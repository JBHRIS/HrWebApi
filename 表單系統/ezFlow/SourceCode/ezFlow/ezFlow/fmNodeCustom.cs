using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ezFlow {
	public partial class fmNodeCustom : Form {
		public string FlowNode_id;
		public string FlowNode_name;

		ezFlowDSTableAdapters.NodeCustomTableAdapter adNodeCustom = new ezFlow.ezFlowDSTableAdapters.NodeCustomTableAdapter();
		ezFlowDS.NodeCustomDataTable dtNodeCustom = new ezFlowDS.NodeCustomDataTable();

		ezFlowDSTableAdapters.RoleTableAdapter adRole = new ezFlow.ezFlowDSTableAdapters.RoleTableAdapter();
		ezFlowDSTableAdapters.PosTableAdapter adPos = new ezFlow.ezFlowDSTableAdapters.PosTableAdapter();
		ezFlowDSTableAdapters.EmpTableAdapter adEmp = new ezFlow.ezFlowDSTableAdapters.EmpTableAdapter();

		public fmNodeCustom() {
			InitializeComponent();
		}

		private void fmNodeCustom_Load(object sender, EventArgs e) {
			adNodeCustom.FillByFlowNode(dtNodeCustom, FlowNode_id);
			this.Text = " - (" + FlowNode_id + ")" + FlowNode_name;
			if(dtNodeCustom.Count > 0) {
				txtApName.Text = dtNodeCustom[0].apName;				
				ezFlowDS.RoleDataTable dtRole = adRole.GetDataByID(dtNodeCustom[0].Role_id);
				if(dtRole.Count > 0) {
					ezFlowDS.PosDataTable dtPos = adPos.GetDataByID(dtRole[0].Pos_id);
					if(dtPos.Count > 0) {
						txtRole.Text = dtPos[0].name;
						txtRole.Tag = dtRole[0].id;
					}

					foreach(ezFlowDS.RoleRow rowRole in dtRole.Rows) {
						ezFlowDS.EmpDataTable dtEmp = adEmp.GetDataById(rowRole.Emp_id);
						if(dtEmp.Count > 0) {
							cbCustomEmp.Items.Add(dtEmp[0].name + "(" + dtEmp[0].id + ")");
						}
					}

					if(dtNodeCustom[0].Emp_id.Trim().Length > 0) {
						ckUse.Enabled = true;
						ckUse.Checked = true;						

					    ezFlowDS.EmpDataTable dtEmp = adEmp.GetDataById(dtNodeCustom[0].Emp_id);
					    if(dtEmp.Count > 0) {
							cbCustomEmp.Text = dtEmp[0].name + "(" + dtEmp[0].id + ")";
					    }
					}					
				}
				else {
					ckUse.Enabled = false;
					ckUse.Checked = false;
					cbCustomEmp.Text = "";
					cbCustomEmp.Items.Clear();
					cbCustomEmp.Enabled = false;
				}
			}
			else {
				txtApName.Text = "";
				txtRole.Text = "";				
			}
		}

		private void bnOK_Click(object sender, EventArgs e) {
			if(txtApName.Text.Trim().Length == 0) {
				MessageBox.Show("請輸入網頁應用程式名稱", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if(txtRole.Text.Trim().Length == 0) {
				MessageBox.Show("請選取角色", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			string Emp_id = "";
			if(ckUse.Enabled && ckUse.Checked) {
				if(cbCustomEmp.Text.Trim().Length == 0) {
					MessageBox.Show("您勾選使用指定成員，但卻未選取。", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				string str = cbCustomEmp.Text.Substring(0, cbCustomEmp.Text.Length - 1);
				string[] strAry = str.Split(new char[] { '(' });
				if(strAry.Length != 2) {
					cbCustomEmp.Text = "";
					MessageBox.Show("請從項目中選取，以得到正確的資料", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
				ezFlowDS.EmpDataTable dtEmp = adEmp.GetDataById(strAry[1]);
				if(dtEmp.Count == 0) {
					MessageBox.Show("無效的成員資料", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				Emp_id = strAry[1];
			}

			ezFlowDS.NodeCustomRow rowNodeCustom;
			if(dtNodeCustom.Count == 0) rowNodeCustom = dtNodeCustom.NewNodeCustomRow();
			else rowNodeCustom = dtNodeCustom[0];
			rowNodeCustom.FlowNode_id = FlowNode_id;
			rowNodeCustom.apName = txtApName.Text;
			rowNodeCustom.Role_id = txtRole.Tag.ToString();
			rowNodeCustom.Emp_id = Emp_id;
			if(dtNodeCustom.Count == 0) dtNodeCustom.AddNodeCustomRow(rowNodeCustom);
			adNodeCustom.Update(dtNodeCustom);
			this.Close();
		}

		private void bnSelect_Click(object sender, EventArgs e) {
			fmRoleSelector dlgRoleSelector = new fmRoleSelector();
			if(dlgRoleSelector.ShowDialog() == DialogResult.OK) {
				string idRole = dlgRoleSelector.Selected_idRole;
				ezFlowDS.RoleDataTable dtRole = adRole.GetDataByID(idRole);
				txtRole.Text = adPos.GetDataByID(dtRole[0].Pos_id)[0].name;
				txtRole.Tag = idRole;

				cbCustomEmp.Items.Clear();

				foreach(ezFlowDS.RoleRow rowRole in dtRole.Rows) {
					ezFlowDS.EmpDataTable dtEmp = adEmp.GetDataById(rowRole.Emp_id);
					if(dtEmp.Count > 0) {
						cbCustomEmp.Items.Add(dtEmp[0].name + "(" + dtEmp[0].id + ")");
					}
				}
			}
		}

		private void txtRole_TextChanged(object sender, EventArgs e) {
			if(txtRole.Text.Trim().Length > 0) {
				ckUse.Enabled = true;
				cbCustomEmp.Text = "";
			}
			else {
				ckUse.Enabled = false;
				cbCustomEmp.Text = "";
			}
		}

		private void ckUse_CheckedChanged(object sender, EventArgs e) {
			if(ckUse.Checked) {
				cbCustomEmp.Enabled = true;
				cbCustomEmp.Text = "";
			}
			else {
				cbCustomEmp.Enabled = false;
				cbCustomEmp.Text = "";
			}
		}
	}
}