namespace JBHR.Med
{
    partial class FRM71N1_IMPORT
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
            this.lblNobr = new System.Windows.Forms.Label();
            this.lbSeq = new System.Windows.Forms.Label();
            this.lblAdate = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.cbxMemo = new System.Windows.Forms.ComboBox();
            this.cbAmt = new System.Windows.Forms.ComboBox();
            this.cbxSeq = new System.Windows.Forms.ComboBox();
            this.cbxYymm = new System.Windows.Forms.ComboBox();
            this.cbxNobr = new System.Windows.Forms.ComboBox();
            this.cbxComp = new System.Windows.Forms.ComboBox();
            this.lbComp = new System.Windows.Forms.Label();
            this.cbxFormat = new System.Windows.Forms.ComboBox();
            this.lbFormat = new System.Windows.Forms.Label();
            this.cbxSubcode = new System.Windows.Forms.ComboBox();
            this.lbSubcode = new System.Windows.Forms.Label();
            this.cbxD_Amt = new System.Windows.Forms.ComboBox();
            this.lbD_Amt = new System.Windows.Forms.Label();
            this.cbxRet_Amt = new System.Windows.Forms.ComboBox();
            this.lbRet_Amt = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbNote1 = new System.Windows.Forms.Label();
            this.lbNote2 = new System.Windows.Forms.Label();
            this.cbxNote1 = new System.Windows.Forms.ComboBox();
            this.cbxNote2 = new System.Windows.Forms.ComboBox();
            this.lbSup_Amt = new System.Windows.Forms.Label();
            this.cbxSup_Amt = new System.Windows.Forms.ComboBox();
            this.lbTAXNO = new System.Windows.Forms.Label();
            this.cbxTAXNO = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMemo
            // 
            this.lblMemo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblMemo.AutoSize = true;
            this.lblMemo.Location = new System.Drawing.Point(241, 142);
            this.lblMemo.Name = "lblMemo";
            this.lblMemo.Size = new System.Drawing.Size(29, 12);
            this.lblMemo.TabIndex = 31;
            this.lblMemo.Text = "備註";
            // 
            // lblAmt
            // 
            this.lblAmt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAmt.AutoSize = true;
            this.lblAmt.ForeColor = System.Drawing.Color.Red;
            this.lblAmt.Location = new System.Drawing.Point(35, 88);
            this.lblAmt.Name = "lblAmt";
            this.lblAmt.Size = new System.Drawing.Size(53, 12);
            this.lblAmt.TabIndex = 30;
            this.lblAmt.Text = "給付總額";
            // 
            // lblNobr
            // 
            this.lblNobr.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblNobr.AutoSize = true;
            this.lblNobr.ForeColor = System.Drawing.Color.Red;
            this.lblNobr.Location = new System.Drawing.Point(35, 7);
            this.lblNobr.Name = "lblNobr";
            this.lblNobr.Size = new System.Drawing.Size(53, 12);
            this.lblNobr.TabIndex = 28;
            this.lblNobr.Text = "員工編號";
            // 
            // lbSeq
            // 
            this.lbSeq.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbSeq.AutoSize = true;
            this.lbSeq.ForeColor = System.Drawing.Color.Red;
            this.lbSeq.Location = new System.Drawing.Point(241, 34);
            this.lbSeq.Name = "lbSeq";
            this.lbSeq.Size = new System.Drawing.Size(29, 12);
            this.lbSeq.TabIndex = 25;
            this.lbSeq.Text = "期別";
            // 
            // lblAdate
            // 
            this.lblAdate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAdate.AutoSize = true;
            this.lblAdate.ForeColor = System.Drawing.Color.Red;
            this.lblAdate.Location = new System.Drawing.Point(35, 34);
            this.lblAdate.Name = "lblAdate";
            this.lblAdate.Size = new System.Drawing.Size(53, 12);
            this.lblAdate.TabIndex = 26;
            this.lblAdate.Text = "所得年月";
            // 
            // btnImport
            // 
            this.btnImport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.SetColumnSpan(this.btnImport, 2);
            this.btnImport.Location = new System.Drawing.Point(144, 193);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 13;
            this.btnImport.Text = "設定";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // cbxMemo
            // 
            this.cbxMemo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxMemo.FormattingEnabled = true;
            this.cbxMemo.Location = new System.Drawing.Point(276, 138);
            this.cbxMemo.Name = "cbxMemo";
            this.cbxMemo.Size = new System.Drawing.Size(85, 20);
            this.cbxMemo.TabIndex = 10;
            this.cbxMemo.Tag = "備註";
            // 
            // cbAmt
            // 
            this.cbAmt.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbAmt.FormattingEnabled = true;
            this.cbAmt.Location = new System.Drawing.Point(94, 84);
            this.cbAmt.Name = "cbAmt";
            this.cbAmt.Size = new System.Drawing.Size(85, 20);
            this.cbAmt.TabIndex = 6;
            this.cbAmt.Tag = "給付總額";
            // 
            // cbxSeq
            // 
            this.cbxSeq.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxSeq.FormattingEnabled = true;
            this.cbxSeq.Location = new System.Drawing.Point(276, 30);
            this.cbxSeq.Name = "cbxSeq";
            this.cbxSeq.Size = new System.Drawing.Size(86, 20);
            this.cbxSeq.TabIndex = 3;
            this.cbxSeq.Tag = "期別";
            // 
            // cbxYymm
            // 
            this.cbxYymm.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxYymm.FormattingEnabled = true;
            this.cbxYymm.Location = new System.Drawing.Point(94, 30);
            this.cbxYymm.Name = "cbxYymm";
            this.cbxYymm.Size = new System.Drawing.Size(85, 20);
            this.cbxYymm.TabIndex = 2;
            this.cbxYymm.Tag = "所得年月";
            // 
            // cbxNobr
            // 
            this.cbxNobr.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxNobr.FormattingEnabled = true;
            this.cbxNobr.Location = new System.Drawing.Point(94, 3);
            this.cbxNobr.Name = "cbxNobr";
            this.cbxNobr.Size = new System.Drawing.Size(85, 20);
            this.cbxNobr.TabIndex = 0;
            this.cbxNobr.Tag = "員工編號";
            // 
            // cbxComp
            // 
            this.cbxComp.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxComp.FormattingEnabled = true;
            this.cbxComp.Location = new System.Drawing.Point(276, 3);
            this.cbxComp.Name = "cbxComp";
            this.cbxComp.Size = new System.Drawing.Size(85, 20);
            this.cbxComp.TabIndex = 1;
            this.cbxComp.Tag = "公司";
            // 
            // lbComp
            // 
            this.lbComp.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbComp.AutoSize = true;
            this.lbComp.ForeColor = System.Drawing.Color.Red;
            this.lbComp.Location = new System.Drawing.Point(241, 7);
            this.lbComp.Name = "lbComp";
            this.lbComp.Size = new System.Drawing.Size(29, 12);
            this.lbComp.TabIndex = 26;
            this.lbComp.Text = "公司";
            // 
            // cbxFormat
            // 
            this.cbxFormat.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxFormat.FormattingEnabled = true;
            this.cbxFormat.Location = new System.Drawing.Point(94, 57);
            this.cbxFormat.Name = "cbxFormat";
            this.cbxFormat.Size = new System.Drawing.Size(85, 20);
            this.cbxFormat.TabIndex = 4;
            this.cbxFormat.Tag = "所得格式";
            // 
            // lbFormat
            // 
            this.lbFormat.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbFormat.AutoSize = true;
            this.lbFormat.ForeColor = System.Drawing.Color.Red;
            this.lbFormat.Location = new System.Drawing.Point(35, 61);
            this.lbFormat.Name = "lbFormat";
            this.lbFormat.Size = new System.Drawing.Size(53, 12);
            this.lbFormat.TabIndex = 26;
            this.lbFormat.Text = "所得格式";
            // 
            // cbxSubcode
            // 
            this.cbxSubcode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxSubcode.FormattingEnabled = true;
            this.cbxSubcode.Location = new System.Drawing.Point(276, 57);
            this.cbxSubcode.Name = "cbxSubcode";
            this.cbxSubcode.Size = new System.Drawing.Size(86, 20);
            this.cbxSubcode.TabIndex = 5;
            this.cbxSubcode.Tag = "所得註記";
            // 
            // lbSubcode
            // 
            this.lbSubcode.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbSubcode.AutoSize = true;
            this.lbSubcode.ForeColor = System.Drawing.Color.Red;
            this.lbSubcode.Location = new System.Drawing.Point(217, 61);
            this.lbSubcode.Name = "lbSubcode";
            this.lbSubcode.Size = new System.Drawing.Size(53, 12);
            this.lbSubcode.TabIndex = 26;
            this.lbSubcode.Text = "所得註記";
            // 
            // cbxD_Amt
            // 
            this.cbxD_Amt.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxD_Amt.FormattingEnabled = true;
            this.cbxD_Amt.Location = new System.Drawing.Point(276, 84);
            this.cbxD_Amt.Name = "cbxD_Amt";
            this.cbxD_Amt.Size = new System.Drawing.Size(86, 20);
            this.cbxD_Amt.TabIndex = 7;
            this.cbxD_Amt.Tag = "扣繳稅額";
            // 
            // lbD_Amt
            // 
            this.lbD_Amt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbD_Amt.AutoSize = true;
            this.lbD_Amt.ForeColor = System.Drawing.Color.Red;
            this.lbD_Amt.Location = new System.Drawing.Point(217, 88);
            this.lbD_Amt.Name = "lbD_Amt";
            this.lbD_Amt.Size = new System.Drawing.Size(53, 12);
            this.lbD_Amt.TabIndex = 30;
            this.lbD_Amt.Text = "扣繳稅額";
            // 
            // cbxRet_Amt
            // 
            this.cbxRet_Amt.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxRet_Amt.FormattingEnabled = true;
            this.cbxRet_Amt.Location = new System.Drawing.Point(276, 111);
            this.cbxRet_Amt.Name = "cbxRet_Amt";
            this.cbxRet_Amt.Size = new System.Drawing.Size(85, 20);
            this.cbxRet_Amt.TabIndex = 9;
            this.cbxRet_Amt.Tag = "自提退休金";
            // 
            // lbRet_Amt
            // 
            this.lbRet_Amt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbRet_Amt.AutoSize = true;
            this.lbRet_Amt.ForeColor = System.Drawing.Color.Black;
            this.lbRet_Amt.Location = new System.Drawing.Point(205, 115);
            this.lbRet_Amt.Name = "lbRet_Amt";
            this.lbRet_Amt.Size = new System.Drawing.Size(65, 12);
            this.lbRet_Amt.TabIndex = 30;
            this.lbRet_Amt.Text = "自提退休金";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.lblNobr, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnImport, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.cbxNobr, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblAdate, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbSeq, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbxSeq, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbxYymm, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbNote1, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lbNote2, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.cbxNote1, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.cbxNote2, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.lbComp, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbxComp, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbFormat, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbxFormat, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbSubcode, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbxSubcode, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblAmt, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbAmt, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbD_Amt, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbxD_Amt, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbRet_Amt, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.cbxRet_Amt, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbSup_Amt, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.cbxSup_Amt, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.cbxMemo, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblMemo, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.lbTAXNO, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.cbxTAXNO, 1, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(365, 220);
            this.tableLayoutPanel1.TabIndex = 32;
            // 
            // lbNote1
            // 
            this.lbNote1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbNote1.AutoSize = true;
            this.lbNote1.ForeColor = System.Drawing.Color.Black;
            this.lbNote1.Location = new System.Drawing.Point(53, 169);
            this.lbNote1.Name = "lbNote1";
            this.lbNote1.Size = new System.Drawing.Size(35, 12);
            this.lbNote1.TabIndex = 32;
            this.lbNote1.Text = "Note1";
            // 
            // lbNote2
            // 
            this.lbNote2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbNote2.AutoSize = true;
            this.lbNote2.Location = new System.Drawing.Point(235, 169);
            this.lbNote2.Name = "lbNote2";
            this.lbNote2.Size = new System.Drawing.Size(35, 12);
            this.lbNote2.TabIndex = 33;
            this.lbNote2.Text = "Note2";
            // 
            // cbxNote1
            // 
            this.cbxNote1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxNote1.FormattingEnabled = true;
            this.cbxNote1.Location = new System.Drawing.Point(94, 165);
            this.cbxNote1.Name = "cbxNote1";
            this.cbxNote1.Size = new System.Drawing.Size(85, 20);
            this.cbxNote1.TabIndex = 11;
            this.cbxNote1.Tag = "Note1";
            // 
            // cbxNote2
            // 
            this.cbxNote2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxNote2.FormattingEnabled = true;
            this.cbxNote2.Location = new System.Drawing.Point(276, 165);
            this.cbxNote2.Name = "cbxNote2";
            this.cbxNote2.Size = new System.Drawing.Size(86, 20);
            this.cbxNote2.TabIndex = 12;
            this.cbxNote2.Tag = "Note2";
            // 
            // lbSup_Amt
            // 
            this.lbSup_Amt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbSup_Amt.AutoSize = true;
            this.lbSup_Amt.ForeColor = System.Drawing.Color.Black;
            this.lbSup_Amt.Location = new System.Drawing.Point(35, 115);
            this.lbSup_Amt.Name = "lbSup_Amt";
            this.lbSup_Amt.Size = new System.Drawing.Size(53, 12);
            this.lbSup_Amt.TabIndex = 36;
            this.lbSup_Amt.Text = "補充保費";
            // 
            // cbxSup_Amt
            // 
            this.cbxSup_Amt.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxSup_Amt.FormattingEnabled = true;
            this.cbxSup_Amt.Location = new System.Drawing.Point(94, 111);
            this.cbxSup_Amt.Name = "cbxSup_Amt";
            this.cbxSup_Amt.Size = new System.Drawing.Size(85, 20);
            this.cbxSup_Amt.TabIndex = 8;
            this.cbxSup_Amt.Tag = "補充保費";
            // 
            // lbTAXNO
            // 
            this.lbTAXNO.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbTAXNO.AutoSize = true;
            this.lbTAXNO.ForeColor = System.Drawing.Color.Black;
            this.lbTAXNO.Location = new System.Drawing.Point(35, 142);
            this.lbTAXNO.Name = "lbTAXNO";
            this.lbTAXNO.Size = new System.Drawing.Size(53, 12);
            this.lbTAXNO.TabIndex = 37;
            this.lbTAXNO.Text = "稅籍編號";
            // 
            // cbxTAXNO
            // 
            this.cbxTAXNO.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxTAXNO.FormattingEnabled = true;
            this.cbxTAXNO.Location = new System.Drawing.Point(94, 138);
            this.cbxTAXNO.Name = "cbxTAXNO";
            this.cbxTAXNO.Size = new System.Drawing.Size(85, 20);
            this.cbxTAXNO.TabIndex = 38;
            this.cbxTAXNO.Tag = "稅籍編號";
            // 
            // FRM71N1_IMPORT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(390, 244);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FRM71N1_IMPORT";
            this.Load += new System.EventHandler(this.FRM71N1_IMPORT_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMemo;
        private System.Windows.Forms.Label lblAmt;
        private System.Windows.Forms.Label lblNobr;
        private System.Windows.Forms.Label lbSeq;
        private System.Windows.Forms.Label lblAdate;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.ComboBox cbxMemo;
        private System.Windows.Forms.ComboBox cbAmt;
        private System.Windows.Forms.ComboBox cbxSeq;
        private System.Windows.Forms.ComboBox cbxYymm;
        private System.Windows.Forms.ComboBox cbxNobr;
        private System.Windows.Forms.ComboBox cbxComp;
        private System.Windows.Forms.Label lbComp;
        private System.Windows.Forms.ComboBox cbxFormat;
        private System.Windows.Forms.Label lbFormat;
        private System.Windows.Forms.ComboBox cbxSubcode;
        private System.Windows.Forms.Label lbSubcode;
        private System.Windows.Forms.ComboBox cbxD_Amt;
        private System.Windows.Forms.Label lbD_Amt;
        private System.Windows.Forms.ComboBox cbxRet_Amt;
        private System.Windows.Forms.Label lbRet_Amt;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbNote1;
        private System.Windows.Forms.Label lbNote2;
        private System.Windows.Forms.ComboBox cbxNote1;
        private System.Windows.Forms.ComboBox cbxNote2;
        private System.Windows.Forms.Label lbSup_Amt;
        private System.Windows.Forms.ComboBox cbxSup_Amt;
        private System.Windows.Forms.Label lbTAXNO;
        private System.Windows.Forms.ComboBox cbxTAXNO;
    }
}
