namespace JBHR.Bas
{
    partial class FRM1F
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
            this.dataGridView1 = new JBControls.DataGridView();
            this.NOBR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nOBRDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.vBASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.basDS = new JBHR.Bas.BasDS();
            this.DEPT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JOB_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dESCSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOMPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lICNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lICPASSDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.oWNERDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lICNOTEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lICANBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bnIMPORT = new System.Windows.Forms.Button();
            this.popupTextBox1 = new JBControls.PopupTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox2 = new JBControls.CheckBox();
            this.checkBox1 = new JBControls.CheckBox();
            this.textBox6 = new JBControls.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox5 = new JBControls.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox4 = new JBControls.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new JBControls.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new JBControls.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new JBControls.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fullDataCtrl1 = new JBControls.FullDataCtrl();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lICANTableAdapter = new JBHR.Bas.BasDSTableAdapters.LICANTableAdapter();
            this.v_BASETableAdapter = new JBHR.Bas.BasDSTableAdapters.V_BASETableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vBASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.basDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lICANBindingSource)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(626, 441);
            this.splitContainer1.SplitterDistance = 197;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("細明體", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NOBR,
            this.nOBRDataGridViewTextBoxColumn,
            this.DEPT_NAME,
            this.JOB_NAME,
            this.dESCSDataGridViewTextBoxColumn,
            this.cOMPDataGridViewTextBoxColumn,
            this.mDATEDataGridViewTextBoxColumn,
            this.eDATEDataGridViewTextBoxColumn,
            this.lICNODataGridViewTextBoxColumn,
            this.lICPASSDataGridViewCheckBoxColumn,
            this.oWNERDataGridViewCheckBoxColumn,
            this.lICNOTEDataGridViewTextBoxColumn,
            this.kEYDATEDataGridViewTextBoxColumn,
            this.kEYMANDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.lICANBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(626, 197);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // NOBR
            // 
            this.NOBR.DataPropertyName = "NOBR";
            this.NOBR.HeaderText = "員工編號";
            this.NOBR.MinimumWidth = 8;
            this.NOBR.Name = "NOBR";
            this.NOBR.ReadOnly = true;
            this.NOBR.Width = 78;
            // 
            // nOBRDataGridViewTextBoxColumn
            // 
            this.nOBRDataGridViewTextBoxColumn.DataPropertyName = "NOBR";
            this.nOBRDataGridViewTextBoxColumn.DataSource = this.vBASEBindingSource;
            this.nOBRDataGridViewTextBoxColumn.DisplayMember = "NAME_C";
            this.nOBRDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.nOBRDataGridViewTextBoxColumn.HeaderText = "員工姓名";
            this.nOBRDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.nOBRDataGridViewTextBoxColumn.Name = "nOBRDataGridViewTextBoxColumn";
            this.nOBRDataGridViewTextBoxColumn.ReadOnly = true;
            this.nOBRDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.nOBRDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.nOBRDataGridViewTextBoxColumn.ValueMember = "NOBR";
            this.nOBRDataGridViewTextBoxColumn.Width = 78;
            // 
            // vBASEBindingSource
            // 
            this.vBASEBindingSource.DataMember = "V_BASE";
            this.vBASEBindingSource.DataSource = this.basDS;
            // 
            // basDS
            // 
            this.basDS.DataSetName = "BasDS";
            this.basDS.Locale = new System.Globalization.CultureInfo("");
            this.basDS.RemotingFormat = System.Data.SerializationFormat.Binary;
            this.basDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DEPT_NAME
            // 
            this.DEPT_NAME.DataPropertyName = "DEPT_NAME";
            this.DEPT_NAME.HeaderText = "部門";
            this.DEPT_NAME.MinimumWidth = 8;
            this.DEPT_NAME.Name = "DEPT_NAME";
            this.DEPT_NAME.ReadOnly = true;
            this.DEPT_NAME.Width = 54;
            // 
            // JOB_NAME
            // 
            this.JOB_NAME.DataPropertyName = "JOB_NAME";
            this.JOB_NAME.HeaderText = "職稱";
            this.JOB_NAME.MinimumWidth = 8;
            this.JOB_NAME.Name = "JOB_NAME";
            this.JOB_NAME.ReadOnly = true;
            this.JOB_NAME.Width = 54;
            // 
            // dESCSDataGridViewTextBoxColumn
            // 
            this.dESCSDataGridViewTextBoxColumn.DataPropertyName = "DESCS";
            this.dESCSDataGridViewTextBoxColumn.HeaderText = "證照內容";
            this.dESCSDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.dESCSDataGridViewTextBoxColumn.Name = "dESCSDataGridViewTextBoxColumn";
            this.dESCSDataGridViewTextBoxColumn.ReadOnly = true;
            this.dESCSDataGridViewTextBoxColumn.Width = 78;
            // 
            // cOMPDataGridViewTextBoxColumn
            // 
            this.cOMPDataGridViewTextBoxColumn.DataPropertyName = "COMP";
            this.cOMPDataGridViewTextBoxColumn.HeaderText = "發照單位";
            this.cOMPDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.cOMPDataGridViewTextBoxColumn.Name = "cOMPDataGridViewTextBoxColumn";
            this.cOMPDataGridViewTextBoxColumn.ReadOnly = true;
            this.cOMPDataGridViewTextBoxColumn.Width = 78;
            // 
            // mDATEDataGridViewTextBoxColumn
            // 
            this.mDATEDataGridViewTextBoxColumn.DataPropertyName = "MDATE";
            this.mDATEDataGridViewTextBoxColumn.HeaderText = "生效日期";
            this.mDATEDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.mDATEDataGridViewTextBoxColumn.Name = "mDATEDataGridViewTextBoxColumn";
            this.mDATEDataGridViewTextBoxColumn.ReadOnly = true;
            this.mDATEDataGridViewTextBoxColumn.Width = 78;
            // 
            // eDATEDataGridViewTextBoxColumn
            // 
            this.eDATEDataGridViewTextBoxColumn.DataPropertyName = "EDATE";
            this.eDATEDataGridViewTextBoxColumn.HeaderText = "有效日期";
            this.eDATEDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.eDATEDataGridViewTextBoxColumn.Name = "eDATEDataGridViewTextBoxColumn";
            this.eDATEDataGridViewTextBoxColumn.ReadOnly = true;
            this.eDATEDataGridViewTextBoxColumn.Width = 78;
            // 
            // lICNODataGridViewTextBoxColumn
            // 
            this.lICNODataGridViewTextBoxColumn.DataPropertyName = "LIC_NO";
            this.lICNODataGridViewTextBoxColumn.HeaderText = "證照編號";
            this.lICNODataGridViewTextBoxColumn.MinimumWidth = 8;
            this.lICNODataGridViewTextBoxColumn.Name = "lICNODataGridViewTextBoxColumn";
            this.lICNODataGridViewTextBoxColumn.ReadOnly = true;
            this.lICNODataGridViewTextBoxColumn.Width = 78;
            // 
            // lICPASSDataGridViewCheckBoxColumn
            // 
            this.lICPASSDataGridViewCheckBoxColumn.DataPropertyName = "LIC_PASS";
            this.lICPASSDataGridViewCheckBoxColumn.HeaderText = "國家考試";
            this.lICPASSDataGridViewCheckBoxColumn.MinimumWidth = 8;
            this.lICPASSDataGridViewCheckBoxColumn.Name = "lICPASSDataGridViewCheckBoxColumn";
            this.lICPASSDataGridViewCheckBoxColumn.ReadOnly = true;
            this.lICPASSDataGridViewCheckBoxColumn.Width = 59;
            // 
            // oWNERDataGridViewCheckBoxColumn
            // 
            this.oWNERDataGridViewCheckBoxColumn.DataPropertyName = "OWNER";
            this.oWNERDataGridViewCheckBoxColumn.HeaderText = "本公司擁有";
            this.oWNERDataGridViewCheckBoxColumn.MinimumWidth = 8;
            this.oWNERDataGridViewCheckBoxColumn.Name = "oWNERDataGridViewCheckBoxColumn";
            this.oWNERDataGridViewCheckBoxColumn.ReadOnly = true;
            this.oWNERDataGridViewCheckBoxColumn.Width = 71;
            // 
            // lICNOTEDataGridViewTextBoxColumn
            // 
            this.lICNOTEDataGridViewTextBoxColumn.DataPropertyName = "LIC_NOTE";
            this.lICNOTEDataGridViewTextBoxColumn.HeaderText = "備註欄";
            this.lICNOTEDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.lICNOTEDataGridViewTextBoxColumn.Name = "lICNOTEDataGridViewTextBoxColumn";
            this.lICNOTEDataGridViewTextBoxColumn.ReadOnly = true;
            this.lICNOTEDataGridViewTextBoxColumn.Width = 66;
            // 
            // kEYDATEDataGridViewTextBoxColumn
            // 
            this.kEYDATEDataGridViewTextBoxColumn.DataPropertyName = "KEY_DATE";
            this.kEYDATEDataGridViewTextBoxColumn.HeaderText = "登錄時間";
            this.kEYDATEDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.kEYDATEDataGridViewTextBoxColumn.Name = "kEYDATEDataGridViewTextBoxColumn";
            this.kEYDATEDataGridViewTextBoxColumn.ReadOnly = true;
            this.kEYDATEDataGridViewTextBoxColumn.Width = 78;
            // 
            // kEYMANDataGridViewTextBoxColumn
            // 
            this.kEYMANDataGridViewTextBoxColumn.DataPropertyName = "KEY_MAN";
            this.kEYMANDataGridViewTextBoxColumn.HeaderText = "登錄者";
            this.kEYMANDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.kEYMANDataGridViewTextBoxColumn.Name = "kEYMANDataGridViewTextBoxColumn";
            this.kEYMANDataGridViewTextBoxColumn.ReadOnly = true;
            this.kEYMANDataGridViewTextBoxColumn.Width = 66;
            // 
            // lICANBindingSource
            // 
            this.lICANBindingSource.DataMember = "LICAN";
            this.lICANBindingSource.DataSource = this.basDS;
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
            this.splitContainer2.Size = new System.Drawing.Size(626, 240);
            this.splitContainer2.SplitterDistance = 162;
            this.splitContainer2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.bnIMPORT);
            this.panel1.Controls.Add(this.popupTextBox1);
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.textBox6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.textBox5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 162);
            this.panel1.TabIndex = 0;
            // 
            // bnIMPORT
            // 
            this.bnIMPORT.Location = new System.Drawing.Point(537, 129);
            this.bnIMPORT.Name = "bnIMPORT";
            this.bnIMPORT.Size = new System.Drawing.Size(75, 23);
            this.bnIMPORT.TabIndex = 32;
            this.bnIMPORT.TabStop = false;
            this.bnIMPORT.Text = "匯入";
            this.bnIMPORT.UseVisualStyleBackColor = true;
            this.bnIMPORT.Click += new System.EventHandler(this.bnIMPORT_Click);
            // 
            // popupTextBox1
            // 
            this.popupTextBox1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.popupTextBox1.CaptionLabel = this.label1;
            this.popupTextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.popupTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lICANBindingSource, "NOBR", true));
            this.popupTextBox1.DataSource = this.vBASEBindingSource;
            this.popupTextBox1.DisplayMember = "name_c";
            this.popupTextBox1.IsEmpty = false;
            this.popupTextBox1.IsEmptyToQuery = true;
            this.popupTextBox1.IsMustBeFound = true;
            this.popupTextBox1.LabelText = "";
            this.popupTextBox1.Location = new System.Drawing.Point(119, 7);
            this.popupTextBox1.Name = "popupTextBox1";
            this.popupTextBox1.QueryFields = "name_e,name_p,idno";
            this.popupTextBox1.ReadOnly = false;
            this.popupTextBox1.ShowDisplayName = true;
            this.popupTextBox1.Size = new System.Drawing.Size(100, 22);
            this.popupTextBox1.TabIndex = 0;
            this.popupTextBox1.ValueMember = "nobr";
            this.popupTextBox1.WhereCmd = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(60, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "員工編號";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.CaptionLabel = null;
            this.checkBox2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.lICANBindingSource, "OWNER", true));
            this.checkBox2.IsImitateCaption = true;
            this.checkBox2.Location = new System.Drawing.Point(490, 61);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(84, 16);
            this.checkBox2.TabIndex = 31;
            this.checkBox2.TabStop = false;
            this.checkBox2.Text = "本公司擁有";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.CaptionLabel = null;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.lICANBindingSource, "LIC_PASS", true));
            this.checkBox1.IsImitateCaption = true;
            this.checkBox1.Location = new System.Drawing.Point(490, 36);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 30;
            this.checkBox1.TabStop = false;
            this.checkBox1.Text = "國家考試";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox6
            // 
            this.textBox6.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox6.CaptionLabel = this.label7;
            this.textBox6.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox6.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lICANBindingSource, "LIC_NOTE", true));
            this.textBox6.DecimalPlace = 2;
            this.textBox6.IsEmpty = true;
            this.textBox6.Location = new System.Drawing.Point(118, 130);
            this.textBox6.Mask = "";
            this.textBox6.MaxLength = 60;
            this.textBox6.Name = "textBox6";
            this.textBox6.PasswordChar = '\0';
            this.textBox6.ReadOnly = false;
            this.textBox6.ShowCalendarButton = true;
            this.textBox6.Size = new System.Drawing.Size(322, 22);
            this.textBox6.TabIndex = 6;
            this.textBox6.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(71, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 28;
            this.label7.Text = "備註欄";
            // 
            // textBox5
            // 
            this.textBox5.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox5.CaptionLabel = this.label6;
            this.textBox5.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox5.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lICANBindingSource, "LIC_NO", true));
            this.textBox5.DecimalPlace = 2;
            this.textBox5.IsEmpty = true;
            this.textBox5.Location = new System.Drawing.Point(118, 105);
            this.textBox5.Mask = "";
            this.textBox5.MaxLength = 50;
            this.textBox5.Name = "textBox5";
            this.textBox5.PasswordChar = '\0';
            this.textBox5.ReadOnly = false;
            this.textBox5.ShowCalendarButton = true;
            this.textBox5.Size = new System.Drawing.Size(225, 22);
            this.textBox5.TabIndex = 5;
            this.textBox5.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(59, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 26;
            this.label6.Text = "證照編號";
            // 
            // textBox4
            // 
            this.textBox4.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox4.CaptionLabel = this.label5;
            this.textBox4.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lICANBindingSource, "EDATE", true));
            this.textBox4.DecimalPlace = 2;
            this.textBox4.IsEmpty = true;
            this.textBox4.Location = new System.Drawing.Point(281, 81);
            this.textBox4.Mask = "0000/00/00";
            this.textBox4.MaxLength = -1;
            this.textBox4.Name = "textBox4";
            this.textBox4.PasswordChar = '\0';
            this.textBox4.ReadOnly = false;
            this.textBox4.ShowCalendarButton = true;
            this.textBox4.Size = new System.Drawing.Size(100, 22);
            this.textBox4.TabIndex = 4;
            this.textBox4.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(222, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 24;
            this.label5.Text = "有效日期";
            // 
            // textBox3
            // 
            this.textBox3.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox3.CaptionLabel = this.label4;
            this.textBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lICANBindingSource, "MDATE", true));
            this.textBox3.DecimalPlace = 2;
            this.textBox3.IsEmpty = true;
            this.textBox3.Location = new System.Drawing.Point(118, 81);
            this.textBox3.Mask = "0000/00/00";
            this.textBox3.MaxLength = -1;
            this.textBox3.Name = "textBox3";
            this.textBox3.PasswordChar = '\0';
            this.textBox3.ReadOnly = false;
            this.textBox3.ShowCalendarButton = true;
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 3;
            this.textBox3.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(59, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 22;
            this.label4.Text = "生效日期";
            // 
            // textBox2
            // 
            this.textBox2.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox2.CaptionLabel = this.label3;
            this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lICANBindingSource, "COMP", true));
            this.textBox2.DecimalPlace = 2;
            this.textBox2.IsEmpty = false;
            this.textBox2.Location = new System.Drawing.Point(118, 57);
            this.textBox2.Mask = "";
            this.textBox2.MaxLength = 50;
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '\0';
            this.textBox2.ReadOnly = false;
            this.textBox2.ShowCalendarButton = true;
            this.textBox2.Size = new System.Drawing.Size(322, 22);
            this.textBox2.TabIndex = 2;
            this.textBox2.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(59, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "發照單位";
            // 
            // textBox1
            // 
            this.textBox1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox1.CaptionLabel = this.label2;
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lICANBindingSource, "DESCS", true));
            this.textBox1.DecimalPlace = 2;
            this.textBox1.IsEmpty = false;
            this.textBox1.Location = new System.Drawing.Point(119, 32);
            this.textBox1.Mask = "";
            this.textBox1.MaxLength = 50;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.ReadOnly = false;
            this.textBox1.ShowCalendarButton = true;
            this.textBox1.Size = new System.Drawing.Size(321, 22);
            this.textBox1.TabIndex = 1;
            this.textBox1.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(60, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 18;
            this.label2.Text = "證照內容";
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
            this.fullDataCtrl1.DataGrid = this.dataGridView1;
            this.fullDataCtrl1.DataSource = this.lICANBindingSource;
            this.fullDataCtrl1.DeleteType = JBControls.FullDataCtrl.EDeleteType.Delete;
            this.fullDataCtrl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.fullDataCtrl1.EnableAutoClone = false;
            this.fullDataCtrl1.GroupCmd = "";
            this.fullDataCtrl1.Location = new System.Drawing.Point(0, 0);
            this.fullDataCtrl1.Name = "fullDataCtrl1";
            this.fullDataCtrl1.QueryFields = "nobr,descs,mdate,edate";
            this.fullDataCtrl1.RecentQuerySql = "";
            this.fullDataCtrl1.SelectCmd = "";
            this.fullDataCtrl1.ShowExceptionMsg = true;
            this.fullDataCtrl1.Size = new System.Drawing.Size(626, 73);
            this.fullDataCtrl1.SortFields = "nobr,descs,mdate,edate";
            this.fullDataCtrl1.TabIndex = 10;
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
            this.errorProvider1.DataSource = this.lICANBindingSource;
            // 
            // lICANTableAdapter
            // 
            this.lICANTableAdapter.ClearBeforeFill = true;
            // 
            // v_BASETableAdapter
            // 
            this.v_BASETableAdapter.ClearBeforeFill = true;
            // 
            // FRM1F
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 441);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "FRM1F";
            this.Text = "FRM1F";
            this.Load += new System.EventHandler(this.FRM1F_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vBASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.basDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lICANBindingSource)).EndInit();
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
		private JBControls.FullDataCtrl fullDataCtrl1;
		private JBControls.DataGridView dataGridView1;
        private BasDS basDS;
        private System.Windows.Forms.BindingSource lICANBindingSource;
		private JBHR.Bas.BasDSTableAdapters.LICANTableAdapter lICANTableAdapter;
		private System.Windows.Forms.Panel panel1;
		private JBControls.CheckBox checkBox2;
		private JBControls.CheckBox checkBox1;
		private JBControls.TextBox textBox6;
		private System.Windows.Forms.Label label7;
		private JBControls.TextBox textBox5;
		private System.Windows.Forms.Label label6;
		private JBControls.TextBox textBox4;
		private System.Windows.Forms.Label label5;
		private JBControls.TextBox textBox3;
		private System.Windows.Forms.Label label4;
		private JBControls.TextBox textBox2;
		private System.Windows.Forms.Label label3;
		private JBControls.TextBox textBox1;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.BindingSource vBASEBindingSource;
        private JBHR.Bas.BasDSTableAdapters.V_BASETableAdapter v_BASETableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOBR;
        private System.Windows.Forms.DataGridViewComboBoxColumn nOBRDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEPT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn JOB_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn dESCSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOMPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lICNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lICPASSDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn oWNERDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lICNOTEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYMANDataGridViewTextBoxColumn;
        private JBControls.PopupTextBox popupTextBox1;
        private System.Windows.Forms.Button bnIMPORT;
    }
}