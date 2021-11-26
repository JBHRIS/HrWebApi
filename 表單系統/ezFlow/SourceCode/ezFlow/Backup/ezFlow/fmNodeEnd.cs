using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ezFlow {
	public partial class fmNodeEnd : Form {
		public string FlowNode_id = "";
		public string FlowNode_name = "";

		ezFlowDSTableAdapters.NodeEndTableAdapter adNodeEnd = new ezFlow.ezFlowDSTableAdapters.NodeEndTableAdapter();
		ezFlowDS.NodeEndDataTable dtNodeEnd = new ezFlowDS.NodeEndDataTable();

		public fmNodeEnd() {
			InitializeComponent();
		}

		private void fmNodeEnd_Load(object sender, EventArgs e) {
			adNodeEnd.FillByFlowNode(dtNodeEnd, FlowNode_id);
			if(dtNodeEnd.Count > 0) {
				ckMailInit.Checked = dtNodeEnd[0].isMailStarter;
				ckMailMang.Checked = dtNodeEnd[0].isMailAllMang;
			}
			else {
				ckMailInit.Checked = false;
				ckMailMang.Checked = false;
			}

			this.Text += " - (" + FlowNode_id + ")" + FlowNode_name;
		}

		private void bnOK_Click(object sender, EventArgs e) {
			ezFlowDS.NodeEndRow rowNodeEnd = null;
			if(dtNodeEnd.Count == 0) rowNodeEnd = dtNodeEnd.NewNodeEndRow();
			else rowNodeEnd = dtNodeEnd[0];

			rowNodeEnd.FlowNode_id = FlowNode_id;
			rowNodeEnd.isMailStarter = ckMailInit.Checked;
			rowNodeEnd.isMailAllMang = ckMailMang.Checked;

			if(dtNodeEnd.Count == 0) dtNodeEnd.AddNodeEndRow(rowNodeEnd);
			adNodeEnd.Update(dtNodeEnd);

			this.Close();
		}
	}
}