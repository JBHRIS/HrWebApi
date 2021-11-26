using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ezFlow {
	public partial class fmNodeInit : Form {
		public string FlowNode_id = "";
		public string FlowNode_name = "";

		ezFlowDSTableAdapters.NodeInitTableAdapter adNodeInit = new ezFlow.ezFlowDSTableAdapters.NodeInitTableAdapter();
		ezFlowDS.NodeInitDataTable dtNodeInit = new ezFlowDS.NodeInitDataTable();

		public fmNodeInit() {
			InitializeComponent();
		}

		private void fmNodeInit_Load(object sender, EventArgs e) {
			adNodeInit.FillByFlowNode(dtNodeInit, FlowNode_id);
			this.Text = " - (" + FlowNode_id + ")" + FlowNode_name;
			if(dtNodeInit.Count > 0) txtApName.Text = dtNodeInit[0].apName;
			else txtApName.Text = "";
		}

		private void bnOK_Click(object sender, EventArgs e) {
			if(txtApName.Text.Trim().Length == 0) {
				MessageBox.Show("請輸入網頁應用程式名稱", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			ezFlowDS.NodeInitRow rowNodeInit;
			if(dtNodeInit.Count == 0) rowNodeInit = dtNodeInit.NewNodeInitRow();
			else rowNodeInit = dtNodeInit[0];
			rowNodeInit.FlowNode_id = FlowNode_id;
			rowNodeInit.apName = txtApName.Text;
			if(dtNodeInit.Count == 0) dtNodeInit.AddNodeInitRow(rowNodeInit);
			adNodeInit.Update(dtNodeInit);
			this.Close();
		}
	}
}