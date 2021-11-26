using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Improve 的摘要描述
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下一行。
// [System.Web.Script.Services.ScriptService]
public class Improve : System.Web.Services.WebService {

    public Improve () {    }

    [WebMethod]
    public bool Run(int ID)
    {
        int ProcessID = Flow.GetProcessID("ApView", ID);

        dcFlowDataContext dcFlow = new dcFlowDataContext();
        dcFormDataContext dcForm = new dcFormDataContext();

        var rAppM = (from c in dcFlow.wfFormApp
                     where c.idProcess == ProcessID
                     select c).FirstOrDefault();

        var dtAppS = from c in dcForm.wfAppImprove
                     where c.idProcess == ProcessID
                     && c.bSign
                     select c;

        foreach (var rAppS in dtAppS)
            rAppS.sState = "3";

        rAppM.sState = (rAppM != null) && dtAppS.Count() > 0 ? "3" : "2";

        dcForm.SubmitChanges();
        dcFlow.SubmitChanges();

        return true;
    }
}
