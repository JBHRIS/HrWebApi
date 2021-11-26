using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ezAdmin {
	public partial class fmMain : Form {
		ezAdminDSTableAdapters.DeptTableAdapter adDept = new ezAdmin.ezAdminDSTableAdapters.DeptTableAdapter();
		ezAdminDSTableAdapters.EmpTableAdapter adEmp = new ezAdmin.ezAdminDSTableAdapters.EmpTableAdapter();
		ezAdminDSTableAdapters.ProcessExceptionTableAdapter adProcessException = new ezAdmin.ezAdminDSTableAdapters.ProcessExceptionTableAdapter();
		ezAdminDSTableAdapters.ProcessFlowTableAdapter adProcessFlow = new ezAdmin.ezAdminDSTableAdapters.ProcessFlowTableAdapter();
		ezAdminDSTableAdapters.ProcessNodeTableAdapter adProcessNode = new ezAdmin.ezAdminDSTableAdapters.ProcessNodeTableAdapter();
		ezAdminDSTableAdapters.QueriesTableAdapter adQueries = new ezAdmin.ezAdminDSTableAdapters.QueriesTableAdapter();
		ezAdminDSTableAdapters.SysPlanTableAdapter adSysPlan = new ezAdmin.ezAdminDSTableAdapters.SysPlanTableAdapter();		

		public fmMain() {
			InitializeComponent();
			ezAdminDS.ErrorTypeRow rowErrorType;
			rowErrorType = this.ezAdminDS.ErrorType.NewErrorTypeRow();
			rowErrorType.id = "1";
			rowErrorType.name = "錯誤";
			this.ezAdminDS.ErrorType.AddErrorTypeRow(rowErrorType);

			rowErrorType = this.ezAdminDS.ErrorType.NewErrorTypeRow();
			rowErrorType.id = "2";
			rowErrorType.name = "取消";
			this.ezAdminDS.ErrorType.AddErrorTypeRow(rowErrorType);

			rowErrorType = this.ezAdminDS.ErrorType.NewErrorTypeRow();
			rowErrorType.id = "3";
			rowErrorType.name = "警告";
			this.ezAdminDS.ErrorType.AddErrorTypeRow(rowErrorType);
		}

		private void fmMain_Load(object sender, EventArgs e) {
			// TODO: 這行程式碼會將資料載入 'ezAdminDS.ProcessException' 資料表。您可以視需要進行移動或移除。
			this.processExceptionTableAdapter.Fill(this.ezAdminDS.ProcessException);
			// TODO: 這行程式碼會將資料載入 'ezAdminDS.FlowTree' 資料表。您可以視需要進行移動或移除。
			this.flowTreeTableAdapter.Fill(this.ezAdminDS.FlowTree);
			// TODO: 這行程式碼會將資料載入 'ezAdminDS.ProcessFlow' 資料表。您可以視需要進行移動或移除。
			this.processFlowTableAdapter.Fill(this.ezAdminDS.ProcessFlow);
		}

		private void bnQuery_Click(object sender, EventArgs e) {
			this.processFlowTableAdapter.Fill(this.ezAdminDS.ProcessFlow);

			string Filter = "";
			
			if(ckCancel.Checked) Filter += " isCancel = 1";
			else Filter += " isCancel = 0";

			if(ckDate.Checked) {
				if(Filter.Trim().Length > 0) Filter += " AND";
				Filter += " adate >= #" + dtStart.Value.Date.ToString("yyyy/MM/dd 00:00:00") + "# AND adate <= #" +
					dtEnd.Value.Date.ToString("yyyy/MM/dd 23:59:59") + "#";
			}

			if(ckFlow.Checked) {
				if(Filter.Trim().Length > 0) Filter += " AND";
				Filter += " FlowTree_id = '" + cbFlow.SelectedValue.ToString() + "'";
			}

			if(ckDept.Checked) {
				if(Filter.Trim().Length > 0) Filter += " AND";
				Filter += " Dept_path LIKE '" + txtDept.Tag.ToString() + "%'";
			}

			if(ckStarter.Checked) {
				if(Filter.Trim().Length > 0) Filter += " AND";
				Filter += " Emp_id = '" + txtStarter.Tag.ToString() + "'";
			}

			if(Filter.Trim().Length > 0) processFlowBindingSource.Filter = Filter;
			else processFlowBindingSource.RemoveFilter();
		}

		private void ckDept_CheckedChanged(object sender, EventArgs e) {
			if(ckDept.Checked) bnDeptQuery.Enabled = true;
			else {
				bnDeptQuery.Enabled = false;
				txtDept.Clear();
			}
		}

		private void ckStarter_CheckedChanged(object sender, EventArgs e) {
			if(ckStarter.Checked) bnMemberQuery.Enabled = true;
			else {
				bnMemberQuery.Enabled = false;
				txtStarter.Clear();
			}
		}

		private void bnDeptQuery_Click(object sender, EventArgs e) {
			fmOrgSelector dlgOrgSelector = new fmOrgSelector();
			if(dlgOrgSelector.ShowDialog() == DialogResult.OK) {
				ezAdminDS.DeptDataTable dtDept = adDept.GetDataByID(dlgOrgSelector.Selected_idDept);
				txtDept.Text = dtDept[0].name;
				txtDept.Tag = dtDept[0].path;
			}
		}

		private void bnMemberQuery_Click(object sender, EventArgs e) {
			fmEmpSelector dlgEmpSelector = new fmEmpSelector();
			if(dlgEmpSelector.ShowDialog() == DialogResult.OK) {
				ezAdminDS.EmpDataTable dtEmp = adEmp.GetDataByID(dlgEmpSelector.Selected_idEmp);
				txtStarter.Text = dtEmp[0].name;
				txtStarter.Tag = dtEmp[0].id;
			}
		}

		private void bnOK_Click(object sender, EventArgs e) {
			if(MessageBox.Show("問題確實已解決了？(被標示為已解決的例外，將不再顯示。)",
				"訊息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
				List<int> lstProcessFlow = new List<int>();
				List<string> lstErrorType = new List<string>();

				foreach(DataGridViewRow grdRow in grdException.SelectedRows) {
					int auto = Convert.ToInt32(grdRow.Cells[0].Value);
					ezAdminDS.ProcessExceptionDataTable dtProcessException = adProcessException.GetDataByAuto(auto);
					dtProcessException[0].isOK = true;
					adProcessException.Update(dtProcessException);

					lstProcessFlow.Add(dtProcessException[0].ProcessFlow_id);
					lstErrorType.Add(dtProcessException[0].errorType);					
				}
				this.processExceptionTableAdapter.Fill(this.ezAdminDS.ProcessException);

				for(int i = 0; i < lstProcessFlow.Count; i++) {
					if(lstErrorType[i] == "1") {
						bool isAllOK = true;
						foreach(DataRow drProcessException in this.ezAdminDS.ProcessException.Rows) {
							ezAdminDS.ProcessExceptionRow rowProcessException = (ezAdminDS.ProcessExceptionRow)drProcessException;
							if(lstProcessFlow[i] == rowProcessException.ProcessFlow_id) {
								isAllOK = false;
								break;
							}
						}
						if(isAllOK) {
							ezAdminDS.ProcessFlowDataTable dtProcessFlow = adProcessFlow.GetDataById(lstProcessFlow[i]);
							dtProcessFlow[0].isError = false;
							adProcessFlow.Update(dtProcessFlow);
						}
					}
				}
				this.processFlowTableAdapter.Fill(this.ezAdminDS.ProcessFlow);
			}
		}

		private void bnCancel_Click(object sender, EventArgs e) {
			if(MessageBox.Show("選取的流程將會被中止，確定嗎？",
				"訊息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
				foreach(DataGridViewRow grdRow in grdProcess.SelectedRows) {
					ezAdminDS.ProcessFlowDataTable dtProcessFlow = adProcessFlow.GetDataById(Convert.ToInt32(grdRow.Cells[0].Value));
					dtProcessFlow[0].isCancel = true;
					adProcessFlow.Update(dtProcessFlow);
				}
				this.processFlowTableAdapter.Fill(this.ezAdminDS.ProcessFlow);
			}
		}

		private void bnContinue_Click(object sender, EventArgs e) {
			if(MessageBox.Show("選取的流程將會恢復運作，確定嗎？",
				"訊息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
				foreach(DataGridViewRow grdRow in grdProcess.SelectedRows) {
					ezAdminDS.ProcessFlowDataTable dtProcessFlow = adProcessFlow.GetDataById(Convert.ToInt32(grdRow.Cells[0].Value));
					dtProcessFlow[0].isCancel = false;
					adProcessFlow.Update(dtProcessFlow);
				}
				this.processFlowTableAdapter.Fill(this.ezAdminDS.ProcessFlow);
			}
		}

		private void bnFinish_Click(object sender, EventArgs e) {
			if(MessageBox.Show("選取的流程將會恢復運作，確定嗎？",
				"訊息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
				foreach(DataGridViewRow grdRow in grdProcess.SelectedRows) {
					ezAdminDS.ProcessFlowDataTable dtProcessFlow = adProcessFlow.GetDataById(Convert.ToInt32(grdRow.Cells[0].Value));
					dtProcessFlow[0].isCancel = true;
					dtProcessFlow[0].isFinish = true;
					adProcessFlow.Update(dtProcessFlow);
				}
				this.processFlowTableAdapter.Fill(this.ezAdminDS.ProcessFlow);
			}
		}
	}
}