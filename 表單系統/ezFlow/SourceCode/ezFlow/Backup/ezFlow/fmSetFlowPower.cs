using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ezFlow {
	public partial class fmSetFlowPower : Form {
		public string FlowTree_id = "";
		public string FlowTree_name = "";
		public fmSetFlowPower() {
			InitializeComponent();
		}

		private void fmSetFlowPower_Load(object sender, EventArgs e) {
			// TODO: 這行程式碼會將資料載入 'ezFlowDS.PosLevel' 資料表。您可以視需要進行移動或移除。
			this.posLevelTableAdapter.Fill(this.ezFlowDS.PosLevel);
			this.flowTreePowerTableAdapter.Fill(this.ezFlowDS.FlowTreePower, FlowTree_id);
			this.flowTreePowerRoleOnlyTableAdapter.Fill(this.ezFlowDS.FlowTreePowerRoleOnly, FlowTree_id);

			this.Text += " - " + FlowTree_name;
		}

		private void bnSelectOrg_Click(object sender, EventArgs e) {
			fmOrgSelector dlgOrgSelector = new fmOrgSelector();

			if(dlgOrgSelector.ShowDialog() == DialogResult.OK) {
				ezFlowDSTableAdapters.DeptTableAdapter adDept = new ezFlow.ezFlowDSTableAdapters.DeptTableAdapter();
				ezFlowDS.DeptDataTable dtDept = adDept.GetDataByID(dlgOrgSelector.Selected_idDept);
				txtOrgPath.Text = dtDept[0].path;
				txtOrgPath.Tag = dtDept[0].id;
			}
		}

		private void bnAddOrg_Click(object sender, EventArgs e) {
			if(txtOrgPath.Text.Trim().Length == 0) {
				MessageBox.Show("您沒有指定部門樹", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			ezFlowDS.FlowTreePowerRow rowFlowTreePower = this.ezFlowDS.FlowTreePower.NewFlowTreePowerRow();
			rowFlowTreePower.FlowTree_id = FlowTree_id;
			rowFlowTreePower.Dept_path = txtOrgPath.Text;
			rowFlowTreePower.isAllSub = ckAllSub.Checked;
			rowFlowTreePower.PosLevel_sorting = Convert.ToInt32(cbPosLevel.SelectedValue.ToString());
			this.ezFlowDS.FlowTreePower.AddFlowTreePowerRow(rowFlowTreePower);
			this.flowTreePowerTableAdapter.Update(this.ezFlowDS.FlowTreePower);

			grdOrg.Rows[grdOrg.Rows.Count - 1].Selected = true;
			grdOrg.CurrentCell = grdOrg.SelectedRows[0].Cells[0];

			txtOrgPath.Text = "/";
			ckAllSub.Checked = true;
			if(cbPosLevel.Items.Count > 0) cbPosLevel.SelectedIndex = 0;
		}

		private void grdOrg_KeyDown(object sender, KeyEventArgs e) {
			if(e.KeyCode == Keys.Delete) {
				if(MessageBox.Show("確定要刪除嗎？", "訊息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
					this.ezFlowDS.FlowTreePower[grdOrg.SelectedRows[0].Index].Delete();
					this.flowTreePowerTableAdapter.Update(this.ezFlowDS.FlowTreePower);
				}
			}
		}

		private void bnSelectRole_Click(object sender, EventArgs e) {
			fmRoleSelector dlgRoleSelector = new fmRoleSelector();

			if(dlgRoleSelector.ShowDialog() == DialogResult.OK) {
				ezFlowDSTableAdapters.RoleTableAdapter adRole = new ezFlow.ezFlowDSTableAdapters.RoleTableAdapter();
				ezFlowDS.RoleDataTable dtRole = adRole.GetDataByID(dlgRoleSelector.Selected_idRole);
				ezFlowDSTableAdapters.PosTableAdapter adPos = new ezFlow.ezFlowDSTableAdapters.PosTableAdapter();
				ezFlowDS.PosDataTable dtPos = adPos.GetDataByID(dtRole[0].Pos_id);
				txtRole.Text = dtPos[0].name;
				txtRole.Tag = dtRole[0].id;				
			}
		}

		private void bnAddRole_Click(object sender, EventArgs e) {
			if(txtRole.Text.Trim().Length == 0) {
				MessageBox.Show("您沒有指定角色", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			ezFlowDS.FlowTreePowerRoleOnlyRow rowFlowTreePowerRoleOnly = this.ezFlowDS.FlowTreePowerRoleOnly.NewFlowTreePowerRoleOnlyRow();
			rowFlowTreePowerRoleOnly.FlowTree_id = FlowTree_id;
			rowFlowTreePowerRoleOnly.Role_id = txtRole.Tag.ToString();
			rowFlowTreePowerRoleOnly.Pos_name = txtRole.Text;
			this.ezFlowDS.FlowTreePowerRoleOnly.AddFlowTreePowerRoleOnlyRow(rowFlowTreePowerRoleOnly);
			this.flowTreePowerRoleOnlyTableAdapter.Update(this.ezFlowDS.FlowTreePowerRoleOnly);

			grdRole.Rows[grdRole.Rows.Count - 1].Selected = true;
			grdRole.CurrentCell = grdRole.SelectedRows[0].Cells[0];

			txtRole.Clear();
		}

		private void grdRole_KeyDown(object sender, KeyEventArgs e) {
			if(e.KeyCode == Keys.Delete) {
				if(MessageBox.Show("確定要刪除嗎？", "訊息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
					this.ezFlowDS.FlowTreePowerRoleOnly[grdRole.SelectedRows[0].Index].Delete();
					this.flowTreePowerRoleOnlyTableAdapter.Update(this.ezFlowDS.FlowTreePowerRoleOnly);
				}
			}
		}
	}
}