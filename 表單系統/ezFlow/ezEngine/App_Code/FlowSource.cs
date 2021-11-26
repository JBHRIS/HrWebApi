using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;


/// <summary>
/// FlowSource 的摘要描述
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class FlowSource : System.Web.Services.WebService {

    public FlowSource () {

        //如果使用設計的元件，請取消註解下行程式碼 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string GetMang(string Role) {
        CMan Man = COrg.GetManager(0, Role);
      return Man.idEmp;
    }
    
}

