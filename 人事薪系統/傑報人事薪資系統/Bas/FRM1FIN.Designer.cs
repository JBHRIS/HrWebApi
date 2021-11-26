namespace JBHR.Bas
{
    partial class FRM1FIN
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
            this.cbxEDATE = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxMDATE = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxNOBR = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxCOMP = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxDESCS = new System.Windows.Forms.ComboBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.cbxLIC_PASS = new System.Windows.Forms.ComboBox();
            this.cbxLIC_NOTE = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cbxOWNER = new System.Windows.Forms.ComboBox();
            this.cbxLIC_NO = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(18, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 1177;
            this.label4.Text = "有效日期";
            // 
            // cbxEDATE
            // 
            this.cbxEDATE.FormattingEnabled = true;
            this.cbxEDATE.Location = new System.Drawing.Point(76, 123);
            this.cbxEDATE.Name = "cbxEDATE";
            this.cbxEDATE.Size = new System.Drawing.Size(121, 20);
            this.cbxEDATE.TabIndex = 5;
            this.cbxEDATE.Tag = "有效日期";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(18, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 1175;
            this.label6.Text = "生效日期";
            // 
            // cbxMDATE
            // 
            this.cbxMDATE.FormattingEnabled = true;
            this.cbxMDATE.Location = new System.Drawing.Point(77, 97);
            this.cbxMDATE.Name = "cbxMDATE";
            this.cbxMDATE.Size = new System.Drawing.Size(121, 20);
            this.cbxMDATE.TabIndex = 4;
            this.cbxMDATE.Tag = "生效日期";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(18, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1171;
            this.label3.Text = "員工編號";
            // 
            // cbxNOBR
            // 
            this.cbxNOBR.FormattingEnabled = true;
            this.cbxNOBR.Location = new System.Drawing.Point(77, 17);
            this.cbxNOBR.Name = "cbxNOBR";
            this.cbxNOBR.Size = new System.Drawing.Size(121, 20);
            this.cbxNOBR.TabIndex = 1;
            this.cbxNOBR.Tag = "員工編號";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(18, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1169;
            this.label1.Text = "發照單位";
            // 
            // cbxCOMP
            // 
            this.cbxCOMP.FormattingEnabled = true;
            this.cbxCOMP.Location = new System.Drawing.Point(77, 70);
            this.cbxCOMP.Name = "cbxCOMP";
            this.cbxCOMP.Size = new System.Drawing.Size(121, 20);
            this.cbxCOMP.TabIndex = 3;
            this.cbxCOMP.Tag = "發照單位";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(18, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1167;
            this.label2.Text = "證照內容";
            // 
            // cbxDESCS
            // 
            this.cbxDESCS.FormattingEnabled = true;
            this.cbxDESCS.Location = new System.Drawing.Point(77, 43);
            this.cbxDESCS.Name = "cbxDESCS";
            this.cbxDESCS.Size = new System.Drawing.Size(121, 20);
            this.cbxDESCS.TabIndex = 2;
            this.cbxDESCS.Tag = "證照內容";
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(225, 123);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 10;
            this.btnImport.Text = "設定";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // cbxLIC_PASS
            // 
            this.cbxLIC_PASS.FormattingEnabled = true;
            this.cbxLIC_PASS.Location = new System.Drawing.Point(282, 70);
            this.cbxLIC_PASS.Name = "cbxLIC_PASS";
            this.cbxLIC_PASS.Size = new System.Drawing.Size(121, 20);
            this.cbxLIC_PASS.TabIndex = 8;
            this.cbxLIC_PASS.Tag = "國家考試";
            // 
            // cbxLIC_NOTE
            // 
            this.cbxLIC_NOTE.FormattingEnabled = true;
            this.cbxLIC_NOTE.Location = new System.Drawing.Point(282, 97);
            this.cbxLIC_NOTE.Name = "cbxLIC_NOTE";
            this.cbxLIC_NOTE.Size = new System.Drawing.Size(121, 20);
            this.cbxLIC_NOTE.TabIndex = 9;
            this.cbxLIC_NOTE.Tag = "備註欄";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(235, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 1173;
            this.label5.Text = "備註欄";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(223, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 1187;
            this.label11.Text = "國家考試";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(211, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 1185;
            this.label10.Text = "本公司擁有";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(223, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 1189;
            this.label12.Text = "證照編號";
            // 
            // cbxOWNER
            // 
            this.cbxOWNER.FormattingEnabled = true;
            this.cbxOWNER.Location = new System.Drawing.Point(282, 43);
            this.cbxOWNER.Name = "cbxOWNER";
            this.cbxOWNER.Size = new System.Drawing.Size(121, 20);
            this.cbxOWNER.TabIndex = 7;
            this.cbxOWNER.Tag = "本公司擁有";
            // 
            // cbxLIC_NO
            // 
            this.cbxLIC_NO.FormattingEnabled = true;
            this.cbxLIC_NO.Location = new System.Drawing.Point(282, 17);
            this.cbxLIC_NO.Name = "cbxLIC_NO";
            this.cbxLIC_NO.Size = new System.Drawing.Size(121, 20);
            this.cbxLIC_NO.TabIndex = 6;
            this.cbxLIC_NO.Tag = "證照編號";
            // 
            // FRM1FIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(417, 159);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cbxLIC_NO);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cbxLIC_PASS);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbxOWNER);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxEDATE);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbxMDATE);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbxLIC_NOTE);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxNOBR);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxCOMP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxDESCS);
            this.Controls.Add(this.btnImport);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FRM1FIN";
            this.Load += new System.EventHandler(this.FRM1FIN_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxEDATE;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxMDATE;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxNOBR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxCOMP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxDESCS;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.ComboBox cbxLIC_PASS;
        private System.Windows.Forms.ComboBox cbxLIC_NOTE;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbxOWNER;
        private System.Windows.Forms.ComboBox cbxLIC_NO;
    }
}
