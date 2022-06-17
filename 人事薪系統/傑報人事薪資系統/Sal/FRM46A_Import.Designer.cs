namespace JBHR.Sal
{
    partial class FRM46A_Import
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
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
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.cbADate = new System.Windows.Forms.ComboBox();
            this.lblAdate = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.lblMemo = new System.Windows.Forms.Label();
            this.cbMemo = new System.Windows.Forms.ComboBox();
            this.lblAmt = new System.Windows.Forms.Label();
            this.lblNobr = new System.Windows.Forms.Label();
            this.cbAmt = new System.Windows.Forms.ComboBox();
            this.lblSalcode = new System.Windows.Forms.Label();
            this.cbNobr = new System.Windows.Forms.ComboBox();
            this.cbxSalcode = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbADate
            // 
            this.cbADate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbADate.FormattingEnabled = true;
            this.cbADate.Location = new System.Drawing.Point(118, 4);
            this.cbADate.Name = "cbADate";
            this.cbADate.Size = new System.Drawing.Size(110, 20);
            this.cbADate.TabIndex = 0;
            this.cbADate.Tag = "異動日期";
            // 
            // lblAdate
            // 
            this.lblAdate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAdate.AutoSize = true;
            this.lblAdate.ForeColor = System.Drawing.Color.Red;
            this.lblAdate.Location = new System.Drawing.Point(59, 8);
            this.lblAdate.Name = "lblAdate";
            this.lblAdate.Size = new System.Drawing.Size(53, 12);
            this.lblAdate.TabIndex = 12;
            this.lblAdate.Text = "生效日期";
            // 
            // btnImport
            // 
            this.btnImport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.SetColumnSpan(this.btnImport, 2);
            this.btnImport.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnImport.Location = new System.Drawing.Point(78, 144);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 5;
            this.btnImport.Text = "設定";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // lblMemo
            // 
            this.lblMemo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblMemo.AutoSize = true;
            this.lblMemo.Location = new System.Drawing.Point(83, 120);
            this.lblMemo.Name = "lblMemo";
            this.lblMemo.Size = new System.Drawing.Size(29, 12);
            this.lblMemo.TabIndex = 16;
            this.lblMemo.Text = "備註";
            // 
            // cbMemo
            // 
            this.cbMemo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbMemo.FormattingEnabled = true;
            this.cbMemo.Location = new System.Drawing.Point(118, 116);
            this.cbMemo.Name = "cbMemo";
            this.cbMemo.Size = new System.Drawing.Size(110, 20);
            this.cbMemo.TabIndex = 4;
            this.cbMemo.Tag = "備註";
            // 
            // lblAmt
            // 
            this.lblAmt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAmt.AutoSize = true;
            this.lblAmt.ForeColor = System.Drawing.Color.Red;
            this.lblAmt.Location = new System.Drawing.Point(83, 92);
            this.lblAmt.Name = "lblAmt";
            this.lblAmt.Size = new System.Drawing.Size(29, 12);
            this.lblAmt.TabIndex = 15;
            this.lblAmt.Text = "金額";
            // 
            // lblNobr
            // 
            this.lblNobr.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblNobr.AutoSize = true;
            this.lblNobr.ForeColor = System.Drawing.Color.Red;
            this.lblNobr.Location = new System.Drawing.Point(59, 36);
            this.lblNobr.Name = "lblNobr";
            this.lblNobr.Size = new System.Drawing.Size(53, 12);
            this.lblNobr.TabIndex = 13;
            this.lblNobr.Text = "員工編號";
            // 
            // cbAmt
            // 
            this.cbAmt.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbAmt.FormattingEnabled = true;
            this.cbAmt.Location = new System.Drawing.Point(118, 88);
            this.cbAmt.Name = "cbAmt";
            this.cbAmt.Size = new System.Drawing.Size(110, 20);
            this.cbAmt.TabIndex = 3;
            this.cbAmt.Tag = "金額";
            // 
            // lblSalcode
            // 
            this.lblSalcode.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblSalcode.AutoSize = true;
            this.lblSalcode.ForeColor = System.Drawing.Color.Red;
            this.lblSalcode.Location = new System.Drawing.Point(59, 64);
            this.lblSalcode.Name = "lblSalcode";
            this.lblSalcode.Size = new System.Drawing.Size(53, 12);
            this.lblSalcode.TabIndex = 14;
            this.lblSalcode.Text = "薪資代碼";
            // 
            // cbNobr
            // 
            this.cbNobr.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbNobr.FormattingEnabled = true;
            this.cbNobr.Location = new System.Drawing.Point(118, 32);
            this.cbNobr.Name = "cbNobr";
            this.cbNobr.Size = new System.Drawing.Size(110, 20);
            this.cbNobr.TabIndex = 1;
            this.cbNobr.Tag = "員工編號";
            // 
            // cbxSalcode
            // 
            this.cbxSalcode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxSalcode.FormattingEnabled = true;
            this.cbxSalcode.Location = new System.Drawing.Point(118, 60);
            this.cbxSalcode.Name = "cbxSalcode";
            this.cbxSalcode.Size = new System.Drawing.Size(110, 20);
            this.cbxSalcode.TabIndex = 2;
            this.cbxSalcode.Tag = "薪資代碼";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.cbADate, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblAdate, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnImport, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblMemo, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.cbMemo, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblAmt, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblNobr, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbAmt, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblSalcode, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbNobr, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbxSalcode, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(231, 171);
            this.tableLayoutPanel1.TabIndex = 19;
            // 
            // FRM46A_Import
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(255, 195);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FRM46A_Import";
            this.Load += new System.EventHandler(this.FRM46A_Import_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbADate;
        private System.Windows.Forms.Label lblAdate;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblMemo;
        private System.Windows.Forms.ComboBox cbMemo;
        private System.Windows.Forms.Label lblAmt;
        private System.Windows.Forms.Label lblNobr;
        private System.Windows.Forms.ComboBox cbAmt;
        private System.Windows.Forms.Label lblSalcode;
        private System.Windows.Forms.ComboBox cbNobr;
        private System.Windows.Forms.ComboBox cbxSalcode;
    }
}
