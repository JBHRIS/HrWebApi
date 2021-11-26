namespace JBHR.Bas
{
    partial class BASETTSI
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
            this.lblCard = new System.Windows.Forms.Label();
            this.lblTtscd = new System.Windows.Forms.Label();
            this.lblMemo = new System.Windows.Forms.Label();
            this.lblEmpcd = new System.Windows.Forms.Label();
            this.lblDI = new System.Windows.Forms.Label();
            this.lblJob = new System.Windows.Forms.Label();
            this.lblDepts = new System.Windows.Forms.Label();
            this.lblDepta = new System.Windows.Forms.Label();
            this.lblCindt = new System.Windows.Forms.Label();
            this.lblAdate = new System.Windows.Forms.Label();
            this.lblTtscode = new System.Windows.Forms.Label();
            this.lblNobr = new System.Windows.Forms.Label();
            this.cbxNobr = new System.Windows.Forms.ComboBox();
            this.lblName = new System.Windows.Forms.Label();
            this.cbxName = new System.Windows.Forms.ComboBox();
            this.cbxTtscode = new System.Windows.Forms.ComboBox();
            this.tTSCODEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.basDS = new JBHR.Bas.BasDS();
            this.cbxCindt = new System.Windows.Forms.ComboBox();
            this.cbxDepts = new System.Windows.Forms.ComboBox();
            this.cbxDeptm = new System.Windows.Forms.ComboBox();
            this.cbxCard = new System.Windows.Forms.ComboBox();
            this.cbxDI = new System.Windows.Forms.ComboBox();
            this.cbxJob = new System.Windows.Forms.ComboBox();
            this.cbxEmpcd = new System.Windows.Forms.ComboBox();
            this.cbxTtscd = new System.Windows.Forms.ComboBox();
            this.cbxMemo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnBrower = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxSheet = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtAdate = new JBControls.TextBox();
            this.lblDept = new System.Windows.Forms.Label();
            this.lblJobl = new System.Windows.Forms.Label();
            this.lblJobs = new System.Windows.Forms.Label();
            this.cbxDept = new System.Windows.Forms.ComboBox();
            this.cbxJobl = new System.Windows.Forms.ComboBox();
            this.cbxJobs = new System.Windows.Forms.ComboBox();
            this.tTSCODETableAdapter = new JBHR.Bas.BasDSTableAdapters.TTSCODETableAdapter();
            this.btnPreview = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRotet = new System.Windows.Forms.Label();
            this.cbxRotet = new System.Windows.Forms.ComboBox();
            this.lblHoliCD = new System.Windows.Forms.Label();
            this.cbxHoliCD = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.tTSCODEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.basDS)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCard
            // 
            this.lblCard.AutoSize = true;
            this.lblCard.ForeColor = System.Drawing.Color.Black;
            this.lblCard.Location = new System.Drawing.Point(215, 258);
            this.lblCard.Name = "lblCard";
            this.lblCard.Size = new System.Drawing.Size(29, 12);
            this.lblCard.TabIndex = 402;
            this.lblCard.Text = "刷卡";
            // 
            // lblTtscd
            // 
            this.lblTtscd.AutoSize = true;
            this.lblTtscd.ForeColor = System.Drawing.Color.Black;
            this.lblTtscd.Location = new System.Drawing.Point(13, 258);
            this.lblTtscd.Name = "lblTtscd";
            this.lblTtscd.Size = new System.Drawing.Size(77, 12);
            this.lblTtscd.TabIndex = 379;
            this.lblTtscd.Text = "異動原因代碼";
            // 
            // lblMemo
            // 
            this.lblMemo.AutoSize = true;
            this.lblMemo.ForeColor = System.Drawing.Color.Black;
            this.lblMemo.Location = new System.Drawing.Point(61, 289);
            this.lblMemo.Name = "lblMemo";
            this.lblMemo.Size = new System.Drawing.Size(29, 12);
            this.lblMemo.TabIndex = 400;
            this.lblMemo.Text = "備註";
            // 
            // lblEmpcd
            // 
            this.lblEmpcd.AutoSize = true;
            this.lblEmpcd.ForeColor = System.Drawing.Color.Black;
            this.lblEmpcd.Location = new System.Drawing.Point(191, 234);
            this.lblEmpcd.Name = "lblEmpcd";
            this.lblEmpcd.Size = new System.Drawing.Size(53, 12);
            this.lblEmpcd.TabIndex = 381;
            this.lblEmpcd.Text = "員別代碼";
            // 
            // lblDI
            // 
            this.lblDI.AutoSize = true;
            this.lblDI.ForeColor = System.Drawing.Color.Black;
            this.lblDI.Location = new System.Drawing.Point(49, 234);
            this.lblDI.Name = "lblDI";
            this.lblDI.Size = new System.Drawing.Size(41, 12);
            this.lblDI.TabIndex = 380;
            this.lblDI.Text = "直間接";
            // 
            // lblJob
            // 
            this.lblJob.AutoSize = true;
            this.lblJob.ForeColor = System.Drawing.Color.Black;
            this.lblJob.Location = new System.Drawing.Point(191, 153);
            this.lblJob.Name = "lblJob";
            this.lblJob.Size = new System.Drawing.Size(53, 12);
            this.lblJob.TabIndex = 378;
            this.lblJob.Text = "職稱代碼";
            // 
            // lblDepts
            // 
            this.lblDepts.AutoSize = true;
            this.lblDepts.ForeColor = System.Drawing.Color.Black;
            this.lblDepts.Location = new System.Drawing.Point(13, 178);
            this.lblDepts.Name = "lblDepts";
            this.lblDepts.Size = new System.Drawing.Size(77, 12);
            this.lblDepts.TabIndex = 377;
            this.lblDepts.Text = "成本部門代碼";
            // 
            // lblDepta
            // 
            this.lblDepta.AutoSize = true;
            this.lblDepta.ForeColor = System.Drawing.Color.Black;
            this.lblDepta.Location = new System.Drawing.Point(13, 209);
            this.lblDepta.Name = "lblDepta";
            this.lblDepta.Size = new System.Drawing.Size(77, 12);
            this.lblDepta.TabIndex = 384;
            this.lblDepta.Text = "簽核部門代碼";
            // 
            // lblCindt
            // 
            this.lblCindt.AutoSize = true;
            this.lblCindt.ForeColor = System.Drawing.Color.Black;
            this.lblCindt.Location = new System.Drawing.Point(179, 125);
            this.lblCindt.Name = "lblCindt";
            this.lblCindt.Size = new System.Drawing.Size(65, 12);
            this.lblCindt.TabIndex = 440;
            this.lblCindt.Text = "年資起算日";
            this.lblCindt.Visible = false;
            // 
            // lblAdate
            // 
            this.lblAdate.AutoSize = true;
            this.lblAdate.ForeColor = System.Drawing.Color.Red;
            this.lblAdate.Location = new System.Drawing.Point(34, 73);
            this.lblAdate.Name = "lblAdate";
            this.lblAdate.Size = new System.Drawing.Size(53, 12);
            this.lblAdate.TabIndex = 434;
            this.lblAdate.Text = "異動日期";
            // 
            // lblTtscode
            // 
            this.lblTtscode.AutoSize = true;
            this.lblTtscode.ForeColor = System.Drawing.Color.Red;
            this.lblTtscode.Location = new System.Drawing.Point(34, 125);
            this.lblTtscode.Name = "lblTtscode";
            this.lblTtscode.Size = new System.Drawing.Size(53, 12);
            this.lblTtscode.TabIndex = 433;
            this.lblTtscode.Text = "異動狀態";
            // 
            // lblNobr
            // 
            this.lblNobr.AutoSize = true;
            this.lblNobr.ForeColor = System.Drawing.Color.Red;
            this.lblNobr.Location = new System.Drawing.Point(34, 97);
            this.lblNobr.Name = "lblNobr";
            this.lblNobr.Size = new System.Drawing.Size(53, 12);
            this.lblNobr.TabIndex = 377;
            this.lblNobr.Text = "員工編號";
            // 
            // cbxNobr
            // 
            this.cbxNobr.FormattingEnabled = true;
            this.cbxNobr.Location = new System.Drawing.Point(96, 94);
            this.cbxNobr.Name = "cbxNobr";
            this.cbxNobr.Size = new System.Drawing.Size(82, 20);
            this.cbxNobr.TabIndex = 2;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(191, 97);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(53, 12);
            this.lblName.TabIndex = 377;
            this.lblName.Text = "員工姓名";
            // 
            // cbxName
            // 
            this.cbxName.FormattingEnabled = true;
            this.cbxName.Location = new System.Drawing.Point(250, 94);
            this.cbxName.Name = "cbxName";
            this.cbxName.Size = new System.Drawing.Size(82, 20);
            this.cbxName.TabIndex = 3;
            // 
            // cbxTtscode
            // 
            this.cbxTtscode.DataSource = this.tTSCODEBindingSource;
            this.cbxTtscode.DisplayMember = "NAME";
            this.cbxTtscode.FormattingEnabled = true;
            this.cbxTtscode.Location = new System.Drawing.Point(96, 122);
            this.cbxTtscode.Name = "cbxTtscode";
            this.cbxTtscode.Size = new System.Drawing.Size(82, 20);
            this.cbxTtscode.TabIndex = 4;
            this.cbxTtscode.ValueMember = "CODE";
            // 
            // tTSCODEBindingSource
            // 
            this.tTSCODEBindingSource.DataMember = "TTSCODE";
            this.tTSCODEBindingSource.DataSource = this.basDS;
            // 
            // basDS
            // 
            this.basDS.DataSetName = "BasDS";
            this.basDS.Locale = new System.Globalization.CultureInfo("");
            this.basDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cbxCindt
            // 
            this.cbxCindt.FormattingEnabled = true;
            this.cbxCindt.Location = new System.Drawing.Point(250, 124);
            this.cbxCindt.Name = "cbxCindt";
            this.cbxCindt.Size = new System.Drawing.Size(82, 20);
            this.cbxCindt.TabIndex = 5;
            this.cbxCindt.Visible = false;
            // 
            // cbxDepts
            // 
            this.cbxDepts.FormattingEnabled = true;
            this.cbxDepts.Location = new System.Drawing.Point(96, 175);
            this.cbxDepts.Name = "cbxDepts";
            this.cbxDepts.Size = new System.Drawing.Size(82, 20);
            this.cbxDepts.TabIndex = 7;
            // 
            // cbxDeptm
            // 
            this.cbxDeptm.FormattingEnabled = true;
            this.cbxDeptm.Location = new System.Drawing.Point(96, 203);
            this.cbxDeptm.Name = "cbxDeptm";
            this.cbxDeptm.Size = new System.Drawing.Size(82, 20);
            this.cbxDeptm.TabIndex = 8;
            // 
            // cbxCard
            // 
            this.cbxCard.FormattingEnabled = true;
            this.cbxCard.Location = new System.Drawing.Point(250, 255);
            this.cbxCard.Name = "cbxCard";
            this.cbxCard.Size = new System.Drawing.Size(82, 20);
            this.cbxCard.TabIndex = 15;
            // 
            // cbxDI
            // 
            this.cbxDI.FormattingEnabled = true;
            this.cbxDI.Location = new System.Drawing.Point(96, 229);
            this.cbxDI.Name = "cbxDI";
            this.cbxDI.Size = new System.Drawing.Size(82, 20);
            this.cbxDI.TabIndex = 12;
            // 
            // cbxJob
            // 
            this.cbxJob.FormattingEnabled = true;
            this.cbxJob.Location = new System.Drawing.Point(250, 150);
            this.cbxJob.Name = "cbxJob";
            this.cbxJob.Size = new System.Drawing.Size(82, 20);
            this.cbxJob.TabIndex = 9;
            // 
            // cbxEmpcd
            // 
            this.cbxEmpcd.FormattingEnabled = true;
            this.cbxEmpcd.Location = new System.Drawing.Point(250, 231);
            this.cbxEmpcd.Name = "cbxEmpcd";
            this.cbxEmpcd.Size = new System.Drawing.Size(82, 20);
            this.cbxEmpcd.TabIndex = 13;
            // 
            // cbxTtscd
            // 
            this.cbxTtscd.FormattingEnabled = true;
            this.cbxTtscd.Location = new System.Drawing.Point(96, 253);
            this.cbxTtscd.Name = "cbxTtscd";
            this.cbxTtscd.Size = new System.Drawing.Size(82, 20);
            this.cbxTtscd.TabIndex = 14;
            // 
            // cbxMemo
            // 
            this.cbxMemo.FormattingEnabled = true;
            this.cbxMemo.Location = new System.Drawing.Point(96, 284);
            this.cbxMemo.Name = "cbxMemo";
            this.cbxMemo.Size = new System.Drawing.Size(201, 20);
            this.cbxMemo.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 442;
            this.label4.Text = "檔案";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Enabled = false;
            this.txtFilePath.Location = new System.Drawing.Point(96, 12);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(376, 22);
            this.txtFilePath.TabIndex = 443;
            // 
            // btnBrower
            // 
            this.btnBrower.Location = new System.Drawing.Point(489, 10);
            this.btnBrower.Name = "btnBrower";
            this.btnBrower.Size = new System.Drawing.Size(75, 23);
            this.btnBrower.TabIndex = 0;
            this.btnBrower.Text = "瀏覽";
            this.btnBrower.UseVisualStyleBackColor = true;
            this.btnBrower.Click += new System.EventHandler(this.btnBrower_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(49, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 442;
            this.label6.Text = "工作表";
            // 
            // comboBoxSheet
            // 
            this.comboBoxSheet.FormattingEnabled = true;
            this.comboBoxSheet.Location = new System.Drawing.Point(96, 40);
            this.comboBoxSheet.Name = "comboBoxSheet";
            this.comboBoxSheet.Size = new System.Drawing.Size(82, 20);
            this.comboBoxSheet.TabIndex = 0;
            this.comboBoxSheet.SelectedIndexChanged += new System.EventHandler(this.comboBoxSheet_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(184, 38);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 444;
            this.button2.Text = "檢視";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(163, 410);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 18;
            this.btnOK.Text = "確認";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(333, 410);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtAdate
            // 
            this.txtAdate.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtAdate.CaptionLabel = null;
            this.txtAdate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtAdate.DecimalPlace = 2;
            this.txtAdate.IsEmpty = true;
            this.txtAdate.Location = new System.Drawing.Point(96, 66);
            this.txtAdate.Mask = "0000/00/00";
            this.txtAdate.MaxLength = -1;
            this.txtAdate.Name = "txtAdate";
            this.txtAdate.PasswordChar = '\0';
            this.txtAdate.ReadOnly = false;
            this.txtAdate.ShowCalendarButton = true;
            this.txtAdate.Size = new System.Drawing.Size(63, 22);
            this.txtAdate.TabIndex = 1;
            this.txtAdate.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // lblDept
            // 
            this.lblDept.AutoSize = true;
            this.lblDept.ForeColor = System.Drawing.Color.Black;
            this.lblDept.Location = new System.Drawing.Point(13, 153);
            this.lblDept.Name = "lblDept";
            this.lblDept.Size = new System.Drawing.Size(77, 12);
            this.lblDept.TabIndex = 448;
            this.lblDept.Text = "編制部門代碼";
            // 
            // lblJobl
            // 
            this.lblJobl.AutoSize = true;
            this.lblJobl.ForeColor = System.Drawing.Color.Black;
            this.lblJobl.Location = new System.Drawing.Point(191, 209);
            this.lblJobl.Name = "lblJobl";
            this.lblJobl.Size = new System.Drawing.Size(53, 12);
            this.lblJobl.TabIndex = 452;
            this.lblJobl.Text = "職等代碼";
            // 
            // lblJobs
            // 
            this.lblJobs.AutoSize = true;
            this.lblJobs.ForeColor = System.Drawing.Color.Black;
            this.lblJobs.Location = new System.Drawing.Point(191, 181);
            this.lblJobs.Name = "lblJobs";
            this.lblJobs.Size = new System.Drawing.Size(53, 12);
            this.lblJobs.TabIndex = 451;
            this.lblJobs.Text = "職類代碼";
            // 
            // cbxDept
            // 
            this.cbxDept.FormattingEnabled = true;
            this.cbxDept.Location = new System.Drawing.Point(96, 149);
            this.cbxDept.Name = "cbxDept";
            this.cbxDept.Size = new System.Drawing.Size(82, 20);
            this.cbxDept.TabIndex = 6;
            // 
            // cbxJobl
            // 
            this.cbxJobl.FormattingEnabled = true;
            this.cbxJobl.Location = new System.Drawing.Point(250, 206);
            this.cbxJobl.Name = "cbxJobl";
            this.cbxJobl.Size = new System.Drawing.Size(82, 20);
            this.cbxJobl.TabIndex = 11;
            // 
            // cbxJobs
            // 
            this.cbxJobs.FormattingEnabled = true;
            this.cbxJobs.Location = new System.Drawing.Point(250, 178);
            this.cbxJobs.Name = "cbxJobs";
            this.cbxJobs.Size = new System.Drawing.Size(82, 20);
            this.cbxJobs.TabIndex = 10;
            // 
            // tTSCODETableAdapter
            // 
            this.tTSCODETableAdapter.ClearBeforeFill = true;
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(250, 410);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 19;
            this.btnPreview.Text = "預覽";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(15, 304);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(551, 100);
            this.groupBox1.TabIndex = 453;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "說明";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "未指定的欄位代表不異動不檢察";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "檢查-錯誤的代碼、錯誤的姓名";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(443, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "錯誤-異動時間重複、異動違規(如離職後異動)、找不到異動資料、找不到人事資料";
            // 
            // lblRotet
            // 
            this.lblRotet.AutoSize = true;
            this.lblRotet.ForeColor = System.Drawing.Color.Black;
            this.lblRotet.Location = new System.Drawing.Point(345, 152);
            this.lblRotet.Name = "lblRotet";
            this.lblRotet.Size = new System.Drawing.Size(65, 12);
            this.lblRotet.TabIndex = 378;
            this.lblRotet.Text = "輪班別代碼";
            // 
            // cbxRotet
            // 
            this.cbxRotet.FormattingEnabled = true;
            this.cbxRotet.Location = new System.Drawing.Point(416, 149);
            this.cbxRotet.Name = "cbxRotet";
            this.cbxRotet.Size = new System.Drawing.Size(82, 20);
            this.cbxRotet.TabIndex = 9;
            // 
            // lblHoliCD
            // 
            this.lblHoliCD.AutoSize = true;
            this.lblHoliCD.ForeColor = System.Drawing.Color.Black;
            this.lblHoliCD.Location = new System.Drawing.Point(345, 181);
            this.lblHoliCD.Name = "lblHoliCD";
            this.lblHoliCD.Size = new System.Drawing.Size(65, 12);
            this.lblHoliCD.TabIndex = 378;
            this.lblHoliCD.Text = "行事曆代碼";
            // 
            // cbxHoliCD
            // 
            this.cbxHoliCD.FormattingEnabled = true;
            this.cbxHoliCD.Location = new System.Drawing.Point(416, 178);
            this.cbxHoliCD.Name = "cbxHoliCD";
            this.cbxHoliCD.Size = new System.Drawing.Size(82, 20);
            this.cbxHoliCD.TabIndex = 9;
            // 
            // BASETTSI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 445);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblJobl);
            this.Controls.Add(this.lblJobs);
            this.Controls.Add(this.lblDept);
            this.Controls.Add(this.txtAdate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnBrower);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxJobs);
            this.Controls.Add(this.cbxName);
            this.Controls.Add(this.cbxCard);
            this.Controls.Add(this.cbxDI);
            this.Controls.Add(this.cbxEmpcd);
            this.Controls.Add(this.cbxMemo);
            this.Controls.Add(this.cbxTtscd);
            this.Controls.Add(this.cbxHoliCD);
            this.Controls.Add(this.cbxRotet);
            this.Controls.Add(this.cbxJob);
            this.Controls.Add(this.cbxDeptm);
            this.Controls.Add(this.cbxJobl);
            this.Controls.Add(this.cbxDepts);
            this.Controls.Add(this.cbxCindt);
            this.Controls.Add(this.cbxDept);
            this.Controls.Add(this.cbxTtscode);
            this.Controls.Add(this.comboBoxSheet);
            this.Controls.Add(this.cbxNobr);
            this.Controls.Add(this.lblCindt);
            this.Controls.Add(this.lblAdate);
            this.Controls.Add(this.lblTtscode);
            this.Controls.Add(this.lblCard);
            this.Controls.Add(this.lblMemo);
            this.Controls.Add(this.lblDepta);
            this.Controls.Add(this.lblEmpcd);
            this.Controls.Add(this.lblDI);
            this.Controls.Add(this.lblHoliCD);
            this.Controls.Add(this.lblTtscd);
            this.Controls.Add(this.lblRotet);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblJob);
            this.Controls.Add(this.lblNobr);
            this.Controls.Add(this.lblDepts);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "BASETTSI";
            this.Text = "BASETTSI";
            this.Load += new System.EventHandler(this.BASETTSI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tTSCODEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.basDS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCard;
        private System.Windows.Forms.Label lblTtscd;
        private System.Windows.Forms.Label lblMemo;
        private System.Windows.Forms.Label lblEmpcd;
        private System.Windows.Forms.Label lblDI;
        private System.Windows.Forms.Label lblJob;
        private System.Windows.Forms.Label lblDepts;
        private System.Windows.Forms.Label lblDepta;
        private System.Windows.Forms.Label lblCindt;
        private System.Windows.Forms.Label lblAdate;
        private System.Windows.Forms.Label lblTtscode;
        private System.Windows.Forms.Label lblNobr;
        private System.Windows.Forms.ComboBox cbxNobr;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ComboBox cbxName;
        private System.Windows.Forms.ComboBox cbxTtscode;
        private System.Windows.Forms.ComboBox cbxCindt;
        private System.Windows.Forms.ComboBox cbxDepts;
        private System.Windows.Forms.ComboBox cbxDeptm;
        private System.Windows.Forms.ComboBox cbxCard;
        private System.Windows.Forms.ComboBox cbxDI;
        private System.Windows.Forms.ComboBox cbxJob;
        private System.Windows.Forms.ComboBox cbxEmpcd;
        private System.Windows.Forms.ComboBox cbxTtscd;
        private System.Windows.Forms.ComboBox cbxMemo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnBrower;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxSheet;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private JBControls.TextBox txtAdate;
        private System.Windows.Forms.Label lblDept;
        private System.Windows.Forms.Label lblJobl;
        private System.Windows.Forms.Label lblJobs;
        private System.Windows.Forms.ComboBox cbxDept;
        private System.Windows.Forms.ComboBox cbxJobl;
        private System.Windows.Forms.ComboBox cbxJobs;
        private BasDS basDS;
        private System.Windows.Forms.BindingSource tTSCODEBindingSource;
        private BasDSTableAdapters.TTSCODETableAdapter tTSCODETableAdapter;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRotet;
        private System.Windows.Forms.ComboBox cbxRotet;
        private System.Windows.Forms.Label lblHoliCD;
        private System.Windows.Forms.ComboBox cbxHoliCD;
    }
}