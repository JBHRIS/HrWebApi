namespace ezFlow {
	partial class fmNodeInit {
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
			this.SuspendLayout();
			// 
			// txtApName
			// 
			this.txtApName.Location = new System.Drawing.Point(95, 12);
			this.txtApName.Name = "txtApName";
			this.txtApName.Size = new System.Drawing.Size(149, 22);
			this.txtApName.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 12);
			this.label1.TabIndex = 1;
			this.label1.Text = "應用程式名稱";
			// 
			// bnOK
			// 
			this.bnOK.Location = new System.Drawing.Point(95, 40);
			this.bnOK.Name = "bnOK";
			this.bnOK.Size = new System.Drawing.Size(75, 23);
			this.bnOK.TabIndex = 2;
			this.bnOK.Text = "確定";
			this.bnOK.UseVisualStyleBackColor = true;
			this.bnOK.Click += new System.EventHandler(this.bnOK_Click);
			// 
			// fmNodeInit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(260, 72);
			this.Controls.Add(this.bnOK);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtApName);
			this.MaximizeBox = false;
			this.Name = "fmNodeInit";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "內容";
			this.Load += new System.EventHandler(this.fmNodeInit_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtApName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button bnOK;
	}
}