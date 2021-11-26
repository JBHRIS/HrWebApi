namespace JBHR.Bas
{
    partial class FRM13IN
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
            this.label6 = new System.Windows.Forms.Label();
            this.cbxFA_BIRDT = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxREL_CODE = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxNOBR = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxFA_NAME = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxFA_IDNO = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxADDR = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(107, 169);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 6;
            this.btnImport.Text = "設定";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(48, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 1095;
            this.label6.Text = "眷屬生日";
            // 
            // cbxFA_BIRDT
            // 
            this.cbxFA_BIRDT.FormattingEnabled = true;
            this.cbxFA_BIRDT.Location = new System.Drawing.Point(107, 119);
            this.cbxFA_BIRDT.Name = "cbxFA_BIRDT";
            this.cbxFA_BIRDT.Size = new System.Drawing.Size(121, 20);
            this.cbxFA_BIRDT.TabIndex = 4;
            this.cbxFA_BIRDT.Tag = "眷屬生日";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(48, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 1093;
            this.label5.Text = "眷屬種類";
            // 
            // cbxREL_CODE
            // 
            this.cbxREL_CODE.FormattingEnabled = true;
            this.cbxREL_CODE.Location = new System.Drawing.Point(107, 93);
            this.cbxREL_CODE.Name = "cbxREL_CODE";
            this.cbxREL_CODE.Size = new System.Drawing.Size(121, 20);
            this.cbxREL_CODE.TabIndex = 3;
            this.cbxREL_CODE.Tag = "眷屬種類";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(48, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1091;
            this.label3.Text = "員工編號";
            // 
            // cbxNOBR
            // 
            this.cbxNOBR.FormattingEnabled = true;
            this.cbxNOBR.Location = new System.Drawing.Point(107, 15);
            this.cbxNOBR.Name = "cbxNOBR";
            this.cbxNOBR.Size = new System.Drawing.Size(121, 20);
            this.cbxNOBR.TabIndex = 0;
            this.cbxNOBR.Tag = "員工編號";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(48, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1089;
            this.label1.Text = "眷屬姓名";
            // 
            // cbxFA_NAME
            // 
            this.cbxFA_NAME.FormattingEnabled = true;
            this.cbxFA_NAME.Location = new System.Drawing.Point(107, 41);
            this.cbxFA_NAME.Name = "cbxFA_NAME";
            this.cbxFA_NAME.Size = new System.Drawing.Size(121, 20);
            this.cbxFA_NAME.TabIndex = 1;
            this.cbxFA_NAME.Tag = "眷屬姓名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(25, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 1087;
            this.label2.Text = "眷屬身份証號";
            // 
            // cbxFA_IDNO
            // 
            this.cbxFA_IDNO.FormattingEnabled = true;
            this.cbxFA_IDNO.Location = new System.Drawing.Point(107, 68);
            this.cbxFA_IDNO.Name = "cbxFA_IDNO";
            this.cbxFA_IDNO.Size = new System.Drawing.Size(121, 20);
            this.cbxFA_IDNO.TabIndex = 2;
            this.cbxFA_IDNO.Tag = "眷屬身份証號";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(48, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 1098;
            this.label4.Text = "眷屬地址";
            // 
            // cbxADDR
            // 
            this.cbxADDR.FormattingEnabled = true;
            this.cbxADDR.Location = new System.Drawing.Point(107, 145);
            this.cbxADDR.Name = "cbxADDR";
            this.cbxADDR.Size = new System.Drawing.Size(121, 20);
            this.cbxADDR.TabIndex = 5;
            this.cbxADDR.Tag = "眷屬地址";
            // 
            // FRM13IN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(288, 200);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxADDR);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbxFA_BIRDT);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbxREL_CODE);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxNOBR);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxFA_NAME);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxFA_IDNO);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FRM13IN";
            this.Load += new System.EventHandler(this.FRM13IN_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxFA_BIRDT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxREL_CODE;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxNOBR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxFA_NAME;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxFA_IDNO;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxADDR;
    }
}
