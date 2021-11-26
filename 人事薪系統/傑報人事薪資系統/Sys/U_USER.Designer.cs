namespace JBHR.Sys
{
	partial class U_USER
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(U_USER));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ptxNobr = new JBControls.PopupTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.uUSERBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sysDS = new JBHR.Sys.SysDS();
            this.vBASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainDS = new JBHR.MainDS();
            this.cbxAdmin = new JBControls.CheckBox();
            this.cbxSys = new JBControls.CheckBox();
            this.cbxAllApp = new JBControls.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonQueryRule = new System.Windows.Forms.Button();
            this.btnConfig = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox4 = new JBControls.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new JBControls.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new JBControls.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new JBControls.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cOMPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.u_USERTableAdapter = new JBHR.Sys.SysDSTableAdapters.U_USERTableAdapter();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.fullDataCtrl1 = new JBControls.FullDataCtrl();
            this.dataGridViewEx1 = new JBControls.DataGridView();
            this.uSERIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eMAILDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sUPERDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.mANGSUPERDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.aDMINDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.kEYDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.v_BASETableAdapter = new JBHR.MainDSTableAdapters.V_BASETableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uUSERBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vBASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDS)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOMPBindingSource)).BeginInit();
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
            this.panel1.Controls.Add(this.ptxNobr);
            this.panel1.Controls.Add(this.cbxAdmin);
            this.panel1.Controls.Add(this.cbxSys);
            this.panel1.Controls.Add(this.cbxAllApp);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // ptxNobr
            // 
            this.ptxNobr.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ptxNobr.CaptionLabel = this.label5;
            this.ptxNobr.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ptxNobr.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uUSERBindingSource, "NOBR", true));
            this.ptxNobr.DataSource = this.vBASEBindingSource;
            this.ptxNobr.DisplayMember = "name_c";
            this.ptxNobr.IsEmpty = true;
            this.ptxNobr.IsEmptyToQuery = true;
            this.ptxNobr.IsMustBeFound = true;
            this.ptxNobr.LabelText = "";
            resources.ApplyResources(this.ptxNobr, "ptxNobr");
            this.ptxNobr.Name = "ptxNobr";
            this.ptxNobr.ReadOnly = false;
            this.ptxNobr.ShowDisplayName = true;
            this.ptxNobr.ValueMember = "nobr";
            this.ptxNobr.WhereCmd = "";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Name = "label5";
            // 
            // uUSERBindingSource
            // 
            this.uUSERBindingSource.DataMember = "U_USER";
            this.uUSERBindingSource.DataSource = this.sysDS;
            // 
            // sysDS
            // 
            this.sysDS.DataSetName = "SysDS";
            this.sysDS.Locale = new System.Globalization.CultureInfo("");
            this.sysDS.RemotingFormat = System.Data.SerializationFormat.Binary;
            this.sysDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vBASEBindingSource
            // 
            this.vBASEBindingSource.DataMember = "V_BASE";
            this.vBASEBindingSource.DataSource = this.mainDS;
            // 
            // mainDS
            // 
            this.mainDS.DataSetName = "MainDS";
            this.mainDS.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.mainDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cbxAdmin
            // 
            resources.ApplyResources(this.cbxAdmin, "cbxAdmin");
            this.cbxAdmin.CaptionLabel = null;
            this.cbxAdmin.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.uUSERBindingSource, "ADMIN", true));
            this.cbxAdmin.IsImitateCaption = true;
            this.cbxAdmin.Name = "cbxAdmin";
            this.cbxAdmin.TabStop = false;
            this.cbxAdmin.UseVisualStyleBackColor = true;
            // 
            // cbxSys
            // 
            resources.ApplyResources(this.cbxSys, "cbxSys");
            this.cbxSys.CaptionLabel = null;
            this.cbxSys.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.uUSERBindingSource, "MANGSUPER", true));
            this.cbxSys.IsImitateCaption = true;
            this.cbxSys.Name = "cbxSys";
            this.cbxSys.TabStop = false;
            this.cbxSys.UseVisualStyleBackColor = true;
            // 
            // cbxAllApp
            // 
            resources.ApplyResources(this.cbxAllApp, "cbxAllApp");
            this.cbxAllApp.CaptionLabel = null;
            this.cbxAllApp.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.uUSERBindingSource, "SUPER", true));
            this.cbxAllApp.IsImitateCaption = true;
            this.cbxAllApp.Name = "cbxAllApp";
            this.cbxAllApp.TabStop = false;
            this.cbxAllApp.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonQueryRule);
            this.groupBox1.Controls.Add(this.btnConfig);
            this.groupBox1.Controls.Add(this.dataGridView1);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // buttonQueryRule
            // 
            resources.ApplyResources(this.buttonQueryRule, "buttonQueryRule");
            this.buttonQueryRule.Name = "buttonQueryRule";
            this.buttonQueryRule.TabStop = false;
            this.buttonQueryRule.UseVisualStyleBackColor = true;
            this.buttonQueryRule.Click += new System.EventHandler(this.ButtonQueryRule_Click);
            // 
            // btnConfig
            // 
            resources.ApplyResources(this.btnConfig, "btnConfig");
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.TabStop = false;
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.TabStop = false;
            // 
            // textBox4
            // 
            this.textBox4.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox4.CaptionLabel = this.label4;
            this.textBox4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uUSERBindingSource, "PASSWORD", true));
            this.textBox4.DecimalPlace = 2;
            this.textBox4.IsEmpty = false;
            resources.ApplyResources(this.textBox4, "textBox4");
            this.textBox4.Mask = "";
            this.textBox4.MaxLength = 50;
            this.textBox4.Name = "textBox4";
            this.textBox4.PasswordChar = '*';
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
            // textBox3
            // 
            this.textBox3.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox3.CaptionLabel = this.label3;
            this.textBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uUSERBindingSource, "E_MAIL", true));
            this.textBox3.DecimalPlace = 2;
            this.textBox3.IsEmpty = true;
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
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Name = "label3";
            // 
            // textBox2
            // 
            this.textBox2.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox2.CaptionLabel = this.label2;
            this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uUSERBindingSource, "NAME", true));
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
            // textBox1
            // 
            this.textBox1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox1.CaptionLabel = this.label1;
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uUSERBindingSource, "USER_ID", true));
            this.textBox1.DecimalPlace = 2;
            this.textBox1.IsEmpty = false;
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Mask = "";
            this.textBox1.MaxLength = 50;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.ReadOnly = false;
            this.textBox1.ShowCalendarButton = true;
            this.textBox1.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Name = "label1";
            // 
            // cOMPBindingSource
            // 
            this.cOMPBindingSource.DataSource = typeof(JBModule.Data.Linq.COMP);
            // 
            // u_USERTableAdapter
            // 
            this.u_USERTableAdapter.ClearBeforeFill = true;
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
            this.fullDataCtrl1.DataSource = this.uUSERBindingSource;
            this.fullDataCtrl1.DeleteType = JBControls.FullDataCtrl.EDeleteType.Delete;
            resources.ApplyResources(this.fullDataCtrl1, "fullDataCtrl1");
            this.fullDataCtrl1.EnableAutoClone = false;
            this.fullDataCtrl1.GroupCmd = "";
            this.fullDataCtrl1.Name = "fullDataCtrl1";
            this.fullDataCtrl1.QueryFields = "user_id,name,system,workadr";
            this.fullDataCtrl1.RecentQuerySql = "";
            this.fullDataCtrl1.SelectCmd = "";
            this.fullDataCtrl1.ShowExceptionMsg = true;
            this.fullDataCtrl1.SortFields = "user_id";
            this.fullDataCtrl1.WhereCmd = "";
            this.fullDataCtrl1.AfterAdd += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterAdd);
            this.fullDataCtrl1.AfterEdit += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterEdit);
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
            this.uSERIDDataGridViewTextBoxColumn,
            this.nAMEDataGridViewTextBoxColumn,
            this.eMAILDataGridViewTextBoxColumn,
            this.sUPERDataGridViewCheckBoxColumn,
            this.mANGSUPERDataGridViewCheckBoxColumn,
            this.aDMINDataGridViewCheckBoxColumn,
            this.kEYDATEDataGridViewTextBoxColumn,
            this.kEYMANDataGridViewTextBoxColumn});
            this.dataGridViewEx1.DataSource = this.uUSERBindingSource;
            resources.ApplyResources(this.dataGridViewEx1, "dataGridViewEx1");
            this.dataGridViewEx1.MultiSelect = false;
            this.dataGridViewEx1.Name = "dataGridViewEx1";
            this.dataGridViewEx1.ReadOnly = true;
            this.dataGridViewEx1.RowHeadersVisible = false;
            this.dataGridViewEx1.RowTemplate.Height = 24;
            this.dataGridViewEx1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEx1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewEx1_DataError);
            this.dataGridViewEx1.SelectionChanged += new System.EventHandler(this.dataGridViewEx1_SelectionChanged);
            // 
            // uSERIDDataGridViewTextBoxColumn
            // 
            this.uSERIDDataGridViewTextBoxColumn.DataPropertyName = "USER_ID";
            resources.ApplyResources(this.uSERIDDataGridViewTextBoxColumn, "uSERIDDataGridViewTextBoxColumn");
            this.uSERIDDataGridViewTextBoxColumn.Name = "uSERIDDataGridViewTextBoxColumn";
            this.uSERIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nAMEDataGridViewTextBoxColumn
            // 
            this.nAMEDataGridViewTextBoxColumn.DataPropertyName = "NAME";
            resources.ApplyResources(this.nAMEDataGridViewTextBoxColumn, "nAMEDataGridViewTextBoxColumn");
            this.nAMEDataGridViewTextBoxColumn.Name = "nAMEDataGridViewTextBoxColumn";
            this.nAMEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // eMAILDataGridViewTextBoxColumn
            // 
            this.eMAILDataGridViewTextBoxColumn.DataPropertyName = "E_MAIL";
            resources.ApplyResources(this.eMAILDataGridViewTextBoxColumn, "eMAILDataGridViewTextBoxColumn");
            this.eMAILDataGridViewTextBoxColumn.Name = "eMAILDataGridViewTextBoxColumn";
            this.eMAILDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sUPERDataGridViewCheckBoxColumn
            // 
            this.sUPERDataGridViewCheckBoxColumn.DataPropertyName = "SUPER";
            resources.ApplyResources(this.sUPERDataGridViewCheckBoxColumn, "sUPERDataGridViewCheckBoxColumn");
            this.sUPERDataGridViewCheckBoxColumn.Name = "sUPERDataGridViewCheckBoxColumn";
            this.sUPERDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // mANGSUPERDataGridViewCheckBoxColumn
            // 
            this.mANGSUPERDataGridViewCheckBoxColumn.DataPropertyName = "MANGSUPER";
            resources.ApplyResources(this.mANGSUPERDataGridViewCheckBoxColumn, "mANGSUPERDataGridViewCheckBoxColumn");
            this.mANGSUPERDataGridViewCheckBoxColumn.Name = "mANGSUPERDataGridViewCheckBoxColumn";
            this.mANGSUPERDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // aDMINDataGridViewCheckBoxColumn
            // 
            this.aDMINDataGridViewCheckBoxColumn.DataPropertyName = "ADMIN";
            resources.ApplyResources(this.aDMINDataGridViewCheckBoxColumn, "aDMINDataGridViewCheckBoxColumn");
            this.aDMINDataGridViewCheckBoxColumn.Name = "aDMINDataGridViewCheckBoxColumn";
            this.aDMINDataGridViewCheckBoxColumn.ReadOnly = true;
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
            // v_BASETableAdapter
            // 
            this.v_BASETableAdapter.ClearBeforeFill = true;
            // 
            // U_USER
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.FormSize = JBControls.JBForm.FormSizeType.Normal;
            this.KeyPreview = true;
            this.Name = "U_USER";
            this.Load += new System.EventHandler(this.U_USER_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uUSERBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vBASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cOMPBindingSource)).EndInit();
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
		private System.Windows.Forms.BindingSource uUSERBindingSource;
		private JBHR.Sys.SysDSTableAdapters.U_USERTableAdapter u_USERTableAdapter;
		private JBControls.DataGridView dataGridViewEx1;
        private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
        private JBControls.TextBox textBox4;
		private JBControls.TextBox textBox2;
        private JBControls.TextBox textBox1;
        private JBControls.FullDataCtrl fullDataCtrl1;
		private System.Windows.Forms.ErrorProvider errorProvider;
		private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private JBControls.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.BindingSource cOMPBindingSource;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.DataGridView dataGridView1;
        private JBControls.CheckBox cbxAllApp;
        private JBControls.CheckBox cbxAdmin;
        private JBControls.CheckBox cbxSys;
        private System.Windows.Forms.DataGridViewTextBoxColumn uSERIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eMAILDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn sUPERDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn mANGSUPERDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn aDMINDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYMANDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label5;
        private JBControls.PopupTextBox ptxNobr;
        private MainDS mainDS;
        private System.Windows.Forms.BindingSource vBASEBindingSource;
        private MainDSTableAdapters.V_BASETableAdapter v_BASETableAdapter;
        private System.Windows.Forms.Button buttonQueryRule;
    }
}