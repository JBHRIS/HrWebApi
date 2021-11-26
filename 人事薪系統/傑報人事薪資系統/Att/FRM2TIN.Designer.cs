namespace JBHR.Att
{
    partial class FRM2TIN
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
            this.cbxDdate = new System.Windows.Forms.ComboBox();
            this.cbxNOTE = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxTOL_HOURS = new System.Windows.Forms.ComboBox();
            this.cbxBDATE = new System.Windows.Forms.ComboBox();
            this.cbxNOBR = new System.Windows.Forms.ComboBox();
            this.cbxH_CODE = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(79, 183);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 6;
            this.btnImport.Text = "設定";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // cbxDdate
            // 
            this.cbxDdate.FormattingEnabled = true;
            this.cbxDdate.Location = new System.Drawing.Point(91, 122);
            this.cbxDdate.Name = "cbxDdate";
            this.cbxDdate.Size = new System.Drawing.Size(121, 20);
            this.cbxDdate.TabIndex = 4;
            this.cbxDdate.Tag = "失效日期";
            this.cbxDdate.SelectedIndexChanged += new System.EventHandler(this.cbxDdate_SelectedIndexChanged);
            // 
            // cbxNOTE
            // 
            this.cbxNOTE.FormattingEnabled = true;
            this.cbxNOTE.Location = new System.Drawing.Point(91, 148);
            this.cbxNOTE.Name = "cbxNOTE";
            this.cbxNOTE.Size = new System.Drawing.Size(121, 20);
            this.cbxNOTE.TabIndex = 5;
            this.cbxNOTE.Tag = "備註";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(56, 151);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 1081;
            this.label12.Text = "備註";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(2, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 12);
            this.label7.TabIndex = 1077;
            this.label7.Text = "得假時數/天數";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(32, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1073;
            this.label3.Text = "生效日期";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(32, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1072;
            this.label2.Text = "員工編號";
            // 
            // cbxTOL_HOURS
            // 
            this.cbxTOL_HOURS.FormattingEnabled = true;
            this.cbxTOL_HOURS.Location = new System.Drawing.Point(91, 70);
            this.cbxTOL_HOURS.Name = "cbxTOL_HOURS";
            this.cbxTOL_HOURS.Size = new System.Drawing.Size(121, 20);
            this.cbxTOL_HOURS.TabIndex = 2;
            this.cbxTOL_HOURS.Tag = "得假時數/天數";
            // 
            // cbxBDATE
            // 
            this.cbxBDATE.FormattingEnabled = true;
            this.cbxBDATE.Location = new System.Drawing.Point(91, 44);
            this.cbxBDATE.Name = "cbxBDATE";
            this.cbxBDATE.Size = new System.Drawing.Size(121, 20);
            this.cbxBDATE.TabIndex = 1;
            this.cbxBDATE.Tag = "生效日期";
            // 
            // cbxNOBR
            // 
            this.cbxNOBR.FormattingEnabled = true;
            this.cbxNOBR.Location = new System.Drawing.Point(91, 18);
            this.cbxNOBR.Name = "cbxNOBR";
            this.cbxNOBR.Size = new System.Drawing.Size(121, 20);
            this.cbxNOBR.TabIndex = 0;
            this.cbxNOBR.Tag = "員工編號";
            // 
            // cbxH_CODE
            // 
            this.cbxH_CODE.FormattingEnabled = true;
            this.cbxH_CODE.Location = new System.Drawing.Point(91, 96);
            this.cbxH_CODE.Name = "cbxH_CODE";
            this.cbxH_CODE.Size = new System.Drawing.Size(121, 20);
            this.cbxH_CODE.TabIndex = 3;
            this.cbxH_CODE.Tag = "假別代碼";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(32, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1086;
            this.label1.Text = "假別代碼";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(32, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 1087;
            this.label6.Text = "失效日期";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // FRM2TIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 224);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxH_CODE);
            this.Controls.Add(this.cbxDdate);
            this.Controls.Add(this.cbxNOTE);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxTOL_HOURS);
            this.Controls.Add(this.cbxBDATE);
            this.Controls.Add(this.cbxNOBR);
            this.Controls.Add(this.btnImport);
            this.Name = "FRM2TIN";
            this.Text = "FRM2TIN";
            this.Load += new System.EventHandler(this.FRM2TIN_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.ComboBox cbxDdate;
        private System.Windows.Forms.ComboBox cbxNOTE;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxTOL_HOURS;
        private System.Windows.Forms.ComboBox cbxBDATE;
        private System.Windows.Forms.ComboBox cbxNOBR;
        private System.Windows.Forms.ComboBox cbxH_CODE;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;

    }
}