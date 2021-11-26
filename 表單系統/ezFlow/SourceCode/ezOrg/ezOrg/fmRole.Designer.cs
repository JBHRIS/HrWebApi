namespace ezOrg {
	partial class fmRole {
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
			this.cbPos = new System.Windows.Forms.ComboBox();
			this.posBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.ezOrgDS = new ezOrg.ezOrgDS();
			this.posTableAdapter = new ezOrg.ezOrgDSTableAdapters.PosTableAdapter();
			this.dpDateB = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.dpDateE = new System.Windows.Forms.DateTimePicker();
			this.label4 = new System.Windows.Forms.Label();
			this.bnOK = new System.Windows.Forms.Button();
			this.lbRoleID = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.posBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ezOrgDS)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "角色代碼";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 50);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 12);
			this.label2.TabIndex = 2;
			this.label2.Text = "對應職務";
			// 
			// cbPos
			// 
			this.cbPos.DataSource = this.posBindingSource;
			this.cbPos.DisplayMember = "name";
			this.cbPos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbPos.FormattingEnabled = true;
			this.cbPos.Location = new System.Drawing.Point(71, 42);
			this.cbPos.Name = "cbPos";
			this.cbPos.Size = new System.Drawing.Size(193, 20);
			this.cbPos.TabIndex = 3;
			this.cbPos.ValueMember = "id";
			// 
			// posBindingSource
			// 
			this.posBindingSource.DataMember = "Pos";
			this.posBindingSource.DataSource = this.ezOrgDS;
			// 
			// ezOrgDS
			// 
			this.ezOrgDS.DataSetName = "ezOrgDS";
			this.ezOrgDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// posTableAdapter
			// 
			this.posTableAdapter.ClearBeforeFill = true;
			// 
			// dpDateB
			// 
			this.dpDateB.CustomFormat = "yyyy/MM/dd";
			this.dpDateB.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dpDateB.Location = new System.Drawing.Point(71, 68);
			this.dpDateB.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
			this.dpDateB.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
			this.dpDateB.Name = "dpDateB";
			this.dpDateB.Size = new System.Drawing.Size(82, 22);
			this.dpDateB.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 78);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 12);
			this.label3.TabIndex = 5;
			this.label3.Text = "生失效日";
			// 
			// dpDateE
			// 
			this.dpDateE.CustomFormat = "yyyy/MM/dd";
			this.dpDateE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dpDateE.Location = new System.Drawing.Point(182, 68);
			this.dpDateE.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
			this.dpDateE.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
			this.dpDateE.Name = "dpDateE";
			this.dpDateE.Size = new System.Drawing.Size(82, 22);
			this.dpDateE.TabIndex = 6;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(159, 73);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(17, 12);
			this.label4.TabIndex = 7;
			this.label4.Text = "～";
			// 
			// bnOK
			// 
			this.bnOK.Location = new System.Drawing.Point(71, 96);
			this.bnOK.Name = "bnOK";
			this.bnOK.Size = new System.Drawing.Size(75, 23);
			this.bnOK.TabIndex = 9;
			this.bnOK.Text = "確定";
			this.bnOK.UseVisualStyleBackColor = true;
			this.bnOK.Click += new System.EventHandler(this.bnOK_Click);
			// 
			// lbRoleID
			// 
			this.lbRoleID.AutoSize = true;
			this.lbRoleID.Location = new System.Drawing.Point(71, 24);
			this.lbRoleID.Name = "lbRoleID";
			this.lbRoleID.Size = new System.Drawing.Size(0, 12);
			this.lbRoleID.TabIndex = 10;
			// 
			// fmRole
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(275, 124);
			this.Controls.Add(this.lbRoleID);
			this.Controls.Add(this.bnOK);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.dpDateE);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.dpDateB);
			this.Controls.Add(this.cbPos);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.Name = "fmRole";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "角色編輯";
			this.Shown += new System.EventHandler(this.fmRole_Shown);
			this.Load += new System.EventHandler(this.fmRole_Load);
			((System.ComponentModel.ISupportInitialize)(this.posBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ezOrgDS)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbPos;
		private ezOrgDS ezOrgDS;
		private System.Windows.Forms.BindingSource posBindingSource;
		private ezOrg.ezOrgDSTableAdapters.PosTableAdapter posTableAdapter;
		private System.Windows.Forms.DateTimePicker dpDateB;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DateTimePicker dpDateE;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button bnOK;
		private System.Windows.Forms.Label lbRoleID;
	}
}