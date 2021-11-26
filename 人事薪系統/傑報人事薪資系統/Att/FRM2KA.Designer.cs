namespace JBHR.Att
{
    partial class FRM2KA
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
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            this.label98 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label95 = new System.Windows.Forms.Label();
            this.label97 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxDataTable = new System.Windows.Forms.ComboBox();
            this.cbxNobr = new System.Windows.Forms.ComboBox();
            this.cbxDate = new System.Windows.Forms.ComboBox();
            this.cbxTime = new System.Windows.Forms.ComboBox();
            this.cbxCardNo = new System.Windows.Forms.ComboBox();
            this.cbxCheckTime = new System.Windows.Forms.ComboBox();
            this.cbxSource = new System.Windows.Forms.ComboBox();
            this.cbxIpAddr = new System.Windows.Forms.ComboBox();
            this.lbTemperature = new System.Windows.Forms.Label();
            this.cbxTemperature = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label98
            // 
            this.label98.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label98.AutoSize = true;
            this.label98.ForeColor = System.Drawing.Color.Red;
            this.label98.Location = new System.Drawing.Point(54, 18);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(41, 12);
            this.label98.TabIndex = 86;
            this.label98.Text = "資料表";
            // 
            // label62
            // 
            this.label62.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label62.AutoSize = true;
            this.label62.ForeColor = System.Drawing.Color.Red;
            this.label62.Location = new System.Drawing.Point(66, 46);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(29, 12);
            this.label62.TabIndex = 84;
            this.label62.Text = "工號";
            // 
            // label95
            // 
            this.label95.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label95.AutoSize = true;
            this.label95.ForeColor = System.Drawing.Color.Red;
            this.label95.Location = new System.Drawing.Point(66, 74);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(29, 12);
            this.label95.TabIndex = 85;
            this.label95.Text = "日期";
            // 
            // label97
            // 
            this.label97.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label97.AutoSize = true;
            this.label97.ForeColor = System.Drawing.Color.Red;
            this.label97.Location = new System.Drawing.Point(66, 102);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(29, 12);
            this.label97.TabIndex = 88;
            this.label97.Text = "時間";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(66, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 87;
            this.label2.Text = "卡號";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.SetColumnSpan(this.button1, 2);
            this.button1.Location = new System.Drawing.Point(102, 265);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 22);
            this.button1.TabIndex = 8;
            this.button1.Text = "確定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(42, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 87;
            this.label1.Text = "檢核時間";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 92;
            this.label3.Text = "來源";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 92;
            this.label4.Text = "IP位置";
            // 
            // cbxDataTable
            // 
            this.cbxDataTable.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxDataTable.FormattingEnabled = true;
            this.cbxDataTable.Location = new System.Drawing.Point(101, 14);
            this.cbxDataTable.Name = "cbxDataTable";
            this.cbxDataTable.Size = new System.Drawing.Size(121, 20);
            this.cbxDataTable.TabIndex = 0;
            this.cbxDataTable.SelectedIndexChanged += new System.EventHandler(this.cbxDataTable_SelectedIndexChange);
            // 
            // cbxNobr
            // 
            this.cbxNobr.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxNobr.FormattingEnabled = true;
            this.cbxNobr.Location = new System.Drawing.Point(101, 42);
            this.cbxNobr.Name = "cbxNobr";
            this.cbxNobr.Size = new System.Drawing.Size(121, 20);
            this.cbxNobr.TabIndex = 1;
            // 
            // cbxDate
            // 
            this.cbxDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxDate.FormattingEnabled = true;
            this.cbxDate.Location = new System.Drawing.Point(101, 70);
            this.cbxDate.Name = "cbxDate";
            this.cbxDate.Size = new System.Drawing.Size(121, 20);
            this.cbxDate.TabIndex = 2;
            // 
            // cbxTime
            // 
            this.cbxTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxTime.FormattingEnabled = true;
            this.cbxTime.Location = new System.Drawing.Point(101, 98);
            this.cbxTime.Name = "cbxTime";
            this.cbxTime.Size = new System.Drawing.Size(121, 20);
            this.cbxTime.TabIndex = 3;
            // 
            // cbxCardNo
            // 
            this.cbxCardNo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxCardNo.FormattingEnabled = true;
            this.cbxCardNo.Location = new System.Drawing.Point(101, 126);
            this.cbxCardNo.Name = "cbxCardNo";
            this.cbxCardNo.Size = new System.Drawing.Size(121, 20);
            this.cbxCardNo.TabIndex = 4;
            // 
            // cbxCheckTime
            // 
            this.cbxCheckTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxCheckTime.FormattingEnabled = true;
            this.cbxCheckTime.Location = new System.Drawing.Point(101, 154);
            this.cbxCheckTime.Name = "cbxCheckTime";
            this.cbxCheckTime.Size = new System.Drawing.Size(121, 20);
            this.cbxCheckTime.TabIndex = 5;
            // 
            // cbxSource
            // 
            this.cbxSource.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxSource.FormattingEnabled = true;
            this.cbxSource.Location = new System.Drawing.Point(101, 182);
            this.cbxSource.Name = "cbxSource";
            this.cbxSource.Size = new System.Drawing.Size(121, 20);
            this.cbxSource.TabIndex = 6;
            // 
            // cbxIpAddr
            // 
            this.cbxIpAddr.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxIpAddr.FormattingEnabled = true;
            this.cbxIpAddr.Location = new System.Drawing.Point(101, 210);
            this.cbxIpAddr.Name = "cbxIpAddr";
            this.cbxIpAddr.Size = new System.Drawing.Size(121, 20);
            this.cbxIpAddr.TabIndex = 7;
            // 
            // lbTemperature
            // 
            this.lbTemperature.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbTemperature.AutoSize = true;
            this.lbTemperature.Location = new System.Drawing.Point(66, 242);
            this.lbTemperature.Name = "lbTemperature";
            this.lbTemperature.Size = new System.Drawing.Size(29, 12);
            this.lbTemperature.TabIndex = 93;
            this.lbTemperature.Text = "體溫";
            // 
            // cbxTemperature
            // 
            this.cbxTemperature.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbxTemperature.FormattingEnabled = true;
            this.cbxTemperature.Location = new System.Drawing.Point(101, 238);
            this.cbxTemperature.Name = "cbxTemperature";
            this.cbxTemperature.Size = new System.Drawing.Size(121, 20);
            this.cbxTemperature.TabIndex = 94;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.Controls.Add(this.label98, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.cbxTemperature, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.cbxDataTable, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbTemperature, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.label62, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbxIpAddr, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.cbxNobr, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.cbxSource, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.label95, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbxCheckTime, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.cbxDate, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbxCardNo, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label97, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.cbxTime, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 12;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(280, 304);
            this.tableLayoutPanel1.TabIndex = 95;
            // 
            // FRM2KA
            // 
            this.ClientSize = new System.Drawing.Size(280, 304);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.Name = "FRM2KA";
            this.Text = "FRM2KA";
            this.Load += new System.EventHandler(this.FRM2KA_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label98;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Label label95;
        private System.Windows.Forms.Label label97;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxDataTable;
        private System.Windows.Forms.ComboBox cbxNobr;
        private System.Windows.Forms.ComboBox cbxDate;
        private System.Windows.Forms.ComboBox cbxTime;
        private System.Windows.Forms.ComboBox cbxCardNo;
        private System.Windows.Forms.ComboBox cbxCheckTime;
        private System.Windows.Forms.ComboBox cbxSource;
        private System.Windows.Forms.ComboBox cbxIpAddr;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cbxTemperature;
        private System.Windows.Forms.Label lbTemperature;
    }
}
