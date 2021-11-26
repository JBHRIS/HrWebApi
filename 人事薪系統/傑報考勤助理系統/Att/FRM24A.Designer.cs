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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ptxNobrB = new JBControls.PopupTextBox();
            this.bASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsBas = new JBHR.Att.dsBas();
            this.ptxNobrE = new JBControls.PopupTextBox();
            this.ptxDeptB = new JBControls.PopupTextBox();
            this.dEPTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ptxDeptE = new JBControls.PopupTextBox();
            this.ptxRoteB = new JBControls.PopupTextBox();
            this.rOTEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsAtt = new JBHR.Att.dsAtt();
            this.ptxRoteE = new JBControls.PopupTextBox();
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
            this.basDS = new JBHR.Bas.BasDS();
            this.dEPTBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dEPTTableAdapter1 = new JBHR.Bas.BasDSTableAdapters.DEPTTableAdapter();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEPTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rOTEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.basDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEPTBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(35, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "工號";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "部門";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(37, 139);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 44);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(208, 21);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(47, 16);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "外勞";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(107, 21);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(47, 16);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "本勞";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 21);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(47, 16);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "全部";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "班別";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(88, 252);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "產生";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(195, 252);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "離開";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            this.ptxNobrB.Location = new System.Drawing.Point(73, 27);
            this.ptxNobrB.Name = "ptxNobrB";
            this.ptxNobrB.ReadOnly = false;
            this.ptxNobrB.Size = new System.Drawing.Size(50, 22);
            this.ptxNobrB.TabIndex = 0;
            this.ptxNobrB.ValueMember = "nobr";
            this.ptxNobrB.WhereCmd = "";
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
            // ptxNobrE
            // 
            this.ptxNobrE.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ptxNobrE.CaptionLabel = null;
            this.ptxNobrE.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ptxNobrE.DataSource = this.bASEBindingSource;
            this.ptxNobrE.DisplayMember = "name_c";
            this.ptxNobrE.IsEmpty = true;
            this.ptxNobrE.IsEmptyToQuery = true;
            this.ptxNobrE.IsMustBeFound = true;
            this.ptxNobrE.LabelText = "";
            this.ptxNobrE.Location = new System.Drawing.Point(183, 27);
            this.ptxNobrE.Name = "ptxNobrE";
            this.ptxNobrE.ReadOnly = false;
            this.ptxNobrE.Size = new System.Drawing.Size(50, 22);
            this.ptxNobrE.TabIndex = 1;
            this.ptxNobrE.ValueMember = "nobr";
            this.ptxNobrE.WhereCmd = "";
            // 
            // ptxDeptB
            // 
            this.ptxDeptB.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ptxDeptB.CaptionLabel = null;
            this.ptxDeptB.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ptxDeptB.DataSource = this.dEPTBindingSource1;
            this.ptxDeptB.DisplayMember = "d_name";
            this.ptxDeptB.IsEmpty = true;
            this.ptxDeptB.IsEmptyToQuery = true;
            this.ptxDeptB.IsMustBeFound = true;
            this.ptxDeptB.LabelText = "";
            this.ptxDeptB.Location = new System.Drawing.Point(73, 55);
            this.ptxDeptB.Name = "ptxDeptB";
            this.ptxDeptB.ReadOnly = false;
            this.ptxDeptB.Size = new System.Drawing.Size(50, 22);
            this.ptxDeptB.TabIndex = 2;
            this.ptxDeptB.ValueMember = "d_no";
            this.ptxDeptB.WhereCmd = "";
            // 
            // dEPTBindingSource
            // 
            this.dEPTBindingSource.DataMember = "DEPT";
            this.dEPTBindingSource.DataSource = this.dsBas;
            // 
            // ptxDeptE
            // 
            this.ptxDeptE.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ptxDeptE.CaptionLabel = null;
            this.ptxDeptE.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ptxDeptE.DataSource = this.dEPTBindingSource1;
            this.ptxDeptE.DisplayMember = "d_name";
            this.ptxDeptE.IsEmpty = true;
            this.ptxDeptE.IsEmptyToQuery = true;
            this.ptxDeptE.IsMustBeFound = true;
            this.ptxDeptE.LabelText = "";
            this.ptxDeptE.Location = new System.Drawing.Point(183, 55);
            this.ptxDeptE.Name = "ptxDeptE";
            this.ptxDeptE.ReadOnly = false;
            this.ptxDeptE.Size = new System.Drawing.Size(50, 22);
            this.ptxDeptE.TabIndex = 3;
            this.ptxDeptE.ValueMember = "d_no";
            this.ptxDeptE.WhereCmd = "";
            // 
            // ptxRoteB
            // 
            this.ptxRoteB.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ptxRoteB.CaptionLabel = null;
            this.ptxRoteB.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ptxRoteB.DataSource = this.rOTEBindingSource;
            this.ptxRoteB.DisplayMember = "rotename";
            this.ptxRoteB.IsEmpty = true;
            this.ptxRoteB.IsEmptyToQuery = true;
            this.ptxRoteB.IsMustBeFound = true;
            this.ptxRoteB.LabelText = "";
            this.ptxRoteB.Location = new System.Drawing.Point(73, 82);
            this.ptxRoteB.Name = "ptxRoteB";
            this.ptxRoteB.ReadOnly = false;
            this.ptxRoteB.Size = new System.Drawing.Size(50, 22);
            this.ptxRoteB.TabIndex = 4;
            this.ptxRoteB.ValueMember = "rote";
            this.ptxRoteB.WhereCmd = "";
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
            // ptxRoteE
            // 
            this.ptxRoteE.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ptxRoteE.CaptionLabel = null;
            this.ptxRoteE.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ptxRoteE.DataSource = this.rOTEBindingSource;
            this.ptxRoteE.DisplayMember = "rotename";
            this.ptxRoteE.IsEmpty = true;
            this.ptxRoteE.IsEmptyToQuery = true;
            this.ptxRoteE.IsMustBeFound = true;
            this.ptxRoteE.LabelText = "";
            this.ptxRoteE.Location = new System.Drawing.Point(183, 82);
            this.ptxRoteE.Name = "ptxRoteE";
            this.ptxRoteE.ReadOnly = false;
            this.ptxRoteE.Size = new System.Drawing.Size(50, 22);
            this.ptxRoteE.TabIndex = 5;
            this.ptxRoteE.ValueMember = "rote";
            this.ptxRoteE.WhereCmd = "";
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
            this.label4.Location = new System.Drawing.Point(35, 115);
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
            this.txtDateB.Location = new System.Drawing.Point(73, 110);
            this.txtDateB.Mask = "0000/00/00";
            this.txtDateB.MaxLength = -1;
            this.txtDateB.Name = "txtDateB";
            this.txtDateB.PasswordChar = '\0';
            this.txtDateB.ReadOnly = false;
            this.txtDateB.Size = new System.Drawing.Size(70, 22);
            this.txtDateB.TabIndex = 6;
            this.txtDateB.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // txtDateE
            // 
            this.txtDateE.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtDateE.CaptionLabel = null;
            this.txtDateE.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDateE.DecimalPlace = 2;
            this.txtDateE.IsEmpty = true;
            this.txtDateE.Location = new System.Drawing.Point(183, 110);
            this.txtDateE.Mask = "0000/00/00";
            this.txtDateE.MaxLength = -1;
            this.txtDateE.Name = "txtDateE";
            this.txtDateE.PasswordChar = '\0';
            this.txtDateE.ReadOnly = false;
            this.txtDateE.Size = new System.Drawing.Size(70, 22);
            this.txtDateE.TabIndex = 7;
            this.txtDateE.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.rdb23);
            this.groupBox2.Controls.Add(this.rdb22);
            this.groupBox2.Controls.Add(this.rdb21);
            this.groupBox2.Location = new System.Drawing.Point(37, 189);
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
            this.rdb23.TabStop = true;
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
            this.rdb22.TabStop = true;
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
            this.rdb21.TabStop = true;
            this.rdb21.Text = "全部";
            this.rdb21.UseVisualStyleBackColor = true;
            // 
            // basDS
            // 
            this.basDS.DataSetName = "BasDS";
            this.basDS.Locale = new System.Globalization.CultureInfo("");
            this.basDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dEPTBindingSource1
            // 
            this.dEPTBindingSource1.DataMember = "DEPT";
            this.dEPTBindingSource1.DataSource = this.basDS;
            // 
            // dEPTTableAdapter1
            // 
            this.dEPTTableAdapter1.ClearBeforeFill = true;
            // 
            // FRM24A
            // 
            this.ClientSize = new System.Drawing.Size(370, 287);
            this.Controls.Add(this.txtDateE);
            this.Controls.Add(this.txtDateB);
            this.Controls.Add(this.ptxRoteE);
            this.Controls.Add(this.ptxDeptE);
            this.Controls.Add(this.ptxNobrE);
            this.Controls.Add(this.ptxRoteB);
            this.Controls.Add(this.ptxDeptB);
            this.Controls.Add(this.ptxNobrB);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "FRM24A";
            this.Text = "FRM25A-產生刷卡資料";
            this.Load += new System.EventHandler(this.FRM25A_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEPTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rOTEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAtt)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.basDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEPTBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private JBControls.PopupTextBox ptxNobrB;
        private JBControls.PopupTextBox ptxNobrE;
        private JBControls.PopupTextBox ptxDeptB;
        private JBControls.PopupTextBox ptxDeptE;
        private JBControls.PopupTextBox ptxRoteB;
        private JBControls.PopupTextBox ptxRoteE;
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
    }
}
