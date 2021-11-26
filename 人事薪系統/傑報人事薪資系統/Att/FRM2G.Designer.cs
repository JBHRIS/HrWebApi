namespace JBHR.Att
{
    partial class FRM2G
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnConfig = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnTran = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.chkRote = new JBControls.CheckBox();
            this.chkTime = new JBControls.CheckBox();
            this.chkDel = new JBControls.CheckBox();
            this.chkError = new JBControls.CheckBox();
            this.chkCreateAbs = new JBControls.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDateB = new JBControls.TextBox();
            this.txtDateE = new JBControls.TextBox();
            this.ptxDeptE = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ptxNobrE = new JBControls.PopupTextBox();
            this.bASEBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dsBas = new JBHR.Att.dsBas();
            this.ptxDeptB = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ptxNobrB = new JBControls.PopupTextBox();
            this.bASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxYYMM = new JBControls.TextBox();
            this.chkFixOt = new JBControls.CheckBox();
            this.dEPTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dEPTBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bASETableAdapter = new JBHR.Att.dsBasTableAdapters.BASETableAdapter();
            this.dEPTTableAdapter = new JBHR.Att.dsBasTableAdapters.DEPTTableAdapter();
            this.BW = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.trpState = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEPTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEPTBindingSource1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnConfig);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnTran);
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.chkFixOt);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(501, 239);
            this.panel1.TabIndex = 0;
            // 
            // btnConfig
            // 
            this.btnConfig.BackgroundImage = global::JBHR.Properties.Resources.Settings_icon;
            this.btnConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfig.Location = new System.Drawing.Point(464, 187);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(25, 23);
            this.btnConfig.TabIndex = 33;
            this.btnConfig.TabStop = false;
            this.btnConfig.Tag = "FRM2G";
            this.btnConfig.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(254, 160);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 2;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "X.離開";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnTran
            // 
            this.btnTran.Location = new System.Drawing.Point(172, 160);
            this.btnTran.Name = "btnTran";
            this.btnTran.Size = new System.Drawing.Size(75, 30);
            this.btnTran.TabIndex = 1;
            this.btnTran.Text = "T.轉換";
            this.btnTran.UseVisualStyleBackColor = true;
            this.btnTran.Click += new System.EventHandler(this.btnTran_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tableLayoutPanel2.Controls.Add(this.chkRote, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.chkTime, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.chkDel, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.chkError, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.chkCreateAbs, 4, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(20, 130);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(455, 24);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // chkRote
            // 
            this.chkRote.AutoSize = true;
            this.chkRote.CaptionLabel = null;
            this.chkRote.Checked = true;
            this.chkRote.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRote.IsImitateCaption = true;
            this.chkRote.Location = new System.Drawing.Point(3, 3);
            this.chkRote.Name = "chkRote";
            this.chkRote.Size = new System.Drawing.Size(72, 16);
            this.chkRote.TabIndex = 0;
            this.chkRote.TabStop = false;
            this.chkRote.Text = "轉換班別";
            this.chkRote.UseVisualStyleBackColor = true;
            // 
            // chkTime
            // 
            this.chkTime.AutoSize = true;
            this.chkTime.CaptionLabel = null;
            this.chkTime.Checked = true;
            this.chkTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTime.IsImitateCaption = true;
            this.chkTime.Location = new System.Drawing.Point(81, 3);
            this.chkTime.Name = "chkTime";
            this.chkTime.Size = new System.Drawing.Size(72, 16);
            this.chkTime.TabIndex = 1;
            this.chkTime.TabStop = false;
            this.chkTime.Text = "轉換時間";
            this.chkTime.UseVisualStyleBackColor = true;
            // 
            // chkDel
            // 
            this.chkDel.AutoSize = true;
            this.chkDel.CaptionLabel = null;
            this.chkDel.Checked = true;
            this.chkDel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDel.IsImitateCaption = true;
            this.chkDel.Location = new System.Drawing.Point(237, 3);
            this.chkDel.Name = "chkDel";
            this.chkDel.Size = new System.Drawing.Size(108, 16);
            this.chkDel.TabIndex = 3;
            this.chkDel.TabStop = false;
            this.chkDel.Text = "刪除離職後出勤";
            this.chkDel.UseVisualStyleBackColor = true;
            // 
            // chkError
            // 
            this.chkError.AutoSize = true;
            this.chkError.CaptionLabel = null;
            this.chkError.Checked = true;
            this.chkError.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkError.IsImitateCaption = true;
            this.chkError.Location = new System.Drawing.Point(159, 3);
            this.chkError.Name = "chkError";
            this.chkError.Size = new System.Drawing.Size(72, 16);
            this.chkError.TabIndex = 2;
            this.chkError.TabStop = false;
            this.chkError.Text = "判斷異常";
            this.chkError.UseVisualStyleBackColor = true;
            // 
            // chkCreateAbs
            // 
            this.chkCreateAbs.AutoSize = true;
            this.chkCreateAbs.CaptionLabel = null;
            this.chkCreateAbs.IsImitateCaption = true;
            this.chkCreateAbs.Location = new System.Drawing.Point(351, 3);
            this.chkCreateAbs.Name = "chkCreateAbs";
            this.chkCreateAbs.Size = new System.Drawing.Size(72, 16);
            this.chkCreateAbs.TabIndex = 4;
            this.chkCreateAbs.TabStop = false;
            this.chkCreateAbs.Text = "產生請假";
            this.chkCreateAbs.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtDateB, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtDateE, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.ptxDeptE, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.ptxNobrE, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.ptxDeptB, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ptxNobrB, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxYYMM, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(347, 112);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "日　　期";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(192, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "至";
            // 
            // txtDateB
            // 
            this.txtDateB.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtDateB.CaptionLabel = null;
            this.txtDateB.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDateB.DecimalPlace = 2;
            this.txtDateB.IsEmpty = true;
            this.txtDateB.Location = new System.Drawing.Point(62, 3);
            this.txtDateB.Mask = "0000/00/00";
            this.txtDateB.MaxLength = -1;
            this.txtDateB.Name = "txtDateB";
            this.txtDateB.PasswordChar = '\0';
            this.txtDateB.ReadOnly = false;
            this.txtDateB.ShowCalendarButton = true;
            this.txtDateB.Size = new System.Drawing.Size(67, 22);
            this.txtDateB.TabIndex = 0;
            this.txtDateB.ValidType = JBControls.TextBox.EValidType.Date;
            this.txtDateB.Validated += new System.EventHandler(this.txtDateB_Validated);
            // 
            // txtDateE
            // 
            this.txtDateE.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtDateE.CaptionLabel = null;
            this.txtDateE.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDateE.DecimalPlace = 2;
            this.txtDateE.IsEmpty = true;
            this.txtDateE.Location = new System.Drawing.Point(215, 3);
            this.txtDateE.Mask = "0000/00/00";
            this.txtDateE.MaxLength = -1;
            this.txtDateE.Name = "txtDateE";
            this.txtDateE.PasswordChar = '\0';
            this.txtDateE.ReadOnly = false;
            this.txtDateE.ShowCalendarButton = true;
            this.txtDateE.Size = new System.Drawing.Size(67, 22);
            this.txtDateE.TabIndex = 1;
            this.txtDateE.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // ptxDeptE
            // 
            this.ptxDeptE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ptxDeptE.FormattingEnabled = true;
            this.ptxDeptE.Location = new System.Drawing.Point(215, 87);
            this.ptxDeptE.Name = "ptxDeptE";
            this.ptxDeptE.Size = new System.Drawing.Size(121, 20);
            this.ptxDeptE.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(192, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "至";
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
            this.ptxNobrE.Location = new System.Drawing.Point(215, 59);
            this.ptxNobrE.Name = "ptxNobrE";
            this.ptxNobrE.ReadOnly = false;
            this.ptxNobrE.ShowDisplayName = true;
            this.ptxNobrE.Size = new System.Drawing.Size(67, 22);
            this.ptxNobrE.TabIndex = 4;
            this.ptxNobrE.ValueMember = "nobr";
            this.ptxNobrE.WhereCmd = "";
            // 
            // bASEBindingSource1
            // 
            this.bASEBindingSource1.DataMember = "BASE";
            this.bASEBindingSource1.DataSource = this.dsBas;
            // 
            // dsBas
            // 
            this.dsBas.DataSetName = "dsBas";
            this.dsBas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ptxDeptB
            // 
            this.ptxDeptB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ptxDeptB.FormattingEnabled = true;
            this.ptxDeptB.Location = new System.Drawing.Point(62, 87);
            this.ptxDeptB.Name = "ptxDeptB";
            this.ptxDeptB.Size = new System.Drawing.Size(121, 20);
            this.ptxDeptB.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "部門代碼";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "員工編號";
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
            this.ptxNobrB.Location = new System.Drawing.Point(62, 59);
            this.ptxNobrB.Name = "ptxNobrB";
            this.ptxNobrB.ReadOnly = false;
            this.ptxNobrB.ShowDisplayName = true;
            this.ptxNobrB.Size = new System.Drawing.Size(67, 22);
            this.ptxNobrB.TabIndex = 3;
            this.ptxNobrB.ValueMember = "nobr";
            this.ptxNobrB.WhereCmd = "";
            // 
            // bASEBindingSource
            // 
            this.bASEBindingSource.DataMember = "BASE";
            this.bASEBindingSource.DataSource = this.dsBas;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "計薪年月";
            // 
            // textBoxYYMM
            // 
            this.textBoxYYMM.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxYYMM.CaptionLabel = null;
            this.textBoxYYMM.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxYYMM.DecimalPlace = 2;
            this.textBoxYYMM.IsEmpty = true;
            this.textBoxYYMM.Location = new System.Drawing.Point(62, 31);
            this.textBoxYYMM.Mask = "";
            this.textBoxYYMM.MaxLength = -1;
            this.textBoxYYMM.Name = "textBoxYYMM";
            this.textBoxYYMM.PasswordChar = '\0';
            this.textBoxYYMM.ReadOnly = false;
            this.textBoxYYMM.ShowCalendarButton = true;
            this.textBoxYYMM.Size = new System.Drawing.Size(67, 22);
            this.textBoxYYMM.TabIndex = 2;
            this.textBoxYYMM.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // chkFixOt
            // 
            this.chkFixOt.AutoSize = true;
            this.chkFixOt.CaptionLabel = null;
            this.chkFixOt.IsImitateCaption = true;
            this.chkFixOt.Location = new System.Drawing.Point(371, 108);
            this.chkFixOt.Name = "chkFixOt";
            this.chkFixOt.Size = new System.Drawing.Size(96, 16);
            this.chkFixOt.TabIndex = 4;
            this.chkFixOt.TabStop = false;
            this.chkFixOt.Text = "產生固定加班";
            this.chkFixOt.UseVisualStyleBackColor = true;
            // 
            // dEPTBindingSource
            // 
            this.dEPTBindingSource.DataMember = "DEPT";
            this.dEPTBindingSource.DataSource = this.dsBas;
            // 
            // dEPTBindingSource1
            // 
            this.dEPTBindingSource1.DataMember = "DEPT";
            this.dEPTBindingSource1.DataSource = this.dsBas;
            // 
            // bASETableAdapter
            // 
            this.bASETableAdapter.ClearBeforeFill = true;
            // 
            // dEPTTableAdapter
            // 
            this.dEPTTableAdapter.ClearBeforeFill = true;
            // 
            // BW
            // 
            this.BW.WorkerReportsProgress = true;
            this.BW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BW_DoWork);
            this.BW.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BW_ProgressChanged);
            this.BW.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BW_RunWorkerCompleted);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1,
            this.trpState});
            this.statusStrip1.Location = new System.Drawing.Point(0, 211);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(501, 28);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.AutoToolTip = true;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(150, 22);
            this.toolStripProgressBar1.Tag = "";
            this.toolStripProgressBar1.ToolTipText = "123";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(16, 23);
            this.toolStripStatusLabel1.Text = " | ";
            // 
            // trpState
            // 
            this.trpState.Name = "trpState";
            this.trpState.Size = new System.Drawing.Size(31, 23);
            this.trpState.Text = "等待";
            // 
            // FRM2G
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 239);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "FRM2G";
            this.Text = "FRM2G";
            this.Load += new System.EventHandler(this.FRM2G_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEPTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEPTBindingSource1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private JBControls.TextBox txtDateB;
        private JBControls.TextBox txtDateE;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private JBControls.CheckBox chkRote;
        private JBControls.CheckBox chkTime;
        private JBControls.CheckBox chkError;
        private JBControls.CheckBox chkDel;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnTran;
        private JBControls.PopupTextBox ptxNobrB;
        private JBControls.PopupTextBox ptxNobrE;
        private dsBas dsBas;
        private System.Windows.Forms.BindingSource bASEBindingSource;
        private JBHR.Att.dsBasTableAdapters.BASETableAdapter bASETableAdapter;
        private System.Windows.Forms.BindingSource bASEBindingSource1;
        private System.Windows.Forms.BindingSource dEPTBindingSource;
        private JBHR.Att.dsBasTableAdapters.DEPTTableAdapter dEPTTableAdapter;
        private System.Windows.Forms.BindingSource dEPTBindingSource1;
        private System.ComponentModel.BackgroundWorker BW;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel trpState;
        private JBControls.CheckBox chkFixOt;
        private System.Windows.Forms.ComboBox ptxDeptE;
        private System.Windows.Forms.ComboBox ptxDeptB;
        private JBControls.CheckBox chkCreateAbs;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Label label7;
        private JBControls.TextBox textBoxYYMM;
    }
}