namespace JBHR.Att
{
    partial class FRM2FA
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnTran = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.uSYS7BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainDS = new JBHR.Sys.SysDS();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblNobr = new System.Windows.Forms.Label();
            this.lblSNO = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblTemperature = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRowCount = new JBControls.TextBox();
            this.txtSuccess = new JBControls.TextBox();
            this.txtRepeat = new JBControls.TextBox();
            this.txtNoTran = new JBControls.TextBox();
            this.txtError = new JBControls.TextBox();
            this.txtAlert = new JBControls.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPath = new JBControls.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new JBControls.DataGridView();
            this.cARDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsAtt = new JBHR.Att.dsAtt();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnInsertAll = new System.Windows.Forms.Button();
            this.btnOverWrite = new System.Windows.Forms.Button();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.cARDTMPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cARDTMPTableAdapter = new JBHR.Att.dsAttTableAdapters.CARDTMPTableAdapter();
            this.cARDTableAdapter = new JBHR.Att.dsAttTableAdapters.CARDTableAdapter();
            this.u_SYS7TableAdapter = new JBHR.Sys.SysDSTableAdapters.U_SYS7TableAdapter();
            this.nOBRDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oNTIMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cARDNODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.temperature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uSYS7BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDS)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cARDBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cARDTMPBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(2, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(642, 449);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.btnTran);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.tableLayoutPanel3);
            this.tabPage1.Controls.Add(this.txtNote);
            this.tabPage1.Controls.Add(this.tableLayoutPanel2);
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(634, 423);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "刷卡設定";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Location = new System.Drawing.Point(13, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 67);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "說明";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "進行資料轉入。";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(413, 12);
            this.label13.TabIndex = 0;
            this.label13.Text = "選取要轉入的刷卡檔案後，下方會顯示檔案格式，如果正確無誤的話再按轉換";
            // 
            // btnTran
            // 
            this.btnTran.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnTran.Location = new System.Drawing.Point(398, 60);
            this.btnTran.Name = "btnTran";
            this.btnTran.Size = new System.Drawing.Size(68, 22);
            this.btnTran.TabIndex = 4;
            this.btnTran.Text = "T.轉換";
            this.btnTran.UseVisualStyleBackColor = true;
            this.btnTran.Click += new System.EventHandler(this.btnTran_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.uSYS7BindingSource;
            this.comboBox1.DisplayMember = "CARD_NAME";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(398, 39);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(48, 20);
            this.comboBox1.TabIndex = 11;
            this.comboBox1.ValueMember = "AUTO";
            this.comboBox1.Visible = false;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChange);
            // 
            // uSYS7BindingSource
            // 
            this.uSYS7BindingSource.DataMember = "U_SYS7";
            this.uSYS7BindingSource.DataSource = this.mainDS;
            // 
            // mainDS
            // 
            this.mainDS.DataSetName = "MainDS";
            this.mainDS.Locale = new System.Globalization.CultureInfo("");
            this.mainDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label10, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label11, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.label12, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblDate, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblNobr, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblSNO, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblTime, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.label14, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblTemperature, 4, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 39);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(388, 41);
            this.tableLayoutPanel3.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 7;
            this.label9.Text = "日期";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(80, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 7;
            this.label10.Text = "工號";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(157, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 7;
            this.label11.Text = "序號";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(234, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 7;
            this.label12.Text = "時間";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(3, 16);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(41, 12);
            this.lblDate.TabIndex = 7;
            this.lblDate.Text = "------";
            // 
            // lblNobr
            // 
            this.lblNobr.AutoSize = true;
            this.lblNobr.Location = new System.Drawing.Point(80, 16);
            this.lblNobr.Name = "lblNobr";
            this.lblNobr.Size = new System.Drawing.Size(41, 12);
            this.lblNobr.TabIndex = 7;
            this.lblNobr.Text = "------";
            // 
            // lblSNO
            // 
            this.lblSNO.AutoSize = true;
            this.lblSNO.Location = new System.Drawing.Point(157, 16);
            this.lblSNO.Name = "lblSNO";
            this.lblSNO.Size = new System.Drawing.Size(41, 12);
            this.lblSNO.TabIndex = 7;
            this.lblSNO.Text = "------";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(234, 16);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(41, 12);
            this.lblTime.TabIndex = 7;
            this.lblTime.Text = "------";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(311, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 12);
            this.label14.TabIndex = 8;
            this.label14.Text = "體溫";
            // 
            // lblTemperature
            // 
            this.lblTemperature.AutoSize = true;
            this.lblTemperature.Location = new System.Drawing.Point(311, 16);
            this.lblTemperature.Name = "lblTemperature";
            this.lblTemperature.Size = new System.Drawing.Size(41, 12);
            this.lblTemperature.TabIndex = 9;
            this.lblTemperature.Text = "------";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(4, 182);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.ReadOnly = true;
            this.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtNote.Size = new System.Drawing.Size(624, 235);
            this.txtNote.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.txtRowCount, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtSuccess, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtRepeat, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtNoTran, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtError, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.txtAlert, 1, 5);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(468, 6);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(160, 170);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(3, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "應轉換數";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(3, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "轉換成功";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(3, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "重複刷卡";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(3, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "未 轉 換";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(3, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "誤 差 數";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(3, 149);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "警 告 數";
            // 
            // txtRowCount
            // 
            this.txtRowCount.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtRowCount.CaptionLabel = null;
            this.txtRowCount.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtRowCount.DecimalPlace = 2;
            this.txtRowCount.IsEmpty = true;
            this.txtRowCount.Location = new System.Drawing.Point(62, 3);
            this.txtRowCount.Mask = "";
            this.txtRowCount.MaxLength = -1;
            this.txtRowCount.Name = "txtRowCount";
            this.txtRowCount.PasswordChar = '\0';
            this.txtRowCount.ReadOnly = false;
            this.txtRowCount.ShowCalendarButton = true;
            this.txtRowCount.Size = new System.Drawing.Size(88, 22);
            this.txtRowCount.TabIndex = 6;
            this.txtRowCount.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // txtSuccess
            // 
            this.txtSuccess.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtSuccess.CaptionLabel = null;
            this.txtSuccess.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtSuccess.DecimalPlace = 2;
            this.txtSuccess.IsEmpty = true;
            this.txtSuccess.Location = new System.Drawing.Point(62, 31);
            this.txtSuccess.Mask = "";
            this.txtSuccess.MaxLength = -1;
            this.txtSuccess.Name = "txtSuccess";
            this.txtSuccess.PasswordChar = '\0';
            this.txtSuccess.ReadOnly = false;
            this.txtSuccess.ShowCalendarButton = true;
            this.txtSuccess.Size = new System.Drawing.Size(88, 22);
            this.txtSuccess.TabIndex = 7;
            this.txtSuccess.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // txtRepeat
            // 
            this.txtRepeat.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtRepeat.CaptionLabel = null;
            this.txtRepeat.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtRepeat.DecimalPlace = 2;
            this.txtRepeat.IsEmpty = true;
            this.txtRepeat.Location = new System.Drawing.Point(62, 59);
            this.txtRepeat.Mask = "";
            this.txtRepeat.MaxLength = -1;
            this.txtRepeat.Name = "txtRepeat";
            this.txtRepeat.PasswordChar = '\0';
            this.txtRepeat.ReadOnly = false;
            this.txtRepeat.ShowCalendarButton = true;
            this.txtRepeat.Size = new System.Drawing.Size(88, 22);
            this.txtRepeat.TabIndex = 8;
            this.txtRepeat.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // txtNoTran
            // 
            this.txtNoTran.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtNoTran.CaptionLabel = null;
            this.txtNoTran.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtNoTran.DecimalPlace = 2;
            this.txtNoTran.IsEmpty = true;
            this.txtNoTran.Location = new System.Drawing.Point(62, 87);
            this.txtNoTran.Mask = "";
            this.txtNoTran.MaxLength = -1;
            this.txtNoTran.Name = "txtNoTran";
            this.txtNoTran.PasswordChar = '\0';
            this.txtNoTran.ReadOnly = false;
            this.txtNoTran.ShowCalendarButton = true;
            this.txtNoTran.Size = new System.Drawing.Size(88, 22);
            this.txtNoTran.TabIndex = 9;
            this.txtNoTran.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // txtError
            // 
            this.txtError.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtError.CaptionLabel = null;
            this.txtError.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtError.DecimalPlace = 2;
            this.txtError.IsEmpty = true;
            this.txtError.Location = new System.Drawing.Point(62, 115);
            this.txtError.Mask = "";
            this.txtError.MaxLength = -1;
            this.txtError.Name = "txtError";
            this.txtError.PasswordChar = '\0';
            this.txtError.ReadOnly = false;
            this.txtError.ShowCalendarButton = true;
            this.txtError.Size = new System.Drawing.Size(88, 22);
            this.txtError.TabIndex = 10;
            this.txtError.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // txtAlert
            // 
            this.txtAlert.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtAlert.CaptionLabel = null;
            this.txtAlert.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtAlert.DecimalPlace = 2;
            this.txtAlert.IsEmpty = true;
            this.txtAlert.Location = new System.Drawing.Point(62, 143);
            this.txtAlert.Mask = "";
            this.txtAlert.MaxLength = -1;
            this.txtAlert.Name = "txtAlert";
            this.txtAlert.PasswordChar = '\0';
            this.txtAlert.ReadOnly = false;
            this.txtAlert.ShowCalendarButton = true;
            this.txtAlert.Size = new System.Drawing.Size(88, 22);
            this.txtAlert.TabIndex = 11;
            this.txtAlert.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btnBrowser, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtPath, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 8);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(462, 28);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btnBrowser
            // 
            this.btnBrowser.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnBrowser.Location = new System.Drawing.Point(411, 3);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(49, 23);
            this.btnBrowser.TabIndex = 2;
            this.btnBrowser.Text = "瀏覽";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "刷卡文字檔名";
            // 
            // txtPath
            // 
            this.txtPath.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtPath.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtPath.CaptionLabel = null;
            this.txtPath.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPath.DecimalPlace = 2;
            this.txtPath.IsEmpty = true;
            this.txtPath.Location = new System.Drawing.Point(86, 3);
            this.txtPath.Mask = "";
            this.txtPath.MaxLength = -1;
            this.txtPath.Name = "txtPath";
            this.txtPath.PasswordChar = '\0';
            this.txtPath.ReadOnly = true;
            this.txtPath.ShowCalendarButton = true;
            this.txtPath.Size = new System.Drawing.Size(319, 22);
            this.txtPath.TabIndex = 1;
            this.txtPath.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Controls.Add(this.btnPrint);
            this.tabPage2.Controls.Add(this.btnInsertAll);
            this.tabPage2.Controls.Add(this.btnOverWrite);
            this.tabPage2.Controls.Add(this.btnDeleteAll);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(634, 423);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "未轉換資料";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nOBRDataGridViewTextBoxColumn,
            this.aDATEDataGridViewTextBoxColumn,
            this.oNTIMEDataGridViewTextBoxColumn,
            this.cARDNODataGridViewTextBoxColumn,
            this.temperature});
            this.dataGridView2.DataSource = this.cARDBindingSource;
            this.dataGridView2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView2.Location = new System.Drawing.Point(6, 36);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(612, 361);
            this.dataGridView2.TabIndex = 7;
            // 
            // cARDBindingSource
            // 
            this.cARDBindingSource.DataMember = "CARD";
            this.cARDBindingSource.DataSource = this.dsAtt;
            // 
            // dsAtt
            // 
            this.dsAtt.DataSetName = "dsAtt";
            this.dsAtt.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.dsAtt.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(251, 6);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(76, 24);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "匯出";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnInsertAll
            // 
            this.btnInsertAll.Location = new System.Drawing.Point(166, 6);
            this.btnInsertAll.Name = "btnInsertAll";
            this.btnInsertAll.Size = new System.Drawing.Size(79, 24);
            this.btnInsertAll.TabIndex = 5;
            this.btnInsertAll.Text = "全部寫入";
            this.btnInsertAll.UseVisualStyleBackColor = true;
            this.btnInsertAll.Click += new System.EventHandler(this.btnInsertAll_Click);
            // 
            // btnOverWrite
            // 
            this.btnOverWrite.Location = new System.Drawing.Point(83, 6);
            this.btnOverWrite.Name = "btnOverWrite";
            this.btnOverWrite.Size = new System.Drawing.Size(77, 24);
            this.btnOverWrite.TabIndex = 4;
            this.btnOverWrite.Text = "全部覆蓋";
            this.btnOverWrite.UseVisualStyleBackColor = true;
            this.btnOverWrite.Click += new System.EventHandler(this.btnOverWrite_Click);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Location = new System.Drawing.Point(6, 6);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(71, 24);
            this.btnDeleteAll.TabIndex = 2;
            this.btnDeleteAll.Text = "全部刪除";
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // cARDTMPBindingSource
            // 
            this.cARDTMPBindingSource.DataMember = "CARDTMP";
            this.cARDTMPBindingSource.DataSource = this.dsAtt;
            // 
            // cARDTMPTableAdapter
            // 
            this.cARDTMPTableAdapter.ClearBeforeFill = true;
            // 
            // cARDTableAdapter
            // 
            this.cARDTableAdapter.ClearBeforeFill = true;
            // 
            // u_SYS7TableAdapter
            // 
            this.u_SYS7TableAdapter.ClearBeforeFill = true;
            // 
            // nOBRDataGridViewTextBoxColumn
            // 
            this.nOBRDataGridViewTextBoxColumn.DataPropertyName = "NOBR";
            this.nOBRDataGridViewTextBoxColumn.HeaderText = "員工編號";
            this.nOBRDataGridViewTextBoxColumn.Name = "nOBRDataGridViewTextBoxColumn";
            // 
            // aDATEDataGridViewTextBoxColumn
            // 
            this.aDATEDataGridViewTextBoxColumn.DataPropertyName = "ADATE";
            this.aDATEDataGridViewTextBoxColumn.HeaderText = "刷卡日期";
            this.aDATEDataGridViewTextBoxColumn.Name = "aDATEDataGridViewTextBoxColumn";
            // 
            // oNTIMEDataGridViewTextBoxColumn
            // 
            this.oNTIMEDataGridViewTextBoxColumn.DataPropertyName = "ONTIME";
            this.oNTIMEDataGridViewTextBoxColumn.HeaderText = "刷卡時間";
            this.oNTIMEDataGridViewTextBoxColumn.Name = "oNTIMEDataGridViewTextBoxColumn";
            // 
            // cARDNODataGridViewTextBoxColumn
            // 
            this.cARDNODataGridViewTextBoxColumn.DataPropertyName = "CARDNO";
            this.cARDNODataGridViewTextBoxColumn.HeaderText = "刷卡卡號";
            this.cARDNODataGridViewTextBoxColumn.Name = "cARDNODataGridViewTextBoxColumn";
            // 
            // temperature
            // 
            this.temperature.DataPropertyName = "temperature";
            this.temperature.HeaderText = "體溫";
            this.temperature.Name = "temperature";
            // 
            // FRM2FA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 441);
            this.Controls.Add(this.tabControl1);
            this.Name = "FRM2FA";
            this.Text = "FRM2FA";
            this.Load += new System.EventHandler(this.FRM2F_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uSYS7BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDS)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cARDBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cARDTMPBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private JBControls.TextBox txtPath;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private JBControls.TextBox txtRowCount;
        private JBControls.TextBox txtSuccess;
        private JBControls.TextBox txtRepeat;
        private JBControls.TextBox txtNoTran;
        private JBControls.TextBox txtError;
        private JBControls.TextBox txtAlert;
        private System.Windows.Forms.Button btnTran;
        private dsAtt dsAtt;
        private System.Windows.Forms.BindingSource cARDTMPBindingSource;
        private JBHR.Att.dsAttTableAdapters.CARDTMPTableAdapter cARDTMPTableAdapter;
        private System.Windows.Forms.BindingSource cARDBindingSource;
        private JBHR.Att.dsAttTableAdapters.CARDTableAdapter cARDTableAdapter;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnInsertAll;
        private System.Windows.Forms.Button btnOverWrite;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblNobr;
        private System.Windows.Forms.Label lblSNO;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.ComboBox comboBox1;
        private JBHR.Sys.SysDS mainDS;
        private System.Windows.Forms.BindingSource uSYS7BindingSource;
        private JBHR.Sys.SysDSTableAdapters.U_SYS7TableAdapter u_SYS7TableAdapter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label8;
        private JBControls.DataGridView dataGridView2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblTemperature;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOBRDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oNTIMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cARDNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn temperature;
    }
}