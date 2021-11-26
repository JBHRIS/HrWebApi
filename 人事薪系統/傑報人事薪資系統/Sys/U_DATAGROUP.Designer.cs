namespace JBHR.Sys
{
	partial class U_DATAGROUP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(U_DATAGROUP));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.uDATAGROUPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sysDS = new JBHR.Sys.SysDS();
            this.checkBox2 = new JBControls.CheckBox();
            this.checkBox1 = new JBControls.CheckBox();
            this.textBox2 = new JBControls.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dATAGROUPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.fullDataCtrl1 = new JBControls.FullDataCtrl();
            this.dataGridViewEx1 = new JBControls.DataGridView();
            this.dATAGROUPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATAGROUP = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.rEADRULEDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.wRITERULEDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nOTEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.u_DATAGROUPTableAdapter = new JBHR.Sys.SysDSTableAdapters.U_DATAGROUPTableAdapter();
            this.dATAGROUPTableAdapter = new JBHR.Sys.SysDSTableAdapters.DATAGROUPTableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uDATAGROUPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dATAGROUPBindingSource)).BeginInit();
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
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // comboBox2
            // 
            this.comboBox2.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.uDATAGROUPBindingSource, "DATAGROUP", true));
            this.comboBox2.DisplayMember = "disp";
            this.comboBox2.FormattingEnabled = true;
            resources.ApplyResources(this.comboBox2, "comboBox2");
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.ValueMember = "val";
            // 
            // uDATAGROUPBindingSource
            // 
            this.uDATAGROUPBindingSource.DataMember = "U_DATAGROUP";
            this.uDATAGROUPBindingSource.DataSource = this.sysDS;
            // 
            // sysDS
            // 
            this.sysDS.DataSetName = "SysDS";
            this.sysDS.Locale = new System.Globalization.CultureInfo("");
            this.sysDS.RemotingFormat = System.Data.SerializationFormat.Binary;
            this.sysDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // checkBox2
            // 
            resources.ApplyResources(this.checkBox2, "checkBox2");
            this.checkBox2.CaptionLabel = null;
            this.checkBox2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.uDATAGROUPBindingSource, "WRITERULE", true));
            this.checkBox2.IsImitateCaption = true;
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.TabStop = false;
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.CaptionLabel = null;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.uDATAGROUPBindingSource, "READRULE", true));
            this.checkBox1.IsImitateCaption = true;
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.TabStop = false;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox2.CaptionLabel = this.label2;
            this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uDATAGROUPBindingSource, "NOTE", true));
            this.textBox2.DecimalPlace = 2;
            this.textBox2.IsEmpty = true;
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.Mask = "";
            this.textBox2.MaxLength = 500;
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '\0';
            this.textBox2.ReadOnly = false;
            this.textBox2.ShowCalendarButton = true;
            this.textBox2.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Name = "label1";
            // 
            // dATAGROUPBindingSource
            // 
            this.dATAGROUPBindingSource.DataMember = "DATAGROUP";
            this.dATAGROUPBindingSource.DataSource = this.sysDS;
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
            this.fullDataCtrl1.DataSource = this.uDATAGROUPBindingSource;
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
            this.dATAGROUPDataGridViewTextBoxColumn,
            this.DATAGROUP,
            this.rEADRULEDataGridViewCheckBoxColumn,
            this.wRITERULEDataGridViewCheckBoxColumn,
            this.nOTEDataGridViewTextBoxColumn,
            this.kEYDATEDataGridViewTextBoxColumn,
            this.kEYMANDataGridViewTextBoxColumn});
            this.dataGridViewEx1.DataSource = this.uDATAGROUPBindingSource;
            resources.ApplyResources(this.dataGridViewEx1, "dataGridViewEx1");
            this.dataGridViewEx1.MultiSelect = false;
            this.dataGridViewEx1.Name = "dataGridViewEx1";
            this.dataGridViewEx1.ReadOnly = true;
            this.dataGridViewEx1.RowHeadersVisible = false;
            this.dataGridViewEx1.RowTemplate.Height = 24;
            this.dataGridViewEx1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEx1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewEx1_DataError);
            // 
            // dATAGROUPDataGridViewTextBoxColumn
            // 
            this.dATAGROUPDataGridViewTextBoxColumn.DataPropertyName = "DATAGROUP";
            resources.ApplyResources(this.dATAGROUPDataGridViewTextBoxColumn, "dATAGROUPDataGridViewTextBoxColumn");
            this.dATAGROUPDataGridViewTextBoxColumn.Name = "dATAGROUPDataGridViewTextBoxColumn";
            this.dATAGROUPDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // DATAGROUP
            // 
            this.DATAGROUP.DataPropertyName = "DATAGROUP";
            this.DATAGROUP.DataSource = this.dATAGROUPBindingSource;
            this.DATAGROUP.DisplayMember = "GROUPNAME";
            this.DATAGROUP.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            resources.ApplyResources(this.DATAGROUP, "DATAGROUP");
            this.DATAGROUP.Name = "DATAGROUP";
            this.DATAGROUP.ReadOnly = true;
            this.DATAGROUP.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DATAGROUP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DATAGROUP.ValueMember = "DATAGROUP";
            // 
            // rEADRULEDataGridViewCheckBoxColumn
            // 
            this.rEADRULEDataGridViewCheckBoxColumn.DataPropertyName = "READRULE";
            resources.ApplyResources(this.rEADRULEDataGridViewCheckBoxColumn, "rEADRULEDataGridViewCheckBoxColumn");
            this.rEADRULEDataGridViewCheckBoxColumn.Name = "rEADRULEDataGridViewCheckBoxColumn";
            this.rEADRULEDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // wRITERULEDataGridViewCheckBoxColumn
            // 
            this.wRITERULEDataGridViewCheckBoxColumn.DataPropertyName = "WRITERULE";
            resources.ApplyResources(this.wRITERULEDataGridViewCheckBoxColumn, "wRITERULEDataGridViewCheckBoxColumn");
            this.wRITERULEDataGridViewCheckBoxColumn.Name = "wRITERULEDataGridViewCheckBoxColumn";
            this.wRITERULEDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // nOTEDataGridViewTextBoxColumn
            // 
            this.nOTEDataGridViewTextBoxColumn.DataPropertyName = "NOTE";
            resources.ApplyResources(this.nOTEDataGridViewTextBoxColumn, "nOTEDataGridViewTextBoxColumn");
            this.nOTEDataGridViewTextBoxColumn.Name = "nOTEDataGridViewTextBoxColumn";
            this.nOTEDataGridViewTextBoxColumn.ReadOnly = true;
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
            // u_DATAGROUPTableAdapter
            // 
            this.u_DATAGROUPTableAdapter.ClearBeforeFill = true;
            // 
            // dATAGROUPTableAdapter
            // 
            this.dATAGROUPTableAdapter.ClearBeforeFill = true;
            // 
            // U_DATAGROUP
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "U_DATAGROUP";
            this.Load += new System.EventHandler(this.U_USER_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uDATAGROUPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dATAGROUPBindingSource)).EndInit();
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
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private JBControls.TextBox textBox2;
        private JBControls.FullDataCtrl fullDataCtrl1;
		private System.Windows.Forms.ErrorProvider errorProvider;
		private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.BindingSource uDATAGROUPBindingSource;
        private SysDSTableAdapters.U_DATAGROUPTableAdapter u_DATAGROUPTableAdapter;
        private System.Windows.Forms.BindingSource dATAGROUPBindingSource;
        private SysDSTableAdapters.DATAGROUPTableAdapter dATAGROUPTableAdapter;
        private JBControls.CheckBox checkBox2;
        private JBControls.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dATAGROUPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn DATAGROUP;
        private System.Windows.Forms.DataGridViewCheckBoxColumn rEADRULEDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn wRITERULEDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOTEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYMANDataGridViewTextBoxColumn;
	}
}