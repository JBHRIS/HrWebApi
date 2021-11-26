namespace JBHR.Sys
{
	partial class U_TTS
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewEx1 = new JBControls.DataGridView();
            this.pRGNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oPCODEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cONTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYTIMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uTTSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sysDS = new JBHR.MainDS();
            this.fullDataCtrl1 = new JBControls.FullDataCtrl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.u_TTSTableAdapter = new JBHR.MainDSTableAdapters.U_TTSTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uTTSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysDS)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewEx1
            // 
            this.dataGridViewEx1.AllowUserToAddRows = false;
            this.dataGridViewEx1.AllowUserToDeleteRows = false;
            this.dataGridViewEx1.AllowUserToResizeRows = false;
            this.dataGridViewEx1.AutoGenerateColumns = false;
            this.dataGridViewEx1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewEx1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewEx1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewEx1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEx1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pRGNAMEDataGridViewTextBoxColumn,
            this.kEYMANDataGridViewTextBoxColumn,
            this.kEYDATEDataGridViewTextBoxColumn,
            this.oPCODEDataGridViewTextBoxColumn,
            this.cONTDataGridViewTextBoxColumn,
            this.kEYTIMEDataGridViewTextBoxColumn});
            this.dataGridViewEx1.DataSource = this.uTTSBindingSource;
            this.dataGridViewEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEx1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewEx1.MultiSelect = false;
            this.dataGridViewEx1.Name = "dataGridViewEx1";
            this.dataGridViewEx1.ReadOnly = true;
            this.dataGridViewEx1.RowHeadersVisible = false;
            this.dataGridViewEx1.RowTemplate.Height = 24;
            this.dataGridViewEx1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEx1.Size = new System.Drawing.Size(636, 413);
            this.dataGridViewEx1.TabIndex = 4;
            // 
            // pRGNAMEDataGridViewTextBoxColumn
            // 
            this.pRGNAMEDataGridViewTextBoxColumn.DataPropertyName = "PRG_NAME";
            this.pRGNAMEDataGridViewTextBoxColumn.HeaderText = "程式名稱";
            this.pRGNAMEDataGridViewTextBoxColumn.Name = "pRGNAMEDataGridViewTextBoxColumn";
            this.pRGNAMEDataGridViewTextBoxColumn.ReadOnly = true;
            this.pRGNAMEDataGridViewTextBoxColumn.Width = 78;
            // 
            // kEYMANDataGridViewTextBoxColumn
            // 
            this.kEYMANDataGridViewTextBoxColumn.DataPropertyName = "KEY_MAN";
            this.kEYMANDataGridViewTextBoxColumn.HeaderText = "登錄者";
            this.kEYMANDataGridViewTextBoxColumn.Name = "kEYMANDataGridViewTextBoxColumn";
            this.kEYMANDataGridViewTextBoxColumn.ReadOnly = true;
            this.kEYMANDataGridViewTextBoxColumn.Width = 66;
            // 
            // kEYDATEDataGridViewTextBoxColumn
            // 
            this.kEYDATEDataGridViewTextBoxColumn.DataPropertyName = "KEY_DATE";
            this.kEYDATEDataGridViewTextBoxColumn.HeaderText = "登錄日期";
            this.kEYDATEDataGridViewTextBoxColumn.Name = "kEYDATEDataGridViewTextBoxColumn";
            this.kEYDATEDataGridViewTextBoxColumn.ReadOnly = true;
            this.kEYDATEDataGridViewTextBoxColumn.Width = 78;
            // 
            // oPCODEDataGridViewTextBoxColumn
            // 
            this.oPCODEDataGridViewTextBoxColumn.DataPropertyName = "OP_CODE";
            this.oPCODEDataGridViewTextBoxColumn.HeaderText = "異動代號";
            this.oPCODEDataGridViewTextBoxColumn.Name = "oPCODEDataGridViewTextBoxColumn";
            this.oPCODEDataGridViewTextBoxColumn.ReadOnly = true;
            this.oPCODEDataGridViewTextBoxColumn.Width = 78;
            // 
            // cONTDataGridViewTextBoxColumn
            // 
            this.cONTDataGridViewTextBoxColumn.DataPropertyName = "CONT";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cONTDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.cONTDataGridViewTextBoxColumn.HeaderText = "異動內容";
            this.cONTDataGridViewTextBoxColumn.Name = "cONTDataGridViewTextBoxColumn";
            this.cONTDataGridViewTextBoxColumn.ReadOnly = true;
            this.cONTDataGridViewTextBoxColumn.Width = 78;
            // 
            // kEYTIMEDataGridViewTextBoxColumn
            // 
            this.kEYTIMEDataGridViewTextBoxColumn.DataPropertyName = "KEY_TIME";
            this.kEYTIMEDataGridViewTextBoxColumn.HeaderText = "登錄時間";
            this.kEYTIMEDataGridViewTextBoxColumn.Name = "kEYTIMEDataGridViewTextBoxColumn";
            this.kEYTIMEDataGridViewTextBoxColumn.ReadOnly = true;
            this.kEYTIMEDataGridViewTextBoxColumn.Width = 78;
            // 
            // uTTSBindingSource
            // 
            this.uTTSBindingSource.DataMember = "U_TTS";
            this.uTTSBindingSource.DataSource = this.sysDS;
            // 
            // sysDS
            // 
            this.sysDS.DataSetName = "SysDS";
            this.sysDS.RemotingFormat = System.Data.SerializationFormat.Binary;
            this.sysDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fullDataCtrl1
            // 
            this.fullDataCtrl1.BindingCtrlsAutoInit = true;
            this.fullDataCtrl1.bnAddEnable = true;
            this.fullDataCtrl1.bnAddVisible = true;
            this.fullDataCtrl1.bnDelEnable = true;
            this.fullDataCtrl1.bnDelVisible = true;
            this.fullDataCtrl1.bnEditEnable = true;
            this.fullDataCtrl1.bnEditVisible = true;
            this.fullDataCtrl1.bnExportEnable = true;
            this.fullDataCtrl1.bnExportVisible = true;
            this.fullDataCtrl1.bnQueryEnable = true;
            this.fullDataCtrl1.bnQueryVisible = true;
            this.fullDataCtrl1.CtrlType = JBControls.FullDataCtrl.ECtrlType.Action;
            this.fullDataCtrl1.DataAdapter = null;
            this.fullDataCtrl1.DataGrid = this.dataGridViewEx1;
            this.fullDataCtrl1.DataSource = this.uTTSBindingSource;
            this.fullDataCtrl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.fullDataCtrl1.GroupCmd = "";
            this.fullDataCtrl1.Location = new System.Drawing.Point(0, 0);
            this.fullDataCtrl1.Name = "fullDataCtrl1";
            this.fullDataCtrl1.QueryFields = "prg_name,key_man,key_date";
            this.fullDataCtrl1.RecentQuerySql = "";
            this.fullDataCtrl1.SelectCmd = "";
            this.fullDataCtrl1.ShowExceptionMsg = true;
            this.fullDataCtrl1.Size = new System.Drawing.Size(636, 29);
            this.fullDataCtrl1.SortFields = "prg_name,key_man,key_date";
            this.fullDataCtrl1.TabIndex = 5;
            this.fullDataCtrl1.Tag = "";
            this.fullDataCtrl1.WhereCmd = "";
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
            this.splitContainer1.Panel2.Controls.Add(this.fullDataCtrl1);
            this.splitContainer1.Size = new System.Drawing.Size(636, 452);
            this.splitContainer1.SplitterDistance = 413;
            this.splitContainer1.TabIndex = 6;
            // 
            // u_TTSTableAdapter
            // 
            this.u_TTSTableAdapter.ClearBeforeFill = true;
            // 
            // U_TTS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 452);
            this.Controls.Add(this.splitContainer1);
            this.Name = "U_TTS";
            this.Text = "U_TTS";
            this.Load += new System.EventHandler(this.U_TTS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uTTSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysDS)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private JBControls.DataGridView dataGridViewEx1;
		private JBControls.FullDataCtrl fullDataCtrl1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private JBHR.MainDS sysDS;
		private System.Windows.Forms.BindingSource uTTSBindingSource;
		private JBHR.MainDSTableAdapters.U_TTSTableAdapter u_TTSTableAdapter;
		private System.Windows.Forms.DataGridViewTextBoxColumn pRGNAMEDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn kEYMANDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn kEYDATEDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn oPCODEDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn cONTDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn kEYTIMEDataGridViewTextBoxColumn;
	}
}