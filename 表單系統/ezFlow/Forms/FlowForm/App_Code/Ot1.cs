using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using JBHR.Dll;

/// <summary>
/// Ot1 的摘要描述
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下一行。
// [System.Web.Script.Services.ScriptService]
public class Ot1 : System.Web.Services.WebService
{
    public Ot1() { }

    [WebMethod]
    public bool Run(int ID)
    {
        int ProcessID = Flow.GetProcessID("ApView", ID);

        dcFlowDataContext dcFlow = new dcFlowDataContext();
        dcFormDataContext dcForm = new dcFormDataContext();

        var rAppM = (from c in dcFlow.wfFormApp
                     where c.idProcess == ProcessID
                     select c).FirstOrDefault();

        var dtAppS = from c in dcForm.wfAppOt1
                     where c.idProcess == ProcessID
                     //&& c.bSign
                     select c;

        var rSysVar = (from c in dcFlow.SysVar
                       select c).FirstOrDefault();

        var rsFormSignM = from c in dcFlow.wfFormSignM
                          where c.idProcess == ProcessID
                          && c.sNote.Trim().Length > 0
                          orderby c.dKeyDate
                          select c;

        string sNote = "";
        foreach (var rFormSignM in rsFormSignM)
            sNote += "<BR>" + rFormSignM.sName + "：" + rFormSignM.sNote;

        foreach (var rAppS in dtAppS)
        {
            string sSubject = "";
            string sBody = "";

            if (rAppS.bSign)
            {
                //JBHR.Dll.Att.OtCal.Ot1Save(rAppS.sNobr, rAppS.sRoteCode, rAppS.dDateB, rAppS.sTimeB, rAppS.sTimeE, rAppS.sOtcatCode, rAppS.sOtrcdCode, rAppS.sOtDeptCode != null ? rAppS.sOtDeptCode : rAppS.sDept, 0, rAppS.sNote, rAppM.sName + "e", 0, "", rAppS.bExceptionHour);
                rAppS.sState = "3";

                sSubject = "【通知】(" + rAppS.sNobr + ")" + rAppS.sName + " 之預估加班單(已核准)";
            }
            else
            {
                sSubject = "【通知】(" + rAppS.sNobr + ")" + rAppS.sName + " 之預估加班單(已退簽)";
            }

            sBody = rAppS.sMailBody;

            var rEmp = (from c in dcFlow.Emp
                        where c.id == rAppM.sNobr
                        select c).FirstOrDefault();

            if (rEmp != null && rEmp.email.Trim().Length > 0 && sBody != null && sBody.Length > 0)
            {
                var rSendMail = new wfSendMail();
                rSendMail.sProcessID = ProcessID.ToString();
                rSendMail.idProcess = Convert.ToInt32(rSendMail.sProcessID);
                rSendMail.sGuid = Guid.NewGuid().ToString();
                rSendMail.sToAddress = rEmp.email;
                rSendMail.sSubject = sSubject;
                rSendMail.sBody = sBody;
                rSendMail.bOnly = true;
                rSendMail.sKeyMan = rAppM.sNobr;
                rSendMail.dKeyDate = DateTime.Now;
                dcFlow.wfSendMail.InsertOnSubmit(rSendMail);
            }
        }

        rAppM.sState = (rAppM != null) && dtAppS.Count() > 0 ? "3" : "2";

        dcForm.SubmitChanges();
        dcFlow.SubmitChanges();

        return true;
    }
}