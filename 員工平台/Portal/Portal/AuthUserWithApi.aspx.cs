using Bll.UserRole.Vdb;
using Bll.System.Vdb;
using Dal.Dao.UserRole;
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
    public partial class AuthUserWithApi : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                UnobtrusiveSession.Session["ActivePage"] = WebPage.GetActivePage;
                ddlPage_DataBind();
                ddlUser_DataBind();
            }
        }
        public void LoadData(string Key = "")
        {

        }

        protected void ddlPage_DataBind()
        {
            var Value = AccessData.GetMenuList(_User);

            var ListId = new Dictionary<string, int>();
            //處理代碼資料
            int i = 1;
            foreach (var rVdb in Value)
            {
                //產生id
                ListId.Add(rVdb.Code, i);
                rVdb.CodeId = i;

                i++;
            }

            foreach (var r in Value)
            {
                //將上層的代碼轉換為id
                if (ListId.ContainsKey(r.ParentCode))
                    r.ParentId = ListId[r.ParentCode];
                else
                    r.ParentId = 0;  //如果沒有找到 就以0取代
            }

            ddlPage.DataSource = Value;
            ddlPage.DataValueField = "Code";
            ddlPage.DataTextField = "FileTitle";
            ddlPage.DataFieldID = "CodeId";
            ddlPage.DataFieldParentID = "ParentId";
            ddlPage.DataBind();
        }

        protected void ddlUser_DataBind()
        {
            var rs = AccessData.GetDeptListEmp(_User);

            ddlUser.DataSource = rs;
            ddlUser.DataTextField = "Text";
            ddlUser.DataValueField = "Value";
            ddlUser.DataBind();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
        }

        protected void ddlUser_EntryAdded(object sender, DropDownTreeEntryEventArgs e)
        {
            var User = ddlUser.SelectedValue;
            var Nobr = new List<string>();
            Nobr.Add(ddlPage.SelectedValue);

            var oUserRole = new UserRoleDao();
            var UserRoleCond = new UserRoleConditions();
            UserRoleCond.AccessToken = _User.AccessToken;
            UserRoleCond.RefreshToken = _User.RefreshToken;
            UserRoleCond.nobr = Nobr;
            var Result = oUserRole.GetData(UserRoleCond);
            if (Result.Status)
            {
                if (Result.Data != null)
                { 
                
                }
                    //var rs = Result.Data as 
            }

        }
    } 
}