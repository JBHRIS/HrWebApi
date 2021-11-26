using JBHR.Wel;
namespace JBHR.EXA
{
	partial class FRM81
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
            this.eFFLVLDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eFFLVLDISPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eFFLVLNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eFFBDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eFFEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eFFLVLBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.exa = new JBHR.EXA.exa();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtEFFE = new JBControls.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEFFB = new JBControls.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEFFLV_NAME = new JBControls.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEFFLVL_DISP = new JBControls.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fullDataCtrl1 = new JBControls.FullDataCtrl();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.eFFLVLTableAdapter = new JBHR.EXA.exaTableAdapters.EFFLVLTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eFFLVLBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exa)).BeginInit();
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
            this.splitContainer1.Size = new System.Drawing.Size(636, 452);
            this.splitContainer1.SplitterDistance = 247;
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
            this.eFFLVLDataGridViewTextBoxColumn,
            this.eFFLVLDISPDataGridViewTextBoxColumn,
            this.eFFLVLNAMEDataGridViewTextBoxColumn,
            this.eFFBDataGridViewTextBoxColumn,
            this.eFFEDataGridViewTextBoxColumn,
            this.kEYDATEDataGridViewTextBoxColumn,
            this.kEYMANDataGridViewTextBoxColumn});
            this.dataGridViewEx1.DataSource = this.eFFLVLBindingSource;
            this.dataGridViewEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEx1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewEx1.MultiSelect = false;
            this.dataGridViewEx1.Name = "dataGridViewEx1";
            this.dataGridViewEx1.ReadOnly = true;
            this.dataGridViewEx1.RowHeadersVisible = false;
            this.dataGridViewEx1.RowTemplate.Height = 24;
            this.dataGridViewEx1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEx1.Size = new System.Drawing.Size(636, 247);
            this.dataGridViewEx1.TabIndex = 6;
            this.dataGridViewEx1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewEx1_DataError);
            // 
            // eFFLVLDataGridViewTextBoxColumn
            // 
            this.eFFLVLDataGridViewTextBoxColumn.DataPropertyName = "EFFLVL";
            this.eFFLVLDataGridViewTextBoxColumn.HeaderText = "等級代碼";
            this.eFFLVLDataGridViewTextBoxColumn.Name = "eFFLVLDataGridViewTextBoxColumn";
            this.eFFLVLDataGridViewTextBoxColumn.ReadOnly = true;
            this.eFFLVLDataGridViewTextBoxColumn.Visible = false;
            this.eFFLVLDataGridViewTextBoxColumn.Width = 59;
            // 
            // eFFLVLDISPDataGridViewTextBoxColumn
            // 
            this.eFFLVLDISPDataGridViewTextBoxColumn.DataPropertyName = "EFFLVL_DISP";
            this.eFFLVLDISPDataGridViewTextBoxColumn.HeaderText = "等級代碼";
            this.eFFLVLDISPDataGridViewTextBoxColumn.Name = "eFFLVLDISPDataGridViewTextBoxColumn";
            this.eFFLVLDISPDataGridViewTextBoxColumn.ReadOnly = true;
            this.eFFLVLDISPDataGridViewTextBoxColumn.Width = 78;
            // 
            // eFFLVLNAMEDataGridViewTextBoxColumn
            // 
            this.eFFLVLNAMEDataGridViewTextBoxColumn.DataPropertyName = "EFFLVL_NAME";
            this.eFFLVLNAMEDataGridViewTextBoxColumn.HeaderText = "考績名稱";
            this.eFFLVLNAMEDataGridViewTextBoxColumn.Name = "eFFLVLNAMEDataGridViewTextBoxColumn";
            this.eFFLVLNAMEDataGridViewTextBoxColumn.ReadOnly = true;
            this.eFFLVLNAMEDataGridViewTextBoxColumn.Width = 78;
            // 
            // eFFBDataGridViewTextBoxColumn
            // 
            this.eFFBDataGridViewTextBoxColumn.DataPropertyName = "EFFB";
            this.eFFBDataGridViewTextBoxColumn.HeaderText = "最低分數";
            this.eFFBDataGridViewTextBoxColumn.Name = "eFFBDataGridViewTextBoxColumn";
            this.eFFBDataGridViewTextBoxColumn.ReadOnly = true;
            this.eFFBDataGridViewTextBoxColumn.Width = 78;
            // 
            // eFFEDataGridViewTextBoxColumn
            // 
            this.eFFEDataGridViewTextBoxColumn.DataPropertyName = "EFFE";
            this.eFFEDataGridViewTextBoxColumn.HeaderText = "最高分數";
            this.eFFEDataGridViewTextBoxColumn.Name = "eFFEDataGridViewTextBoxColumn";
            this.eFFEDataGridViewTextBoxColumn.ReadOnly = true;
            this.eFFEDataGridViewTextBoxColumn.Width = 78;
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
            // eFFLVLBindingSource
            // 
            this.eFFLVLBindingSource.DataMember = "EFFLVL";
            this.eFFLVLBindingSource.DataSource = this.exa;
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
            this.splitContainer2.Size = new System.Drawing.Size(636, 201);
            this.splitContainer2.SplitterDistance = 121;
            this.splitContainer2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtEFFE);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtEFFB);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtEFFLV_NAME);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtEFFLVL_DISP);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(636, 121);
            this.panel1.TabIndex = 7;
            // 
            // txtEFFE
            // 
            this.txtEFFE.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtEFFE.CaptionLabel = this.label4;
            this.txtEFFE.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtEFFE.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eFFLVLBindingSource, "EFFE", true));
            this.txtEFFE.DecimalPlace = 2;
            this.txtEFFE.IsEmpty = false;
            this.txtEFFE.Location = new System.Drawing.Point(74, 91);
            this.txtEFFE.Mask = "";
            this.txtEFFE.MaxLength = -1;
            this.txtEFFE.Name = "txtEFFE";
            this.txtEFFE.PasswordChar = '\0';
            this.txtEFFE.ReadOnly = false;
            this.txtEFFE.Size = new System.Drawing.Size(100, 22);
            this.txtEFFE.TabIndex = 3;
            this.txtEFFE.ValidType = JBControls.TextBox.EValidType.Decimal;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(15, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "最高分數";
            // 
            // txtEFFB
            // 
            this.txtEFFB.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtEFFB.CaptionLabel = this.label3;
            this.txtEFFB.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtEFFB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eFFLVLBindingSource, "EFFB", true));
            this.txtEFFB.DecimalPlace = 2;
            this.txtEFFB.IsEmpty = false;
            this.txtEFFB.Location = new System.Drawing.Point(74, 63);
            this.txtEFFB.Mask = "";
            this.txtEFFB.MaxLength = -1;
            this.txtEFFB.Name = "txtEFFB";
            this.txtEFFB.PasswordChar = '\0';
            this.txtEFFB.ReadOnly = false;
            this.txtEFFB.Size = new System.Drawing.Size(100, 22);
            this.txtEFFB.TabIndex = 2;
            this.txtEFFB.ValidType = JBControls.TextBox.EValidType.Decimal;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(15, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "最低分數";
            // 
            // txtEFFLV_NAME
            // 
            this.txtEFFLV_NAME.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtEFFLV_NAME.CaptionLabel = this.label2;
            this.txtEFFLV_NAME.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtEFFLV_NAME.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eFFLVLBindingSource, "EFFLVL_NAME", true));
            this.txtEFFLV_NAME.DecimalPlace = 2;
            this.txtEFFLV_NAME.IsEmpty = false;
            this.txtEFFLV_NAME.Location = new System.Drawing.Point(74, 35);
            this.txtEFFLV_NAME.Mask = "";
            this.txtEFFLV_NAME.MaxLength = 50;
            this.txtEFFLV_NAME.Name = "txtEFFLV_NAME";
            this.txtEFFLV_NAME.PasswordChar = '\0';
            this.txtEFFLV_NAME.ReadOnly = false;
            this.txtEFFLV_NAME.Size = new System.Drawing.Size(100, 22);
            this.txtEFFLV_NAME.TabIndex = 1;
            this.txtEFFLV_NAME.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(15, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "考績名稱";
            // 
            // txtEFFLVL_DISP
            // 
            this.txtEFFLVL_DISP.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtEFFLVL_DISP.CaptionLabel = this.label1;
            this.txtEFFLVL_DISP.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtEFFLVL_DISP.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eFFLVLBindingSource, "EFFLVL_DISP", true));
            this.txtEFFLVL_DISP.DecimalPlace = 2;
            this.txtEFFLVL_DISP.IsEmpty = false;
            this.txtEFFLVL_DISP.Location = new System.Drawing.Point(74, 7);
            this.txtEFFLVL_DISP.Mask = "";
            this.txtEFFLVL_DISP.MaxLength = 50;
            this.txtEFFLVL_DISP.Name = "txtEFFLVL_DISP";
            this.txtEFFLVL_DISP.PasswordChar = '\0';
            this.txtEFFLVL_DISP.ReadOnly = false;
            this.txtEFFLVL_DISP.Size = new System.Drawing.Size(100, 22);
            this.txtEFFLVL_DISP.TabIndex = 0;
            this.txtEFFLVL_DISP.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(15, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "等級代碼";
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
            this.fullDataCtrl1.DataSource = this.eFFLVLBindingSource;
            this.fullDataCtrl1.DeleteType = JBControls.FullDataCtrl.EDeleteType.Delete;
            this.fullDataCtrl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.fullDataCtrl1.GroupCmd = "";
            this.fullDataCtrl1.Location = new System.Drawing.Point(0, 0);
            this.fullDataCtrl1.Name = "fullDataCtrl1";
            this.fullDataCtrl1.QueryFields = "nobr,yymm,seq,sal_code";
            this.fullDataCtrl1.RecentQuerySql = "";
            this.fullDataCtrl1.SelectCmd = "";
            this.fullDataCtrl1.ShowExceptionMsg = true;
            this.fullDataCtrl1.Size = new System.Drawing.Size(636, 73);
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
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // eFFLVLTableAdapter
            // 
            this.eFFLVLTableAdapter.ClearBeforeFill = true;
            // 
            // FRM81
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 452);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "FRM81";
            this.Text = "FRM81";
            this.Load += new System.EventHandler(this.FRM81_Load_1);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eFFLVLBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exa)).EndInit();
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
        private exa exa;
        private System.Windows.Forms.BindingSource eFFLVLBindingSource;
        private exaTableAdapters.EFFLVLTableAdapter eFFLVLTableAdapter;
        private JBControls.TextBox txtEFFE;
        private System.Windows.Forms.Label label4;
        private JBControls.TextBox txtEFFB;
        private System.Windows.Forms.Label label3;
        private JBControls.TextBox txtEFFLV_NAME;
        private System.Windows.Forms.Label label2;
        private JBControls.TextBox txtEFFLVL_DISP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn eFFLVLDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eFFLVLDISPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eFFLVLNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eFFBDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eFFEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYMANDataGridViewTextBoxColumn;
	}
}