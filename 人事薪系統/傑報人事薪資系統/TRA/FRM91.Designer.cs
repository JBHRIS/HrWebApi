using JBHR.Wel;
namespace JBHR.TRA
{
	partial class FRM91
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
            this.tRTYPEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tRTYPEDISPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dESCRDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tRTYPEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.traDS1 = new JBHR.TRA.traDS1();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDESCR = new JBControls.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTR_TYPE_DISP = new JBControls.TextBox();
            this.fullDataCtrl1 = new JBControls.FullDataCtrl();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tRTYPETableAdapter = new JBHR.TRA.traDS1TableAdapters.TRTYPETableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tRTYPEBindingSource)).BeginInit();
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
            this.splitContainer1.SplitterDistance = 291;
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
            this.tRTYPEDataGridViewTextBoxColumn,
            this.tRTYPEDISPDataGridViewTextBoxColumn,
            this.dESCRDataGridViewTextBoxColumn,
            this.kEYDATEDataGridViewTextBoxColumn,
            this.kEYMANDataGridViewTextBoxColumn});
            this.dataGridViewEx1.DataSource = this.tRTYPEBindingSource;
            this.dataGridViewEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEx1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewEx1.MultiSelect = false;
            this.dataGridViewEx1.Name = "dataGridViewEx1";
            this.dataGridViewEx1.ReadOnly = true;
            this.dataGridViewEx1.RowHeadersVisible = false;
            this.dataGridViewEx1.RowTemplate.Height = 24;
            this.dataGridViewEx1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEx1.Size = new System.Drawing.Size(626, 291);
            this.dataGridViewEx1.TabIndex = 6;
            this.dataGridViewEx1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewEx1_DataError);
            // 
            // tRTYPEDataGridViewTextBoxColumn
            // 
            this.tRTYPEDataGridViewTextBoxColumn.DataPropertyName = "TR_TYPE";
            this.tRTYPEDataGridViewTextBoxColumn.HeaderText = "類別代碼";
            this.tRTYPEDataGridViewTextBoxColumn.Name = "tRTYPEDataGridViewTextBoxColumn";
            this.tRTYPEDataGridViewTextBoxColumn.ReadOnly = true;
            this.tRTYPEDataGridViewTextBoxColumn.Visible = false;
            this.tRTYPEDataGridViewTextBoxColumn.Width = 57;
            // 
            // tRTYPEDISPDataGridViewTextBoxColumn
            // 
            this.tRTYPEDISPDataGridViewTextBoxColumn.DataPropertyName = "TR_TYPE_DISP";
            this.tRTYPEDISPDataGridViewTextBoxColumn.HeaderText = "課程類別代碼";
            this.tRTYPEDISPDataGridViewTextBoxColumn.Name = "tRTYPEDISPDataGridViewTextBoxColumn";
            this.tRTYPEDISPDataGridViewTextBoxColumn.ReadOnly = true;
            this.tRTYPEDISPDataGridViewTextBoxColumn.Width = 102;
            // 
            // dESCRDataGridViewTextBoxColumn
            // 
            this.dESCRDataGridViewTextBoxColumn.DataPropertyName = "DESCR";
            this.dESCRDataGridViewTextBoxColumn.HeaderText = "課程類別名稱";
            this.dESCRDataGridViewTextBoxColumn.Name = "dESCRDataGridViewTextBoxColumn";
            this.dESCRDataGridViewTextBoxColumn.ReadOnly = true;
            this.dESCRDataGridViewTextBoxColumn.Width = 102;
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
            // tRTYPEBindingSource
            // 
            this.tRTYPEBindingSource.DataMember = "TRTYPE";
            this.tRTYPEBindingSource.DataSource = this.traDS1;
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
            this.splitContainer2.Size = new System.Drawing.Size(626, 146);
            this.splitContainer2.SplitterDistance = 66;
            this.splitContainer2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtDESCR);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtTR_TYPE_DISP);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 66);
            this.panel1.TabIndex = 7;
            // 
            // txtDESCR
            // 
            this.txtDESCR.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtDESCR.CaptionLabel = this.label1;
            this.txtDESCR.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDESCR.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tRTYPEBindingSource, "DESCR", true));
            this.txtDESCR.DecimalPlace = 2;
            this.txtDESCR.IsEmpty = false;
            this.txtDESCR.Location = new System.Drawing.Point(92, 37);
            this.txtDESCR.Mask = "";
            this.txtDESCR.MaxLength = 50;
            this.txtDESCR.Name = "txtDESCR";
            this.txtDESCR.PasswordChar = '\0';
            this.txtDESCR.ReadOnly = false;
            this.txtDESCR.ShowCalendarButton = true;
            this.txtDESCR.Size = new System.Drawing.Size(100, 22);
            this.txtDESCR.TabIndex = 1;
            this.txtDESCR.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(9, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "課程類別名稱";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(8, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "課程類別代碼";
            // 
            // txtTR_TYPE_DISP
            // 
            this.txtTR_TYPE_DISP.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtTR_TYPE_DISP.CaptionLabel = this.label2;
            this.txtTR_TYPE_DISP.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTR_TYPE_DISP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tRTYPEBindingSource, "TR_TYPE_DISP", true));
            this.txtTR_TYPE_DISP.DecimalPlace = 2;
            this.txtTR_TYPE_DISP.IsEmpty = false;
            this.txtTR_TYPE_DISP.Location = new System.Drawing.Point(91, 9);
            this.txtTR_TYPE_DISP.Mask = "";
            this.txtTR_TYPE_DISP.MaxLength = 50;
            this.txtTR_TYPE_DISP.Name = "txtTR_TYPE_DISP";
            this.txtTR_TYPE_DISP.PasswordChar = '\0';
            this.txtTR_TYPE_DISP.ReadOnly = false;
            this.txtTR_TYPE_DISP.ShowCalendarButton = true;
            this.txtTR_TYPE_DISP.Size = new System.Drawing.Size(100, 22);
            this.txtTR_TYPE_DISP.TabIndex = 0;
            this.txtTR_TYPE_DISP.ValidType = JBControls.TextBox.EValidType.String;
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
            this.fullDataCtrl1.DataSource = this.tRTYPEBindingSource;
            this.fullDataCtrl1.DeleteType = JBControls.FullDataCtrl.EDeleteType.Delete;
            this.fullDataCtrl1.EnableAutoClone = false;
            this.fullDataCtrl1.GroupCmd = "";
            this.fullDataCtrl1.Location = new System.Drawing.Point(-2, 0);
            this.fullDataCtrl1.Name = "fullDataCtrl1";
            this.fullDataCtrl1.QueryFields = "tr_type_disp,key_date,key_man";
            this.fullDataCtrl1.RecentQuerySql = "";
            this.fullDataCtrl1.SelectCmd = "";
            this.fullDataCtrl1.ShowExceptionMsg = true;
            this.fullDataCtrl1.Size = new System.Drawing.Size(626, 73);
            this.fullDataCtrl1.SortFields = "tr_type_disp,key_date,key_man";
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
            // tRTYPETableAdapter
            // 
            this.tRTYPETableAdapter.ClearBeforeFill = true;
            // 
            // FRM91
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 441);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "FRM91";
            this.Text = "FRM91";
            this.Load += new System.EventHandler(this.FRM91_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tRTYPEBindingSource)).EndInit();
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
        private JBControls.TextBox txtDESCR;
        private System.Windows.Forms.Label label2;
        private JBControls.TextBox txtTR_TYPE_DISP;
        private System.Windows.Forms.Label label1;
        private traDS1 traDS1;
        private System.Windows.Forms.BindingSource tRTYPEBindingSource;
        private traDS1TableAdapters.TRTYPETableAdapter tRTYPETableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn tRTYPEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tRTYPEDISPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dESCRDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYMANDataGridViewTextBoxColumn;
	}
}