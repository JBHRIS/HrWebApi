using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// AbsSetManage 的摘要描述
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下一行。
// [System.Web.Script.Services.ScriptService]
public class AbsSetManage : System.Web.Services.WebService
{

    public AbsSetManage()
    {

        //如果使用設計的元件，請取消註解下行程式碼 
        //InitializeComponent(); 
    }

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
                     select c;

        var rFormSignM = (from c in dcFlow.wfFormSignM
                          where c.idProcess == ProcessID
                          orderby c.dKeyDate descending
                          select c).FirstOrDefault();

        if (rFormSignM != null)
        {
            string sNobr = JBHR.Dll.Bas.GetDeptmManage(rFormSignM.sNobr, "");
            if (sNobr.Trim().Length > 0)
                foreach (var rAppS in dtAppS)
                    rAppS.sReserve3 = sNobr;

            dcForm.SubmitChanges();
        }

        return true;
    }
}