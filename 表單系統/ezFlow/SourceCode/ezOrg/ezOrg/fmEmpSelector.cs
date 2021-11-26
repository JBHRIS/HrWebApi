using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ezOrg {
	public partial class fmEmpSelector : Form {
		class EmpData {
			public string idRole;
			public string idEmp;
		}

		public string Selected_idRole;
		public string Selected_idEmp;

		ezOrgDS.PosDataTable dtPos = fmMain.adPos.GetData();
		ezOrgDS.EmpDataTable dtEmp = fmMain.adEmp.GetData();

		public fmEmpSelector() {
			InitializeComponent();
		}

		private void fmEmpSelector_Load(object sender, EventArgs e) {
			ezOrgDS.DeptDataTable dtDept = fmMain.adDept.GetDataByParent("");
			for(int i = 0; i < dtDept.Count; i++) {
				TreeNode deptNode = new TreeNode(dtDept[i].name);
				deptNode.Tag = dtDept[i].id;
				deptNode.ImageIndex = 0;
				deptNode.SelectedImageIndex = 0;
				tvMain.Nodes.Add(deptNode);
				CreateRole(dtDept[i].id, deptNode);
				CreateDept(dtDept[i].id, deptNode);
				deptNode.Expand();
			}
		}

		void CreateDept(string idParent, TreeNode nodeParent) {
			ezOrgDS.DeptDataTable dtDept = fmMain.adDept.GetDataByParent(idParent);
			for(int i = 0; i < dtDept.Count; i++) {
				TreeNode deptNode = new TreeNode(dtDept[i].name);
				deptNode.Tag = dtDept[i].id;
				deptNode.ImageIndex = 0;
				deptNode.SelectedImageIndex = 0;
				nodeParent.Nodes.Add(deptNode);
				CreateRole(dtDept[i].id, deptNode);
				CreateDept(dtDept[i].id, deptNode);
			}
		}

		void CreateRole(string idParent, TreeNode nodeParent) {
			ezOrgDS.RoleDataTable dtRole = fmMain.adRole.DeptMang_GetDataByDeptID(idParent);
			string oldRole = "";
			for(int i = 0; i < dtRole.Count; i++) {
				if(oldRole == dtRole[i].id) continue;
				else oldRole = dtRole[i].id;
				TreeNode roleNode = new TreeNode(dtPos.FindByid(dtRole[i].Pos_id).name);
				roleNode.Tag = dtRole[i].id;
				roleNode.ImageIndex = 1;
				roleNode.SelectedImageIndex = 1;
				nodeParent.Nodes.Add(roleNode);
				CreateEmp(dtRole[i].id, roleNode);
				CreateSubRole(dtRole[i].id, dtRole[i].Dept_id, roleNode);
			}
		}

		void CreateSubRole(string idParent,string Dept_id, TreeNode nodeParent) {
			ezOrgDS.RoleDataTable dtRole = fmMain.adRole.GetDataByParent(idParent, Dept_id);
			string oldRole = "";
			for(int i = 0; i < dtRole.Count; i++) {
				if(oldRole == dtRole[i].id) continue;
				else oldRole = dtRole[i].id;
				TreeNode roleNode = new TreeNode(dtPos.FindByid(dtRole[i].Pos_id).name);
				roleNode.Tag = dtRole[i].id;
				roleNode.ImageIndex = 1;
				roleNode.SelectedImageIndex = 1;
				nodeParent.Nodes.Add(roleNode);
				CreateEmp(dtRole[i].id, roleNode);
				CreateSubRole(dtRole[i].id, dtRole[i].Dept_id, roleNode);
			}
		}

		void CreateEmp(string id, TreeNode nodeParent) {
			ezOrgDS.RoleDataTable dtRole = fmMain.adRole.GetDataByID(id);
			for(int i = 0; i < dtRole.Count; i++) {
				if(dtRole[i].Emp_id.Trim().Length > 0) {
					TreeNode empNode = new TreeNode(dtEmp.FindByid(dtRole[i].Emp_id).name);
					EmpData empData = new EmpData();
					empData.idRole = dtRole[i].id;
					empData.idEmp = dtRole[i].Emp_id;
					empNode.Tag = empData;
					empNode.ImageIndex = 2;
					empNode.SelectedImageIndex = 2;
					nodeParent.Nodes.Add(empNode);
				}
			}
		}

		private void fmRoleSelector_Shown(object sender, EventArgs e) {
			Selected_idRole = "";
			Selected_idEmp = "";
		}

		private void bnOK_Click(object sender, EventArgs e) {
			if(tvMain.SelectedNode == null) {
				MessageBox.Show("請選取一個角色", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if(tvMain.SelectedNode.ImageIndex != 2) {
				MessageBox.Show("您選取的並非成員", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			DialogResult = DialogResult.OK;			
			Selected_idRole = ((EmpData)tvMain.SelectedNode.Tag).idRole;
			Selected_idEmp = ((EmpData)tvMain.SelectedNode.Tag).idEmp;
			this.Close();
		}
	}
}