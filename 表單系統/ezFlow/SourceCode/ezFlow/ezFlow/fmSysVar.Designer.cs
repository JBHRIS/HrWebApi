namespace ezFlow {
	partial class fmSysVar {
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
			this.txtUrlRoot = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtMailServer = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.txtSenderName = new System.Windows.Forms.TextBox();
			this.txtSendMail = new System.Windows.Forms.TextBox();
			this.txtMailID = new System.Windows.Forms.TextBox();
			this.txtMailPW = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.txtWebSrvURL = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtUrlRoot
			// 
			this.txtUrlRoot.Location = new System.Drawing.Point(131, 12);
			this.txtUrlRoot.Name = "txtUrlRoot";
			this.txtUrlRoot.Size = new System.Drawing.Size(374, 22);
			this.txtUrlRoot.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(511, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(116, 12);
			this.label1.TabIndex = 1;
			this.label1.Text = "(ezClient 的完整 URL)";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.Color.Blue;
			this.label2.Location = new System.Drawing.Point(72, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 12);
			this.label2.TabIndex = 2;
			this.label2.Text = "網站位址";
			// 
			// txtMailServer
			// 
			this.txtMailServer.Location = new System.Drawing.Point(131, 68);
			this.txtMailServer.Name = "txtMailServer";
			this.txtMailServer.Size = new System.Drawing.Size(187, 22);
			this.txtMailServer.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.ForeColor = System.Drawing.Color.Blue;
			this.label3.Location = new System.Drawing.Point(60, 73);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(65, 12);
			this.label3.TabIndex = 4;
			this.label3.Text = "郵件伺服器";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.ForeColor = System.Drawing.Color.Blue;
			this.label4.Location = new System.Drawing.Point(24, 129);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(101, 12);
			this.label4.TabIndex = 5;
			this.label4.Text = "系統用之電子郵件";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.ForeColor = System.Drawing.Color.Blue;
			this.label5.Location = new System.Drawing.Point(12, 101);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(113, 12);
			this.label5.TabIndex = 6;
			this.label5.Text = "系統用之寄件者名稱";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 157);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(113, 12);
			this.label6.TabIndex = 7;
			this.label6.Text = "郵件伺服器認証帳號";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(12, 185);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(113, 12);
			this.label7.TabIndex = 8;
			this.label7.Text = "郵件伺服器認証密碼";
			// 
			// txtSenderName
			// 
			this.txtSenderName.Location = new System.Drawing.Point(131, 96);
			this.txtSenderName.Name = "txtSenderName";
			this.txtSenderName.Size = new System.Drawing.Size(187, 22);
			this.txtSenderName.TabIndex = 9;
			// 
			// txtSendMail
			// 
			this.txtSendMail.Location = new System.Drawing.Point(131, 124);
			this.txtSendMail.Name = "txtSendMail";
			this.txtSendMail.Size = new System.Drawing.Size(187, 22);
			this.txtSendMail.TabIndex = 10;
			// 
			// txtMailID
			// 
			this.txtMailID.Location = new System.Drawing.Point(131, 152);
			this.txtMailID.Name = "txtMailID";
			this.txtMailID.Size = new System.Drawing.Size(187, 22);
			this.txtMailID.TabIndex = 11;
			// 
			// txtMailPW
			// 
			this.txtMailPW.Location = new System.Drawing.Point(131, 180);
			this.txtMailPW.Name = "txtMailPW";
			this.txtMailPW.PasswordChar = '*';
			this.txtMailPW.Size = new System.Drawing.Size(187, 22);
			this.txtMailPW.TabIndex = 12;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(324, 73);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(249, 12);
			this.label8.TabIndex = 13;
			this.label8.Text = "(強烈建議使用 IP 位址，以縮短 DNS 搜尋時間)";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.ForeColor = System.Drawing.Color.Blue;
			this.label9.Location = new System.Drawing.Point(420, 129);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(101, 12);
			this.label9.TabIndex = 14;
			this.label9.Text = "●藍色為必填欄位";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(420, 157);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(125, 12);
			this.label10.TabIndex = 15;
			this.label10.Text = "●黑色視實際需要填寫";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.ForeColor = System.Drawing.Color.Blue;
			this.label11.Location = new System.Drawing.Point(50, 45);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(75, 12);
			this.label11.TabIndex = 17;
			this.label11.Text = "ezEngine 位址";
			// 
			// txtWebSrvURL
			// 
			this.txtWebSrvURL.Location = new System.Drawing.Point(131, 40);
			this.txtWebSrvURL.Name = "txtWebSrvURL";
			this.txtWebSrvURL.Size = new System.Drawing.Size(374, 22);
			this.txtWebSrvURL.TabIndex = 16;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(511, 45);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(121, 12);
			this.label12.TabIndex = 18;
			this.label12.Text = "(ezEngine 的完整 URL)";
			// 
			// fmSysVar
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(639, 212);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.txtWebSrvURL);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.txtMailPW);
			this.Controls.Add(this.txtMailID);
			this.Controls.Add(this.txtSendMail);
			this.Controls.Add(this.txtSenderName);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtMailServer);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtUrlRoot);
			this.MaximizeBox = false;
			this.Name = "fmSysVar";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "系統參數";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fmSysVar_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtUrlRoot;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtMailServer;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtSenderName;
		private System.Windows.Forms.TextBox txtSendMail;
		private System.Windows.Forms.TextBox txtMailID;
		private System.Windows.Forms.TextBox txtMailPW;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox txtWebSrvURL;
		private System.Windows.Forms.Label label12;
	}
}