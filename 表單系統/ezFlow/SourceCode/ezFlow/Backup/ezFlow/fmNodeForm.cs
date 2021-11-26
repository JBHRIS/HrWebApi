using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ezFlow {
	public partial class fmNodeForm : Form {
		public string FlowNode_id;
		public string FlowNode_name;

		ezFlowDSTableAdapters.NodeFormTableAdapter adNodeForm = new ezFlow.ezFlowDSTableAdapters.NodeFormTableAdapter();
		ezFlowDS.NodeFormDataTable dtNodeForm = new ezFlowDS.NodeFormDataTable();

		public fmNodeForm() {
			InitializeComponent();
		}

		private void fmNodeForm_Load(object sender, EventArgs e) {
			// TODO: �o��{���X�|�N��Ƹ��J 'ezFlowDS.NodeForm' ��ƪ�C�z�i�H���ݭn�i�沾�ʩβ����C
			adNodeForm.FillByFlowNode(dtNodeForm, FlowNode_id);
			this.Text = " - (" + FlowNode_id + ")" + FlowNode_name;
			if(dtNodeForm.Count > 0) txtApName.Text = dtNodeForm[0].apName;
			else txtApName.Text = "";
		}

		private void bnOK_Click(object sender, EventArgs e) {
			if(txtApName.Text.Trim().Length == 0) {
				MessageBox.Show("�п�J�������ε{���W��", "�T������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			ezFlowDS.NodeFormRow rowNodeForm;
			if(dtNodeForm.Count == 0) rowNodeForm = dtNodeForm.NewNodeFormRow();
			else rowNodeForm = dtNodeForm[0];
			rowNodeForm.FlowNode_id = FlowNode_id;
			rowNodeForm.apName = txtApName.Text;
			if(dtNodeForm.Count == 0) dtNodeForm.AddNodeFormRow(rowNodeForm);
			adNodeForm.Update(dtNodeForm);
			this.Close();
		}
	}
}