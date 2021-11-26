using JBHR.Wel;
namespace JBHR.TRA
{
	partial class FRM92
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
            this.tRCOMPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tRCOMPDISPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tRCOMPNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tELDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tRCOMPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.traDS1 = new JBHR.TRA.traDS1();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTEL = new JBControls.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTR_COMP_NAME = new JBControls.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTR_COMP_DISP = new JBControls.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fullDataCtrl1 = new JBControls.FullDataCtrl();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tRCOMPTableAdapter = new JBHR.TRA.traDS1TableAdapters.TRCOMPTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tRCOMPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.traDS1)).BeginInit();
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
            this.splitContainer1.SplitterDistance = 260;
            this.splitContainer1.TabIndex = 10;
            // 
            // dataGridViewEx1
            // 
            this.dataGridViewEx1.AllowUserToAddRows = false;
            this.dataGridViewEx1.AllowUserToDeleteRows = false;
            this.dataGridViewEx1.AllowUserToResizeRows = false;
            this.dataGridViewEx1.AutoGenerateColumns = false;
            this.dataGridViewEx1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
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
            this.tRCOMPDataGridViewTextBoxColumn,
            this.tRCOMPDISPDataGridViewTextBoxColumn,
            this.tRCOMPNAMEDataGridViewTextBoxColumn,
            this.tELDataGridViewTextBoxColumn,
            this.kEYDATEDataGridViewTextBoxColumn,
            this.kEYMANDataGridViewTextBoxColumn});
            this.dataGridViewEx1.DataSource = this.tRCOMPBindingSource;
            this.dataGridViewEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEx1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewEx1.MultiSelect = false;
            this.dataGridViewEx1.Name = "dataGridViewEx1";
            this.dataGridViewEx1.ReadOnly = true;
            this.dataGridViewEx1.RowHeadersVisible = false;
            this.dataGridViewEx1.RowTemplate.Height = 24;
            this.dataGridViewEx1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEx1.Size = new System.Drawing.Size(626, 260);
            this.dataGridViewEx1.TabIndex = 6;
            this.dataGridViewEx1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewEx1_DataError);
            // 
            // tRCOMPDataGridViewTextBoxColumn
            // 
            this.tRCOMPDataGridViewTextBoxColumn.DataPropertyName = "TR_COMP";
            this.tRCOMPDataGridViewTextBoxColumn.HeaderText = "承辦單位代碼";
            this.tRCOMPDataGridViewTextBoxColumn.Name = "tRCOMPDataGridViewTextBoxColumn";
            this.tRCOMPDataGridViewTextBoxColumn.ReadOnly = true;
            this.tRCOMPDataGridViewTextBoxColumn.Visible = false;
            this.tRCOMPDataGridViewTextBoxColumn.Width = 83;
            // 
            // tRCOMPDISPDataGridViewTextBoxColumn
            // 
            this.tRCOMPDISPDataGridViewTextBoxColumn.DataPropertyName = "TR_COMP_DISP";
            this.tRCOMPDISPDataGridViewTextBoxColumn.HeaderText = "承辦單位代碼";
            this.tRCOMPDISPDataGridViewTextBoxColumn.Name = "tRCOMPDISPDataGridViewTextBoxColumn";
            this.tRCOMPDISPDataGridViewTextBoxColumn.ReadOnly = true;
            this.tRCOMPDISPDataGridViewTextBoxColumn.Width = 102;
            // 
            // tRCOMPNAMEDataGridViewTextBoxColumn
            // 
            this.tRCOMPNAMEDataGridViewTextBoxColumn.DataPropertyName = "TR_COMP_NAME";
            this.tRCOMPNAMEDataGridViewTextBoxColumn.HeaderText = "承辦單位";
            this.tRCOMPNAMEDataGridViewTextBoxColumn.Name = "tRCOMPNAMEDataGridViewTextBoxColumn";
            this.tRCOMPNAMEDataGridViewTextBoxColumn.ReadOnly = true;
            this.tRCOMPNAMEDataGridViewTextBoxColumn.Width = 78;
            // 
            // tELDataGridViewTextBoxColumn
            // 
            this.tELDataGridViewTextBoxColumn.DataPropertyName = "TEL";
            this.tELDataGridViewTextBoxColumn.HeaderText = "聯絡電話";
            this.tELDataGridViewTextBoxColumn.Name = "tELDataGridViewTextBoxColumn";
            this.tELDataGridViewTextBoxColumn.ReadOnly = true;
            this.tELDataGridViewTextBoxColumn.Width = 78;
            // 
            // kEYDATEDataGridViewTextBoxColumn
            // 
            this.kEYDATEDataGridViewTextBoxColumn.DataPropertyName = "KEY_DATE";
            this.kEYDATEDataGridViewTextBoxColumn.HeaderText = "建檔日期";
            this.kEYDATEDataGridViewTextBoxColumn.Name = "kEYDATEDataGridViewTextBoxColumn";
            this.kEYDATEDataGridViewTextBoxColumn.ReadOnly = true;
            this.kEYDATEDataGridViewTextBoxColumn.Width = 78;
            // 
            // kEYMANDataGridViewTextBoxColumn
            // 
            this.kEYMANDataGridViewTextBoxColumn.DataPropertyName = "KEY_MAN";
            this.kEYMANDataGridViewTextBoxColumn.HeaderText = "建檔人員";
            this.kEYMANDataGridViewTextBoxColumn.Name = "kEYMANDataGridViewTextBoxColumn";
            this.kEYMANDataGridViewTextBoxColumn.ReadOnly = true;
            this.kEYMANDataGridViewTextBoxColumn.Width = 78;
            // 
            // tRCOMPBindingSource
            // 
            this.tRCOMPBindingSource.DataMember = "TRCOMP";
            this.tRCOMPBindingSource.DataSource = this.traDS1;
            // 
            // traDS1
            // 
            this.traDS1.DataSetName = "traDS1";
            this.traDS1.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.traDS1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.splitContainer2.Size = new System.Drawing.Size(626, 177);
            this.splitContainer2.SplitterDistance = 97;
            this.splitContainer2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtTEL);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtTR_COMP_NAME);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtTR_COMP_DISP);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 97);
            this.panel1.TabIndex = 7;
            // 
            // txtTEL
            // 
            this.txtTEL.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtTEL.CaptionLabel = this.label3;
            this.txtTEL.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTEL.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tRCOMPBindingSource, "TEL", true));
            this.txtTEL.DecimalPlace = 2;
            this.txtTEL.IsEmpty = true;
            this.txtTEL.Location = new System.Drawing.Point(93, 63);
            this.txtTEL.Mask = "";
            this.txtTEL.MaxLength = 50;
            this.txtTEL.Name = "txtTEL";
            this.txtTEL.PasswordChar = '\0';
            this.txtTEL.ReadOnly = false;
            this.txtTEL.ShowCalendarButton = true;
            this.txtTEL.Size = new System.Drawing.Size(100, 22);
            this.txtTEL.TabIndex = 2;
            this.txtTEL.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(34, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "聯絡電話";
            // 
            // txtTR_COMP_NAME
            // 
            this.txtTR_COMP_NAME.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtTR_COMP_NAME.CaptionLabel = this.label2;
            this.txtTR_COMP_NAME.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTR_COMP_NAME.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tRCOMPBindingSource, "TR_COMP_NAME", true));
            this.txtTR_COMP_NAME.DecimalPlace = 2;
            this.txtTR_COMP_NAME.IsEmpty = false;
            this.txtTR_COMP_NAME.Location = new System.Drawing.Point(93, 35);
            this.txtTR_COMP_NAME.Mask = "";
            this.txtTR_COMP_NAME.MaxLength = 50;
            this.txtTR_COMP_NAME.Name = "txtTR_COMP_NAME";
            this.txtTR_COMP_NAME.PasswordChar = '\0';
            this.txtTR_COMP_NAME.ReadOnly = false;
            this.txtTR_COMP_NAME.ShowCalendarButton = true;
            this.txtTR_COMP_NAME.Size = new System.Drawing.Size(100, 22);
            this.txtTR_COMP_NAME.TabIndex = 1;
            this.txtTR_COMP_NAME.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(34, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "承辦單位";
            // 
            // txtTR_COMP_DISP
            // 
            this.txtTR_COMP_DISP.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtTR_COMP_DISP.CaptionLabel = this.label1;
            this.txtTR_COMP_DISP.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTR_COMP_DISP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tRCOMPBindingSource, "TR_COMP_DISP", true));
            this.txtTR_COMP_DISP.DecimalPlace = 2;
            this.txtTR_COMP_DISP.IsEmpty = false;
            this.txtTR_COMP_DISP.Location = new System.Drawing.Point(93, 7);
            this.txtTR_COMP_DISP.Mask = "";
            this.txtTR_COMP_DISP.MaxLength = 50;
            this.txtTR_COMP_DISP.Name = "txtTR_COMP_DISP";
            this.txtTR_COMP_DISP.PasswordChar = '\0';
            this.txtTR_COMP_DISP.ReadOnly = false;
            this.txtTR_COMP_DISP.ShowCalendarButton = true;
            this.txtTR_COMP_DISP.Size = new System.Drawing.Size(100, 22);
            this.txtTR_COMP_DISP.TabIndex = 0;
            this.txtTR_COMP_DISP.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "承辦單位代碼";
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
            this.fullDataCtrl1.DataSource = this.tRCOMPBindingSource;
            this.fullDataCtrl1.DeleteType = JBControls.FullDataCtrl.EDeleteType.Delete;
            this.fullDataCtrl1.EnableAutoClone = false;
            this.fullDataCtrl1.GroupCmd = "";
            this.fullDataCtrl1.Location = new System.Drawing.Point(-2, 0);
            this.fullDataCtrl1.Name = "fullDataCtrl1";
            this.fullDataCtrl1.QueryFields = "tr_comp_disp,tr_comp_name,key_date,key_man";
            this.fullDataCtrl1.RecentQuerySql = "";
            this.fullDataCtrl1.SelectCmd = "";
            this.fullDataCtrl1.ShowExceptionMsg = true;
            this.fullDataCtrl1.Size = new System.Drawing.Size(626, 73);
            this.fullDataCtrl1.SortFields = "tr_comp_disp,tr_comp_name,key_date,key_man";
            this.fullDataCtrl1.TabIndex = 0;
            this.fullDataCtrl1.WhereCmd = "";
            this.fullDataCtrl1.AfterAdd += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterAdd);
            this.fullDataCtrl1.BeforeDel += new JBControls.FullDataCtrl.BeforeEventHandler(this.fullDataCtrl1_BeforeDel);
            this.fullDataCtrl1.AfterDel += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterDel);
            this.fullDataCtrl1.BeforeSave += new JBControls.FullDataCtrl.BeforeEventHandler(this.fullDataCtrl1_BeforeSave);
            this.fullDataCtrl1.AfterSave += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterSave);
            this.fullDataCtrl1.AfterExport += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterExport);
            this.fullDataCtrl1.AfterQuery += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterQuery);
            this.fullDataCtrl1.AfterShow += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterShow);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // tRCOMPTableAdapter
            // 
            this.tRCOMPTableAdapter.ClearBeforeFill = true;
            // 
            // FRM92
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 441);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "FRM92";
            this.Text = "FRM92";
            this.Load += new System.EventHandler(this.FRM92_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tRCOMPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.traDS1)).EndInit();
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
		private JBControls.DataGridView dataGridViewEx1;
		private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel1;
        private JBControls.FullDataCtrl fullDataCtrl1;
        private WelDS welDS;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private JBControls.TextBox txtTR_COMP_NAME;
        private System.Windows.Forms.Label label2;
        private JBControls.TextBox txtTR_COMP_DISP;
        private System.Windows.Forms.Label label1;
        private JBControls.TextBox txtTEL;
        private System.Windows.Forms.Label label3;
        private traDS1 traDS1;
        private System.Windows.Forms.BindingSource tRCOMPBindingSource;
        private traDS1TableAdapters.TRCOMPTableAdapter tRCOMPTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn tRCOMPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tRCOMPDISPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tRCOMPNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tELDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYMANDataGridViewTextBoxColumn;
	}
}