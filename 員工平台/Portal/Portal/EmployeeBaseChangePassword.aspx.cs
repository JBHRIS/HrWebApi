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
    public partial class EmployeeBaseChangePassword : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //((Single)Master)._DivClass = "passwordBox animated fadeInDown";
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtOldPassword.Text == "" || txtNewPassword.Text == "")
            {
                lblMsg.CssClass = "label-danger animated shake";
                lblMsg.Text = "請確認輸入是否正確";
                return;
            }
            if (txtNewPassword.Text != txtCheckPassword.Text)
            {
                lblMsg.CssClass = "label-danger animated shake";
                lblMsg.Text = "確認密碼不正確，請確認後重新輸入";
                return;
            }

            var oUpdatePassword = new UpdatePasswordDao();
            var UpdatePasswordCond = new UpdatePasswordConditions();
            UpdatePasswordCond.AccessToken = _User.AccessToken;
            UpdatePasswordCond.RefreshToken = _User.RefreshToken;
            UpdatePasswordCond.CompanySetting = CompanySetting;
            UpdatePasswordCond.oldPw = txtOldPassword.Text;
            UpdatePasswordCond.newPw = txtNewPassword.Text;
                
            var Result = oUpdatePassword.GetData(UpdatePasswordCond);
            if (Result.Status)
            {
                lblMsg.CssClass = "label-primary animated shake";
                lblMsg.Text = "密碼已成功修改";
                Response.Redirect("Login.aspx?Param=Logout");
            }
            else
            {
                lblMsg.CssClass = "label-danger animated shake";
                lblMsg.Text = "請確認輸入是否正確";
            }
            
            
        }
    }
}