namespace JBHR.Sys
{
	partial class U_QUERY
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtValue1 = new JBControls.TextBox();
            this.gridQuery = new JBControls.DataGridView();
            this.cALCCONDITIONBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sysDS = new JBHR.Sys.SysDS();
            this.label3 = new System.Windows.Forms.Label();
            this.bnAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbQueryField = new System.Windows.Forms.ComboBox();
            this.mTCODEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainDS = new JBHR.MainDS();
            this.bnQuit = new System.Windows.Forms.Button();
            this.mTCODETableAdapter = new JBHR.MainDSTableAdapters.MTCODETableAdapter();
            this.cALC_CONDITIONTableAdapter = new JBHR.Sys.SysDSTableAdapters.CALC_CONDITIONTableAdapter();
            this.bnQuery = new System.Windows.Forms.Button();
            this.cbCriteria = new System.Windows.Forms.ComboBox();
            this.ButtonColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cONDTYPEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cONDITIONDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vALUE1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cALCCONDITIONBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mTCODEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDS)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.cbCriteria);
            this.panel1.Controls.Add(this.txtValue1);
            this.panel1.Controls.Add(this.gridQuery);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.bnAdd);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbQueryField);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(417, 151);
            this.panel1.TabIndex = 0;
            // 
            // txtValue1
            // 
            this.txtValue1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtValue1.CaptionLabel = null;
            this.txtValue1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtValue1.DecimalPlace = 5;
            this.txtValue1.IsEmpty = true;
            this.txtValue1.Location = new System.Drawing.Point(226, 7);
            this.txtValue1.Mask = "";
            this.txtValue1.MaxLength = -1;
            this.txtValue1.Name = "txtValue1";
            this.txtValue1.PasswordChar = '\0';
            this.txtValue1.ReadOnly = false;
            this.txtValue1.Size = new System.Drawing.Size(100, 22);
            this.txtValue1.TabIndex = 11;
            this.txtValue1.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // gridQuery
            // 
            this.gridQuery.AllowUserToAddRows = false;
            this.gridQuery.AllowUserToDeleteRows = false;
            this.gridQuery.AllowUserToResizeRows = false;
            this.gridQuery.AutoGenerateColumns = false;
            this.gridQuery.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridQuery.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("細明體", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridQuery.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridQuery.ColumnHeadersVisible = false;
            this.gridQuery.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ButtonColumn,
            this.cONDTYPEDataGridViewTextBoxColumn,
            this.cONDITIONDataGridViewTextBoxColumn,
            this.vALUE1DataGridViewTextBoxColumn});
            this.gridQuery.DataSource = this.cALCCONDITIONBindingSource;
            this.gridQuery.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridQuery.Location = new System.Drawing.Point(71, 35);
            this.gridQuery.MultiSelect = false;
            this.gridQuery.Name = "gridQuery";
            this.gridQuery.ReadOnly = true;
            this.gridQuery.RowHeadersVisible = false;
            this.gridQuery.RowTemplate.Height = 24;
            this.gridQuery.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridQuery.Size = new System.Drawing.Size(336, 99);
            this.gridQuery.TabIndex = 4;
            this.gridQuery.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridQuery_CellContentClick);
            // 
            // cALCCONDITIONBindingSource
            // 
            this.cALCCONDITIONBindingSource.DataMember = "CALC_CONDITION";
            this.cALCCONDITIONBindingSource.DataSource = this.sysDS;
            // 
            // sysDS
            // 
            this.sysDS.DataSetName = "SysDS";
            this.sysDS.Locale = new System.Globalization.CultureInfo("");
            this.sysDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "選擇條件";
            // 
            // bnAdd
            // 
            this.bnAdd.Location = new System.Drawing.Point(332, 6);
            this.bnAdd.Name = "bnAdd";
            this.bnAdd.Size = new System.Drawing.Size(75, 23);
            this.bnAdd.TabIndex = 3;
            this.bnAdd.Text = "新增";
            this.bnAdd.UseVisualStyleBackColor = true;
            this.bnAdd.Click += new System.EventHandler(this.bnAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "條件欄位";
            // 
            // cbQueryField
            // 
            this.cbQueryField.DataSource = this.mTCODEBindingSource;
            this.cbQueryField.DisplayMember = "NAME";
            this.cbQueryField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbQueryField.FormattingEnabled = true;
            this.cbQueryField.Location = new System.Drawing.Point(71, 8);
            this.cbQueryField.Name = "cbQueryField";
            this.cbQueryField.Size = new System.Drawing.Size(100, 20);
            this.cbQueryField.TabIndex = 0;
            this.cbQueryField.TabStop = false;
            this.cbQueryField.ValueMember = "CODE";
            this.cbQueryField.SelectedIndexChanged += new System.EventHandler(this.cbQueryField_SelectedIndexChanged);
            // 
            // mTCODEBindingSource
            // 
            this.mTCODEBindingSource.DataMember = "MTCODE";
            this.mTCODEBindingSource.DataSource = this.mainDS;
            // 
            // mainDS
            // 
            this.mainDS.DataSetName = "MainDS";
            this.mainDS.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.mainDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bnQuit
            // 
            this.bnQuit.Location = new System.Drawing.Point(233, 169);
            this.bnQuit.Name = "bnQuit";
            this.bnQuit.Size = new System.Drawing.Size(75, 23);
            this.bnQuit.TabIndex = 2;
            this.bnQuit.Text = "離開";
            this.bnQuit.UseVisualStyleBackColor = true;
            this.bnQuit.Click += new System.EventHandler(this.bnQuit_Click);
            // 
            // mTCODETableAdapter
            // 
            this.mTCODETableAdapter.ClearBeforeFill = true;
            // 
            // cALC_CONDITIONTableAdapter
            // 
            this.cALC_CONDITIONTableAdapter.ClearBeforeFill = true;
            // 
            // bnQuery
            // 
            this.bnQuery.Location = new System.Drawing.Point(133, 169);
            this.bnQuery.Name = "bnQuery";
            this.bnQuery.Size = new System.Drawing.Size(75, 23);
            this.bnQuery.TabIndex = 3;
            this.bnQuery.Text = "存檔";
            this.bnQuery.UseVisualStyleBackColor = true;
            this.bnQuery.Click += new System.EventHandler(this.bnQuery_Click);
            // 
            // cbCriteria
            // 
            this.cbCriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCriteria.FormattingEnabled = true;
            this.cbCriteria.Items.AddRange(new object[] {
            "=",
            "<>"});
            this.cbCriteria.Location = new System.Drawing.Point(177, 8);
            this.cbCriteria.Name = "cbCriteria";
            this.cbCriteria.Size = new System.Drawing.Size(43, 20);
            this.cbCriteria.TabIndex = 12;
            // 
            // ButtonColumn
            // 
            this.ButtonColumn.HeaderText = "";
            this.ButtonColumn.Name = "ButtonColumn";
            this.ButtonColumn.ReadOnly = true;
            this.ButtonColumn.Text = "刪除條件";
            this.ButtonColumn.UseColumnTextForButtonValue = true;
            // 
            // cONDTYPEDataGridViewTextBoxColumn
            // 
            this.cONDTYPEDataGridViewTextBoxColumn.DataPropertyName = "COND_TYPE";
            this.cONDTYPEDataGridViewTextBoxColumn.DataSource = this.mTCODEBindingSource;
            this.cONDTYPEDataGridViewTextBoxColumn.DisplayMember = "NAME";
            this.cONDTYPEDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.cONDTYPEDataGridViewTextBoxColumn.HeaderText = "COND_TYPE";
            this.cONDTYPEDataGridViewTextBoxColumn.Name = "cONDTYPEDataGridViewTextBoxColumn";
            this.cONDTYPEDataGridViewTextBoxColumn.ReadOnly = true;
            this.cONDTYPEDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cONDTYPEDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cONDTYPEDataGridViewTextBoxColumn.ValueMember = "CODE";
            // 
            // cONDITIONDataGridViewTextBoxColumn
            // 
            this.cONDITIONDataGridViewTextBoxColumn.DataPropertyName = "CONDITION";
            this.cONDITIONDataGridViewTextBoxColumn.HeaderText = "CONDITION";
            this.cONDITIONDataGridViewTextBoxColumn.Name = "cONDITIONDataGridViewTextBoxColumn";
            this.cONDITIONDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vALUE1DataGridViewTextBoxColumn
            // 
            this.vALUE1DataGridViewTextBoxColumn.DataPropertyName = "VALUE1";
            this.vALUE1DataGridViewTextBoxColumn.HeaderText = "VALUE1";
            this.vALUE1DataGridViewTextBoxColumn.Name = "vALUE1DataGridViewTextBoxColumn";
            this.vALUE1DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // U_QUERY
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(441, 202);
            this.ControlBox = false;
            this.Controls.Add(this.bnQuery);
            this.Controls.Add(this.bnQuit);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "U_QUERY";
            this.Text = "進階設定";
            this.Activated += new System.EventHandler(this.U_QUERY_Activated);
            this.Load += new System.EventHandler(this.U_QUERY_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cALCCONDITIONBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mTCODEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDS)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbQueryField;
		private System.Windows.Forms.Button bnAdd;
        private System.Windows.Forms.Button bnQuit;
        private System.Windows.Forms.Label label3;
        private JBControls.DataGridView gridQuery;
        private JBControls.TextBox txtValue1;
        private MainDS mainDS;
        private System.Windows.Forms.BindingSource mTCODEBindingSource;
        private MainDSTableAdapters.MTCODETableAdapter mTCODETableAdapter;
        private SysDS sysDS;
        private System.Windows.Forms.BindingSource cALCCONDITIONBindingSource;
        private SysDSTableAdapters.CALC_CONDITIONTableAdapter cALC_CONDITIONTableAdapter;
        private System.Windows.Forms.Button bnQuery;
        private System.Windows.Forms.ComboBox cbCriteria;
        private System.Windows.Forms.DataGridViewButtonColumn ButtonColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn cONDTYPEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cONDITIONDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vALUE1DataGridViewTextBoxColumn;
	}
}