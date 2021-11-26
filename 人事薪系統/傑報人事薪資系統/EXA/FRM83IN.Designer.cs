namespace JBHR.EXA
{
    partial class FRM83IN
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
            this.label2 = new System.Windows.Forms.Label();
            this.cbxYYMM = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxEFFTYPE = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxNOBR = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxEFFSCORE = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxEFFLVL = new System.Windows.Forms.ComboBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(47, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1074;
            this.label2.Text = "績效年度";
            // 
            // cbxYYMM
            // 
            this.cbxYYMM.FormattingEnabled = true;
            this.cbxYYMM.Location = new System.Drawing.Point(106, 17);
            this.cbxYYMM.Name = "cbxYYMM";
            this.cbxYYMM.Size = new System.Drawing.Size(121, 20);
            this.cbxYYMM.TabIndex = 0;
            this.cbxYYMM.Tag = "績效年度";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(47, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1076;
            this.label1.Text = "考核種類";
            // 
            // cbxEFFTYPE
            // 
            this.cbxEFFTYPE.FormattingEnabled = true;
            this.cbxEFFTYPE.Location = new System.Drawing.Point(106, 43);
            this.cbxEFFTYPE.Name = "cbxEFFTYPE";
            this.cbxEFFTYPE.Size = new System.Drawing.Size(121, 20);
            this.cbxEFFTYPE.TabIndex = 1;
            this.cbxEFFTYPE.Tag = "考核種類";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(47, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1078;
            this.label3.Text = "員工編號";
            // 
            // cbxNOBR
            // 
            this.cbxNOBR.FormattingEnabled = true;
            this.cbxNOBR.Location = new System.Drawing.Point(106, 69);
            this.cbxNOBR.Name = "cbxNOBR";
            this.cbxNOBR.Size = new System.Drawing.Size(121, 20);
            this.cbxNOBR.TabIndex = 2;
            this.cbxNOBR.Tag = "員工編號";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(47, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 1082;
            this.label5.Text = "考核分數";
            // 
            // cbxEFFSCORE
            // 
            this.cbxEFFSCORE.FormattingEnabled = true;
            this.cbxEFFSCORE.Location = new System.Drawing.Point(106, 95);
            this.cbxEFFSCORE.Name = "cbxEFFSCORE";
            this.cbxEFFSCORE.Size = new System.Drawing.Size(121, 20);
            this.cbxEFFSCORE.TabIndex = 3;
            this.cbxEFFSCORE.Tag = "考核分數";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(47, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 1084;
            this.label6.Text = "考核等級";
            // 
            // cbxEFFLVL
            // 
            this.cbxEFFLVL.FormattingEnabled = true;
            this.cbxEFFLVL.Location = new System.Drawing.Point(106, 121);
            this.cbxEFFLVL.Name = "cbxEFFLVL";
            this.cbxEFFLVL.Size = new System.Drawing.Size(121, 20);
            this.cbxEFFLVL.TabIndex = 4;
            this.cbxEFFLVL.Tag = "考核等級";
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(106, 147);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 5;
            this.btnImport.Text = "設定";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // FRM83IN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(288, 181);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbxEFFLVL);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbxEFFSCORE);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxNOBR);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxEFFTYPE);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxYYMM);
            this.Name = "FRM83IN";
            this.Load += new System.EventHandler(this.FRM83IN_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxYYMM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxEFFTYPE;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxNOBR;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxEFFSCORE;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxEFFLVL;
        private System.Windows.Forms.Button btnImport;
    }
}
