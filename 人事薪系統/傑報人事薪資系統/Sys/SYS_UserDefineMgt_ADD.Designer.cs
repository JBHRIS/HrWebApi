namespace JBHR.Sys
{
    partial class SYS_UserDefineMgt_ADD
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
            this.txtNote = new System.Windows.Forms.TextBox();
            this.lbNote = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtUDGPName = new System.Windows.Forms.TextBox();
            this.lbUDGPName = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbPRG_NAME = new System.Windows.Forms.Label();
            this.cbxFromList = new System.Windows.Forms.ComboBox();
            this.lbTableLayout = new System.Windows.Forms.Label();
            this.cbxTableLayout = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNote
            // 
            this.txtNote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtNote, 3);
            this.txtNote.Location = new System.Drawing.Point(107, 90);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.tableLayoutPanel1.SetRowSpan(this.txtNote, 3);
            this.txtNote.Size = new System.Drawing.Size(308, 81);
            this.txtNote.TabIndex = 3;
            // 
            // lbNote
            // 
            this.lbNote.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbNote.AutoSize = true;
            this.lbNote.Location = new System.Drawing.Point(72, 95);
            this.lbNote.Name = "lbNote";
            this.lbNote.Size = new System.Drawing.Size(29, 12);
            this.lbNote.TabIndex = 14;
            this.lbNote.Text = "備註";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(211, 177);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(107, 177);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(98, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "存檔";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtUDGPName
            // 
            this.txtUDGPName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUDGPName.Location = new System.Drawing.Point(107, 3);
            this.txtUDGPName.Name = "txtUDGPName";
            this.txtUDGPName.Size = new System.Drawing.Size(98, 22);
            this.txtUDGPName.TabIndex = 0;
            // 
            // lbUDGPName
            // 
            this.lbUDGPName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbUDGPName.AutoSize = true;
            this.lbUDGPName.Location = new System.Drawing.Point(48, 8);
            this.lbUDGPName.Name = "lbUDGPName";
            this.lbUDGPName.Size = new System.Drawing.Size(53, 12);
            this.lbUDGPName.TabIndex = 8;
            this.lbUDGPName.Text = "群組名稱";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.lbPRG_NAME, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtNote, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbxFromList, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtUDGPName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbNote, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbUDGPName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbTableLayout, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.cbxTableLayout, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 1, 6);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(418, 204);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // lbPRG_NAME
            // 
            this.lbPRG_NAME.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbPRG_NAME.AutoSize = true;
            this.lbPRG_NAME.Location = new System.Drawing.Point(48, 37);
            this.lbPRG_NAME.Name = "lbPRG_NAME";
            this.lbPRG_NAME.Size = new System.Drawing.Size(53, 12);
            this.lbPRG_NAME.TabIndex = 8;
            this.lbPRG_NAME.Text = "套用頁面";
            // 
            // cbxFromList
            // 
            this.cbxFromList.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.cbxFromList, 3);
            this.cbxFromList.FormattingEnabled = true;
            this.cbxFromList.Location = new System.Drawing.Point(107, 33);
            this.cbxFromList.Name = "cbxFromList";
            this.cbxFromList.Size = new System.Drawing.Size(308, 20);
            this.cbxFromList.TabIndex = 1;
            this.cbxFromList.SelectionChangeCommitted += new System.EventHandler(this.cbxFromList_SelectionChangeCommitted);
            // 
            // lbTableLayout
            // 
            this.lbTableLayout.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbTableLayout.AutoSize = true;
            this.lbTableLayout.Location = new System.Drawing.Point(6, 66);
            this.lbTableLayout.Name = "lbTableLayout";
            this.lbTableLayout.Size = new System.Drawing.Size(95, 12);
            this.lbTableLayout.TabIndex = 9;
            this.lbTableLayout.Text = "套用TableLayout";
            // 
            // cbxTableLayout
            // 
            this.cbxTableLayout.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.cbxTableLayout, 3);
            this.cbxTableLayout.FormattingEnabled = true;
            this.cbxTableLayout.Location = new System.Drawing.Point(107, 62);
            this.cbxTableLayout.Name = "cbxTableLayout";
            this.cbxTableLayout.Size = new System.Drawing.Size(308, 20);
            this.cbxTableLayout.TabIndex = 2;
            // 
            // SYS_UserDefineMgt_ADD
            // 
            this.ClientSize = new System.Drawing.Size(442, 228);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormSize = JBControls.JBForm.FormSizeType.Custom;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SYS_UserDefineMgt_ADD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "自定欄位群組設定";
            this.Load += new System.EventHandler(this.SYS_UserDefineMgt_ADD_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label lbNote;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtUDGPName;
        private System.Windows.Forms.Label lbUDGPName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbPRG_NAME;
        private System.Windows.Forms.ComboBox cbxFromList;
        private System.Windows.Forms.Label lbTableLayout;
        private System.Windows.Forms.ComboBox cbxTableLayout;
    }
}
