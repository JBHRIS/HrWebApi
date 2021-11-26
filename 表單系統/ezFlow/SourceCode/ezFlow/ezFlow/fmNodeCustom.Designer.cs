namespace ezFlow {
	partial class fmNodeCustom {
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
			this.txtRole = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.bnSelect = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.cbCustomEmp = new System.Windows.Forms.ComboBox();
			this.ckUse = new System.Windows.Forms.CheckBox();
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
			this.bnOK.Location = new System.Drawing.Point(95, 96);
			this.bnOK.Name = "bnOK";
			this.bnOK.Size = new System.Drawing.Size(75, 23);
			this.bnOK.TabIndex = 2;
			this.bnOK.Text = "確定";
			this.bnOK.UseVisualStyleBackColor = true;
			this.bnOK.Click += new System.EventHandler(this.bnOK_Click);
			// 
			// txtRole
			// 
			this.txtRole.Location = new System.Drawing.Point(95, 40);
			this.txtRole.Name = "txtRole";
			this.txtRole.ReadOnly = true;
			this.txtRole.Size = new System.Drawing.Size(149, 22);
			this.txtRole.TabIndex = 3;
			this.txtRole.TextChanged += new System.EventHandler(this.txtRole_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 45);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(77, 12);
			this.label2.TabIndex = 5;
			this.label2.Text = "自訂角色名稱";
			// 
			// bnSelect
			// 
			this.bnSelect.Location = new System.Drawing.Point(253, 12);
			this.bnSelect.Name = "bnSelect";
			this.bnSelect.Size = new System.Drawing.Size(75, 50);
			this.bnSelect.TabIndex = 7;
			this.bnSelect.Text = "選取角色";
			this.bnSelect.UseVisualStyleBackColor = true;
			this.bnSelect.Click += new System.EventHandler(this.bnSelect_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 73);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(77, 12);
			this.label3.TabIndex = 9;
			this.label3.Text = "自訂角色成員";
			// 
			// cbCustomEmp
			// 
			this.cbCustomEmp.Enabled = false;
			this.cbCustomEmp.FormattingEnabled = true;
			this.cbCustomEmp.Location = new System.Drawing.Point(95, 68);
			this.cbCustomEmp.Name = "cbCustomEmp";
			this.cbCustomEmp.Size = new System.Drawing.Size(149, 20);
			this.cbCustomEmp.TabIndex = 10;
			// 
			// ckUse
			// 
			this.ckUse.AutoSize = true;
			this.ckUse.Enabled = false;
			this.ckUse.Location = new System.Drawing.Point(253, 73);
			this.ckUse.Name = "ckUse";
			this.ckUse.Size = new System.Drawing.Size(48, 16);
			this.ckUse.TabIndex = 11;
			this.ckUse.Text = "使用";
			this.ckUse.UseVisualStyleBackColor = true;
			this.ckUse.CheckedChanged += new System.EventHandler(this.ckUse_CheckedChanged);
			// 
			// fmNodeCustom
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(340, 126);
			this.Controls.Add(this.ckUse);
			this.Controls.Add(this.cbCustomEmp);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.bnSelect);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtRole);
			this.Controls.Add(this.bnOK);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtApName);
			this.MaximizeBox = false;
			this.Name = "fmNodeCustom";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "內容";
			this.Load += new System.EventHandler(this.fmNodeCustom_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtApName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button bnOK;
		private System.Windows.Forms.TextBox txtRole;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button bnSelect;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbCustomEmp;
		private System.Windows.Forms.CheckBox ckUse;
	}
}