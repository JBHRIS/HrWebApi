using JBHR.Wel;
namespace JBHR.EXA
{
	partial class FRM82
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
            this.eFFTYPEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.exa = new JBHR.EXA.exa();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtEFFTYPE_NAME = new JBControls.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEFFTYPE_DISP = new JBControls.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fullDataCtrl1 = new JBControls.FullDataCtrl();
            this.eFFLVLBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.eFFLVLTableAdapter = new JBHR.EXA.exaTableAdapters.EFFLVLTableAdapter();
            this.eFFTYPETableAdapter = new JBHR.EXA.exaTableAdapters.EFFTYPETableAdapter();
            this.EFFTYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EFFTYPE_DISP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EFFTYPE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KEY_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KEY_MAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eFFTYPEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eFFLVLBindingSource)).BeginInit();
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
            this.splitContainer1.SplitterDistance = 279;
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
            this.EFFTYPE,
            this.EFFTYPE_DISP,
            this.EFFTYPE_NAME,
            this.KEY_DATE,
            this.KEY_MAN});
            this.dataGridViewEx1.DataSource = this.eFFTYPEBindingSource;
            this.dataGridViewEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEx1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewEx1.MultiSelect = false;
            this.dataGridViewEx1.Name = "dataGridViewEx1";
            this.dataGridViewEx1.ReadOnly = true;
            this.dataGridViewEx1.RowHeadersVisible = false;
            this.dataGridViewEx1.RowTemplate.Height = 24;
            this.dataGridViewEx1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEx1.Size = new System.Drawing.Size(626, 279);
            this.dataGridViewEx1.TabIndex = 6;
            this.dataGridViewEx1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewEx1_DataError);
            // 
            // eFFTYPEBindingSource
            // 
            this.eFFTYPEBindingSource.DataMember = "EFFTYPE";
            this.eFFTYPEBindingSource.DataSource = this.exa;
            // 
            // exa
            // 
            this.exa.DataSetName = "exa";
            this.exa.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.exa.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.splitContainer2.Size = new System.Drawing.Size(626, 158);
            this.splitContainer2.SplitterDistance = 78;
            this.splitContainer2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtEFFTYPE_NAME);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtEFFTYPE_DISP);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 78);
            this.panel1.TabIndex = 7;
            // 
            // txtEFFTYPE_NAME
            // 
            this.txtEFFTYPE_NAME.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtEFFTYPE_NAME.CaptionLabel = this.label2;
            this.txtEFFTYPE_NAME.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtEFFTYPE_NAME.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eFFTYPEBindingSource, "EFFTYPE_NAME", true));
            this.txtEFFTYPE_NAME.DecimalPlace = 2;
            this.txtEFFTYPE_NAME.IsEmpty = false;
            this.txtEFFTYPE_NAME.Location = new System.Drawing.Point(99, 37);
            this.txtEFFTYPE_NAME.Mask = "";
            this.txtEFFTYPE_NAME.MaxLength = 50;
            this.txtEFFTYPE_NAME.Name = "txtEFFTYPE_NAME";
            this.txtEFFTYPE_NAME.PasswordChar = '\0';
            this.txtEFFTYPE_NAME.ReadOnly = false;
            this.txtEFFTYPE_NAME.ShowCalendarButton = true;
            this.txtEFFTYPE_NAME.Size = new System.Drawing.Size(100, 22);
            this.txtEFFTYPE_NAME.TabIndex = 1;
            this.txtEFFTYPE_NAME.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(16, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "考核種類名稱";
            // 
            // txtEFFTYPE_DISP
            // 
            this.txtEFFTYPE_DISP.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtEFFTYPE_DISP.CaptionLabel = this.label1;
            this.txtEFFTYPE_DISP.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtEFFTYPE_DISP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eFFTYPEBindingSource, "EFFTYPE_DISP", true));
            this.txtEFFTYPE_DISP.DecimalPlace = 2;
            this.txtEFFTYPE_DISP.IsEmpty = false;
            this.txtEFFTYPE_DISP.Location = new System.Drawing.Point(99, 9);
            this.txtEFFTYPE_DISP.Mask = "";
            this.txtEFFTYPE_DISP.MaxLength = 50;
            this.txtEFFTYPE_DISP.Name = "txtEFFTYPE_DISP";
            this.txtEFFTYPE_DISP.PasswordChar = '\0';
            this.txtEFFTYPE_DISP.ReadOnly = false;
            this.txtEFFTYPE_DISP.ShowCalendarButton = true;
            this.txtEFFTYPE_DISP.Size = new System.Drawing.Size(100, 22);
            this.txtEFFTYPE_DISP.TabIndex = 0;
            this.txtEFFTYPE_DISP.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(16, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "考核種類代碼";
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
            this.fullDataCtrl1.DataSource = this.eFFTYPEBindingSource;
            this.fullDataCtrl1.DeleteType = JBControls.FullDataCtrl.EDeleteType.Delete;
            this.fullDataCtrl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.fullDataCtrl1.EnableAutoClone = false;
            this.fullDataCtrl1.GroupCmd = "";
            this.fullDataCtrl1.Location = new System.Drawing.Point(0, 0);
            this.fullDataCtrl1.Name = "fullDataCtrl1";
            this.fullDataCtrl1.QueryFields = "nobr,yymm,seq,sal_code";
            this.fullDataCtrl1.RecentQuerySql = "";
            this.fullDataCtrl1.SelectCmd = "";
            this.fullDataCtrl1.ShowExceptionMsg = true;
            this.fullDataCtrl1.Size = new System.Drawing.Size(626, 73);
            this.fullDataCtrl1.SortFields = "nobr,yymm,sal_code";
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
            // eFFLVLBindingSource
            // 
            this.eFFLVLBindingSource.DataMember = "EFFLVL";
            this.eFFLVLBindingSource.DataSource = this.exa;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // eFFLVLTableAdapter
            // 
            this.eFFLVLTableAdapter.ClearBeforeFill = true;
            // 
            // eFFTYPETableAdapter
            // 
            this.eFFTYPETableAdapter.ClearBeforeFill = true;
            // 
            // EFFTYPE
            // 
            this.EFFTYPE.DataPropertyName = "EFFTYPE";
            this.EFFTYPE.HeaderText = "考核種類代碼";
            this.EFFTYPE.Name = "EFFTYPE";
            this.EFFTYPE.ReadOnly = true;
            this.EFFTYPE.Visible = false;
            this.EFFTYPE.Width = 83;
            // 
            // EFFTYPE_DISP
            // 
            this.EFFTYPE_DISP.DataPropertyName = "EFFTYPE_DISP";
            this.EFFTYPE_DISP.HeaderText = "考核種類代碼";
            this.EFFTYPE_DISP.Name = "EFFTYPE_DISP";
            this.EFFTYPE_DISP.ReadOnly = true;
            this.EFFTYPE_DISP.Width = 102;
            // 
            // EFFTYPE_NAME
            // 
            this.EFFTYPE_NAME.DataPropertyName = "EFFTYPE_NAME";
            this.EFFTYPE_NAME.HeaderText = "考核種類名稱";
            this.EFFTYPE_NAME.Name = "EFFTYPE_NAME";
            this.EFFTYPE_NAME.ReadOnly = true;
            this.EFFTYPE_NAME.Width = 102;
            // 
            // KEY_DATE
            // 
            this.KEY_DATE.DataPropertyName = "KEY_DATE";
            this.KEY_DATE.HeaderText = "建檔日期";
            this.KEY_DATE.Name = "KEY_DATE";
            this.KEY_DATE.ReadOnly = true;
            this.KEY_DATE.Width = 78;
            // 
            // KEY_MAN
            // 
            this.KEY_MAN.DataPropertyName = "KEY_MAN";
            this.KEY_MAN.HeaderText = "建檔人員";
            this.KEY_MAN.Name = "KEY_MAN";
            this.KEY_MAN.ReadOnly = true;
            this.KEY_MAN.Width = 78;
            // 
            // FRM82
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 441);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "FRM82";
            this.Text = "FRM82";
            this.Load += new System.EventHandler(this.FRM82_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eFFTYPEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exa)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eFFLVLBindingSource)).EndInit();
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
        private exa exa;
        private System.Windows.Forms.BindingSource eFFLVLBindingSource;
        private exaTableAdapters.EFFLVLTableAdapter eFFLVLTableAdapter;
        private JBControls.TextBox txtEFFTYPE_NAME;
        private System.Windows.Forms.Label label2;
        private JBControls.TextBox txtEFFTYPE_DISP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource eFFTYPEBindingSource;
        private exaTableAdapters.EFFTYPETableAdapter eFFTYPETableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn EFFTYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn EFFTYPE_DISP;
        private System.Windows.Forms.DataGridViewTextBoxColumn EFFTYPE_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn KEY_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn KEY_MAN;
    }
}