using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ezFlow {
	public partial class fmNodeService : Form {
		public string FlowNode_id = "";
		public string FlowNode_name = "";

		ezFlowDSTableAdapters.NodeServiceTableAdapter adNodeService = new ezFlow.ezFlowDSTableAdapters.NodeServiceTableAdapter();
		ezFlowDS.NodeServiceDataTable dtNodeService = new ezFlowDS.NodeServiceDataTable();

		public fmNodeService() {
			InitializeComponent();
		}

		private void fmNodeService_Load(object sender, EventArgs e) {
			adNodeService.FillByFlowNode(dtNodeService, FlowNode_id);
			if(dtNodeService.Count > 0) txtURL.Text = dtNodeService[0].webSrvUrl;
			else txtURL.Text = "";

			this.Text += " - (" + FlowNode_id + ")" + FlowNode_name;
		}

		private void bnOK_Click(object sender, EventArgs e) {
			ezFlowDS.NodeServiceRow rowNodeService = null;
			if(dtNodeService.Count == 0) rowNodeService = dtNodeService.NewNodeServiceRow();
			else rowNodeService = dtNodeService[0];
			rowNodeService.FlowNode_id = FlowNode_id;
			rowNodeService.webSrvUrl = txtURL.Text;
			if(dtNodeService.Count == 0) dtNodeService.AddNodeServiceRow(rowNodeService);
			adNodeService.Update(dtNodeService);

			this.Close();
		}
	}
}