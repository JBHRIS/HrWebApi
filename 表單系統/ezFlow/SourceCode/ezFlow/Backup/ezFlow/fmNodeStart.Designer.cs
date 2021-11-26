namespace ezFlow {
	partial class fmNodeStart {
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
			this.txtVirtualPath = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtViewAp = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtTableName = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.ckAuto = new System.Windows.Forms.CheckBox();
			this.bnOK = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtVirtualPath
			// 
			this.txtVirtualPath.Location = new System.Drawing.Point(119, 8);
			this.txtVirtualPath.Name = "txtVirtualPath";
			this.txtVirtualPath.Size = new System.Drawing.Size(187, 22);
			this.txtVirtualPath.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(48, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 12);
			this.label1.TabIndex = 1;
			this.label1.Text = "程式資料夾";
			// 
			// txtViewAp
			// 
			this.txtViewAp.Location = new System.Drawing.Point(119, 64);
			this.txtViewAp.Name = "txtViewAp";
			this.txtViewAp.Size = new System.Drawing.Size(187, 22);
			this.txtViewAp.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 69);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(101, 12);
			this.label2.TabIndex = 3;
			this.label2.Text = "資料檢視應用程式";
			// 
			// txtTableName
			// 
			this.txtTableName.Location = new System.Drawing.Point(119, 36);
			this.txtTableName.Name = "txtTableName";
			this.txtTableName.Size = new System.Drawing.Size(187, 22);
			this.txtTableName.TabIndex = 10;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(48, 41);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(65, 12);
			this.label5.TabIndex = 9;
			this.label5.Text = "流程資料表";
			// 
			// ckAuto
			// 
			this.ckAuto.AutoSize = true;
			this.ckAuto.Location = new System.Drawing.Point(119, 92);
			this.ckAuto.Name = "ckAuto";
			this.ckAuto.Size = new System.Drawing.Size(96, 16);
			this.ckAuto.TabIndex = 5;
			this.ckAuto.Text = "自動啟動流程";
			this.ckAuto.UseVisualStyleBackColor = true;
			// 
			// bnOK
			// 
			this.bnOK.Location = new System.Drawing.Point(231, 115);
			this.bnOK.Name = "bnOK";
			this.bnOK.Size = new System.Drawing.Size(75, 23);
			this.bnOK.TabIndex = 5;
			this.bnOK.Text = "確定";
			this.bnOK.UseVisualStyleBackColor = true;
			this.bnOK.Click += new System.EventHandler(this.bnOK_Click);
			// 
			// fmNodeStart
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(320, 151);
			this.Controls.Add(this.txtTableName);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.ckAuto);
			this.Controls.Add(this.bnOK);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtViewAp);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtVirtualPath);
			this.MaximizeBox = false;
			this.Name = "fmNodeStart";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "內容";
			this.Load += new System.EventHandler(this.fmNodeStart_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtVirtualPath;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtViewAp;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox ckAuto;
		private System.Windows.Forms.TextBox txtTableName;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button bnOK;
	}
}