using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Test 的摘要描述
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下一行。
// [System.Web.Script.Services.ScriptService]
public class Test : System.Web.Services.WebService {

    public Test () {

        //如果使用設計的元件，請取消註解下行程式碼 
        //InitializeComponent(); 
    }

    [WebMethod]
    public bool Run(int ID)
    {
        //int ProcessID = Flow.GetProcessID("ApView", ID);
        int ProcessID = 7;

        dcFlowDataContext dcFlow = new dcFlowDataContext();

        var rAppM = (from c in dcFlow.wfFormApp
                     where c.idProcess == ProcessID
                     select c).FirstOrDefault();

        rAppM.sState = "3";

        dcFlow.SubmitChanges();

        return true;
    }
    
}

