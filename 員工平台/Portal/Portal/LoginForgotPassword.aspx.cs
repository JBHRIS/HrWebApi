using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bll.UserPassword.Vdb;
using Dal.Dao.UserPassword;

namespace Portal
{
    public partial class LoginForgotPassword : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Single)Master)._DivClass = "passwordBox animated fadeInDown";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtEmpId.Text == "" || txtIdentifyNO.Text == "" || txtEmail.Text == "")
            {
                lblMsg.Text = "請確認輸入是否正確";
                return;
            }
            var LoginToken = UnobtrusiveSession.Session["ConnectionToken"] as string;
            var oVerifyIdentity = new VerifyIdentityDao();
            var VerifyIdentityCond = new VerifyIdentityConditions();
            VerifyIdentityCond.AccessToken = LoginToken == null ? "" : LoginToken;
            VerifyIdentityCond.RefreshToken = _User.RefreshToken;
            VerifyIdentityCond.CompanySetting = CompanySetting;
            VerifyIdentityCond.email = txtEmail.Text;
            VerifyIdentityCond.idNo = txtIdentifyNO.Text;
            VerifyIdentityCond.nobr = txtEmpId.Text;
            VerifyIdentityCond.redirectUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf('/')) + "/LoginChangePassword.aspx";
            VerifyIdentityCond.redirectQueryString = CompanySetting != null ? "&Company=" + CompanySetting.AccountCode : "";
            var Result = oVerifyIdentity.GetData(VerifyIdentityCond);
            if (Result.Status)
            {
                lblMsg.CssClass = "label-primary animated shake";
                lblMsg.Text = "已發送認證信件至您的信箱";
            }
            else
            {
                lblMsg.Text = "請確認輸入是否正確";
            }
            
        }
    }
}