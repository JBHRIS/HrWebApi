namespace ezFlow {
	partial class fmLineType {
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
			this.txtLinkText = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cbLinkType = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.bnOK = new System.Windows.Forms.Button();
			this.cbLinkStyle = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtLinkText
			// 
			this.txtLinkText.Location = new System.Drawing.Point(71, 10);
			this.txtLinkText.Name = "txtLinkText";
			this.txtLinkText.Size = new System.Drawing.Size(209, 22);
			this.txtLinkText.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 12);
			this.label1.TabIndex = 1;
			this.label1.Text = "線段說明";
			// 
			// cbLinkType
			// 
			this.cbLinkType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbLinkType.FormattingEnabled = true;
			this.cbLinkType.Items.AddRange(new object[] {
            "藍色－無條件的限制",
            "綠色－有條件的限制",
            "紅色－無符合的條件"});
			this.cbLinkType.Location = new System.Drawing.Point(71, 38);
			this.cbLinkType.Name = "cbLinkType";
			this.cbLinkType.Size = new System.Drawing.Size(209, 20);
			this.cbLinkType.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 12);
			this.label2.TabIndex = 3;
			this.label2.Text = "條件類型";
			// 
			// bnOK
			// 
			this.bnOK.Location = new System.Drawing.Point(71, 91);
			this.bnOK.Name = "bnOK";
			this.bnOK.Size = new System.Drawing.Size(75, 23);
			this.bnOK.TabIndex = 4;
			this.bnOK.Text = "確定";
			this.bnOK.UseVisualStyleBackColor = true;
			this.bnOK.Click += new System.EventHandler(this.bnOK_Click);
			// 
			// cbLinkStyle
			// 
			this.cbLinkStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbLinkStyle.FormattingEnabled = true;
			this.cbLinkStyle.Items.AddRange(new object[] {
            "線段樣式一",
            "線段樣式二",
            "線段樣式三"});
			this.cbLinkStyle.Location = new System.Drawing.Point(71, 65);
			this.cbLinkStyle.Name = "cbLinkStyle";
			this.cbLinkStyle.Size = new System.Drawing.Size(209, 20);
			this.cbLinkStyle.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 69);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 12);
			this.label3.TabIndex = 6;
			this.label3.Text = "線段類型";
			// 
			// fmLineType
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 120);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cbLinkStyle);
			this.Controls.Add(this.bnOK);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cbLinkType);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtLinkText);
			this.MaximizeBox = false;
			this.Name = "fmLineType";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "線段設定";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtLinkText;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbLinkType;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button bnOK;
		private System.Windows.Forms.ComboBox cbLinkStyle;
		private System.Windows.Forms.Label label3;
	}
}