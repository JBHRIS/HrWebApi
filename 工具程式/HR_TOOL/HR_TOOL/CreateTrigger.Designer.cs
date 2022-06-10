namespace HR_TOOL
{
    partial class CreateTrigger
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
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
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.bnCreate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDB = new System.Windows.Forms.TextBox();
            this.ckDelete = new System.Windows.Forms.CheckBox();
            this.ckUpdate = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDS = new System.Windows.Forms.TextBox();
            this.bnDeleteAll = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.progressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.StatusMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bnCreate
            // 
            this.bnCreate.Location = new System.Drawing.Point(146, 75);
            this.bnCreate.Name = "bnCreate";
            this.bnCreate.Size = new System.Drawing.Size(75, 23);
            this.bnCreate.TabIndex = 0;
            this.bnCreate.Text = "開始建置";
            this.bnCreate.UseVisualStyleBackColor = true;
            this.bnCreate.Click += new System.EventHandler(this.bnCreate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(231, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "資料庫";
            this.label1.Visible = false;
            // 
            // txtDB
            // 
            this.txtDB.Location = new System.Drawing.Point(272, 35);
            this.txtDB.Name = "txtDB";
            this.txtDB.ReadOnly = true;
            this.txtDB.Size = new System.Drawing.Size(100, 22);
            this.txtDB.TabIndex = 3;
            this.txtDB.Visible = false;
            // 
            // ckDelete
            // 
            this.ckDelete.AutoSize = true;
            this.ckDelete.Checked = true;
            this.ckDelete.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckDelete.Location = new System.Drawing.Point(90, 26);
            this.ckDelete.Name = "ckDelete";
            this.ckDelete.Size = new System.Drawing.Size(94, 16);
            this.ckDelete.TabIndex = 4;
            this.ckDelete.Text = "Trigger_Delete";
            this.ckDelete.UseVisualStyleBackColor = true;
            // 
            // ckUpdate
            // 
            this.ckUpdate.AutoSize = true;
            this.ckUpdate.Checked = true;
            this.ckUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckUpdate.Location = new System.Drawing.Point(90, 48);
            this.ckUpdate.Name = "ckUpdate";
            this.ckUpdate.Size = new System.Drawing.Size(98, 16);
            this.ckUpdate.TabIndex = 4;
            this.ckUpdate.Text = "Trigger_Update";
            this.ckUpdate.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(231, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "伺服器";
            this.label2.Visible = false;
            // 
            // txtDS
            // 
            this.txtDS.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtDS.Location = new System.Drawing.Point(272, 4);
            this.txtDS.Name = "txtDS";
            this.txtDS.ReadOnly = true;
            this.txtDS.Size = new System.Drawing.Size(100, 22);
            this.txtDS.TabIndex = 3;
            this.txtDS.Visible = false;
            // 
            // bnDeleteAll
            // 
            this.bnDeleteAll.Location = new System.Drawing.Point(55, 75);
            this.bnDeleteAll.Name = "bnDeleteAll";
            this.bnDeleteAll.Size = new System.Drawing.Size(75, 23);
            this.bnDeleteAll.TabIndex = 0;
            this.bnDeleteAll.Text = "執行刪除";
            this.bnDeleteAll.UseVisualStyleBackColor = true;
            this.bnDeleteAll.Click += new System.EventHandler(this.bnDeleteAll_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar1,
            this.StatusMsg});
            this.statusStrip1.Location = new System.Drawing.Point(0, 119);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(284, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // progressBar1
            // 
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // StatusMsg
            // 
            this.StatusMsg.Name = "StatusMsg";
            this.StatusMsg.Size = new System.Drawing.Size(16, 17);
            this.StatusMsg.Text = "...";
            // 
            // CreateTrigger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 141);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ckUpdate);
            this.Controls.Add(this.ckDelete);
            this.Controls.Add(this.txtDS);
            this.Controls.Add(this.txtDB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bnDeleteAll);
            this.Controls.Add(this.bnCreate);
            this.Name = "CreateTrigger";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreateTrigger";
            this.Load += new System.EventHandler(this.CreateTrigger_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bnCreate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDB;
        private System.Windows.Forms.CheckBox ckDelete;
        private System.Windows.Forms.CheckBox ckUpdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDS;
        private System.Windows.Forms.Button bnDeleteAll;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar progressBar1;
        private System.Windows.Forms.ToolStripStatusLabel StatusMsg;
    }
}

