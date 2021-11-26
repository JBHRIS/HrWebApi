namespace JBHR.Sys
{
    partial class SYS_MenuMgt_ADD
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
            this.lbMUGPName = new System.Windows.Forms.Label();
            this.txtMUGPName = new System.Windows.Forms.TextBox();
            this.cbInherit = new System.Windows.Forms.ComboBox();
            this.lbInherit = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbNote = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbMUGPName
            // 
            this.lbMUGPName.AutoSize = true;
            this.lbMUGPName.Location = new System.Drawing.Point(9, 17);
            this.lbMUGPName.Name = "lbMUGPName";
            this.lbMUGPName.Size = new System.Drawing.Size(77, 12);
            this.lbMUGPName.TabIndex = 0;
            this.lbMUGPName.Text = "選單群組名稱";
            // 
            // txtMUGPName
            // 
            this.txtMUGPName.Location = new System.Drawing.Point(88, 12);
            this.txtMUGPName.Name = "txtMUGPName";
            this.txtMUGPName.Size = new System.Drawing.Size(124, 22);
            this.txtMUGPName.TabIndex = 1;
            // 
            // cbInherit
            // 
            this.cbInherit.FormattingEnabled = true;
            this.cbInherit.Location = new System.Drawing.Point(88, 40);
            this.cbInherit.Name = "cbInherit";
            this.cbInherit.Size = new System.Drawing.Size(124, 20);
            this.cbInherit.TabIndex = 2;
            // 
            // lbInherit
            // 
            this.lbInherit.AutoSize = true;
            this.lbInherit.Location = new System.Drawing.Point(9, 43);
            this.lbInherit.Name = "lbInherit";
            this.lbInherit.Size = new System.Drawing.Size(77, 12);
            this.lbInherit.TabIndex = 3;
            this.lbInherit.Text = "複製選單設定";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(54, 148);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "存檔";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(135, 148);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lbNote
            // 
            this.lbNote.AutoSize = true;
            this.lbNote.Location = new System.Drawing.Point(9, 72);
            this.lbNote.Name = "lbNote";
            this.lbNote.Size = new System.Drawing.Size(29, 12);
            this.lbNote.TabIndex = 6;
            this.lbNote.Text = "備註";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(44, 66);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(168, 76);
            this.txtNote.TabIndex = 7;
            // 
            // SYS_MenuMgt_ADD
            // 
            this.ClientSize = new System.Drawing.Size(224, 183);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.lbNote);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbInherit);
            this.Controls.Add(this.cbInherit);
            this.Controls.Add(this.txtMUGPName);
            this.Controls.Add(this.lbMUGPName);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SYS_MenuMgt_ADD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "選單群組設定";
            this.Load += new System.EventHandler(this.SYS_MenuMgt_ADD_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbMUGPName;
        private System.Windows.Forms.TextBox txtMUGPName;
        private System.Windows.Forms.ComboBox cbInherit;
        private System.Windows.Forms.Label lbInherit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbNote;
        private System.Windows.Forms.TextBox txtNote;
    }
}
