namespace JBHR.Med
{
	partial class FRM71A
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
            this.lblComp = new System.Windows.Forms.Label();
            this.lblNobr = new System.Windows.Forms.Label();
            this.lblDAmt = new System.Windows.Forms.Label();
            this.lblFormat = new System.Windows.Forms.Label();
            this.lblAmt = new System.Windows.Forms.Label();
            this.lblYYMM = new System.Windows.Forms.Label();
            this.txtFileName = new JBControls.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblForsub = new System.Windows.Forms.Label();
            this.cbxNobr = new System.Windows.Forms.ComboBox();
            this.cbxAmt = new System.Windows.Forms.ComboBox();
            this.cbxDAMT = new System.Windows.Forms.ComboBox();
            this.cbxYRINA = new System.Windows.Forms.ComboBox();
            this.cbxComp = new System.Windows.Forms.ComboBox();
            this.cbxFormat = new System.Windows.Forms.ComboBox();
            this.lblYrina = new System.Windows.Forms.Label();
            this.cbxForsub = new System.Windows.Forms.ComboBox();
            this.lblMemo = new System.Windows.Forms.Label();
            this.cbxMemo = new System.Windows.Forms.ComboBox();
            this.lblTaxno = new System.Windows.Forms.Label();
            this.cbxTaxNO = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblSalcode = new System.Windows.Forms.Label();
            this.cbxSalcode = new System.Windows.Forms.ComboBox();
            this.lblSupAmt = new System.Windows.Forms.Label();
            this.cbxSupAmt = new System.Windows.Forms.ComboBox();
            this.cbxYYMM = new System.Windows.Forms.ComboBox();
            this.lblSEQ = new System.Windows.Forms.Label();
            this.cbxSEQ = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblComp
            // 
            this.lblComp.AutoSize = true;
            this.lblComp.ForeColor = System.Drawing.Color.Red;
            this.lblComp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblComp.Location = new System.Drawing.Point(16, 98);
            this.lblComp.Name = "lblComp";
            this.lblComp.Size = new System.Drawing.Size(53, 12);
            this.lblComp.TabIndex = 18;
            this.lblComp.Text = "扣繳公司";
            // 
            // lblNobr
            // 
            this.lblNobr.AutoSize = true;
            this.lblNobr.ForeColor = System.Drawing.Color.Red;
            this.lblNobr.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNobr.Location = new System.Drawing.Point(5, 74);
            this.lblNobr.Name = "lblNobr";
            this.lblNobr.Size = new System.Drawing.Size(65, 12);
            this.lblNobr.TabIndex = 15;
            this.lblNobr.Text = "所得人編號";
            // 
            // lblDAmt
            // 
            this.lblDAmt.AutoSize = true;
            this.lblDAmt.ForeColor = System.Drawing.Color.Red;
            this.lblDAmt.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDAmt.Location = new System.Drawing.Point(295, 126);
            this.lblDAmt.Name = "lblDAmt";
            this.lblDAmt.Size = new System.Drawing.Size(53, 12);
            this.lblDAmt.TabIndex = 23;
            this.lblDAmt.Text = "扣繳稅額";
            // 
            // lblFormat
            // 
            this.lblFormat.AutoSize = true;
            this.lblFormat.ForeColor = System.Drawing.Color.Red;
            this.lblFormat.Location = new System.Drawing.Point(319, 98);
            this.lblFormat.Name = "lblFormat";
            this.lblFormat.Size = new System.Drawing.Size(29, 12);
            this.lblFormat.TabIndex = 22;
            this.lblFormat.Text = "格式";
            // 
            // lblAmt
            // 
            this.lblAmt.AutoSize = true;
            this.lblAmt.ForeColor = System.Drawing.Color.Red;
            this.lblAmt.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAmt.Location = new System.Drawing.Point(40, 124);
            this.lblAmt.Name = "lblAmt";
            this.lblAmt.Size = new System.Drawing.Size(29, 12);
            this.lblAmt.TabIndex = 19;
            this.lblAmt.Text = "金額";
            // 
            // lblYYMM
            // 
            this.lblYYMM.AutoSize = true;
            this.lblYYMM.ForeColor = System.Drawing.Color.Red;
            this.lblYYMM.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblYYMM.Location = new System.Drawing.Point(16, 46);
            this.lblYYMM.Name = "lblYYMM";
            this.lblYYMM.Size = new System.Drawing.Size(53, 12);
            this.lblYYMM.TabIndex = 16;
            this.lblYYMM.Text = "計薪年月";
            // 
            // txtFileName
            // 
            this.txtFileName.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.txtFileName.CaptionLabel = this.label7;
            this.txtFileName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtFileName.DecimalPlace = 2;
            this.txtFileName.Enabled = false;
            this.txtFileName.IsEmpty = true;
            this.txtFileName.Location = new System.Drawing.Point(69, 12);
            this.txtFileName.Mask = "";
            this.txtFileName.MaxLength = -1;
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.PasswordChar = '\0';
            this.txtFileName.ReadOnly = false;
            this.txtFileName.ShowCalendarButton = true;
            this.txtFileName.Size = new System.Drawing.Size(403, 22);
            this.txtFileName.TabIndex = 0;
            this.txtFileName.ValidType = JBControls.TextBox.EValidType.String;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(10, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 31;
            this.label7.Text = "匯入檔案";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(474, 11);
            this.button1.Name = "btnEmp";
            this.button1.Size = new System.Drawing.Size(26, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "…";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button2.Location = new System.Drawing.Point(150, 230);
            this.button2.Name = "buttonMang";
            this.button2.Size = new System.Drawing.Size(75, 24);
            this.button2.TabIndex = 15;
            this.button2.Text = "匯入";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblForsub
            // 
            this.lblForsub.AutoSize = true;
            this.lblForsub.ForeColor = System.Drawing.Color.Black;
            this.lblForsub.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblForsub.Location = new System.Drawing.Point(295, 176);
            this.lblForsub.Name = "lblForsub";
            this.lblForsub.Size = new System.Drawing.Size(53, 12);
            this.lblForsub.TabIndex = 23;
            this.lblForsub.Text = "給付項目";
            // 
            // cbxNobr
            // 
            this.cbxNobr.FormattingEnabled = true;
            this.cbxNobr.Location = new System.Drawing.Point(75, 69);
            this.cbxNobr.Name = "cbxNobr";
            this.cbxNobr.Size = new System.Drawing.Size(121, 20);
            this.cbxNobr.TabIndex = 4;
            // 
            // cbxAmt
            // 
            this.cbxAmt.FormattingEnabled = true;
            this.cbxAmt.Location = new System.Drawing.Point(75, 121);
            this.cbxAmt.Name = "cbxAmt";
            this.cbxAmt.Size = new System.Drawing.Size(121, 20);
            this.cbxAmt.TabIndex = 8;
            // 
            // cbxDAMT
            // 
            this.cbxDAMT.FormattingEnabled = true;
            this.cbxDAMT.Location = new System.Drawing.Point(354, 121);
            this.cbxDAMT.Name = "cbxDAMT";
            this.cbxDAMT.Size = new System.Drawing.Size(121, 20);
            this.cbxDAMT.TabIndex = 9;
            // 
            // cbxYRINA
            // 
            this.cbxYRINA.FormattingEnabled = true;
            this.cbxYRINA.Location = new System.Drawing.Point(75, 173);
            this.cbxYRINA.Name = "cbxYRINA";
            this.cbxYRINA.Size = new System.Drawing.Size(121, 20);
            this.cbxYRINA.TabIndex = 11;
            // 
            // cbxComp
            // 
            this.cbxComp.FormattingEnabled = true;
            this.cbxComp.Location = new System.Drawing.Point(75, 95);
            this.cbxComp.Name = "cbxComp";
            this.cbxComp.Size = new System.Drawing.Size(121, 20);
            this.cbxComp.TabIndex = 6;
            // 
            // cbxFormat
            // 
            this.cbxFormat.FormattingEnabled = true;
            this.cbxFormat.Location = new System.Drawing.Point(354, 95);
            this.cbxFormat.Name = "cbxFormat";
            this.cbxFormat.Size = new System.Drawing.Size(121, 20);
            this.cbxFormat.TabIndex = 7;
            // 
            // lblYrina
            // 
            this.lblYrina.AutoSize = true;
            this.lblYrina.ForeColor = System.Drawing.Color.Black;
            this.lblYrina.Location = new System.Drawing.Point(39, 176);
            this.lblYrina.Name = "lblYrina";
            this.lblYrina.Size = new System.Drawing.Size(29, 12);
            this.lblYrina.TabIndex = 22;
            this.lblYrina.Text = "業別";
            // 
            // cbxForsub
            // 
            this.cbxForsub.FormattingEnabled = true;
            this.cbxForsub.Location = new System.Drawing.Point(354, 171);
            this.cbxForsub.Name = "cbxForsub";
            this.cbxForsub.Size = new System.Drawing.Size(121, 20);
            this.cbxForsub.TabIndex = 12;
            // 
            // lblMemo
            // 
            this.lblMemo.AutoSize = true;
            this.lblMemo.ForeColor = System.Drawing.Color.Black;
            this.lblMemo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblMemo.Location = new System.Drawing.Point(39, 202);
            this.lblMemo.Name = "lblMemo";
            this.lblMemo.Size = new System.Drawing.Size(29, 12);
            this.lblMemo.TabIndex = 23;
            this.lblMemo.Text = "備註";
            // 
            // cbxMemo
            // 
            this.cbxMemo.FormattingEnabled = true;
            this.cbxMemo.Location = new System.Drawing.Point(74, 199);
            this.cbxMemo.Name = "cbxMemo";
            this.cbxMemo.Size = new System.Drawing.Size(121, 20);
            this.cbxMemo.TabIndex = 13;
            // 
            // lblTaxno
            // 
            this.lblTaxno.AutoSize = true;
            this.lblTaxno.ForeColor = System.Drawing.Color.Black;
            this.lblTaxno.Location = new System.Drawing.Point(271, 202);
            this.lblTaxno.Name = "lblTaxno";
            this.lblTaxno.Size = new System.Drawing.Size(77, 12);
            this.lblTaxno.TabIndex = 22;
            this.lblTaxno.Text = "租賃稅籍編號";
            // 
            // cbxTaxNO
            // 
            this.cbxTaxNO.FormattingEnabled = true;
            this.cbxTaxNO.Location = new System.Drawing.Point(354, 199);
            this.cbxTaxNO.Name = "cbxTaxNO";
            this.cbxTaxNO.Size = new System.Drawing.Size(121, 20);
            this.cbxTaxNO.TabIndex = 14;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnClose.Location = new System.Drawing.Point(295, 230);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 24);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "離開";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblSalcode
            // 
            this.lblSalcode.AutoSize = true;
            this.lblSalcode.ForeColor = System.Drawing.Color.Black;
            this.lblSalcode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSalcode.Location = new System.Drawing.Point(294, 74);
            this.lblSalcode.Name = "lblSalcode";
            this.lblSalcode.Size = new System.Drawing.Size(53, 12);
            this.lblSalcode.TabIndex = 15;
            this.lblSalcode.Text = "所得代號";
            // 
            // cbxSalcode
            // 
            this.cbxSalcode.FormattingEnabled = true;
            this.cbxSalcode.Location = new System.Drawing.Point(354, 69);
            this.cbxSalcode.Name = "cbxSalcode";
            this.cbxSalcode.Size = new System.Drawing.Size(121, 20);
            this.cbxSalcode.TabIndex = 5;
            // 
            // lblSupAmt
            // 
            this.lblSupAmt.AutoSize = true;
            this.lblSupAmt.ForeColor = System.Drawing.Color.Red;
            this.lblSupAmt.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSupAmt.Location = new System.Drawing.Point(18, 150);
            this.lblSupAmt.Name = "lblSupAmt";
            this.lblSupAmt.Size = new System.Drawing.Size(53, 12);
            this.lblSupAmt.TabIndex = 19;
            this.lblSupAmt.Text = "補充保費";
            // 
            // cbxSupAmt
            // 
            this.cbxSupAmt.FormattingEnabled = true;
            this.cbxSupAmt.Location = new System.Drawing.Point(75, 147);
            this.cbxSupAmt.Name = "cbxSupAmt";
            this.cbxSupAmt.Size = new System.Drawing.Size(121, 20);
            this.cbxSupAmt.TabIndex = 10;
            // 
            // cbxYYMM
            // 
            this.cbxYYMM.FormattingEnabled = true;
            this.cbxYYMM.Location = new System.Drawing.Point(74, 40);
            this.cbxYYMM.Name = "cbxYYMM";
            this.cbxYYMM.Size = new System.Drawing.Size(121, 20);
            this.cbxYYMM.TabIndex = 2;
            // 
            // lblSEQ
            // 
            this.lblSEQ.AutoSize = true;
            this.lblSEQ.ForeColor = System.Drawing.Color.Red;
            this.lblSEQ.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSEQ.Location = new System.Drawing.Point(318, 43);
            this.lblSEQ.Name = "lblSEQ";
            this.lblSEQ.Size = new System.Drawing.Size(29, 12);
            this.lblSEQ.TabIndex = 16;
            this.lblSEQ.Text = "期別";
            // 
            // cbxSEQ
            // 
            this.cbxSEQ.FormattingEnabled = true;
            this.cbxSEQ.Location = new System.Drawing.Point(354, 40);
            this.cbxSEQ.Name = "cbxSEQ";
            this.cbxSEQ.Size = new System.Drawing.Size(121, 20);
            this.cbxSEQ.TabIndex = 3;
            // 
            // FRM71A
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(509, 265);
            this.Controls.Add(this.cbxTaxNO);
            this.Controls.Add(this.cbxForsub);
            this.Controls.Add(this.cbxFormat);
            this.Controls.Add(this.cbxComp);
            this.Controls.Add(this.cbxMemo);
            this.Controls.Add(this.cbxYRINA);
            this.Controls.Add(this.cbxDAMT);
            this.Controls.Add(this.cbxSupAmt);
            this.Controls.Add(this.cbxAmt);
            this.Controls.Add(this.cbxSalcode);
            this.Controls.Add(this.cbxSEQ);
            this.Controls.Add(this.cbxYYMM);
            this.Controls.Add(this.cbxNobr);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.lblMemo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblForsub);
            this.Controls.Add(this.lblTaxno);
            this.Controls.Add(this.lblYrina);
            this.Controls.Add(this.lblDAmt);
            this.Controls.Add(this.lblSupAmt);
            this.Controls.Add(this.lblFormat);
            this.Controls.Add(this.lblAmt);
            this.Controls.Add(this.lblComp);
            this.Controls.Add(this.lblSEQ);
            this.Controls.Add(this.lblSalcode);
            this.Controls.Add(this.lblYYMM);
            this.Controls.Add(this.lblNobr);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM71A";
            this.Load += new System.EventHandler(this.FRM62I_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblComp;
        private System.Windows.Forms.Label lblNobr;
		private System.Windows.Forms.Label lblDAmt;
		private System.Windows.Forms.Label lblFormat;
        private System.Windows.Forms.Label lblAmt;
		private System.Windows.Forms.Label lblYYMM;
		private JBControls.TextBox txtFileName;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblForsub;
        private System.Windows.Forms.ComboBox cbxFormat;
        private System.Windows.Forms.ComboBox cbxComp;
        private System.Windows.Forms.ComboBox cbxYRINA;
        private System.Windows.Forms.ComboBox cbxDAMT;
        private System.Windows.Forms.ComboBox cbxAmt;
        private System.Windows.Forms.ComboBox cbxNobr;
        private System.Windows.Forms.ComboBox cbxForsub;
        private System.Windows.Forms.Label lblYrina;
        private System.Windows.Forms.ComboBox cbxTaxNO;
        private System.Windows.Forms.ComboBox cbxMemo;
        private System.Windows.Forms.Label lblMemo;
        private System.Windows.Forms.Label lblTaxno;
        private System.Windows.Forms.ComboBox cbxSalcode;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblSalcode;
        private System.Windows.Forms.ComboBox cbxSupAmt;
        private System.Windows.Forms.Label lblSupAmt;
        private System.Windows.Forms.ComboBox cbxSEQ;
        private System.Windows.Forms.ComboBox cbxYYMM;
        private System.Windows.Forms.Label lblSEQ;
	}
}