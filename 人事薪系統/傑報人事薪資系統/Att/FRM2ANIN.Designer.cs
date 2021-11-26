namespace JBHR.Att
{
    partial class FRM2ANIN
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
            this.label3 = new System.Windows.Forms.Label();
            this.cbxNOBR = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxADATE = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxROTE = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(83, 89);
            this.btnImport.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(50, 23);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "設定";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(26, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1104;
            this.label3.Text = "員工編號";
            // 
            // cbxNOBR
            // 
            this.cbxNOBR.FormattingEnabled = true;
            this.cbxNOBR.Location = new System.Drawing.Point(83, 13);
            this.cbxNOBR.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbxNOBR.Name = "cbxNOBR";
            this.cbxNOBR.Size = new System.Drawing.Size(108, 20);
            this.cbxNOBR.TabIndex = 1;
            this.cbxNOBR.Tag = "員工編號";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(26, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1102;
            this.label1.Text = "調班日期";
            // 
            // cbxADATE
            // 
            this.cbxADATE.FormattingEnabled = true;
            this.cbxADATE.Location = new System.Drawing.Point(83, 37);
            this.cbxADATE.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbxADATE.Name = "cbxADATE";
            this.cbxADATE.Size = new System.Drawing.Size(108, 20);
            this.cbxADATE.TabIndex = 2;
            this.cbxADATE.Tag = "調班日期";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(26, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1100;
            this.label2.Text = "調班班別";
            // 
            // cbxROTE
            // 
            this.cbxROTE.FormattingEnabled = true;
            this.cbxROTE.Location = new System.Drawing.Point(83, 61);
            this.cbxROTE.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbxROTE.Name = "cbxROTE";
            this.cbxROTE.Size = new System.Drawing.Size(108, 20);
            this.cbxROTE.TabIndex = 3;
            this.cbxROTE.Tag = "調班班別";
            // 
            // FRM2ANIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(209, 119);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxNOBR);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxADATE);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxROTE);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FRM2ANIN";
            this.Load += new System.EventHandler(this.FRM2ANIN_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxNOBR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxADATE;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxROTE;
    }
}
