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
			rowErrorType.name = "���~";
			this.ezAdminDS.ErrorType.AddErrorTypeRow(rowErrorType);

			rowErrorType = this.ezAdminDS.ErrorType.NewErrorTypeRow();
			rowErrorType.id = "2";
			rowErrorType.name = "����";
			this.ezAdminDS.ErrorType.AddErrorTypeRow(rowErrorType);

			rowErrorType = this.ezAdminDS.ErrorType.NewErrorTypeRow();
			rowErrorType.id = "3";
			rowErrorType.name = "ĵ�i";
			this.ezAdminDS.ErrorType.AddErrorTypeRow(rowErrorType);
		}

		private void fmMain_Load(object sender, EventArgs e) {
			// TODO: �o��{���X�|�N��Ƹ��J 'ezAdminDS.ProcessException' ��ƪ�C�z�i�H���ݭn�i�沾�ʩβ����C
			this.processExceptionTableAdapter.Fill(this.ezAdminDS.ProcessException);
			// TODO: �o��{���X�|�N��Ƹ��J 'ezAdminDS.FlowTree' ��ƪ�C�z�i�H���ݭn�i�沾�ʩβ����C
			this.flowTreeTableAdapter.Fill(this.ezAdminDS.FlowTree);
			// TODO: �o��{���X�|�N��Ƹ��J 'ezAdminDS.ProcessFlow' ��ƪ�C�z�i�H���ݭn�i�沾�ʩβ����C
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
			if(MessageBox.Show("���D�T��w�ѨM�F�H(�Q�Хܬ��w�ѨM���ҥ~�A�N���A��ܡC)",
				"�T������", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
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
			if(MessageBox.Show("������y�{�N�|�Q����A�T�w�ܡH",
				"�T������", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
				foreach(DataGridViewRow grdRow in grdProcess.SelectedRows) {
					ezAdminDS.ProcessFlowDataTable dtProcessFlow = adProcessFlow.GetDataById(Convert.ToInt32(grdRow.Cells[0].Value));
					dtProcessFlow[0].isCancel = true;
					adProcessFlow.Update(dtProcessFlow);
				}
				this.processFlowTableAdapter.Fill(this.ezAdminDS.ProcessFlow);
			}
		}

		private void bnContinue_Click(object sender, EventArgs e) {
			if(MessageBox.Show("������y�{�N�|��_�B�@�A�T�w�ܡH",
				"�T������", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
				foreach(DataGridViewRow grdRow in grdProcess.SelectedRows) {
					ezAdminDS.ProcessFlowDataTable dtProcessFlow = adProcessFlow.GetDataById(Convert.ToInt32(grdRow.Cells[0].Value));
					dtProcessFlow[0].isCancel = false;
					adProcessFlow.Update(dtProcessFlow);
				}
				this.processFlowTableAdapter.Fill(this.ezAdminDS.ProcessFlow);
			}
		}

		private void bnFinish_Click(object sender, EventArgs e) {
			if(MessageBox.Show("������y�{�N�|��_�B�@�A�T�w�ܡH",
				"�T������", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
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