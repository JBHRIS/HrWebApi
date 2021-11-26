namespace JBHR.Sys
{
    partial class SYS_UserDefineMgt_ADD_M
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtMasterName = new System.Windows.Forms.TextBox();
            this.lbMasterName = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.lbNote = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(172, 127);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(91, 127);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "存檔";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtMasterName
            // 
            this.txtMasterName.Enabled = false;
            this.txtMasterName.Location = new System.Drawing.Point(91, 12);
            this.txtMasterName.Name = "txtMasterName";
            this.txtMasterName.Size = new System.Drawing.Size(124, 22);
            this.txtMasterName.TabIndex = 0;
            // 
            // lbMasterName
            // 
            this.lbMasterName.AutoSize = true;
            this.lbMasterName.Location = new System.Drawing.Point(32, 15);
            this.lbMasterName.Name = "lbMasterName";
            this.lbMasterName.Size = new System.Drawing.Size(53, 12);
            this.lbMasterName.TabIndex = 16;
            this.lbMasterName.Text = "主檔名稱";
            // 
            // txtNote
            // 
            this.txtNote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNote.Location = new System.Drawing.Point(91, 40);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(183, 81);
            this.txtNote.TabIndex = 2;
            // 
            // lbNote
            // 
            this.lbNote.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbNote.AutoSize = true;
            this.lbNote.Location = new System.Drawing.Point(56, 48);
            this.lbNote.Name = "lbNote";
            this.lbNote.Size = new System.Drawing.Size(29, 12);
            this.lbNote.TabIndex = 20;
            this.lbNote.Text = "備註";
            // 
            // SYS_UserDefineMgt_ADD_M
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 163);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.lbNote);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtMasterName);
            this.Controls.Add(this.lbMasterName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SYS_UserDefineMgt_ADD_M";
            this.Text = "自定義欄位主檔設定";
            this.Load += new System.EventHandler(this.SYS_UserDefineMgt_ADD_C_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtMasterName;
        private System.Windows.Forms.Label lbMasterName;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label lbNote;
    }
}