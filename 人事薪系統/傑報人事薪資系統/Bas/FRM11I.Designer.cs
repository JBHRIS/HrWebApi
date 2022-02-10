namespace JBHR.Bas
{
	partial class FRM11I
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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewEx1 = new JBControls.DataGridView();
            this.D_NO_DISP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D_ENAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dEPTGROUPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dEPTABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.basDS = new JBHR.Bas.BasDS();
            this.DEPT_TREE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOBR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MANGEMAIL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EMAIL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ADATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DDATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbxDeptLevel = new System.Windows.Forms.ComboBox();
            this.cbDEPT_GROUP = new System.Windows.Forms.ComboBox();
            this.txtMangMail = new JBControls.TextBox();
            this.textBox5 = new JBControls.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.popupTextBox2 = new JBControls.PopupTextBox();
            this.vBASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBox3 = new JBControls.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new JBControls.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDNO = new JBControls.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDeptGroup = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDdate = new JBControls.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAdate = new JBControls.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnMang = new System.Windows.Forms.Button();
            this.btnCodeGroup = new System.Windows.Forms.Button();
            this.fullDataCtrl1 = new JBControls.FullDataCtrl();
            this.dEPTABindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.basDS1 = new JBHR.Bas.BasDS();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dEPTATableAdapter = new JBHR.Bas.BasDSTableAdapters.DEPTATableAdapter();
            this.v_BASETableAdapter = new JBHR.Bas.BasDSTableAdapters.V_BASETableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEPTABindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.basDS)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vBASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEPTABindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.basDS1)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnMang);
            this.splitContainer1.Panel2.Controls.Add(this.btnCodeGroup);
            this.splitContainer1.Panel2.Controls.Add(this.fullDataCtrl1);
            this.splitContainer1.Size = new System.Drawing.Size(784, 561);
            this.splitContainer1.SplitterDistance = 484;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(784, 484);
            this.splitContainer2.SplitterDistance = 205;
            this.splitContainer2.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.HideSelection = false;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(205, 484);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.dataGridViewEx1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.panel1);
            this.splitContainer3.Size = new System.Drawing.Size(575, 484);
            this.splitContainer3.SplitterDistance = 288;
            this.splitContainer3.TabIndex = 0;
            // 
            // dataGridViewEx1
            // 
            this.dataGridViewEx1.AllowUserToAddRows = false;
            this.dataGridViewEx1.AllowUserToDeleteRows = false;
            this.dataGridViewEx1.AllowUserToResizeRows = false;
            this.dataGridViewEx1.AutoGenerateColumns = false;
            this.dataGridViewEx1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("細明體", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewEx1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewEx1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.D_NO_DISP,
            this.dNAMEDataGridViewTextBoxColumn,
            this.D_ENAME,
            this.dEPTGROUPDataGridViewTextBoxColumn,
            this.DEPT_TREE,
            this.NOBR,
            this.MANGEMAIL,
            this.EMAIL,
            this.ADATE,
            this.DDATE,
            this.kEYDATEDataGridViewTextBoxColumn,
            this.kEYMANDataGridViewTextBoxColumn});
            this.dataGridViewEx1.DataSource = this.dEPTABindingSource;
            this.dataGridViewEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEx1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewEx1.MultiSelect = false;
            this.dataGridViewEx1.Name = "dataGridViewEx1";
            this.dataGridViewEx1.RowHeadersVisible = false;
            this.dataGridViewEx1.RowTemplate.Height = 24;
            this.dataGridViewEx1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEx1.Size = new System.Drawing.Size(575, 288);
            this.dataGridViewEx1.TabIndex = 8;
            // 
            // D_NO_DISP
            // 
            this.D_NO_DISP.DataPropertyName = "D_NO_DISP";
            this.D_NO_DISP.HeaderText = "簽核部門代碼";
            this.D_NO_DISP.Name = "D_NO_DISP";
            this.D_NO_DISP.Width = 102;
            // 
            // dNAMEDataGridViewTextBoxColumn
            // 
            this.dNAMEDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dNAMEDataGridViewTextBoxColumn.DataPropertyName = "D_NAME";
            this.dNAMEDataGridViewTextBoxColumn.HeaderText = "部門名稱";
            this.dNAMEDataGridViewTextBoxColumn.Name = "dNAMEDataGridViewTextBoxColumn";
            this.dNAMEDataGridViewTextBoxColumn.Width = 150;
            // 
            // D_ENAME
            // 
            this.D_ENAME.DataPropertyName = "D_ENAME";
            this.D_ENAME.HeaderText = "英文名稱";
            this.D_ENAME.Name = "D_ENAME";
            this.D_ENAME.Width = 78;
            // 
            // dEPTGROUPDataGridViewTextBoxColumn
            // 
            this.dEPTGROUPDataGridViewTextBoxColumn.DataPropertyName = "DEPT_GROUP";
            this.dEPTGROUPDataGridViewTextBoxColumn.DataSource = this.dEPTABindingSource;
            this.dEPTGROUPDataGridViewTextBoxColumn.DisplayMember = "D_NO_DISP";
            this.dEPTGROUPDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dEPTGROUPDataGridViewTextBoxColumn.HeaderText = "部門群組代碼";
            this.dEPTGROUPDataGridViewTextBoxColumn.Name = "dEPTGROUPDataGridViewTextBoxColumn";
            this.dEPTGROUPDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dEPTGROUPDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dEPTGROUPDataGridViewTextBoxColumn.ValueMember = "D_NO";
            this.dEPTGROUPDataGridViewTextBoxColumn.Width = 102;
            // 
            // dEPTABindingSource
            // 
            this.dEPTABindingSource.DataMember = "DEPTA";
            this.dEPTABindingSource.DataSource = this.basDS;
            // 
            // basDS
            // 
            this.basDS.DataSetName = "BasDS";
            this.basDS.Locale = new System.Globalization.CultureInfo("");
            this.basDS.RemotingFormat = System.Data.SerializationFormat.Binary;
            this.basDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DEPT_TREE
            // 
            this.DEPT_TREE.DataPropertyName = "DEPT_TREE";
            this.DEPT_TREE.HeaderText = "部門層級";
            this.DEPT_TREE.Name = "DEPT_TREE";
            this.DEPT_TREE.Width = 78;
            // 
            // NOBR
            // 
            this.NOBR.DataPropertyName = "NOBR";
            this.NOBR.HeaderText = "部門主管";
            this.NOBR.Name = "NOBR";
            this.NOBR.Width = 78;
            // 
            // MANGEMAIL
            // 
            this.MANGEMAIL.DataPropertyName = "MANGEMAIL";
            this.MANGEMAIL.HeaderText = "主管信箱";
            this.MANGEMAIL.Name = "MANGEMAIL";
            this.MANGEMAIL.Width = 78;
            // 
            // EMAIL
            // 
            this.EMAIL.DataPropertyName = "EMAIL";
            this.EMAIL.HeaderText = "異常通知信箱";
            this.EMAIL.Name = "EMAIL";
            this.EMAIL.Width = 102;
            // 
            // ADATE
            // 
            this.ADATE.DataPropertyName = "ADATE";
            this.ADATE.HeaderText = "生效日期";
            this.ADATE.Name = "ADATE";
            this.ADATE.Width = 78;
            // 
            // DDATE
            // 
            this.DDATE.DataPropertyName = "DDATE";
            this.DDATE.HeaderText = "失效日期";
            this.DDATE.Name = "DDATE";
            this.DDATE.Width = 78;
            // 
            // kEYDATEDataGridViewTextBoxColumn
            // 
            this.kEYDATEDataGridViewTextBoxColumn.DataPropertyName = "KEY_DATE";
            this.kEYDATEDataGridViewTextBoxColumn.HeaderText = "登錄日期";
            this.kEYDATEDataGridViewTextBoxColumn.Name = "kEYDATEDataGridViewTextBoxColumn";
            this.kEYDATEDataGridViewTextBoxColumn.Width = 78;
            // 
            // kEYMANDataGridViewTextBoxColumn
            // 
            this.kEYMANDataGridViewTextBoxColumn.DataPropertyName = "KEY_MAN";
            this.kEYMANDataGridViewTextBoxColumn.HeaderText = "登錄者";
            this.kEYMANDataGridViewTextBoxColumn.Name = "kEYMANDataGridViewTextBoxColumn";
            this.kEYMANDataGridViewTextBoxColumn.Width = 66;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(575, 192);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Controls.Add(this.txtDNO, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbDeptGroup, 5, 5);
            this.tableLayoutPanel1.Controls.Add(this.cbxDeptLevel, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.label11, 4, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtDdate, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label9, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtAdate, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.cbDEPT_GROUP, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBox2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox5, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label3, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox3, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.popupTextBox2, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtMangMail, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.label8, 3, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(571, 188);
            this.tableLayoutPanel1.TabIndex = 28;
            // 
            // cbxDeptLevel
            // 
            this.cbxDeptLevel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.cbxDeptLevel, 2);
            this.cbxDeptLevel.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dEPTABindingSource, "DEPT_TREE", true));
            this.cbxDeptLevel.DropDownWidth = 150;
            this.cbxDeptLevel.FormattingEnabled = true;
            this.cbxDeptLevel.Location = new System.Drawing.Point(383, 67);
            this.cbxDeptLevel.Name = "cbxDeptLevel";
            this.cbxDeptLevel.Size = new System.Drawing.Size(185, 20);
            this.cbxDeptLevel.TabIndex = 4;
            // 
            // cbDEPT_GROUP
            // 
            this.cbDEPT_GROUP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.cbDEPT_GROUP, 2);
            this.cbDEPT_GROUP.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dEPTABindingSource, "DEPT_GROUP", true));
            this.cbDEPT_GROUP.DropDownWidth = 150;
            this.cbDEPT_GROUP.FormattingEnabled = true;
            this.cbDEPT_GROUP.Location = new System.Drawing.Point(98, 67);
            this.cbDEPT_GROUP.Name = "cbDEPT_GROUP";
            this.cbDEPT_GROUP.Size = new System.Drawing.Size(184, 20);
            this.cbDEPT_GROUP.TabIndex = 3;
            // 
            // txtMangMail
            // 
            this.txtMangMail.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtMangMail.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtMangMail.CaptionLabel = null;
            this.txtMangMail.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tableLayoutPanel1.SetColumnSpan(this.txtMangMail, 2);
            this.txtMangMail.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dEPTABindingSource, "MANGEMAIL", true));
            this.txtMangMail.DecimalPlace = 2;
            this.txtMangMail.IsEmpty = true;
            this.txtMangMail.Location = new System.Drawing.Point(383, 97);
            this.txtMangMail.Mask = "";
            this.txtMangMail.MaxLength = 50;
            this.txtMangMail.Name = "txtMangMail";
            this.txtMangMail.PasswordChar = '\0';
            this.txtMangMail.ReadOnly = false;
            this.txtMangMail.ShowCalendarButton = true;
            this.txtMangMail.Size = new System.Drawing.Size(184, 22);
            this.txtMangMail.TabIndex = 6;
            this.txtMangMail.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // textBox5
            // 
            this.textBox5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox5.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox5.CaptionLabel = this.label7;
            this.textBox5.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tableLayoutPanel1.SetColumnSpan(this.textBox5, 5);
            this.textBox5.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dEPTABindingSource, "EMAIL", true));
            this.textBox5.DecimalPlace = 2;
            this.textBox5.IsEmpty = true;
            this.textBox5.Location = new System.Drawing.Point(98, 128);
            this.textBox5.Mask = "";
            this.textBox5.MaxLength = 500;
            this.textBox5.Name = "textBox5";
            this.textBox5.PasswordChar = '\0';
            this.textBox5.ReadOnly = false;
            this.textBox5.ShowCalendarButton = true;
            this.textBox5.Size = new System.Drawing.Size(467, 22);
            this.textBox5.TabIndex = 7;
            this.textBox5.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(15, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "異常通知信箱";
            // 
            // popupTextBox2
            // 
            this.popupTextBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.popupTextBox2.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.popupTextBox2.CaptionLabel = null;
            this.popupTextBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tableLayoutPanel1.SetColumnSpan(this.popupTextBox2, 2);
            this.popupTextBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dEPTABindingSource, "NOBR", true));
            this.popupTextBox2.DataSource = this.vBASEBindingSource;
            this.popupTextBox2.DisplayMember = "name_c";
            this.popupTextBox2.IsEmpty = true;
            this.popupTextBox2.IsEmptyToQuery = true;
            this.popupTextBox2.IsMustBeFound = true;
            this.popupTextBox2.LabelText = "";
            this.popupTextBox2.Location = new System.Drawing.Point(98, 97);
            this.popupTextBox2.Name = "popupTextBox2";
            this.popupTextBox2.ReadOnly = false;
            this.popupTextBox2.ShowDisplayName = true;
            this.popupTextBox2.Size = new System.Drawing.Size(89, 22);
            this.popupTextBox2.TabIndex = 5;
            this.popupTextBox2.ValueMember = "nobr";
            this.popupTextBox2.WhereCmd = "";
            // 
            // vBASEBindingSource
            // 
            this.vBASEBindingSource.DataMember = "V_BASE";
            this.vBASEBindingSource.DataSource = this.basDS;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox3.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox3.CaptionLabel = this.label3;
            this.textBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tableLayoutPanel1.SetColumnSpan(this.textBox3, 2);
            this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dEPTABindingSource, "D_ENAME", true));
            this.textBox3.DecimalPlace = 2;
            this.textBox3.IsEmpty = true;
            this.textBox3.Location = new System.Drawing.Point(383, 35);
            this.textBox3.Mask = "";
            this.textBox3.MaxLength = 50;
            this.textBox3.Name = "textBox3";
            this.textBox3.PasswordChar = '\0';
            this.textBox3.ReadOnly = false;
            this.textBox3.ShowCalendarButton = true;
            this.textBox3.Size = new System.Drawing.Size(185, 22);
            this.textBox3.TabIndex = 2;
            this.textBox3.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(324, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "英文名稱";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox2.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox2.CaptionLabel = this.label2;
            this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tableLayoutPanel1.SetColumnSpan(this.textBox2, 2);
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dEPTABindingSource, "D_NAME", true));
            this.textBox2.DecimalPlace = 2;
            this.textBox2.IsEmpty = false;
            this.textBox2.Location = new System.Drawing.Point(98, 35);
            this.textBox2.Mask = "";
            this.textBox2.MaxLength = 50;
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '\0';
            this.textBox2.ReadOnly = false;
            this.textBox2.ShowCalendarButton = true;
            this.textBox2.Size = new System.Drawing.Size(184, 22);
            this.textBox2.TabIndex = 1;
            this.textBox2.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(39, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "部門名稱";
            // 
            // txtDNO
            // 
            this.txtDNO.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtDNO.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtDNO.CaptionLabel = this.label1;
            this.txtDNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tableLayoutPanel1.SetColumnSpan(this.txtDNO, 2);
            this.txtDNO.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dEPTABindingSource, "D_NO_DISP", true));
            this.txtDNO.DecimalPlace = 2;
            this.txtDNO.IsEmpty = false;
            this.txtDNO.Location = new System.Drawing.Point(98, 4);
            this.txtDNO.Mask = "";
            this.txtDNO.MaxLength = 50;
            this.txtDNO.Name = "txtDNO";
            this.txtDNO.PasswordChar = '\0';
            this.txtDNO.ReadOnly = false;
            this.txtDNO.ShowCalendarButton = true;
            this.txtDNO.Size = new System.Drawing.Size(121, 22);
            this.txtDNO.TabIndex = 0;
            this.txtDNO.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "簽核部門代碼";
            // 
            // cbDeptGroup
            // 
            this.cbDeptGroup.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbDeptGroup.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dEPTABindingSource, "SIGN_GROUP", true));
            this.cbDeptGroup.DropDownWidth = 150;
            this.cbDeptGroup.FormattingEnabled = true;
            this.cbDeptGroup.Location = new System.Drawing.Point(478, 161);
            this.cbDeptGroup.Name = "cbDeptGroup";
            this.cbDeptGroup.Size = new System.Drawing.Size(90, 20);
            this.cbDeptGroup.TabIndex = 10;
            this.cbDeptGroup.Visible = false;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(419, 165);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 8;
            this.label11.Text = "簽核群組";
            this.label11.Visible = false;
            // 
            // txtDdate
            // 
            this.txtDdate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtDdate.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtDdate.CaptionLabel = this.label9;
            this.txtDdate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDdate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dEPTABindingSource, "DDATE", true));
            this.txtDdate.DecimalPlace = 2;
            this.txtDdate.IsEmpty = false;
            this.txtDdate.Location = new System.Drawing.Point(288, 160);
            this.txtDdate.Mask = "0000/00/00";
            this.txtDdate.MaxLength = -1;
            this.txtDdate.Name = "txtDdate";
            this.txtDdate.PasswordChar = '\0';
            this.txtDdate.ReadOnly = false;
            this.txtDdate.ShowCalendarButton = true;
            this.txtDdate.Size = new System.Drawing.Size(89, 22);
            this.txtDdate.TabIndex = 9;
            this.txtDdate.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(229, 165);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "失效日期";
            // 
            // txtAdate
            // 
            this.txtAdate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtAdate.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtAdate.CaptionLabel = this.label10;
            this.txtAdate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtAdate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dEPTABindingSource, "ADATE", true));
            this.txtAdate.DecimalPlace = 2;
            this.txtAdate.IsEmpty = false;
            this.txtAdate.Location = new System.Drawing.Point(98, 160);
            this.txtAdate.Mask = "0000/00/00";
            this.txtAdate.MaxLength = -1;
            this.txtAdate.Name = "txtAdate";
            this.txtAdate.PasswordChar = '\0';
            this.txtAdate.ReadOnly = false;
            this.txtAdate.ShowCalendarButton = true;
            this.txtAdate.Size = new System.Drawing.Size(89, 22);
            this.txtAdate.TabIndex = 8;
            this.txtAdate.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(39, 165);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 27;
            this.label10.Text = "生效日期";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(15, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "部門群組代碼";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(324, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "部門層級";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(39, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "部門主管";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(324, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 5;
            this.label8.Text = "主管信箱";
            // 
            // btnMang
            // 
            this.btnMang.Location = new System.Drawing.Point(633, 46);
            this.btnMang.Name = "btnMang";
            this.btnMang.Size = new System.Drawing.Size(75, 23);
            this.btnMang.TabIndex = 5;
            this.btnMang.TabStop = false;
            this.btnMang.Text = "離職主管";
            this.btnMang.UseVisualStyleBackColor = true;
            this.btnMang.Click += new System.EventHandler(this.btnMang_Click);
            // 
            // btnCodeGroup
            // 
            this.btnCodeGroup.Location = new System.Drawing.Point(633, 3);
            this.btnCodeGroup.Name = "btnCodeGroup";
            this.btnCodeGroup.Size = new System.Drawing.Size(75, 23);
            this.btnCodeGroup.TabIndex = 4;
            this.btnCodeGroup.TabStop = false;
            this.btnCodeGroup.Text = "代碼群組";
            this.btnCodeGroup.UseVisualStyleBackColor = true;
            this.btnCodeGroup.Click += new System.EventHandler(this.btnCodeGroup_Click_1);
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
            this.fullDataCtrl1.DataSource = this.dEPTABindingSource;
            this.fullDataCtrl1.DeleteType = JBControls.FullDataCtrl.EDeleteType.Delete;
            this.fullDataCtrl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.fullDataCtrl1.EnableAutoClone = false;
            this.fullDataCtrl1.GroupCmd = "";
            this.fullDataCtrl1.Location = new System.Drawing.Point(0, 0);
            this.fullDataCtrl1.Name = "fullDataCtrl1";
            this.fullDataCtrl1.QueryFields = "d_no,d_name,dept_group";
            this.fullDataCtrl1.RecentQuerySql = "";
            this.fullDataCtrl1.SelectCmd = "";
            this.fullDataCtrl1.ShowExceptionMsg = true;
            this.fullDataCtrl1.Size = new System.Drawing.Size(784, 73);
            this.fullDataCtrl1.SortFields = "d_no,d_name,dept_group";
            this.fullDataCtrl1.TabIndex = 0;
            this.fullDataCtrl1.WhereCmd = "";
            this.fullDataCtrl1.AfterAdd += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterAdd);
            this.fullDataCtrl1.AfterEdit += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterEdit);
            this.fullDataCtrl1.BeforeDel += new JBControls.FullDataCtrl.BeforeEventHandler(this.fullDataCtrl1_BeforeDel);
            this.fullDataCtrl1.AfterDel += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterDel);
            this.fullDataCtrl1.BeforeSave += new JBControls.FullDataCtrl.BeforeEventHandler(this.fullDataCtrl1_BeforeSave);
            this.fullDataCtrl1.AfterSave += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterSave);
            this.fullDataCtrl1.AfterCancel += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterCancel);
            this.fullDataCtrl1.AfterExport += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterExport);
            // 
            // dEPTABindingSource1
            // 
            this.dEPTABindingSource1.DataMember = "DEPTA";
            this.dEPTABindingSource1.DataSource = this.basDS1;
            // 
            // basDS1
            // 
            this.basDS1.DataSetName = "BasDS";
            this.basDS1.Locale = new System.Globalization.CultureInfo("");
            this.basDS1.RemotingFormat = System.Data.SerializationFormat.Binary;
            this.basDS1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.DataSource = this.dEPTABindingSource;
            // 
            // dEPTATableAdapter
            // 
            this.dEPTATableAdapter.ClearBeforeFill = true;
            // 
            // v_BASETableAdapter
            // 
            this.v_BASETableAdapter.ClearBeforeFill = true;
            // 
            // FRM11I
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.splitContainer1);
            this.FormSize = JBControls.JBForm.FormSizeType.Normal;
            this.KeyPreview = true;
            this.Name = "FRM11I";
            this.Text = "FRM11I";
            this.Load += new System.EventHandler(this.FRM111_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEx1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEPTABindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.basDS)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vBASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEPTABindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.basDS1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private JBControls.FullDataCtrl fullDataCtrl1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.SplitContainer splitContainer3;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label5;
		private JBControls.TextBox textBox2;
		private System.Windows.Forms.Label label2;
		private JBControls.TextBox txtDNO;
        private System.Windows.Forms.Label label1;
		private BasDS basDS;
		private System.Windows.Forms.BindingSource dEPTABindingSource;
        private JBHR.Bas.BasDSTableAdapters.DEPTATableAdapter dEPTATableAdapter;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private JBControls.DataGridView dataGridViewEx1;
        private JBControls.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource dEPTABindingSource1;
        private BasDS basDS1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private JBControls.PopupTextBox popupTextBox2;
        private System.Windows.Forms.BindingSource vBASEBindingSource;
        private BasDSTableAdapters.V_BASETableAdapter v_BASETableAdapter;
        private JBControls.TextBox textBox5;
        private System.Windows.Forms.Label label7;
        private JBControls.TextBox txtMangMail;
        private System.Windows.Forms.Label label8;
        private JBControls.TextBox txtDdate;
        private System.Windows.Forms.Label label9;
        private JBControls.TextBox txtAdate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnCodeGroup;
        private System.Windows.Forms.ComboBox cbDEPT_GROUP;
        private System.Windows.Forms.DataGridViewTextBoxColumn D_NO_DISP;
        private System.Windows.Forms.DataGridViewTextBoxColumn dNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn D_ENAME;
        private System.Windows.Forms.DataGridViewComboBoxColumn dEPTGROUPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEPT_TREE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOBR;
        private System.Windows.Forms.DataGridViewTextBoxColumn MANGEMAIL;
        private System.Windows.Forms.DataGridViewTextBoxColumn EMAIL;
        private System.Windows.Forms.DataGridViewTextBoxColumn ADATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DDATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYMANDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnMang;
        private System.Windows.Forms.ComboBox cbxDeptLevel;
        private System.Windows.Forms.ComboBox cbDeptGroup;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}