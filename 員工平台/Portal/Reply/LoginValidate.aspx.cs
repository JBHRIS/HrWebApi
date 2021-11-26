using Dal.Dao.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Reply
{
    public partial class LoginValidate : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var CompanyId = "";
                var EmpId = "";
                var EmpName = "";
                var Role = 2;
                //以上值用資料帶入
                if (Request.QueryString["CompanyId"] != null && Request.QueryString["CompanyId"] != "")
                    CompanyId = "";

                var oShareCompany = new ShareCompanyDao();
                var CompanySetting = oShareCompany.GetCompanySetting(CompanyId);

                var oUser = new User();
                oUser.UserCode = CompanyId + EmpId;
                oUser.CompanyId = CompanyId;
                oUser.EmpName = EmpName;
                oUser.RoleKey = Role;
                _AuthManager.SignIn(oUser, oUser.UserCode, CompanySetting);
                Response.Redirect("");
            }
        }
    }
}