using JBHR.Wel;
namespace JBHR.TRA
{
	partial class FRM93
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
            this.tRASNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tRASNODISPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tRASNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tELDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tRASSCODEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.traDS1 = new JBHR.TRA.traDS1();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new JBControls.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTR_ASNAME = new JBControls.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTR_ASNO_DISP = new JBControls.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fullDataCtrl1 = new JBControls.FullDataCtrl();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tRASSCODETableAdapter = new JBHR.TRA.traDS1TableAdapters.TRASSCODETableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tRASSCODEBindingSource)).BeginInit();
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
            this.splitContainer1.SplitterDistance = 257;
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
            this.tRASNODataGridViewTextBoxColumn,
            this.tRASNODISPDataGridViewTextBoxColumn,
            this.tRASNAMEDataGridViewTextBoxColumn,
            this.tELDataGridViewTextBoxColumn,
            this.kEYDATEDataGridViewTextBoxColumn,
            this.kEYMANDataGridViewTextBoxColumn});
            this.dataGridViewEx1.DataSource = this.tRASSCODEBindingSource;
            this.dataGridViewEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEx1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewEx1.MultiSelect = false;
            this.dataGridViewEx1.Name = "dataGridViewEx1";
            this.dataGridViewEx1.ReadOnly = true;
            this.dataGridViewEx1.RowHeadersVisible = false;
            this.dataGridViewEx1.RowTemplate.Height = 24;
            this.dataGridViewEx1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEx1.Size = new System.Drawing.Size(626, 257);
            this.dataGridViewEx1.TabIndex = 6;
            this.dataGridViewEx1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewEx1_DataError);
            // 
            // tRASNODataGridViewTextBoxColumn
            // 
            this.tRASNODataGridViewTextBoxColumn.DataPropertyName = "TR_ASNO";
            this.tRASNODataGridViewTextBoxColumn.HeaderText = "課程評估代碼";
            this.tRASNODataGridViewTextBoxColumn.Name = "tRASNODataGridViewTextBoxColumn";
            this.tRASNODataGridViewTextBoxColumn.ReadOnly = true;
            this.tRASNODataGridViewTextBoxColumn.Visible = false;
            this.tRASNODataGridViewTextBoxColumn.Width = 83;
            // 
            // tRASNODISPDataGridViewTextBoxColumn
            // 
            this.tRASNODISPDataGridViewTextBoxColumn.DataPropertyName = "TR_ASNO_DISP";
            this.tRASNODISPDataGridViewTextBoxColumn.HeaderText = "課程評估代碼";
            this.tRASNODISPDataGridViewTextBoxColumn.Name = "tRASNODISPDataGridViewTextBoxColumn";
            this.tRASNODISPDataGridViewTextBoxColumn.ReadOnly = true;
            this.tRASNODISPDataGridViewTextBoxColumn.Width = 102;
            // 
            // tRASNAMEDataGridViewTextBoxColumn
            // 
            this.tRASNAMEDataGridViewTextBoxColumn.DataPropertyName = "TR_ASNAME";
            this.tRASNAMEDataGridViewTextBoxColumn.HeaderText = "課程評估名稱";
            this.tRASNAMEDataGridViewTextBoxColumn.Name = "tRASNAMEDataGridViewTextBoxColumn";
            this.tRASNAMEDataGridViewTextBoxColumn.ReadOnly = true;
            this.tRASNAMEDataGridViewTextBoxColumn.Width = 102;
            // 
            // tELDataGridViewTextBoxColumn
            // 
            this.tELDataGridViewTextBoxColumn.DataPropertyName = "TEL";
            this.tELDataGridViewTextBoxColumn.HeaderText = "聯絡電話";
            this.tELDataGridViewTextBoxColumn.Name = "tELDataGridViewTextBoxColumn";
            this.tELDataGridViewTextBoxColumn.ReadOnly = true;
            this.tELDataGridViewTextBoxColumn.Visible = false;
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
            // tRASSCODEBindingSource
            // 
            this.tRASSCODEBindingSource.DataMember = "TRASSCODE";
            this.tRASSCODEBindingSource.DataSource = this.traDS1;
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
            this.splitContainer2.Size = new System.Drawing.Size(626, 180);
            this.splitContainer2.SplitterDistance = 100;
            this.splitContainer2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtTR_ASNAME);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtTR_ASNO_DISP);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 100);
            this.panel1.TabIndex = 7;
            // 
            // textBox1
            // 
            this.textBox1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox1.CaptionLabel = this.label3;
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tRASSCODEBindingSource, "TEL", true));
            this.textBox1.DecimalPlace = 2;
            this.textBox1.IsEmpty = true;
            this.textBox1.Location = new System.Drawing.Point(93, 63);
            this.textBox1.Mask = "";
            this.textBox1.MaxLength = 50;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.ReadOnly = false;
            this.textBox1.ShowCalendarButton = true;
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 1;
            this.textBox1.ValidType = JBControls.TextBox.EValidType.String;
            this.textBox1.Visible = false;
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
            this.label3.Visible = false;
            // 
            // txtTR_ASNAME
            // 
            this.txtTR_ASNAME.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtTR_ASNAME.CaptionLabel = this.label2;
            this.txtTR_ASNAME.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTR_ASNAME.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tRASSCODEBindingSource, "TR_ASNAME", true));
            this.txtTR_ASNAME.DecimalPlace = 2;
            this.txtTR_ASNAME.IsEmpty = false;
            this.txtTR_ASNAME.Location = new System.Drawing.Point(93, 35);
            this.txtTR_ASNAME.Mask = "";
            this.txtTR_ASNAME.MaxLength = 50;
            this.txtTR_ASNAME.Name = "txtTR_ASNAME";
            this.txtTR_ASNAME.PasswordChar = '\0';
            this.txtTR_ASNAME.ReadOnly = false;
            this.txtTR_ASNAME.ShowCalendarButton = true;
            this.txtTR_ASNAME.Size = new System.Drawing.Size(100, 22);
            this.txtTR_ASNAME.TabIndex = 1;
            this.txtTR_ASNAME.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(10, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "課程評估名稱";
            // 
            // txtTR_ASNO_DISP
            // 
            this.txtTR_ASNO_DISP.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtTR_ASNO_DISP.CaptionLabel = this.label1;
            this.txtTR_ASNO_DISP.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTR_ASNO_DISP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tRASSCODEBindingSource, "TR_ASNO_DISP", true));
            this.txtTR_ASNO_DISP.DecimalPlace = 2;
            this.txtTR_ASNO_DISP.IsEmpty = false;
            this.txtTR_ASNO_DISP.Location = new System.Drawing.Point(93, 7);
            this.txtTR_ASNO_DISP.Mask = "";
            this.txtTR_ASNO_DISP.MaxLength = 50;
            this.txtTR_ASNO_DISP.Name = "txtTR_ASNO_DISP";
            this.txtTR_ASNO_DISP.PasswordChar = '\0';
            this.txtTR_ASNO_DISP.ReadOnly = false;
            this.txtTR_ASNO_DISP.ShowCalendarButton = true;
            this.txtTR_ASNO_DISP.Size = new System.Drawing.Size(100, 22);
            this.txtTR_ASNO_DISP.TabIndex = 0;
            this.txtTR_ASNO_DISP.ValidType = JBControls.TextBox.EValidType.String;
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
            this.label1.Text = "課程評估代碼";
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
            this.fullDataCtrl1.DataSource = this.tRASSCODEBindingSource;
            this.fullDataCtrl1.DeleteType = JBControls.FullDataCtrl.EDeleteType.Delete;
            this.fullDataCtrl1.EnableAutoClone = false;
            this.fullDataCtrl1.GroupCmd = "";
            this.fullDataCtrl1.Location = new System.Drawing.Point(-2, 0);
            this.fullDataCtrl1.Name = "fullDataCtrl1";
            this.fullDataCtrl1.QueryFields = "tr_asno_disp,tr_asname,key_date,key_man";
            this.fullDataCtrl1.RecentQuerySql = "";
            this.fullDataCtrl1.SelectCmd = "";
            this.fullDataCtrl1.ShowExceptionMsg = true;
            this.fullDataCtrl1.Size = new System.Drawing.Size(626, 73);
            this.fullDataCtrl1.SortFields = "tr_asno_disp,tr_asname,key_date,key_man";
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
            // tRASSCODETableAdapter
            // 
            this.tRASSCODETableAdapter.ClearBeforeFill = true;
            // 
            // FRM93
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 441);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "FRM93";
            this.Text = "FRM93";
            this.Load += new System.EventHandler(this.FRM93_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tRASSCODEBindingSource)).EndInit();
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
        private JBControls.TextBox txtTR_ASNAME;
        private System.Windows.Forms.Label label2;
        private JBControls.TextBox txtTR_ASNO_DISP;
        private System.Windows.Forms.Label label1;
        private JBControls.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private traDS1 traDS1;
        private System.Windows.Forms.BindingSource tRASSCODEBindingSource;
        private traDS1TableAdapters.TRASSCODETableAdapter tRASSCODETableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn tRASNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tRASNODISPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tRASNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tELDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYMANDataGridViewTextBoxColumn;
    }
}