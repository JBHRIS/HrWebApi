namespace JBHR.Ins
{
    partial class FRM3V
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbxDeptE = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ptxNobrB = new JBControls.PopupTextBox();
            this.vBASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainDS = new JBHR.MainDS();
            this.ptxNobrE = new JBControls.PopupTextBox();
            this.cbxDeptB = new System.Windows.Forms.ComboBox();
            this.dEPTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.basDS = new JBHR.Bas.BasDS();
            this.txtYYMM = new JBControls.TextBox();
            this.txtSeq = new JBControls.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnGen = new System.Windows.Forms.Button();
            this.v_BASETableAdapter = new JBHR.MainDSTableAdapters.V_BASETableAdapter();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFileName = new JBControls.TextBox();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.dEPTTableAdapter = new JBHR.Bas.BasDSTableAdapters.DEPTTableAdapter();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxYYMM1 = new JBControls.TextBox();
            this.textBoxSeq1 = new JBControls.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxYear = new JBControls.TextBox();
            this.comboBoxInsComp = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vBASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEPTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.basDS)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 176F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 194F));
            this.tableLayoutPanel1.Controls.Add(this.cbxDeptE, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.ptxNobrB, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.ptxNobrE, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbxDeptB, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(24, 71);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(452, 59);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // cbxDeptE
            // 
            this.cbxDeptE.FormattingEnabled = true;
            this.cbxDeptE.Location = new System.Drawing.Point(261, 31);
            this.cbxDeptE.Name = "cbxDeptE";
            this.cbxDeptE.Size = new System.Drawing.Size(159, 20);
            this.cbxDeptE.TabIndex = 3;
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
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(238, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "至";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "部門代碼";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(238, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "至";
            // 
            // ptxNobrB
            // 
            this.ptxNobrB.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ptxNobrB.CaptionLabel = null;
            this.ptxNobrB.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ptxNobrB.DataSource = this.vBASEBindingSource;
            this.ptxNobrB.DisplayMember = "name_c";
            this.ptxNobrB.IsEmpty = true;
            this.ptxNobrB.IsEmptyToQuery = true;
            this.ptxNobrB.IsMustBeFound = true;
            this.ptxNobrB.LabelText = "";
            this.ptxNobrB.Location = new System.Drawing.Point(62, 3);
            this.ptxNobrB.Name = "ptxNobrB";
            this.ptxNobrB.ReadOnly = false;
            this.ptxNobrB.ShowDisplayName = true;
            this.ptxNobrB.Size = new System.Drawing.Size(100, 22);
            this.ptxNobrB.TabIndex = 0;
            this.ptxNobrB.ValueMember = "nobr";
            this.ptxNobrB.WhereCmd = "";
            // 
            // vBASEBindingSource
            // 
            this.vBASEBindingSource.DataMember = "V_BASE";
            this.vBASEBindingSource.DataSource = this.mainDS;
            // 
            // mainDS
            // 
            this.mainDS.DataSetName = "MainDS";
            this.mainDS.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.mainDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ptxNobrE
            // 
            this.ptxNobrE.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ptxNobrE.CaptionLabel = null;
            this.ptxNobrE.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ptxNobrE.DataSource = this.vBASEBindingSource;
            this.ptxNobrE.DisplayMember = "name_c";
            this.ptxNobrE.IsEmpty = true;
            this.ptxNobrE.IsEmptyToQuery = true;
            this.ptxNobrE.IsMustBeFound = true;
            this.ptxNobrE.LabelText = "";
            this.ptxNobrE.Location = new System.Drawing.Point(261, 3);
            this.ptxNobrE.Name = "ptxNobrE";
            this.ptxNobrE.ReadOnly = false;
            this.ptxNobrE.ShowDisplayName = true;
            this.ptxNobrE.Size = new System.Drawing.Size(100, 22);
            this.ptxNobrE.TabIndex = 1;
            this.ptxNobrE.ValueMember = "nobr";
            this.ptxNobrE.WhereCmd = "";
            // 
            // cbxDeptB
            // 
            this.cbxDeptB.FormattingEnabled = true;
            this.cbxDeptB.Location = new System.Drawing.Point(62, 31);
            this.cbxDeptB.Name = "cbxDeptB";
            this.cbxDeptB.Size = new System.Drawing.Size(159, 20);
            this.cbxDeptB.TabIndex = 2;
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
            this.basDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtYYMM
            // 
            this.txtYYMM.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtYYMM.CaptionLabel = null;
            this.txtYYMM.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtYYMM.DecimalPlace = 2;
            this.txtYYMM.IsEmpty = true;
            this.txtYYMM.Location = new System.Drawing.Point(86, 43);
            this.txtYYMM.Mask = "";
            this.txtYYMM.MaxLength = -1;
            this.txtYYMM.Name = "txtYYMM";
            this.txtYYMM.PasswordChar = '\0';
            this.txtYYMM.ReadOnly = false;
            this.txtYYMM.ShowCalendarButton = true;
            this.txtYYMM.Size = new System.Drawing.Size(76, 22);
            this.txtYYMM.TabIndex = 2;
            this.txtYYMM.ValidType = JBControls.TextBox.EValidType.String;
            this.txtYYMM.Validated += new System.EventHandler(this.txtYYMM_Validated);
            // 
            // txtSeq
            // 
            this.txtSeq.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtSeq.CaptionLabel = null;
            this.txtSeq.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtSeq.DecimalPlace = 2;
            this.txtSeq.IsEmpty = true;
            this.txtSeq.Location = new System.Drawing.Point(168, 43);
            this.txtSeq.Mask = "";
            this.txtSeq.MaxLength = -1;
            this.txtSeq.Name = "txtSeq";
            this.txtSeq.PasswordChar = '\0';
            this.txtSeq.ReadOnly = false;
            this.txtSeq.ShowCalendarButton = true;
            this.txtSeq.Size = new System.Drawing.Size(40, 22);
            this.txtSeq.TabIndex = 3;
            this.txtSeq.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "薪資年月";
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(332, 172);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(91, 23);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "離開";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnGen
            // 
            this.btnGen.Location = new System.Drawing.Point(215, 172);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(91, 23);
            this.btnGen.TabIndex = 9;
            this.btnGen.Text = "產生媒體檔";
            this.btnGen.UseVisualStyleBackColor = true;
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
            // 
            // v_BASETableAdapter
            // 
            this.v_BASETableAdapter.ClearBeforeFill = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "檔案路徑";
            // 
            // txtFileName
            // 
            this.txtFileName.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtFileName.CaptionLabel = null;
            this.txtFileName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtFileName.DecimalPlace = 2;
            this.txtFileName.IsEmpty = true;
            this.txtFileName.Location = new System.Drawing.Point(87, 136);
            this.txtFileName.Mask = "";
            this.txtFileName.MaxLength = -1;
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.PasswordChar = '\0';
            this.txtFileName.ReadOnly = false;
            this.txtFileName.ShowCalendarButton = true;
            this.txtFileName.Size = new System.Drawing.Size(336, 22);
            this.txtFileName.TabIndex = 6;
            this.txtFileName.TabStop = false;
            this.txtFileName.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // btnBrowser
            // 
            this.btnBrowser.Location = new System.Drawing.Point(429, 135);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(52, 23);
            this.btnBrowser.TabIndex = 7;
            this.btnBrowser.Text = "瀏覽";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // dEPTTableAdapter
            // 
            this.dEPTTableAdapter.ClearBeforeFill = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(262, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "至";
            // 
            // textBoxYYMM1
            // 
            this.textBoxYYMM1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxYYMM1.CaptionLabel = null;
            this.textBoxYYMM1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxYYMM1.DecimalPlace = 2;
            this.textBoxYYMM1.IsEmpty = true;
            this.textBoxYYMM1.Location = new System.Drawing.Point(284, 43);
            this.textBoxYYMM1.Mask = "";
            this.textBoxYYMM1.MaxLength = -1;
            this.textBoxYYMM1.Name = "textBoxYYMM1";
            this.textBoxYYMM1.PasswordChar = '\0';
            this.textBoxYYMM1.ReadOnly = false;
            this.textBoxYYMM1.ShowCalendarButton = true;
            this.textBoxYYMM1.Size = new System.Drawing.Size(76, 22);
            this.textBoxYYMM1.TabIndex = 4;
            this.textBoxYYMM1.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // textBoxSeq1
            // 
            this.textBoxSeq1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxSeq1.CaptionLabel = null;
            this.textBoxSeq1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxSeq1.DecimalPlace = 2;
            this.textBoxSeq1.IsEmpty = true;
            this.textBoxSeq1.Location = new System.Drawing.Point(366, 43);
            this.textBoxSeq1.Mask = "";
            this.textBoxSeq1.MaxLength = -1;
            this.textBoxSeq1.Name = "textBoxSeq1";
            this.textBoxSeq1.PasswordChar = '\0';
            this.textBoxSeq1.ReadOnly = false;
            this.textBoxSeq1.ShowCalendarButton = true;
            this.textBoxSeq1.Size = new System.Drawing.Size(40, 22);
            this.textBoxSeq1.TabIndex = 5;
            this.textBoxSeq1.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(96, 172);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "產生所得人資料";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(48, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "年度";
            // 
            // textBoxYear
            // 
            this.textBoxYear.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.textBoxYear.CaptionLabel = null;
            this.textBoxYear.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBoxYear.DecimalPlace = 2;
            this.textBoxYear.IsEmpty = true;
            this.textBoxYear.Location = new System.Drawing.Point(86, 15);
            this.textBoxYear.Mask = "";
            this.textBoxYear.MaxLength = -1;
            this.textBoxYear.Name = "textBoxYear";
            this.textBoxYear.PasswordChar = '\0';
            this.textBoxYear.ReadOnly = false;
            this.textBoxYear.ShowCalendarButton = true;
            this.textBoxYear.Size = new System.Drawing.Size(50, 22);
            this.textBoxYear.TabIndex = 0;
            this.textBoxYear.ValidType = JBControls.TextBox.EValidType.String;
            this.textBoxYear.Validated += new System.EventHandler(this.txtYYMM_Validated);
            // 
            // comboBoxInsComp
            // 
            this.comboBoxInsComp.FormattingEnabled = true;
            this.comboBoxInsComp.Location = new System.Drawing.Point(295, 17);
            this.comboBoxInsComp.Name = "comboBoxInsComp";
            this.comboBoxInsComp.Size = new System.Drawing.Size(121, 20);
            this.comboBoxInsComp.TabIndex = 1;
            this.comboBoxInsComp.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(236, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 5;
            this.label9.Text = "投保單位";
            this.label9.Visible = false;
            // 
            // FRM3V
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(507, 212);
            this.Controls.Add(this.comboBoxInsComp);
            this.Controls.Add(this.textBoxSeq1);
            this.Controls.Add(this.txtSeq);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxYYMM1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxYear);
            this.Controls.Add(this.txtYYMM);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnBrowser);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnGen);
            this.Controls.Add(this.label5);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "FRM3V";
            this.Text = "FRM3V";
            this.Load += new System.EventHandler(this.FRM3V_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vBASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEPTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.basDS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private JBControls.TextBox txtYYMM;
        private JBControls.TextBox txtSeq;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private JBControls.PopupTextBox ptxNobrB;
        private JBControls.PopupTextBox ptxNobrE;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnGen;
        private MainDS mainDS;
        private System.Windows.Forms.BindingSource vBASEBindingSource;
        private MainDSTableAdapters.V_BASETableAdapter v_BASETableAdapter;
        private System.Windows.Forms.Label label5;
        private JBControls.TextBox txtFileName;
        private System.Windows.Forms.Button btnBrowser;
        private Bas.BasDS basDS;
        private System.Windows.Forms.BindingSource dEPTBindingSource;
        private Bas.BasDSTableAdapters.DEPTTableAdapter dEPTTableAdapter;
        private System.Windows.Forms.Label label4;
        private JBControls.TextBox textBoxYYMM1;
        private JBControls.TextBox textBoxSeq1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private JBControls.TextBox textBoxYear;
        private System.Windows.Forms.ComboBox cbxDeptE;
        private System.Windows.Forms.ComboBox cbxDeptB;
        private System.Windows.Forms.ComboBox comboBoxInsComp;
        private System.Windows.Forms.Label label9;
    }
}