namespace JBHR.Med
{
    partial class FRM51A
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
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
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.vBASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.medDS = new JBHR.Med.MedDS();
            this.v_BASETableAdapter = new JBHR.Med.MedDSTableAdapters.V_BASETableAdapter();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cbxEmpE = new JBControls.ComboBox();
            this.eMPCDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.basDS = new JBHR.Bas.BasDS();
            this.cbxEmpB = new JBControls.ComboBox();
            this.comboBoxFORMAT = new JBControls.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.yRFORMATBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBoxSER_NOE = new JBControls.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxSER_NOB = new JBControls.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.popupTextBoxNOBR_E = new JBControls.PopupTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.popupTextBoxNOBR_B = new JBControls.PopupTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxYEAR = new JBControls.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPayDateE = new JBControls.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxYYMM_E = new JBControls.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPayDateB = new JBControls.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxSEQE = new JBControls.TextBox();
            this.textBoxSEQB = new JBControls.TextBox();
            this.textBoxYYMM_B = new JBControls.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.yRFORMATTableAdapter = new JBHR.Med.MedDSTableAdapters.YRFORMATTableAdapter();
            this.eMPCDTableAdapter = new JBHR.Bas.BasDSTableAdapters.EMPCDTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.vBASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medDS)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eMPCDBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.basDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yRFORMATBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // vBASEBindingSource
            // 
            this.vBASEBindingSource.DataMember = "V_BASE";
            this.vBASEBindingSource.DataSource = this.medDS;
            // 
            // medDS
            // 
            this.medDS.DataSetName = "MedDS";
            this.medDS.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.medDS.RemotingFormat = System.Data.SerializationFormat.Binary;
            this.medDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // v_BASETableAdapter
            // 
            this.v_BASETableAdapter.ClearBeforeFill = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 254);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(339, 23);
            this.progressBar1.TabIndex = 20;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.cbxEmpE);
            this.panel1.Controls.Add(this.cbxEmpB);
            this.panel1.Controls.Add(this.comboBoxFORMAT);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.textBoxSER_NOE);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.textBoxSER_NOB);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.popupTextBoxNOBR_E);
            this.panel1.Controls.Add(this.popupTextBoxNOBR_B);
            this.panel1.Controls.Add(this.textBoxYEAR);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtPayDateE);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.textBoxYYMM_E);
            this.panel1.Controls.Add(this.txtPayDateB);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.textBoxSEQE);
            this.panel1.Controls.Add(this.textBoxSEQB);
            this.panel1.Controls.Add(this.textBoxYYMM_B);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(339, 254);
            this.panel1.TabIndex = 21;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(163, 221);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "離開";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(82, 221);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "轉入";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbxEmpE
            // 
            this.cbxEmpE.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.cbxEmpE.BackColor = System.Drawing.SystemColors.Control;
            this.cbxEmpE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cbxEmpE.CaptionLabel = null;
            this.cbxEmpE.DataSource = this.eMPCDBindingSource;
            this.cbxEmpE.DisplayMember = "empdescr";
            this.cbxEmpE.DropDownCount = 10;
            this.cbxEmpE.IsDisplayValueLabel = false;
            this.cbxEmpE.IsEmpty = true;
            this.cbxEmpE.Location = new System.Drawing.Point(200, 131);
            this.cbxEmpE.Name = "cbxEmpE";
            this.cbxEmpE.SelectedValue = "";
            this.cbxEmpE.Size = new System.Drawing.Size(67, 22);
            this.cbxEmpE.TabIndex = 10;
            this.cbxEmpE.ValueMember = "empcd";
            // 
            // eMPCDBindingSource
            // 
            this.eMPCDBindingSource.DataMember = "EMPCD";
            this.eMPCDBindingSource.DataSource = this.basDS;
            // 
            // basDS
            // 
            this.basDS.DataSetName = "BasDS";
            this.basDS.Locale = new System.Globalization.CultureInfo("");
            this.basDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cbxEmpB
            // 
            this.cbxEmpB.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.cbxEmpB.BackColor = System.Drawing.SystemColors.Control;
            this.cbxEmpB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cbxEmpB.CaptionLabel = null;
            this.cbxEmpB.DataSource = this.eMPCDBindingSource;
            this.cbxEmpB.DisplayMember = "empdescr";
            this.cbxEmpB.DropDownCount = 10;
            this.cbxEmpB.IsDisplayValueLabel = false;
            this.cbxEmpB.IsEmpty = true;
            this.cbxEmpB.Location = new System.Drawing.Point(71, 131);
            this.cbxEmpB.Name = "cbxEmpB";
            this.cbxEmpB.SelectedValue = "";
            this.cbxEmpB.Size = new System.Drawing.Size(67, 22);
            this.cbxEmpB.TabIndex = 9;
            this.cbxEmpB.ValueMember = "empcd";
            // 
            // comboBoxFORMAT
            // 
            this.comboBoxFORMAT.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.comboBoxFORMAT.BackColor = System.Drawing.SystemColors.Control;
            this.comboBoxFORMAT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.comboBoxFORMAT.CaptionLabel = this.label8;
            this.comboBoxFORMAT.DataSource = this.yRFORMATBindingSource;
            this.comboBoxFORMAT.DisplayMember = "m_fmt_name";
            this.comboBoxFORMAT.DropDownCount = 10;
            this.comboBoxFORMAT.IsDisplayValueLabel = true;
            this.comboBoxFORMAT.IsEmpty = true;
            this.comboBoxFORMAT.Location = new System.Drawing.Point(71, 185);
            this.comboBoxFORMAT.Name = "comboBoxFORMAT";
            this.comboBoxFORMAT.SelectedValue = "";
            this.comboBoxFORMAT.Size = new System.Drawing.Size(100, 22);
            this.comboBoxFORMAT.TabIndex = 13;
            this.comboBoxFORMAT.ValueMember = "m_format";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(36, 190);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 35;
            this.label8.Text = "格式";
            // 
            // yRFORMATBindingSource
            // 
            this.yRFORMATBindingSource.DataMember = "YRFORMAT";
            this.yRFORMATBindingSource.DataSource = this.medDS;
            // 
            // textBoxSER_NOE
            // 
            this.textBoxSER_NOE.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxSER_NOE.CaptionLabel = this.label6;
            this.textBoxSER_NOE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxSER_NOE.DecimalPlace = 2;
            this.textBoxSER_NOE.IsEmpty = true;
            this.textBoxSER_NOE.Location = new System.Drawing.Point(200, 156);
            this.textBoxSER_NOE.Mask = "L0000000";
            this.textBoxSER_NOE.MaxLength = -1;
            this.textBoxSER_NOE.Name = "textBoxSER_NOE";
            this.textBoxSER_NOE.PasswordChar = '\0';
            this.textBoxSER_NOE.ReadOnly = false;
            this.textBoxSER_NOE.ShowCalendarButton = true;
            this.textBoxSER_NOE.Size = new System.Drawing.Size(103, 22);
            this.textBoxSER_NOE.TabIndex = 12;
            this.textBoxSER_NOE.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(177, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 34;
            this.label6.Text = "至";
            // 
            // textBoxSER_NOB
            // 
            this.textBoxSER_NOB.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxSER_NOB.CaptionLabel = this.label7;
            this.textBoxSER_NOB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxSER_NOB.DecimalPlace = 2;
            this.textBoxSER_NOB.IsEmpty = true;
            this.textBoxSER_NOB.Location = new System.Drawing.Point(71, 156);
            this.textBoxSER_NOB.Mask = "L0000000";
            this.textBoxSER_NOB.MaxLength = -1;
            this.textBoxSER_NOB.Name = "textBoxSER_NOB";
            this.textBoxSER_NOB.PasswordChar = '\0';
            this.textBoxSER_NOB.ReadOnly = false;
            this.textBoxSER_NOB.ShowCalendarButton = true;
            this.textBoxSER_NOB.Size = new System.Drawing.Size(100, 22);
            this.textBoxSER_NOB.TabIndex = 11;
            this.textBoxSER_NOB.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(24, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 33;
            this.label7.Text = "流水號";
            // 
            // popupTextBoxNOBR_E
            // 
            this.popupTextBoxNOBR_E.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.popupTextBoxNOBR_E.CaptionLabel = this.label3;
            this.popupTextBoxNOBR_E.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.popupTextBoxNOBR_E.DataSource = this.vBASEBindingSource;
            this.popupTextBoxNOBR_E.DisplayMember = "name_c";
            this.popupTextBoxNOBR_E.IsEmpty = true;
            this.popupTextBoxNOBR_E.IsEmptyToQuery = true;
            this.popupTextBoxNOBR_E.IsMustBeFound = true;
            this.popupTextBoxNOBR_E.LabelText = "";
            this.popupTextBoxNOBR_E.Location = new System.Drawing.Point(200, 103);
            this.popupTextBoxNOBR_E.Name = "popupTextBoxNOBR_E";
            this.popupTextBoxNOBR_E.QueryFields = "name_e,name_p";
            this.popupTextBoxNOBR_E.ReadOnly = false;
            this.popupTextBoxNOBR_E.ShowDisplayName = true;
            this.popupTextBoxNOBR_E.Size = new System.Drawing.Size(52, 22);
            this.popupTextBoxNOBR_E.TabIndex = 8;
            this.popupTextBoxNOBR_E.ValueMember = "nobr";
            this.popupTextBoxNOBR_E.WhereCmd = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(177, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 30;
            this.label3.Text = "至";
            // 
            // popupTextBoxNOBR_B
            // 
            this.popupTextBoxNOBR_B.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.popupTextBoxNOBR_B.CaptionLabel = this.label4;
            this.popupTextBoxNOBR_B.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.popupTextBoxNOBR_B.DataSource = this.vBASEBindingSource;
            this.popupTextBoxNOBR_B.DisplayMember = "name_c";
            this.popupTextBoxNOBR_B.IsEmpty = true;
            this.popupTextBoxNOBR_B.IsEmptyToQuery = true;
            this.popupTextBoxNOBR_B.IsMustBeFound = true;
            this.popupTextBoxNOBR_B.LabelText = "";
            this.popupTextBoxNOBR_B.Location = new System.Drawing.Point(71, 103);
            this.popupTextBoxNOBR_B.Name = "popupTextBoxNOBR_B";
            this.popupTextBoxNOBR_B.QueryFields = "name_e,name_p";
            this.popupTextBoxNOBR_B.ReadOnly = false;
            this.popupTextBoxNOBR_B.ShowDisplayName = true;
            this.popupTextBoxNOBR_B.Size = new System.Drawing.Size(49, 22);
            this.popupTextBoxNOBR_B.TabIndex = 7;
            this.popupTextBoxNOBR_B.ValueMember = "nobr";
            this.popupTextBoxNOBR_B.WhereCmd = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(12, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 27;
            this.label4.Text = "員工編號";
            // 
            // textBoxYEAR
            // 
            this.textBoxYEAR.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxYEAR.CaptionLabel = this.label5;
            this.textBoxYEAR.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxYEAR.DecimalPlace = 2;
            this.textBoxYEAR.IsEmpty = true;
            this.textBoxYEAR.Location = new System.Drawing.Point(71, 19);
            this.textBoxYEAR.Mask = "";
            this.textBoxYEAR.MaxLength = 4;
            this.textBoxYEAR.Name = "textBoxYEAR";
            this.textBoxYEAR.PasswordChar = '\0';
            this.textBoxYEAR.ReadOnly = false;
            this.textBoxYEAR.ShowCalendarButton = true;
            this.textBoxYEAR.Size = new System.Drawing.Size(49, 22);
            this.textBoxYEAR.TabIndex = 0;
            this.textBoxYEAR.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(12, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 32;
            this.label5.Text = "扣繳年度";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(177, 135);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 12);
            this.label12.TabIndex = 30;
            this.label12.Text = "至";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(36, 135);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 27;
            this.label11.Text = "員別";
            // 
            // txtPayDateE
            // 
            this.txtPayDateE.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtPayDateE.CaptionLabel = this.label10;
            this.txtPayDateE.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPayDateE.DecimalPlace = 2;
            this.txtPayDateE.IsEmpty = true;
            this.txtPayDateE.Location = new System.Drawing.Point(200, 75);
            this.txtPayDateE.Mask = "0000/00/00";
            this.txtPayDateE.MaxLength = 6;
            this.txtPayDateE.Name = "txtPayDateE";
            this.txtPayDateE.PasswordChar = '\0';
            this.txtPayDateE.ReadOnly = false;
            this.txtPayDateE.ShowCalendarButton = true;
            this.txtPayDateE.Size = new System.Drawing.Size(70, 22);
            this.txtPayDateE.TabIndex = 6;
            this.txtPayDateE.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(177, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 24;
            this.label10.Text = "至";
            // 
            // textBoxYYMM_E
            // 
            this.textBoxYYMM_E.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxYYMM_E.CaptionLabel = this.label2;
            this.textBoxYYMM_E.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxYYMM_E.DecimalPlace = 2;
            this.textBoxYYMM_E.IsEmpty = true;
            this.textBoxYYMM_E.Location = new System.Drawing.Point(200, 47);
            this.textBoxYYMM_E.Mask = "";
            this.textBoxYYMM_E.MaxLength = 6;
            this.textBoxYYMM_E.Name = "textBoxYYMM_E";
            this.textBoxYYMM_E.PasswordChar = '\0';
            this.textBoxYYMM_E.ReadOnly = false;
            this.textBoxYYMM_E.ShowCalendarButton = true;
            this.textBoxYYMM_E.Size = new System.Drawing.Size(52, 22);
            this.textBoxYYMM_E.TabIndex = 3;
            this.textBoxYYMM_E.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(177, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 24;
            this.label2.Text = "至";
            // 
            // txtPayDateB
            // 
            this.txtPayDateB.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtPayDateB.CaptionLabel = this.label9;
            this.txtPayDateB.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPayDateB.DecimalPlace = 2;
            this.txtPayDateB.IsEmpty = true;
            this.txtPayDateB.Location = new System.Drawing.Point(71, 75);
            this.txtPayDateB.Mask = "0000/00/00";
            this.txtPayDateB.MaxLength = 6;
            this.txtPayDateB.Name = "txtPayDateB";
            this.txtPayDateB.PasswordChar = '\0';
            this.txtPayDateB.ReadOnly = false;
            this.txtPayDateB.ShowCalendarButton = true;
            this.txtPayDateB.Size = new System.Drawing.Size(67, 22);
            this.txtPayDateB.TabIndex = 5;
            this.txtPayDateB.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(12, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 21;
            this.label9.Text = "發放日期";
            // 
            // textBoxSEQE
            // 
            this.textBoxSEQE.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxSEQE.CaptionLabel = null;
            this.textBoxSEQE.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxSEQE.DecimalPlace = 2;
            this.textBoxSEQE.IsEmpty = true;
            this.textBoxSEQE.Location = new System.Drawing.Point(258, 47);
            this.textBoxSEQE.Mask = "";
            this.textBoxSEQE.MaxLength = 6;
            this.textBoxSEQE.Name = "textBoxSEQE";
            this.textBoxSEQE.PasswordChar = '\0';
            this.textBoxSEQE.ReadOnly = false;
            this.textBoxSEQE.ShowCalendarButton = true;
            this.textBoxSEQE.Size = new System.Drawing.Size(21, 22);
            this.textBoxSEQE.TabIndex = 4;
            this.textBoxSEQE.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // textBoxSEQB
            // 
            this.textBoxSEQB.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxSEQB.CaptionLabel = null;
            this.textBoxSEQB.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxSEQB.DecimalPlace = 2;
            this.textBoxSEQB.IsEmpty = true;
            this.textBoxSEQB.Location = new System.Drawing.Point(126, 47);
            this.textBoxSEQB.Mask = "";
            this.textBoxSEQB.MaxLength = 6;
            this.textBoxSEQB.Name = "textBoxSEQB";
            this.textBoxSEQB.PasswordChar = '\0';
            this.textBoxSEQB.ReadOnly = false;
            this.textBoxSEQB.ShowCalendarButton = true;
            this.textBoxSEQB.Size = new System.Drawing.Size(21, 22);
            this.textBoxSEQB.TabIndex = 2;
            this.textBoxSEQB.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // textBoxYYMM_B
            // 
            this.textBoxYYMM_B.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxYYMM_B.CaptionLabel = this.label1;
            this.textBoxYYMM_B.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxYYMM_B.DecimalPlace = 2;
            this.textBoxYYMM_B.IsEmpty = true;
            this.textBoxYYMM_B.Location = new System.Drawing.Point(71, 47);
            this.textBoxYYMM_B.Mask = "";
            this.textBoxYYMM_B.MaxLength = 6;
            this.textBoxYYMM_B.Name = "textBoxYYMM_B";
            this.textBoxYYMM_B.PasswordChar = '\0';
            this.textBoxYYMM_B.ReadOnly = false;
            this.textBoxYYMM_B.ShowCalendarButton = true;
            this.textBoxYYMM_B.Size = new System.Drawing.Size(49, 22);
            this.textBoxYYMM_B.TabIndex = 1;
            this.textBoxYYMM_B.ValidType = JBControls.TextBox.EValidType.String;
            this.textBoxYYMM_B.Validated += new System.EventHandler(this.textBoxYYMM_B_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "發放年月";
            // 
            // yRFORMATTableAdapter
            // 
            this.yRFORMATTableAdapter.ClearBeforeFill = true;
            // 
            // eMPCDTableAdapter
            // 
            this.eMPCDTableAdapter.ClearBeforeFill = true;
            // 
            // FRM51A
            // 
            this.ClientSize = new System.Drawing.Size(339, 277);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.progressBar1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "FRM51A";
            this.Text = "從薪資轉入";
            this.Load += new System.EventHandler(this.FRM51A_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vBASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medDS)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eMPCDBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.basDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yRFORMATBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MedDS medDS;
        private System.Windows.Forms.BindingSource vBASEBindingSource;
        private JBHR.Med.MedDSTableAdapters.V_BASETableAdapter v_BASETableAdapter;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private JBControls.ComboBox comboBoxFORMAT;
        private System.Windows.Forms.Label label8;
        private JBControls.TextBox textBoxSER_NOE;
        private System.Windows.Forms.Label label6;
        private JBControls.TextBox textBoxSER_NOB;
        private System.Windows.Forms.Label label7;
        private JBControls.PopupTextBox popupTextBoxNOBR_E;
        private System.Windows.Forms.Label label3;
        private JBControls.PopupTextBox popupTextBoxNOBR_B;
        private System.Windows.Forms.Label label4;
        private JBControls.TextBox textBoxYEAR;
        private System.Windows.Forms.Label label5;
        private JBControls.TextBox textBoxYYMM_E;
        private System.Windows.Forms.Label label2;
        private JBControls.TextBox textBoxYYMM_B;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource yRFORMATBindingSource;
        private MedDSTableAdapters.YRFORMATTableAdapter yRFORMATTableAdapter;
        private JBControls.TextBox txtPayDateE;
        private System.Windows.Forms.Label label10;
        private JBControls.TextBox txtPayDateB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private Bas.BasDS basDS;
        private System.Windows.Forms.BindingSource eMPCDBindingSource;
        private Bas.BasDSTableAdapters.EMPCDTableAdapter eMPCDTableAdapter;
        private JBControls.ComboBox cbxEmpE;
        private JBControls.ComboBox cbxEmpB;
        private JBControls.TextBox textBoxSEQE;
        private JBControls.TextBox textBoxSEQB;

    }
}
