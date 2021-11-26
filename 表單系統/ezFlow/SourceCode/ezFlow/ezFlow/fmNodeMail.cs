using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ezFlow {
	public partial class fmNodeMail : Form {
		public string FlowNode_id = "";
		public string FlowNode_name = "";

		ezFlowDSTableAdapters.NodeMailTableAdapter adNodeMail = new ezFlow.ezFlowDSTableAdapters.NodeMailTableAdapter();
		ezFlowDS.NodeMailDataTable dtNodeMail = new ezFlowDS.NodeMailDataTable();

		public fmNodeMail() {
			InitializeComponent();
		}

		private void fmNodeMail_Load(object sender, EventArgs e) {
			adNodeMail.FillByFlowNode(dtNodeMail, FlowNode_id);
			if(dtNodeMail.Count > 0) {
				switch(dtNodeMail[0].receiveType) {
					case "1":
						rbnInit.Checked = true;
						break;
					case "2":
						rbnCustom.Checked = true;
						break;
					case "3":
						rbnDynamic.Checked = true;
						break;
					case "4":
						rbnMang.Checked = true;
						break;
				}
				txtCustom.Text = dtNodeMail[0].customEmail;
				txtTable.Text = dtNodeMail[0].dynamicTable;
				txtFdMail.Text = dtNodeMail[0].dynamicFdMail;
				ckCustom.Checked = dtNodeMail[0].isCustom;
				txtSubject.Text = dtNodeMail[0].subject;
				txtContent.Text = dtNodeMail[0].mailContent;
			}
			else {
				rbnInit.Checked = true;
				txtCustom.Text = "";
				txtTable.Text = "";
				txtFdMail.Text = "";
				ckCustom.Checked = false;
				txtSubject.Text = "";
				txtContent.Text = "";
			}

			this.Text += " - (" + FlowNode_id + ")" + FlowNode_name;
		}

		private void ckCustom_CheckedChanged(object sender, EventArgs e) {
			if(ckCustom.Checked) groupBox.Enabled = true;
			else groupBox.Enabled = false;
		}

		private void bnOK_Click(object sender, EventArgs e) {
			ezFlowDS.NodeMailRow rowNodeMail = null;
			if(dtNodeMail.Count == 0) rowNodeMail = dtNodeMail.NewNodeMailRow();
			else rowNodeMail = dtNodeMail[0];
			rowNodeMail.FlowNode_id = FlowNode_id;
			if(rbnInit.Checked) rowNodeMail.receiveType = "1";
			if(rbnCustom.Checked) rowNodeMail.receiveType = "2";
			if(rbnDynamic.Checked) rowNodeMail.receiveType = "3";
			if (rbnMang.Checked) rowNodeMail.receiveType = "4";
			rowNodeMail.customEmail = txtCustom.Text;
			rowNodeMail.dynamicTable = txtTable.Text;
			rowNodeMail.dynamicFdMail = txtFdMail.Text;
			rowNodeMail.isCustom = ckCustom.Checked;
			rowNodeMail.subject = txtSubject.Text;
			rowNodeMail.mailContent = txtContent.Text;
			if(dtNodeMail.Count == 0) dtNodeMail.AddNodeMailRow(rowNodeMail);
			adNodeMail.Update(dtNodeMail);

			this.Close();
		}
	}
}