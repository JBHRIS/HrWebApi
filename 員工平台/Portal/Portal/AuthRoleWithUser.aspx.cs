using Bll.UserRole.Vdb;
using Bll.Employee.Vdb;
using Bll;
using Dal.Dao.UserRole;
using Dal.Dao.Employee;
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
    public partial class AuthRoleWithUser : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                UnobtrusiveSession.Session["ActivePage"] = WebPage.GetActivePage;
                cblRole_DataBind();
                ddlUser_DataBind();

            }
        }
        public void LoadData(string Key = "")
        {

        }

        protected void cblRole_DataBind()
        {
            var rs = AccessData.GetRoleList(_User, CompanySetting);
            foreach (var r in rs.ToArray())
            {
                if (r.Code == "Admin" || r.Code == "Emp" || r.Code == "HR" || r.Code == "Manager")
                {
                    rs.Remove(r);
                }
            }
            cblRole.DataSource = rs;
            cblRole.DataBindings.DataTextField = "Name";
            cblRole.DataBindings.DataValueField = "Code";
            cblRole.DataBind();
        }

        protected void ddlUser_DataBind()
        {
            var rs = AccessData.GetPeopleList(_User, CompanySetting) ;
            ddlEmp.DataSource = rs;
            ddlEmp.DataTextField = "Text";
            ddlEmp.DataValueField = "Value";
            ddlEmp.DataBind();
        }

        
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (ddlEmp.SelectedValue == "")
            {
                lblMsg.CssClass = "badge badge-danger animated shake";
                lblMsg.Text = "請選擇員工";
                return;
            }
            var roleCodeList = cblRole.Items.Cast<ButtonListItem>();
            int i = 0, count = 0;
            foreach (var roleCode in roleCodeList)
            {
                count++;
                if (roleCode.Selected)
                {
                    var oInsertUserRole = new InsertUserRoleDao();
                    var InsertUserRoleCond = new InsertUserRoleConditions();
                    InsertUserRoleCond.AccessToken = _User.AccessToken;
                    InsertUserRoleCond.RefreshToken = _User.RefreshToken;
                    InsertUserRoleCond.CompanySetting = CompanySetting;
                    InsertUserRoleCond.nobr = ddlEmp.SelectedValue;
                    InsertUserRoleCond.roleCode = roleCode.Value;
                    var Result = oInsertUserRole.GetData(InsertUserRoleCond);
                    if (Result.Status)
                    {
                        if (Result.Data != null)
                        {
                            var rs = Result.Data as InsertUserRoleRow;
                            if (rs.Result)
                            {
                                i++;
                            }
                        }
                    }
                }
                else
                {
                    var oDeleteUserRole = new DeleteUserRoleDao();
                    var DeleteUserRoleCond = new DeleteUserRoleConditions();
                    DeleteUserRoleCond.AccessToken = _User.AccessToken;
                    DeleteUserRoleCond.RefreshToken = _User.RefreshToken;
                    DeleteUserRoleCond.CompanySetting = CompanySetting;
                    DeleteUserRoleCond.nobr = ddlEmp.SelectedValue;
                    DeleteUserRoleCond.roleCode = roleCode.Value;
                    var Result = oDeleteUserRole.GetData(DeleteUserRoleCond);
                    if (Result.Status)
                    {
                        if (Result.Data != null)
                        {
                            var rs = Result.Data as DeleteUserRoleRow;
                            if (rs.Result)
                            {
                                i++;
                            }
                        }
                    }
                }
            }
            if (i > 0)
            {
                lblMsg.CssClass = "badge badge-primary animated shake";
                lblMsg.Text = "更新成功";
            }
            else
            {
                lblMsg.CssClass = "badge badge-danger animated shake";
                lblMsg.Text = "更新失敗";
            }
        }

        protected void ddlEmp_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            foreach (ButtonListItem r in cblRole.Items)
            {
                r.Selected = false;
            }
            var User = ddlEmp.SelectedValue;
            var Nobr = new List<string>();
            Nobr.Add(User);

            var rs = new List<UserRoleRow>();
            var oUserRole = new UserRoleDao();
            var UserRoleCond = new UserRoleConditions();
            UserRoleCond.AccessToken = _User.AccessToken;
            UserRoleCond.RefreshToken = _User.RefreshToken;
            UserRoleCond.CompanySetting = CompanySetting;
            UserRoleCond.nobr = Nobr;
            var Result = oUserRole.GetData(UserRoleCond);
            if (Result.Status)
            {
                if (Result.Data != null)
                {
                    rs = Result.Data as List<UserRoleRow>;
                    foreach (var rTarget in rs[0].roleCode)
                    {
                        foreach (ButtonListItem r in cblRole.Items)
                        {
                            if(r.Value == rTarget)
                                r.Selected = true;
                        }

                    }
                }
            }
        }
    } 
}