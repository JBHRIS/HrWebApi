namespace JBHR.Sal
{
    partial class FRM4LIN
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
            this.cbNobr = new System.Windows.Forms.ComboBox();
            this.cbAmt = new System.Windows.Forms.ComboBox();
            this.cbMemo = new System.Windows.Forms.ComboBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.lblAdate = new System.Windows.Forms.Label();
            this.lblNobr = new System.Windows.Forms.Label();
            this.lblSalcode = new System.Windows.Forms.Label();
            this.lblAmt = new System.Windows.Forms.Label();
            this.lblMemo = new System.Windows.Forms.Label();
            this.cbxSalcode = new System.Windows.Forms.ComboBox();
            this.cbFA_IDNO = new System.Windows.Forms.ComboBox();
            this.lbFA_IDNO = new System.Windows.Forms.Label();
            this.cbYymm = new System.Windows.Forms.ComboBox();
            this.cbSeq = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbNobr
            // 
            this.cbNobr.FormattingEnabled = true;
            this.cbNobr.Location = new System.Drawing.Point(98, 14);
            this.cbNobr.Name = "cbNobr";
            this.cbNobr.Size = new System.Drawing.Size(86, 20);
            this.cbNobr.TabIndex = 0;
            this.cbNobr.Tag = "員工編號";
            // 
            // cbAmt
            // 
            this.cbAmt.FormattingEnabled = true;
            this.cbAmt.Location = new System.Drawing.Point(98, 118);
            this.cbAmt.Name = "cbAmt";
            this.cbAmt.Size = new System.Drawing.Size(86, 20);
            this.cbAmt.TabIndex = 4;
            this.cbAmt.Tag = "金額";
            // 
            // cbMemo
            // 
            this.cbMemo.FormattingEnabled = true;
            this.cbMemo.Location = new System.Drawing.Point(98, 170);
            this.cbMemo.Name = "cbMemo";
            this.cbMemo.Size = new System.Drawing.Size(86, 20);
            this.cbMemo.TabIndex = 6;
            this.cbMemo.Tag = "備註";
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(92, 201);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 7;
            this.btnImport.Text = "設定";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // lblAdate
            // 
            this.lblAdate.AutoSize = true;
            this.lblAdate.ForeColor = System.Drawing.Color.Red;
            this.lblAdate.Location = new System.Drawing.Point(39, 43);
            this.lblAdate.Name = "lblAdate";
            this.lblAdate.Size = new System.Drawing.Size(53, 12);
            this.lblAdate.TabIndex = 12;
            this.lblAdate.Text = "計薪年月";
            // 
            // lblNobr
            // 
            this.lblNobr.AutoSize = true;
            this.lblNobr.ForeColor = System.Drawing.Color.Red;
            this.lblNobr.Location = new System.Drawing.Point(39, 17);
            this.lblNobr.Name = "lblNobr";
            this.lblNobr.Size = new System.Drawing.Size(53, 12);
            this.lblNobr.TabIndex = 13;
            this.lblNobr.Text = "員工編號";
            // 
            // lblSalcode
            // 
            this.lblSalcode.AutoSize = true;
            this.lblSalcode.ForeColor = System.Drawing.Color.Red;
            this.lblSalcode.Location = new System.Drawing.Point(39, 95);
            this.lblSalcode.Name = "lblSalcode";
            this.lblSalcode.Size = new System.Drawing.Size(53, 12);
            this.lblSalcode.TabIndex = 14;
            this.lblSalcode.Text = "薪資代碼";
            // 
            // lblAmt
            // 
            this.lblAmt.AutoSize = true;
            this.lblAmt.ForeColor = System.Drawing.Color.Red;
            this.lblAmt.Location = new System.Drawing.Point(63, 121);
            this.lblAmt.Name = "lblAmt";
            this.lblAmt.Size = new System.Drawing.Size(29, 12);
            this.lblAmt.TabIndex = 15;
            this.lblAmt.Text = "金額";
            // 
            // lblMemo
            // 
            this.lblMemo.AutoSize = true;
            this.lblMemo.Location = new System.Drawing.Point(63, 173);
            this.lblMemo.Name = "lblMemo";
            this.lblMemo.Size = new System.Drawing.Size(29, 12);
            this.lblMemo.TabIndex = 16;
            this.lblMemo.Text = "備註";
            // 
            // cbxSalcode
            // 
            this.cbxSalcode.FormattingEnabled = true;
            this.cbxSalcode.Location = new System.Drawing.Point(98, 92);
            this.cbxSalcode.Name = "cbxSalcode";
            this.cbxSalcode.Size = new System.Drawing.Size(86, 20);
            this.cbxSalcode.TabIndex = 3;
            this.cbxSalcode.Tag = "薪資代碼";
            // 
            // cbFA_IDNO
            // 
            this.cbFA_IDNO.FormattingEnabled = true;
            this.cbFA_IDNO.Location = new System.Drawing.Point(98, 144);
            this.cbFA_IDNO.Name = "cbFA_IDNO";
            this.cbFA_IDNO.Size = new System.Drawing.Size(86, 20);
            this.cbFA_IDNO.TabIndex = 5;
            this.cbFA_IDNO.Tag = "眷屬身號";
            // 
            // lbFA_IDNO
            // 
            this.lbFA_IDNO.AutoSize = true;
            this.lbFA_IDNO.Location = new System.Drawing.Point(39, 147);
            this.lbFA_IDNO.Name = "lbFA_IDNO";
            this.lbFA_IDNO.Size = new System.Drawing.Size(53, 12);
            this.lbFA_IDNO.TabIndex = 13;
            this.lbFA_IDNO.Text = "眷屬身號";
            // 
            // cbYymm
            // 
            this.cbYymm.FormattingEnabled = true;
            this.cbYymm.Location = new System.Drawing.Point(98, 40);
            this.cbYymm.Name = "cbYymm";
            this.cbYymm.Size = new System.Drawing.Size(86, 20);
            this.cbYymm.TabIndex = 1;
            this.cbYymm.Tag = "計薪年月";
            // 
            // cbSeq
            // 
            this.cbSeq.FormattingEnabled = true;
            this.cbSeq.Location = new System.Drawing.Point(98, 66);
            this.cbSeq.Name = "cbSeq";
            this.cbSeq.Size = new System.Drawing.Size(86, 20);
            this.cbSeq.TabIndex = 2;
            this.cbSeq.Tag = "期別";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(63, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "期別";
            // 
            // FRM4LIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 236);
            this.Controls.Add(this.lblMemo);
            this.Controls.Add(this.lblAmt);
            this.Controls.Add(this.lblSalcode);
            this.Controls.Add(this.lbFA_IDNO);
            this.Controls.Add(this.lblNobr);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAdate);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.cbMemo);
            this.Controls.Add(this.cbAmt);
            this.Controls.Add(this.cbxSalcode);
            this.Controls.Add(this.cbFA_IDNO);
            this.Controls.Add(this.cbSeq);
            this.Controls.Add(this.cbYymm);
            this.Controls.Add(this.cbNobr);
            this.Name = "FRM4LIN";
            this.Text = "FRM4LI";
            this.Load += new System.EventHandler(this.FRM4LIN_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbNobr;
        private System.Windows.Forms.ComboBox cbAmt;
        private System.Windows.Forms.ComboBox cbMemo;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label lblAdate;
        private System.Windows.Forms.Label lblNobr;
        private System.Windows.Forms.Label lblSalcode;
        private System.Windows.Forms.Label lblAmt;
        private System.Windows.Forms.Label lblMemo;
        private System.Windows.Forms.ComboBox cbxSalcode;
        private System.Windows.Forms.ComboBox cbFA_IDNO;
        private System.Windows.Forms.Label lbFA_IDNO;
        private System.Windows.Forms.ComboBox cbYymm;
        private System.Windows.Forms.ComboBox cbSeq;
        private System.Windows.Forms.Label label1;

    }
}