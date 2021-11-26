namespace ezOrg {
	partial class fmEmp {
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
			this.txtID = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.txtPW = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.bnOK = new System.Windows.Forms.Button();
			this.lbMsg = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtLogin = new System.Windows.Forms.TextBox();
			this.cbSex = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// txtID
			// 
			this.txtID.Location = new System.Drawing.Point(80, 12);
			this.txtID.Name = "txtID";
			this.txtID.Size = new System.Drawing.Size(100, 22);
			this.txtID.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(45, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 12);
			this.label1.TabIndex = 1;
			this.label1.Text = "工號";
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(248, 12);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(100, 22);
			this.txtName.TabIndex = 2;
			// 
			// txtPW
			// 
			this.txtPW.Location = new System.Drawing.Point(248, 66);
			this.txtPW.Name = "txtPW";
			this.txtPW.Size = new System.Drawing.Size(100, 22);
			this.txtPW.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(213, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 12);
			this.label2.TabIndex = 4;
			this.label2.Text = "姓名";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(189, 71);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 12);
			this.label3.TabIndex = 5;
			this.label3.Text = "登入密碼";
			// 
			// bnOK
			// 
			this.bnOK.Location = new System.Drawing.Point(273, 122);
			this.bnOK.Name = "bnOK";
			this.bnOK.Size = new System.Drawing.Size(75, 23);
			this.bnOK.TabIndex = 6;
			this.bnOK.Text = "儲存";
			this.bnOK.UseVisualStyleBackColor = true;
			this.bnOK.Click += new System.EventHandler(this.bnOK_Click);
			// 
			// lbMsg
			// 
			this.lbMsg.AutoSize = true;
			this.lbMsg.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.lbMsg.ForeColor = System.Drawing.Color.Black;
			this.lbMsg.Location = new System.Drawing.Point(21, 133);
			this.lbMsg.Name = "lbMsg";
			this.lbMsg.Size = new System.Drawing.Size(0, 12);
			this.lbMsg.TabIndex = 7;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(21, 71);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(53, 12);
			this.label4.TabIndex = 9;
			this.label4.Text = "登入帳號";
			// 
			// txtLogin
			// 
			this.txtLogin.Location = new System.Drawing.Point(80, 66);
			this.txtLogin.Name = "txtLogin";
			this.txtLogin.Size = new System.Drawing.Size(100, 22);
			this.txtLogin.TabIndex = 8;
			// 
			// cbSex
			// 
			this.cbSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSex.FormattingEnabled = true;
			this.cbSex.Items.AddRange(new object[] {
            "男",
            "女"});
			this.cbSex.Location = new System.Drawing.Point(80, 40);
			this.cbSex.Name = "cbSex";
			this.cbSex.Size = new System.Drawing.Size(48, 20);
			this.cbSex.TabIndex = 10;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(45, 44);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(29, 12);
			this.label5.TabIndex = 11;
			this.label5.Text = "性別";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(21, 99);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(53, 12);
			this.label6.TabIndex = 13;
			this.label6.Text = "電子郵件";
			// 
			// txtEmail
			// 
			this.txtEmail.Location = new System.Drawing.Point(80, 94);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(268, 22);
			this.txtEmail.TabIndex = 12;
			// 
			// fmEmp
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(372, 157);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtEmail);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.cbSex);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtLogin);
			this.Controls.Add(this.lbMsg);
			this.Controls.Add(this.bnOK);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtPW);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtID);
			this.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.MaximizeBox = false;
			this.Name = "fmEmp";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "員工編輯";
			this.Shown += new System.EventHandler(this.fmEmp_Shown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtID;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.TextBox txtPW;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button bnOK;
		private System.Windows.Forms.Label lbMsg;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtLogin;
		private System.Windows.Forms.ComboBox cbSex;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtEmail;
	}
}