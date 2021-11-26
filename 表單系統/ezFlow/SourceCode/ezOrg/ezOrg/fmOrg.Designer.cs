namespace ezOrg {
	partial class fmOrg {
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
			this.label1 = new System.Windows.Forms.Label();
			this.txtID = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.bnOK = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.cbDeptLevel = new System.Windows.Forms.ComboBox();
			this.deptLevelBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.ezOrgDS = new ezOrg.ezOrgDS();
			this.deptLevelTableAdapter = new ezOrg.ezOrgDSTableAdapters.DeptLevelTableAdapter();
			((System.ComponentModel.ISupportInitialize)(this.deptLevelBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ezOrgDS)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "部門代碼";
			// 
			// txtID
			// 
			this.txtID.Location = new System.Drawing.Point(72, 16);
			this.txtID.Name = "txtID";
			this.txtID.Size = new System.Drawing.Size(60, 22);
			this.txtID.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 61);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 12);
			this.label2.TabIndex = 2;
			this.label2.Text = "部門名稱";
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(72, 51);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(166, 22);
			this.txtName.TabIndex = 3;
			// 
			// bnOK
			// 
			this.bnOK.Location = new System.Drawing.Point(245, 82);
			this.bnOK.Name = "bnOK";
			this.bnOK.Size = new System.Drawing.Size(65, 23);
			this.bnOK.TabIndex = 4;
			this.bnOK.Text = "確定";
			this.bnOK.UseVisualStyleBackColor = true;
			this.bnOK.Click += new System.EventHandler(this.bnOK_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 93);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 12);
			this.label3.TabIndex = 5;
			this.label3.Text = "部門等級";
			// 
			// cbDeptLevel
			// 
			this.cbDeptLevel.DataSource = this.deptLevelBindingSource;
			this.cbDeptLevel.DisplayMember = "name";
			this.cbDeptLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbDeptLevel.FormattingEnabled = true;
			this.cbDeptLevel.Location = new System.Drawing.Point(72, 85);
			this.cbDeptLevel.Name = "cbDeptLevel";
			this.cbDeptLevel.Size = new System.Drawing.Size(166, 20);
			this.cbDeptLevel.TabIndex = 6;
			this.cbDeptLevel.ValueMember = "id";
			// 
			// deptLevelBindingSource
			// 
			this.deptLevelBindingSource.DataMember = "DeptLevel";
			this.deptLevelBindingSource.DataSource = this.ezOrgDS;
			// 
			// ezOrgDS
			// 
			this.ezOrgDS.DataSetName = "ezOrgDS";
			this.ezOrgDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// deptLevelTableAdapter
			// 
			this.deptLevelTableAdapter.ClearBeforeFill = true;
			// 
			// fmOrg
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(322, 119);
			this.Controls.Add(this.cbDeptLevel);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.bnOK);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtID);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.Name = "fmOrg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "部門編輯";
			this.Shown += new System.EventHandler(this.fmOrg_Shown);
			this.Load += new System.EventHandler(this.fmOrg_Load);
			((System.ComponentModel.ISupportInitialize)(this.deptLevelBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ezOrgDS)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtID;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Button bnOK;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbDeptLevel;
		private ezOrgDS ezOrgDS;
		private System.Windows.Forms.BindingSource deptLevelBindingSource;
		private ezOrg.ezOrgDSTableAdapters.DeptLevelTableAdapter deptLevelTableAdapter;
	}
}