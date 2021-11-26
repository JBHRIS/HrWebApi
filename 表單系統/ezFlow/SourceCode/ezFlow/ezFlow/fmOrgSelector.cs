using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ezFlow {
	public partial class fmOrgSelector : Form {
		public string Selected_idDept;
		ezFlowDSTableAdapters.DeptTableAdapter adDept = new ezFlow.ezFlowDSTableAdapters.DeptTableAdapter();

		public fmOrgSelector() {
			InitializeComponent();
		}

		private void fmOrgSelector_Load(object sender, EventArgs e) {
			ezFlowDS.DeptDataTable dtDept = adDept.GetDataByParent("");
			for(int i = 0; i < dtDept.Count; i++) {
				TreeNode deptNode = new TreeNode(dtDept[i].name);
				deptNode.Tag = dtDept[i].id;
				deptNode.ImageIndex = 0;
				deptNode.SelectedImageIndex = 0;
				tvMain.Nodes.Add(deptNode);
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
				CreateDept(dtDept[i].id, deptNode);
			}
		}

		private void fmOrgSelector_Shown(object sender, EventArgs e) {
			Selected_idDept = "";
		}

		private void bnOK_Click(object sender, EventArgs e) {
			if(tvMain.SelectedNode == null) {
				MessageBox.Show("請選取一個部門", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			DialogResult = DialogResult.OK;
			Selected_idDept = tvMain.SelectedNode.Tag.ToString();
			this.Close();
		}
	}
}