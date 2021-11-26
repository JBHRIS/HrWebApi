using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ezOrg {	
	public partial class fmChgPW : Form {
		public string sEmpID;

		public fmChgPW() {
			InitializeComponent();
		}

		private void fmChgPW_Shown(object sender, EventArgs e) {
			txtPW.Text = "";
			txtConfirm.Text = "";
		}

		private void bnOK_Click(object sender, EventArgs e) {
			if(txtPW.Text == txtConfirm.Text) {
				ezOrgDS.EmpDataTable dtEmp = fmMain.adEmp.GetDataByID(sEmpID);
				dtEmp[0].pw = txtPW.Text;
				fmMain.adEmp.Update(dtEmp);

				DialogResult = DialogResult.OK;
				this.Close();
			}
			else MessageBox.Show("二次的密碼輸入不相符", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}
	}
}