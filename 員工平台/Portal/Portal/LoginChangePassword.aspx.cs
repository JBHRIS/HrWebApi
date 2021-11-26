using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bll.Token.Vdb;
using Bll.UserPassword.Vdb;
using Dal.Dao.Share;
using Dal.Dao.Token;
using Dal.Dao.UserPassword;

namespace Portal
{
    public partial class LoginChangePassword : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Single)Master)._DivClass = "passwordBox animated fadeInDown";
            if (!this.IsPostBack)
            {
                if (Request.QueryString["key"] != null)
                {
                    txtResetKey.Text = Request.QueryString["key"];
                }
                else
                {
                    lblMsg.Text = "請點選信箱中的連結來重設密碼";
                    lblMsg.CssClass = "label-danger animated shake";
                }
                if (Request.QueryString["Company"] != null)
                {
                    var CompanyId = Request.QueryString["Company"];
                    var oShareCompany = new ShareCompanyDao();
                    var CompanySetting = oShareCompany.GetCompanySetting(CompanyId);

                    this.CompanySetting = CompanySetting;
                    var oConnection = new ConnectionDao();
                    var ConnectionCondition = new ConnectionConditions();
                    ConnectionCondition.DbName = CompanySetting.HrApiConnection;
                    var LoginTokenResult = oConnection.GetData(ConnectionCondition);
                    LoginToken = LoginTokenResult.Payload.ToString();
                    UnobtrusiveSession.Session["ConnectionToken"] = LoginToken;

                    HttpContext.Current.Response.Cookies.Add(new HttpCookie("CompanyId", CompanyId));
                    UnobtrusiveSession.Session["CompanySetting"] = CompanySetting;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.Text == "" || txtCheckPassword.Text == "" || txtNewPassword.Text != txtCheckPassword.Text || txtResetKey.Text == "")
            {
                lblMsg.CssClass = "label-danger animated shake";
                lblMsg.Text = "請確認輸入是否正確";
                return;
            }
            var rs = "";

            var LoginToken = UnobtrusiveSession.Session["ConnectionToken"] as string;

            var oChangePassword = new ChangePasswordDao();
            var ChangePasswordCond = new ChangePasswordConditions();
            ChangePasswordCond.AccessToken = LoginToken == null ? "" : LoginToken;
            ChangePasswordCond.RefreshToken = _User.RefreshToken;
            ChangePasswordCond.CompanySetting = CompanySetting;
            ChangePasswordCond.resetkey = txtResetKey.Text;
            ChangePasswordCond.newPw = txtNewPassword.Text;
            var Result = oChangePassword.GetData(ChangePasswordCond);

            if (Result.Status)
            {
                rs = "Success";
            }

            if (rs == "" || rs == null)
            {
                lblMsg.CssClass = "label-danger animated shake";
                lblMsg.Text = "請確認輸入是否正確1";
            }
            else if (rs == "Success")
            {
                Response.Redirect("Login.aspx");
                lblMsg.CssClass = "label-primary animated shake";
                lblMsg.Text = "密碼修改成功，回到登入頁重新登入";
            }
        }
    }
}