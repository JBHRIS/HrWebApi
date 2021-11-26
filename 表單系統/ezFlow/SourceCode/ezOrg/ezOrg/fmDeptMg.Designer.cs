namespace ezOrg {
	partial class fmDeptMg {
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
			this.label2 = new System.Windows.Forms.Label();
			this.txtDeptName = new System.Windows.Forms.TextBox();
			this.cbRoles = new System.Windows.Forms.ComboBox();
			this.mangRolesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.ezOrgDS = new ezOrg.ezOrgDS();
			this.bnOK = new System.Windows.Forms.Button();
			this.mangRolesTableAdapter = new ezOrg.ezOrgDSTableAdapters.MangRolesTableAdapter();
			((System.ComponentModel.ISupportInitialize)(this.mangRolesBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ezOrgDS)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(61, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "部門名稱：";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 51);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(113, 12);
			this.label2.TabIndex = 1;
			this.label2.Text = "預設部門主管角色：";
			// 
			// txtDeptName
			// 
			this.txtDeptName.Location = new System.Drawing.Point(123, 15);
			this.txtDeptName.Name = "txtDeptName";
			this.txtDeptName.ReadOnly = true;
			this.txtDeptName.Size = new System.Drawing.Size(178, 22);
			this.txtDeptName.TabIndex = 2;
			// 
			// cbRoles
			// 
			this.cbRoles.DataSource = this.mangRolesBindingSource;
			this.cbRoles.DisplayMember = "Pos_name";
			this.cbRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbRoles.FormattingEnabled = true;
			this.cbRoles.Location = new System.Drawing.Point(123, 43);
			this.cbRoles.Name = "cbRoles";
			this.cbRoles.Size = new System.Drawing.Size(178, 20);
			this.cbRoles.TabIndex = 3;
			this.cbRoles.ValueMember = "id";
			// 
			// mangRolesBindingSource
			// 
			this.mangRolesBindingSource.DataMember = "MangRoles";
			this.mangRolesBindingSource.DataSource = this.ezOrgDS;
			// 
			// ezOrgDS
			// 
			this.ezOrgDS.DataSetName = "ezOrgDS";
			this.ezOrgDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// bnOK
			// 
			this.bnOK.Location = new System.Drawing.Point(226, 69);
			this.bnOK.Name = "bnOK";
			this.bnOK.Size = new System.Drawing.Size(75, 23);
			this.bnOK.TabIndex = 4;
			this.bnOK.Text = "確定";
			this.bnOK.UseVisualStyleBackColor = true;
			this.bnOK.Click += new System.EventHandler(this.bnOK_Click);
			// 
			// mangRolesTableAdapter
			// 
			this.mangRolesTableAdapter.ClearBeforeFill = true;
			// 
			// fmDeptMg
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(316, 104);
			this.Controls.Add(this.bnOK);
			this.Controls.Add(this.cbRoles);
			this.Controls.Add(this.txtDeptName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.Name = "fmDeptMg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "指定部門預設主管角色";
			this.Shown += new System.EventHandler(this.fmDeptMg_Shown);
			((System.ComponentModel.ISupportInitialize)(this.mangRolesBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ezOrgDS)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtDeptName;
		private System.Windows.Forms.ComboBox cbRoles;
		private System.Windows.Forms.Button bnOK;
		private System.Windows.Forms.BindingSource mangRolesBindingSource;
		private ezOrgDS ezOrgDS;
		private ezOrg.ezOrgDSTableAdapters.MangRolesTableAdapter mangRolesTableAdapter;

	}
}