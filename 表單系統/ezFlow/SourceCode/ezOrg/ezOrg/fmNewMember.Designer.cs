namespace ezOrg {
	partial class fmNewMember {
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
			this.cbEmp = new System.Windows.Forms.ComboBox();
			this.empBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.ezOrgDS = new ezOrg.ezOrgDS();
			this.label1 = new System.Windows.Forms.Label();
			this.bnOK = new System.Windows.Forms.Button();
			this.empTableAdapter = new ezOrg.ezOrgDSTableAdapters.EmpTableAdapter();
			((System.ComponentModel.ISupportInitialize)(this.empBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ezOrgDS)).BeginInit();
			this.SuspendLayout();
			// 
			// cbEmp
			// 
			this.cbEmp.DataSource = this.empBindingSource;
			this.cbEmp.DisplayMember = "name";
			this.cbEmp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbEmp.FormattingEnabled = true;
			this.cbEmp.Location = new System.Drawing.Point(71, 12);
			this.cbEmp.Name = "cbEmp";
			this.cbEmp.Size = new System.Drawing.Size(147, 20);
			this.cbEmp.TabIndex = 0;
			this.cbEmp.ValueMember = "id";
			// 
			// empBindingSource
			// 
			this.empBindingSource.DataMember = "Emp";
			this.empBindingSource.DataSource = this.ezOrgDS;
			// 
			// ezOrgDS
			// 
			this.ezOrgDS.DataSetName = "ezOrgDS";
			this.ezOrgDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 12);
			this.label1.TabIndex = 1;
			this.label1.Text = "選取員工";
			// 
			// bnOK
			// 
			this.bnOK.Location = new System.Drawing.Point(224, 10);
			this.bnOK.Name = "bnOK";
			this.bnOK.Size = new System.Drawing.Size(75, 23);
			this.bnOK.TabIndex = 2;
			this.bnOK.Text = "選取";
			this.bnOK.UseVisualStyleBackColor = true;
			this.bnOK.Click += new System.EventHandler(this.bnOK_Click);
			// 
			// empTableAdapter
			// 
			this.empTableAdapter.ClearBeforeFill = true;
			// 
			// fmNewMember
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(313, 43);
			this.Controls.Add(this.bnOK);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cbEmp);
			this.MaximizeBox = false;
			this.Name = "fmNewMember";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "選取員工";
			this.Shown += new System.EventHandler(this.fmNewMember_Shown);
			this.Load += new System.EventHandler(this.fmNewMember_Load);
			((System.ComponentModel.ISupportInitialize)(this.empBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ezOrgDS)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cbEmp;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button bnOK;
		private ezOrgDS ezOrgDS;
		private System.Windows.Forms.BindingSource empBindingSource;
		private ezOrg.ezOrgDSTableAdapters.EmpTableAdapter empTableAdapter;
	}
}