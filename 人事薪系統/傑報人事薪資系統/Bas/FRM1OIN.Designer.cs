namespace JBHR.Bas
{
    partial class FRM1OIN
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
            this.label4 = new System.Windows.Forms.Label();
            this.cbxDdate = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxAdate = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxNOBR = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxWorkAdr = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxContractType = new System.Windows.Forms.ComboBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(15, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 1202;
            this.label4.Text = "到期日期";
            // 
            // cbxDdate
            // 
            this.cbxDdate.FormattingEnabled = true;
            this.cbxDdate.Location = new System.Drawing.Point(73, 127);
            this.cbxDdate.Name = "cbxDdate";
            this.cbxDdate.Size = new System.Drawing.Size(121, 20);
            this.cbxDdate.TabIndex = 4;
            this.cbxDdate.Tag = "到期日期";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(15, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 1200;
            this.label6.Text = "起始日期";
            // 
            // cbxAdate
            // 
            this.cbxAdate.FormattingEnabled = true;
            this.cbxAdate.Location = new System.Drawing.Point(74, 100);
            this.cbxAdate.Name = "cbxAdate";
            this.cbxAdate.Size = new System.Drawing.Size(121, 20);
            this.cbxAdate.TabIndex = 3;
            this.cbxAdate.Tag = "起始日期";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(15, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1196;
            this.label3.Text = "員工編號";
            // 
            // cbxNOBR
            // 
            this.cbxNOBR.FormattingEnabled = true;
            this.cbxNOBR.Location = new System.Drawing.Point(74, 20);
            this.cbxNOBR.Name = "cbxNOBR";
            this.cbxNOBR.Size = new System.Drawing.Size(121, 20);
            this.cbxNOBR.TabIndex = 0;
            this.cbxNOBR.Tag = "員工編號";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(27, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1194;
            this.label1.Text = "派駐區";
            // 
            // cbxWorkAdr
            // 
            this.cbxWorkAdr.FormattingEnabled = true;
            this.cbxWorkAdr.Location = new System.Drawing.Point(74, 73);
            this.cbxWorkAdr.Name = "cbxWorkAdr";
            this.cbxWorkAdr.Size = new System.Drawing.Size(121, 20);
            this.cbxWorkAdr.TabIndex = 2;
            this.cbxWorkAdr.Tag = "派駐區";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(15, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1192;
            this.label2.Text = "合同種類";
            // 
            // cbxContractType
            // 
            this.cbxContractType.FormattingEnabled = true;
            this.cbxContractType.Location = new System.Drawing.Point(74, 47);
            this.cbxContractType.Name = "cbxContractType";
            this.cbxContractType.Size = new System.Drawing.Size(121, 20);
            this.cbxContractType.TabIndex = 1;
            this.cbxContractType.Tag = "合同種類";
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(73, 159);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 5;
            this.btnImport.Text = "設定";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // FRM1OIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(216, 194);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxDdate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbxAdate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxNOBR);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxWorkAdr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxContractType);
            this.Controls.Add(this.btnImport);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FRM1OIN";
            this.Load += new System.EventHandler(this.FRM1OIN_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxDdate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxAdate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxNOBR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxWorkAdr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxContractType;
        private System.Windows.Forms.Button btnImport;
    }
}
