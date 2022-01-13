using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bll.Tools;
using Dal;

namespace Performance
{
    public partial class ManageSystemUserEdit : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["AutoKey"] != null && Request.QueryString["AutoKey"] != "0")
                {
                    var r = (from c in dcShare.SystemUser
                             where c.AutoKey == Convert.ToInt32(Request.QueryString["AutoKey"])
                             select c).FirstOrDefault();
                    txtAccount.Text = r.AccountCode;
                    txtRoleKey.Text = r.RoleKey.ToString();
                }
            }
        }
        protected void btnReturn_Click(object sender, EventArgs e)
        {
            if (UnobtrusiveSession.Session["ActivePage"] != null)
            {
                var ReturnPage = (string)UnobtrusiveSession.Session["ActivePage"];

                Response.Redirect(ReturnPage);
            }
            else
                Response.Redirect("Index.aspx");
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtAccount.Text == "" || txtRoleKey.Text == "" || txtCheckPassword.Text == "" || txtPassword.Text == "" )
            {
                lblMsg.CssClass = "badge-danger badge";
                lblMsg.Text = "請確認資料是否輸入正確";
                return;
            }
            if (txtPassword.Text != txtCheckPassword.Text)
            { 
                lblMsg.CssClass = "badge-danger badge";
                lblMsg.Text = "密碼和確認密碼不一致，請確認後再試";
                return;
            }
            
            if (Request.QueryString["AutoKey"] != null && Request.QueryString["AutoKey"] != "0")
            {
                var r = (from c in dcShare.SystemUser
                         where c.AutoKey == Convert.ToInt32(Request.QueryString["AutoKey"])
                         select c).FirstOrDefault();
                if (r != null)
                {
                    r.AccountCode = txtAccount.Text;
                    r.AccountPassword = txtPassword.Text.ToSHA512();
                    r.MoneyPassword = "";
                    dcShare.SubmitChanges();
                    lblMsg.CssClass = "badge-primary badge";
                    lblMsg.Text = "更新成功";
                    if (UnobtrusiveSession.Session["ActivePage"] != null)
                    {
                        var ReturnPage = (string)UnobtrusiveSession.Session["ActivePage"];

                        Response.Redirect(ReturnPage);
                    }
                    else
                        Response.Redirect("Index.aspx");
                }
            }
            else
            {
                var oSystemUser = new SystemUser();
                oSystemUser.Code = Guid.NewGuid().ToString();
                oSystemUser.AccountCode = txtAccount.Text;
                oSystemUser.AccountPassword = txtPassword.Text.ToSHA512();
                oSystemUser.MoneyPassword = "";
                oSystemUser.RoleKey = Convert.ToInt32(txtRoleKey.Text);
                oSystemUser.InsertDate = DateTime.Now;
                oSystemUser.InsertMan = _User.EmpName;
                oSystemUser.DateA = DateTime.Now;
                oSystemUser.DateD = DateTime.MaxValue;
                oSystemUser.Status = "1";
                oSystemUser.UpdateDate = DateTime.Now;
                oSystemUser.UpdateMan = _User.EmpName;
                dcShare.SystemUser.InsertOnSubmit(oSystemUser);
                dcShare.SubmitChanges();
                lblMsg.CssClass = "badge-primary badge";
                lblMsg.Text = "新增成功";
                if (UnobtrusiveSession.Session["ActivePage"] != null)
                {
                    var ReturnPage = (string)UnobtrusiveSession.Session["ActivePage"];

                    Response.Redirect(ReturnPage);
                }
                else
                    Response.Redirect("Index.aspx");
            }
        }
    }
}