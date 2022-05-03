namespace JBHR.Ins
{
    partial class FRM31
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
            this.iNSURLVBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.insDS = new JBHR.Ins.InsDS();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new JBControls.TextBox();
            this.textBox2 = new JBControls.TextBox();
            this.textBox3 = new JBControls.TextBox();
            this.textBox4 = new JBControls.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox5 = new JBControls.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox7 = new JBControls.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox6 = new JBControls.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox8 = new JBControls.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.fullDataCtrl1 = new JBControls.FullDataCtrl();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.iNSURLVTableAdapter = new JBHR.Ins.InsDSTableAdapters.INSURLVTableAdapter();
            this.aMTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eFFDATELDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eFFDATEHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EFF_RATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lFFDATELDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lFFDATEHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eFFDATERDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lFFDATERDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EFF_DATEJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LFF_DATEJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYMANDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kEYDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox9 = new JBControls.TextBox();
            this.textBox10 = new JBControls.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNSURLVBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.insDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.splitContainer1.Size = new System.Drawing.Size(784, 561);
            this.splitContainer1.SplitterDistance = 387;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("細明體", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.aMTDataGridViewTextBoxColumn,
            this.eFFDATELDataGridViewTextBoxColumn,
            this.eFFDATEHDataGridViewTextBoxColumn,
            this.EFF_RATE,
            this.lFFDATELDataGridViewTextBoxColumn,
            this.lFFDATEHDataGridViewTextBoxColumn,
            this.eFFDATERDataGridViewTextBoxColumn,
            this.lFFDATERDataGridViewTextBoxColumn,
            this.EFF_DATEJ,
            this.LFF_DATEJ,
            this.kEYMANDataGridViewTextBoxColumn,
            this.kEYDATEDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.iNSURLVBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(784, 387);
            this.dataGridView1.TabIndex = 0;
            // 
            // iNSURLVBindingSource
            // 
            this.iNSURLVBindingSource.DataMember = "INSURLV";
            this.iNSURLVBindingSource.DataSource = this.insDS;
            // 
            // insDS
            // 
            this.insDS.DataSetName = "InsDS";
            this.insDS.Locale = new System.Globalization.CultureInfo("");
            this.insDS.RemotingFormat = System.Data.SerializationFormat.Binary;
            this.insDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.splitContainer2.Size = new System.Drawing.Size(784, 170);
            this.splitContainer2.SplitterDistance = 86;
            this.splitContainer2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 86);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Controls.Add(this.label9, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.label10, 6, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox4, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox5, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox7, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox6, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox8, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox9, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox10, 7, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(716, 82);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(15, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "投保金額";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(3, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "勞保生效日";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(3, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "勞保失效日";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox1.CaptionLabel = this.label1;
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iNSURLVBindingSource, "AMT", true));
            this.textBox1.DecimalPlace = 2;
            this.textBox1.IsEmpty = false;
            this.textBox1.Location = new System.Drawing.Point(74, 3);
            this.textBox1.Mask = "";
            this.textBox1.MaxLength = -1;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.ReadOnly = false;
            this.textBox1.ShowCalendarButton = true;
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.ValidType = JBControls.TextBox.EValidType.Decimal;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox2.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox2.CaptionLabel = this.label2;
            this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iNSURLVBindingSource, "EFF_DATEL", true));
            this.textBox2.DecimalPlace = 2;
            this.textBox2.IsEmpty = false;
            this.textBox2.Location = new System.Drawing.Point(74, 31);
            this.textBox2.Mask = "0000/00/00";
            this.textBox2.MaxLength = -1;
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '\0';
            this.textBox2.ReadOnly = false;
            this.textBox2.ShowCalendarButton = true;
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 2;
            this.textBox2.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox3.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox3.CaptionLabel = this.label3;
            this.textBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iNSURLVBindingSource, "LFF_DATEL", true));
            this.textBox3.DecimalPlace = 2;
            this.textBox3.IsEmpty = false;
            this.textBox3.Location = new System.Drawing.Point(74, 59);
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
            // textBox4
            // 
            this.textBox4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox4.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox4.CaptionLabel = this.label4;
            this.textBox4.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iNSURLVBindingSource, "EFF_DATEH", true));
            this.textBox4.DecimalPlace = 2;
            this.textBox4.IsEmpty = false;
            this.textBox4.Location = new System.Drawing.Point(251, 31);
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
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(180, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "健保生效日";
            // 
            // textBox5
            // 
            this.textBox5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox5.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox5.CaptionLabel = this.label5;
            this.textBox5.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox5.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iNSURLVBindingSource, "LFF_DATEH", true));
            this.textBox5.DecimalPlace = 2;
            this.textBox5.IsEmpty = false;
            this.textBox5.Location = new System.Drawing.Point(251, 59);
            this.textBox5.Mask = "0000/00/00";
            this.textBox5.MaxLength = -1;
            this.textBox5.Name = "textBox5";
            this.textBox5.PasswordChar = '\0';
            this.textBox5.ReadOnly = false;
            this.textBox5.ShowCalendarButton = true;
            this.textBox5.Size = new System.Drawing.Size(100, 22);
            this.textBox5.TabIndex = 5;
            this.textBox5.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(180, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "健保失效日";
            // 
            // textBox7
            // 
            this.textBox7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox7.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox7.CaptionLabel = this.label7;
            this.textBox7.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox7.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iNSURLVBindingSource, "LFF_DATER", true));
            this.textBox7.DecimalPlace = 2;
            this.textBox7.IsEmpty = false;
            this.textBox7.Location = new System.Drawing.Point(428, 59);
            this.textBox7.Mask = "0000/00/00";
            this.textBox7.MaxLength = -1;
            this.textBox7.Name = "textBox7";
            this.textBox7.PasswordChar = '\0';
            this.textBox7.ReadOnly = false;
            this.textBox7.ShowCalendarButton = true;
            this.textBox7.Size = new System.Drawing.Size(100, 22);
            this.textBox7.TabIndex = 7;
            this.textBox7.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(357, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "勞退失效日";
            // 
            // textBox6
            // 
            this.textBox6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox6.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox6.CaptionLabel = this.label6;
            this.textBox6.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox6.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iNSURLVBindingSource, "EFF_DATER", true));
            this.textBox6.DecimalPlace = 2;
            this.textBox6.IsEmpty = false;
            this.textBox6.Location = new System.Drawing.Point(428, 31);
            this.textBox6.Mask = "0000/00/00";
            this.textBox6.MaxLength = -1;
            this.textBox6.Name = "textBox6";
            this.textBox6.PasswordChar = '\0';
            this.textBox6.ReadOnly = false;
            this.textBox6.ShowCalendarButton = true;
            this.textBox6.Size = new System.Drawing.Size(100, 22);
            this.textBox6.TabIndex = 6;
            this.textBox6.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(357, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "勞退生效日";
            // 
            // textBox8
            // 
            this.textBox8.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox8.CaptionLabel = this.label8;
            this.textBox8.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox8.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iNSURLVBindingSource, "EFF_RATE", true));
            this.textBox8.DecimalPlace = 5;
            this.textBox8.IsEmpty = false;
            this.textBox8.Location = new System.Drawing.Point(251, 3);
            this.textBox8.Mask = "";
            this.textBox8.MaxLength = -1;
            this.textBox8.Name = "textBox8";
            this.textBox8.PasswordChar = '\0';
            this.textBox8.ReadOnly = false;
            this.textBox8.ShowCalendarButton = true;
            this.textBox8.Size = new System.Drawing.Size(100, 22);
            this.textBox8.TabIndex = 1;
            this.textBox8.ValidType = JBControls.TextBox.EValidType.Decimal;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(192, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 15;
            this.label8.Text = "健保費率";
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
            this.fullDataCtrl1.DataSource = this.iNSURLVBindingSource;
            this.fullDataCtrl1.DeleteType = JBControls.FullDataCtrl.EDeleteType.Delete;
            this.fullDataCtrl1.EnableAutoClone = false;
            this.fullDataCtrl1.GroupCmd = "";
            this.fullDataCtrl1.Location = new System.Drawing.Point(-2, 5);
            this.fullDataCtrl1.Name = "fullDataCtrl1";
            this.fullDataCtrl1.QueryFields = "amt,eff_rate";
            this.fullDataCtrl1.RecentQuerySql = "";
            this.fullDataCtrl1.SelectCmd = "";
            this.fullDataCtrl1.ShowExceptionMsg = true;
            this.fullDataCtrl1.Size = new System.Drawing.Size(635, 73);
            this.fullDataCtrl1.SortFields = "amt,eff_rate";
            this.fullDataCtrl1.TabIndex = 0;
            this.fullDataCtrl1.WhereCmd = "";
            this.fullDataCtrl1.AfterDel += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterDel);
            this.fullDataCtrl1.BeforeSave += new JBControls.FullDataCtrl.BeforeEventHandler(this.fullDataCtrl1_BeforeSave);
            this.fullDataCtrl1.AfterSave += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterSave);
            this.fullDataCtrl1.AfterExport += new JBControls.FullDataCtrl.AfterEventHandler(this.fullDataCtrl1_AfterExport);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.DataSource = this.iNSURLVBindingSource;
            // 
            // iNSURLVTableAdapter
            // 
            this.iNSURLVTableAdapter.ClearBeforeFill = true;
            // 
            // aMTDataGridViewTextBoxColumn
            // 
            this.aMTDataGridViewTextBoxColumn.DataPropertyName = "AMT";
            this.aMTDataGridViewTextBoxColumn.HeaderText = "投保金額";
            this.aMTDataGridViewTextBoxColumn.Name = "aMTDataGridViewTextBoxColumn";
            this.aMTDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // eFFDATELDataGridViewTextBoxColumn
            // 
            this.eFFDATELDataGridViewTextBoxColumn.DataPropertyName = "EFF_DATEL";
            this.eFFDATELDataGridViewTextBoxColumn.HeaderText = "勞保生效日";
            this.eFFDATELDataGridViewTextBoxColumn.Name = "eFFDATELDataGridViewTextBoxColumn";
            this.eFFDATELDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // eFFDATEHDataGridViewTextBoxColumn
            // 
            this.eFFDATEHDataGridViewTextBoxColumn.DataPropertyName = "LFF_DATEL";
            this.eFFDATEHDataGridViewTextBoxColumn.HeaderText = "勞保失效日";
            this.eFFDATEHDataGridViewTextBoxColumn.Name = "eFFDATEHDataGridViewTextBoxColumn";
            this.eFFDATEHDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // EFF_RATE
            // 
            this.EFF_RATE.DataPropertyName = "EFF_RATE";
            this.EFF_RATE.HeaderText = "健保費率";
            this.EFF_RATE.Name = "EFF_RATE";
            this.EFF_RATE.ReadOnly = true;
            // 
            // lFFDATELDataGridViewTextBoxColumn
            // 
            this.lFFDATELDataGridViewTextBoxColumn.DataPropertyName = "EFF_DATEH";
            this.lFFDATELDataGridViewTextBoxColumn.HeaderText = "健保生效日";
            this.lFFDATELDataGridViewTextBoxColumn.Name = "lFFDATELDataGridViewTextBoxColumn";
            this.lFFDATELDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lFFDATEHDataGridViewTextBoxColumn
            // 
            this.lFFDATEHDataGridViewTextBoxColumn.DataPropertyName = "LFF_DATEH";
            this.lFFDATEHDataGridViewTextBoxColumn.HeaderText = "健保失效日";
            this.lFFDATEHDataGridViewTextBoxColumn.Name = "lFFDATEHDataGridViewTextBoxColumn";
            this.lFFDATEHDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // eFFDATERDataGridViewTextBoxColumn
            // 
            this.eFFDATERDataGridViewTextBoxColumn.DataPropertyName = "EFF_DATER";
            this.eFFDATERDataGridViewTextBoxColumn.HeaderText = "勞退生效日";
            this.eFFDATERDataGridViewTextBoxColumn.Name = "eFFDATERDataGridViewTextBoxColumn";
            this.eFFDATERDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lFFDATERDataGridViewTextBoxColumn
            // 
            this.lFFDATERDataGridViewTextBoxColumn.DataPropertyName = "LFF_DATER";
            this.lFFDATERDataGridViewTextBoxColumn.HeaderText = "勞退失效日";
            this.lFFDATERDataGridViewTextBoxColumn.Name = "lFFDATERDataGridViewTextBoxColumn";
            this.lFFDATERDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // EFF_DATEJ
            // 
            this.EFF_DATEJ.DataPropertyName = "EFF_DATEJ";
            this.EFF_DATEJ.HeaderText = "職災生效日";
            this.EFF_DATEJ.Name = "EFF_DATEJ";
            this.EFF_DATEJ.ReadOnly = true;
            // 
            // LFF_DATEJ
            // 
            this.LFF_DATEJ.DataPropertyName = "LFF_DATEJ";
            this.LFF_DATEJ.HeaderText = "職災失效日";
            this.LFF_DATEJ.Name = "LFF_DATEJ";
            this.LFF_DATEJ.ReadOnly = true;
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
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(538, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "職災生效日";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(538, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 2;
            this.label10.Text = "職災失效日";
            // 
            // textBox9
            // 
            this.textBox9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox9.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox9.CaptionLabel = null;
            this.textBox9.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox9.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iNSURLVBindingSource, "EFF_DATEJ", true));
            this.textBox9.DecimalPlace = 2;
            this.textBox9.IsEmpty = false;
            this.textBox9.Location = new System.Drawing.Point(609, 31);
            this.textBox9.Mask = "0000/00/00";
            this.textBox9.MaxLength = -1;
            this.textBox9.Name = "textBox9";
            this.textBox9.PasswordChar = '\0';
            this.textBox9.ReadOnly = false;
            this.textBox9.ShowCalendarButton = true;
            this.textBox9.Size = new System.Drawing.Size(100, 22);
            this.textBox9.TabIndex = 6;
            this.textBox9.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // textBox10
            // 
            this.textBox10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox10.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBox10.CaptionLabel = null;
            this.textBox10.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox10.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iNSURLVBindingSource, "LFF_DATEJ", true));
            this.textBox10.DecimalPlace = 2;
            this.textBox10.IsEmpty = false;
            this.textBox10.Location = new System.Drawing.Point(609, 59);
            this.textBox10.Mask = "0000/00/00";
            this.textBox10.MaxLength = -1;
            this.textBox10.Name = "textBox10";
            this.textBox10.PasswordChar = '\0';
            this.textBox10.ReadOnly = false;
            this.textBox10.ShowCalendarButton = true;
            this.textBox10.Size = new System.Drawing.Size(100, 22);
            this.textBox10.TabIndex = 6;
            this.textBox10.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // FRM31
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.splitContainer1);
            this.FormSize = JBControls.JBForm.FormSizeType.Normal;
            this.KeyPreview = true;
            this.Name = "FRM31";
            this.Text = "FRM31";
            this.Load += new System.EventHandler(this.FRM31_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iNSURLVBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.insDS)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel1;
        private JBControls.FullDataCtrl fullDataCtrl1;
        private JBControls.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private JBControls.TextBox textBox1;
        private JBControls.TextBox textBox2;
        private JBControls.TextBox textBox3;
        private JBControls.TextBox textBox4;
        private JBControls.TextBox textBox5;
        private JBControls.TextBox textBox6;
        private JBControls.TextBox textBox7;
        private InsDS insDS;
        private System.Windows.Forms.BindingSource iNSURLVBindingSource;
        private JBHR.Ins.InsDSTableAdapters.INSURLVTableAdapter iNSURLVTableAdapter;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private JBControls.TextBox textBox8;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn aMTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eFFDATELDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eFFDATEHDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EFF_RATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn lFFDATELDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lFFDATEHDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eFFDATERDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lFFDATERDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EFF_DATEJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn LFF_DATEJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYMANDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kEYDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private JBControls.TextBox textBox9;
        private JBControls.TextBox textBox10;
    }
}