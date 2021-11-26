using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ezOrg {
	public partial class fmNewMember : Form {
		public string Emp_id;

		public fmNewMember() {
			InitializeComponent();
		}

		private void fmNewMember_Load(object sender, EventArgs e) {
			// TODO: 這行程式碼會將資料載入 'ezOrgDS.Emp' 資料表。您可以視需要進行移動或移除。
			this.empTableAdapter.FillByNewMember(this.ezOrgDS.Emp);
		}

		private void bnOK_Click(object sender, EventArgs e) {
			Emp_id = cbEmp.SelectedValue.ToString();
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void fmNewMember_Shown(object sender, EventArgs e) {
			Emp_id = "";
			if(cbEmp.Items.Count > 0) cbEmp.SelectedIndex = 0;
		}
	}
}