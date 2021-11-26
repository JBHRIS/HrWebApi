using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ezOrg {	
	public partial class fmEmp : Form {
		public string Emp_id = "";
		ezOrgDS.EmpDataTable dtEmp;
		public fmEmp() {
			InitializeComponent();
		}

		private void bnOK_Click(object sender, EventArgs e) {
			ezOrgDS.EmpRow rowEmp;
			if(Emp_id.Trim().Length == 0) {
				dtEmp = fmMain.adEmp.GetDataByID(txtID.Text);
				if(dtEmp.Count > 0) {
					MessageBox.Show("此工號已使用", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
				else {
					rowEmp = dtEmp.NewEmpRow();
					rowEmp.id = txtID.Text;
					rowEmp.name = txtName.Text;
					rowEmp.login = txtLogin.Text;
					rowEmp.pw = txtPW.Text;
					rowEmp.sex = cbSex.Text;
					rowEmp.email = txtEmail.Text;
					rowEmp.isNeedAgent = false;
					rowEmp.dateB = Convert.ToDateTime("1900/1/1");
					rowEmp.dateE = Convert.ToDateTime("1900/1/1");
					dtEmp.AddEmpRow(rowEmp);
					fmMain.adEmp.Update(dtEmp);
					this.Close();
				}
			}
			else {
				rowEmp = dtEmp[0];
				rowEmp.id = txtID.Text;
				rowEmp.name = txtName.Text;
				rowEmp.login = txtLogin.Text;
				rowEmp.pw = txtPW.Text;
				rowEmp.sex = cbSex.Text;
				rowEmp.email = txtEmail.Text;
				rowEmp.isNeedAgent = false;
				rowEmp.dateB = Convert.ToDateTime("1900/1/1");
				rowEmp.dateE = Convert.ToDateTime("1900/1/1");
				fmMain.adEmp.Update(dtEmp);
				this.Close();
			}
		}

		private void fmEmp_Shown(object sender, EventArgs e) {
			if(Emp_id.Trim().Length == 0) {
				lbMsg.Text += "目前工號最大值： " + fmMain.adEmp.MaxID();
				txtID.Text = "";
				txtName.Text = "";
				txtPW.Text = "";
				txtLogin.Text = "";
				txtEmail.Text = "";
				cbSex.Text = "男";
			}
			else {
				lbMsg.Text = "";
				dtEmp = fmMain.adEmp.GetDataByID(Emp_id);
				txtID.Text = dtEmp[0].id;
				txtName.Text = (dtEmp[0].IsnameNull()) ? "" : dtEmp[0].name;
				txtPW.Text = (dtEmp[0].IspwNull()) ? "" : dtEmp[0].pw;
				txtLogin.Text = (dtEmp[0].IsloginNull()) ? "" : dtEmp[0].login;
				txtEmail.Text = (dtEmp[0].IsemailNull()) ? "" : dtEmp[0].email;
				cbSex.Text = (dtEmp[0].IssexNull()) ? "男" : dtEmp[0].sex;
			}
		}
	}
}