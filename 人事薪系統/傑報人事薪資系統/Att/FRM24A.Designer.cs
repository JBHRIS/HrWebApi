namespace JBHR.Att
{
    partial class FRM24A
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
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.RadCheckedListDataItem radCheckedListDataItem1 = new Telerik.WinControls.UI.RadCheckedListDataItem();
            Telerik.WinControls.UI.RadCheckedListDataItem radCheckedListDataItem2 = new Telerik.WinControls.UI.RadCheckedListDataItem();
            this.btnCreate = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.bASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsBas = new JBHR.Att.dsBas();
            this.dEPTBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.basDS = new JBHR.Bas.BasDS();
            this.dEPTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rOTEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsAtt = new JBHR.Att.dsAtt();
            this.bASETableAdapter = new JBHR.Att.dsBasTableAdapters.BASETableAdapter();
            this.dEPTTableAdapter = new JBHR.Att.dsBasTableAdapters.DEPTTableAdapter();
            this.rOTETableAdapter = new JBHR.Att.dsAttTableAdapters.ROTETableAdapter();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDateB = new JBControls.TextBox();
            this.txtDateE = new JBControls.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdb23 = new System.Windows.Forms.RadioButton();
            this.rdb22 = new System.Windows.Forms.RadioButton();
            this.rdb21 = new System.Windows.Forms.RadioButton();
            this.dEPTTableAdapter1 = new JBHR.Bas.BasDSTableAdapters.DEPTTableAdapter();
            this.btnConfig = new System.Windows.Forms.Button();
            this.checkAbs = new JBControls.CheckBox();
            this.isRandom = new JBControls.CheckBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonEmp = new System.Windows.Forms.Button();
            this.radCheckedDropDownList1 = new Telerik.WinControls.UI.RadCheckedDropDownList();
            this.visualStudio2012LightTheme1 = new Telerik.WinControls.Themes.VisualStudio2012LightTheme();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.radCheckedDropDownList2 = new Telerik.WinControls.UI.RadCheckedDropDownList();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEPTBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.basDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEPTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rOTEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckedDropDownList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckedDropDownList2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.Location = new System.Drawing.Point(68, 214);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 5;
            this.btnCreate.Text = "產生";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(231, 214);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "離開";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // bASEBindingSource
            // 
            this.bASEBindingSource.DataMember = "BASE";
            this.bASEBindingSource.DataSource = this.dsBas;
            // 
            // dsBas
            // 
            this.dsBas.DataSetName = "dsBas";
            this.dsBas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dEPTBindingSource1
            // 
            this.dEPTBindingSource1.DataMember = "DEPT";
            this.dEPTBindingSource1.DataSource = this.basDS;
            // 
            // basDS
            // 
            this.basDS.DataSetName = "BasDS";
            this.basDS.Locale = new System.Globalization.CultureInfo("");
            this.basDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dEPTBindingSource
            // 
            this.dEPTBindingSource.DataMember = "DEPT";
            this.dEPTBindingSource.DataSource = this.dsBas;
            // 
            // rOTEBindingSource
            // 
            this.rOTEBindingSource.DataMember = "ROTE";
            this.rOTEBindingSource.DataSource = this.dsAtt;
            // 
            // dsAtt
            // 
            this.dsAtt.DataSetName = "dsAtt";
            this.dsAtt.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.dsAtt.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bASETableAdapter
            // 
            this.bASETableAdapter.ClearBeforeFill = true;
            // 
            // dEPTTableAdapter
            // 
            this.dEPTTableAdapter.ClearBeforeFill = true;
            // 
            // rOTETableAdapter
            // 
            this.rOTETableAdapter.ClearBeforeFill = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "日期";
            // 
            // txtDateB
            // 
            this.txtDateB.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtDateB.CaptionLabel = null;
            this.txtDateB.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDateB.DecimalPlace = 2;
            this.txtDateB.IsEmpty = true;
            this.txtDateB.Location = new System.Drawing.Point(80, 12);
            this.txtDateB.Mask = "0000/00/00";
            this.txtDateB.MaxLength = -1;
            this.txtDateB.Name = "txtDateB";
            this.txtDateB.PasswordChar = '\0';
            this.txtDateB.ReadOnly = false;
            this.txtDateB.ShowCalendarButton = true;
            this.txtDateB.Size = new System.Drawing.Size(70, 22);
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
            this.txtDateE.Location = new System.Drawing.Point(183, 12);
            this.txtDateE.Mask = "0000/00/00";
            this.txtDateE.MaxLength = -1;
            this.txtDateE.Name = "txtDateE";
            this.txtDateE.PasswordChar = '\0';
            this.txtDateE.ReadOnly = false;
            this.txtDateE.ShowCalendarButton = true;
            this.txtDateE.Size = new System.Drawing.Size(70, 22);
            this.txtDateE.TabIndex = 1;
            this.txtDateE.ValidType = JBControls.TextBox.EValidType.Date;
            this.txtDateE.Validated += new System.EventHandler(this.txtDateE_Validated);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.rdb23);
            this.groupBox2.Controls.Add(this.rdb22);
            this.groupBox2.Controls.Add(this.rdb21);
            this.groupBox2.Location = new System.Drawing.Point(44, 136);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(308, 44);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // rdb23
            // 
            this.rdb23.AutoSize = true;
            this.rdb23.Location = new System.Drawing.Point(208, 21);
            this.rdb23.Name = "rdb23";
            this.rdb23.Size = new System.Drawing.Size(59, 16);
            this.rdb23.TabIndex = 2;
            this.rdb23.Text = "下班卡";
            this.rdb23.UseVisualStyleBackColor = true;
            // 
            // rdb22
            // 
            this.rdb22.AutoSize = true;
            this.rdb22.Location = new System.Drawing.Point(107, 21);
            this.rdb22.Name = "rdb22";
            this.rdb22.Size = new System.Drawing.Size(59, 16);
            this.rdb22.TabIndex = 1;
            this.rdb22.Text = "上班卡";
            this.rdb22.UseVisualStyleBackColor = true;
            // 
            // rdb21
            // 
            this.rdb21.AutoSize = true;
            this.rdb21.Checked = true;
            this.rdb21.Location = new System.Drawing.Point(6, 21);
            this.rdb21.Name = "rdb21";
            this.rdb21.Size = new System.Drawing.Size(47, 16);
            this.rdb21.TabIndex = 0;
            this.rdb21.Text = "全部";
            this.rdb21.UseVisualStyleBackColor = true;
            // 
            // dEPTTableAdapter1
            // 
            this.dEPTTableAdapter1.ClearBeforeFill = true;
            // 
            // btnConfig
            // 
            this.btnConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfig.Location = new System.Drawing.Point(250, 185);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(102, 23);
            this.btnConfig.TabIndex = 34;
            this.btnConfig.TabStop = false;
            this.btnConfig.Tag = "FRM24A";
            this.btnConfig.Text = "分鐘數設定";
            this.btnConfig.UseVisualStyleBackColor = true;
            // 
            // checkAbs
            // 
            this.checkAbs.AutoSize = true;
            this.checkAbs.CaptionLabel = null;
            this.checkAbs.Checked = true;
            this.checkAbs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkAbs.IsImitateCaption = true;
            this.checkAbs.Location = new System.Drawing.Point(37, 187);
            this.checkAbs.Name = "checkAbs";
            this.checkAbs.Size = new System.Drawing.Size(72, 16);
            this.checkAbs.TabIndex = 35;
            this.checkAbs.TabStop = false;
            this.checkAbs.Text = "檢查請假";
            this.checkAbs.UseVisualStyleBackColor = true;
            // 
            // isRandom
            // 
            this.isRandom.AutoSize = true;
            this.isRandom.CaptionLabel = null;
            this.isRandom.IsImitateCaption = true;
            this.isRandom.Location = new System.Drawing.Point(115, 187);
            this.isRandom.Name = "isRandom";
            this.isRandom.Size = new System.Drawing.Size(108, 16);
            this.isRandom.TabIndex = 35;
            this.isRandom.TabStop = false;
            this.isRandom.Text = "隨機加減分鐘數";
            this.isRandom.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(150, 214);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "刪除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 36;
            this.label1.Text = "對象";
            // 
            // buttonEmp
            // 
            this.buttonEmp.Location = new System.Drawing.Point(80, 47);
            this.buttonEmp.Name = "buttonEmp";
            this.buttonEmp.Size = new System.Drawing.Size(75, 23);
            this.buttonEmp.TabIndex = 2;
            this.buttonEmp.Text = "(0)";
            this.buttonEmp.UseVisualStyleBackColor = true;
            // 
            // radCheckedDropDownList1
            // 
            this.radCheckedDropDownList1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.radCheckedDropDownList1.DataSource = this.rOTEBindingSource;
            this.radCheckedDropDownList1.DisplayMember = "ROTENAME";
            this.radCheckedDropDownList1.DropDownAnimationEnabled = false;
            this.radCheckedDropDownList1.Location = new System.Drawing.Point(80, 76);
            this.radCheckedDropDownList1.Name = "radCheckedDropDownList1";
            // 
            // 
            // 
            this.radCheckedDropDownList1.RootElement.ControlBounds = new System.Drawing.Rectangle(80, 76, 125, 20);
            this.radCheckedDropDownList1.RootElement.StretchVertically = true;
            this.radCheckedDropDownList1.ShowCheckAllItems = true;
            this.radCheckedDropDownList1.Size = new System.Drawing.Size(123, 24);
            this.radCheckedDropDownList1.TabIndex = 38;
            this.radCheckedDropDownList1.ThemeName = "VisualStudio2012Light";
            this.radCheckedDropDownList1.ValueMember = "ROTE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 36;
            this.label2.Text = "班別";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 36;
            this.label3.Text = "需刷卡";
            // 
            // radCheckedDropDownList2
            // 
            this.radCheckedDropDownList2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.radCheckedDropDownList2.DisplayMember = "ROTE_DISP+ROTENAME";
            this.radCheckedDropDownList2.DropDownAnimationEnabled = false;
            radCheckedListDataItem1.Text = "Y";
            radCheckedListDataItem2.Text = "N";
            this.radCheckedDropDownList2.Items.Add(radCheckedListDataItem1);
            this.radCheckedDropDownList2.Items.Add(radCheckedListDataItem2);
            this.radCheckedDropDownList2.Location = new System.Drawing.Point(80, 106);
            this.radCheckedDropDownList2.Name = "radCheckedDropDownList2";
            // 
            // 
            // 
            this.radCheckedDropDownList2.RootElement.ControlBounds = new System.Drawing.Rectangle(80, 106, 125, 20);
            this.radCheckedDropDownList2.RootElement.StretchVertically = true;
            this.radCheckedDropDownList2.ShowCheckAllItems = true;
            this.radCheckedDropDownList2.Size = new System.Drawing.Size(123, 24);
            this.radCheckedDropDownList2.TabIndex = 38;
            this.radCheckedDropDownList2.ThemeName = "VisualStudio2012Light";
            this.radCheckedDropDownList2.ValueMember = "ROTE";
            // 
            // FRM24A
            // 
            this.ClientSize = new System.Drawing.Size(370, 253);
            this.Controls.Add(this.radCheckedDropDownList2);
            this.Controls.Add(this.radCheckedDropDownList1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonEmp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.isRandom);
            this.Controls.Add(this.checkAbs);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.txtDateE);
            this.Controls.Add(this.txtDateB);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label4);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "FRM24A";
            this.Text = "FRM24A-產生刷卡資料";
            this.Load += new System.EventHandler(this.FRM25A_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEPTBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.basDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEPTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rOTEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckedDropDownList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckedDropDownList2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.BindingSource bASEBindingSource;
        private dsBas dsBas;
        private dsBasTableAdapters.BASETableAdapter bASETableAdapter;
        private System.Windows.Forms.BindingSource dEPTBindingSource;
        private dsBasTableAdapters.DEPTTableAdapter dEPTTableAdapter;
        private dsAtt dsAtt;
        private System.Windows.Forms.BindingSource rOTEBindingSource;
        private dsAttTableAdapters.ROTETableAdapter rOTETableAdapter;
        private System.Windows.Forms.Label label4;
        private JBControls.TextBox txtDateB;
        private JBControls.TextBox txtDateE;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdb23;
        private System.Windows.Forms.RadioButton rdb22;
        private System.Windows.Forms.RadioButton rdb21;
        private Bas.BasDS basDS;
        private System.Windows.Forms.BindingSource dEPTBindingSource1;
        private Bas.BasDSTableAdapters.DEPTTableAdapter dEPTTableAdapter1;
        private System.Windows.Forms.Button btnConfig;
        private JBControls.CheckBox checkAbs;
        private JBControls.CheckBox isRandom;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonEmp;
        private Telerik.WinControls.UI.RadCheckedDropDownList radCheckedDropDownList1;
        private Telerik.WinControls.Themes.VisualStudio2012LightTheme visualStudio2012LightTheme1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Telerik.WinControls.UI.RadCheckedDropDownList radCheckedDropDownList2;
    }
}
