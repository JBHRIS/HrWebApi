namespace JBHR.Sys
{
	partial class SYS_CODE
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.sysDS = new JBHR.Sys.SysDS();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox1 = new JBControls.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cODEFILTERBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vwCompDatagroupBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.MEMOTextBox = new JBControls.TextBox();
            this.vwCompCodeGroupBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.fullDataCtrl1 = new JBControls.FullDataCtrl();
            this.dataGridViewEx1 = new JBControls.DataGridView();
            this.cODEGROUPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nOTEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.cODE_FILTERTableAdapter = new JBHR.Sys.SysDSTableAdapters.CODE_FILTERTableAdapter();
            this.vw_Comp_Code_GroupTableAdapter = new JBHR.Sys.SysDSTableAdapters.vw_Comp_Code_GroupTableAdapter();
            this.vw_Comp_DatagroupTableAdapter = new JBHR.Sys.SysDSTableAdapters.vw_Comp_DatagroupTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sysDS)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cODEFILTERBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwCompDatagroupBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwCompCodeGroupBindingSource)).BeginInit();
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
            // sysDS
            // 
            this.sysDS.DataSetName = "SysDS";
            this.sysDS.Locale = new System.Globalization.CultureInfo("");
            this.sysDS.RemotingFormat = System.Data.SerializationFormat.Binary;
            this.sysDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.MEMOTextBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 76);
            this.panel1.TabIndex = 6;
            // 
            // comboBox1
            // 
            this.comboBox1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.comboBox1.BackColor = System.Drawing.SystemColors.Control;
            this.comboBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.comboBox1.CaptionLabel = this.label1;
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.cODEFILTERBindingSource, "CODEGROUP", true));
            this.comboBox1.DataSource = this.vwCompDatagroupBindingSource;
            this.comboBox1.DisplayMember = "groupname";
            this.comboBox1.DropDownCount = 10;
            this.comboBox1.IsDisplayValueLabel = true;
            this.comboBox1.IsEmpty = false;
            this.comboBox1.Location = new System.Drawing.Point(92, 8);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.SelectedValue = "";
            this.comboBox1.Size = new System.Drawing.Size(124, 22);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.ValueMember = "datagroup";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(33, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "代碼群組";
            // 
            // cODEFILTERBindingSource
            // 
            this.cODEFILTERBindingSource.DataMember = "CODE_FILTER";
            this.cODEFILTERBindingSource.DataSource = this.sysDS;
            // 
            // vwCompDatagroupBindingSource
            // 
            this.vwCompDatagroupBindingSource.DataMember = "vw_Comp_Datagroup";
            this.vwCompDatagroupBindingSource.DataSource = this.sysDS;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(57, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "備註";
            // 
            // MEMOTextBox
            // 
            this.MEMOTextBox.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.MEMOTextBox.CaptionLabel = this.label4;
            this.MEMOTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.MEMOTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cODEFILTERBindingSource, "NOTE", true));
            this.MEMOTextBox.DecimalPlace = 2;
            this.MEMOTextBox.IsEmpty = true;
            this.MEMOTextBox.Location = new System.Drawing.Point(92, 36);
            this.MEMOTextBox.Mask = "";
            this.MEMOTextBox.MaxLength = 500;
            this.MEMOTextBox.Name = "MEMOTextBox";
            this.MEMOTextBox.PasswordChar = '\0';
            this.MEMOTextBox.ReadOnly = false;
            this.MEMOTextBox.ShowCalendarButton = true;
            this.MEMOTextBox.Size = new System.Drawing.Size(236, 22);
            this.MEMOTextBox.TabIndex = 1;
            this.MEMOTextBox.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // vwCompCodeGroupBindingSource
            // 
            this.vwCompCodeGroupBindingSource.DataMember = "vw_Comp_Code_Group";
            this.vwCompCodeGroupBindingSource.DataSource = this.sysDS;
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
            this.fullDataCtrl1.DataSource = this.cODEFILTERBindingSource;
            this.fullDataCtrl1.DeleteType = JBControls.FullDataCtrl.EDeleteType.Delete;
            this.fullDataCtrl1.EnableAutoClone = false;
            this.fullDataCtrl1.GroupCmd = "";
            this.fullDataCtrl1.Location = new System.Drawing.Point(-2, -2);
            this.fullDataCtrl1.Name = "fullDataCtrl1";
            this.fullDataCtrl1.QueryFields = "yymm";
            this.fullDataCtrl1.RecentQuerySql = "";
            this.fullDataCtrl1.SelectCmd = "";
            this.fullDataCtrl1.ShowExceptionMsg = true;
            this.fullDataCtrl1.Size = new System.Drawing.Size(636, 73);
            this.fullDataCtrl1.SortFields = "yymm,seq";
            this.fullDataCtrl1.TabIndex = 5;
            this.fullDataCtrl1.WhereCmd = "";
            this.fullDataCtrl1.AfterAdd += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterAdd);
            this.fullDataCtrl1.BeforeDel += new JBControls.FullDataCtrl.BeforeEventHandler(this.fullDataCtrl1_BeforeDel);
            this.fullDataCtrl1.AfterDel += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterDel);
            this.fullDataCtrl1.BeforeSave += new JBControls.FullDataCtrl.BeforeEventHandler(this.fullDataCtrl1_BeforeSave);
            this.fullDataCtrl1.AfterSave += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterSave);
            this.fullDataCtrl1.AfterExport += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterExport);
            // 
            // dataGridViewEx1
            // 
            this.dataGridViewEx1.AllowUserToAddRows = false;
            this.dataGridViewEx1.AllowUserToDeleteRows = false;
            this.dataGridViewEx1.AllowUserToResizeRows = false;
            this.dataGridViewEx1.AutoGenerateColumns = false;
            this.dataGridViewEx1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("細明體", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewEx1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewEx1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEx1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cODEGROUPDataGridViewTextBoxColumn,
            this.nOTEDataGridViewTextBoxColumn,
            this.kEYDATEDataGridViewTextBoxColumn,
            this.kEYMANDataGridViewTextBoxColumn});
            this.dataGridViewEx1.DataSource = this.cODEFILTERBindingSource;
            this.dataGridViewEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEx1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewEx1.MultiSelect = false;
            this.dataGridViewEx1.Name = "dataGridViewEx1";
            this.dataGridViewEx1.ReadOnly = true;
            this.dataGridViewEx1.RowHeadersVisible = false;
            this.dataGridViewEx1.RowTemplate.Height = 24;
            this.dataGridViewEx1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEx1.Size = new System.Drawing.Size(626, 286);
            this.dataGridViewEx1.TabIndex = 4;
            // 
            // cODEGROUPDataGridViewTextBoxColumn
            // 
            this.cODEGROUPDataGridViewTextBoxColumn.DataPropertyName = "CODEGROUP";
            this.cODEGROUPDataGridViewTextBoxColumn.HeaderText = "代碼群組";
            this.cODEGROUPDataGridViewTextBoxColumn.Name = "cODEGROUPDataGridViewTextBoxColumn";
            this.cODEGROUPDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nOTEDataGridViewTextBoxColumn
            // 
            this.nOTEDataGridViewTextBoxColumn.DataPropertyName = "NOTE";
            this.nOTEDataGridViewTextBoxColumn.HeaderText = "備註";
            this.nOTEDataGridViewTextBoxColumn.Name = "nOTEDataGridViewTextBoxColumn";
            this.nOTEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // kEYDATEDataGridViewTextBoxColumn
            // 
            this.kEYDATEDataGridViewTextBoxColumn.DataPropertyName = "KEY_DATE";
            this.kEYDATEDataGridViewTextBoxColumn.HeaderText = "登錄日期";
            this.kEYDATEDataGridViewTextBoxColumn.Name = "kEYDATEDataGridViewTextBoxColumn";
            this.kEYDATEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // kEYMANDataGridViewTextBoxColumn
            // 
            this.kEYMANDataGridViewTextBoxColumn.DataPropertyName = "KEY_MAN";
            this.kEYMANDataGridViewTextBoxColumn.HeaderText = "登錄者";
            this.kEYMANDataGridViewTextBoxColumn.Name = "kEYMANDataGridViewTextBoxColumn";
            this.kEYMANDataGridViewTextBoxColumn.ReadOnly = true;
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
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewEx1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(626, 441);
            this.splitContainer1.SplitterDistance = 286;
            this.splitContainer1.TabIndex = 7;
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
            this.splitContainer2.Size = new System.Drawing.Size(626, 151);
            this.splitContainer2.SplitterDistance = 76;
            this.splitContainer2.TabIndex = 0;
            // 
            // cODE_FILTERTableAdapter
            // 
            this.cODE_FILTERTableAdapter.ClearBeforeFill = true;
            // 
            // vw_Comp_Code_GroupTableAdapter
            // 
            this.vw_Comp_Code_GroupTableAdapter.ClearBeforeFill = true;
            // 
            // vw_Comp_DatagroupTableAdapter
            // 
            this.vw_Comp_DatagroupTableAdapter.ClearBeforeFill = true;
            // 
            // SYS_CODE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 441);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "SYS_CODE";
            this.Text = "FRMG15";
            this.Load += new System.EventHandler(this.FRMG12_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sysDS)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cODEFILTERBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwCompDatagroupBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwCompCodeGroupBindingSource)).EndInit();
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

		private JBControls.DataGridView dataGridViewEx1;
		private JBControls.FullDataCtrl fullDataCtrl1;
        private SysDS sysDS;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label1;
		private JBControls.TextBox MEMOTextBox;
        private System.Windows.Forms.ErrorProvider errorProvider;
		private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dATAGROUPDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource cODEFILTERBindingSource;
        private SysDSTableAdapters.CODE_FILTERTableAdapter cODE_FILTERTableAdapter;
        private JBControls.ComboBox comboBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cODEGROUPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOTEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYMANDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource vwCompCodeGroupBindingSource;
        private SysDSTableAdapters.vw_Comp_Code_GroupTableAdapter vw_Comp_Code_GroupTableAdapter;
        private System.Windows.Forms.BindingSource vwCompDatagroupBindingSource;
        private SysDSTableAdapters.vw_Comp_DatagroupTableAdapter vw_Comp_DatagroupTableAdapter;
	}
}