using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using JBHR.Dll;

/// <summary>
/// Return 的摘要描述
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下一行。
// [System.Web.Script.Services.ScriptService]
public class Return : System.Web.Services.WebService
{
    public Return() { }

    [WebMethod]
    public bool Run(int ID)
    {
        int ProcessID = Flow.GetProcessID("ApView", ID);

        dcFlowDataContext dcFlow = new dcFlowDataContext();
        dcFormDataContext dcForm = new dcFormDataContext();

        var rAppM = (from c in dcFlow.wfFormApp
                     where c.idProcess == ProcessID
                     select c).FirstOrDefault();

        var rAppS = (from c in dcForm.wfAppReturn
                     where c.idProcess == ProcessID
                     && c.bSign
                     select c).FirstOrDefault();

        if (rAppM != null && rAppS != null)
        {
            Att.AbsCal.AbsSave(rAppS.sNobr, "U", rAppS.dDateB, rAppS.dDateE, rAppS.sTimeB, rAppS.sTimeE, "", rAppS.sNote, rAppM.sName + "e", "", 0);
            rAppS.sState = "3";

            var rEmpBase = JBHR.Dll.Bas.EmpBase(rAppS.sNobr).FirstOrDefault();
            if (rEmpBase != null)
            {
                var rSysVar = (from c in dcFlow.SysVar
                               select c).FirstOrDefault();

                if (rSysVar != null)
                {
                    var dtContact = from c in dcFlow.wfFormCode
                                    where c.sCategory == "ReturnWork"
                                    //&& c.sCode == rEmpBase.sWrokcd.Trim()
                                    select c;

                    //發信通知聯絡人
                    foreach (var rContact in dtContact.ToList())
                    {
                        if (rContact != null && rContact.sContent != null)
                        {
                            string[] arrContent = rContact.sContent.Split(',');
                            foreach (string ss in arrContent)
                            {
                                if (ss.Trim().Length > 0)
                                {
                                    string body = rContact.sName + ",您好...<br><br>" +
                                          "這封信，是由 電子簽核系統 所發出的。<br>" +
                                          "<br><br>" +
                                          "返台申請單有您的代辦事項，請您點以下連結前往處理。" +
                                          "<br><br>" +
                                          "<a href='" + rSysVar.urlRoot + "/Forms/FlowForm/Return/Check.aspx?ApView=" + ID.ToString() + "'>代辦事項</a>";

                                    Tools.SendMailThread(rSysVar.mailServer, rSysVar.senderMail, false, rSysVar.mailID, rSysVar.mailPW, ss, rSysVar.senderName, body);
                                }
                            }
                        }
                    }
                }
            }
        }

        rAppM.sState = (rAppM != null) && rAppS != null ? "3" : "2";

        dcForm.SubmitChanges();
        dcFlow.SubmitChanges();

        return true;
    }
}