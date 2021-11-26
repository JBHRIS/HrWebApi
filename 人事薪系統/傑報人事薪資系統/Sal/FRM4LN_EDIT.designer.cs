namespace JBHR.Sal
{
    partial class FRM4LN_EDIT
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
            this.label1 = new System.Windows.Forms.Label();
            this.ptxNobr = new JBControls.PopupTextBox();
            this.vBASEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.basDS = new JBHR.Bas.BasDS();
            this.txtYymm = new JBControls.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSeq = new JBControls.TextBox();
            this.ptxSalcode = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMemo = new JBControls.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxContract = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbFA_IDNO = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.v_BASETableAdapter = new JBHR.Bas.BasDSTableAdapters.V_BASETableAdapter();
            this.txtAmt = new JBControls.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.vBASEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.basDS)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(27, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "員工編號";
            // 
            // ptxNobr
            // 
            this.ptxNobr.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ptxNobr.CaptionLabel = this.label1;
            this.ptxNobr.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ptxNobr.DataSource = this.vBASEBindingSource;
            this.ptxNobr.DisplayMember = "name_c";
            this.ptxNobr.IsEmpty = true;
            this.ptxNobr.IsEmptyToQuery = true;
            this.ptxNobr.IsMustBeFound = true;
            this.ptxNobr.LabelText = "";
            this.ptxNobr.Location = new System.Drawing.Point(86, 12);
            this.ptxNobr.Name = "ptxNobr";
            this.ptxNobr.ReadOnly = false;
            this.ptxNobr.ShowDisplayName = true;
            this.ptxNobr.Size = new System.Drawing.Size(105, 22);
            this.ptxNobr.TabIndex = 0;
            this.ptxNobr.ValueMember = "nobr";
            this.ptxNobr.WhereCmd = "";
            this.ptxNobr.QueryCompleted += new JBControls.PopupTextBox.QueryCompletedHandler(this.ptxNobr_QueryCompleted);
            // 
            // vBASEBindingSource
            // 
            this.vBASEBindingSource.DataMember = "V_BASE";
            this.vBASEBindingSource.DataSource = this.basDS;
            // 
            // basDS
            // 
            this.basDS.DataSetName = "BasDS";
            this.basDS.Locale = new System.Globalization.CultureInfo("");
            this.basDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtYymm
            // 
            this.txtYymm.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtYymm.CaptionLabel = null;
            this.txtYymm.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtYymm.DecimalPlace = 2;
            this.txtYymm.IsEmpty = false;
            this.txtYymm.Location = new System.Drawing.Point(86, 66);
            this.txtYymm.Mask = "";
            this.txtYymm.MaxLength = 50;
            this.txtYymm.Name = "txtYymm";
            this.txtYymm.PasswordChar = '\0';
            this.txtYymm.ReadOnly = false;
            this.txtYymm.ShowCalendarButton = true;
            this.txtYymm.Size = new System.Drawing.Size(65, 22);
            this.txtYymm.TabIndex = 3;
            this.txtYymm.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(27, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "計薪年月";
            // 
            // txtSeq
            // 
            this.txtSeq.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtSeq.CaptionLabel = null;
            this.txtSeq.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtSeq.DecimalPlace = 2;
            this.txtSeq.IsEmpty = false;
            this.txtSeq.Location = new System.Drawing.Point(159, 66);
            this.txtSeq.Mask = "";
            this.txtSeq.MaxLength = 50;
            this.txtSeq.Name = "txtSeq";
            this.txtSeq.PasswordChar = '\0';
            this.txtSeq.ReadOnly = false;
            this.txtSeq.ShowCalendarButton = true;
            this.txtSeq.Size = new System.Drawing.Size(40, 22);
            this.txtSeq.TabIndex = 4;
            this.txtSeq.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // ptxSalcode
            // 
            this.ptxSalcode.FormattingEnabled = true;
            this.ptxSalcode.Location = new System.Drawing.Point(86, 94);
            this.ptxSalcode.Name = "ptxSalcode";
            this.ptxSalcode.Size = new System.Drawing.Size(121, 20);
            this.ptxSalcode.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(27, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "薪資代碼";
            // 
            // txtMemo
            // 
            this.txtMemo.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtMemo.CaptionLabel = null;
            this.txtMemo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtMemo.DecimalPlace = 2;
            this.txtMemo.IsEmpty = true;
            this.txtMemo.Location = new System.Drawing.Point(86, 148);
            this.txtMemo.Mask = "";
            this.txtMemo.MaxLength = 120;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.PasswordChar = '\0';
            this.txtMemo.ReadOnly = false;
            this.txtMemo.ShowCalendarButton = true;
            this.txtMemo.Size = new System.Drawing.Size(428, 22);
            this.txtMemo.TabIndex = 7;
            this.txtMemo.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(51, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "備註";
            // 
            // comboBoxContract
            // 
            this.comboBoxContract.Enabled = false;
            this.comboBoxContract.FormattingEnabled = true;
            this.comboBoxContract.Location = new System.Drawing.Point(86, 40);
            this.comboBoxContract.Name = "comboBoxContract";
            this.comboBoxContract.Size = new System.Drawing.Size(428, 20);
            this.comboBoxContract.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(51, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "合同";
            // 
            // cbFA_IDNO
            // 
            this.cbFA_IDNO.FormattingEnabled = true;
            this.cbFA_IDNO.Location = new System.Drawing.Point(347, 14);
            this.cbFA_IDNO.Name = "cbFA_IDNO";
            this.cbFA_IDNO.Size = new System.Drawing.Size(167, 20);
            this.cbFA_IDNO.TabIndex = 1;
            this.cbFA_IDNO.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(291, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 18;
            this.label6.Text = "眷屬身號";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(159, 191);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "存檔";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(293, 191);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.TabStop = false;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // v_BASETableAdapter
            // 
            this.v_BASETableAdapter.ClearBeforeFill = true;
            // 
            // txtAmt
            // 
            this.txtAmt.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtAmt.CaptionLabel = null;
            this.txtAmt.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtAmt.DecimalPlace = 2;
            this.txtAmt.IsEmpty = false;
            this.txtAmt.Location = new System.Drawing.Point(86, 120);
            this.txtAmt.Mask = "";
            this.txtAmt.MaxLength = -1;
            this.txtAmt.Name = "txtAmt";
            this.txtAmt.PasswordChar = '\0';
            this.txtAmt.ReadOnly = false;
            this.txtAmt.ShowCalendarButton = true;
            this.txtAmt.Size = new System.Drawing.Size(100, 22);
            this.txtAmt.TabIndex = 6;
            this.txtAmt.ValidType = JBControls.TextBox.EValidType.Decimal;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(51, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 20;
            this.label4.Text = "金額";
            // 
            // FRM4LN_EDIT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 227);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAmt);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.cbFA_IDNO);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxContract);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMemo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ptxSalcode);
            this.Controls.Add(this.txtSeq);
            this.Controls.Add(this.txtYymm);
            this.Controls.Add(this.ptxNobr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FRM4LN_EDIT";
            this.Text = "FRM4LN_ADD";
            this.Load += new System.EventHandler(this.FRM4LN_ADD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vBASEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.basDS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private JBControls.PopupTextBox ptxNobr;
        private JBControls.TextBox txtYymm;
        private System.Windows.Forms.Label label2;
        private JBControls.TextBox txtSeq;
        private System.Windows.Forms.ComboBox ptxSalcode;
        private System.Windows.Forms.Label label3;
        private JBControls.TextBox txtMemo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxContract;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbFA_IDNO;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private Bas.BasDS basDS;
        private System.Windows.Forms.BindingSource vBASEBindingSource;
        private Bas.BasDSTableAdapters.V_BASETableAdapter v_BASETableAdapter;
        private JBControls.TextBox txtAmt;
        private System.Windows.Forms.Label label4;
    }
}