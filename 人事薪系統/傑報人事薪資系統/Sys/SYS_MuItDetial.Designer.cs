namespace JBHR.Sys
{
    partial class SYS_MuItDetial
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
            this.lbMenuName = new System.Windows.Forms.Label();
            this.lbDspText = new System.Windows.Forms.Label();
            this.txtMenuName = new System.Windows.Forms.TextBox();
            this.txtDspText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFromList = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.chbCommon = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lbMenuName
            // 
            this.lbMenuName.AutoSize = true;
            this.lbMenuName.Location = new System.Drawing.Point(11, 17);
            this.lbMenuName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbMenuName.Name = "lbMenuName";
            this.lbMenuName.Size = new System.Drawing.Size(53, 12);
            this.lbMenuName.TabIndex = 0;
            this.lbMenuName.Text = "選單名稱";
            // 
            // lbDspText
            // 
            this.lbDspText.AutoSize = true;
            this.lbDspText.Location = new System.Drawing.Point(11, 43);
            this.lbDspText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbDspText.Name = "lbDspText";
            this.lbDspText.Size = new System.Drawing.Size(53, 12);
            this.lbDspText.TabIndex = 1;
            this.lbDspText.Text = "顯示文字";
            // 
            // txtMenuName
            // 
            this.txtMenuName.Location = new System.Drawing.Point(65, 14);
            this.txtMenuName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMenuName.Name = "txtMenuName";
            this.txtMenuName.Size = new System.Drawing.Size(196, 22);
            this.txtMenuName.TabIndex = 0;
            // 
            // txtDspText
            // 
            this.txtDspText.Location = new System.Drawing.Point(65, 40);
            this.txtDspText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDspText.Name = "txtDspText";
            this.txtDspText.Size = new System.Drawing.Size(196, 22);
            this.txtDspText.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 69);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "開啟頁面";
            // 
            // cbFromList
            // 
            this.cbFromList.DisplayMember = "Value";
            this.cbFromList.FormattingEnabled = true;
            this.cbFromList.Location = new System.Drawing.Point(65, 66);
            this.cbFromList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbFromList.Name = "cbFromList";
            this.cbFromList.Size = new System.Drawing.Size(196, 20);
            this.cbFromList.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(107, 90);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "存檔";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(186, 90);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.TabStop = false;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // chbCommon
            // 
            this.chbCommon.AutoSize = true;
            this.chbCommon.Location = new System.Drawing.Point(13, 95);
            this.chbCommon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chbCommon.Name = "chbCommon";
            this.chbCommon.Size = new System.Drawing.Size(72, 16);
            this.chbCommon.TabIndex = 3;
            this.chbCommon.TabStop = false;
            this.chbCommon.Text = "公用選單";
            this.chbCommon.UseVisualStyleBackColor = true;
            // 
            // SYS_MuItDetial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 120);
            this.Controls.Add(this.chbCommon);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbFromList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDspText);
            this.Controls.Add(this.txtMenuName);
            this.Controls.Add(this.lbDspText);
            this.Controls.Add(this.lbMenuName);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "SYS_MuItDetial";
            this.Text = "選單功能設定";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Sys_MuItDetial_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbMenuName;
        private System.Windows.Forms.Label lbDspText;
        private System.Windows.Forms.TextBox txtMenuName;
        private System.Windows.Forms.TextBox txtDspText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbFromList;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox chbCommon;
    }
}