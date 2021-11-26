namespace ezAdmin {
	partial class fmEmpSelector {
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmEmpSelector));
			this.bnOK = new System.Windows.Forms.Button();
			this.tvMain = new System.Windows.Forms.TreeView();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.SuspendLayout();
			// 
			// bnOK
			// 
			this.bnOK.Location = new System.Drawing.Point(205, 345);
			this.bnOK.Name = "bnOK";
			this.bnOK.Size = new System.Drawing.Size(75, 23);
			this.bnOK.TabIndex = 4;
			this.bnOK.Text = "確定";
			this.bnOK.UseVisualStyleBackColor = true;
			this.bnOK.Click += new System.EventHandler(this.bnOK_Click);
			// 
			// tvMain
			// 
			this.tvMain.ImageIndex = 0;
			this.tvMain.ImageList = this.imageList;
			this.tvMain.Location = new System.Drawing.Point(12, 12);
			this.tvMain.Name = "tvMain";
			this.tvMain.SelectedImageIndex = 0;
			this.tvMain.Size = new System.Drawing.Size(268, 327);
			this.tvMain.TabIndex = 3;
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.SystemColors.Control;
			this.imageList.Images.SetKeyName(0, "untitled.bmp");
			this.imageList.Images.SetKeyName(1, "untitled1.bmp");
			this.imageList.Images.SetKeyName(2, "untitled3.bmp");
			// 
			// fmEmpSelector
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 373);
			this.Controls.Add(this.bnOK);
			this.Controls.Add(this.tvMain);
			this.MaximizeBox = false;
			this.Name = "fmEmpSelector";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "成員選取器";
			this.Shown += new System.EventHandler(this.fmRoleSelector_Shown);
			this.Load += new System.EventHandler(this.fmEmpSelector_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button bnOK;
		private System.Windows.Forms.TreeView tvMain;
		private System.Windows.Forms.ImageList imageList;
	}
}