namespace JBHR.Bas
{
    partial class FRM1DIN
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
            this.label9 = new System.Windows.Forms.Label();
            this.cbxDATE = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxCADATE = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxNOBR = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxRATE = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxDEPTS = new System.Windows.Forms.ComboBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(31, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 1175;
            this.label9.Text = "失效日期";
            // 
            // cbxDATE
            // 
            this.cbxDATE.FormattingEnabled = true;
            this.cbxDATE.Location = new System.Drawing.Point(90, 125);
            this.cbxDATE.Name = "cbxDATE";
            this.cbxDATE.Size = new System.Drawing.Size(121, 20);
            this.cbxDATE.TabIndex = 4;
            this.cbxDATE.Tag = "失效日期";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(31, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 1173;
            this.label8.Text = "生效日期";
            // 
            // cbxCADATE
            // 
            this.cbxCADATE.FormattingEnabled = true;
            this.cbxCADATE.Location = new System.Drawing.Point(90, 97);
            this.cbxCADATE.Name = "cbxCADATE";
            this.cbxCADATE.Size = new System.Drawing.Size(121, 20);
            this.cbxCADATE.TabIndex = 3;
            this.cbxCADATE.Tag = "生效日期";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(31, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1171;
            this.label3.Text = "員工編號";
            // 
            // cbxNOBR
            // 
            this.cbxNOBR.FormattingEnabled = true;
            this.cbxNOBR.Location = new System.Drawing.Point(90, 18);
            this.cbxNOBR.Name = "cbxNOBR";
            this.cbxNOBR.Size = new System.Drawing.Size(121, 20);
            this.cbxNOBR.TabIndex = 0;
            this.cbxNOBR.Tag = "員工編號";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(31, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1169;
            this.label1.Text = "分攤比率";
            // 
            // cbxRATE
            // 
            this.cbxRATE.FormattingEnabled = true;
            this.cbxRATE.Location = new System.Drawing.Point(90, 70);
            this.cbxRATE.Name = "cbxRATE";
            this.cbxRATE.Size = new System.Drawing.Size(121, 20);
            this.cbxRATE.TabIndex = 2;
            this.cbxRATE.Tag = "分攤比率";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(31, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1167;
            this.label2.Text = "成本部門";
            // 
            // cbxDEPTS
            // 
            this.cbxDEPTS.FormattingEnabled = true;
            this.cbxDEPTS.Location = new System.Drawing.Point(90, 44);
            this.cbxDEPTS.Name = "cbxDEPTS";
            this.cbxDEPTS.Size = new System.Drawing.Size(121, 20);
            this.cbxDEPTS.TabIndex = 1;
            this.cbxDEPTS.Tag = "成本部門";
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(90, 157);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 5;
            this.btnImport.Text = "設定";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // FRM1DIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(239, 195);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbxDATE);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbxCADATE);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxNOBR);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxRATE);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxDEPTS);
            this.Controls.Add(this.btnImport);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FRM1DIN";
            this.Load += new System.EventHandler(this.FRM1DIN_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbxDATE;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbxCADATE;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxNOBR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxRATE;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxDEPTS;
        private System.Windows.Forms.Button btnImport;
    }
}
