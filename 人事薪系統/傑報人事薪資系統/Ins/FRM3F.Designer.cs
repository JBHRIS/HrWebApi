namespace JBHR.Ins
{
    partial class FRM3F
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new JBControls.DataGridView();
            this.yYMMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iNSURTYPEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nOBRDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOBR = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.vBASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.insDS = new JBHR.Ins.InsDS();
            this.fAIDNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eXPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOMPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iNPOLABBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.popupTextBox1 = new JBControls.PopupTextBox();
            this.popupTextBox2 = new JBControls.PopupTextBox();
            this.fAMILY1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.basDS = new JBHR.Bas.BasDS();
            this.textBox3 = new JBControls.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new JBControls.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new JBControls.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbINSUR_TYPE = new System.Windows.Forms.ComboBox();
            this.fullDataCtrl1 = new JBControls.FullDataCtrl();
            this.fAMILYBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iNSURTYPEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iNPOLABTableAdapter = new JBHR.Ins.InsDSTableAdapters.INPOLABTableAdapter();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.iNSUR_TYPETableAdapter = new JBHR.Ins.InsDSTableAdapters.INSUR_TYPETableAdapter();
            this.fAMILYTableAdapter = new JBHR.Bas.BasDSTableAdapters.FAMILYTableAdapter();
            this.v_BASETableAdapter = new JBHR.Ins.InsDSTableAdapters.V_BASETableAdapter();
            this.fAMILY1TableAdapter = new JBHR.Bas.BasDSTableAdapters.FAMILY1TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vBASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.insDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNPOLABBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fAMILY1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.basDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fAMILYBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNSURTYPEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.splitContainer1.Size = new System.Drawing.Size(626, 440);
            this.splitContainer1.SplitterDistance = 270;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.yYMMDataGridViewTextBoxColumn,
            this.iNSURTYPEDataGridViewTextBoxColumn,
            this.nOBRDataGridViewTextBoxColumn,
            this.NOBR,
            this.fAIDNODataGridViewTextBoxColumn,
            this.eXPDataGridViewTextBoxColumn,
            this.cOMPDataGridViewTextBoxColumn,
            this.kEYDATEDataGridViewTextBoxColumn,
            this.kEYMANDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.iNPOLABBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(626, 270);
            this.dataGridView1.TabIndex = 0;
            // 
            // yYMMDataGridViewTextBoxColumn
            // 
            this.yYMMDataGridViewTextBoxColumn.DataPropertyName = "YYMM";
            this.yYMMDataGridViewTextBoxColumn.HeaderText = "扣款年月";
            this.yYMMDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.yYMMDataGridViewTextBoxColumn.Name = "yYMMDataGridViewTextBoxColumn";
            this.yYMMDataGridViewTextBoxColumn.ReadOnly = true;
            this.yYMMDataGridViewTextBoxColumn.Width = 150;
            // 
            // iNSURTYPEDataGridViewTextBoxColumn
            // 
            this.iNSURTYPEDataGridViewTextBoxColumn.DataPropertyName = "INSUR_TYPE";
            this.iNSURTYPEDataGridViewTextBoxColumn.HeaderText = "費用種類";
            this.iNSURTYPEDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.iNSURTYPEDataGridViewTextBoxColumn.Name = "iNSURTYPEDataGridViewTextBoxColumn";
            this.iNSURTYPEDataGridViewTextBoxColumn.ReadOnly = true;
            this.iNSURTYPEDataGridViewTextBoxColumn.Width = 150;
            // 
            // nOBRDataGridViewTextBoxColumn
            // 
            this.nOBRDataGridViewTextBoxColumn.DataPropertyName = "NOBR";
            this.nOBRDataGridViewTextBoxColumn.HeaderText = "員工編號";
            this.nOBRDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.nOBRDataGridViewTextBoxColumn.Name = "nOBRDataGridViewTextBoxColumn";
            this.nOBRDataGridViewTextBoxColumn.ReadOnly = true;
            this.nOBRDataGridViewTextBoxColumn.Width = 150;
            // 
            // NOBR
            // 
            this.NOBR.DataPropertyName = "NOBR";
            this.NOBR.DataSource = this.vBASEBindingSource;
            this.NOBR.DisplayMember = "NAME_C";
            this.NOBR.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.NOBR.HeaderText = "員工姓名";
            this.NOBR.MinimumWidth = 8;
            this.NOBR.Name = "NOBR";
            this.NOBR.ReadOnly = true;
            this.NOBR.ValueMember = "NOBR";
            this.NOBR.Width = 150;
            // 
            // vBASEBindingSource
            // 
            this.vBASEBindingSource.DataMember = "V_BASE";
            this.vBASEBindingSource.DataSource = this.insDS;
            // 
            // insDS
            // 
            this.insDS.DataSetName = "InsDS";
            this.insDS.Locale = new System.Globalization.CultureInfo("");
            this.insDS.RemotingFormat = System.Data.SerializationFormat.Binary;
            this.insDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fAIDNODataGridViewTextBoxColumn
            // 
            this.fAIDNODataGridViewTextBoxColumn.DataPropertyName = "FA_IDNO";
            this.fAIDNODataGridViewTextBoxColumn.HeaderText = "身分證號";
            this.fAIDNODataGridViewTextBoxColumn.MinimumWidth = 8;
            this.fAIDNODataGridViewTextBoxColumn.Name = "fAIDNODataGridViewTextBoxColumn";
            this.fAIDNODataGridViewTextBoxColumn.ReadOnly = true;
            this.fAIDNODataGridViewTextBoxColumn.Width = 150;
            // 
            // eXPDataGridViewTextBoxColumn
            // 
            this.eXPDataGridViewTextBoxColumn.DataPropertyName = "EXP";
            this.eXPDataGridViewTextBoxColumn.HeaderText = "扣款費用";
            this.eXPDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.eXPDataGridViewTextBoxColumn.Name = "eXPDataGridViewTextBoxColumn";
            this.eXPDataGridViewTextBoxColumn.ReadOnly = true;
            this.eXPDataGridViewTextBoxColumn.Width = 150;
            // 
            // cOMPDataGridViewTextBoxColumn
            // 
            this.cOMPDataGridViewTextBoxColumn.DataPropertyName = "COMP";
            this.cOMPDataGridViewTextBoxColumn.HeaderText = "公司負擔";
            this.cOMPDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.cOMPDataGridViewTextBoxColumn.Name = "cOMPDataGridViewTextBoxColumn";
            this.cOMPDataGridViewTextBoxColumn.ReadOnly = true;
            this.cOMPDataGridViewTextBoxColumn.Width = 150;
            // 
            // kEYDATEDataGridViewTextBoxColumn
            // 
            this.kEYDATEDataGridViewTextBoxColumn.DataPropertyName = "KEY_DATE";
            this.kEYDATEDataGridViewTextBoxColumn.HeaderText = "登錄日期";
            this.kEYDATEDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.kEYDATEDataGridViewTextBoxColumn.Name = "kEYDATEDataGridViewTextBoxColumn";
            this.kEYDATEDataGridViewTextBoxColumn.ReadOnly = true;
            this.kEYDATEDataGridViewTextBoxColumn.Width = 150;
            // 
            // kEYMANDataGridViewTextBoxColumn
            // 
            this.kEYMANDataGridViewTextBoxColumn.DataPropertyName = "KEY_MAN";
            this.kEYMANDataGridViewTextBoxColumn.HeaderText = "登錄者";
            this.kEYMANDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.kEYMANDataGridViewTextBoxColumn.Name = "kEYMANDataGridViewTextBoxColumn";
            this.kEYMANDataGridViewTextBoxColumn.ReadOnly = true;
            this.kEYMANDataGridViewTextBoxColumn.Width = 150;
            // 
            // iNPOLABBindingSource
            // 
            this.iNPOLABBindingSource.DataMember = "INPOLAB";
            this.iNPOLABBindingSource.DataSource = this.insDS;
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
            this.splitContainer2.Size = new System.Drawing.Size(626, 166);
            this.splitContainer2.SplitterDistance = 88;
            this.splitContainer2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.buttonDelete);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 88);
            this.panel1.TabIndex = 0;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(543, 25);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.TabStop = false;
            this.buttonDelete.Text = "大量刪除";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(543, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 22);
            this.button1.TabIndex = 1;
            this.button1.TabStop = false;
            this.button1.Text = "匯入";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.popupTextBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.popupTextBox2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox3, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox2, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbINSUR_TYPE, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(456, 84);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "員工編號";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(3, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "身分證號";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(3, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "費用種類";
            // 
            // popupTextBox1
            // 
            this.popupTextBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.popupTextBox1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.popupTextBox1.CaptionLabel = this.label1;
            this.popupTextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.popupTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iNPOLABBindingSource, "NOBR", true));
            this.popupTextBox1.DataSource = this.vBASEBindingSource;
            this.popupTextBox1.DisplayMember = "name_c";
            this.popupTextBox1.IsEmpty = false;
            this.popupTextBox1.IsEmptyToQuery = true;
            this.popupTextBox1.IsMustBeFound = true;
            this.popupTextBox1.LabelText = "";
            this.popupTextBox1.Location = new System.Drawing.Point(62, 3);
            this.popupTextBox1.Name = "popupTextBox1";
            this.popupTextBox1.QueryFields = "name_e,name_p";
            this.popupTextBox1.ReadOnly = false;
            this.popupTextBox1.ShowDisplayName = true;
            this.popupTextBox1.Size = new System.Drawing.Size(100, 22);
            this.popupTextBox1.TabIndex = 0;
            this.popupTextBox1.ValueMember = "nobr";
            this.popupTextBox1.WhereCmd = "";
            // 
            // popupTextBox2
            // 
            this.popupTextBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.popupTextBox2.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.popupTextBox2.CaptionLabel = this.label2;
            this.popupTextBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.popupTextBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iNPOLABBindingSource, "FA_IDNO", true));
            this.popupTextBox2.DataSource = this.fAMILY1BindingSource;
            this.popupTextBox2.DisplayMember = "name_c";
            this.popupTextBox2.IsEmpty = false;
            this.popupTextBox2.IsEmptyToQuery = true;
            this.popupTextBox2.IsMustBeFound = true;
            this.popupTextBox2.LabelText = "";
            this.popupTextBox2.Location = new System.Drawing.Point(62, 31);
            this.popupTextBox2.Name = "popupTextBox2";
            this.popupTextBox2.ReadOnly = false;
            this.popupTextBox2.ShowDisplayName = true;
            this.popupTextBox2.Size = new System.Drawing.Size(100, 22);
            this.popupTextBox2.TabIndex = 1;
            this.popupTextBox2.ValueMember = "idno";
            this.popupTextBox2.WhereCmd = "";
            this.popupTextBox2.Leave += new System.EventHandler(this.popupTextBox2_Leave);
            // 
            // fAMILY1BindingSource
            // 
            this.fAMILY1BindingSource.DataMember = "FAMILY1";
            this.fAMILY1BindingSource.DataSource = this.basDS;
            // 
            // basDS
            // 
            this.basDS.DataSetName = "BasDS";
            this.basDS.Locale = new System.Globalization.CultureInfo("");
            this.basDS.RemotingFormat = System.Data.SerializationFormat.Binary;
            this.basDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox3.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox3.CaptionLabel = this.label6;
            this.textBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iNPOLABBindingSource, "COMP", true));
            this.textBox3.DecimalPlace = 2;
            this.textBox3.IsEmpty = false;
            this.textBox3.Location = new System.Drawing.Point(240, 59);
            this.textBox3.Mask = "";
            this.textBox3.MaxLength = -1;
            this.textBox3.Name = "textBox3";
            this.textBox3.PasswordChar = '\0';
            this.textBox3.ReadOnly = false;
            this.textBox3.ShowCalendarButton = true;
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 5;
            this.textBox3.ValidType = JBControls.TextBox.EValidType.Decimal;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(181, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "公司負擔";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox2.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox2.CaptionLabel = this.label5;
            this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iNPOLABBindingSource, "EXP", true));
            this.textBox2.DecimalPlace = 2;
            this.textBox2.IsEmpty = false;
            this.textBox2.Location = new System.Drawing.Point(240, 31);
            this.textBox2.Mask = "";
            this.textBox2.MaxLength = -1;
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '\0';
            this.textBox2.ReadOnly = false;
            this.textBox2.ShowCalendarButton = true;
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 4;
            this.textBox2.ValidType = JBControls.TextBox.EValidType.Decimal;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(181, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "扣款費用";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox1.CaptionLabel = this.label4;
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iNPOLABBindingSource, "YYMM", true));
            this.textBox1.DecimalPlace = 2;
            this.textBox1.IsEmpty = false;
            this.textBox1.Location = new System.Drawing.Point(240, 3);
            this.textBox1.Mask = "";
            this.textBox1.MaxLength = 50;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.ReadOnly = false;
            this.textBox1.ShowCalendarButton = true;
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 3;
            this.textBox1.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(181, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "扣款年月";
            // 
            // cbINSUR_TYPE
            // 
            this.cbINSUR_TYPE.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.iNPOLABBindingSource, "INSUR_TYPE", true));
            this.cbINSUR_TYPE.FormattingEnabled = true;
            this.cbINSUR_TYPE.Location = new System.Drawing.Point(62, 59);
            this.cbINSUR_TYPE.Name = "cbINSUR_TYPE";
            this.cbINSUR_TYPE.Size = new System.Drawing.Size(113, 20);
            this.cbINSUR_TYPE.TabIndex = 2;
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
            this.fullDataCtrl1.DataSource = this.iNPOLABBindingSource;
            this.fullDataCtrl1.DeleteType = JBControls.FullDataCtrl.EDeleteType.Delete;
            this.fullDataCtrl1.EnableAutoClone = false;
            this.fullDataCtrl1.GroupCmd = "";
            this.fullDataCtrl1.Location = new System.Drawing.Point(-2, 2);
            this.fullDataCtrl1.Name = "fullDataCtrl1";
            this.fullDataCtrl1.QueryFields = "nobr,fa_idno,yymm,insur_type";
            this.fullDataCtrl1.RecentQuerySql = "";
            this.fullDataCtrl1.SelectCmd = "";
            this.fullDataCtrl1.ShowExceptionMsg = true;
            this.fullDataCtrl1.Size = new System.Drawing.Size(635, 73);
            this.fullDataCtrl1.SortFields = "nobr";
            this.fullDataCtrl1.TabIndex = 0;
            this.fullDataCtrl1.WhereCmd = "";
            this.fullDataCtrl1.BeforeDel += new JBControls.FullDataCtrl.BeforeEventHandler(this.fullDataCtrl1_BeforeDel);
            this.fullDataCtrl1.AfterDel += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterDel);
            this.fullDataCtrl1.BeforeSave += new JBControls.FullDataCtrl.BeforeEventHandler(this.fullDataCtrl1_BeforeSave);
            this.fullDataCtrl1.AfterSave += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterSave);
            this.fullDataCtrl1.AfterExport += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterExport);
            // 
            // fAMILYBindingSource
            // 
            this.fAMILYBindingSource.DataMember = "FAMILY";
            this.fAMILYBindingSource.DataSource = this.basDS;
            // 
            // iNSURTYPEBindingSource
            // 
            this.iNSURTYPEBindingSource.DataMember = "INSUR_TYPE";
            this.iNSURTYPEBindingSource.DataSource = this.insDS;
            // 
            // iNPOLABTableAdapter
            // 
            this.iNPOLABTableAdapter.ClearBeforeFill = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.DataSource = this.iNPOLABBindingSource;
            // 
            // iNSUR_TYPETableAdapter
            // 
            this.iNSUR_TYPETableAdapter.ClearBeforeFill = true;
            // 
            // fAMILYTableAdapter
            // 
            this.fAMILYTableAdapter.ClearBeforeFill = true;
            // 
            // v_BASETableAdapter
            // 
            this.v_BASETableAdapter.ClearBeforeFill = true;
            // 
            // fAMILY1TableAdapter
            // 
            this.fAMILY1TableAdapter.ClearBeforeFill = true;
            // 
            // FRM3F
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 440);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "FRM3F";
            this.Text = "FRM3F";
            this.Load += new System.EventHandler(this.FRM3F_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vBASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.insDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNPOLABBindingSource)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fAMILY1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.basDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fAMILYBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNSURTYPEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private JBControls.DataGridView dataGridView1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel1;
        private JBControls.FullDataCtrl fullDataCtrl1;
        private InsDS insDS;
        private System.Windows.Forms.BindingSource iNPOLABBindingSource;
		private JBHR.Ins.InsDSTableAdapters.INPOLABTableAdapter iNPOLABTableAdapter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private JBControls.PopupTextBox popupTextBox1;
        private JBControls.PopupTextBox popupTextBox2;
        private JBControls.TextBox textBox1;
        private JBControls.TextBox textBox2;
        private JBControls.TextBox textBox3;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private System.Windows.Forms.Button button1;
        private JBHR.Bas.BasDS basDS;
        private System.Windows.Forms.BindingSource iNSURTYPEBindingSource;
        private JBHR.Ins.InsDSTableAdapters.INSUR_TYPETableAdapter iNSUR_TYPETableAdapter;
        private System.Windows.Forms.BindingSource fAMILYBindingSource;
        private JBHR.Bas.BasDSTableAdapters.FAMILYTableAdapter fAMILYTableAdapter;
        private System.Windows.Forms.BindingSource vBASEBindingSource;
        private JBHR.Ins.InsDSTableAdapters.V_BASETableAdapter v_BASETableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn yYMMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iNSURTYPEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOBRDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn NOBR;
        private System.Windows.Forms.DataGridViewTextBoxColumn fAIDNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eXPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOMPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYMANDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox cbINSUR_TYPE;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.BindingSource fAMILY1BindingSource;
        private Bas.BasDSTableAdapters.FAMILY1TableAdapter fAMILY1TableAdapter;
    }
}