using Bll.Role.Vdb;
using Bll.System.Vdb;
using Dal.Dao.Role;
using Bll.Tools;
using Dal.Dao.Attendance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.Design;
using Telerik.Web.UI;
using System.Text;


namespace Portal
{
    public partial class AuthRoleEdit : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["AutoKey"] != null)
                {
                    var rs = new List<RoleRow>();
                    if (WebPage.DataCache && UnobtrusiveSession.Session["RoleList"] != null)
                    {
                        rs = UnobtrusiveSession.Session["RoleList"] as List<RoleRow>;
                    }
                    else
                    {
                        var oNews = new RoleDao();
                        var NewsCond = new RoleConditions();
                        NewsCond.AccessToken = _User.AccessToken;
                        NewsCond.RefreshToken = _User.RefreshToken;
                        NewsCond.CompanySetting = CompanySetting;
                        var Result = oNews.GetData(NewsCond);
                        if (Result.Status)
                        {
                            if (Result.Data != null)
                            {
                                rs = Result.Data as List<RoleRow>;
                            }
                        }
                    }

                    var rsData = (from c in rs
                                  where c.Code == Request.QueryString["AutoKey"]
                                  select c).FirstOrDefault();
                    txtCode.Text = rsData.Code;
                    txtCode.Enabled = false;
                    txtName.Text = rsData.Name;
                    //cbIsAdminRole.Checked = rsData.IsAdminRole;
                    cbIsVisible.Checked = rsData.IsVisible;
                }
            }
        }
        public void LoadData(string Key = "")
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtCode.Text == "" || txtName.Text == "")
            {
                lblMsg.CssClass = "badge badge-danger";
                lblMsg.Text = "請確認資料是否輸入正確";
                return;
            }
            if (Request.QueryString["AutoKey"] == null)
            {
                var oInsertRole = new InsertRoleDao();
                var InsertRoleCond = new InsertRoleConditions();
                InsertRoleCond.AccessToken = _User.AccessToken;
                InsertRoleCond.RefreshToken = _User.RefreshToken;
                InsertRoleCond.CompanySetting = CompanySetting;
                InsertRoleCond.Code = txtCode.Text;
                InsertRoleCond.name = txtName.Text;
                InsertRoleCond.isAdminRole = false;
                InsertRoleCond.isVisible = true;
                var Result = oInsertRole.GetData(InsertRoleCond);
                if (Result.Status)
                {
                    if (Result.Data != null)
                    {
                        var rs = Result.Data as InsertRoleRow;
                        if (rs.Result)
                        {
                            lblMsg.CssClass = "badge badge-primary";
                            lblMsg.Text = "新增成功";
                        }
                        else
                        {
                            lblMsg.CssClass = "badge badge-danger";
                            lblMsg.Text = "新增失敗1";
                        }
                    }
                    else
                    {
                        lblMsg.CssClass = "badge badge-danger";
                        lblMsg.Text = "新增失敗2";
                    }
                }
            }
            else
            {
                var oUpdateRole = new UpdateRoleDao();
                var UpdateRoleCond = new UpdateRoleConditions();
                UpdateRoleCond.AccessToken = _User.AccessToken;
                UpdateRoleCond.RefreshToken = _User.RefreshToken;
                UpdateRoleCond.CompanySetting = CompanySetting;
                UpdateRoleCond.Code = txtCode.Text;
                UpdateRoleCond.name = txtName.Text;
                UpdateRoleCond.isAdminRole = txtCode.Text == "Admin";
                UpdateRoleCond.isVisible = true;
                var Result = oUpdateRole.GetData(UpdateRoleCond);
                if (Result.Status)
                {
                    if (Result.Data != null)
                    {
                        var rs = Result.Data as UpdateRoleRow;
                        if (rs.Result)
                        {
                            lblMsg.CssClass = "badge badge-primary";
                            lblMsg.Text = "更新成功";
                        }
                        else
                        {
                            lblMsg.CssClass = "badge badge-danger";
                            lblMsg.Text = "更新失敗1";
                        }
                    }
                    else
                    {
                        lblMsg.CssClass = "badge badge-danger";
                        lblMsg.Text = "更新失敗2";
                    }
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

        
    } 
}