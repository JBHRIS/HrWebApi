namespace ezFlow {
	partial class fmNodeEnd {
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
			this.bnOK = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.ckMailMang = new System.Windows.Forms.CheckBox();
			this.ckMailInit = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// bnOK
			// 
			this.bnOK.Location = new System.Drawing.Point(137, 99);
			this.bnOK.Name = "bnOK";
			this.bnOK.Size = new System.Drawing.Size(75, 23);
			this.bnOK.TabIndex = 2;
			this.bnOK.Text = "確定";
			this.bnOK.UseVisualStyleBackColor = true;
			this.bnOK.Click += new System.EventHandler(this.bnOK_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.ckMailMang);
			this.groupBox1.Controls.Add(this.ckMailInit);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(200, 81);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "郵件服務";
			// 
			// ckMailMang
			// 
			this.ckMailMang.AutoSize = true;
			this.ckMailMang.Location = new System.Drawing.Point(34, 48);
			this.ckMailMang.Name = "ckMailMang";
			this.ckMailMang.Size = new System.Drawing.Size(132, 16);
			this.ckMailMang.TabIndex = 3;
			this.ckMailMang.Text = "郵件通知所有簽核者";
			this.ckMailMang.UseVisualStyleBackColor = true;
			// 
			// ckMailInit
			// 
			this.ckMailInit.AutoSize = true;
			this.ckMailInit.Location = new System.Drawing.Point(34, 26);
			this.ckMailInit.Name = "ckMailInit";
			this.ckMailInit.Size = new System.Drawing.Size(132, 16);
			this.ckMailInit.TabIndex = 2;
			this.ckMailInit.Text = "郵件通知流程起始者";
			this.ckMailInit.UseVisualStyleBackColor = true;
			// 
			// fmNodeEnd
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(225, 129);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.bnOK);
			this.MaximizeBox = false;
			this.Name = "fmNodeEnd";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "內容";
			this.Load += new System.EventHandler(this.fmNodeEnd_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button bnOK;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox ckMailMang;
		private System.Windows.Forms.CheckBox ckMailInit;
	}
}