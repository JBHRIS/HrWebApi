namespace JBHR.Bas
{
	partial class FRM111
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
            this.dEPTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.basDS = new JBHR.Bas.BasDS();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox8 = new JBControls.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.checkBox1 = new JBControls.CheckBox();
            this.cbxDeptTree = new System.Windows.Forms.ComboBox();
            this.textBox1 = new JBControls.TextBox();
            this.cbDEPT_GROUP = new System.Windows.Forms.ComboBox();
            this.textBox4 = new JBControls.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ptxNobr = new JBControls.PopupTextBox();
            this.vBASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new JBControls.TextBox();
            this.textBox6 = new JBControls.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox3 = new JBControls.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox5 = new JBControls.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxAvailableCode = new System.Windows.Forms.CheckBox();
            this.btnMang = new System.Windows.Forms.Button();
            this.btnCodeGroup = new System.Windows.Forms.Button();
            this.fullDataCtrl1 = new JBControls.FullDataCtrl();
            this.dEPTBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.basDS1 = new JBHR.Bas.BasDS();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dEPTTableAdapter = new JBHR.Bas.BasDSTableAdapters.DEPTTableAdapter();
            this.v_BASETableAdapter = new JBHR.Bas.BasDSTableAdapters.V_BASETableAdapter();
            this.D_NO_DISP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D_ENAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dEPTGROUPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.aDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pNSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DEPT_TREE = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.NOBR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EMAIL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RES = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.kEYDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.dEPTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.basDS)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vBASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEPTBindingSource1)).BeginInit();
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
            this.splitContainer1.Panel2.Controls.Add(this.cbxAvailableCode);
            this.splitContainer1.Panel2.Controls.Add(this.btnMang);
            this.splitContainer1.Panel2.Controls.Add(this.btnCodeGroup);
            this.splitContainer1.Panel2.Controls.Add(this.fullDataCtrl1);
            this.splitContainer1.Size = new System.Drawing.Size(834, 561);
            this.splitContainer1.SplitterDistance = 480;
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
            this.splitContainer2.Size = new System.Drawing.Size(834, 480);
            this.splitContainer2.SplitterDistance = 218;
            this.splitContainer2.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.HideSelection = false;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(218, 480);
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
            this.splitContainer3.Size = new System.Drawing.Size(612, 480);
            this.splitContainer3.SplitterDistance = 305;
            this.splitContainer3.TabIndex = 0;
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
            this.D_NO_DISP,
            this.dNAMEDataGridViewTextBoxColumn,
            this.D_ENAME,
            this.dEPTGROUPDataGridViewTextBoxColumn,
            this.aDATEDataGridViewTextBoxColumn,
            this.dDATEDataGridViewTextBoxColumn,
            this.pNSDataGridViewTextBoxColumn,
            this.DEPT_TREE,
            this.NOBR,
            this.EMAIL,
            this.kEYMANDataGridViewTextBoxColumn,
            this.RES,
            this.kEYDATEDataGridViewTextBoxColumn});
            this.dataGridViewEx1.DataSource = this.dEPTBindingSource;
            this.dataGridViewEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEx1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewEx1.MultiSelect = false;
            this.dataGridViewEx1.Name = "dataGridViewEx1";
            this.dataGridViewEx1.ReadOnly = true;
            this.dataGridViewEx1.RowHeadersVisible = false;
            this.dataGridViewEx1.RowTemplate.Height = 24;
            this.dataGridViewEx1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEx1.Size = new System.Drawing.Size(612, 305);
            this.dataGridViewEx1.TabIndex = 9;
            // 
            // dEPTBindingSource
            // 
            this.dEPTBindingSource.DataMember = "DEPT";
            this.dEPTBindingSource.DataSource = this.basDS;
            // 
            // basDS
            // 
            this.basDS.DataSetName = "BasDS";
            this.basDS.Locale = new System.Globalization.CultureInfo("");
            this.basDS.RemotingFormat = System.Data.SerializationFormat.Binary;
            this.basDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(612, 171);
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
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox8, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.checkBox1, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.cbxDeptTree, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbDEPT_GROUP, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox4, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.ptxNobr, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label9, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox6, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBox3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox5, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 4, 1);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(608, 167);
            this.tableLayoutPanel1.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(21, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "編制部門代碼";
            // 
            // textBox8
            // 
            this.textBox8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox8.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox8.CaptionLabel = this.label10;
            this.textBox8.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tableLayoutPanel1.SetColumnSpan(this.textBox8, 5);
            this.textBox8.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dEPTBindingSource, "EMAIL", true));
            this.textBox8.DecimalPlace = 2;
            this.textBox8.IsEmpty = true;
            this.textBox8.Location = new System.Drawing.Point(104, 140);
            this.textBox8.Mask = "";
            this.textBox8.MaxLength = 500;
            this.textBox8.Name = "textBox8";
            this.textBox8.PasswordChar = '\0';
            this.textBox8.ReadOnly = false;
            this.textBox8.ShowCalendarButton = true;
            this.textBox8.Size = new System.Drawing.Size(470, 22);
            this.textBox8.TabIndex = 9;
            this.textBox8.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(21, 145);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 12);
            this.label10.TabIndex = 20;
            this.label10.Text = "異常通知信箱";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.CaptionLabel = null;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.dEPTBindingSource, "RES", true));
            this.checkBox1.IsImitateCaption = true;
            this.checkBox1.Location = new System.Drawing.Point(306, 111);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(95, 16);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.TabStop = false;
            this.checkBox1.Text = "不計休息時間";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            // 
            // cbxDeptTree
            // 
            this.cbxDeptTree.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.cbxDeptTree, 2);
            this.cbxDeptTree.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dEPTBindingSource, "DEPT_TREE", true));
            this.cbxDeptTree.FormattingEnabled = true;
            this.cbxDeptTree.Location = new System.Drawing.Point(104, 84);
            this.cbxDeptTree.Name = "cbxDeptTree";
            this.cbxDeptTree.Size = new System.Drawing.Size(184, 20);
            this.cbxDeptTree.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox1.CaptionLabel = this.label1;
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dEPTBindingSource, "D_NO_DISP", true));
            this.textBox1.DecimalPlace = 2;
            this.textBox1.IsEmpty = false;
            this.textBox1.Location = new System.Drawing.Point(104, 3);
            this.textBox1.Mask = "";
            this.textBox1.MaxLength = 50;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.ReadOnly = false;
            this.textBox1.ShowCalendarButton = true;
            this.textBox1.Size = new System.Drawing.Size(89, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // cbDEPT_GROUP
            // 
            this.cbDEPT_GROUP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.cbDEPT_GROUP, 3);
            this.cbDEPT_GROUP.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dEPTBindingSource, "DEPT_GROUP", true));
            this.cbDEPT_GROUP.FormattingEnabled = true;
            this.cbDEPT_GROUP.Location = new System.Drawing.Point(306, 3);
            this.cbDEPT_GROUP.Name = "cbDEPT_GROUP";
            this.cbDEPT_GROUP.Size = new System.Drawing.Size(280, 20);
            this.cbDEPT_GROUP.TabIndex = 1;
            // 
            // textBox4
            // 
            this.textBox4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox4.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox4.CaptionLabel = this.label4;
            this.textBox4.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dEPTBindingSource, "PNS", true));
            this.textBox4.DecimalPlace = 2;
            this.textBox4.IsEmpty = true;
            this.textBox4.Location = new System.Drawing.Point(104, 111);
            this.textBox4.Mask = "";
            this.textBox4.MaxLength = -1;
            this.textBox4.Name = "textBox4";
            this.textBox4.PasswordChar = '\0';
            this.textBox4.ReadOnly = false;
            this.textBox4.ShowCalendarButton = true;
            this.textBox4.Size = new System.Drawing.Size(64, 22);
            this.textBox4.TabIndex = 8;
            this.textBox4.ValidType = JBControls.TextBox.EValidType.Decimal;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(45, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "編制人數";
            // 
            // ptxNobr
            // 
            this.ptxNobr.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ptxNobr.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ptxNobr.CaptionLabel = null;
            this.ptxNobr.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tableLayoutPanel1.SetColumnSpan(this.ptxNobr, 2);
            this.ptxNobr.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dEPTBindingSource, "NOBR", true));
            this.ptxNobr.DataSource = this.vBASEBindingSource;
            this.ptxNobr.DisplayMember = "name_c";
            this.ptxNobr.IsEmpty = true;
            this.ptxNobr.IsEmptyToQuery = true;
            this.ptxNobr.IsMustBeFound = true;
            this.ptxNobr.LabelText = "";
            this.ptxNobr.Location = new System.Drawing.Point(407, 84);
            this.ptxNobr.Name = "ptxNobr";
            this.ptxNobr.QueryFields = "name_e,idno";
            this.ptxNobr.ReadOnly = false;
            this.ptxNobr.ShowDisplayName = true;
            this.ptxNobr.Size = new System.Drawing.Size(89, 22);
            this.ptxNobr.TabIndex = 7;
            this.ptxNobr.ValueMember = "nobr";
            this.ptxNobr.WhereCmd = "";
            // 
            // vBASEBindingSource
            // 
            this.vBASEBindingSource.DataMember = "V_BASE";
            this.vBASEBindingSource.DataSource = this.basDS;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(247, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "部門群組";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(348, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 17;
            this.label9.Text = "主管工號";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(45, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "部門名稱";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox2.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox2.CaptionLabel = this.label2;
            this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tableLayoutPanel1.SetColumnSpan(this.textBox2, 3);
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dEPTBindingSource, "D_NAME", true));
            this.textBox2.DecimalPlace = 2;
            this.textBox2.IsEmpty = false;
            this.textBox2.Location = new System.Drawing.Point(104, 30);
            this.textBox2.Mask = "";
            this.textBox2.MaxLength = 50;
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '\0';
            this.textBox2.ReadOnly = false;
            this.textBox2.ShowCalendarButton = true;
            this.textBox2.Size = new System.Drawing.Size(279, 22);
            this.textBox2.TabIndex = 2;
            this.textBox2.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // textBox6
            // 
            this.textBox6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox6.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox6.CaptionLabel = this.label7;
            this.textBox6.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox6.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dEPTBindingSource, "DDATE", true));
            this.textBox6.DecimalPlace = 2;
            this.textBox6.IsEmpty = false;
            this.textBox6.Location = new System.Drawing.Point(508, 57);
            this.textBox6.Mask = "0000/00/00";
            this.textBox6.MaxLength = -1;
            this.textBox6.Name = "textBox6";
            this.textBox6.PasswordChar = '\0';
            this.textBox6.ReadOnly = false;
            this.textBox6.ShowCalendarButton = true;
            this.textBox6.Size = new System.Drawing.Size(90, 22);
            this.textBox6.TabIndex = 5;
            this.textBox6.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(449, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "撤銷日期";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(21, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "報表分析群組";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox3.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox3.CaptionLabel = this.label3;
            this.textBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tableLayoutPanel1.SetColumnSpan(this.textBox3, 3);
            this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dEPTBindingSource, "D_ENAME", true));
            this.textBox3.DecimalPlace = 2;
            this.textBox3.IsEmpty = true;
            this.textBox3.Location = new System.Drawing.Point(104, 57);
            this.textBox3.Mask = "";
            this.textBox3.MaxLength = 50;
            this.textBox3.Name = "textBox3";
            this.textBox3.PasswordChar = '\0';
            this.textBox3.ReadOnly = false;
            this.textBox3.ShowCalendarButton = true;
            this.textBox3.Size = new System.Drawing.Size(279, 22);
            this.textBox3.TabIndex = 4;
            this.textBox3.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(45, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "英文名稱";
            // 
            // textBox5
            // 
            this.textBox5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox5.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox5.CaptionLabel = this.label6;
            this.textBox5.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox5.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dEPTBindingSource, "ADATE", true));
            this.textBox5.DecimalPlace = 2;
            this.textBox5.IsEmpty = false;
            this.textBox5.Location = new System.Drawing.Point(508, 30);
            this.textBox5.Mask = "0000/00/00";
            this.textBox5.MaxLength = -1;
            this.textBox5.Name = "textBox5";
            this.textBox5.PasswordChar = '\0';
            this.textBox5.ReadOnly = false;
            this.textBox5.ShowCalendarButton = true;
            this.textBox5.Size = new System.Drawing.Size(90, 22);
            this.textBox5.TabIndex = 3;
            this.textBox5.ValidType = JBControls.TextBox.EValidType.Date;
            this.textBox5.Validated += new System.EventHandler(this.textBox5_Validated);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(449, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "成立日期";
            // 
            // cbxAvailableCode
            // 
            this.cbxAvailableCode.AutoSize = true;
            this.cbxAvailableCode.Location = new System.Drawing.Point(732, 7);
            this.cbxAvailableCode.Name = "cbxAvailableCode";
            this.cbxAvailableCode.Size = new System.Drawing.Size(96, 16);
            this.cbxAvailableCode.TabIndex = 10;
            this.cbxAvailableCode.TabStop = false;
            this.cbxAvailableCode.Text = "顯示失效部門";
            this.cbxAvailableCode.UseVisualStyleBackColor = true;
            this.cbxAvailableCode.CheckedChanged += new System.EventHandler(this.cbxAvailableCode_CheckedChanged);
            // 
            // btnMang
            // 
            this.btnMang.Location = new System.Drawing.Point(632, 46);
            this.btnMang.Name = "btnMang";
            this.btnMang.Size = new System.Drawing.Size(75, 23);
            this.btnMang.TabIndex = 4;
            this.btnMang.TabStop = false;
            this.btnMang.Text = "離職主管";
            this.btnMang.UseVisualStyleBackColor = true;
            this.btnMang.Click += new System.EventHandler(this.btnMang_Click);
            // 
            // btnCodeGroup
            // 
            this.btnCodeGroup.Location = new System.Drawing.Point(632, 3);
            this.btnCodeGroup.Name = "btnCodeGroup";
            this.btnCodeGroup.Size = new System.Drawing.Size(75, 23);
            this.btnCodeGroup.TabIndex = 3;
            this.btnCodeGroup.TabStop = false;
            this.btnCodeGroup.Text = "代碼群組";
            this.btnCodeGroup.UseVisualStyleBackColor = true;
            this.btnCodeGroup.Click += new System.EventHandler(this.btnCodeGroup_Click);
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
            this.fullDataCtrl1.DataSource = this.dEPTBindingSource;
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
            this.fullDataCtrl1.Size = new System.Drawing.Size(834, 73);
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
            // dEPTBindingSource1
            // 
            this.dEPTBindingSource1.DataMember = "DEPT";
            this.dEPTBindingSource1.DataSource = this.basDS1;
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
            this.errorProvider1.DataSource = this.dEPTBindingSource;
            // 
            // dEPTTableAdapter
            // 
            this.dEPTTableAdapter.ClearBeforeFill = true;
            // 
            // v_BASETableAdapter
            // 
            this.v_BASETableAdapter.ClearBeforeFill = true;
            // 
            // D_NO_DISP
            // 
            this.D_NO_DISP.DataPropertyName = "D_NO_DISP";
            this.D_NO_DISP.HeaderText = "編制部門代碼";
            this.D_NO_DISP.Name = "D_NO_DISP";
            this.D_NO_DISP.ReadOnly = true;
            this.D_NO_DISP.Width = 102;
            // 
            // dNAMEDataGridViewTextBoxColumn
            // 
            this.dNAMEDataGridViewTextBoxColumn.DataPropertyName = "D_NAME";
            this.dNAMEDataGridViewTextBoxColumn.HeaderText = "部門名稱";
            this.dNAMEDataGridViewTextBoxColumn.Name = "dNAMEDataGridViewTextBoxColumn";
            this.dNAMEDataGridViewTextBoxColumn.ReadOnly = true;
            this.dNAMEDataGridViewTextBoxColumn.Width = 78;
            // 
            // D_ENAME
            // 
            this.D_ENAME.DataPropertyName = "D_ENAME";
            this.D_ENAME.HeaderText = "英文名稱";
            this.D_ENAME.Name = "D_ENAME";
            this.D_ENAME.ReadOnly = true;
            this.D_ENAME.Width = 78;
            // 
            // dEPTGROUPDataGridViewTextBoxColumn
            // 
            this.dEPTGROUPDataGridViewTextBoxColumn.DataPropertyName = "DEPT_GROUP";
            this.dEPTGROUPDataGridViewTextBoxColumn.DataSource = this.dEPTBindingSource;
            this.dEPTGROUPDataGridViewTextBoxColumn.DisplayMember = "D_NO_DISP";
            this.dEPTGROUPDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dEPTGROUPDataGridViewTextBoxColumn.HeaderText = "部門群組";
            this.dEPTGROUPDataGridViewTextBoxColumn.Name = "dEPTGROUPDataGridViewTextBoxColumn";
            this.dEPTGROUPDataGridViewTextBoxColumn.ReadOnly = true;
            this.dEPTGROUPDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dEPTGROUPDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dEPTGROUPDataGridViewTextBoxColumn.ValueMember = "D_NO";
            this.dEPTGROUPDataGridViewTextBoxColumn.Width = 78;
            // 
            // aDATEDataGridViewTextBoxColumn
            // 
            this.aDATEDataGridViewTextBoxColumn.DataPropertyName = "ADATE";
            this.aDATEDataGridViewTextBoxColumn.HeaderText = "成立日期";
            this.aDATEDataGridViewTextBoxColumn.Name = "aDATEDataGridViewTextBoxColumn";
            this.aDATEDataGridViewTextBoxColumn.ReadOnly = true;
            this.aDATEDataGridViewTextBoxColumn.Width = 78;
            // 
            // dDATEDataGridViewTextBoxColumn
            // 
            this.dDATEDataGridViewTextBoxColumn.DataPropertyName = "DDATE";
            this.dDATEDataGridViewTextBoxColumn.HeaderText = "撤銷日期";
            this.dDATEDataGridViewTextBoxColumn.Name = "dDATEDataGridViewTextBoxColumn";
            this.dDATEDataGridViewTextBoxColumn.ReadOnly = true;
            this.dDATEDataGridViewTextBoxColumn.Width = 78;
            // 
            // pNSDataGridViewTextBoxColumn
            // 
            this.pNSDataGridViewTextBoxColumn.DataPropertyName = "PNS";
            this.pNSDataGridViewTextBoxColumn.HeaderText = "編制人數";
            this.pNSDataGridViewTextBoxColumn.Name = "pNSDataGridViewTextBoxColumn";
            this.pNSDataGridViewTextBoxColumn.ReadOnly = true;
            this.pNSDataGridViewTextBoxColumn.Width = 78;
            // 
            // DEPT_TREE
            // 
            this.DEPT_TREE.DataPropertyName = "DEPT_TREE";
            this.DEPT_TREE.DataSource = this.dEPTBindingSource;
            this.DEPT_TREE.DisplayMember = "D_NO_DISP";
            this.DEPT_TREE.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.DEPT_TREE.HeaderText = "部門樹";
            this.DEPT_TREE.Name = "DEPT_TREE";
            this.DEPT_TREE.ReadOnly = true;
            this.DEPT_TREE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DEPT_TREE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DEPT_TREE.ValueMember = "D_NO";
            this.DEPT_TREE.Width = 66;
            // 
            // NOBR
            // 
            this.NOBR.DataPropertyName = "NOBR";
            this.NOBR.HeaderText = "主管工號";
            this.NOBR.Name = "NOBR";
            this.NOBR.ReadOnly = true;
            this.NOBR.Width = 78;
            // 
            // EMAIL
            // 
            this.EMAIL.DataPropertyName = "EMAIL";
            this.EMAIL.HeaderText = "異常通知信箱";
            this.EMAIL.Name = "EMAIL";
            this.EMAIL.ReadOnly = true;
            this.EMAIL.Width = 102;
            // 
            // kEYMANDataGridViewTextBoxColumn
            // 
            this.kEYMANDataGridViewTextBoxColumn.DataPropertyName = "KEY_MAN";
            this.kEYMANDataGridViewTextBoxColumn.HeaderText = "登錄者";
            this.kEYMANDataGridViewTextBoxColumn.Name = "kEYMANDataGridViewTextBoxColumn";
            this.kEYMANDataGridViewTextBoxColumn.ReadOnly = true;
            this.kEYMANDataGridViewTextBoxColumn.Width = 66;
            // 
            // RES
            // 
            this.RES.DataPropertyName = "RES";
            this.RES.HeaderText = "不計休息時間";
            this.RES.Name = "RES";
            this.RES.ReadOnly = true;
            this.RES.Visible = false;
            this.RES.Width = 83;
            // 
            // kEYDATEDataGridViewTextBoxColumn
            // 
            this.kEYDATEDataGridViewTextBoxColumn.DataPropertyName = "KEY_DATE";
            this.kEYDATEDataGridViewTextBoxColumn.HeaderText = "登錄日期";
            this.kEYDATEDataGridViewTextBoxColumn.Name = "kEYDATEDataGridViewTextBoxColumn";
            this.kEYDATEDataGridViewTextBoxColumn.ReadOnly = true;
            this.kEYDATEDataGridViewTextBoxColumn.Width = 78;
            // 
            // FRM111
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 561);
            this.Controls.Add(this.splitContainer1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.KeyPreview = true;
            this.Name = "FRM111";
            this.Text = "FRM111";
            this.Load += new System.EventHandler(this.FRM111_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.dEPTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.basDS)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vBASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEPTBindingSource1)).EndInit();
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
		private JBControls.TextBox textBox4;
		private System.Windows.Forms.Label label4;
		private JBControls.TextBox textBox2;
		private System.Windows.Forms.Label label2;
		private JBControls.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private JBControls.TextBox textBox6;
		private System.Windows.Forms.Label label7;
		private JBControls.TextBox textBox5;
        private System.Windows.Forms.Label label6;
		private BasDS basDS;
		private System.Windows.Forms.BindingSource dEPTBindingSource;
        private JBHR.Bas.BasDSTableAdapters.DEPTTableAdapter dEPTTableAdapter;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private JBControls.DataGridView dataGridViewEx1;
        private JBControls.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private BasDS basDS1;
        private System.Windows.Forms.BindingSource dEPTBindingSource1;
        private System.Windows.Forms.Label label8;
        private JBControls.PopupTextBox ptxNobr;
        private System.Windows.Forms.BindingSource vBASEBindingSource;
        private System.Windows.Forms.Label label9;
        private BasDSTableAdapters.V_BASETableAdapter v_BASETableAdapter;
        private JBControls.TextBox textBox8;
        private System.Windows.Forms.Label label10;
        private JBControls.CheckBox checkBox1;
        private System.Windows.Forms.Button btnCodeGroup;
        private System.Windows.Forms.ComboBox cbDEPT_GROUP;
        private System.Windows.Forms.ComboBox cbxDeptTree;
        private System.Windows.Forms.Button btnMang;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox cbxAvailableCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn D_NO_DISP;
        private System.Windows.Forms.DataGridViewTextBoxColumn dNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn D_ENAME;
        private System.Windows.Forms.DataGridViewComboBoxColumn dEPTGROUPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pNSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn DEPT_TREE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOBR;
        private System.Windows.Forms.DataGridViewTextBoxColumn EMAIL;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYMANDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn RES;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYDATEDataGridViewTextBoxColumn;
    }
}