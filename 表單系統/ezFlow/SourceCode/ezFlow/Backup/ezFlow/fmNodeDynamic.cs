using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ezFlow {
	public partial class fmNodeDynamic : Form {
		public string FlowNode_id = "";
		public string FlowNode_name = "";

		ezFlowDSTableAdapters.NodeDynamicTableAdapter adNodeDynamic = new ezFlow.ezFlowDSTableAdapters.NodeDynamicTableAdapter();
		ezFlowDS.NodeDynamicDataTable dtNodeDynamic = new ezFlowDS.NodeDynamicDataTable();

		public fmNodeDynamic() {
			InitializeComponent();
		}

		private void fmNodeDynamic_Load(object sender, EventArgs e) {
			adNodeDynamic.FillByFlowNode(dtNodeDynamic, FlowNode_id);
			this.Text = " - (" + FlowNode_id + ")" + FlowNode_name;
			if(dtNodeDynamic.Count > 0) {
				txtApName.Text = dtNodeDynamic[0].apName;
				txtTableName.Text = dtNodeDynamic[0].tableName;
				txtFdRole.Text = dtNodeDynamic[0].fdRole;
				txtFdEmp.Text = dtNodeDynamic[0].fdEmp;
			}
			else {
				txtApName.Text = "";
				txtTableName.Text = "";
				txtFdRole.Text = "";
				txtFdEmp.Text = "";
			}
		}

		private void bnOK_Click(object sender, EventArgs e) {
			if(txtApName.Text.Trim().Length == 0) {
				MessageBox.Show("請輸入網頁應用程式名稱", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			ezFlowDS.NodeDynamicRow rowNodeDynamic;
			if(dtNodeDynamic.Count == 0) rowNodeDynamic = dtNodeDynamic.NewNodeDynamicRow();
			else rowNodeDynamic = dtNodeDynamic[0];
			rowNodeDynamic.FlowNode_id = FlowNode_id;
			rowNodeDynamic.apName = txtApName.Text;
			rowNodeDynamic.tableName = txtTableName.Text;
			rowNodeDynamic.fdRole = txtFdRole.Text;
			rowNodeDynamic.fdEmp = txtFdEmp.Text;
			if(dtNodeDynamic.Count == 0) dtNodeDynamic.AddNodeDynamicRow(rowNodeDynamic);
			adNodeDynamic.Update(dtNodeDynamic);
			this.Close();
		}
	}
}