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

public partial class PostDetail : System.Web.UI.Page
{
	string BoardList_auto;
    AllModule Module = new AllModule();

    protected void Page_Load(object sender, EventArgs e)
    {
		string PostMain_auto = Request["PostMain_auto"];
		ezClientDS.PostMainDataTable dtPostMain = Module.adPostMain.GetDataByAuto(Convert.ToInt32(PostMain_auto));
		lbSubject.Text = dtPostMain[0].subject;
		ezClientDS.BoardListDataTable dtBoardList = Module.adBoardList.GetDataByAuto(dtPostMain[0].BoardList_auto);
		lbCaption.Text = "<a href='PostMain.aspx?BoardList_auto=" + dtBoardList[0].auto.ToString() + "'>" +
			dtBoardList[0].caption + "</a>";
		BoardList_auto = dtBoardList[0].auto.ToString();
    }

	protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e) {
		if(e.Item.DataItem != null) {
			Control ctrl = null, ctrl1 = null, ctrl2 = null;

			ezClientDS.PostDetailRow rowPostDetail = (ezClientDS.PostDetailRow)((DataRowView)e.Item.DataItem).Row;
			ezClientDS.EmpDataTable dtEmp = Module.adEmp.GetDataById(rowPostDetail.Emp_id);

			ctrl = e.Item.FindControl("lbName");
			if(ctrl != null) {
				((Label)ctrl).Text = dtEmp[0].name;
				if(!dtEmp[0].IsemailNull() && dtEmp[0].email.Trim().Length > 0) {
					ctrl = e.Item.FindControl("lbEmail");
					if(ctrl != null) ((Label)ctrl).Text = "<a href='mailto:" + dtEmp[0].email + "'>" +
						dtEmp[0].email + "</a>";
				}
			}
			
			ctrl = e.Item.FindControl("lbPraiseCount");
			if(ctrl != null) {
				ezClientDS.EmpInfoDataTable dtEmpInfo = Module.adEmpInfo.GetDataByEmp(rowPostDetail.Emp_id);
				ctrl1 = e.Item.FindControl("lbSignText");
				if(dtEmpInfo.Count > 0) {
					((Label)ctrl).Text = dtEmpInfo[0].praiseCount.ToString();
					if(ctrl1 != null) ((Label)ctrl1).Text = dtEmpInfo[0].signText;
				}
				else {
					((Label)ctrl).Text = "0";
					if(ctrl1 != null) ((Label)ctrl1).Text = "&nbsp;";
				}
			}

			ctrl = e.Item.FindControl("lbPostCount");
			if(ctrl != null) {
				((Label)ctrl).Text = Module.adPostDetail.CountQueryByEmp(rowPostDetail.Emp_id).ToString();
			}

			ctrl1 = e.Item.FindControl("bnEdit");
			ctrl2 = e.Item.FindControl("bnDel");
			if(ctrl1 != null && ctrl2 != null) {
				((Button)ctrl1).Visible = false;
				((Button)ctrl2).Visible = false;
				ezClientDS.BoardListDataTable dtBoardList = Module.adBoardList.GetDataByAuto(Convert.ToInt32(BoardList_auto));
				if(dtBoardList.Count > 0) {
					if(rowPostDetail.Emp_id == Request.Cookies["ezFlow"]["Emp_id"].ToString() || 
						Request.Cookies["ezFlow"]["Emp_id"].ToString() == dtBoardList[0].Emp_idAdmin1 ||
						Request.Cookies["ezFlow"]["Emp_id"].ToString() == dtBoardList[0].Emp_idAdmin2) {
						((Button)ctrl1).Visible = true;
						((Button)ctrl2).Visible = true;
					}
				}
			}
		}
	}

	protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e) {
		if(e.CommandName == "Reply") {			
			Response.Redirect("Post.aspx?Flag=Reply&BoardList_auto=" + BoardList_auto + "&PostDetail_auto=" + e.CommandArgument.ToString());
		}
		if(e.CommandName == "ReplyEmpty") {
			Response.Redirect("Post.aspx?Flag=ReplyEmpty&BoardList_auto=" + BoardList_auto + "&PostDetail_auto=" + e.CommandArgument.ToString());
		}
		if(e.CommandName == "EditPost") {
			Response.Redirect("Post.aspx?Flag=Edit&BoardList_auto=" + BoardList_auto + "&PostDetail_auto=" + e.CommandArgument.ToString());
		}
		if(e.CommandName == "DelPost") {
			ezClientDS.PostDetailDataTable dtPostDetail = Module.adPostDetail.GetDataByAuto(Convert.ToInt32(e.CommandArgument));						
			ezClientDS.SysVarDataTable dtSysVar = Module.adSysVar.GetData();			
			if(dtSysVar.Count > 0 && dtPostDetail.Count > 0) {
				if(dtPostDetail[0].Emp_id != Request.Cookies["ezFlow"]["Emp_id"].ToString()) {
					ezClientDS.EmpDataTable dtEmp = Module.adEmp.GetDataById(dtPostDetail[0].Emp_id);
					if(dtEmp.Count > 0 && !dtEmp[0].IsemailNull() && dtEmp[0].email.Length > 0) {
						try {
							string from = "\"ezFlow PostMan\" <" + dtSysVar[0].senderMail + ">";
							string to = "\"" + dtEmp[0].name + "\" <" + dtEmp[0].email + ">";
							string subject = "刪文通知";
							string body = "刪除時間:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "<BR><BR>" +
								"以下是原文<BR><HR>" + dtPostDetail[0].content;
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

				int PostMain_auto = dtPostDetail[0].PostMain_auto;
				dtPostDetail[0].Delete();
				Module.adPostDetail.Update(dtPostDetail);
				DataList1.DataBind();

				if(DataList1.Items.Count == 0) {
					ezClientDS.PostMainDataTable dtPostMain = Module.adPostMain.GetDataByAuto(PostMain_auto);
					if(dtPostMain.Count > 0) {
						dtPostMain[0].Delete();
						Module.adPostMain.Update(dtPostMain);
					}
					Response.Write("PostMain.aspx?BoardList_auto=" + BoardList_auto);
				}
			}
		}
		if(e.CommandName == "Praise") {
			if(e.CommandArgument.ToString() == Request.Cookies["ezFlow"]["Emp_id"].ToString()) {
				string script = "alert('自己讚美自己，只要放在心裡面就好了！');";
				if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "PraiseMsg")) {
					Page.ClientScript.RegisterStartupScript(typeof(string),"PraiseMsg",script,true);
				}
			}
			else {
				ezClientDS.PraiseRecordDataTable dtPraiseRecord = Module.adPraiseRecord.GetDataByOne(
					Convert.ToInt32(Request["PostMain_auto"]),e.CommandArgument.ToString(),Request.Cookies["ezFlow"]["Emp_id"].ToString());
				if(dtPraiseRecord.Count > 0) {
					string script = "alert('同一個主題同一個作者，只要讚美一次就好了！');";
					if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "PraiseMsg")) {
						Page.ClientScript.RegisterStartupScript(typeof(string), "PraiseMsg", script, true);
					}
				}
				else {
					ezClientDS.PraiseRecordRow rowPraiseRecord = dtPraiseRecord.NewPraiseRecordRow();
					rowPraiseRecord.PostMain_auto = Convert.ToInt32(Request["PostMain_auto"]);
					rowPraiseRecord.Emp_idAuthor = e.CommandArgument.ToString();
					rowPraiseRecord.Emp_id = Request.Cookies["ezFlow"]["Emp_id"].ToString();
					dtPraiseRecord.AddPraiseRecordRow(rowPraiseRecord);
					Module.adPraiseRecord.Update(dtPraiseRecord);

					ezClientDS.EmpInfoDataTable dtEmpInfo = Module.adEmpInfo.GetDataByEmp(e.CommandArgument.ToString());
					ezClientDS.EmpInfoRow rowEmpInfo = null;
					if(dtEmpInfo.Count == 0) {
						rowEmpInfo = dtEmpInfo.NewEmpInfoRow();
						rowEmpInfo.Emp_id = e.CommandArgument.ToString();
						rowEmpInfo.signText = "";
						rowEmpInfo.praiseCount = 0;
					}
					else rowEmpInfo = dtEmpInfo[0];
					rowEmpInfo.praiseCount++;
					if(dtEmpInfo.Count == 0) dtEmpInfo.AddEmpInfoRow(rowEmpInfo);

					Module.adEmpInfo.Update(dtEmpInfo);

					DataList1.DataBind();

					string script = "alert('感謝您給予一個讚美獎勵');";
					if(!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "PraiseMsg")) {
						Page.ClientScript.RegisterStartupScript(typeof(string), "PraiseMsg", script, true);
					}
				}
			}
		}
	}

	protected void bnNewPost_Click(object sender, EventArgs e) {
		Response.Redirect("Post.aspx?Flag=New&BoardList_auto=" + BoardList_auto + "&PostDetail_auto=0");
	}
}
