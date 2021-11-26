using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ezFlow {
	public partial class fmNodeStart : Form {
		public string FlowNode_id = "";
		public string FlowNode_name = "";

		ezFlowDSTableAdapters.NodeStartTableAdapter adNodeStart = new ezFlow.ezFlowDSTableAdapters.NodeStartTableAdapter();
		ezFlowDS.NodeStartDataTable dtNodeStart = new ezFlowDS.NodeStartDataTable();


		public fmNodeStart() {
			InitializeComponent();
		}

		private void fmNodeStart_Load(object sender, EventArgs e) {
			adNodeStart.FillByFlowNode(dtNodeStart, FlowNode_id);

			if(dtNodeStart.Count > 0) {
				txtVirtualPath.Text = dtNodeStart[0].virtualPath;
				txtViewAp.Text = dtNodeStart[0].viewAp;
				ckAuto.Checked = dtNodeStart[0].isAuto;				
				txtTableName.Text = dtNodeStart[0].tableName;				
			}
			else {
				txtVirtualPath.Text = "";
				txtViewAp.Text = "";
				ckAuto.Checked = false;				
				txtTableName.Text = "";				
			}

			this.Text += " - (" + FlowNode_id + ")" + FlowNode_name;
		}

		private void bnOK_Click(object sender, EventArgs e) {
			if(txtVirtualPath.Text.Trim().Length == 0) {
				MessageBox.Show("請輸入程式存放資料夾的名稱", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if(txtViewAp.Text.Trim().Length == 0) {
				MessageBox.Show("請輸入資料檢視應用程式的名稱", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			ezFlowDS.NodeStartRow rowNodeStart = null;
			if(dtNodeStart.Count == 0) rowNodeStart = dtNodeStart.NewNodeStartRow();
			else rowNodeStart = dtNodeStart[0];
			rowNodeStart.FlowNode_id = FlowNode_id;
			rowNodeStart.virtualPath = txtVirtualPath.Text;
			rowNodeStart.viewAp = txtViewAp.Text;
			rowNodeStart.isAuto = ckAuto.Checked;			
			rowNodeStart.tableName = txtTableName.Text;			
			if(dtNodeStart.Count == 0) dtNodeStart.AddNodeStartRow(rowNodeStart);
			adNodeStart.Update(dtNodeStart);

			this.Close();
		}
	}
}