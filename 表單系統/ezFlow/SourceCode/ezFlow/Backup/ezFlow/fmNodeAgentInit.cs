using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ezFlow {
	public partial class fmNodeAgentInit : Form {
		public string FlowNode_id;
		public string FlowNode_name;

		ezFlowDSTableAdapters.NodeAgentInitTableAdapter adNodeAgentInit = new ezFlow.ezFlowDSTableAdapters.NodeAgentInitTableAdapter();
		ezFlowDS.NodeAgentInitDataTable dtNodeAgentInit = new ezFlowDS.NodeAgentInitDataTable();

		public fmNodeAgentInit() {
			InitializeComponent();
		}

		private void fmNodeAgentInit_Load(object sender, EventArgs e) {
			adNodeAgentInit.FillByFlowNode(dtNodeAgentInit, FlowNode_id);
			this.Text = " - (" + FlowNode_id + ")" + FlowNode_name;
			if(dtNodeAgentInit.Count > 0) txtApName.Text = dtNodeAgentInit[0].apName;
			else txtApName.Text = "";
		}

		private void bnOK_Click(object sender, EventArgs e) {
			if(txtApName.Text.Trim().Length == 0) {
				MessageBox.Show("請輸入網頁應用程式名稱", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			ezFlowDS.NodeAgentInitRow rowNodeAgentInit;
			if(dtNodeAgentInit.Count == 0) rowNodeAgentInit = dtNodeAgentInit.NewNodeAgentInitRow();
			else rowNodeAgentInit = dtNodeAgentInit[0];
			rowNodeAgentInit.FlowNode_id = FlowNode_id;
			rowNodeAgentInit.apName = txtApName.Text;
			if(dtNodeAgentInit.Count == 0) dtNodeAgentInit.AddNodeAgentInitRow(rowNodeAgentInit);
			adNodeAgentInit.Update(dtNodeAgentInit);
			this.Close();
		}
	}
}