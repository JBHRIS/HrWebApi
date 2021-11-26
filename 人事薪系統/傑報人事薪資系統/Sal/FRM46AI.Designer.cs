namespace JBHR.Sal
{
    partial class FRM46AI
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
            this.sALCODEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.salaryDS = new JBHR.Sal.SalaryDS();
            this.cbAmt = new System.Windows.Forms.ComboBox();
            this.cbMemo = new System.Windows.Forms.ComboBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.sALCODETableAdapter = new JBHR.Sal.SalaryDSTableAdapters.SALCODETableAdapter();
            this.btnPreview = new System.Windows.Forms.Button();
            this.lblAdate = new System.Windows.Forms.Label();
            this.lblNobr = new System.Windows.Forms.Label();
            this.lblSalcode = new System.Windows.Forms.Label();
            this.lblAmt = new System.Windows.Forms.Label();
            this.lblMemo = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.iMPORTTYPEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.viewDS = new JBHR.Sal.ViewDS();
            this.iMPORT_TYPETableAdapter = new JBHR.Sal.ViewDSTableAdapters.IMPORT_TYPETableAdapter();
            this.cbxSalcode = new System.Windows.Forms.ComboBox();
            this.txtAdate = new JBControls.TextBox();
            this.cbxSheet = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
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
            this.btnBrowser.TabIndex = 0;
            this.btnBrowser.Text = "瀏覽";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // cbNobr
            // 
            this.cbNobr.FormattingEnabled = true;
            this.cbNobr.Location = new System.Drawing.Point(75, 113);
            this.cbNobr.Name = "cbNobr";
            this.cbNobr.Size = new System.Drawing.Size(86, 20);
            this.cbNobr.TabIndex = 3;
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
            this.cbAmt.Location = new System.Drawing.Point(75, 167);
            this.cbAmt.Name = "cbAmt";
            this.cbAmt.Size = new System.Drawing.Size(86, 20);
            this.cbAmt.TabIndex = 5;
            // 
            // cbMemo
            // 
            this.cbMemo.FormattingEnabled = true;
            this.cbMemo.Location = new System.Drawing.Point(75, 194);
            this.cbMemo.Name = "cbMemo";
            this.cbMemo.Size = new System.Drawing.Size(86, 20);
            this.cbMemo.TabIndex = 6;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(261, 192);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 8;
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
            this.btnPreview.Location = new System.Drawing.Point(177, 192);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 7;
            this.btnPreview.Text = "預覽";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // lblAdate
            // 
            this.lblAdate.AutoSize = true;
            this.lblAdate.Location = new System.Drawing.Point(16, 93);
            this.lblAdate.Name = "lblAdate";
            this.lblAdate.Size = new System.Drawing.Size(53, 12);
            this.lblAdate.TabIndex = 12;
            this.lblAdate.Text = "生效日期";
            // 
            // lblNobr
            // 
            this.lblNobr.AutoSize = true;
            this.lblNobr.Location = new System.Drawing.Point(16, 118);
            this.lblNobr.Name = "lblNobr";
            this.lblNobr.Size = new System.Drawing.Size(53, 12);
            this.lblNobr.TabIndex = 13;
            this.lblNobr.Text = "員工編號";
            // 
            // lblSalcode
            // 
            this.lblSalcode.AutoSize = true;
            this.lblSalcode.Location = new System.Drawing.Point(16, 145);
            this.lblSalcode.Name = "lblSalcode";
            this.lblSalcode.Size = new System.Drawing.Size(53, 12);
            this.lblSalcode.TabIndex = 14;
            this.lblSalcode.Text = "薪資代碼";
            // 
            // lblAmt
            // 
            this.lblAmt.AutoSize = true;
            this.lblAmt.Location = new System.Drawing.Point(40, 171);
            this.lblAmt.Name = "lblAmt";
            this.lblAmt.Size = new System.Drawing.Size(29, 12);
            this.lblAmt.TabIndex = 15;
            this.lblAmt.Text = "金額";
            // 
            // lblMemo
            // 
            this.lblMemo.AutoSize = true;
            this.lblMemo.Location = new System.Drawing.Point(40, 198);
            this.lblMemo.Name = "lblMemo";
            this.lblMemo.Size = new System.Drawing.Size(29, 12);
            this.lblMemo.TabIndex = 16;
            this.lblMemo.Text = "備註";
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "原有資料";
            this.label6.Visible = false;
            // 
            // cbType
            // 
            this.cbType.DataSource = this.iMPORTTYPEBindingSource;
            this.cbType.DisplayMember = "NAME";
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(75, 230);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(86, 20);
            this.cbType.TabIndex = 6;
            this.cbType.ValueMember = "CODE";
            this.cbType.Visible = false;
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
            // cbxSalcode
            // 
            this.cbxSalcode.FormattingEnabled = true;
            this.cbxSalcode.Location = new System.Drawing.Point(75, 141);
            this.cbxSalcode.Name = "cbxSalcode";
            this.cbxSalcode.Size = new System.Drawing.Size(86, 20);
            this.cbxSalcode.TabIndex = 4;
            // 
            // txtAdate
            // 
            this.txtAdate.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtAdate.CaptionLabel = null;
            this.txtAdate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtAdate.DecimalPlace = 2;
            this.txtAdate.IsEmpty = true;
            this.txtAdate.Location = new System.Drawing.Point(75, 86);
            this.txtAdate.Mask = "0000/00/00";
            this.txtAdate.MaxLength = -1;
            this.txtAdate.Name = "txtAdate";
            this.txtAdate.PasswordChar = '\0';
            this.txtAdate.ReadOnly = false;
            this.txtAdate.ShowCalendarButton = true;
            this.txtAdate.Size = new System.Drawing.Size(72, 22);
            this.txtAdate.TabIndex = 2;
            this.txtAdate.ValidType = JBControls.TextBox.EValidType.Date;
            // 
            // cbxSheet
            // 
            this.cbxSheet.DisplayMember = "NAME";
            this.cbxSheet.FormattingEnabled = true;
            this.cbxSheet.Location = new System.Drawing.Point(75, 60);
            this.cbxSheet.Name = "cbxSheet";
            this.cbxSheet.Size = new System.Drawing.Size(86, 20);
            this.cbxSheet.TabIndex = 1;
            this.cbxSheet.ValueMember = "CODE";
            this.cbxSheet.SelectedIndexChanged += new System.EventHandler(this.cbxSheet_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 17;
            this.label8.Text = "工作表";
            // 
            // FRM46AI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 227);
            this.Controls.Add(this.txtAdate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblMemo);
            this.Controls.Add(this.lblAmt);
            this.Controls.Add(this.lblSalcode);
            this.Controls.Add(this.lblNobr);
            this.Controls.Add(this.lblAdate);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.cbxSheet);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.cbMemo);
            this.Controls.Add(this.cbAmt);
            this.Controls.Add(this.cbxSalcode);
            this.Controls.Add(this.cbNobr);
            this.Controls.Add(this.btnBrowser);
            this.Controls.Add(this.textBox1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "FRM46AI";
            this.Text = "FRM46AI";
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
        private System.Windows.Forms.ComboBox cbAmt;
        private System.Windows.Forms.ComboBox cbMemo;
        private System.Windows.Forms.Button btnImport;
        private SalaryDS salaryDS;
        private System.Windows.Forms.BindingSource sALCODEBindingSource;
        private JBHR.Sal.SalaryDSTableAdapters.SALCODETableAdapter sALCODETableAdapter;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Label lblAdate;
        private System.Windows.Forms.Label lblNobr;
        private System.Windows.Forms.Label lblSalcode;
        private System.Windows.Forms.Label lblAmt;
        private System.Windows.Forms.Label lblMemo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbType;
        private ViewDS viewDS;
        private System.Windows.Forms.BindingSource iMPORTTYPEBindingSource;
        private JBHR.Sal.ViewDSTableAdapters.IMPORT_TYPETableAdapter iMPORT_TYPETableAdapter;
        private System.Windows.Forms.ComboBox cbxSalcode;
        private JBControls.TextBox txtAdate;
        private System.Windows.Forms.ComboBox cbxSheet;
        private System.Windows.Forms.Label label8;

    }
}