using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ezOrg {
	public partial class fmWorkAgent : Form {
		public string sRoleID;
		public string sEmpID;
		ezOrgDSTableAdapters.QueriesTableAdapter adQueries = new ezOrg.ezOrgDSTableAdapters.QueriesTableAdapter();

		public fmWorkAgent() {
			InitializeComponent();
		}

		private void fmWorkAgent_Load(object sender, EventArgs e) {
			ezOrgDS.RoleDataTable dtRole = fmMain.adRole.GetDataByID(sRoleID);
			ezOrgDS.PosDataTable dtPos = fmMain.adPos.GetDataByID(dtRole[0].Pos_id);
			ezOrgDS.EmpDataTable dtEmp = fmMain.adEmp.GetDataByID(sEmpID);
		 	ezOrgDS.DeptDataTable dtDept = fmMain.adDept.GetDataByID(dtRole[0].Dept_id);

			lbSource.Text = dtEmp[0].name + "(" + dtPos[0].name + ")";

			// TODO: 這行程式碼會將資料載入 'ezOrgDS.FlowTree' 資料表。您可以視需要進行移動或移除。
			this.flowTreeTableAdapter.FillByPower(this.ezOrgDS.FlowTree, dtDept[0].path, sRoleID);
			// TODO: 這行程式碼會將資料載入 'ezOrgDS.WorkAgent' 資料表。您可以視需要進行移動或移除。
			this.workAgentTableAdapter.FillByIdSource(this.ezOrgDS.WorkAgent, sRoleID, sEmpID);
			// TODO: 這行程式碼會將資料載入 'ezOrgDS.WorkAgentPower' 資料表。您可以視需要進行移動或移除。
			if(this.ezOrgDS.WorkAgent.Count > 0) {
				grdAgent.Rows[0].Selected = true;
				this.workAgentPowerTableAdapter.FillByWorkAgent(this.ezOrgDS.WorkAgentPower, this.ezOrgDS.WorkAgent[0].auto);				
			}
		}

		private void bnAdd_Click(object sender, EventArgs e) {
			fmEmpSelector dlgEmpSelector = new fmEmpSelector();
			if(dlgEmpSelector.ShowDialog() == DialogResult.OK) {
				string empTarget = dlgEmpSelector.Selected_idEmp;
				string roleTarget = dlgEmpSelector.Selected_idRole;

				if(empTarget == sEmpID) {
					MessageBox.Show("您不可以選擇本人自己成為代理人", "訊息通知", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				ezOrgDS.RoleDataTable dtRole = fmMain.adRole.GetDataByID(roleTarget);
				ezOrgDS.PosDataTable dtPos = fmMain.adPos.GetDataByID(dtRole[0].Pos_id);
				ezOrgDS.EmpDataTable dtEmp = fmMain.adEmp.GetDataByID(empTarget);

			 	ezOrgDS.WorkAgentRow rowWorkAgent = this.ezOrgDS.WorkAgent.NewWorkAgentRow();
				rowWorkAgent.Role_idSource = sRoleID;
				rowWorkAgent.Emp_idSource = sEmpID;
				rowWorkAgent.Role_idTarget = roleTarget;
				rowWorkAgent.Emp_idTarget = empTarget;
				rowWorkAgent.Pos_name = dtPos[0].name;
				rowWorkAgent.Emp_name = dtEmp[0].name;
				this.ezOrgDS.WorkAgent.AddWorkAgentRow(rowWorkAgent);

				this.workAgentTableAdapter.Update(this.ezOrgDS.WorkAgent);
				grdAgent.Rows[grdAgent.NewRowIndex - 1].Cells[0].Selected = true;				
			}			
		}

		private void grdAgent_SelectionChanged(object sender, EventArgs e) {
			bool bDel = false;
			for(int i = 0; i < this.ezOrgDS.WorkAgent.Count; i++) {
				if(this.ezOrgDS.WorkAgent[i].RowState == DataRowState.Deleted) {
					this.ezOrgDS.WorkAgentPower.Clear();
					adQueries.DeleteQuery_WorkAgentPower(this.ezOrgDS.WorkAgentPower[i].auto);
					bDel = true;
					break;
				}
			}
			if(bDel) this.workAgentTableAdapter.Update(this.ezOrgDS.WorkAgent);

			if(this.ezOrgDS.WorkAgent.Count > 0 && grdAgent.SelectedRows[0].Index != grdAgent.NewRowIndex) {
				this.workAgentPowerTableAdapter.FillByWorkAgent(this.ezOrgDS.WorkAgentPower,
					this.ezOrgDS.WorkAgent[grdAgent.SelectedRows[0].Index].auto);
			}
		}

		private void grdPower_SelectionChanged(object sender, EventArgs e) {
			bool bDel = false;
			for(int i = 0; i < this.ezOrgDS.WorkAgentPower.Count; i++) {
				if(this.ezOrgDS.WorkAgentPower[i].RowState == DataRowState.Deleted) {					
					bDel = true;
					break;
				}
			}
			if(bDel) this.workAgentPowerTableAdapter.Update(this.ezOrgDS.WorkAgentPower);

			bool bAdd = false;
			for(int i = 0; i < this.ezOrgDS.WorkAgentPower.Count; i++) {
				if(this.ezOrgDS.WorkAgentPower[i].RowState == DataRowState.Added) {
					if(this.ezOrgDS.WorkAgent.Count > 0) {
						this.ezOrgDS.WorkAgentPower[i].WorkAgent_auto =
							this.ezOrgDS.WorkAgent[grdAgent.SelectedRows[0].Index].auto;
						bAdd = true;
					}
					else this.ezOrgDS.WorkAgentPower[i].RejectChanges();
				}
			}
			if(bAdd) this.workAgentPowerTableAdapter.Update(this.ezOrgDS.WorkAgentPower);
		}

		private void grdPower_KeyDown(object sender, KeyEventArgs e) {
			if(e.KeyCode == Keys.Delete) {
				if(MessageBox.Show("確定刪除嗎？", "訊息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == 
					DialogResult.Yes) {
					this.ezOrgDS.WorkAgentPower[grdPower.SelectedRows[0].Index].Delete();
				}
			}
		}

		private void grdAgent_KeyDown(object sender, KeyEventArgs e) {
			if(e.KeyCode == Keys.Delete) {
				if(MessageBox.Show("確定刪除嗎？", "訊息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
					DialogResult.Yes) {
					this.ezOrgDS.WorkAgent[grdAgent.SelectedRows[0].Index].Delete();
				}
			}
		}
	}
}