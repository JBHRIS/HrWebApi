using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ezOrg {
	public partial class fmChgMang : Form {
		public string sRoleID;
		ezOrgDS.RoleDataTable dtRole;

		public fmChgMang() {
			InitializeComponent();
		}

		private void fmChgMang_Load(object sender, EventArgs e) {
			dtRole = fmMain.adRole.GetDataByID(sRoleID);
			ezOrgDS.DeptDataTable dtDept = this.deptTableAdapter.GetDataByID(dtRole[0].Dept_id);

			this.deptTableAdapter.FillByCharIndex(this.ezOrgDS.Dept, dtDept[0].path);

			if(dtRole[0].idParent.Trim().Length == 0) {
				lbMsg.Text = "上層部門的預設主管";
				if(cbDept.Items.Count > 0) {
					if(cbDept.Items.Count > 1) cbDept.SelectedIndex = 1;
					else cbDept.SelectedIndex = 0;
					this.rolePosTableAdapter.Fill(this.ezOrgDS.RolePos, cbDept.SelectedValue.ToString(), sRoleID);
					if(cbRolePos.Items.Count > 0) cbRolePos.SelectedIndex = 0;
				}
			}
			else {
				ezOrgDS.RoleDataTable dtRoleParent = fmMain.adRole.GetDataByID(dtRole[0].idParent);
				ezOrgDS.DeptDataTable dtDeptParent = fmMain.adDept.GetDataByID(dtRoleParent[0].Dept_id);
				ezOrgDS.PosDataTable dtPosParent = fmMain.adPos.GetDataByID(dtRoleParent[0].Pos_id);
				lbMsg.Text = "[" + dtDeptParent[0].name + "]-" + dtPosParent[0].name;

				this.rolePosTableAdapter.Fill(this.ezOrgDS.RolePos, cbDept.SelectedValue.ToString(), sRoleID);
				cbRolePos.SelectedValue = dtRole[0].idParent;

				cbDept.SelectedValue = dtDeptParent[0].id;
				cbRolePos.SelectedValue = dtRole[0].idParent;
			}
		}

		private void cbDept_SelectedIndexChanged(object sender, EventArgs e) {
			if(cbDept.SelectedIndex != -1) {
				this.rolePosTableAdapter.Fill(this.ezOrgDS.RolePos, cbDept.SelectedValue.ToString(), sRoleID);
			}
		}

		private void bnOK_Click(object sender, EventArgs e) {
			for(int i=0; i<dtRole.Count; i++) dtRole[i].idParent = cbRolePos.SelectedValue.ToString();
			fmMain.adRole.Update(dtRole);

			DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}