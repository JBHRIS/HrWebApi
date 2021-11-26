namespace ezFlow {
	partial class fmOpenFlow {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmOpenFlow));
			this.tvMain = new System.Windows.Forms.TreeView();
			this.imgList1 = new System.Windows.Forms.ImageList(this.components);
			this.lvMain = new System.Windows.Forms.ListView();
			this.imgList2 = new System.Windows.Forms.ImageList(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.txtSelect = new System.Windows.Forms.TextBox();
			this.bnOpen = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tvMain
			// 
			this.tvMain.ImageIndex = 0;
			this.tvMain.ImageList = this.imgList1;
			this.tvMain.Location = new System.Drawing.Point(0, 0);
			this.tvMain.Name = "tvMain";
			this.tvMain.SelectedImageIndex = 0;
			this.tvMain.Size = new System.Drawing.Size(200, 285);
			this.tvMain.TabIndex = 0;
			this.tvMain.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvMain_AfterLabelEdit);
			this.tvMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvMain_MouseDown);
			// 
			// imgList1
			// 
			this.imgList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList1.ImageStream")));
			this.imgList1.TransparentColor = System.Drawing.Color.White;
			this.imgList1.Images.SetKeyName(0, "folder.bmp");
			this.imgList1.Images.SetKeyName(1, "Openfolder.bmp");
			// 
			// lvMain
			// 
			this.lvMain.LargeImageList = this.imgList2;
			this.lvMain.Location = new System.Drawing.Point(201, 0);
			this.lvMain.MultiSelect = false;
			this.lvMain.Name = "lvMain";
			this.lvMain.Size = new System.Drawing.Size(392, 285);
			this.lvMain.TabIndex = 1;
			this.lvMain.UseCompatibleStateImageBehavior = false;
			this.lvMain.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lvMain_AfterLabelEdit);
			this.lvMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvMain_MouseDown);
			// 
			// imgList2
			// 
			this.imgList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList2.ImageStream")));
			this.imgList2.TransparentColor = System.Drawing.Color.White;
			this.imgList2.Images.SetKeyName(0, "Flow.bmp");
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 298);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 12);
			this.label1.TabIndex = 2;
			this.label1.Text = "選取的流程";
			// 
			// txtSelect
			// 
			this.txtSelect.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.txtSelect.Location = new System.Drawing.Point(80, 293);
			this.txtSelect.Name = "txtSelect";
			this.txtSelect.ReadOnly = true;
			this.txtSelect.Size = new System.Drawing.Size(421, 22);
			this.txtSelect.TabIndex = 3;
			// 
			// bnOpen
			// 
			this.bnOpen.Location = new System.Drawing.Point(507, 291);
			this.bnOpen.Name = "bnOpen";
			this.bnOpen.Size = new System.Drawing.Size(75, 23);
			this.bnOpen.TabIndex = 4;
			this.bnOpen.Text = "開啟";
			this.bnOpen.UseVisualStyleBackColor = true;
			this.bnOpen.Click += new System.EventHandler(this.bnOpen_Click);
			// 
			// fmOpenFlow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(592, 323);
			this.Controls.Add(this.bnOpen);
			this.Controls.Add(this.txtSelect);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lvMain);
			this.Controls.Add(this.tvMain);
			this.MaximizeBox = false;
			this.Name = "fmOpenFlow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "開啟流程";
			this.Load += new System.EventHandler(this.fmOpenFlow_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TreeView tvMain;
		private System.Windows.Forms.ListView lvMain;
		private System.Windows.Forms.ImageList imgList1;
		private System.Windows.Forms.ImageList imgList2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtSelect;
		private System.Windows.Forms.Button bnOpen;
	}
}