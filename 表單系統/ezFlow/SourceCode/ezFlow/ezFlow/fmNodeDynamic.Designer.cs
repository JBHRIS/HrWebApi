namespace ezFlow {
	partial class fmNodeDynamic {
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
			this.txtApName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.bnOK = new System.Windows.Forms.Button();
			this.txtTableName = new System.Windows.Forms.TextBox();
			this.txtFdRole = new System.Windows.Forms.TextBox();
			this.txtFdEmp = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtApName
			// 
			this.txtApName.Location = new System.Drawing.Point(122, 12);
			this.txtApName.Name = "txtApName";
			this.txtApName.Size = new System.Drawing.Size(149, 22);
			this.txtApName.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(36, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 12);
			this.label1.TabIndex = 1;
			this.label1.Text = "應用程式名稱";
			// 
			// bnOK
			// 
			this.bnOK.Location = new System.Drawing.Point(122, 124);
			this.bnOK.Name = "bnOK";
			this.bnOK.Size = new System.Drawing.Size(75, 23);
			this.bnOK.TabIndex = 2;
			this.bnOK.Text = "確定";
			this.bnOK.UseVisualStyleBackColor = true;
			this.bnOK.Click += new System.EventHandler(this.bnOK_Click);
			// 
			// txtTableName
			// 
			this.txtTableName.Location = new System.Drawing.Point(122, 40);
			this.txtTableName.Name = "txtTableName";
			this.txtTableName.Size = new System.Drawing.Size(149, 22);
			this.txtTableName.TabIndex = 3;
			// 
			// txtFdRole
			// 
			this.txtFdRole.Location = new System.Drawing.Point(122, 68);
			this.txtFdRole.Name = "txtFdRole";
			this.txtFdRole.Size = new System.Drawing.Size(149, 22);
			this.txtFdRole.TabIndex = 4;
			// 
			// txtFdEmp
			// 
			this.txtFdEmp.Location = new System.Drawing.Point(122, 96);
			this.txtFdEmp.Name = "txtFdEmp";
			this.txtFdEmp.Size = new System.Drawing.Size(149, 22);
			this.txtFdEmp.TabIndex = 5;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(24, 45);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(89, 12);
			this.label2.TabIndex = 6;
			this.label2.Text = "動態指定資料表";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 73);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(101, 12);
			this.label3.TabIndex = 7;
			this.label3.Text = "動態指定角色欄位";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 101);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(101, 12);
			this.label4.TabIndex = 8;
			this.label4.Text = "動態指定成員欄位";
			// 
			// fmNodeDynamic
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(285, 158);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtFdEmp);
			this.Controls.Add(this.txtFdRole);
			this.Controls.Add(this.txtTableName);
			this.Controls.Add(this.bnOK);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtApName);
			this.MaximizeBox = false;
			this.Name = "fmNodeDynamic";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "內容";
			this.Load += new System.EventHandler(this.fmNodeDynamic_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtApName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button bnOK;
		private System.Windows.Forms.TextBox txtTableName;
		private System.Windows.Forms.TextBox txtFdRole;
		private System.Windows.Forms.TextBox txtFdEmp;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
	}
}