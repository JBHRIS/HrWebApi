using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ezOrg {
	public partial class fmDeptMg : Form {
		public string sDeptID;

		public fmDeptMg() {
			InitializeComponent();			
		}

		private void fmDeptMg_Shown(object sender, EventArgs e) {
			this.mangRolesTableAdapter.Fill(this.ezOrgDS.MangRoles, sDeptID);
			ezOrgDS.DeptDataTable dtDept = fmMain.adDept.GetDataByID(sDeptID);
			txtDeptName.Text = dtDept[0].name;			
		}

		private void bnOK_Click(object sender, EventArgs e) {
			ezOrgDS.RoleDataTable dtRole = fmMain.adRole.DeptMang_GetDataByDeptID(sDeptID);
			for(int i = 0; i < dtRole.Count; i++) {
				if(dtRole[i].id == cbRoles.SelectedValue.ToString()) dtRole[i].deptMg = true;
				else dtRole[i].deptMg = false;
			}
			fmMain.adRole.Update(dtRole);

			DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}