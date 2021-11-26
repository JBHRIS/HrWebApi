namespace ConfigUpdate {
	partial class Form1 {
		/// <summary>
		/// 設計工具所需的變數。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清除任何使用中的資源。
		/// </summary>
		/// <param name="disposing">如果應該公開 Managed 資源則為 true，否則為 false。</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 設計工具產生的程式碼

		/// <summary>
		/// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
		///
		/// </summary>
		private void InitializeComponent() {
			this.label1 = new System.Windows.Forms.Label();
			this.txtSource = new System.Windows.Forms.TextBox();
			this.txtUid = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtPwd = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.bnUpdate = new System.Windows.Forms.Button();
			this.ckSubFolder = new System.Windows.Forms.CheckBox();
			this.ckDelBackup = new System.Windows.Forms.CheckBox();
			this.txtDB = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(22, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "伺服器";
			// 
			// txtSource
			// 
			this.txtSource.Location = new System.Drawing.Point(81, 12);
			this.txtSource.Name = "txtSource";
			this.txtSource.Size = new System.Drawing.Size(179, 22);
			this.txtSource.TabIndex = 0;
			// 
			// txtUid
			// 
			this.txtUid.Location = new System.Drawing.Point(81, 68);
			this.txtUid.Name = "txtUid";
			this.txtUid.Size = new System.Drawing.Size(89, 22);
			this.txtUid.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(22, 73);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 12);
			this.label2.TabIndex = 2;
			this.label2.Text = "登入帳號";
			// 
			// txtPwd
			// 
			this.txtPwd.Location = new System.Drawing.Point(81, 96);
			this.txtPwd.Name = "txtPwd";
			this.txtPwd.Size = new System.Drawing.Size(89, 22);
			this.txtPwd.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(22, 101);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 12);
			this.label3.TabIndex = 4;
			this.label3.Text = "登入密碼";
			// 
			// bnUpdate
			// 
			this.bnUpdate.Location = new System.Drawing.Point(81, 169);
			this.bnUpdate.Name = "bnUpdate";
			this.bnUpdate.Size = new System.Drawing.Size(75, 23);
			this.bnUpdate.TabIndex = 6;
			this.bnUpdate.Text = "更新";
			this.bnUpdate.UseVisualStyleBackColor = true;
			this.bnUpdate.Click += new System.EventHandler(this.bnUpdate_Click);
			// 
			// ckSubFolder
			// 
			this.ckSubFolder.AutoSize = true;
			this.ckSubFolder.Location = new System.Drawing.Point(81, 125);
			this.ckSubFolder.Name = "ckSubFolder";
			this.ckSubFolder.Size = new System.Drawing.Size(108, 16);
			this.ckSubFolder.TabIndex = 4;
			this.ckSubFolder.Text = "一併搜尋子目錄";
			this.ckSubFolder.UseVisualStyleBackColor = true;
			// 
			// ckDelBackup
			// 
			this.ckDelBackup.AutoSize = true;
			this.ckDelBackup.Location = new System.Drawing.Point(81, 147);
			this.ckDelBackup.Name = "ckDelBackup";
			this.ckDelBackup.Size = new System.Drawing.Size(132, 16);
			this.ckDelBackup.TabIndex = 5;
			this.ckDelBackup.Text = "更新完後刪除備份檔";
			this.ckDelBackup.UseVisualStyleBackColor = true;
			// 
			// txtDB
			// 
			this.txtDB.Location = new System.Drawing.Point(81, 40);
			this.txtDB.Name = "txtDB";
			this.txtDB.Size = new System.Drawing.Size(89, 22);
			this.txtDB.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(22, 44);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(41, 12);
			this.label4.TabIndex = 10;
			this.label4.Text = "資料庫";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 210);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtDB);
			this.Controls.Add(this.ckDelBackup);
			this.Controls.Add(this.ckSubFolder);
			this.Controls.Add(this.bnUpdate);
			this.Controls.Add(this.txtPwd);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtUid);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtSource);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "設定檔更新程式";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtSource;
		private System.Windows.Forms.TextBox txtUid;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtPwd;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button bnUpdate;
		private System.Windows.Forms.CheckBox ckSubFolder;
		private System.Windows.Forms.CheckBox ckDelBackup;
		private System.Windows.Forms.TextBox txtDB;
		private System.Windows.Forms.Label label4;
	}
}

