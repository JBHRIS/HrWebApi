using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// SaveAbs 的摘要描述
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下一行。
// [System.Web.Script.Services.ScriptService]
public class SaveAbs : System.Web.Services.WebService
{
    public SaveAbs()
    {

        //如果使用設計的元件，請取消註解下行程式碼 
        //InitializeComponent(); 
    }

    [WebMethod]
    public bool Run(int ID)
    {
        int ProcessID = ID;
        localhost.Service oService = new localhost.Service();
        var rGetApView = oService.GetApView(ID);
        ProcessID = rGetApView.ProcessFlow_id;

        dcHRDataContext dcHR = new dcHRDataContext();
        dcFlowDataContext dcFlow = new dcFlowDataContext();
        dcFormDataContext dcForm = new dcFormDataContext();

        var rAppM = (from c in dcFlow.wfFormApp
                     where c.idProcess == ProcessID
                     select c).FirstOrDefault();

        var rsAppS = (from c in dcForm.wfAppAbs
                      where c.idProcess == ProcessID
                      select c).ToList();

        if (rAppM == null || rsAppS.Count == 0)
            return false;

        //表單流程結束記號
        rAppM.sState = rAppM.bSign ? "3" : rAppM.sState;

        List<string> lsNobr = new List<string>();
        lsNobr.Add(rAppM.sNobr);
        lsNobr.AddRange(rsAppS.Select(p => p.sNobr));

        var rsFormSignM = (from c in dcFlow.wfFormSignM
                           where c.idProcess == ProcessID
                           orderby c.dKeyDate
                           select c).ToList();

        var rsEmp = (from c in dcFlow.Emp
                     where lsNobr.Contains(c.id)
                     select c).ToList();

        string sSignNote = "";
        foreach (var rFormSignM in rsFormSignM)
            sSignNote += "<BR>" + rFormSignM.sName + "：" + rFormSignM.sNote;

        Dal.Dao.Att.AbsDao oAbsDao = new Dal.Dao.Att.AbsDao(dcHR.Connection);

        string sSubject = "【通知】(" + rAppM.sNobr + ")" + rAppM.sName + " 之請假單";
        string sBody = "";

        List<string> lsSendMail = new List<string>();

        var rEmp = (from c in rsEmp
                    where c.id == rAppM.sNobr
                    select c).FirstOrDefault();

        if (rEmp.email.Trim().Length > 0 && !lsSendMail.Contains(rEmp.email))
            lsSendMail.Add(rEmp.email);

        foreach (var rAppS in rsAppS)
        {
            if (rAppS.bSign)
            {
                int iPass = oAbsDao.AbsSave(rAppS.sNobr, rAppS.sHcode, rAppS.dDateB, rAppS.dDateE, rAppS.sTimeB, rAppS.sTimeE, rAppS.sNote, rAppM.sName, "", rAppM.sProcessID);
                rAppS.sState = "3";
            }

            sBody += ("此筆資料" + (rAppS.sState == "3" ? "核准" : "駁回")) + rAppS.sMailBody + "<BR><BR>";

            rEmp = (from c in rsEmp
                    where c.id == rAppS.sNobr
                    select c).FirstOrDefault();
            
            //啟動代理日期
            if (rEmp != null)
            {
                rEmp.dateB = rAppS.dDateTimeB;
                rEmp.dateE = rAppS.dDateTimeE;
            }

            if (rEmp.email.Trim().Length > 0 && !lsSendMail.Contains(rEmp.email))
                lsSendMail.Add(rEmp.email);
        }

        if (sBody.Length > 0)
        {
            foreach (var s in lsSendMail)
            {
                var rSendMail = new wfSendMail();
                rSendMail.sProcessID = ProcessID.ToString();
                rSendMail.idProcess = Convert.ToInt32(rSendMail.sProcessID);
                rSendMail.sGuid = Guid.NewGuid().ToString();
                rSendMail.sToAddress = s;
                rSendMail.sSubject = sSubject;
                rSendMail.sBody = sBody;
                rSendMail.bOnly = true;
                rSendMail.sKeyMan = rAppM.sNobr;
                rSendMail.dKeyDate = DateTime.Now;
                dcFlow.wfSendMail.InsertOnSubmit(rSendMail);
            }
        }

        dcForm.SubmitChanges();
        dcFlow.SubmitChanges();

        return true;
    }
}
