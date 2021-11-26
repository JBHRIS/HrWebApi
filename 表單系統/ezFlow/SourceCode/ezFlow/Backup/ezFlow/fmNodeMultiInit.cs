using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ezFlow {
	public partial class fmNodeMultiInit : Form {
		public string FlowNode_id;
		public string FlowNode_name;

		ezFlowDSTableAdapters.NodeMultiInitTableAdapter adNodeMultiInit = new ezFlow.ezFlowDSTableAdapters.NodeMultiInitTableAdapter();
		ezFlowDS.NodeMultiInitDataTable dtNodeMultiInit = new ezFlowDS.NodeMultiInitDataTable();

		public fmNodeMultiInit() {
			InitializeComponent();
		}

		private void fmNodeMultiInit_Load(object sender, EventArgs e) {
			adNodeMultiInit.FillByFlowNode(dtNodeMultiInit, FlowNode_id);
			this.Text = " - (" + FlowNode_id + ")" + FlowNode_name;
			if(dtNodeMultiInit.Count > 0) txtApName.Text = dtNodeMultiInit[0].apName;
			else txtApName.Text = "";
		}

		private void bnOK_Click(object sender, EventArgs e) {
			if(txtApName.Text.Trim().Length == 0) {
				MessageBox.Show("請輸入網頁應用程式名稱", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			ezFlowDS.NodeMultiInitRow rowNodeMultiInit;
			if(dtNodeMultiInit.Count == 0) rowNodeMultiInit = dtNodeMultiInit.NewNodeMultiInitRow();
			else rowNodeMultiInit = dtNodeMultiInit[0];
			rowNodeMultiInit.FlowNode_id = FlowNode_id;
			rowNodeMultiInit.apName = txtApName.Text;
			if(dtNodeMultiInit.Count == 0) dtNodeMultiInit.AddNodeMultiInitRow(rowNodeMultiInit);
			adNodeMultiInit.Update(dtNodeMultiInit);
			this.Close();
		}
	}
}