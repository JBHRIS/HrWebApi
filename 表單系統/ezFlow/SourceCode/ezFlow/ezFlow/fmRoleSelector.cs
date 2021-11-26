using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ezFlow {
	public partial class fmRoleSelector : Form {
		public string Selected_idRole;

		ezFlowDSTableAdapters.PosTableAdapter adPos = new ezFlow.ezFlowDSTableAdapters.PosTableAdapter();
		ezFlowDS.PosDataTable dtPos;
		ezFlowDSTableAdapters.DeptTableAdapter adDept = new ezFlow.ezFlowDSTableAdapters.DeptTableAdapter();
		ezFlowDSTableAdapters.RoleTableAdapter adRole = new ezFlow.ezFlowDSTableAdapters.RoleTableAdapter();

		public fmRoleSelector() {
			InitializeComponent();

			dtPos = adPos.GetData();
		}

		private void fmRoleSelector_Load(object sender, EventArgs e) {
      
			ezFlowDS.DeptDataTable dtDept = adDept.GetDataByParent("");
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
         
			ezFlowDS.DeptDataTable dtDept = adDept.GetDataByParent(idParent);
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
         
			ezFlowDS.RoleDataTable dtRole = adRole.DeptMang_GetDataByDeptID(idParent);
			string oldRole = "";
			for(int i = 0; i < dtRole.Count; i++) {
				if(oldRole == dtRole[i].id) continue;
				else oldRole = dtRole[i].id;
				TreeNode roleNode = new TreeNode(dtPos.FindByid(dtRole[i].Pos_id).name);
				roleNode.Tag = dtRole[i].id;
				roleNode.ImageIndex = 1;
				roleNode.SelectedImageIndex = 1;
				nodeParent.Nodes.Add(roleNode);
				CreateSubRole(dtRole[i].id, dtRole[i].Dept_id, roleNode);
			}
		}

		void CreateSubRole(string idParent, string Dept_id, TreeNode nodeParent) {
         
			ezFlowDS.RoleDataTable dtRole = adRole.GetDataByParent(idParent, Dept_id);
			string oldRole = "";
			for(int i = 0; i < dtRole.Count; i++) {
				if(oldRole == dtRole[i].id) continue;
				else oldRole = dtRole[i].id;
				TreeNode roleNode = new TreeNode(dtPos.FindByid(dtRole[i].Pos_id).name);
				roleNode.Tag = dtRole[i].id;
				roleNode.ImageIndex = 1;
				roleNode.SelectedImageIndex = 1;
				nodeParent.Nodes.Add(roleNode);
				CreateSubRole(dtRole[i].id, dtRole[i].Dept_id, roleNode);
			}
		}

		private void fmRoleSelector_Shown(object sender, EventArgs e) {
			Selected_idRole = "";
		}

		private void bnOK_Click(object sender, EventArgs e) {
			if(tvMain.SelectedNode == null) {
				MessageBox.Show("請選取一個角色", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if(tvMain.SelectedNode.ImageIndex != 1) {
				MessageBox.Show("您選取的並非角色", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			DialogResult = DialogResult.OK;
			Selected_idRole = tvMain.SelectedNode.Tag.ToString();
			this.Close();
		}
	}
}