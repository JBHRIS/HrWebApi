namespace ezFlow {
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.bnEnd = new System.Windows.Forms.Button();
			this.imgList = new System.Windows.Forms.ImageList(this.components);
			this.bnService = new System.Windows.Forms.Button();
			this.bnMail = new System.Windows.Forms.Button();
			this.bnMultiStart = new System.Windows.Forms.Button();
			this.bnAgentInit = new System.Windows.Forms.Button();
			this.bnDynamic = new System.Windows.Forms.Button();
			this.bnCustom = new System.Windows.Forms.Button();
			this.bnMultiInit = new System.Windows.Forms.Button();
			this.bnInit = new System.Windows.Forms.Button();
			this.bnMang = new System.Windows.Forms.Button();
			this.bnForm = new System.Windows.Forms.Button();
			this.bnStart = new System.Windows.Forms.Button();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.bnEnd);
			this.panel1.Controls.Add(this.bnService);
			this.panel1.Controls.Add(this.bnMail);
			this.panel1.Controls.Add(this.bnMultiStart);
			this.panel1.Controls.Add(this.bnAgentInit);
			this.panel1.Controls.Add(this.bnDynamic);
			this.panel1.Controls.Add(this.bnCustom);
			this.panel1.Controls.Add(this.bnMultiInit);
			this.panel1.Controls.Add(this.bnInit);
			this.panel1.Controls.Add(this.bnMang);
			this.panel1.Controls.Add(this.bnForm);
			this.panel1.Controls.Add(this.bnStart);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 24);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1016, 70);
			this.panel1.TabIndex = 0;
			// 
			// bnEnd
			// 
			this.bnEnd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.bnEnd.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.bnEnd.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.bnEnd.ImageIndex = 11;
			this.bnEnd.ImageList = this.imgList;
			this.bnEnd.Location = new System.Drawing.Point(930, 3);
			this.bnEnd.Name = "bnEnd";
			this.bnEnd.Size = new System.Drawing.Size(80, 64);
			this.bnEnd.TabIndex = 45;
			this.bnEnd.Tag = "nEnd";
			this.bnEnd.Text = "流程結束";
			this.bnEnd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.bnEnd.UseVisualStyleBackColor = false;
			this.bnEnd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bnNode_MouseDown);
			// 
			// imgList
			// 
			this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
			this.imgList.TransparentColor = System.Drawing.Color.White;
			this.imgList.Images.SetKeyName(0, "1流程開始.bmp");
			this.imgList.Images.SetKeyName(1, "2填寫表單.bmp");
			this.imgList.Images.SetKeyName(2, "3主管審核.bmp");
			this.imgList.Images.SetKeyName(3, "4流程起始者.bmp");
			this.imgList.Images.SetKeyName(4, "5會簽起始者.bmp");
			this.imgList.Images.SetKeyName(5, "6自定簽核者.bmp");
			this.imgList.Images.SetKeyName(6, "7動態簽核者.bmp");
			this.imgList.Images.SetKeyName(7, "流程起始者.bmp");
			this.imgList.Images.SetKeyName(8, "8會簽流程.bmp");
			this.imgList.Images.SetKeyName(9, "10郵件通知.bmp");
			this.imgList.Images.SetKeyName(10, "11服務程式.bmp");
			this.imgList.Images.SetKeyName(11, "12流程結束.bmp");
			// 
			// bnService
			// 
			this.bnService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.bnService.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.bnService.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.bnService.ImageIndex = 10;
			this.bnService.ImageList = this.imgList;
			this.bnService.Location = new System.Drawing.Point(846, 3);
			this.bnService.Name = "bnService";
			this.bnService.Size = new System.Drawing.Size(80, 64);
			this.bnService.TabIndex = 44;
			this.bnService.Tag = "nService";
			this.bnService.Text = "服務程式";
			this.bnService.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.bnService.UseVisualStyleBackColor = false;
			this.bnService.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bnNode_MouseDown);
			// 
			// bnMail
			// 
			this.bnMail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.bnMail.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.bnMail.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.bnMail.ImageIndex = 9;
			this.bnMail.ImageList = this.imgList;
			this.bnMail.Location = new System.Drawing.Point(762, 3);
			this.bnMail.Name = "bnMail";
			this.bnMail.Size = new System.Drawing.Size(80, 64);
			this.bnMail.TabIndex = 43;
			this.bnMail.Tag = "nMail";
			this.bnMail.Text = "郵件通知";
			this.bnMail.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.bnMail.UseVisualStyleBackColor = false;
			this.bnMail.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bnNode_MouseDown);
			// 
			// bnMultiStart
			// 
			this.bnMultiStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.bnMultiStart.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.bnMultiStart.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.bnMultiStart.ImageIndex = 8;
			this.bnMultiStart.ImageList = this.imgList;
			this.bnMultiStart.Location = new System.Drawing.Point(594, 3);
			this.bnMultiStart.Name = "bnMultiStart";
			this.bnMultiStart.Size = new System.Drawing.Size(80, 64);
			this.bnMultiStart.TabIndex = 42;
			this.bnMultiStart.Tag = "nMultiStart";
			this.bnMultiStart.Text = "會簽流程";
			this.bnMultiStart.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.bnMultiStart.UseVisualStyleBackColor = false;
			this.bnMultiStart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bnNode_MouseDown);
			// 
			// bnAgentInit
			// 
			this.bnAgentInit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.bnAgentInit.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.bnAgentInit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.bnAgentInit.ImageIndex = 7;
			this.bnAgentInit.ImageList = this.imgList;
			this.bnAgentInit.Location = new System.Drawing.Point(510, 3);
			this.bnAgentInit.Name = "bnAgentInit";
			this.bnAgentInit.Size = new System.Drawing.Size(80, 64);
			this.bnAgentInit.TabIndex = 41;
			this.bnAgentInit.Tag = "nAgentInit";
			this.bnAgentInit.Text = "代理起始者";
			this.bnAgentInit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.bnAgentInit.UseVisualStyleBackColor = false;
			this.bnAgentInit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bnNode_MouseDown);
			// 
			// bnDynamic
			// 
			this.bnDynamic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.bnDynamic.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.bnDynamic.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.bnDynamic.ImageIndex = 6;
			this.bnDynamic.ImageList = this.imgList;
			this.bnDynamic.Location = new System.Drawing.Point(426, 3);
			this.bnDynamic.Name = "bnDynamic";
			this.bnDynamic.Size = new System.Drawing.Size(80, 64);
			this.bnDynamic.TabIndex = 40;
			this.bnDynamic.Tag = "nDynamic";
			this.bnDynamic.Text = "動態成員";
			this.bnDynamic.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.bnDynamic.UseVisualStyleBackColor = false;
			this.bnDynamic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bnNode_MouseDown);
			// 
			// bnCustom
			// 
			this.bnCustom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.bnCustom.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.bnCustom.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.bnCustom.ImageIndex = 5;
			this.bnCustom.ImageList = this.imgList;
			this.bnCustom.Location = new System.Drawing.Point(342, 3);
			this.bnCustom.Name = "bnCustom";
			this.bnCustom.Size = new System.Drawing.Size(80, 64);
			this.bnCustom.TabIndex = 39;
			this.bnCustom.Tag = "nCustom";
			this.bnCustom.Text = "自訂成員";
			this.bnCustom.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.bnCustom.UseVisualStyleBackColor = false;
			this.bnCustom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bnNode_MouseDown);
			// 
			// bnMultiInit
			// 
			this.bnMultiInit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.bnMultiInit.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.bnMultiInit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.bnMultiInit.ImageIndex = 4;
			this.bnMultiInit.ImageList = this.imgList;
			this.bnMultiInit.Location = new System.Drawing.Point(678, 3);
			this.bnMultiInit.Name = "bnMultiInit";
			this.bnMultiInit.Size = new System.Drawing.Size(80, 64);
			this.bnMultiInit.TabIndex = 38;
			this.bnMultiInit.Tag = "nMultiInit";
			this.bnMultiInit.Text = "會簽起始者";
			this.bnMultiInit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.bnMultiInit.UseVisualStyleBackColor = false;
			this.bnMultiInit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bnNode_MouseDown);
			// 
			// bnInit
			// 
			this.bnInit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.bnInit.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.bnInit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.bnInit.ImageIndex = 3;
			this.bnInit.ImageList = this.imgList;
			this.bnInit.Location = new System.Drawing.Point(258, 3);
			this.bnInit.Name = "bnInit";
			this.bnInit.Size = new System.Drawing.Size(80, 64);
			this.bnInit.TabIndex = 37;
			this.bnInit.Tag = "nInit";
			this.bnInit.Text = "流程起始者";
			this.bnInit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.bnInit.UseVisualStyleBackColor = false;
			this.bnInit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bnNode_MouseDown);
			// 
			// bnMang
			// 
			this.bnMang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.bnMang.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.bnMang.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.bnMang.ImageIndex = 2;
			this.bnMang.ImageList = this.imgList;
			this.bnMang.Location = new System.Drawing.Point(174, 3);
			this.bnMang.Name = "bnMang";
			this.bnMang.Size = new System.Drawing.Size(80, 64);
			this.bnMang.TabIndex = 36;
			this.bnMang.Tag = "nMang";
			this.bnMang.Text = "主管審核";
			this.bnMang.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.bnMang.UseVisualStyleBackColor = false;
			this.bnMang.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bnNode_MouseDown);
			// 
			// bnForm
			// 
			this.bnForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.bnForm.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.bnForm.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.bnForm.ImageIndex = 1;
			this.bnForm.ImageList = this.imgList;
			this.bnForm.Location = new System.Drawing.Point(90, 3);
			this.bnForm.Name = "bnForm";
			this.bnForm.Size = new System.Drawing.Size(80, 64);
			this.bnForm.TabIndex = 35;
			this.bnForm.Tag = "nForm";
			this.bnForm.Text = "表單填寫";
			this.bnForm.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.bnForm.UseVisualStyleBackColor = false;
			this.bnForm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bnNode_MouseDown);
			// 
			// bnStart
			// 
			this.bnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.bnStart.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.bnStart.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.bnStart.ImageIndex = 0;
			this.bnStart.ImageList = this.imgList;
			this.bnStart.Location = new System.Drawing.Point(6, 3);
			this.bnStart.Name = "bnStart";
			this.bnStart.Size = new System.Drawing.Size(80, 64);
			this.bnStart.TabIndex = 34;
			this.bnStart.Tag = "nStart";
			this.bnStart.Text = "流程開始";
			this.bnStart.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.bnStart.UseVisualStyleBackColor = false;
			this.bnStart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bnNode_MouseDown);
			// 
			// tabControl
			// 
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(0, 94);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(1016, 647);
			this.tabControl.TabIndex = 1;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1016, 24);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem9,
            this.toolStripSeparator1,
            this.toolStripMenuItem3});
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(55, 20);
			this.toolStripMenuItem1.Text = "檔案(&F)";
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem2.Image")));
			this.toolStripMenuItem2.ImageTransparentColor = System.Drawing.Color.White;
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
			this.toolStripMenuItem2.Text = "開啟流程";
			this.toolStripMenuItem2.Click += new System.EventHandler(this.mnuOpen_Click);
			// 
			// toolStripMenuItem9
			// 
			this.toolStripMenuItem9.Name = "toolStripMenuItem9";
			this.toolStripMenuItem9.Size = new System.Drawing.Size(152, 22);
			this.toolStripMenuItem9.Text = "設定系統參數";
			this.toolStripMenuItem9.Click += new System.EventHandler(this.mnuSysVar_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem3.Image")));
			this.toolStripMenuItem3.ImageTransparentColor = System.Drawing.Color.White;
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(152, 22);
			this.toolStripMenuItem3.Text = "關閉流程";
			this.toolStripMenuItem3.Click += new System.EventHandler(this.mnuClose_Click);
			// 
			// fmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1016, 741);
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.menuStrip1);
			this.DoubleBuffered = true;
			this.Name = "fmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "流程編輯器 Ver 3.5";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.fmMain_Load);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fmMain_FormClosing);
			this.panel1.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.ImageList imgList;
		private System.Windows.Forms.Button bnEnd;
		private System.Windows.Forms.Button bnService;
		private System.Windows.Forms.Button bnMail;
		private System.Windows.Forms.Button bnMultiStart;
		private System.Windows.Forms.Button bnAgentInit;
		private System.Windows.Forms.Button bnDynamic;
		private System.Windows.Forms.Button bnCustom;
		private System.Windows.Forms.Button bnMultiInit;
		private System.Windows.Forms.Button bnInit;
		private System.Windows.Forms.Button bnMang;
		private System.Windows.Forms.Button bnForm;
		private System.Windows.Forms.Button bnStart;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
	}
}

