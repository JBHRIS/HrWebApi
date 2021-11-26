using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using JBHR.Dll;

/// <summary>
/// AbsMessage 的摘要描述
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下一行。
// [System.Web.Script.Services.ScriptService]
public class AbsMessage : System.Web.Services.WebService
{

    public AbsMessage() { }

    [WebMethod]
    public bool Run(int ID)
    {
        int ProcessID = Flow.GetProcessID("ApView", ID);

        dcFlowDataContext dcFlow = new dcFlowDataContext();
        dcFormDataContext dcForm = new dcFormDataContext();

        var rAppM = (from c in dcFlow.wfFormApp
                     where c.idProcess == ProcessID
                     select c).FirstOrDefault();

        var dtAppS = from c in dcForm.wfAppAbs
                     where c.idProcess == ProcessID
                     && c.bSign
                     select c;

        var dtFormSignM = from c in dcFlow.wfFormSignM
                          where c.idProcess == ProcessID
                          select c;

        var rsFormSignM = dtFormSignM.Where(p => p.sNobr == "C11023");

        var rsMail = from c in dcForm.wfFormSendMail
                     where c.idProcess == ProcessID
                     select c;

        var rSysVar = (from c in dcFlow.SysVar
                       select c).FirstOrDefault();

        if (rSysVar != null)
        {
            string SignHtml = htmlSign(ProcessID);

            foreach (var rAppS in dtAppS)
            {
                if (!rsFormSignM.Any()) //sara有核過不用通知
                {
                    if (rAppM != null && rAppS != null)
                    {
                        if (rAppM.bAuth)    //一定要是主管才需要通知
                        {

                            //發信通知Sara
                            string body = "Dear Sara" + "<br><br>" +
                                          "There is a leave form has been approved,<br>" +
                                          "if you need to check,please click the link.<br><br>" +
                                          "<a href='" + rSysVar.urlRoot + "/Forms/FlowForm/Abs/Check.aspx?ApView=" + ID.ToString() + "'>Detail</a>";

                            Tools.SendMailThread(rSysVar.mailServer, rSysVar.senderMail, false, rSysVar.mailID, rSysVar.mailPW, "sarac@corsair.com", "The Leave Form Approved Notify", body);

                        }
                    }
                }

                //請假單上選的
                if (rAppS.sAgentNobr != null && rAppS.sAgentNobr.Trim().Length > 0)
                {
                    //發信通知職務代理人
                    string body = rAppS.sAgentName + "Hi" + "<br><br>" +
                                   rAppS.sName + "　" + rAppS.dDateTimeB.ToString() + "-" + rAppS.dDateTimeE.ToString() + "Leave(" + rAppS.sHname + ")<br>" +
                                  "Notification:You are the agents.<br><br>" +
                                  "Action items:<br>" +
                                  rAppS.sAgentNote + "<br>" +
                                  "Please help!";

                    var rAgent = (from c in dcFlow.Emp
                                  where c.id == rAppS.sAgentNobr.Trim()
                                  select c).FirstOrDefault();

                    if (rAgent != null && rAgent.email.Trim().Length > 0)
                        Tools.SendMailThread(rSysVar.mailServer, rSysVar.senderMail, false, rSysVar.mailID, rSysVar.mailPW, rAgent.email.Trim(), rSysVar.senderName + "-職務代理人通知", body);

                    //Flow.SetCheckAgentDefault(rAppS.sNobr, rAppS.sAgentNobr, rAppS.dDateTimeB, rAppS.dDateTimeE);
                }

                //通知使用者自訂的代理人
                var rsA = (from c in dcForm.wfAppAgent
                           where c.sNobr == rAppS.sNobr
                           select c).ToList();

                foreach (var rA in rsA)
                {
                    if (rA.sAgentMail != null && rA.sAgentMail.Trim().Length > 0)
                    {
                        //發信通知職務代理人
                        string body = rA.sAgentName + "Hi" + "<br><br>" +
                                       rAppS.sName + "　" + rAppS.dDateTimeB.ToString() + "-" + rAppS.dDateTimeE.ToString() + "Leave(" + rAppS.sHname + ")<br>" +
                                      "otification:You are the agent.<br><br>" +
                                      "Action items:<br>" +
                                      rAppS.sAgentNote + "<br>" +
                                      "Please help!";

                        Tools.SendMailThread(rSysVar.mailServer, rSysVar.senderMail, false, rSysVar.mailID, rSysVar.mailPW, rA.sAgentMail.Trim(), rSysVar.senderName + "-職務代理人通知", body);
                    }
                }
            }

            foreach (var rMail in rsMail)
            {
                //發信通知
                string body = "Dear" + rMail.sName + "<br><br>" +
                              "There is a leave form has been approved,<br>" +
                              "if you need to check,please click the link.<br><br>" +
                              "<a href='" + rSysVar.urlRoot + "/Forms/FlowForm/Abs/Check.aspx?ApView=" + ID.ToString() + "'>Detail</a><br><br>" +
                              (rMail.sContent == null ? "" : rMail.sContent.Trim()) + "<br>" +
                              SignHtml;

                Tools.SendMailThread(rSysVar.mailServer, rSysVar.senderMail, false, rSysVar.mailID, rSysVar.mailPW, rMail.sMail, "The Leave Form Approved Notify", body);
            }
        }

        return true;
    }

    public string htmlSign(int iProcessID)
    {
        dcFlowDataContext dcFlow = new dcFlowDataContext();

        var dtSignM = (from c in dcFlow.wfFormSignM
                       where c.idProcess == iProcessID
                       orderby c.dKeyDate
                       select c).CopyToDataTable();

        dtSignM.Columns.Remove("iAutoKey");
        dtSignM.Columns.Remove("sFormCode");
        dtSignM.Columns.Remove("sFormName");
        dtSignM.Columns.Remove("sProcessID");
        dtSignM.Columns.Remove("idProcess");
        dtSignM.Columns.Remove("sKey");
        dtSignM.Columns.Remove("sNobr");
        dtSignM.Columns.Remove("sDept");
        dtSignM.Columns.Remove("sDeptName");
        dtSignM.Columns.Remove("sJob");
        dtSignM.Columns.Remove("sJobName");
        dtSignM.Columns.Remove("sRole");
        dtSignM.Columns.Remove("bSign");
        dtSignM.Columns.Remove("sSign");

        dtSignM.Columns["sName"].ColumnName = "姓名 Name";
        dtSignM.Columns["sNote"].ColumnName = "簽核內容 Sign-off";
        dtSignM.Columns["dKeyDate"].ColumnName = "簽核日期時間 Sign-off Time";

        return JBHR.Dll.Tools.ConvertToHtmlFile(dtSignM);
    }
}