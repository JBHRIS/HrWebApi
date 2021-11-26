using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ezOrg {
	public partial class fmRole : Form {		
		public string sDeptID = "";
		public string sParentID = "";

		private ezOrgDS.RoleDataTable dtRole;

		public fmRole() {
			InitializeComponent();
		}

		private void fmRole_Load(object sender, EventArgs e) {
			// TODO: 這行程式碼會將資料載入 'ezOrgDS.Pos' 資料表。您可以視需要進行移動或移除。
			this.posTableAdapter.Fill(this.ezOrgDS.Pos);
		}

		private void fmRole_Shown(object sender, EventArgs e) {
			lbRoleID.Text = "系統自動編號";
			if(cbPos.Items.Count > 0) cbPos.SelectedIndex = 0;
			dpDateB.Value = DateTime.Now.Date;
			dpDateE.Value = Convert.ToDateTime("2099/12/31");

			dtRole = new ezOrgDS.RoleDataTable();
			ezOrgDS.RoleRow rRole = dtRole.NewRoleRow();
			rRole.id = "";
			rRole.idParent = sParentID;
			rRole.Dept_id = sDeptID;
			rRole.Pos_id = "";
			rRole.dateB = DateTime.Now;
			rRole.dateE = DateTime.Now;
			rRole.Emp_id = "";
			rRole.mgDefault = false;
			rRole.deptMg = false;
			dtRole.AddRoleRow(rRole);
		}

		private void bnOK_Click(object sender, EventArgs e) {
			ezOrgDS.RoleDataTable dtRoleCheck =
				fmMain.adRole.GetDataByDeptIDAndPosID(dtRole[0].Dept_id, 
				cbPos.SelectedValue.ToString());
			string RoleID = dtRole[0].Dept_id + cbPos.SelectedValue.ToString();
			if(dtRoleCheck.Count > 0) {
				RoleID += Convert.ToString(dtRoleCheck.Count + 1);
			}
			lbRoleID.Text = RoleID;

			dtRole[0].id = RoleID;
			dtRole[0].Pos_id = cbPos.SelectedValue.ToString();
			dtRole[0].dateB = dpDateB.Value;
			dtRole[0].dateE = dpDateE.Value;
			dtRole[0].mgDefault = false;
			dtRole[0].deptMg = false;
			fmMain.adRole.Update(dtRole);

			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}