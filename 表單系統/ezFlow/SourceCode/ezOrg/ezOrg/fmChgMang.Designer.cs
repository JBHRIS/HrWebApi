namespace ezOrg {
	partial class fmChgMang {
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
			this.cbDept = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cbRolePos = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.bnOK = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.lbMsg = new System.Windows.Forms.Label();
			this.rolePosBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.ezOrgDS = new ezOrg.ezOrgDS();
			this.deptBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.deptTableAdapter = new ezOrg.ezOrgDSTableAdapters.DeptTableAdapter();
			this.rolePosTableAdapter = new ezOrg.ezOrgDSTableAdapters.RolePosTableAdapter();
			((System.ComponentModel.ISupportInitialize)(this.rolePosBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ezOrgDS)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.deptBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// cbDept
			// 
			this.cbDept.DataSource = this.deptBindingSource;
			this.cbDept.DisplayMember = "name";
			this.cbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbDept.FormattingEnabled = true;
			this.cbDept.Location = new System.Drawing.Point(119, 47);
			this.cbDept.Name = "cbDept";
			this.cbDept.Size = new System.Drawing.Size(230, 20);
			this.cbDept.TabIndex = 0;
			this.cbDept.ValueMember = "id";
			this.cbDept.SelectedIndexChanged += new System.EventHandler(this.cbDept_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 55);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(101, 12);
			this.label1.TabIndex = 1;
			this.label1.Text = "選擇主管所在部門";
			// 
			// cbRolePos
			// 
			this.cbRolePos.DataSource = this.rolePosBindingSource;
			this.cbRolePos.DisplayMember = "name";
			this.cbRolePos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbRolePos.FormattingEnabled = true;
			this.cbRolePos.Location = new System.Drawing.Point(119, 73);
			this.cbRolePos.Name = "cbRolePos";
			this.cbRolePos.Size = new System.Drawing.Size(230, 20);
			this.cbRolePos.TabIndex = 2;
			this.cbRolePos.ValueMember = "id";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 81);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(101, 12);
			this.label2.TabIndex = 3;
			this.label2.Text = "選擇擔任主管角色";
			// 
			// bnOK
			// 
			this.bnOK.Location = new System.Drawing.Point(356, 69);
			this.bnOK.Name = "bnOK";
			this.bnOK.Size = new System.Drawing.Size(75, 23);
			this.bnOK.TabIndex = 4;
			this.bnOK.Text = "確定";
			this.bnOK.UseVisualStyleBackColor = true;
			this.bnOK.Click += new System.EventHandler(this.bnOK_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.label3.Location = new System.Drawing.Point(12, 18);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(109, 12);
			this.label3.TabIndex = 5;
			this.label3.Text = "目前主管角色為：";
			// 
			// lbMsg
			// 
			this.lbMsg.AutoSize = true;
			this.lbMsg.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.lbMsg.Location = new System.Drawing.Point(119, 18);
			this.lbMsg.Name = "lbMsg";
			this.lbMsg.Size = new System.Drawing.Size(0, 12);
			this.lbMsg.TabIndex = 6;
			// 
			// rolePosBindingSource
			// 
			this.rolePosBindingSource.DataMember = "RolePos";
			this.rolePosBindingSource.DataSource = this.ezOrgDS;
			// 
			// ezOrgDS
			// 
			this.ezOrgDS.DataSetName = "ezOrgDS";
			this.ezOrgDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// deptBindingSource
			// 
			this.deptBindingSource.DataMember = "Dept";
			this.deptBindingSource.DataSource = this.ezOrgDS;
			// 
			// deptTableAdapter
			// 
			this.deptTableAdapter.ClearBeforeFill = true;
			// 
			// rolePosTableAdapter
			// 
			this.rolePosTableAdapter.ClearBeforeFill = true;
			// 
			// fmChgMang
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(438, 102);
			this.Controls.Add(this.lbMsg);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.bnOK);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cbRolePos);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cbDept);
			this.MaximizeBox = false;
			this.Name = "fmChgMang";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "選取主管角色";
			this.Load += new System.EventHandler(this.fmChgMang_Load);
			((System.ComponentModel.ISupportInitialize)(this.rolePosBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ezOrgDS)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.deptBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cbDept;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbRolePos;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button bnOK;
		private ezOrgDS ezOrgDS;
		private System.Windows.Forms.BindingSource deptBindingSource;
		private ezOrg.ezOrgDSTableAdapters.DeptTableAdapter deptTableAdapter;
		private System.Windows.Forms.BindingSource rolePosBindingSource;
		private ezOrg.ezOrgDSTableAdapters.RolePosTableAdapter rolePosTableAdapter;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lbMsg;				
	}
}