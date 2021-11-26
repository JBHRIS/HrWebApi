namespace JBHR.Att
{
    partial class FRM2JBB
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
            this.dEPTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsBas = new JBHR.Att.dsBas();
            this.bASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dEPTBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bASEBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.rOTEBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dsAtt = new JBHR.Att.dsAtt();
            this.rOTEBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.bASETableAdapter = new JBHR.Att.dsBasTableAdapters.BASETableAdapter();
            this.dEPTTableAdapter = new JBHR.Att.dsBasTableAdapters.DEPTTableAdapter();
            this.rOTEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rOTETableAdapter = new JBHR.Att.dsAttTableAdapters.ROTETableAdapter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rb33 = new System.Windows.Forms.RadioButton();
            this.rb32 = new System.Windows.Forms.RadioButton();
            this.rb31 = new System.Windows.Forms.RadioButton();
            this.chkSysOt = new JBControls.CheckBox();
            this.cbxOtrcd = new JBControls.ComboBox();
            this.oTRCDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNote = new JBControls.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb23 = new System.Windows.Forms.RadioButton();
            this.rb22 = new System.Windows.Forms.RadioButton();
            this.rb21 = new System.Windows.Forms.RadioButton();
            this.gpbType = new System.Windows.Forms.GroupBox();
            this.rb12 = new System.Windows.Forms.RadioButton();
            this.rb11 = new System.Windows.Forms.RadioButton();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBdate = new JBControls.TextBox();
            this.ptxNobrB = new JBControls.PopupTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ptxNobrE = new JBControls.PopupTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.ptxRoteB = new JBControls.PopupTextBox();
            this.ptxRoteE = new JBControls.PopupTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEdate = new JBControls.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.hCODEBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.hCODEBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.hCODEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hCODETableAdapter = new JBHR.Att.dsAttTableAdapters.HCODETableAdapter();
            this.oTRCDTableAdapter = new JBHR.Att.dsAttTableAdapters.OTRCDTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dEPTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEPTBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rOTEBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rOTEBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rOTEBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oTRCDBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gpbType.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hCODEBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hCODEBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hCODEBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dEPTBindingSource
            // 
            this.dEPTBindingSource.DataMember = "DEPT";
            this.dEPTBindingSource.DataSource = this.dsBas;
            // 
            // dsBas
            // 
            this.dsBas.DataSetName = "dsBas";
            this.dsBas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bASEBindingSource
            // 
            this.bASEBindingSource.DataMember = "BASE";
            this.bASEBindingSource.DataSource = this.dsBas;
            // 
            // dEPTBindingSource1
            // 
            this.dEPTBindingSource1.DataMember = "DEPT";
            this.dEPTBindingSource1.DataSource = this.dsBas;
            // 
            // bASEBindingSource1
            // 
            this.bASEBindingSource1.DataMember = "BASE";
            this.bASEBindingSource1.DataSource = this.dsBas;
            // 
            // rOTEBindingSource1
            // 
            this.rOTEBindingSource1.DataMember = "ROTE";
            this.rOTEBindingSource1.DataSource = this.dsAtt;
            // 
            // dsAtt
            // 
            this.dsAtt.DataSetName = "dsAtt";
            this.dsAtt.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.dsAtt.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rOTEBindingSource2
            // 
            this.rOTEBindingSource2.DataMember = "ROTE";
            this.rOTEBindingSource2.DataSource = this.dsAtt;
            // 
            // bASETableAdapter
            // 
            this.bASETableAdapter.ClearBeforeFill = true;
            // 
            // dEPTTableAdapter
            // 
            this.dEPTTableAdapter.ClearBeforeFill = true;
            // 
            // rOTEBindingSource
            // 
            this.rOTEBindingSource.DataMember = "ROTE";
            this.rOTEBindingSource.DataSource = this.dsAtt;
            // 
            // rOTETableAdapter
            // 
            this.rOTETableAdapter.ClearBeforeFill = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.chkSysOt);
            this.panel1.Controls.Add(this.cbxOtrcd);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtNote);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.gpbType);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnDel);
            this.panel1.Controls.Add(this.btnRun);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(453, 337);
            this.panel1.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(43, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 37;
            this.label7.Text = "身分別";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rb33);
            this.groupBox2.Controls.Add(this.rb32);
            this.groupBox2.Controls.Add(this.rb31);
            this.groupBox2.Location = new System.Drawing.Point(91, 134);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(341, 32);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            // 
            // rb33
            // 
            this.rb33.AutoSize = true;
            this.rb33.Checked = true;
            this.rb33.Location = new System.Drawing.Point(125, 10);
            this.rb33.Name = "rb33";
            this.rb33.Size = new System.Drawing.Size(47, 16);
            this.rb33.TabIndex = 1;
            this.rb33.TabStop = true;
            this.rb33.Text = "外勞";
            this.rb33.UseVisualStyleBackColor = true;
            // 
            // rb32
            // 
            this.rb32.AutoSize = true;
            this.rb32.Location = new System.Drawing.Point(60, 10);
            this.rb32.Name = "rb32";
            this.rb32.Size = new System.Drawing.Size(47, 16);
            this.rb32.TabIndex = 1;
            this.rb32.Tag = "上班前";
            this.rb32.Text = "本勞";
            this.rb32.UseVisualStyleBackColor = true;
            // 
            // rb31
            // 
            this.rb31.AutoSize = true;
            this.rb31.Location = new System.Drawing.Point(7, 10);
            this.rb31.Name = "rb31";
            this.rb31.Size = new System.Drawing.Size(47, 16);
            this.rb31.TabIndex = 0;
            this.rb31.Text = "全部";
            this.rb31.UseVisualStyleBackColor = true;
            // 
            // chkSysOt
            // 
            this.chkSysOt.AutoSize = true;
            this.chkSysOt.CaptionLabel = null;
            this.chkSysOt.Checked = true;
            this.chkSysOt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSysOt.IsImitateCaption = true;
            this.chkSysOt.Location = new System.Drawing.Point(237, 242);
            this.chkSysOt.Name = "chkSysOt";
            this.chkSysOt.Size = new System.Drawing.Size(48, 16);
            this.chkSysOt.TabIndex = 36;
            this.chkSysOt.Text = "假日";
            this.chkSysOt.UseVisualStyleBackColor = true;
            // 
            // cbxOtrcd
            // 
            this.cbxOtrcd.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.cbxOtrcd.BackColor = System.Drawing.SystemColors.Control;
            this.cbxOtrcd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cbxOtrcd.CaptionLabel = null;
            this.cbxOtrcd.DataSource = this.oTRCDBindingSource;
            this.cbxOtrcd.DisplayMember = "otrname";
            this.cbxOtrcd.DropDownCount = 10;
            this.cbxOtrcd.IsDisplayValueLabel = true;
            this.cbxOtrcd.IsEmpty = true;
            this.cbxOtrcd.Location = new System.Drawing.Point(92, 238);
            this.cbxOtrcd.Name = "cbxOtrcd";
            this.cbxOtrcd.SelectedValue = "";
            this.cbxOtrcd.Size = new System.Drawing.Size(124, 22);
            this.cbxOtrcd.TabIndex = 35;
            this.cbxOtrcd.ValueMember = "otrcd";
            // 
            // oTRCDBindingSource
            // 
            this.oTRCDBindingSource.DataMember = "OTRCD";
            this.oTRCDBindingSource.DataSource = this.dsAtt;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(54, 271);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 34;
            this.label10.Text = "備註";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 243);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 34;
            this.label8.Text = "加班原因";
            // 
            // txtNote
            // 
            this.txtNote.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtNote.CaptionLabel = null;
            this.txtNote.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtNote.DecimalPlace = 2;
            this.txtNote.IsEmpty = true;
            this.txtNote.Location = new System.Drawing.Point(92, 266);
            this.txtNote.Mask = "";
            this.txtNote.MaxLength = -1;
            this.txtNote.Name = "txtNote";
            this.txtNote.PasswordChar = '\0';
            this.txtNote.ReadOnly = false;
            this.txtNote.Size = new System.Drawing.Size(284, 22);
            this.txtNote.TabIndex = 33;
            this.txtNote.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 29;
            this.label4.Text = "時數預設值";
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(21, 179);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 29;
            this.label16.Text = "轉換預設值";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb23);
            this.groupBox1.Controls.Add(this.rb22);
            this.groupBox1.Controls.Add(this.rb21);
            this.groupBox1.Location = new System.Drawing.Point(91, 201);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(341, 32);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            // 
            // rb23
            // 
            this.rb23.AutoSize = true;
            this.rb23.Location = new System.Drawing.Point(210, 10);
            this.rb23.Name = "rb23";
            this.rb23.Size = new System.Drawing.Size(125, 16);
            this.rb23.TabIndex = 1;
            this.rb23.Text = "建議時數=補休時數";
            this.rb23.UseVisualStyleBackColor = true;
            // 
            // rb22
            // 
            this.rb22.AutoSize = true;
            this.rb22.Checked = true;
            this.rb22.Location = new System.Drawing.Point(84, 10);
            this.rb22.Name = "rb22";
            this.rb22.Size = new System.Drawing.Size(125, 16);
            this.rb22.TabIndex = 1;
            this.rb22.TabStop = true;
            this.rb22.Text = "建議時數=加班時數";
            this.rb22.UseVisualStyleBackColor = true;
            // 
            // rb21
            // 
            this.rb21.AutoSize = true;
            this.rb21.Location = new System.Drawing.Point(7, 10);
            this.rb21.Name = "rb21";
            this.rb21.Size = new System.Drawing.Size(71, 16);
            this.rb21.TabIndex = 0;
            this.rb21.Text = "不要預設";
            this.rb21.UseVisualStyleBackColor = true;
            // 
            // gpbType
            // 
            this.gpbType.Controls.Add(this.rb12);
            this.gpbType.Controls.Add(this.rb11);
            this.gpbType.Location = new System.Drawing.Point(92, 167);
            this.gpbType.Name = "gpbType";
            this.gpbType.Size = new System.Drawing.Size(340, 32);
            this.gpbType.TabIndex = 32;
            this.gpbType.TabStop = false;
            // 
            // rb12
            // 
            this.rb12.AutoSize = true;
            this.rb12.Checked = true;
            this.rb12.Location = new System.Drawing.Point(84, 10);
            this.rb12.Name = "rb12";
            this.rb12.Size = new System.Drawing.Size(59, 16);
            this.rb12.TabIndex = 1;
            this.rb12.TabStop = true;
            this.rb12.Text = "要轉換";
            this.rb12.UseVisualStyleBackColor = true;
            // 
            // rb11
            // 
            this.rb11.AutoSize = true;
            this.rb11.Location = new System.Drawing.Point(7, 10);
            this.rb11.Name = "rb11";
            this.rb11.Size = new System.Drawing.Size(59, 16);
            this.rb11.TabIndex = 0;
            this.rb11.Text = "不轉換";
            this.rb11.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(292, 302);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 28;
            this.btnExit.Text = "離開";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(184, 302);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 27;
            this.btnDel.Text = "刪除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(70, 302);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 27;
            this.btnRun.Text = "新增";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtBdate, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.ptxNobrB, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.ptxNobrE, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label14, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ptxRoteB, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.ptxRoteE, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label15, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtEdate, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.label9, 2, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(30, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(347, 118);
            this.tableLayoutPanel1.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "部門代碼";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "員工編號";
            // 
            // txtBdate
            // 
            this.txtBdate.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtBdate.CaptionLabel = null;
            this.txtBdate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtBdate.DecimalPlace = 2;
            this.txtBdate.IsEmpty = true;
            this.txtBdate.Location = new System.Drawing.Point(62, 87);
            this.txtBdate.Mask = "0000/00/00";
            this.txtBdate.MaxLength = -1;
            this.txtBdate.Name = "txtBdate";
            this.txtBdate.PasswordChar = '\0';
            this.txtBdate.ReadOnly = false;
            this.txtBdate.Size = new System.Drawing.Size(71, 22);
            this.txtBdate.TabIndex = 24;
            this.txtBdate.ValidType = JBControls.TextBox.EValidType.Date;
            this.txtBdate.Validated += new System.EventHandler(this.txtBdate_Validated);
            // 
            // ptxNobrB
            // 
            this.ptxNobrB.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ptxNobrB.CaptionLabel = null;
            this.ptxNobrB.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ptxNobrB.DataSource = this.bASEBindingSource;
            this.ptxNobrB.DisplayMember = "name_c";
            this.ptxNobrB.IsEmpty = true;
            this.ptxNobrB.IsEmptyToQuery = true;
            this.ptxNobrB.IsMustBeFound = true;
            this.ptxNobrB.LabelText = "";
            this.ptxNobrB.Location = new System.Drawing.Point(62, 3);
            this.ptxNobrB.Name = "ptxNobrB";
            this.ptxNobrB.ReadOnly = false;
            this.ptxNobrB.Size = new System.Drawing.Size(59, 22);
            this.ptxNobrB.TabIndex = 16;
            this.ptxNobrB.ValueMember = "nobr";
            this.ptxNobrB.WhereCmd = "";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(192, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "至";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(192, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "至";
            // 
            // ptxNobrE
            // 
            this.ptxNobrE.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ptxNobrE.CaptionLabel = null;
            this.ptxNobrE.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ptxNobrE.DataSource = this.bASEBindingSource1;
            this.ptxNobrE.DisplayMember = "name_c";
            this.ptxNobrE.IsEmpty = true;
            this.ptxNobrE.IsEmptyToQuery = true;
            this.ptxNobrE.IsMustBeFound = true;
            this.ptxNobrE.LabelText = "";
            this.ptxNobrE.Location = new System.Drawing.Point(215, 3);
            this.ptxNobrE.Name = "ptxNobrE";
            this.ptxNobrE.ReadOnly = false;
            this.ptxNobrE.Size = new System.Drawing.Size(59, 22);
            this.ptxNobrE.TabIndex = 16;
            this.ptxNobrE.ValueMember = "nobr";
            this.ptxNobrE.WhereCmd = "";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 63);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 2;
            this.label14.Text = "班別代碼";
            // 
            // ptxRoteB
            // 
            this.ptxRoteB.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ptxRoteB.CaptionLabel = null;
            this.ptxRoteB.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ptxRoteB.DataSource = this.rOTEBindingSource1;
            this.ptxRoteB.DisplayMember = "rotename";
            this.ptxRoteB.IsEmpty = true;
            this.ptxRoteB.IsEmptyToQuery = true;
            this.ptxRoteB.IsMustBeFound = true;
            this.ptxRoteB.LabelText = "";
            this.ptxRoteB.Location = new System.Drawing.Point(62, 58);
            this.ptxRoteB.Name = "ptxRoteB";
            this.ptxRoteB.ReadOnly = false;
            this.ptxRoteB.Size = new System.Drawing.Size(59, 22);
            this.ptxRoteB.TabIndex = 16;
            this.ptxRoteB.ValueMember = "rote";
            this.ptxRoteB.WhereCmd = "";
            // 
            // ptxRoteE
            // 
            this.ptxRoteE.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ptxRoteE.CaptionLabel = null;
            this.ptxRoteE.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ptxRoteE.DataSource = this.rOTEBindingSource2;
            this.ptxRoteE.DisplayMember = "rotename";
            this.ptxRoteE.IsEmpty = true;
            this.ptxRoteE.IsEmptyToQuery = true;
            this.ptxRoteE.IsMustBeFound = true;
            this.ptxRoteE.LabelText = "";
            this.ptxRoteE.Location = new System.Drawing.Point(215, 58);
            this.ptxRoteE.Name = "ptxRoteE";
            this.ptxRoteE.ReadOnly = false;
            this.ptxRoteE.Size = new System.Drawing.Size(59, 22);
            this.ptxRoteE.TabIndex = 16;
            this.ptxRoteE.ValueMember = "rote";
            this.ptxRoteE.WhereCmd = "";
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(192, 63);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(17, 12);
            this.label15.TabIndex = 5;
            this.label15.Text = "至";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "出勤日期";
            // 
            // txtEdate
            // 
            this.txtEdate.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtEdate.CaptionLabel = null;
            this.txtEdate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtEdate.DecimalPlace = 2;
            this.txtEdate.IsEmpty = true;
            this.txtEdate.Location = new System.Drawing.Point(215, 87);
            this.txtEdate.Mask = "0000/00/00";
            this.txtEdate.MaxLength = -1;
            this.txtEdate.Name = "txtEdate";
            this.txtEdate.PasswordChar = '\0';
            this.txtEdate.ReadOnly = false;
            this.txtEdate.Size = new System.Drawing.Size(71, 22);
            this.txtEdate.TabIndex = 24;
            this.txtEdate.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(192, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 5;
            this.label9.Text = "至";
            // 
            // hCODEBindingSource2
            // 
            this.hCODEBindingSource2.DataMember = "HCODE";
            this.hCODEBindingSource2.DataSource = this.dsAtt;
            // 
            // hCODEBindingSource1
            // 
            this.hCODEBindingSource1.DataMember = "HCODE";
            this.hCODEBindingSource1.DataSource = this.dsAtt;
            // 
            // hCODEBindingSource
            // 
            this.hCODEBindingSource.DataMember = "HCODE";
            this.hCODEBindingSource.DataSource = this.dsAtt;
            // 
            // hCODETableAdapter
            // 
            this.hCODETableAdapter.ClearBeforeFill = true;
            // 
            // oTRCDTableAdapter
            // 
            this.oTRCDTableAdapter.ClearBeforeFill = true;
            // 
            // FRM2JBB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 337);
            this.Controls.Add(this.panel1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "FRM2JBB";
            this.Text = "FRM2JBB";
            this.Load += new System.EventHandler(this.FRM2O_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dEPTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEPTBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rOTEBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rOTEBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rOTEBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.oTRCDBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpbType.ResumeLayout(false);
            this.gpbType.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hCODEBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hCODEBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hCODEBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private dsBas dsBas;
        private System.Windows.Forms.BindingSource bASEBindingSource;
        private JBHR.Att.dsBasTableAdapters.BASETableAdapter bASETableAdapter;
        private System.Windows.Forms.BindingSource bASEBindingSource1;
        private System.Windows.Forms.BindingSource dEPTBindingSource;
        private JBHR.Att.dsBasTableAdapters.DEPTTableAdapter dEPTTableAdapter;
        private System.Windows.Forms.BindingSource dEPTBindingSource1;
        private dsAtt dsAtt;
        private System.Windows.Forms.BindingSource rOTEBindingSource;
        private JBHR.Att.dsAttTableAdapters.ROTETableAdapter rOTETableAdapter;
        private System.Windows.Forms.BindingSource rOTEBindingSource1;
        private System.Windows.Forms.BindingSource rOTEBindingSource2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox gpbType;
        private System.Windows.Forms.RadioButton rb12;
        private System.Windows.Forms.RadioButton rb11;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private JBControls.PopupTextBox ptxNobrB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private JBControls.PopupTextBox ptxNobrE;
        private System.Windows.Forms.Label label14;
        private JBControls.PopupTextBox ptxRoteB;
        private JBControls.PopupTextBox ptxRoteE;
        private System.Windows.Forms.Label label15;
        private JBControls.TextBox txtBdate;
        private System.Windows.Forms.Label label1;
        private JBControls.TextBox txtEdate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.BindingSource hCODEBindingSource;
        private JBHR.Att.dsAttTableAdapters.HCODETableAdapter hCODETableAdapter;
        private System.Windows.Forms.BindingSource hCODEBindingSource1;
        private System.Windows.Forms.BindingSource hCODEBindingSource2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb22;
        private System.Windows.Forms.RadioButton rb21;
        private System.Windows.Forms.RadioButton rb23;
        private JBControls.ComboBox cbxOtrcd;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private JBControls.TextBox txtNote;
        private System.Windows.Forms.BindingSource oTRCDBindingSource;
        private JBHR.Att.dsAttTableAdapters.OTRCDTableAdapter oTRCDTableAdapter;
        private JBControls.CheckBox chkSysOt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rb33;
        private System.Windows.Forms.RadioButton rb32;
        private System.Windows.Forms.RadioButton rb31;
    }
}