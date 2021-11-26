namespace JBHR.Sal
{
    partial class FRM46EI
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.cbNobr = new System.Windows.Forms.ComboBox();
            this.ptxSalcode = new JBControls.PopupTextBox();
            this.sALCODEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.salaryDS = new JBHR.Sal.SalaryDS();
            this.cbAmt = new System.Windows.Forms.ComboBox();
            this.cbMemo = new System.Windows.Forms.ComboBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.sALCODETableAdapter = new JBHR.Sal.SalaryDSTableAdapters.SALCODETableAdapter();
            this.btnPreview = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAdate = new JBControls.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.iMPORTTYPEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.viewDS = new JBHR.Sal.ViewDS();
            this.iMPORT_TYPETableAdapter = new JBHR.Sal.ViewDSTableAdapters.IMPORT_TYPETableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sALCODEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iMPORTTYPEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewDS)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(75, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(177, 22);
            this.textBox1.TabIndex = 0;
            // 
            // btnBrowser
            // 
            this.btnBrowser.Location = new System.Drawing.Point(258, 30);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(75, 23);
            this.btnBrowser.TabIndex = 1;
            this.btnBrowser.Text = "瀏覽";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // cbNobr
            // 
            this.cbNobr.FormattingEnabled = true;
            this.cbNobr.Location = new System.Drawing.Point(75, 88);
            this.cbNobr.Name = "cbNobr";
            this.cbNobr.Size = new System.Drawing.Size(86, 20);
            this.cbNobr.TabIndex = 4;
            // 
            // ptxSalcode
            // 
            this.ptxSalcode.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ptxSalcode.CaptionLabel = null;
            this.ptxSalcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ptxSalcode.DataSource = this.sALCODEBindingSource;
            this.ptxSalcode.DisplayMember = "sal_name";
            this.ptxSalcode.IsEmpty = true;
            this.ptxSalcode.IsEmptyToQuery = true;
            this.ptxSalcode.IsMustBeFound = true;
            this.ptxSalcode.LabelText = "";
            this.ptxSalcode.Location = new System.Drawing.Point(75, 114);
            this.ptxSalcode.Name = "ptxSalcode";
            this.ptxSalcode.ReadOnly = false;
            this.ptxSalcode.Size = new System.Drawing.Size(86, 22);
            this.ptxSalcode.TabIndex = 5;
            this.ptxSalcode.ValueMember = "sal_code";
            this.ptxSalcode.WhereCmd = "";
            // 
            // sALCODEBindingSource
            // 
            this.sALCODEBindingSource.DataMember = "SALCODE";
            this.sALCODEBindingSource.DataSource = this.salaryDS;
            // 
            // salaryDS
            // 
            this.salaryDS.DataSetName = "SalaryDS";
            this.salaryDS.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.salaryDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cbAmt
            // 
            this.cbAmt.FormattingEnabled = true;
            this.cbAmt.Location = new System.Drawing.Point(75, 142);
            this.cbAmt.Name = "cbAmt";
            this.cbAmt.Size = new System.Drawing.Size(86, 20);
            this.cbAmt.TabIndex = 6;
            // 
            // cbMemo
            // 
            this.cbMemo.FormattingEnabled = true;
            this.cbMemo.Location = new System.Drawing.Point(75, 169);
            this.cbMemo.Name = "cbMemo";
            this.cbMemo.Size = new System.Drawing.Size(86, 20);
            this.cbMemo.TabIndex = 7;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(258, 195);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 10;
            this.btnImport.Text = "轉檔";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // sALCODETableAdapter
            // 
            this.sALCODETableAdapter.ClearBeforeFill = true;
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(174, 195);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 9;
            this.btnPreview.Text = "預覽";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "生效日期";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "工號";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "薪資代碼";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "金額";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "備註";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "匯入檔名";
            // 
            // txtAdate
            // 
            this.txtAdate.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtAdate.CaptionLabel = null;
            this.txtAdate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtAdate.DecimalPlace = 2;
            this.txtAdate.IsEmpty = true;
            this.txtAdate.Location = new System.Drawing.Point(75, 60);
            this.txtAdate.Mask = "0000/00/00";
            this.txtAdate.MaxLength = -1;
            this.txtAdate.Name = "txtAdate";
            this.txtAdate.PasswordChar = '\0';
            this.txtAdate.ReadOnly = false;
            this.txtAdate.Size = new System.Drawing.Size(69, 22);
            this.txtAdate.TabIndex = 2;
            this.txtAdate.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "原有資料";
            // 
            // cbType
            // 
            this.cbType.DataSource = this.iMPORTTYPEBindingSource;
            this.cbType.DisplayMember = "NAME";
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(75, 195);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(86, 20);
            this.cbType.TabIndex = 8;
            this.cbType.ValueMember = "CODE";
            // 
            // iMPORTTYPEBindingSource
            // 
            this.iMPORTTYPEBindingSource.DataMember = "IMPORT_TYPE";
            this.iMPORTTYPEBindingSource.DataSource = this.viewDS;
            // 
            // viewDS
            // 
            this.viewDS.DataSetName = "ViewDS";
            this.viewDS.Locale = new System.Globalization.CultureInfo("zh-TW");
            this.viewDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // iMPORT_TYPETableAdapter
            // 
            this.iMPORT_TYPETableAdapter.ClearBeforeFill = true;
            // 
            // FRM46EI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 273);
            this.Controls.Add(this.txtAdate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.cbMemo);
            this.Controls.Add(this.cbAmt);
            this.Controls.Add(this.ptxSalcode);
            this.Controls.Add(this.cbNobr);
            this.Controls.Add(this.btnBrowser);
            this.Controls.Add(this.textBox1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "FRM46EI";
            this.Text = "FRM46EI";
            this.Load += new System.EventHandler(this.IP_FRM4L_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sALCODEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salaryDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iMPORTTYPEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewDS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.ComboBox cbNobr;
        private JBControls.PopupTextBox ptxSalcode;
        private System.Windows.Forms.ComboBox cbAmt;
        private System.Windows.Forms.ComboBox cbMemo;
        private System.Windows.Forms.Button btnImport;
        private SalaryDS salaryDS;
        private System.Windows.Forms.BindingSource sALCODEBindingSource;
        private JBHR.Sal.SalaryDSTableAdapters.SALCODETableAdapter sALCODETableAdapter;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private JBControls.TextBox txtAdate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbType;
        private ViewDS viewDS;
        private System.Windows.Forms.BindingSource iMPORTTYPEBindingSource;
        private JBHR.Sal.ViewDSTableAdapters.IMPORT_TYPETableAdapter iMPORT_TYPETableAdapter;

    }
}