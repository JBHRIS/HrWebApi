namespace JBHR.Bas
{
    partial class FRM1GIN
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
            this.label12 = new System.Windows.Forms.Label();
            this.cbxMaster = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxMEMO = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxNOBR = new System.Windows.Forms.ComboBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(11, 45);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 1196;
            this.label12.Text = "專長與興趣";
            // 
            // cbxMaster
            // 
            this.cbxMaster.FormattingEnabled = true;
            this.cbxMaster.Location = new System.Drawing.Point(81, 43);
            this.cbxMaster.Name = "cbxMaster";
            this.cbxMaster.Size = new System.Drawing.Size(121, 20);
            this.cbxMaster.TabIndex = 1;
            this.cbxMaster.Tag = "專長與興趣";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(47, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 1194;
            this.label5.Text = "備註";
            // 
            // cbxMEMO
            // 
            this.cbxMEMO.FormattingEnabled = true;
            this.cbxMEMO.Location = new System.Drawing.Point(81, 70);
            this.cbxMEMO.Name = "cbxMEMO";
            this.cbxMEMO.Size = new System.Drawing.Size(121, 20);
            this.cbxMEMO.TabIndex = 2;
            this.cbxMEMO.Tag = "備註";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(23, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1192;
            this.label3.Text = "員工編號";
            // 
            // cbxNOBR
            // 
            this.cbxNOBR.FormattingEnabled = true;
            this.cbxNOBR.Location = new System.Drawing.Point(81, 17);
            this.cbxNOBR.Name = "cbxNOBR";
            this.cbxNOBR.Size = new System.Drawing.Size(121, 20);
            this.cbxNOBR.TabIndex = 0;
            this.cbxNOBR.Tag = "員工編號";
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(81, 99);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "設定";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // FRM1GIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(223, 137);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cbxMaster);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbxMEMO);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxNOBR);
            this.Controls.Add(this.btnImport);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FRM1GIN";
            this.Load += new System.EventHandler(this.FRM1GIN_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbxMaster;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxMEMO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxNOBR;
        private System.Windows.Forms.Button btnImport;
    }
}
