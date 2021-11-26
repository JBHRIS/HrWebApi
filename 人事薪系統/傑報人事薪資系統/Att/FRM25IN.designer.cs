namespace JBHR.Att
{
    partial class FRM25IN
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
            this.cbxMENO = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxONTIME = new System.Windows.Forms.ComboBox();
            this.cbxADATE = new System.Windows.Forms.ComboBox();
            this.cbxNOBR = new System.Windows.Forms.ComboBox();
            this.cbxREASON = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbLOS_TRUE = new System.Windows.Forms.RadioButton();
            this.rbLOS_FALSE = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(106, 178);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "設定";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // cbxMENO
            // 
            this.cbxMENO.FormattingEnabled = true;
            this.cbxMENO.Location = new System.Drawing.Point(106, 121);
            this.cbxMENO.Name = "cbxMENO";
            this.cbxMENO.Size = new System.Drawing.Size(121, 20);
            this.cbxMENO.TabIndex = 5;
            this.cbxMENO.Tag = "備註";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(71, 124);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 1081;
            this.label12.Text = "備註";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(47, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 1074;
            this.label4.Text = "刷卡時間";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(47, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1073;
            this.label3.Text = "刷卡日期";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(47, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1072;
            this.label2.Text = "員工編號";
            // 
            // cbxONTIME
            // 
            this.cbxONTIME.FormattingEnabled = true;
            this.cbxONTIME.Location = new System.Drawing.Point(106, 69);
            this.cbxONTIME.Name = "cbxONTIME";
            this.cbxONTIME.Size = new System.Drawing.Size(121, 20);
            this.cbxONTIME.TabIndex = 3;
            this.cbxONTIME.Tag = "刷卡時間";
            // 
            // cbxADATE
            // 
            this.cbxADATE.FormattingEnabled = true;
            this.cbxADATE.Location = new System.Drawing.Point(106, 43);
            this.cbxADATE.Name = "cbxADATE";
            this.cbxADATE.Size = new System.Drawing.Size(121, 20);
            this.cbxADATE.TabIndex = 2;
            this.cbxADATE.Tag = "刷卡日期";
            // 
            // cbxNOBR
            // 
            this.cbxNOBR.FormattingEnabled = true;
            this.cbxNOBR.Location = new System.Drawing.Point(106, 17);
            this.cbxNOBR.Name = "cbxNOBR";
            this.cbxNOBR.Size = new System.Drawing.Size(121, 20);
            this.cbxNOBR.TabIndex = 1;
            this.cbxNOBR.Tag = "員工編號";
            // 
            // cbxREASON
            // 
            this.cbxREASON.FormattingEnabled = true;
            this.cbxREASON.Location = new System.Drawing.Point(106, 95);
            this.cbxREASON.Name = "cbxREASON";
            this.cbxREASON.Size = new System.Drawing.Size(121, 20);
            this.cbxREASON.TabIndex = 4;
            this.cbxREASON.Tag = "原因代碼";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(47, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1086;
            this.label1.Text = "原因代碼";
            // 
            // rbLOS_TRUE
            // 
            this.rbLOS_TRUE.AutoSize = true;
            this.rbLOS_TRUE.Checked = true;
            this.rbLOS_TRUE.Location = new System.Drawing.Point(116, 8);
            this.rbLOS_TRUE.Name = "rbLOS_TRUE";
            this.rbLOS_TRUE.Size = new System.Drawing.Size(35, 16);
            this.rbLOS_TRUE.TabIndex = 1087;
            this.rbLOS_TRUE.TabStop = true;
            this.rbLOS_TRUE.Tag = "是否為遺忘刷卡";
            this.rbLOS_TRUE.Text = "是";
            this.rbLOS_TRUE.UseVisualStyleBackColor = true;
            // 
            // rbLOS_FALSE
            // 
            this.rbLOS_FALSE.AutoSize = true;
            this.rbLOS_FALSE.Location = new System.Drawing.Point(161, 8);
            this.rbLOS_FALSE.Name = "rbLOS_FALSE";
            this.rbLOS_FALSE.Size = new System.Drawing.Size(35, 16);
            this.rbLOS_FALSE.TabIndex = 1088;
            this.rbLOS_FALSE.Text = "否";
            this.rbLOS_FALSE.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbLOS_FALSE);
            this.panel1.Controls.Add(this.rbLOS_TRUE);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(38, 142);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(204, 30);
            this.panel1.TabIndex = 1090;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 12);
            this.label5.TabIndex = 1081;
            this.label5.Text = "是否為遺忘刷卡:";
            // 
            // FRM25IN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 214);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxREASON);
            this.Controls.Add(this.cbxMENO);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxONTIME);
            this.Controls.Add(this.cbxADATE);
            this.Controls.Add(this.cbxNOBR);
            this.Controls.Add(this.btnImport);
            this.Name = "FRM25IN";
            this.Text = "FRM25IN";
            this.Load += new System.EventHandler(this.FRM25IN_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.ComboBox cbxMENO;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxONTIME;
        private System.Windows.Forms.ComboBox cbxADATE;
        private System.Windows.Forms.ComboBox cbxNOBR;
        private System.Windows.Forms.ComboBox cbxREASON;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbLOS_TRUE;
        private System.Windows.Forms.RadioButton rbLOS_FALSE;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;

    }
}