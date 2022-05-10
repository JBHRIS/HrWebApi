namespace JBHR.Sys
{
	partial class FRMG12
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
            this.lOCKWAGEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sysDS = new JBHR.Sys.SysDS();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBatch = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.saladrLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.maskedTextBox2 = new JBControls.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new JBControls.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.MEMOTextBox = new JBControls.TextBox();
            this.lOCK_WAGETableAdapter = new JBHR.Sys.SysDSTableAdapters.LOCK_WAGETableAdapter();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.fullDataCtrl1 = new JBControls.FullDataCtrl();
            this.dataGridViewEx1 = new JBControls.DataGridView();
            this.yYMMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sEQDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sALADRDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mENODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.lOCKWAGEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysDS)).BeginInit();
            this.panel1.SuspendLayout();
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
            // lOCKWAGEBindingSource
            // 
            this.lOCKWAGEBindingSource.DataMember = "LOCK_WAGE";
            this.lOCKWAGEBindingSource.DataSource = this.sysDS;
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
            this.panel1.Controls.Add(this.btnBatch);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.saladrLabel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.maskedTextBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.MEMOTextBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 123);
            this.panel1.TabIndex = 6;
            // 
            // btnBatch
            // 
            this.btnBatch.Location = new System.Drawing.Point(539, 92);
            this.btnBatch.Name = "btnBatch";
            this.btnBatch.Size = new System.Drawing.Size(81, 23);
            this.btnBatch.TabIndex = 10;
            this.btnBatch.TabStop = false;
            this.btnBatch.Text = "批次鎖檔";
            this.btnBatch.UseVisualStyleBackColor = true;
            this.btnBatch.Click += new System.EventHandler(this.btnBatch_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.lOCKWAGEBindingSource, "SALADR", true));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(75, 66);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(130, 20);
            this.comboBox1.TabIndex = 2;
            // 
            // saladrLabel
            // 
            this.saladrLabel.AutoSize = true;
            this.saladrLabel.Location = new System.Drawing.Point(211, 69);
            this.saladrLabel.Name = "saladrLabel";
            this.saladrLabel.Size = new System.Drawing.Size(0, 12);
            this.saladrLabel.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(16, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "資料群組";
            // 
            // maskedTextBox2
            // 
            this.maskedTextBox2.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.maskedTextBox2.CaptionLabel = this.label2;
            this.maskedTextBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.maskedTextBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lOCKWAGEBindingSource, "SEQ", true));
            this.maskedTextBox2.DecimalPlace = 2;
            this.maskedTextBox2.IsEmpty = false;
            this.maskedTextBox2.Location = new System.Drawing.Point(75, 36);
            this.maskedTextBox2.Mask = "";
            this.maskedTextBox2.MaxLength = 2;
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.PasswordChar = '\0';
            this.maskedTextBox2.ReadOnly = false;
            this.maskedTextBox2.ShowCalendarButton = true;
            this.maskedTextBox2.Size = new System.Drawing.Size(29, 22);
            this.maskedTextBox2.TabIndex = 1;
            this.maskedTextBox2.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(40, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "期數";
            // 
            // textBox1
            // 
            this.textBox1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox1.CaptionLabel = this.label1;
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lOCKWAGEBindingSource, "YYMM", true));
            this.textBox1.DecimalPlace = 2;
            this.textBox1.IsEmpty = false;
            this.textBox1.Location = new System.Drawing.Point(75, 8);
            this.textBox1.Mask = "999999";
            this.textBox1.MaxLength = 10;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.ReadOnly = false;
            this.textBox1.ShowCalendarButton = true;
            this.textBox1.Size = new System.Drawing.Size(45, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(16, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "計薪年月";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(40, 97);
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
            this.MEMOTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lOCKWAGEBindingSource, "MENO", true));
            this.MEMOTextBox.DecimalPlace = 2;
            this.MEMOTextBox.IsEmpty = true;
            this.MEMOTextBox.Location = new System.Drawing.Point(75, 92);
            this.MEMOTextBox.Mask = "";
            this.MEMOTextBox.MaxLength = 50;
            this.MEMOTextBox.Name = "MEMOTextBox";
            this.MEMOTextBox.PasswordChar = '\0';
            this.MEMOTextBox.ReadOnly = false;
            this.MEMOTextBox.ShowCalendarButton = true;
            this.MEMOTextBox.Size = new System.Drawing.Size(451, 22);
            this.MEMOTextBox.TabIndex = 3;
            this.MEMOTextBox.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // lOCK_WAGETableAdapter
            // 
            this.lOCK_WAGETableAdapter.ClearBeforeFill = true;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            this.errorProvider.DataSource = this.lOCKWAGEBindingSource;
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
            this.fullDataCtrl1.DataSource = this.lOCKWAGEBindingSource;
            this.fullDataCtrl1.DeleteType = JBControls.FullDataCtrl.EDeleteType.Delete;
            this.fullDataCtrl1.EnableAutoClone = false;
            this.fullDataCtrl1.GroupCmd = "";
            this.fullDataCtrl1.Location = new System.Drawing.Point(-2, 16);
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
            this.yYMMDataGridViewTextBoxColumn,
            this.sEQDataGridViewTextBoxColumn,
            this.sALADRDataGridViewTextBoxColumn,
            this.mENODataGridViewTextBoxColumn,
            this.kEYMANDataGridViewTextBoxColumn,
            this.kEYDATEDataGridViewTextBoxColumn});
            this.dataGridViewEx1.DataSource = this.lOCKWAGEBindingSource;
            this.dataGridViewEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEx1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewEx1.MultiSelect = false;
            this.dataGridViewEx1.Name = "dataGridViewEx1";
            this.dataGridViewEx1.ReadOnly = true;
            this.dataGridViewEx1.RowHeadersVisible = false;
            this.dataGridViewEx1.RowTemplate.Height = 24;
            this.dataGridViewEx1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEx1.Size = new System.Drawing.Size(626, 221);
            this.dataGridViewEx1.TabIndex = 4;
            // 
            // yYMMDataGridViewTextBoxColumn
            // 
            this.yYMMDataGridViewTextBoxColumn.DataPropertyName = "YYMM";
            this.yYMMDataGridViewTextBoxColumn.HeaderText = "計薪年月";
            this.yYMMDataGridViewTextBoxColumn.Name = "yYMMDataGridViewTextBoxColumn";
            this.yYMMDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sEQDataGridViewTextBoxColumn
            // 
            this.sEQDataGridViewTextBoxColumn.DataPropertyName = "SEQ";
            this.sEQDataGridViewTextBoxColumn.HeaderText = "期數";
            this.sEQDataGridViewTextBoxColumn.Name = "sEQDataGridViewTextBoxColumn";
            this.sEQDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sALADRDataGridViewTextBoxColumn
            // 
            this.sALADRDataGridViewTextBoxColumn.DataPropertyName = "SALADR";
            this.sALADRDataGridViewTextBoxColumn.HeaderText = "資料群組";
            this.sALADRDataGridViewTextBoxColumn.Name = "sALADRDataGridViewTextBoxColumn";
            this.sALADRDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mENODataGridViewTextBoxColumn
            // 
            this.mENODataGridViewTextBoxColumn.DataPropertyName = "MENO";
            this.mENODataGridViewTextBoxColumn.HeaderText = "備註";
            this.mENODataGridViewTextBoxColumn.Name = "mENODataGridViewTextBoxColumn";
            this.mENODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // kEYMANDataGridViewTextBoxColumn
            // 
            this.kEYMANDataGridViewTextBoxColumn.DataPropertyName = "KEY_MAN";
            this.kEYMANDataGridViewTextBoxColumn.HeaderText = "登錄者";
            this.kEYMANDataGridViewTextBoxColumn.Name = "kEYMANDataGridViewTextBoxColumn";
            this.kEYMANDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // kEYDATEDataGridViewTextBoxColumn
            // 
            this.kEYDATEDataGridViewTextBoxColumn.DataPropertyName = "KEY_DATE";
            this.kEYDATEDataGridViewTextBoxColumn.HeaderText = "登錄日期";
            this.kEYDATEDataGridViewTextBoxColumn.Name = "kEYDATEDataGridViewTextBoxColumn";
            this.kEYDATEDataGridViewTextBoxColumn.ReadOnly = true;
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
            this.splitContainer1.SplitterDistance = 221;
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
            this.splitContainer2.Size = new System.Drawing.Size(626, 216);
            this.splitContainer2.SplitterDistance = 123;
            this.splitContainer2.TabIndex = 0;
            // 
            // FRMG12
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 441);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "FRMG12";
            this.Text = "FRMG12";
            this.Load += new System.EventHandler(this.FRMG12_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lOCKWAGEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysDS)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
		private System.Windows.Forms.BindingSource lOCKWAGEBindingSource;
		private JBHR.Sys.SysDSTableAdapters.LOCK_WAGETableAdapter lOCK_WAGETableAdapter;
		private System.Windows.Forms.Panel panel1;
		private JBControls.TextBox maskedTextBox2;
		private JBControls.TextBox textBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private JBControls.TextBox MEMOTextBox;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DataGridViewTextBoxColumn yYMMDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn sEQDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn sALADRDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn mENODataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn kEYMANDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn kEYDATEDataGridViewTextBoxColumn;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.Label saladrLabel;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnBatch;
	}
}