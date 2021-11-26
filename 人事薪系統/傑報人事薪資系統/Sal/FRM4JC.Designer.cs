namespace JBHR.Sal
{
    partial class FRM4JC
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM4JC));
            this.txtCont = new System.Windows.Forms.TextBox();
            this.btnCalc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbAns = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.cbxNobr = new System.Windows.Forms.ComboBox();
            this.txtCalcAttDateE = new JBControls.TextBox();
            this.txtCalcAttDateB = new JBControls.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxItemAuto = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnEditSalFunction = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCalcSalDateE = new JBControls.TextBox();
            this.txtCalcSalDateB = new JBControls.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtYYMM = new System.Windows.Forms.TextBox();
            this.btnYYMM_Prev = new System.Windows.Forms.Button();
            this.btnYYMM_Next = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.cbxCALCTYPE = new System.Windows.Forms.ComboBox();
            this.btnCalcType_Prev = new System.Windows.Forms.Button();
            this.btnCalcType_Next = new System.Windows.Forms.Button();
            this.btnUpdateScript = new System.Windows.Forms.Button();
            this.btnReadScript = new System.Windows.Forms.Button();
            this.dgvSalBase = new System.Windows.Forms.DataGridView();
            this.txtDCont = new System.Windows.Forms.TextBox();
            this.btnCalcAll = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCont_big = new System.Windows.Forms.Button();
            this.btnCont_small = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.lbFontSize = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalBase)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCont
            // 
            this.txtCont.AcceptsReturn = true;
            this.txtCont.AcceptsTab = true;
            this.txtCont.AllowDrop = true;
            this.txtCont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCont.Location = new System.Drawing.Point(2, 32);
            this.txtCont.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtCont.Multiline = true;
            this.txtCont.Name = "txtCont";
            this.txtCont.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCont.Size = new System.Drawing.Size(322, 138);
            this.txtCont.TabIndex = 0;
            this.txtCont.WordWrap = false;
            // 
            // btnCalc
            // 
            this.btnCalc.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCalc.Location = new System.Drawing.Point(253, 3);
            this.btnCalc.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(67, 25);
            this.btnCalc.TabIndex = 1;
            this.btnCalc.Text = "計算";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(2, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "=";
            // 
            // lbAns
            // 
            this.lbAns.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbAns.AutoSize = true;
            this.lbAns.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbAns.Location = new System.Drawing.Point(28, 0);
            this.lbAns.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbAns.Name = "lbAns";
            this.lbAns.Size = new System.Drawing.Size(19, 22);
            this.lbAns.TabIndex = 3;
            this.lbAns.Text = "?";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "工號";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 59);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "出勤起日";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.2766F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.45745F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.21277F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0295F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.46903F));
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cbxNobr, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtCalcAttDateE, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtCalcAttDateB, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.cbxItemAuto, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.btnEditSalFunction, 4, 5);
            this.tableLayoutPanel2.Controls.Add(this.label9, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.label10, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtCalcSalDateE, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtCalcSalDateB, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel2, 1, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 9;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(284, 240);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // cbxNobr
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.cbxNobr, 3);
            this.cbxNobr.FormattingEnabled = true;
            this.cbxNobr.Location = new System.Drawing.Point(62, 3);
            this.cbxNobr.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbxNobr.Name = "cbxNobr";
            this.cbxNobr.Size = new System.Drawing.Size(116, 20);
            this.cbxNobr.TabIndex = 9;
            // 
            // txtCalcAttDateE
            // 
            this.txtCalcAttDateE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCalcAttDateE.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtCalcAttDateE.CaptionLabel = null;
            this.txtCalcAttDateE.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtCalcAttDateE.DecimalPlace = 2;
            this.txtCalcAttDateE.IsEmpty = true;
            this.txtCalcAttDateE.Location = new System.Drawing.Point(62, 81);
            this.txtCalcAttDateE.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtCalcAttDateE.Mask = "0000/00/00";
            this.txtCalcAttDateE.MaxLength = -1;
            this.txtCalcAttDateE.Name = "txtCalcAttDateE";
            this.txtCalcAttDateE.PasswordChar = '\0';
            this.txtCalcAttDateE.ReadOnly = false;
            this.txtCalcAttDateE.ShowCalendarButton = true;
            this.txtCalcAttDateE.Size = new System.Drawing.Size(74, 22);
            this.txtCalcAttDateE.TabIndex = 7;
            this.txtCalcAttDateE.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // txtCalcAttDateB
            // 
            this.txtCalcAttDateB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCalcAttDateB.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtCalcAttDateB.CaptionLabel = null;
            this.txtCalcAttDateB.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtCalcAttDateB.DecimalPlace = 2;
            this.txtCalcAttDateB.IsEmpty = true;
            this.txtCalcAttDateB.Location = new System.Drawing.Point(62, 55);
            this.txtCalcAttDateB.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtCalcAttDateB.Mask = "0000/00/00";
            this.txtCalcAttDateB.MaxLength = -1;
            this.txtCalcAttDateB.Name = "txtCalcAttDateB";
            this.txtCalcAttDateB.PasswordChar = '\0';
            this.txtCalcAttDateB.ReadOnly = false;
            this.txtCalcAttDateB.ShowCalendarButton = true;
            this.txtCalcAttDateB.Size = new System.Drawing.Size(74, 22);
            this.txtCalcAttDateB.TabIndex = 7;
            this.txtCalcAttDateB.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 85);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "出勤迄日";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 33);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "計薪日期";
            // 
            // cbxItemAuto
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.cbxItemAuto, 3);
            this.cbxItemAuto.FormattingEnabled = true;
            this.cbxItemAuto.Location = new System.Drawing.Point(62, 133);
            this.cbxItemAuto.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbxItemAuto.Name = "cbxItemAuto";
            this.cbxItemAuto.Size = new System.Drawing.Size(152, 20);
            this.cbxItemAuto.TabIndex = 8;
            this.cbxItemAuto.SelectedIndexChanged += new System.EventHandler(this.cbxAuto_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 137);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "計算項目";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 111);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "計算種類";
            // 
            // btnEditSalFunction
            // 
            this.btnEditSalFunction.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnEditSalFunction.Location = new System.Drawing.Point(228, 133);
            this.btnEditSalFunction.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnEditSalFunction.Name = "btnEditSalFunction";
            this.btnEditSalFunction.Size = new System.Drawing.Size(40, 19);
            this.btnEditSalFunction.TabIndex = 11;
            this.btnEditSalFunction.Text = "編輯";
            this.btnEditSalFunction.UseVisualStyleBackColor = true;
            this.btnEditSalFunction.Click += new System.EventHandler(this.btnEditSalFunction_Click);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(143, 59);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 6;
            this.label9.Text = "計薪起日";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(143, 85);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 6;
            this.label10.Text = "計薪迄日";
            // 
            // txtCalcSalDateE
            // 
            this.txtCalcSalDateE.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCalcSalDateE.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtCalcSalDateE.CaptionLabel = null;
            this.txtCalcSalDateE.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tableLayoutPanel2.SetColumnSpan(this.txtCalcSalDateE, 2);
            this.txtCalcSalDateE.DecimalPlace = 2;
            this.txtCalcSalDateE.IsEmpty = true;
            this.txtCalcSalDateE.Location = new System.Drawing.Point(200, 81);
            this.txtCalcSalDateE.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtCalcSalDateE.Mask = "0000/00/00";
            this.txtCalcSalDateE.MaxLength = -1;
            this.txtCalcSalDateE.Name = "txtCalcSalDateE";
            this.txtCalcSalDateE.PasswordChar = '\0';
            this.txtCalcSalDateE.ReadOnly = false;
            this.txtCalcSalDateE.ShowCalendarButton = true;
            this.txtCalcSalDateE.Size = new System.Drawing.Size(73, 22);
            this.txtCalcSalDateE.TabIndex = 7;
            this.txtCalcSalDateE.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // txtCalcSalDateB
            // 
            this.txtCalcSalDateB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCalcSalDateB.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtCalcSalDateB.CaptionLabel = null;
            this.txtCalcSalDateB.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tableLayoutPanel2.SetColumnSpan(this.txtCalcSalDateB, 2);
            this.txtCalcSalDateB.DecimalPlace = 2;
            this.txtCalcSalDateB.IsEmpty = true;
            this.txtCalcSalDateB.Location = new System.Drawing.Point(200, 55);
            this.txtCalcSalDateB.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtCalcSalDateB.Mask = "0000/00/00";
            this.txtCalcSalDateB.MaxLength = -1;
            this.txtCalcSalDateB.Name = "txtCalcSalDateB";
            this.txtCalcSalDateB.PasswordChar = '\0';
            this.txtCalcSalDateB.ReadOnly = false;
            this.txtCalcSalDateB.ShowCalendarButton = true;
            this.txtCalcSalDateB.Size = new System.Drawing.Size(73, 22);
            this.txtCalcSalDateB.TabIndex = 7;
            this.txtCalcSalDateB.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // flowLayoutPanel1
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.flowLayoutPanel1, 2);
            this.flowLayoutPanel1.Controls.Add(this.txtYYMM);
            this.flowLayoutPanel1.Controls.Add(this.btnYYMM_Prev);
            this.flowLayoutPanel1.Controls.Add(this.btnYYMM_Next);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(62, 29);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(133, 20);
            this.flowLayoutPanel1.TabIndex = 13;
            // 
            // txtYYMM
            // 
            this.txtYYMM.Location = new System.Drawing.Point(2, 3);
            this.txtYYMM.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtYYMM.Name = "txtYYMM";
            this.txtYYMM.Size = new System.Drawing.Size(80, 22);
            this.txtYYMM.TabIndex = 10;
            this.txtYYMM.TextChanged += new System.EventHandler(this.txtYYMM_TextChanged);
            // 
            // btnYYMM_Prev
            // 
            this.btnYYMM_Prev.Font = new System.Drawing.Font("新細明體", 9F);
            this.btnYYMM_Prev.Location = new System.Drawing.Point(86, 3);
            this.btnYYMM_Prev.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnYYMM_Prev.Name = "btnYYMM_Prev";
            this.btnYYMM_Prev.Size = new System.Drawing.Size(17, 19);
            this.btnYYMM_Prev.TabIndex = 12;
            this.btnYYMM_Prev.Text = "-";
            this.btnYYMM_Prev.UseVisualStyleBackColor = true;
            this.btnYYMM_Prev.Click += new System.EventHandler(this.btnYYMM_Prev_Click);
            // 
            // btnYYMM_Next
            // 
            this.btnYYMM_Next.Font = new System.Drawing.Font("新細明體", 9F);
            this.btnYYMM_Next.Location = new System.Drawing.Point(107, 3);
            this.btnYYMM_Next.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnYYMM_Next.Name = "btnYYMM_Next";
            this.btnYYMM_Next.Size = new System.Drawing.Size(17, 19);
            this.btnYYMM_Next.TabIndex = 12;
            this.btnYYMM_Next.Text = "+";
            this.btnYYMM_Next.UseVisualStyleBackColor = true;
            this.btnYYMM_Next.Click += new System.EventHandler(this.btnYYMM_Next_Click);
            // 
            // flowLayoutPanel2
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.flowLayoutPanel2, 2);
            this.flowLayoutPanel2.Controls.Add(this.cbxCALCTYPE);
            this.flowLayoutPanel2.Controls.Add(this.btnCalcType_Prev);
            this.flowLayoutPanel2.Controls.Add(this.btnCalcType_Next);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(62, 107);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(133, 20);
            this.flowLayoutPanel2.TabIndex = 14;
            // 
            // cbxCALCTYPE
            // 
            this.cbxCALCTYPE.FormattingEnabled = true;
            this.cbxCALCTYPE.Location = new System.Drawing.Point(2, 3);
            this.cbxCALCTYPE.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbxCALCTYPE.Name = "cbxCALCTYPE";
            this.cbxCALCTYPE.Size = new System.Drawing.Size(80, 20);
            this.cbxCALCTYPE.TabIndex = 8;
            this.cbxCALCTYPE.SelectedIndexChanged += new System.EventHandler(this.cbxCALCTYPE_SelectedIndexChanged);
            // 
            // btnCalcType_Prev
            // 
            this.btnCalcType_Prev.Font = new System.Drawing.Font("新細明體", 9F);
            this.btnCalcType_Prev.Location = new System.Drawing.Point(86, 3);
            this.btnCalcType_Prev.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCalcType_Prev.Name = "btnCalcType_Prev";
            this.btnCalcType_Prev.Size = new System.Drawing.Size(17, 19);
            this.btnCalcType_Prev.TabIndex = 12;
            this.btnCalcType_Prev.Text = "-";
            this.btnCalcType_Prev.UseVisualStyleBackColor = true;
            this.btnCalcType_Prev.Click += new System.EventHandler(this.btnCalcType_Prev_Click);
            // 
            // btnCalcType_Next
            // 
            this.btnCalcType_Next.Font = new System.Drawing.Font("新細明體", 9F);
            this.btnCalcType_Next.Location = new System.Drawing.Point(107, 3);
            this.btnCalcType_Next.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCalcType_Next.Name = "btnCalcType_Next";
            this.btnCalcType_Next.Size = new System.Drawing.Size(17, 19);
            this.btnCalcType_Next.TabIndex = 12;
            this.btnCalcType_Next.Text = "+";
            this.btnCalcType_Next.UseVisualStyleBackColor = true;
            this.btnCalcType_Next.Click += new System.EventHandler(this.btnCalcType_Next_Click);
            // 
            // btnUpdateScript
            // 
            this.btnUpdateScript.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnUpdateScript.Location = new System.Drawing.Point(2, 3);
            this.btnUpdateScript.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnUpdateScript.Name = "btnUpdateScript";
            this.btnUpdateScript.Size = new System.Drawing.Size(74, 25);
            this.btnUpdateScript.TabIndex = 9;
            this.btnUpdateScript.Text = "儲存Script";
            this.btnUpdateScript.UseVisualStyleBackColor = true;
            this.btnUpdateScript.Click += new System.EventHandler(this.btnUpdateScript_Click);
            // 
            // btnReadScript
            // 
            this.btnReadScript.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnReadScript.Location = new System.Drawing.Point(82, 3);
            this.btnReadScript.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnReadScript.Name = "btnReadScript";
            this.btnReadScript.Size = new System.Drawing.Size(74, 25);
            this.btnReadScript.TabIndex = 9;
            this.btnReadScript.Text = "讀取Script";
            this.btnReadScript.UseVisualStyleBackColor = true;
            this.btnReadScript.Click += new System.EventHandler(this.btnReadScript_Click);
            // 
            // dgvSalBase
            // 
            this.dgvSalBase.AllowUserToAddRows = false;
            this.dgvSalBase.AllowUserToDeleteRows = false;
            this.dgvSalBase.AllowUserToResizeColumns = false;
            this.dgvSalBase.AllowUserToResizeRows = false;
            this.dgvSalBase.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSalBase.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSalBase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSalBase.Location = new System.Drawing.Point(2, 3);
            this.dgvSalBase.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgvSalBase.MultiSelect = false;
            this.dgvSalBase.Name = "dgvSalBase";
            this.dgvSalBase.ReadOnly = true;
            this.dgvSalBase.RowHeadersVisible = false;
            this.dgvSalBase.RowHeadersWidth = 62;
            this.dgvSalBase.RowTemplate.Height = 27;
            this.dgvSalBase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvSalBase.ShowCellErrors = false;
            this.dgvSalBase.ShowCellToolTips = false;
            this.dgvSalBase.ShowEditingIcon = false;
            this.dgvSalBase.ShowRowErrors = false;
            this.dgvSalBase.Size = new System.Drawing.Size(148, 354);
            this.dgvSalBase.TabIndex = 10;
            // 
            // txtDCont
            // 
            this.txtDCont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDCont.Location = new System.Drawing.Point(2, 3);
            this.txtDCont.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtDCont.Multiline = true;
            this.txtDCont.Name = "txtDCont";
            this.txtDCont.ReadOnly = true;
            this.txtDCont.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDCont.Size = new System.Drawing.Size(306, 109);
            this.txtDCont.TabIndex = 11;
            this.txtDCont.WordWrap = false;
            // 
            // btnCalcAll
            // 
            this.btnCalcAll.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCalcAll.Location = new System.Drawing.Point(215, 3);
            this.btnCalcAll.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCalcAll.Name = "btnCalcAll";
            this.btnCalcAll.Size = new System.Drawing.Size(67, 33);
            this.btnCalcAll.TabIndex = 13;
            this.btnCalcAll.Text = "全部計算";
            this.btnCalcAll.UseVisualStyleBackColor = true;
            this.btnCalcAll.Click += new System.EventHandler(this.btnCalcAll_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(2, 213);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(322, 138);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel6);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage1.Size = new System.Drawing.Size(314, 112);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "解析公式";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.txtDCont, 0, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(2, 3);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.Size = new System.Drawing.Size(310, 106);
            this.tableLayoutPanel6.TabIndex = 12;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage2.Size = new System.Drawing.Size(314, 113);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "...";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(102, 45);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "整建中...";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.label1);
            this.flowLayoutPanel3.Controls.Add(this.lbAns);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(2, 12);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(90, 24);
            this.flowLayoutPanel3.TabIndex = 15;
            // 
            // btnCont_big
            // 
            this.btnCont_big.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCont_big.Font = new System.Drawing.Font("新細明體", 9F);
            this.btnCont_big.Location = new System.Drawing.Point(136, 3);
            this.btnCont_big.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCont_big.Name = "btnCont_big";
            this.btnCont_big.Size = new System.Drawing.Size(17, 19);
            this.btnCont_big.TabIndex = 12;
            this.btnCont_big.Text = "+";
            this.btnCont_big.UseVisualStyleBackColor = true;
            this.btnCont_big.Click += new System.EventHandler(this.btnCont_big_Click);
            // 
            // btnCont_small
            // 
            this.btnCont_small.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCont_small.Font = new System.Drawing.Font("新細明體", 9F);
            this.btnCont_small.Location = new System.Drawing.Point(115, 3);
            this.btnCont_small.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCont_small.Name = "btnCont_small";
            this.btnCont_small.Size = new System.Drawing.Size(17, 19);
            this.btnCont_small.TabIndex = 12;
            this.btnCont_small.Text = "-";
            this.btnCont_small.UseVisualStyleBackColor = true;
            this.btnCont_small.Click += new System.EventHandler(this.btnCont_small_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.53477F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.46523F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 287F));
            this.tableLayoutPanel1.Controls.Add(this.dgvSalBase, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(770, 360);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.flowLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tabControl1, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.txtCont, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(154, 3);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(326, 354);
            this.tableLayoutPanel3.TabIndex = 11;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.btnCont_big);
            this.flowLayoutPanel4.Controls.Add(this.btnCont_small);
            this.flowLayoutPanel4.Controls.Add(this.lbFontSize);
            this.flowLayoutPanel4.Controls.Add(this.label11);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(169, 3);
            this.flowLayoutPanel4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(155, 23);
            this.flowLayoutPanel4.TabIndex = 0;
            // 
            // lbFontSize
            // 
            this.lbFontSize.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbFontSize.AutoSize = true;
            this.lbFontSize.Location = new System.Drawing.Point(100, 6);
            this.lbFontSize.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbFontSize.Name = "lbFontSize";
            this.lbFontSize.Size = new System.Drawing.Size(11, 12);
            this.lbFontSize.TabIndex = 14;
            this.lbFontSize.Text = "9";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(37, 6);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 12);
            this.label11.TabIndex = 13;
            this.label11.Text = "字體大小 :";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.Controls.Add(this.btnReadScript, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnCalc, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnUpdateScript, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(2, 176);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(322, 31);
            this.tableLayoutPanel4.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel5);
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(484, 3);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 354);
            this.panel1.TabIndex = 12;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.Controls.Add(this.btnCalcAll, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.flowLayoutPanel3, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 315);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(284, 39);
            this.tableLayoutPanel5.TabIndex = 16;
            // 
            // FRM4JC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 360);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "FRM4JC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRM4JC";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalBase)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtCont;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbAns;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private JBControls.TextBox txtCalcAttDateB;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnUpdateScript;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnReadScript;
        private System.Windows.Forms.ComboBox cbxItemAuto;
        private System.Windows.Forms.ComboBox cbxNobr;
        private JBControls.TextBox txtCalcAttDateE;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtYYMM;
        private System.Windows.Forms.ComboBox cbxCALCTYPE;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvSalBase;
        private System.Windows.Forms.TextBox txtDCont;
        private System.Windows.Forms.Button btnEditSalFunction;
        private System.Windows.Forms.Button btnCalcAll;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private JBControls.TextBox txtCalcSalDateE;
        private JBControls.TextBox txtCalcSalDateB;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnYYMM_Prev;
        private System.Windows.Forms.Button btnYYMM_Next;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnCalcType_Prev;
        private System.Windows.Forms.Button btnCalcType_Next;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button btnCont_big;
        private System.Windows.Forms.Button btnCont_small;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label lbFontSize;
        private System.Windows.Forms.Label label11;
    }
}

