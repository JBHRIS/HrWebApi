using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ezFlow {
	public partial class fmNodeMang : Form {
		public string FlowNode_id = "";
		public string FlowNode_name = "";
		public string FlowTree_id = "";

		ezFlowDSTableAdapters.NodeMangTableAdapter adNodeMang = new ezFlow.ezFlowDSTableAdapters.NodeMangTableAdapter();
		ezFlowDS.NodeMangDataTable dtNodeMang = new ezFlowDS.NodeMangDataTable();

		public fmNodeMang() {
			InitializeComponent();
		}

		private void fmNodeMang_Load(object sender, EventArgs e) {
			adNodeMang.FillByFlowNode(dtNodeMang, FlowNode_id);
			this.Text = " - (" + FlowNode_id + ")" + FlowNode_name;
			if(dtNodeMang.Count > 0) txtApName.Text = dtNodeMang[0].apName;
			else txtApName.Text = "";
		}

		private void bnOK_Click(object sender, EventArgs e) {
			if(txtApName.Text.Trim().Length == 0) {
				MessageBox.Show("請輸入網頁應用程式名稱", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			ezFlowDS.NodeMangRow rowNodeMang;
			if(dtNodeMang.Count == 0) rowNodeMang = dtNodeMang.NewNodeMangRow();
			else rowNodeMang = dtNodeMang[0];
			rowNodeMang.FlowNode_id = FlowNode_id;
			rowNodeMang.apName = txtApName.Text;
			if(dtNodeMang.Count == 0) dtNodeMang.AddNodeMangRow(rowNodeMang);
			adNodeMang.Update(dtNodeMang);
			this.Close();
		}

		private void bnSet_Click(object sender, EventArgs e) {
			fmMangPower dlgMangPower = new fmMangPower();
			dlgMangPower.FlowNode_id = FlowNode_id;
			dlgMangPower.FlowNode_name = FlowNode_name;
			dlgMangPower.FlowTree_id = FlowTree_id;
			dlgMangPower.ShowDialog();
		}

	}
}