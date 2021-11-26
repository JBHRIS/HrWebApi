namespace JBHR.Bas
{
    partial class FRM1AIN
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
            this.btnImport = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxEDATE = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxBDATE = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxJOB = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxNOTE = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxNOBR = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxTITTLE = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxCOMPANY = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(219, 98);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 7;
            this.btnImport.Text = "設定";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(217, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 1139;
            this.label7.Text = "結束日期";
            // 
            // cbxEDATE
            // 
            this.cbxEDATE.FormattingEnabled = true;
            this.cbxEDATE.Location = new System.Drawing.Point(276, 69);
            this.cbxEDATE.Name = "cbxEDATE";
            this.cbxEDATE.Size = new System.Drawing.Size(121, 20);
            this.cbxEDATE.TabIndex = 6;
            this.cbxEDATE.Tag = "結束日期";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(217, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 1136;
            this.label4.Text = "開始日期";
            // 
            // cbxBDATE
            // 
            this.cbxBDATE.FormattingEnabled = true;
            this.cbxBDATE.Location = new System.Drawing.Point(276, 43);
            this.cbxBDATE.Name = "cbxBDATE";
            this.cbxBDATE.Size = new System.Drawing.Size(121, 20);
            this.cbxBDATE.TabIndex = 5;
            this.cbxBDATE.Tag = "開始日期";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(217, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 1134;
            this.label6.Text = "工作內容";
            // 
            // cbxJOB
            // 
            this.cbxJOB.FormattingEnabled = true;
            this.cbxJOB.Location = new System.Drawing.Point(276, 17);
            this.cbxJOB.Name = "cbxJOB";
            this.cbxJOB.Size = new System.Drawing.Size(121, 20);
            this.cbxJOB.TabIndex = 4;
            this.cbxJOB.Tag = "工作內容";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(43, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 1132;
            this.label5.Text = "備註";
            // 
            // cbxNOTE
            // 
            this.cbxNOTE.FormattingEnabled = true;
            this.cbxNOTE.Location = new System.Drawing.Point(78, 95);
            this.cbxNOTE.Name = "cbxNOTE";
            this.cbxNOTE.Size = new System.Drawing.Size(121, 20);
            this.cbxNOTE.TabIndex = 3;
            this.cbxNOTE.Tag = "備註";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(20, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1130;
            this.label3.Text = "員工編號";
            // 
            // cbxNOBR
            // 
            this.cbxNOBR.FormattingEnabled = true;
            this.cbxNOBR.Location = new System.Drawing.Point(79, 17);
            this.cbxNOBR.Name = "cbxNOBR";
            this.cbxNOBR.Size = new System.Drawing.Size(121, 20);
            this.cbxNOBR.TabIndex = 0;
            this.cbxNOBR.Tag = "員工編號";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(43, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1128;
            this.label1.Text = "職稱";
            // 
            // cbxTITTLE
            // 
            this.cbxTITTLE.FormattingEnabled = true;
            this.cbxTITTLE.Location = new System.Drawing.Point(79, 69);
            this.cbxTITTLE.Name = "cbxTITTLE";
            this.cbxTITTLE.Size = new System.Drawing.Size(121, 20);
            this.cbxTITTLE.TabIndex = 2;
            this.cbxTITTLE.Tag = "職稱";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(43, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1126;
            this.label2.Text = "公司";
            // 
            // cbxCOMPANY
            // 
            this.cbxCOMPANY.FormattingEnabled = true;
            this.cbxCOMPANY.Location = new System.Drawing.Point(79, 43);
            this.cbxCOMPANY.Name = "cbxCOMPANY";
            this.cbxCOMPANY.Size = new System.Drawing.Size(121, 20);
            this.cbxCOMPANY.TabIndex = 1;
            this.cbxCOMPANY.Tag = "公司";
            // 
            // FRM1AIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(417, 133);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbxEDATE);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxBDATE);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbxJOB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbxNOTE);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxNOBR);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxTITTLE);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxCOMPANY);
            this.Controls.Add(this.btnImport);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FRM1AIN";
            this.Load += new System.EventHandler(this.FRM1AIN_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxEDATE;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxBDATE;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxJOB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxNOTE;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxNOBR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxTITTLE;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxCOMPANY;
    }
}
