using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ezFlow {
	public partial class fmSysVar : Form {
		ezFlowDSTableAdapters.SysVarTableAdapter adSysVar = new ezFlow.ezFlowDSTableAdapters.SysVarTableAdapter();
		ezFlowDS.SysVarDataTable dtSysVar;
		ezFlowDS.SysVarRow rowSysVar;
		public fmSysVar() {
			InitializeComponent();
			dtSysVar = adSysVar.GetData();			
			if(dtSysVar.Count == 0) {
				rowSysVar = dtSysVar.NewSysVarRow();
				rowSysVar.urlRoot = "http://";
				rowSysVar.mailServer = "";
				rowSysVar.senderName = "";
				rowSysVar.senderMail = "";
				rowSysVar.mailID = "";
				rowSysVar.mailPW = "";
				rowSysVar.maxKey = 0;
				rowSysVar.webSrvURL = "http://";
				dtSysVar.AddSysVarRow(rowSysVar);
				adSysVar.Update(dtSysVar);
			}
			else rowSysVar = dtSysVar[0];

			txtUrlRoot.Text = rowSysVar.urlRoot;
			txtMailServer.Text = rowSysVar.mailServer;
			txtSenderName.Text = rowSysVar.senderName;
			txtSendMail.Text = rowSysVar.senderMail;
			txtMailID.Text = rowSysVar.mailID;
			txtMailPW.Text = rowSysVar.mailPW;
			txtWebSrvURL.Text = rowSysVar.webSrvURL;
		}

		private void fmSysVar_FormClosing(object sender, FormClosingEventArgs e) {			
			if(txtUrlRoot.Text.Trim().Length == 0) {
				MessageBox.Show("網站位址未填寫", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);				
				return;
			}
			if(txtWebSrvURL.Text.Trim().Length == 0) {
				MessageBox.Show("ezEngine 位址未填寫", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if(txtMailServer.Text.Trim().Length == 0) {
				MessageBox.Show("沒有指定郵件伺服器", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if(txtSenderName.Text.Trim().Length == 0) {
				MessageBox.Show("沒有指定寄件者名稱", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if(txtSendMail.Text.Trim().Length == 0) {
				MessageBox.Show("沒有指定電子郵件", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if(txtMailID.Text.Trim().Length > 0 && txtMailPW.Text.Trim().Length == 0) {
				MessageBox.Show("沒有設定郵件伺服器認証密碼", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if(txtMailPW.Text.Trim().Length > 0 && txtMailID.Text.Trim().Length == 0) {
				MessageBox.Show("沒有設定郵件伺服器認証帳號", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			rowSysVar.urlRoot = txtUrlRoot.Text;
			rowSysVar.mailServer = txtMailServer.Text;
			rowSysVar.senderName = txtSenderName.Text;
			rowSysVar.senderMail = txtSendMail.Text;
			rowSysVar.mailID = txtMailID.Text;
			rowSysVar.mailPW = txtMailPW.Text;
			rowSysVar.webSrvURL = txtWebSrvURL.Text;
			adSysVar.Update(dtSysVar);
		}
	}
}