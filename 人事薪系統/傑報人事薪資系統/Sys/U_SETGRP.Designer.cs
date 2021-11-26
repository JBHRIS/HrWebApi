namespace JBHR.Sys
{
    partial class U_SETGRP
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new JBControls.DataGridView();
            this.pROGDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pROGNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uPRGBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sysDS = new JBHR.Sys.SysDS();
            this.dataGridView2 = new JBControls.DataGridView();
            this.gROUPIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gROUPNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pROGDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PROG = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.aDDDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.eDITDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dELEDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pRINTDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sYSTEMDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.kEYMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uGROUPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBox1 = new JBControls.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uGROUP1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fullDataCtrl1 = new JBControls.FullDataCtrl();
            this.textBox1 = new JBControls.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new JBControls.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1 = new JBControls.CheckBox();
            this.checkBox2 = new JBControls.CheckBox();
            this.checkBox3 = new JBControls.CheckBox();
            this.checkBox4 = new JBControls.CheckBox();
            this.u_PRGTableAdapter = new JBHR.Sys.SysDSTableAdapters.U_PRGTableAdapter();
            this.u_GROUPTableAdapter = new JBHR.Sys.SysDSTableAdapters.U_GROUPTableAdapter();
            this.u_GROUP1TableAdapter = new JBHR.Sys.SysDSTableAdapters.U_GROUP1TableAdapter();
            this.label4 = new System.Windows.Forms.Label();
            this.lbPrgID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uPRGBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uGROUPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uGROUP1BindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pROGDataGridViewTextBoxColumn,
            this.pROGNAMEDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.uPRGBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(203, 452);
            this.dataGridView1.TabIndex = 0;
            // 
            // pROGDataGridViewTextBoxColumn
            // 
            this.pROGDataGridViewTextBoxColumn.DataPropertyName = "PROG";
            this.pROGDataGridViewTextBoxColumn.FillWeight = 70F;
            this.pROGDataGridViewTextBoxColumn.HeaderText = "程式代碼";
            this.pROGDataGridViewTextBoxColumn.Name = "pROGDataGridViewTextBoxColumn";
            this.pROGDataGridViewTextBoxColumn.ReadOnly = true;
            this.pROGDataGridViewTextBoxColumn.Width = 70;
            // 
            // pROGNAMEDataGridViewTextBoxColumn
            // 
            this.pROGNAMEDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pROGNAMEDataGridViewTextBoxColumn.DataPropertyName = "PROG_NAME";
            this.pROGNAMEDataGridViewTextBoxColumn.HeaderText = "程式名稱";
            this.pROGNAMEDataGridViewTextBoxColumn.Name = "pROGNAMEDataGridViewTextBoxColumn";
            this.pROGNAMEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // uPRGBindingSource
            // 
            this.uPRGBindingSource.DataMember = "U_PRG";
            this.uPRGBindingSource.DataSource = this.sysDS;
            // 
            // sysDS
            // 
            this.sysDS.DataSetName = "SysDS";
            this.sysDS.Locale = new System.Globalization.CultureInfo("");
            this.sysDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoGenerateColumns = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gROUPIDDataGridViewTextBoxColumn,
            this.gROUPNAMEDataGridViewTextBoxColumn,
            this.pROGDataGridViewTextBoxColumn1,
            this.PROG,
            this.aDDDataGridViewCheckBoxColumn,
            this.eDITDataGridViewCheckBoxColumn,
            this.dELEDataGridViewCheckBoxColumn,
            this.pRINTDataGridViewCheckBoxColumn,
            this.sYSTEMDataGridViewCheckBoxColumn,
            this.kEYMANDataGridViewTextBoxColumn,
            this.kEYDATEDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.uGROUPBindingSource;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView2.Location = new System.Drawing.Point(203, 0);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(633, 209);
            this.dataGridView2.TabIndex = 1;
            // 
            // gROUPIDDataGridViewTextBoxColumn
            // 
            this.gROUPIDDataGridViewTextBoxColumn.DataPropertyName = "GROUP_ID";
            this.gROUPIDDataGridViewTextBoxColumn.HeaderText = "群組代碼";
            this.gROUPIDDataGridViewTextBoxColumn.Name = "gROUPIDDataGridViewTextBoxColumn";
            this.gROUPIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // gROUPNAMEDataGridViewTextBoxColumn
            // 
            this.gROUPNAMEDataGridViewTextBoxColumn.DataPropertyName = "GROUP_NAME";
            this.gROUPNAMEDataGridViewTextBoxColumn.HeaderText = "群組名稱";
            this.gROUPNAMEDataGridViewTextBoxColumn.Name = "gROUPNAMEDataGridViewTextBoxColumn";
            this.gROUPNAMEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pROGDataGridViewTextBoxColumn1
            // 
            this.pROGDataGridViewTextBoxColumn1.DataPropertyName = "PROG";
            this.pROGDataGridViewTextBoxColumn1.HeaderText = "程式代碼";
            this.pROGDataGridViewTextBoxColumn1.Name = "pROGDataGridViewTextBoxColumn1";
            this.pROGDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // PROG
            // 
            this.PROG.DataPropertyName = "PROG";
            this.PROG.DataSource = this.uPRGBindingSource;
            this.PROG.DisplayMember = "PROG_NAME";
            this.PROG.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.PROG.HeaderText = "程式名稱";
            this.PROG.Name = "PROG";
            this.PROG.ReadOnly = true;
            this.PROG.ValueMember = "PROG";
            // 
            // aDDDataGridViewCheckBoxColumn
            // 
            this.aDDDataGridViewCheckBoxColumn.DataPropertyName = "ADD_";
            this.aDDDataGridViewCheckBoxColumn.HeaderText = "新增";
            this.aDDDataGridViewCheckBoxColumn.Name = "aDDDataGridViewCheckBoxColumn";
            this.aDDDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // eDITDataGridViewCheckBoxColumn
            // 
            this.eDITDataGridViewCheckBoxColumn.DataPropertyName = "EDIT";
            this.eDITDataGridViewCheckBoxColumn.HeaderText = "修改";
            this.eDITDataGridViewCheckBoxColumn.Name = "eDITDataGridViewCheckBoxColumn";
            this.eDITDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // dELEDataGridViewCheckBoxColumn
            // 
            this.dELEDataGridViewCheckBoxColumn.DataPropertyName = "DELE";
            this.dELEDataGridViewCheckBoxColumn.HeaderText = "刪除";
            this.dELEDataGridViewCheckBoxColumn.Name = "dELEDataGridViewCheckBoxColumn";
            this.dELEDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // pRINTDataGridViewCheckBoxColumn
            // 
            this.pRINTDataGridViewCheckBoxColumn.DataPropertyName = "PRINT_";
            this.pRINTDataGridViewCheckBoxColumn.HeaderText = "匯出";
            this.pRINTDataGridViewCheckBoxColumn.Name = "pRINTDataGridViewCheckBoxColumn";
            this.pRINTDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // sYSTEMDataGridViewCheckBoxColumn
            // 
            this.sYSTEMDataGridViewCheckBoxColumn.DataPropertyName = "SYSTEM";
            this.sYSTEMDataGridViewCheckBoxColumn.HeaderText = "系統";
            this.sYSTEMDataGridViewCheckBoxColumn.Name = "sYSTEMDataGridViewCheckBoxColumn";
            this.sYSTEMDataGridViewCheckBoxColumn.ReadOnly = true;
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
            // uGROUPBindingSource
            // 
            this.uGROUPBindingSource.DataMember = "U_GROUP";
            this.uGROUPBindingSource.DataSource = this.sysDS;
            this.uGROUPBindingSource.CurrentChanged += new System.EventHandler(this.uGROUPBindingSource_CurrentChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.comboBox1.BackColor = System.Drawing.SystemColors.Control;
            this.comboBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.comboBox1.CaptionLabel = this.label1;
            this.comboBox1.DataSource = this.uGROUP1BindingSource;
            this.comboBox1.DisplayMember = "group_name";
            this.comboBox1.DropDownCount = 10;
            this.comboBox1.IsEmpty = true;
            this.comboBox1.Location = new System.Drawing.Point(289, 279);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.SelectedValue = "";
            this.comboBox1.Size = new System.Drawing.Size(124, 22);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.ValueMember = "group_id";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(230, 284);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "群組代碼";
            // 
            // uGROUP1BindingSource
            // 
            this.uGROUP1BindingSource.DataMember = "U_GROUP1";
            this.uGROUP1BindingSource.DataSource = this.sysDS;
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
            this.fullDataCtrl1.CtrlType = JBControls.FullDataCtrl.ECtrlType.Full;
            this.fullDataCtrl1.DataAdapter = null;
            this.fullDataCtrl1.DataGrid = this.dataGridView2;
            this.fullDataCtrl1.DataSource = this.uGROUPBindingSource;
            this.fullDataCtrl1.GroupCmd = "";
            this.fullDataCtrl1.Location = new System.Drawing.Point(203, 379);
            this.fullDataCtrl1.Name = "fullDataCtrl1";
            this.fullDataCtrl1.QueryFields = "group_id,group_name";
            this.fullDataCtrl1.RecentQuerySql = "";
            this.fullDataCtrl1.SelectCmd = "";
            this.fullDataCtrl1.ShowExceptionMsg = true;
            this.fullDataCtrl1.Size = new System.Drawing.Size(633, 73);
            this.fullDataCtrl1.SortFields = "group_id,group_name,prog";
            this.fullDataCtrl1.TabIndex = 4;
            this.fullDataCtrl1.WhereCmd = "";
            this.fullDataCtrl1.AfterDel += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterDel);
            this.fullDataCtrl1.AfterSave += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterSave);
            this.fullDataCtrl1.BeforeSave += new JBControls.FullDataCtrl.BeforeEventHandler(this.fullDataCtrl1_BeforeSave);
            this.fullDataCtrl1.AfterCancel += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterCancel);
            this.fullDataCtrl1.AfterAdd += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterAdd);
            this.fullDataCtrl1.AfterExport += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterExport);
            this.fullDataCtrl1.AfterEdit += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterEdit);
            // 
            // textBox1
            // 
            this.textBox1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox1.CaptionLabel = this.label2;
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox1.DecimalPlace = 2;
            this.textBox1.IsEmpty = true;
            this.textBox1.Location = new System.Drawing.Point(68, 19);
            this.textBox1.Mask = "";
            this.textBox1.MaxLength = 50;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.ReadOnly = false;
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 5;
            this.textBox1.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(9, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "群組代碼";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(221, 219);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 51);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "若為新的群組代碼與名稱請填這裡";
            // 
            // textBox2
            // 
            this.textBox2.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox2.CaptionLabel = this.label3;
            this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox2.DecimalPlace = 2;
            this.textBox2.IsEmpty = true;
            this.textBox2.Location = new System.Drawing.Point(244, 19);
            this.textBox2.Mask = "";
            this.textBox2.MaxLength = 50;
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '\0';
            this.textBox2.ReadOnly = false;
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 7;
            this.textBox2.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(185, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "群組名稱";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.CaptionLabel = null;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.uGROUPBindingSource, "ADD_", true));
            this.checkBox1.IsImitateCaption = true;
            this.checkBox1.Location = new System.Drawing.Point(232, 347);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(48, 16);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "新增";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.CaptionLabel = null;
            this.checkBox2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.uGROUPBindingSource, "EDIT", true));
            this.checkBox2.IsImitateCaption = true;
            this.checkBox2.Location = new System.Drawing.Point(286, 347);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(48, 16);
            this.checkBox2.TabIndex = 9;
            this.checkBox2.Text = "修改";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.CaptionLabel = null;
            this.checkBox3.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.uGROUPBindingSource, "DELE", true));
            this.checkBox3.IsImitateCaption = true;
            this.checkBox3.Location = new System.Drawing.Point(340, 347);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(48, 16);
            this.checkBox3.TabIndex = 10;
            this.checkBox3.Text = "刪除";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.CaptionLabel = null;
            this.checkBox4.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.uGROUPBindingSource, "PRINT_", true));
            this.checkBox4.IsImitateCaption = true;
            this.checkBox4.Location = new System.Drawing.Point(394, 347);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(48, 16);
            this.checkBox4.TabIndex = 11;
            this.checkBox4.Text = "匯出";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // u_PRGTableAdapter
            // 
            this.u_PRGTableAdapter.ClearBeforeFill = true;
            // 
            // u_GROUPTableAdapter
            // 
            this.u_GROUPTableAdapter.ClearBeforeFill = true;
            // 
            // u_GROUP1TableAdapter
            // 
            this.u_GROUP1TableAdapter.ClearBeforeFill = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(230, 328);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "程式代碼:";
            // 
            // lbPrgID
            // 
            this.lbPrgID.AutoSize = true;
            this.lbPrgID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uGROUPBindingSource, "PROG", true));
            this.lbPrgID.Location = new System.Drawing.Point(295, 328);
            this.lbPrgID.Name = "lbPrgID";
            this.lbPrgID.Size = new System.Drawing.Size(0, 12);
            this.lbPrgID.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(287, 304);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(209, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "若是新的資料群組，這裡請選(None)。";
            // 
            // U_SETGRP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 452);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbPrgID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.fullDataCtrl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "U_SETGRP";
            this.Text = "U_SETGRP";
            this.Load += new System.EventHandler(this.U_SETGRP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uPRGBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sysDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uGROUPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uGROUP1BindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private JBControls.DataGridView dataGridView1;
        private SysDS sysDS;
        private System.Windows.Forms.BindingSource uPRGBindingSource;
        private JBHR.Sys.SysDSTableAdapters.U_PRGTableAdapter u_PRGTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn pROGDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pROGNAMEDataGridViewTextBoxColumn;
        private JBControls.DataGridView dataGridView2;
        private System.Windows.Forms.BindingSource uGROUPBindingSource;
        private JBHR.Sys.SysDSTableAdapters.U_GROUPTableAdapter u_GROUPTableAdapter;
        private JBControls.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private JBControls.FullDataCtrl fullDataCtrl1;
        private JBControls.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private JBControls.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private JBControls.CheckBox checkBox1;
        private JBControls.CheckBox checkBox2;
        private JBControls.CheckBox checkBox3;
        private JBControls.CheckBox checkBox4;
        private System.Windows.Forms.BindingSource uGROUP1BindingSource;
        private JBHR.Sys.SysDSTableAdapters.U_GROUP1TableAdapter u_GROUP1TableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn gROUPIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gROUPNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pROGDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewComboBoxColumn PROG;
        private System.Windows.Forms.DataGridViewCheckBoxColumn aDDDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn eDITDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dELEDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn pRINTDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn sYSTEMDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYMANDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbPrgID;
        private System.Windows.Forms.Label label5;
    }
}