namespace JBHR.Bas
{
	partial class FRM11X
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
            this.dataGridViewEx1 = new JBControls.DataGridView();
            this.dNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dNODISPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dSUMDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.kEYDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eXPDEPTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.basDS = new JBHR.Bas.BasDS();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCodeGroup = new System.Windows.Forms.Button();
            this.cKD_SUM = new JBControls.CheckBox();
            this.txtD_NAME = new JBControls.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtD_NO_DISP = new JBControls.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fullDataCtrl1 = new JBControls.FullDataCtrl();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.eXP_DEPTTableAdapter = new JBHR.Bas.BasDSTableAdapters.EXP_DEPTTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eXPDEPTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.basDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewEx1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(626, 441);
            this.splitContainer1.SplitterDistance = 281;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridViewEx1
            // 
            this.dataGridViewEx1.AllowUserToAddRows = false;
            this.dataGridViewEx1.AllowUserToDeleteRows = false;
            this.dataGridViewEx1.AllowUserToResizeRows = false;
            this.dataGridViewEx1.AutoGenerateColumns = false;
            this.dataGridViewEx1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("細明體", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewEx1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewEx1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEx1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dNODataGridViewTextBoxColumn,
            this.dNODISPDataGridViewTextBoxColumn,
            this.dNAMEDataGridViewTextBoxColumn,
            this.dSUMDataGridViewCheckBoxColumn,
            this.kEYDATEDataGridViewTextBoxColumn,
            this.kEYMANDataGridViewTextBoxColumn});
            this.dataGridViewEx1.DataSource = this.eXPDEPTBindingSource;
            this.dataGridViewEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEx1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewEx1.MultiSelect = false;
            this.dataGridViewEx1.Name = "dataGridViewEx1";
            this.dataGridViewEx1.ReadOnly = true;
            this.dataGridViewEx1.RowHeadersVisible = false;
            this.dataGridViewEx1.RowTemplate.Height = 24;
            this.dataGridViewEx1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEx1.Size = new System.Drawing.Size(626, 281);
            this.dataGridViewEx1.TabIndex = 7;
            // 
            // dNODataGridViewTextBoxColumn
            // 
            this.dNODataGridViewTextBoxColumn.DataPropertyName = "D_NO";
            this.dNODataGridViewTextBoxColumn.HeaderText = "費用代碼";
            this.dNODataGridViewTextBoxColumn.Name = "dNODataGridViewTextBoxColumn";
            this.dNODataGridViewTextBoxColumn.ReadOnly = true;
            this.dNODataGridViewTextBoxColumn.Visible = false;
            // 
            // dNODISPDataGridViewTextBoxColumn
            // 
            this.dNODISPDataGridViewTextBoxColumn.DataPropertyName = "D_NO_DISP";
            this.dNODISPDataGridViewTextBoxColumn.HeaderText = "費用代碼";
            this.dNODISPDataGridViewTextBoxColumn.Name = "dNODISPDataGridViewTextBoxColumn";
            this.dNODISPDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dNAMEDataGridViewTextBoxColumn
            // 
            this.dNAMEDataGridViewTextBoxColumn.DataPropertyName = "D_NAME";
            this.dNAMEDataGridViewTextBoxColumn.HeaderText = "費用名稱";
            this.dNAMEDataGridViewTextBoxColumn.Name = "dNAMEDataGridViewTextBoxColumn";
            this.dNAMEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dSUMDataGridViewCheckBoxColumn
            // 
            this.dSUMDataGridViewCheckBoxColumn.DataPropertyName = "D_SUM";
            this.dSUMDataGridViewCheckBoxColumn.HeaderText = "加總欄位";
            this.dSUMDataGridViewCheckBoxColumn.Name = "dSUMDataGridViewCheckBoxColumn";
            this.dSUMDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // kEYDATEDataGridViewTextBoxColumn
            // 
            this.kEYDATEDataGridViewTextBoxColumn.DataPropertyName = "KEY_DATE";
            this.kEYDATEDataGridViewTextBoxColumn.HeaderText = "登入者";
            this.kEYDATEDataGridViewTextBoxColumn.Name = "kEYDATEDataGridViewTextBoxColumn";
            this.kEYDATEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // kEYMANDataGridViewTextBoxColumn
            // 
            this.kEYMANDataGridViewTextBoxColumn.DataPropertyName = "KEY_MAN";
            this.kEYMANDataGridViewTextBoxColumn.HeaderText = "登入時間";
            this.kEYMANDataGridViewTextBoxColumn.Name = "kEYMANDataGridViewTextBoxColumn";
            this.kEYMANDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // eXPDEPTBindingSource
            // 
            this.eXPDEPTBindingSource.DataMember = "EXP_DEPT";
            this.eXPDEPTBindingSource.DataSource = this.basDS;
            // 
            // basDS
            // 
            this.basDS.DataSetName = "BasDS";
            this.basDS.Locale = new System.Globalization.CultureInfo("");
            this.basDS.RemotingFormat = System.Data.SerializationFormat.Binary;
            this.basDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.splitContainer2.Size = new System.Drawing.Size(626, 156);
            this.splitContainer2.SplitterDistance = 80;
            this.splitContainer2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnCodeGroup);
            this.panel1.Controls.Add(this.cKD_SUM);
            this.panel1.Controls.Add(this.txtD_NAME);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtD_NO_DISP);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 80);
            this.panel1.TabIndex = 0;
            // 
            // btnCodeGroup
            // 
            this.btnCodeGroup.Location = new System.Drawing.Point(547, 56);
            this.btnCodeGroup.Name = "btnCodeGroup";
            this.btnCodeGroup.Size = new System.Drawing.Size(75, 23);
            this.btnCodeGroup.TabIndex = 8;
            this.btnCodeGroup.TabStop = false;
            this.btnCodeGroup.Text = "代碼群組";
            this.btnCodeGroup.UseVisualStyleBackColor = true;
            this.btnCodeGroup.Click += new System.EventHandler(this.btnCodeGroup_Click);
            // 
            // cKD_SUM
            // 
            this.cKD_SUM.AutoSize = true;
            this.cKD_SUM.CaptionLabel = null;
            this.cKD_SUM.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.eXPDEPTBindingSource, "D_SUM", true));
            this.cKD_SUM.IsImitateCaption = true;
            this.cKD_SUM.Location = new System.Drawing.Point(96, 60);
            this.cKD_SUM.Name = "cKD_SUM";
            this.cKD_SUM.Size = new System.Drawing.Size(72, 16);
            this.cKD_SUM.TabIndex = 7;
            this.cKD_SUM.TabStop = false;
            this.cKD_SUM.Text = "加總欄位";
            this.cKD_SUM.UseVisualStyleBackColor = true;
            // 
            // txtD_NAME
            // 
            this.txtD_NAME.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtD_NAME.CaptionLabel = this.label2;
            this.txtD_NAME.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtD_NAME.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eXPDEPTBindingSource, "D_NAME", true));
            this.txtD_NAME.DecimalPlace = 2;
            this.txtD_NAME.IsEmpty = false;
            this.txtD_NAME.Location = new System.Drawing.Point(96, 31);
            this.txtD_NAME.Mask = "";
            this.txtD_NAME.MaxLength = 50;
            this.txtD_NAME.Name = "txtD_NAME";
            this.txtD_NAME.PasswordChar = '\0';
            this.txtD_NAME.ReadOnly = false;
            this.txtD_NAME.ShowCalendarButton = true;
            this.txtD_NAME.Size = new System.Drawing.Size(169, 22);
            this.txtD_NAME.TabIndex = 1;
            this.txtD_NAME.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(37, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "費用名稱";
            // 
            // txtD_NO_DISP
            // 
            this.txtD_NO_DISP.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtD_NO_DISP.CaptionLabel = this.label1;
            this.txtD_NO_DISP.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtD_NO_DISP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eXPDEPTBindingSource, "D_NO_DISP", true));
            this.txtD_NO_DISP.DecimalPlace = 2;
            this.txtD_NO_DISP.IsEmpty = false;
            this.txtD_NO_DISP.Location = new System.Drawing.Point(96, 3);
            this.txtD_NO_DISP.Mask = "";
            this.txtD_NO_DISP.MaxLength = 50;
            this.txtD_NO_DISP.Name = "txtD_NO_DISP";
            this.txtD_NO_DISP.PasswordChar = '\0';
            this.txtD_NO_DISP.ReadOnly = false;
            this.txtD_NO_DISP.ShowCalendarButton = true;
            this.txtD_NO_DISP.Size = new System.Drawing.Size(100, 22);
            this.txtD_NO_DISP.TabIndex = 0;
            this.txtD_NO_DISP.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(37, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "費用代碼";
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
            this.fullDataCtrl1.DataSource = this.eXPDEPTBindingSource;
            this.fullDataCtrl1.DeleteType = JBControls.FullDataCtrl.EDeleteType.Delete;
            this.fullDataCtrl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.fullDataCtrl1.EnableAutoClone = false;
            this.fullDataCtrl1.GroupCmd = "";
            this.fullDataCtrl1.Location = new System.Drawing.Point(0, 0);
            this.fullDataCtrl1.Name = "fullDataCtrl1";
            this.fullDataCtrl1.QueryFields = "empcd,empdescr";
            this.fullDataCtrl1.RecentQuerySql = "";
            this.fullDataCtrl1.SelectCmd = "";
            this.fullDataCtrl1.ShowExceptionMsg = true;
            this.fullDataCtrl1.Size = new System.Drawing.Size(626, 73);
            this.fullDataCtrl1.SortFields = "empcd,empdescr";
            this.fullDataCtrl1.TabIndex = 0;
            this.fullDataCtrl1.WhereCmd = "";
            this.fullDataCtrl1.AfterDel += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterDel);
            this.fullDataCtrl1.BeforeSave += new JBControls.FullDataCtrl.BeforeEventHandler(this.fullDataCtrl1_BeforeSave);
            this.fullDataCtrl1.AfterSave += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterSave);
            this.fullDataCtrl1.AfterExport += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterExport);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // eXP_DEPTTableAdapter
            // 
            this.eXP_DEPTTableAdapter.ClearBeforeFill = true;
            // 
            // FRM11X
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 441);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "FRM11X";
            this.Text = "FRM11X";
            this.Load += new System.EventHandler(this.FRM11D_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eXPDEPTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.basDS)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private JBControls.DataGridView dataGridViewEx1;
		private JBControls.FullDataCtrl fullDataCtrl1;
		private System.Windows.Forms.Panel panel1;
		private JBControls.TextBox txtD_NAME;
		private System.Windows.Forms.Label label2;
		private JBControls.TextBox txtD_NO_DISP;
		private System.Windows.Forms.Label label1;
		private JBControls.CheckBox cKD_SUM;
        private BasDS basDS;
		private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.BindingSource eXPDEPTBindingSource;
        private BasDSTableAdapters.EXP_DEPTTableAdapter eXP_DEPTTableAdapter;
        private System.Windows.Forms.Button btnCodeGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn dNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dNODISPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dSUMDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYMANDataGridViewTextBoxColumn;
	}
}