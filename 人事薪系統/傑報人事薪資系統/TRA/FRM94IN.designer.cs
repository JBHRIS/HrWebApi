namespace JBHR.TRA
{
    partial class FRM94IN
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnImport = new System.Windows.Forms.Button();
            this.cbxTR_MEMO = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxNOBR = new System.Windows.Forms.ComboBox();
            this.cbxTR_ASDATE = new System.Windows.Forms.ComboBox();
            this.cbxCOURSE = new System.Windows.Forms.ComboBox();
            this.cbxAT_HRS = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxST_HRS = new System.Windows.Forms.ComboBox();
            this.cbxCLOSE_ = new System.Windows.Forms.ComboBox();
            this.cbxTR_REPO = new System.Windows.Forms.ComboBox();
            this.cbxAPPLYNO = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbxAVL = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(195, 163);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 13;
            this.btnImport.Text = "設定";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // cbxTR_MEMO
            // 
            this.cbxTR_MEMO.FormattingEnabled = true;
            this.cbxTR_MEMO.Location = new System.Drawing.Point(306, 122);
            this.cbxTR_MEMO.Name = "cbxTR_MEMO";
            this.cbxTR_MEMO.Size = new System.Drawing.Size(121, 20);
            this.cbxTR_MEMO.TabIndex = 9;
            this.cbxTR_MEMO.Tag = "備註";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(271, 125);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 1081;
            this.label12.Text = "備註";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(32, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 1075;
            this.label5.Text = "員工編號";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(20, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 1073;
            this.label3.Text = "完成評核日";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(32, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1072;
            this.label2.Text = "課程代碼";
            // 
            // cbxNOBR
            // 
            this.cbxNOBR.FormattingEnabled = true;
            this.cbxNOBR.Location = new System.Drawing.Point(91, 21);
            this.cbxNOBR.Name = "cbxNOBR";
            this.cbxNOBR.Size = new System.Drawing.Size(121, 20);
            this.cbxNOBR.TabIndex = 0;
            this.cbxNOBR.Tag = "員工編號";
            // 
            // cbxTR_ASDATE
            // 
            this.cbxTR_ASDATE.FormattingEnabled = true;
            this.cbxTR_ASDATE.Location = new System.Drawing.Point(91, 70);
            this.cbxTR_ASDATE.Name = "cbxTR_ASDATE";
            this.cbxTR_ASDATE.Size = new System.Drawing.Size(121, 20);
            this.cbxTR_ASDATE.TabIndex = 2;
            this.cbxTR_ASDATE.Tag = "完成評核日";
            // 
            // cbxCOURSE
            // 
            this.cbxCOURSE.FormattingEnabled = true;
            this.cbxCOURSE.Location = new System.Drawing.Point(91, 47);
            this.cbxCOURSE.Name = "cbxCOURSE";
            this.cbxCOURSE.Size = new System.Drawing.Size(121, 20);
            this.cbxCOURSE.TabIndex = 1;
            this.cbxCOURSE.Tag = "課程代碼";
            // 
            // cbxAT_HRS
            // 
            this.cbxAT_HRS.FormattingEnabled = true;
            this.cbxAT_HRS.Location = new System.Drawing.Point(91, 96);
            this.cbxAT_HRS.Name = "cbxAT_HRS";
            this.cbxAT_HRS.Size = new System.Drawing.Size(121, 20);
            this.cbxAT_HRS.TabIndex = 3;
            this.cbxAT_HRS.Tag = "缺課時數";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(32, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1073;
            this.label1.Text = "缺課時數";
            // 
            // cbxST_HRS
            // 
            this.cbxST_HRS.FormattingEnabled = true;
            this.cbxST_HRS.Location = new System.Drawing.Point(91, 122);
            this.cbxST_HRS.Name = "cbxST_HRS";
            this.cbxST_HRS.Size = new System.Drawing.Size(121, 20);
            this.cbxST_HRS.TabIndex = 4;
            this.cbxST_HRS.Tag = "已訓時數";
            // 
            // cbxCLOSE_
            // 
            this.cbxCLOSE_.FormattingEnabled = true;
            this.cbxCLOSE_.Location = new System.Drawing.Point(306, 47);
            this.cbxCLOSE_.Name = "cbxCLOSE_";
            this.cbxCLOSE_.Size = new System.Drawing.Size(121, 20);
            this.cbxCLOSE_.TabIndex = 6;
            this.cbxCLOSE_.Tag = "是否結訓";
            // 
            // cbxTR_REPO
            // 
            this.cbxTR_REPO.FormattingEnabled = true;
            this.cbxTR_REPO.Location = new System.Drawing.Point(306, 73);
            this.cbxTR_REPO.Name = "cbxTR_REPO";
            this.cbxTR_REPO.Size = new System.Drawing.Size(121, 20);
            this.cbxTR_REPO.TabIndex = 7;
            this.cbxTR_REPO.Tag = "是否完成評核";
            // 
            // cbxAPPLYNO
            // 
            this.cbxAPPLYNO.FormattingEnabled = true;
            this.cbxAPPLYNO.Location = new System.Drawing.Point(306, 21);
            this.cbxAPPLYNO.Name = "cbxAPPLYNO";
            this.cbxAPPLYNO.Size = new System.Drawing.Size(121, 20);
            this.cbxAPPLYNO.TabIndex = 5;
            this.cbxAPPLYNO.Tag = "申請編號";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(32, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 1072;
            this.label4.Text = "已訓時數";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(247, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 1073;
            this.label6.Text = "是否結訓";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(223, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 1073;
            this.label8.Text = "是否完成評核";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(247, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 1075;
            this.label9.Text = "申請編號";
            // 
            // cbxAVL
            // 
            this.cbxAVL.FormattingEnabled = true;
            this.cbxAVL.Location = new System.Drawing.Point(306, 96);
            this.cbxAVL.Name = "cbxAVL";
            this.cbxAVL.Size = new System.Drawing.Size(121, 20);
            this.cbxAVL.TabIndex = 8;
            this.cbxAVL.Tag = "是否合格";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(247, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 1072;
            this.label7.Text = "是否合格";
            // 
            // FRM94IN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 207);
            this.Controls.Add(this.cbxTR_MEMO);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxAPPLYNO);
            this.Controls.Add(this.cbxNOBR);
            this.Controls.Add(this.cbxTR_REPO);
            this.Controls.Add(this.cbxCLOSE_);
            this.Controls.Add(this.cbxAT_HRS);
            this.Controls.Add(this.cbxST_HRS);
            this.Controls.Add(this.cbxTR_ASDATE);
            this.Controls.Add(this.cbxAVL);
            this.Controls.Add(this.cbxCOURSE);
            this.Controls.Add(this.btnImport);
            this.Name = "FRM94IN";
            this.Text = "FRM95IN";
            this.Load += new System.EventHandler(this.FRM94IN_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.ComboBox cbxTR_MEMO;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxNOBR;
        private System.Windows.Forms.ComboBox cbxTR_ASDATE;
        private System.Windows.Forms.ComboBox cbxCOURSE;
        private System.Windows.Forms.ComboBox cbxAT_HRS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxST_HRS;
        private System.Windows.Forms.ComboBox cbxCLOSE_;
        private System.Windows.Forms.ComboBox cbxTR_REPO;
        private System.Windows.Forms.ComboBox cbxAPPLYNO;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbxAVL;
        private System.Windows.Forms.Label label7;

    }
}