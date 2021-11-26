namespace JBHR.Bas
{
    partial class BASETTSI1
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
            this.lblMemo = new System.Windows.Forms.Label();
            this.lblAmt = new System.Windows.Forms.Label();
            this.lblSalcode = new System.Windows.Forms.Label();
            this.lblNobr = new System.Windows.Forms.Label();
            this.lblAdate = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.cbxTts3 = new System.Windows.Forms.ComboBox();
            this.cbxTts2 = new System.Windows.Forms.ComboBox();
            this.cbxTts1 = new System.Windows.Forms.ComboBox();
            this.cbNobr = new System.Windows.Forms.ComboBox();
            this.cbxField1 = new System.Windows.Forms.ComboBox();
            this.cbxField2 = new System.Windows.Forms.ComboBox();
            this.cbxField3 = new System.Windows.Forms.ComboBox();
            this.cbxTtscode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxTts4 = new System.Windows.Forms.ComboBox();
            this.cbxField4 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxAdate = new System.Windows.Forms.ComboBox();
            this.cbxTts5 = new System.Windows.Forms.ComboBox();
            this.cbxField5 = new System.Windows.Forms.ComboBox();
            this.cbxTts6 = new System.Windows.Forms.ComboBox();
            this.cbxField6 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMemo
            // 
            this.lblMemo.AutoSize = true;
            this.lblMemo.Location = new System.Drawing.Point(27, 149);
            this.lblMemo.Name = "lblMemo";
            this.lblMemo.Size = new System.Drawing.Size(59, 12);
            this.lblMemo.TabIndex = 27;
            this.lblMemo.Text = "異動欄位3";
            // 
            // lblAmt
            // 
            this.lblAmt.AutoSize = true;
            this.lblAmt.Location = new System.Drawing.Point(27, 122);
            this.lblAmt.Name = "lblAmt";
            this.lblAmt.Size = new System.Drawing.Size(59, 12);
            this.lblAmt.TabIndex = 26;
            this.lblAmt.Text = "異動欄位2";
            // 
            // lblSalcode
            // 
            this.lblSalcode.AutoSize = true;
            this.lblSalcode.Location = new System.Drawing.Point(27, 97);
            this.lblSalcode.Name = "lblSalcode";
            this.lblSalcode.Size = new System.Drawing.Size(59, 12);
            this.lblSalcode.TabIndex = 25;
            this.lblSalcode.Text = "異動欄位1";
            // 
            // lblNobr
            // 
            this.lblNobr.AutoSize = true;
            this.lblNobr.Location = new System.Drawing.Point(27, 46);
            this.lblNobr.Name = "lblNobr";
            this.lblNobr.Size = new System.Drawing.Size(53, 12);
            this.lblNobr.TabIndex = 24;
            this.lblNobr.Text = "員工編號";
            // 
            // lblAdate
            // 
            this.lblAdate.AutoSize = true;
            this.lblAdate.Location = new System.Drawing.Point(27, 19);
            this.lblAdate.Name = "lblAdate";
            this.lblAdate.Size = new System.Drawing.Size(53, 12);
            this.lblAdate.TabIndex = 23;
            this.lblAdate.Text = "生效日期";
            // 
            // btnImport
            // 
            this.btnImport.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnImport.Location = new System.Drawing.Point(97, 253);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 15;
            this.btnImport.Text = "設定";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // cbxTts3
            // 
            this.cbxTts3.FormattingEnabled = true;
            this.cbxTts3.Location = new System.Drawing.Point(86, 146);
            this.cbxTts3.Name = "cbxTts3";
            this.cbxTts3.Size = new System.Drawing.Size(86, 20);
            this.cbxTts3.TabIndex = 7;
            this.cbxTts3.Tag = "異動欄位3";
            // 
            // cbxTts2
            // 
            this.cbxTts2.FormattingEnabled = true;
            this.cbxTts2.Location = new System.Drawing.Point(86, 119);
            this.cbxTts2.Name = "cbxTts2";
            this.cbxTts2.Size = new System.Drawing.Size(86, 20);
            this.cbxTts2.TabIndex = 5;
            this.cbxTts2.Tag = "異動欄位2";
            // 
            // cbxTts1
            // 
            this.cbxTts1.FormattingEnabled = true;
            this.cbxTts1.Location = new System.Drawing.Point(86, 93);
            this.cbxTts1.Name = "cbxTts1";
            this.cbxTts1.Size = new System.Drawing.Size(86, 20);
            this.cbxTts1.TabIndex = 3;
            this.cbxTts1.Tag = "異動欄位1";
            // 
            // cbNobr
            // 
            this.cbNobr.FormattingEnabled = true;
            this.cbNobr.Location = new System.Drawing.Point(86, 41);
            this.cbNobr.Name = "cbNobr";
            this.cbNobr.Size = new System.Drawing.Size(86, 20);
            this.cbNobr.TabIndex = 1;
            this.cbNobr.Tag = "員工編號";
            // 
            // cbxField1
            // 
            this.cbxField1.FormattingEnabled = true;
            this.cbxField1.Location = new System.Drawing.Point(178, 93);
            this.cbxField1.Name = "cbxField1";
            this.cbxField1.Size = new System.Drawing.Size(86, 20);
            this.cbxField1.TabIndex = 4;
            this.cbxField1.Tag = "異動後資料1";
            // 
            // cbxField2
            // 
            this.cbxField2.FormattingEnabled = true;
            this.cbxField2.Location = new System.Drawing.Point(178, 119);
            this.cbxField2.Name = "cbxField2";
            this.cbxField2.Size = new System.Drawing.Size(86, 20);
            this.cbxField2.TabIndex = 6;
            this.cbxField2.Tag = "異動後資料2";
            // 
            // cbxField3
            // 
            this.cbxField3.FormattingEnabled = true;
            this.cbxField3.Location = new System.Drawing.Point(178, 146);
            this.cbxField3.Name = "cbxField3";
            this.cbxField3.Size = new System.Drawing.Size(86, 20);
            this.cbxField3.TabIndex = 8;
            this.cbxField3.Tag = "異動後資料3";
            // 
            // cbxTtscode
            // 
            this.cbxTtscode.FormattingEnabled = true;
            this.cbxTtscode.Location = new System.Drawing.Point(86, 67);
            this.cbxTtscode.Name = "cbxTtscode";
            this.cbxTtscode.Size = new System.Drawing.Size(86, 20);
            this.cbxTtscode.TabIndex = 2;
            this.cbxTtscode.Tag = "異動代碼";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 25;
            this.label1.Text = "異動代碼";
            // 
            // cbxTts4
            // 
            this.cbxTts4.FormattingEnabled = true;
            this.cbxTts4.Location = new System.Drawing.Point(86, 172);
            this.cbxTts4.Name = "cbxTts4";
            this.cbxTts4.Size = new System.Drawing.Size(86, 20);
            this.cbxTts4.TabIndex = 9;
            this.cbxTts4.Tag = "異動欄位4";
            // 
            // cbxField4
            // 
            this.cbxField4.FormattingEnabled = true;
            this.cbxField4.Location = new System.Drawing.Point(178, 172);
            this.cbxField4.Name = "cbxField4";
            this.cbxField4.Size = new System.Drawing.Size(86, 20);
            this.cbxField4.TabIndex = 10;
            this.cbxField4.Tag = "異動後資料4";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 27;
            this.label2.Text = "異動欄位4";
            // 
            // cbxAdate
            // 
            this.cbxAdate.FormattingEnabled = true;
            this.cbxAdate.Location = new System.Drawing.Point(86, 15);
            this.cbxAdate.Name = "cbxAdate";
            this.cbxAdate.Size = new System.Drawing.Size(86, 20);
            this.cbxAdate.TabIndex = 0;
            this.cbxAdate.Tag = "異動日期";
            // 
            // cbxTts5
            // 
            this.cbxTts5.FormattingEnabled = true;
            this.cbxTts5.Location = new System.Drawing.Point(86, 199);
            this.cbxTts5.Name = "cbxTts5";
            this.cbxTts5.Size = new System.Drawing.Size(86, 20);
            this.cbxTts5.TabIndex = 11;
            this.cbxTts5.Tag = "異動欄位5";
            // 
            // cbxField5
            // 
            this.cbxField5.FormattingEnabled = true;
            this.cbxField5.Location = new System.Drawing.Point(178, 199);
            this.cbxField5.Name = "cbxField5";
            this.cbxField5.Size = new System.Drawing.Size(86, 20);
            this.cbxField5.TabIndex = 12;
            this.cbxField5.Tag = "異動後資料5";
            // 
            // cbxTts6
            // 
            this.cbxTts6.FormattingEnabled = true;
            this.cbxTts6.Location = new System.Drawing.Point(86, 225);
            this.cbxTts6.Name = "cbxTts6";
            this.cbxTts6.Size = new System.Drawing.Size(86, 20);
            this.cbxTts6.TabIndex = 13;
            this.cbxTts6.Tag = "異動欄位6";
            // 
            // cbxField6
            // 
            this.cbxField6.FormattingEnabled = true;
            this.cbxField6.Location = new System.Drawing.Point(178, 225);
            this.cbxField6.Name = "cbxField6";
            this.cbxField6.Size = new System.Drawing.Size(86, 20);
            this.cbxField6.TabIndex = 14;
            this.cbxField6.Tag = "異動後資料6";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 27;
            this.label3.Text = "異動欄位5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 27;
            this.label4.Text = "異動欄位6";
            // 
            // BASETTSI1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(297, 288);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblMemo);
            this.Controls.Add(this.lblAmt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSalcode);
            this.Controls.Add(this.lblNobr);
            this.Controls.Add(this.lblAdate);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.cbxField6);
            this.Controls.Add(this.cbxField4);
            this.Controls.Add(this.cbxTts6);
            this.Controls.Add(this.cbxTts4);
            this.Controls.Add(this.cbxField5);
            this.Controls.Add(this.cbxField3);
            this.Controls.Add(this.cbxTts5);
            this.Controls.Add(this.cbxTts3);
            this.Controls.Add(this.cbxField2);
            this.Controls.Add(this.cbxTts2);
            this.Controls.Add(this.cbxField1);
            this.Controls.Add(this.cbxTtscode);
            this.Controls.Add(this.cbxTts1);
            this.Controls.Add(this.cbxAdate);
            this.Controls.Add(this.cbNobr);
            this.Name = "BASETTSI1";
            this.Load += new System.EventHandler(this.BASETTSI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMemo;
        private System.Windows.Forms.Label lblAmt;
        private System.Windows.Forms.Label lblSalcode;
        private System.Windows.Forms.Label lblNobr;
        private System.Windows.Forms.Label lblAdate;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.ComboBox cbxTts3;
        private System.Windows.Forms.ComboBox cbxTts2;
        private System.Windows.Forms.ComboBox cbxTts1;
        private System.Windows.Forms.ComboBox cbNobr;
        private System.Windows.Forms.ComboBox cbxField1;
        private System.Windows.Forms.ComboBox cbxField2;
        private System.Windows.Forms.ComboBox cbxField3;
        private System.Windows.Forms.ComboBox cbxTtscode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxTts4;
        private System.Windows.Forms.ComboBox cbxField4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxAdate;
        private System.Windows.Forms.ComboBox cbxTts5;
        private System.Windows.Forms.ComboBox cbxField5;
        private System.Windows.Forms.ComboBox cbxTts6;
        private System.Windows.Forms.ComboBox cbxField6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
