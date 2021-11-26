using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ezOrg {
	public partial class fmCheckAgent : Form {
		public string sRoleID;
		public string sEmpID;

		ezOrgDSTableAdapters.CheckAgentDefaultTableAdapter adCheckAgentDefault = new ezOrg.ezOrgDSTableAdapters.CheckAgentDefaultTableAdapter();
		ezOrgDS.CheckAgentDefaultDataTable dtCheckAgentDefault;

		ezOrgDSTableAdapters.QueriesTableAdapter adQueries = new ezOrg.ezOrgDSTableAdapters.QueriesTableAdapter();

		public fmCheckAgent() {
			InitializeComponent();
		}

		private void fmCheckAgent_Load(object sender, EventArgs e) {
			ezOrgDS.RoleDataTable dtRole;
			ezOrgDS.PosDataTable dtPos;
			ezOrgDS.EmpDataTable dtEmp;
			ezOrgDS.DeptDataTable dtDept;

			dtRole = fmMain.adRole.GetDataByID(sRoleID);
			dtPos = fmMain.adPos.GetDataByID(dtRole[0].Pos_id);
			dtEmp = fmMain.adEmp.GetDataByID(sEmpID);
			dtDept = fmMain.adDept.GetDataByID(dtRole[0].Dept_id);
			
			lbSource.Text = dtEmp[0].name + "(" + dtPos[0].name + ")";

			this.flowTreeTableAdapter.FillByPower(this.ezOrgDS.FlowTree, dtDept[0].path, sRoleID);
			this.deptTableAdapter.FillByPath(this.ezOrgDS.Dept,dtDept[0].path);

			dtCheckAgentDefault = adCheckAgentDefault.GetDataByIdSource(sRoleID, sEmpID);
			
			this.checkAgentAlwaysTableAdapter.FillByIdSource(this.ezOrgDS.CheckAgentAlways, sRoleID, sEmpID);
			if(this.ezOrgDS.CheckAgentAlways.Count > 0) {				
				this.checkAgentPowerMTableAdapter.FillByCheckAgentAlways(this.ezOrgDS.CheckAgentPowerM,
					this.ezOrgDS.CheckAgentAlways[0].auto);
				if(this.ezOrgDS.CheckAgentPowerM.Count > 0) {					
					this.checkAgentPowerDTableAdapter.FillByCheckAgentPowerM(this.ezOrgDS.CheckAgentPowerD,
						this.ezOrgDS.CheckAgentPowerM[0].auto);
				}
			}

			if(dtCheckAgentDefault.Count > 0) {
				if(dtCheckAgentDefault[0].Role_idTarget1.Trim().Length > 0) {
					dtRole = fmMain.adRole.GetDataByID(dtCheckAgentDefault[0].Role_idTarget1);
					dtPos = fmMain.adPos.GetDataByID(dtRole[0].Pos_id);
					dtEmp = fmMain.adEmp.GetDataByID(dtCheckAgentDefault[0].Emp_idTarget1);
					txtPos1.Text = dtPos[0].name;
					txtName1.Text = dtEmp[0].name;
				}
				if(dtCheckAgentDefault[0].Role_idTarget2.Trim().Length > 0) {
					dtRole = fmMain.adRole.GetDataByID(dtCheckAgentDefault[0].Role_idTarget2);
					dtPos = fmMain.adPos.GetDataByID(dtRole[0].Pos_id);
					dtEmp = fmMain.adEmp.GetDataByID(dtCheckAgentDefault[0].Emp_idTarget2);
					txtPos2.Text = dtPos[0].name;
					txtName2.Text = dtEmp[0].name;
				}
				if(dtCheckAgentDefault[0].Role_idTarget3.Trim().Length > 0) {
					dtRole = fmMain.adRole.GetDataByID(dtCheckAgentDefault[0].Role_idTarget3);
					dtPos = fmMain.adPos.GetDataByID(dtRole[0].Pos_id);
					dtEmp = fmMain.adEmp.GetDataByID(dtCheckAgentDefault[0].Emp_idTarget3);
					txtPos3.Text = dtPos[0].name;
					txtName3.Text = dtEmp[0].name;
				}
			}

			DefaultAgentControl();
		}

		void DefaultAgentControl() {
			bnAdd3.Enabled = true;
			bnClear3.Enabled = true;
			bnAdd2.Enabled = true;
			bnClear2.Enabled = true;

			if(txtPos2.Text.Trim().Length == 0) {
				bnAdd3.Enabled = false;
				bnClear3.Enabled = false;
			}
			if(txtPos1.Text.Trim().Length == 0) {
				bnAdd2.Enabled = false;
				bnClear2.Enabled = false;
			}
		}

		private void bnAdd1_Click(object sender, EventArgs e) {
			fmEmpSelector dlgEmpSelector = new fmEmpSelector();

			if(dlgEmpSelector.ShowDialog() == DialogResult.OK) {
				if(dlgEmpSelector.Selected_idEmp == sEmpID) {
					MessageBox.Show("您不可以選擇本人自己成為代理人", "訊息通知", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				if(dtCheckAgentDefault.Count == 0) {
					ezOrgDS.CheckAgentDefaultRow rowCheckAgentDefault = dtCheckAgentDefault.NewCheckAgentDefaultRow();
					rowCheckAgentDefault.Role_idSource = sRoleID;
					rowCheckAgentDefault.Emp_idSource = sEmpID;
					rowCheckAgentDefault.Role_idTarget1 = dlgEmpSelector.Selected_idRole;
					rowCheckAgentDefault.Emp_idTarget1 = dlgEmpSelector.Selected_idEmp;
					rowCheckAgentDefault.Role_idTarget2 = "";
					rowCheckAgentDefault.Emp_idTarget2 = "";
					rowCheckAgentDefault.Role_idTarget3 = "";
					rowCheckAgentDefault.Emp_idTarget3 = "";
					dtCheckAgentDefault.AddCheckAgentDefaultRow(rowCheckAgentDefault);
				}
				else {
					if(dlgEmpSelector.Selected_idEmp == dtCheckAgentDefault[0].Emp_idTarget2 ||
						dlgEmpSelector.Selected_idEmp == dtCheckAgentDefault[0].Emp_idTarget3) {
						MessageBox.Show("您選擇的成員已經是 ' " + lbSource.Text + " ' 的代理人", "訊息通知", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}
					dtCheckAgentDefault[0].Role_idTarget1 = dlgEmpSelector.Selected_idRole;
					dtCheckAgentDefault[0].Emp_idTarget1 = dlgEmpSelector.Selected_idEmp;
				}
				adCheckAgentDefault.Update(dtCheckAgentDefault);

				ezOrgDS.RoleDataTable dtRole = fmMain.adRole.GetDataByID(dlgEmpSelector.Selected_idRole);
				ezOrgDS.PosDataTable dtPos = fmMain.adPos.GetDataByID(dtRole[0].Pos_id);
				ezOrgDS.EmpDataTable dtEmp = fmMain.adEmp.GetDataByID(dlgEmpSelector.Selected_idEmp);

				txtPos1.Text = dtPos[0].name;
				txtName1.Text = dtEmp[0].name;
			}

			DefaultAgentControl();
		}

		private void bnClear1_Click(object sender, EventArgs e) {
			if(dtCheckAgentDefault.Count > 0) {
				dtCheckAgentDefault[0].Role_idTarget1 = dtCheckAgentDefault[0].Role_idTarget2;
				dtCheckAgentDefault[0].Emp_idTarget1 = dtCheckAgentDefault[0].Emp_idTarget2;
				dtCheckAgentDefault[0].Role_idTarget2 = dtCheckAgentDefault[0].Role_idTarget3;
				dtCheckAgentDefault[0].Emp_idTarget2 = dtCheckAgentDefault[0].Emp_idTarget3;
				dtCheckAgentDefault[0].Role_idTarget3 = "";
				dtCheckAgentDefault[0].Emp_idTarget3 = "";
				adCheckAgentDefault.Update(dtCheckAgentDefault);

				txtPos1.Text = txtPos2.Text;
				txtName1.Text = txtName2.Text;
				txtPos2.Text = txtPos3.Text;
				txtName2.Text = txtName3.Text;
				txtPos3.Text = "";
				txtName3.Text = "";

				DefaultAgentControl();
			}			
		}

		private void bnAdd2_Click(object sender, EventArgs e) {
			fmEmpSelector dlgEmpSelector = new fmEmpSelector();

			if(dlgEmpSelector.ShowDialog() == DialogResult.OK) {
				if(dlgEmpSelector.Selected_idEmp == sEmpID) {
					MessageBox.Show("您不可以選擇本人自己成為代理人", "訊息通知", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				if(dlgEmpSelector.Selected_idEmp == dtCheckAgentDefault[0].Emp_idTarget1 ||
					dlgEmpSelector.Selected_idEmp == dtCheckAgentDefault[0].Emp_idTarget3) {
					MessageBox.Show("您選擇的成員已經是 ' " + lbSource.Text + " ' 的代理人", "訊息通知", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				dtCheckAgentDefault[0].Role_idTarget2 = dlgEmpSelector.Selected_idRole;
				dtCheckAgentDefault[0].Emp_idTarget2 = dlgEmpSelector.Selected_idEmp;
				adCheckAgentDefault.Update(dtCheckAgentDefault);

				ezOrgDS.RoleDataTable dtRole = fmMain.adRole.GetDataByID(dlgEmpSelector.Selected_idRole);
				ezOrgDS.PosDataTable dtPos = fmMain.adPos.GetDataByID(dtRole[0].Pos_id);
				ezOrgDS.EmpDataTable dtEmp = fmMain.adEmp.GetDataByID(dlgEmpSelector.Selected_idEmp);

				txtPos2.Text = dtPos[0].name;
				txtName2.Text = dtEmp[0].name;
			}

			DefaultAgentControl();
		}

		private void bnClear2_Click(object sender, EventArgs e) {
			dtCheckAgentDefault[0].Role_idTarget2 = dtCheckAgentDefault[0].Role_idTarget3;
			dtCheckAgentDefault[0].Emp_idTarget2 = dtCheckAgentDefault[0].Emp_idTarget3;
			dtCheckAgentDefault[0].Role_idTarget3 = "";
			dtCheckAgentDefault[0].Emp_idTarget3 = "";
			adCheckAgentDefault.Update(dtCheckAgentDefault);

			txtPos2.Text = txtPos3.Text;
			txtName2.Text = txtName3.Text;
			txtPos3.Text = "";
			txtName3.Text = "";

			DefaultAgentControl();
		}

		private void bnAdd3_Click(object sender, EventArgs e) {
			fmEmpSelector dlgEmpSelector = new fmEmpSelector();

			if(dlgEmpSelector.ShowDialog() == DialogResult.OK) {
				if(dlgEmpSelector.Selected_idEmp == sEmpID) {
					MessageBox.Show("您不可以選擇本人自己成為代理人", "訊息通知", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				if(dlgEmpSelector.Selected_idEmp == dtCheckAgentDefault[0].Emp_idTarget1 ||
					dlgEmpSelector.Selected_idEmp == dtCheckAgentDefault[0].Emp_idTarget2) {
					MessageBox.Show("您選擇的成員已經是 ' " + lbSource.Text + " ' 的代理人", "訊息通知", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				dtCheckAgentDefault[0].Role_idTarget3 = dlgEmpSelector.Selected_idRole;
				dtCheckAgentDefault[0].Emp_idTarget3 = dlgEmpSelector.Selected_idEmp;
				adCheckAgentDefault.Update(dtCheckAgentDefault);

				ezOrgDS.RoleDataTable dtRole = fmMain.adRole.GetDataByID(dlgEmpSelector.Selected_idRole);
				ezOrgDS.PosDataTable dtPos = fmMain.adPos.GetDataByID(dtRole[0].Pos_id);
				ezOrgDS.EmpDataTable dtEmp = fmMain.adEmp.GetDataByID(dlgEmpSelector.Selected_idEmp);

				txtPos3.Text = dtPos[0].name;
				txtName3.Text = dtEmp[0].name;
			}

			DefaultAgentControl();
		}

		private void bnClear3_Click(object sender, EventArgs e) {
			dtCheckAgentDefault[0].Role_idTarget3 = "";
			dtCheckAgentDefault[0].Emp_idTarget3 = "";
			adCheckAgentDefault.Update(dtCheckAgentDefault);

			txtPos3.Text = "";
			txtName3.Text = "";

			DefaultAgentControl();
		}

		private void bnAdd4_Click(object sender, EventArgs e) {
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

				ezOrgDS.CheckAgentAlwaysRow rowCheckAgentAlways = this.ezOrgDS.CheckAgentAlways.NewCheckAgentAlwaysRow();
				rowCheckAgentAlways.Role_idSource = sRoleID;
				rowCheckAgentAlways.Emp_idSource = sEmpID;
				rowCheckAgentAlways.Role_idTarget = roleTarget;
				rowCheckAgentAlways.Emp_idTarget = empTarget;
				rowCheckAgentAlways.Pos_name = dtPos[0].name;
				rowCheckAgentAlways.Emp_name = dtEmp[0].name;
				this.ezOrgDS.CheckAgentAlways.AddCheckAgentAlwaysRow(rowCheckAgentAlways);

				this.checkAgentAlwaysTableAdapter.Update(this.ezOrgDS.CheckAgentAlways);
				grdAgent.Rows[grdAgent.NewRowIndex - 1].Cells[0].Selected = true;				
			}
		}

		private void grdAgent_SelectionChanged(object sender, EventArgs e) {
			bool bDel = false;
			for(int i = 0; i < this.ezOrgDS.CheckAgentAlways.Count; i++) {
				if(this.ezOrgDS.CheckAgentAlways[i].RowState == DataRowState.Deleted) {
					this.ezOrgDS.CheckAgentPowerD.Clear();
					for(int j = 0; j < this.ezOrgDS.CheckAgentPowerM.Count; j++) {
						adQueries.DeleteQuery_CheckAgentPowerD(this.ezOrgDS.CheckAgentPowerM[i].auto);
					}
					this.ezOrgDS.CheckAgentPowerM.Clear();
					adQueries.DeleteQuery_CheckAgentPowerM(this.ezOrgDS.CheckAgentAlways[i].auto);
					bDel = true;
					break;
				}
			}
			if(bDel) this.checkAgentAlwaysTableAdapter.Update(this.ezOrgDS.CheckAgentAlways);

			if(this.ezOrgDS.CheckAgentAlways.Count > 0 && grdAgent.SelectedRows[0].Index != grdAgent.NewRowIndex) {
				this.checkAgentPowerMTableAdapter.FillByCheckAgentAlways(this.ezOrgDS.CheckAgentPowerM,
					this.ezOrgDS.CheckAgentAlways[grdAgent.SelectedRows[0].Index].auto);
				if(this.ezOrgDS.CheckAgentPowerM.Count > 0) {
					this.checkAgentPowerDTableAdapter.FillByCheckAgentPowerM(this.ezOrgDS.CheckAgentPowerD,
						this.ezOrgDS.CheckAgentPowerM[0].auto);
				}
				else this.ezOrgDS.CheckAgentPowerD.Clear();
			}
		}

		private void grdM_SelectionChanged(object sender, EventArgs e) {
			bool bDel = false;
			for(int i = 0; i < this.ezOrgDS.CheckAgentPowerM.Count; i++) {
				if(this.ezOrgDS.CheckAgentPowerM[i].RowState == DataRowState.Deleted) {
					this.ezOrgDS.CheckAgentPowerD.Clear();
					adQueries.DeleteQuery_CheckAgentPowerD(this.ezOrgDS.CheckAgentPowerM[i].auto);
					bDel = true;
					break;
				}
			}
			if(bDel) this.checkAgentPowerMTableAdapter.Update(this.ezOrgDS.CheckAgentPowerM);

			bool bAdd = false;
			for(int i = 0; i < this.ezOrgDS.CheckAgentPowerM.Count; i++) {
				if(this.ezOrgDS.CheckAgentPowerM[i].RowState == DataRowState.Added) {
					if(this.ezOrgDS.CheckAgentAlways.Count > 0) {
						this.ezOrgDS.CheckAgentPowerM[i].CheckAgentAlways_auto =
							this.ezOrgDS.CheckAgentAlways[grdAgent.SelectedRows[0].Index].auto;
					}
					else this.ezOrgDS.CheckAgentPowerM[i].RejectChanges();
				}
				bAdd = true;
			}
			if(bAdd) this.checkAgentPowerMTableAdapter.Update(this.ezOrgDS.CheckAgentPowerM);

			if(this.ezOrgDS.CheckAgentPowerM.Count > 0 && grdM.SelectedRows[0].Index != grdM.NewRowIndex) {
				this.checkAgentPowerDTableAdapter.FillByCheckAgentPowerM(this.ezOrgDS.CheckAgentPowerD,
					this.ezOrgDS.CheckAgentPowerM[grdM.SelectedRows[0].Index].auto);
			}
		}

		private void grdD_SelectionChanged(object sender, EventArgs e) {
			bool bDel = false;
			for(int i = 0; i < this.ezOrgDS.CheckAgentPowerD.Count; i++) {
				if(this.ezOrgDS.CheckAgentPowerD[i].RowState == DataRowState.Deleted) {
					bDel = true;
					break;
				}
			}
			if(bDel) this.checkAgentPowerDTableAdapter.Update(this.ezOrgDS.CheckAgentPowerD);

			bool bAdd = false;
			for(int i = 0; i < this.ezOrgDS.CheckAgentPowerD.Count; i++) {
				if(this.ezOrgDS.CheckAgentPowerD[i].RowState == DataRowState.Added) {
					if(this.ezOrgDS.CheckAgentPowerM.Count > 0) {
						this.ezOrgDS.CheckAgentPowerD[i].CheckAgentPowerM_auto =
							this.ezOrgDS.CheckAgentPowerM[grdM.SelectedRows[0].Index].auto;
					}
					else this.ezOrgDS.CheckAgentPowerD[i].RejectChanges();
				}
				bAdd = true;
			}
			if(bAdd) this.checkAgentPowerDTableAdapter.Update(this.ezOrgDS.CheckAgentPowerD);
		}

		private void grdAgent_KeyDown(object sender, KeyEventArgs e) {
			if(e.KeyCode == Keys.Delete) {
				if(MessageBox.Show("確定刪除嗎？", "訊息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
					DialogResult.Yes) {
					this.ezOrgDS.CheckAgentAlways[grdAgent.SelectedRows[0].Index].Delete();
				}
			}
		}

		private void grdM_KeyDown(object sender, KeyEventArgs e) {
			if(e.KeyCode == Keys.Delete) {
				if(MessageBox.Show("確定刪除嗎？", "訊息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
					DialogResult.Yes) {
					this.ezOrgDS.CheckAgentPowerM[grdM.SelectedRows[0].Index].Delete();
				}
			}
		}

		private void grdD_KeyDown(object sender, KeyEventArgs e) {
			if(e.KeyCode == Keys.Delete) {
				if(MessageBox.Show("確定刪除嗎？", "訊息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
					DialogResult.Yes) {
					this.ezOrgDS.CheckAgentPowerD[grdD.SelectedRows[0].Index].Delete();
				}
			}
		}
	}
}