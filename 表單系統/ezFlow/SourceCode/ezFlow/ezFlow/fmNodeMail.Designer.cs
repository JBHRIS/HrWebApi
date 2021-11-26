namespace ezFlow {
	partial class fmNodeMail {
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtFdMail = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtTable = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtCustom = new System.Windows.Forms.TextBox();
			this.rbnDynamic = new System.Windows.Forms.RadioButton();
			this.rbnCustom = new System.Windows.Forms.RadioButton();
			this.rbnInit = new System.Windows.Forms.RadioButton();
			this.groupBox = new System.Windows.Forms.GroupBox();
			this.txtContent = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtSubject = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.ckCustom = new System.Windows.Forms.CheckBox();
			this.bnOK = new System.Windows.Forms.Button();
			this.rbnMang = new System.Windows.Forms.RadioButton();
			this.groupBox1.SuspendLayout();
			this.groupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rbnMang);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtFdMail);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtTable);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtCustom);
			this.groupBox1.Controls.Add(this.rbnDynamic);
			this.groupBox1.Controls.Add(this.rbnCustom);
			this.groupBox1.Controls.Add(this.rbnInit);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(345, 144);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "收件者";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(128, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(157, 12);
			this.label3.TabIndex = 13;
			this.label3.Text = "(包含共用流程及代理起始者)";
			// 
			// txtFdMail
			// 
			this.txtFdMail.Location = new System.Drawing.Point(185, 110);
			this.txtFdMail.Name = "txtFdMail";
			this.txtFdMail.Size = new System.Drawing.Size(142, 22);
			this.txtFdMail.TabIndex = 11;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(126, 115);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 12);
			this.label2.TabIndex = 11;
			this.label2.Text = "郵件欄位";
			// 
			// txtTable
			// 
			this.txtTable.Location = new System.Drawing.Point(185, 87);
			this.txtTable.Name = "txtTable";
			this.txtTable.Size = new System.Drawing.Size(142, 22);
			this.txtTable.TabIndex = 10;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(138, 92);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 12);
			this.label1.TabIndex = 9;
			this.label1.Text = "資料表";
			// 
			// txtCustom
			// 
			this.txtCustom.Location = new System.Drawing.Point(128, 63);
			this.txtCustom.Name = "txtCustom";
			this.txtCustom.Size = new System.Drawing.Size(199, 22);
			this.txtCustom.TabIndex = 8;
			// 
			// rbnDynamic
			// 
			this.rbnDynamic.AutoSize = true;
			this.rbnDynamic.Location = new System.Drawing.Point(15, 88);
			this.rbnDynamic.Name = "rbnDynamic";
			this.rbnDynamic.Size = new System.Drawing.Size(107, 16);
			this.rbnDynamic.TabIndex = 9;
			this.rbnDynamic.Text = "動態收件者郵件";
			this.rbnDynamic.UseVisualStyleBackColor = true;
			// 
			// rbnCustom
			// 
			this.rbnCustom.AutoSize = true;
			this.rbnCustom.Location = new System.Drawing.Point(15, 66);
			this.rbnCustom.Name = "rbnCustom";
			this.rbnCustom.Size = new System.Drawing.Size(107, 16);
			this.rbnCustom.TabIndex = 7;
			this.rbnCustom.Text = "固定收件者郵件";
			this.rbnCustom.UseVisualStyleBackColor = true;
			// 
			// rbnInit
			// 
			this.rbnInit.AutoSize = true;
			this.rbnInit.Checked = true;
			this.rbnInit.Location = new System.Drawing.Point(15, 21);
			this.rbnInit.Name = "rbnInit";
			this.rbnInit.Size = new System.Drawing.Size(83, 16);
			this.rbnInit.TabIndex = 5;
			this.rbnInit.TabStop = true;
			this.rbnInit.Text = "流程起始者";
			this.rbnInit.UseVisualStyleBackColor = true;
			// 
			// groupBox
			// 
			this.groupBox.Controls.Add(this.txtContent);
			this.groupBox.Controls.Add(this.label5);
			this.groupBox.Controls.Add(this.txtSubject);
			this.groupBox.Controls.Add(this.label4);
			this.groupBox.Enabled = false;
			this.groupBox.Location = new System.Drawing.Point(12, 175);
			this.groupBox.Name = "groupBox";
			this.groupBox.Size = new System.Drawing.Size(346, 183);
			this.groupBox.TabIndex = 6;
			this.groupBox.TabStop = false;
			// 
			// txtContent
			// 
			this.txtContent.Location = new System.Drawing.Point(72, 49);
			this.txtContent.Multiline = true;
			this.txtContent.Name = "txtContent";
			this.txtContent.Size = new System.Drawing.Size(255, 122);
			this.txtContent.TabIndex = 15;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(13, 49);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(53, 12);
			this.label5.TabIndex = 14;
			this.label5.Text = "郵件內容";
			// 
			// txtSubject
			// 
			this.txtSubject.Location = new System.Drawing.Point(72, 21);
			this.txtSubject.Name = "txtSubject";
			this.txtSubject.Size = new System.Drawing.Size(255, 22);
			this.txtSubject.TabIndex = 13;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(13, 21);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(53, 12);
			this.label4.TabIndex = 12;
			this.label4.Text = "郵件主旨";
			// 
			// ckCustom
			// 
			this.ckCustom.AutoSize = true;
			this.ckCustom.Location = new System.Drawing.Point(27, 162);
			this.ckCustom.Name = "ckCustom";
			this.ckCustom.Size = new System.Drawing.Size(96, 16);
			this.ckCustom.TabIndex = 7;
			this.ckCustom.Text = "自訂郵件內容";
			this.ckCustom.UseVisualStyleBackColor = true;
			this.ckCustom.CheckedChanged += new System.EventHandler(this.ckCustom_CheckedChanged);
			// 
			// bnOK
			// 
			this.bnOK.Location = new System.Drawing.Point(283, 364);
			this.bnOK.Name = "bnOK";
			this.bnOK.Size = new System.Drawing.Size(75, 23);
			this.bnOK.TabIndex = 8;
			this.bnOK.Text = "確定";
			this.bnOK.UseVisualStyleBackColor = true;
			this.bnOK.Click += new System.EventHandler(this.bnOK_Click);
			// 
			// rbnMang
			// 
			this.rbnMang.AutoSize = true;
			this.rbnMang.Location = new System.Drawing.Point(15, 43);
			this.rbnMang.Name = "rbnMang";
			this.rbnMang.Size = new System.Drawing.Size(119, 16);
			this.rbnMang.TabIndex = 6;
			this.rbnMang.Text = "流程起始者的主管";
			this.rbnMang.UseVisualStyleBackColor = true;
			// 
			// fmNodeMail
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(370, 392);
			this.Controls.Add(this.bnOK);
			this.Controls.Add(this.ckCustom);
			this.Controls.Add(this.groupBox);
			this.Controls.Add(this.groupBox1);
			this.MaximizeBox = false;
			this.Name = "fmNodeMail";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "內容";
			this.Load += new System.EventHandler(this.fmNodeMail_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox.ResumeLayout(false);
			this.groupBox.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtTable;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtCustom;
		private System.Windows.Forms.RadioButton rbnDynamic;
		private System.Windows.Forms.RadioButton rbnCustom;
		private System.Windows.Forms.RadioButton rbnInit;
		private System.Windows.Forms.TextBox txtFdMail;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox;
		private System.Windows.Forms.CheckBox ckCustom;
		private System.Windows.Forms.TextBox txtContent;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtSubject;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button bnOK;
		private System.Windows.Forms.RadioButton rbnMang;

	}
}