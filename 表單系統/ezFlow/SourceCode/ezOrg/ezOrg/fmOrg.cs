using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ezOrg {
	public partial class fmOrg : Form {
		public string idParent, deptPath;

		public fmOrg() {
			InitializeComponent();
		}

		private void bnOK_Click(object sender, EventArgs e) {
			ezOrgDS.DeptDataTable dtDept = fmMain.adDept.GetDataByID(txtID.Text);
			if(dtDept.Count > 0) {
				MessageBox.Show("代碼不可重覆使用。", "訊息通知", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			ezOrgDS.DeptRow rDept = dtDept.NewDeptRow();
			rDept.id = txtID.Text;
			rDept.name = txtName.Text;
			rDept.idParent = idParent;
			rDept.path = deptPath + "/" + txtName.Text;
			rDept.DeptLevel_id = cbDeptLevel.SelectedValue.ToString();
			dtDept.AddDeptRow(rDept);

			fmMain.adDept.Update(dtDept);
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void fmOrg_Shown(object sender, EventArgs e) {
			txtID.Text = "";
			txtName.Text = "";
			if(cbDeptLevel.Items.Count > 0) cbDeptLevel.SelectedIndex = 0;
		}

		private void fmOrg_Load(object sender, EventArgs e) {
			// TODO: 這行程式碼會將資料載入 'ezOrgDS.DeptLevel' 資料表。您可以視需要進行移動或移除。
			this.deptLevelTableAdapter.Fill(this.ezOrgDS.DeptLevel);
		}
	}
}