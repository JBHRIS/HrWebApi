using Dal.Dao.Share;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bll.Tools;

namespace Reply
{
    public partial class LoginValidate : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var oEncryptHepler = new EncryptHepler();
                var CompanyId = "";
                var EmpId = "";
                var EmpName = "";
                var Role = 2;
                //以上值用資料帶入
                if (Request.QueryString["Param"] != null && Request.QueryString["Param"] != "")
                {
                    var Parameter = oEncryptHepler.Decrypt(Request.QueryString["Param"]);
                    var UserData = JsonConvert.DeserializeObject<List<string>>(Parameter);
                    CompanyId = UserData[0];
                    EmpId = UserData[1];
                    EmpName = UserData[2];
                    Role = Convert.ToInt32(UserData[3]);
                }

                var oShareCompany = new ShareCompanyDao();
                var CompanySetting = oShareCompany.GetCompanySetting(CompanyId);

                var oUser = new User();
                oUser.UserCode = CompanyId + EmpId;
                oUser.CompanyId = CompanyId;
                oUser.EmpName = EmpName;
                oUser.RoleKey = Role;
                _AuthManager.SignIn(oUser, oUser.UserCode, CompanySetting);
                Response.Redirect("ProblemReturn.aspx");
            }
        }
    }
}