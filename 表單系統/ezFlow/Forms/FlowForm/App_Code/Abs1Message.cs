using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using JBHR.Dll;

/// <summary>
/// Abs1Message 的摘要描述
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下一行。
// [System.Web.Script.Services.ScriptService]
public class Abs1Message : System.Web.Services.WebService
{

    public Abs1Message()
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

        var rAppS = (from c in dcForm.wfAppAbs
                     where c.idProcess == ProcessID
                     && c.bSign
                     select c).FirstOrDefault();

        if (rAppM != null && rAppS != null)
        {
            var rSysVar = (from c in dcFlow.SysVar
                           select c).FirstOrDefault();

            if (rSysVar != null)
            {


            }
        }

        return true;
    }
}