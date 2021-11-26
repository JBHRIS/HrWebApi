namespace JBHR.Sys
{
    partial class SYS_UserDefineMgt_ADD_C
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
            this.txtCompName = new System.Windows.Forms.TextBox();
            this.lbCompName = new System.Windows.Forms.Label();
            this.lbMaster = new System.Windows.Forms.Label();
            this.cbxMaster = new System.Windows.Forms.ComboBox();
            this.txtCompID = new System.Windows.Forms.TextBox();
            this.lbCompID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(140, 94);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(59, 94);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "存檔";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtCompName
            // 
            this.txtCompName.Enabled = false;
            this.txtCompName.Location = new System.Drawing.Point(91, 40);
            this.txtCompName.Name = "txtCompName";
            this.txtCompName.Size = new System.Drawing.Size(124, 22);
            this.txtCompName.TabIndex = 1;
            // 
            // lbCompName
            // 
            this.lbCompName.AutoSize = true;
            this.lbCompName.Location = new System.Drawing.Point(12, 43);
            this.lbCompName.Name = "lbCompName";
            this.lbCompName.Size = new System.Drawing.Size(53, 12);
            this.lbCompName.TabIndex = 16;
            this.lbCompName.Text = "公司名稱";
            // 
            // lbMaster
            // 
            this.lbMaster.AutoSize = true;
            this.lbMaster.Location = new System.Drawing.Point(12, 71);
            this.lbMaster.Name = "lbMaster";
            this.lbMaster.Size = new System.Drawing.Size(77, 12);
            this.lbMaster.TabIndex = 15;
            this.lbMaster.Text = "自定欄位主檔";
            // 
            // cbxMaster
            // 
            this.cbxMaster.FormattingEnabled = true;
            this.cbxMaster.Location = new System.Drawing.Point(91, 68);
            this.cbxMaster.Name = "cbxMaster";
            this.cbxMaster.Size = new System.Drawing.Size(124, 20);
            this.cbxMaster.TabIndex = 2;
            // 
            // txtCompID
            // 
            this.txtCompID.Enabled = false;
            this.txtCompID.Location = new System.Drawing.Point(91, 12);
            this.txtCompID.Name = "txtCompID";
            this.txtCompID.Size = new System.Drawing.Size(124, 22);
            this.txtCompID.TabIndex = 0;
            // 
            // lbCompID
            // 
            this.lbCompID.AutoSize = true;
            this.lbCompID.Location = new System.Drawing.Point(12, 15);
            this.lbCompID.Name = "lbCompID";
            this.lbCompID.Size = new System.Drawing.Size(53, 12);
            this.lbCompID.TabIndex = 12;
            this.lbCompID.Text = "公司代碼";
            // 
            // SYS_UserDefineMgt_ADD_C
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 129);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtCompName);
            this.Controls.Add(this.lbCompName);
            this.Controls.Add(this.lbMaster);
            this.Controls.Add(this.cbxMaster);
            this.Controls.Add(this.txtCompID);
            this.Controls.Add(this.lbCompID);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SYS_UserDefineMgt_ADD_C";
            this.Text = "公司對應自定義欄位主檔設定";
            this.Load += new System.EventHandler(this.SYS_UserDefineMgt_ADD_C_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtCompName;
        private System.Windows.Forms.Label lbCompName;
        private System.Windows.Forms.Label lbMaster;
        private System.Windows.Forms.ComboBox cbxMaster;
        private System.Windows.Forms.TextBox txtCompID;
        private System.Windows.Forms.Label lbCompID;
    }
}