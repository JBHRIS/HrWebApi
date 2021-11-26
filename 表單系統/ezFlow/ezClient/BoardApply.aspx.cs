using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;

public partial class BoardApply : System.Web.UI.Page
{
    AllModule Module = new AllModule();

    protected void Page_Load(object sender, EventArgs e)
    {
		if(!this.IsPostBack) {
			ezClientDS.EmpDataTable dtEmp = Module.adEmp.GetDataById(Request.Cookies["ezFlow"]["Emp_id"].ToString());
			if(dtEmp.Count > 0)
				lbName.Text = dtEmp[0].name;
			else
				bnOK.Enabled = false;
		}
    }

	protected void bnOK_Click(object sender, EventArgs e) {
		if(lbName.Text.Trim().Length == 0) {
			if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "AlertMsg"))
				Page.ClientScript.RegisterStartupScript(typeof(string), "AlertMsg", "alert('沒有申請者資訊，請重新登入');", true);
			return;
		}
		if(txtBoardName.Text.Trim().Length == 0) {
			if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "AlertMsg"))
				Page.ClientScript.RegisterStartupScript(typeof(string), "AlertMsg", "alert('沒有填寫討論區板名');", true);
			return;
		}
		if(txtBoardNote.Text.Trim().Length == 0) {
			if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "AlertMsg"))
				Page.ClientScript.RegisterStartupScript(typeof(string), "AlertMsg", "alert('沒有填寫討論區簡要');", true);
			return;
		}
		string Emp_idAdmin2 = "";
		if(txtAdmin2.Text.Trim().Length > 0) {
			ezClientDS.EmpDataTable dtEmp = Module.adEmp.GetDataBySearch(txtAdmin2.Text);
			if(dtEmp.Count > 0) Emp_idAdmin2 = dtEmp[0].name;
		}

		ezClientDS.BoardApplyDataTable dtBoardApply = new ezClientDS.BoardApplyDataTable();
		ezClientDS.BoardApplyRow rowBoardApply = dtBoardApply.NewBoardApplyRow();
		rowBoardApply.boardName = txtBoardName.Text;
		rowBoardApply.boardNote = txtBoardNote.Text;
		rowBoardApply.Emp_idAdmin1 = Request.Cookies["ezFlow"]["Emp_id"].ToString();
		rowBoardApply.Emp_idAdmin2 = Emp_idAdmin2;
		rowBoardApply.adate = DateTime.Now;
		dtBoardApply.AddBoardApplyRow(rowBoardApply);
		Module.adBoardApply.Update(dtBoardApply);

		ezClientDS.SysAdminDataTable dtSysAdmin = Module.adSysAdmin.GetData();
		if(dtSysAdmin.Count > 0) {
			ezClientDS.SysVarDataTable dtSysVar = Module.adSysVar.GetData();
			if(dtSysVar.Count > 0) {
				for(int i = 0; i < dtSysAdmin.Count; i++) {
					ezClientDS.EmpDataTable dtEmp = Module.adEmp.GetDataBySearch(txtAdmin2.Text);
					if(dtEmp.Count > 0) {
						try {
							string from = "\"ezFlow PostMan\" <" + dtSysVar[0].senderMail + ">";
							string to = "\"" + dtEmp[0].name + "\" <" + dtEmp[0].email + ">";
							string subject = "新板申請通知";
							string body = "申請人:" + lbName.Text + "<BR>" +
								"申請時間:" + rowBoardApply.adate.ToString("yyyy-MM-dd HH:mm") + "<BR>" +
								"討論板名稱:" + txtBoardName.Text + "<BR>" +
								"討論板簡要:" + txtBoardNote.Text + "<BR>" +
								"推荐副板主:" + txtAdmin2 + "<BR><BR>" +
								"請儘快處理。謝謝！";
							string mailServerName = (dtSysVar[0].IsmailServerNull()) ? "" : dtSysVar[0].mailServer;
							bool isUseDefaultCredentials = true;
							string strFrom = (dtSysVar[0].IsmailIDNull()) ? "" : dtSysVar[0].mailID;
							string strFromPass = (dtSysVar[0].IsmailPWNull()) ? "" : dtSysVar[0].mailPW;
							if(strFrom.Trim().Length > 0) isUseDefaultCredentials = false;

							using(MailMessage message =
								new MailMessage(from, to, subject, body)) {
								message.IsBodyHtml = true;
								message.Priority = MailPriority.High;
								message.BodyEncoding = System.Text.Encoding.Default;
								message.SubjectEncoding = System.Text.Encoding.Default;

								SmtpClient mailClient = new SmtpClient(mailServerName);
								mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;

								if(isUseDefaultCredentials) mailClient.UseDefaultCredentials = true;
								else {
									mailClient.UseDefaultCredentials = false;
									mailClient.Credentials = new System.Net.NetworkCredential(strFrom, strFromPass);
								}

								mailClient.Send(message);
							}
						}
						catch { }
					}
				}
			}
		}

		txtAdmin2.Text = "";
		txtBoardNote.Text = "";
		txtBoardName.Text = "";

		if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "SuccessMsg"))
			Page.ClientScript.RegisterStartupScript(typeof(string), "SuccessMsg", "alert('申請單已成功送出。');", true);
	}
}
