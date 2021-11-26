namespace ezOrg {
	partial class fmMain {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmMain));
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.pnlMain = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.SystemColors.Control;
			this.imageList.Images.SetKeyName(0, "untitled.bmp");
			this.imageList.Images.SetKeyName(1, "untitled1.bmp");
			this.imageList.Images.SetKeyName(2, "untitled3.bmp");
			// 
			// pnlMain
			// 
			this.pnlMain.BackColor = System.Drawing.Color.AliceBlue;
			this.pnlMain.Location = new System.Drawing.Point(3, 3);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Size = new System.Drawing.Size(1024, 768);
			this.pnlMain.TabIndex = 0;
			this.pnlMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlMain_MouseDown);
			this.pnlMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlMain_MouseMove);
			this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
			// 
			// fmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(792, 573);
			this.Controls.Add(this.pnlMain);
			this.DoubleBuffered = true;
			this.Name = "fmMain";
			this.Text = "企業組織維護";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Shown += new System.EventHandler(this.fmMain_Shown);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fmMain_MouseDown);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.Panel pnlMain;
	}
}