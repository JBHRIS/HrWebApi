namespace ezSendMail {
	partial class Form1 {
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMaxCount = new System.Windows.Forms.NumericUpDown();
            this.txtSpanTime = new System.Windows.Forms.NumericUpDown();
            this.txtTrigger = new System.Windows.Forms.NumericUpDown();
            this.bnSave = new System.Windows.Forms.Button();
            this.ckAutoFix = new System.Windows.Forms.CheckBox();
            this.txtToAddress = new System.Windows.Forms.TextBox();
            this.ckMailCustom = new System.Windows.Forms.CheckBox();
            this.ckMailMang = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bnRun = new System.Windows.Forms.Button();
            this.lbNextRunTime = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbRunTime = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblEnableTest = new System.Windows.Forms.Label();
            this.lblTestAcc = new System.Windows.Forms.Label();
            this.lblDisableMail = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.txtMaxCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.txtSpanTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.txtTrigger)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMaxCount);
            this.groupBox1.Controls.Add(this.txtSpanTime);
            this.groupBox1.Controls.Add(this.txtTrigger);
            this.groupBox1.Controls.Add(this.bnSave);
            this.groupBox1.Controls.Add(this.ckAutoFix);
            this.groupBox1.Controls.Add(this.txtToAddress);
            this.groupBox1.Controls.Add(this.ckMailCustom);
            this.groupBox1.Controls.Add(this.ckMailMang);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13 , 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(464 , 184);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "服務參數";
            // 
            // txtMaxCount
            // 
            this.txtMaxCount.Location = new System.Drawing.Point(162 , 78);
            this.txtMaxCount.Name = "txtMaxCount";
            this.txtMaxCount.Size = new System.Drawing.Size(45 , 22);
            this.txtMaxCount.TabIndex = 39;
            // 
            // txtSpanTime
            // 
            this.txtSpanTime.Location = new System.Drawing.Point(162 , 50);
            this.txtSpanTime.Name = "txtSpanTime";
            this.txtSpanTime.Size = new System.Drawing.Size(45 , 22);
            this.txtSpanTime.TabIndex = 38;
            // 
            // txtTrigger
            // 
            this.txtTrigger.Location = new System.Drawing.Point(162 , 22);
            this.txtTrigger.Name = "txtTrigger";
            this.txtTrigger.Size = new System.Drawing.Size(45 , 22);
            this.txtTrigger.TabIndex = 37;
            // 
            // bnSave
            // 
            this.bnSave.Location = new System.Drawing.Point(295 , 27);
            this.bnSave.Name = "bnSave";
            this.bnSave.Size = new System.Drawing.Size(150 , 68);
            this.bnSave.TabIndex = 36;
            this.bnSave.Text = "立即套用參數設定";
            this.bnSave.UseVisualStyleBackColor = true;
            this.bnSave.Click += new System.EventHandler(this.bnSave_Click);
            // 
            // ckAutoFix
            // 
            this.ckAutoFix.AutoSize = true;
            this.ckAutoFix.Checked = true;
            this.ckAutoFix.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckAutoFix.Location = new System.Drawing.Point(53 , 106);
            this.ckAutoFix.Name = "ckAutoFix";
            this.ckAutoFix.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ckAutoFix.Size = new System.Drawing.Size(120 , 16);
            this.ckAutoFix.TabIndex = 35;
            this.ckAutoFix.Text = "自動修復卡單問題";
            this.ckAutoFix.UseVisualStyleBackColor = true;
            // 
            // txtToAddress
            // 
            this.txtToAddress.Location = new System.Drawing.Point(202 , 147);
            this.txtToAddress.Name = "txtToAddress";
            this.txtToAddress.Size = new System.Drawing.Size(243 , 22);
            this.txtToAddress.TabIndex = 34;
            // 
            // ckMailCustom
            // 
            this.ckMailCustom.AutoSize = true;
            this.ckMailCustom.Checked = true;
            this.ckMailCustom.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckMailCustom.Location = new System.Drawing.Point(77 , 150);
            this.ckMailCustom.Name = "ckMailCustom";
            this.ckMailCustom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ckMailCustom.Size = new System.Drawing.Size(96 , 16);
            this.ckMailCustom.TabIndex = 33;
            this.ckMailCustom.Text = "發現問題回報";
            this.ckMailCustom.UseVisualStyleBackColor = true;
            // 
            // ckMailMang
            // 
            this.ckMailMang.AutoSize = true;
            this.ckMailMang.Checked = true;
            this.ckMailMang.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckMailMang.Location = new System.Drawing.Point(29 , 128);
            this.ckMailMang.Name = "ckMailMang";
            this.ckMailMang.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ckMailMang.Size = new System.Drawing.Size(144 , 16);
            this.ckMailMang.TabIndex = 32;
            this.ckMailMang.Text = "超過激催次數通知主管";
            this.ckMailMang.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(213 , 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73 , 12);
            this.label5.TabIndex = 31;
            this.label5.Text = "(單位：次數)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(78 , 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77 , 12);
            this.label6.TabIndex = 29;
            this.label6.Text = "最大激催次數";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(213 , 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73 , 12);
            this.label4.TabIndex = 28;
            this.label4.Text = "(單位：小時)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78 , 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77 , 12);
            this.label3.TabIndex = 26;
            this.label3.Text = "激催郵件間隔";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213 , 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73 , 12);
            this.label2.TabIndex = 25;
            this.label2.Text = "(單位：分鐘)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78 , 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77 , 12);
            this.label1.TabIndex = 23;
            this.label1.Text = "觸發服務週期";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bnRun);
            this.groupBox2.Controls.Add(this.lbNextRunTime);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.lbRunTime);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(13 , 202);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(464 , 66);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "服務排程";
            // 
            // bnRun
            // 
            this.bnRun.Location = new System.Drawing.Point(295 , 22);
            this.bnRun.Name = "bnRun";
            this.bnRun.Size = new System.Drawing.Size(150 , 30);
            this.bnRun.TabIndex = 4;
            this.bnRun.Text = "立即執行服務";
            this.bnRun.UseVisualStyleBackColor = true;
            this.bnRun.Click += new System.EventHandler(this.bnRun_Click);
            // 
            // lbNextRunTime
            // 
            this.lbNextRunTime.AutoSize = true;
            this.lbNextRunTime.Location = new System.Drawing.Point(112 , 40);
            this.lbNextRunTime.Name = "lbNextRunTime";
            this.lbNextRunTime.Size = new System.Drawing.Size(0 , 12);
            this.lbNextRunTime.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17 , 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89 , 12);
            this.label10.TabIndex = 2;
            this.label10.Text = "下次預計時間：";
            // 
            // lbRunTime
            // 
            this.lbRunTime.AutoSize = true;
            this.lbRunTime.Location = new System.Drawing.Point(112 , 22);
            this.lbRunTime.Name = "lbRunTime";
            this.lbRunTime.Size = new System.Drawing.Size(0 , 12);
            this.lbRunTime.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17 , 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89 , 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "最近執行時間：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("新細明體" , 9F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ((byte) (136)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(12 , 393);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70 , 12);
            this.label11.TabIndex = 25;
            this.label11.Text = "服務狀態：";
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("新細明體" , 9F , System.Drawing.FontStyle.Bold , System.Drawing.GraphicsUnit.Point , ((byte) (136)));
            this.lbStatus.ForeColor = System.Drawing.Color.Black;
            this.lbStatus.Location = new System.Drawing.Point(80 , 393);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(83 , 12);
            this.lbStatus.TabIndex = 26;
            this.lbStatus.Text = "服務已停止…";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(308 , 388);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150 , 23);
            this.button1.TabIndex = 27;
            this.button1.Text = "資料庫升級";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.lblDisableMail);
            this.groupBox3.Controls.Add(this.lblTestAcc);
            this.groupBox3.Controls.Add(this.lblEnableTest);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Location = new System.Drawing.Point(14 , 274);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(463 , 108);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "程式設定";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(294 , 35);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150 , 41);
            this.button2.TabIndex = 0;
            this.button2.Text = "測試發信";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16 , 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65 , 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "啟用測試：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16 , 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65 , 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "測試帳號：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16 , 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65 , 12);
            this.label12.TabIndex = 1;
            this.label12.Text = "停用寄信：";
            // 
            // lblEnableTest
            // 
            this.lblEnableTest.AutoSize = true;
            this.lblEnableTest.ForeColor = System.Drawing.Color.Navy;
            this.lblEnableTest.Location = new System.Drawing.Point(89 , 18);
            this.lblEnableTest.Name = "lblEnableTest";
            this.lblEnableTest.Size = new System.Drawing.Size(13 , 12);
            this.lblEnableTest.TabIndex = 1;
            this.lblEnableTest.Text = "--";
            // 
            // lblTestAcc
            // 
            this.lblTestAcc.AutoSize = true;
            this.lblTestAcc.ForeColor = System.Drawing.Color.Navy;
            this.lblTestAcc.Location = new System.Drawing.Point(89 , 37);
            this.lblTestAcc.Name = "lblTestAcc";
            this.lblTestAcc.Size = new System.Drawing.Size(13 , 12);
            this.lblTestAcc.TabIndex = 1;
            this.lblTestAcc.Text = "--";
            // 
            // lblDisableMail
            // 
            this.lblDisableMail.AutoSize = true;
            this.lblDisableMail.ForeColor = System.Drawing.Color.Navy;
            this.lblDisableMail.Location = new System.Drawing.Point(89 , 56);
            this.lblDisableMail.Name = "lblDisableMail";
            this.lblDisableMail.Size = new System.Drawing.Size(13 , 12);
            this.lblDisableMail.TabIndex = 1;
            this.lblDisableMail.Text = "--";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F , 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500 , 426);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "ezSendMail v1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.txtMaxCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.txtSpanTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.txtTrigger)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button bnSave;
		private System.Windows.Forms.CheckBox ckAutoFix;
		private System.Windows.Forms.TextBox txtToAddress;
		private System.Windows.Forms.CheckBox ckMailCustom;
		private System.Windows.Forms.CheckBox ckMailMang;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label lbRunTime;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button bnRun;
		private System.Windows.Forms.Label lbNextRunTime;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label lbStatus;
		private System.Windows.Forms.NumericUpDown txtMaxCount;
		private System.Windows.Forms.NumericUpDown txtSpanTime;
		private System.Windows.Forms.NumericUpDown txtTrigger;
		private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblDisableMail;
        private System.Windows.Forms.Label lblTestAcc;
        private System.Windows.Forms.Label lblEnableTest;
        private System.Windows.Forms.Label label8;

	}
}

