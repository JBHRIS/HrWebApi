using Bll.Role.Vdb;
using Bll.System.Vdb;
using Dal.Dao.Role;
using Bll.Tools;
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
    public partial class AuthRole : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //News_DataBind();
                UnobtrusiveSession.Session["ActivePage"] = WebPage.GetActivePage;
            }
        }
        public void LoadData(string Key = "")
        {

        }
        protected void lvMain_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            var rs = new List<RoleRow>();
            rs = AccessData.GetRoleList(_User, CompanySetting);
            var rsList = (from c in rs
                          where c.IsVisible == true
                          select c).ToList();
            lvMain.DataSource = rs;

            var Script = "$(document).ready(function() {$('.footable').footable();});";
            ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
        }
        protected void lvMain_ItemCommand(object sender, RadListViewCommandEventArgs e)
        {
            var cn = e.CommandName;
            var ca = e.CommandArgument;
            
            if (cn == "Edit")
            {
                Response.Redirect("AuthRoleEdit.aspx?AutoKey=" + ca);
            }
            if (cn == "Delete")
            {
                var oDeleteRole = new DeleteRoleDao();
                var DeleteRoleCond = new DeleteRoleConditions();
                DeleteRoleCond.AccessToken = _User.AccessToken;
                DeleteRoleCond.RefreshToken = _User.RefreshToken;
                DeleteRoleCond.CompanySetting = CompanySetting;
                DeleteRoleCond.Code = ca.ToString();
                var Result = oDeleteRole.GetData(DeleteRoleCond);
                if (Result.Status)
                {
                    if (Result.Data != null)
                    {
                        var rs = Result.Data as DeleteRoleRow;
                        if (rs.Result)
                        {
                            lblMsg.CssClass = "badge badge-primary animated shake";
                            lblMsg.Text = "刪除成功";
                        }
                        else
                        {
                            lblMsg.CssClass = "badge badge-danger animated shake";
                            lblMsg.Text = "刪除失敗1";
                        }
                    }
                    else
                    {
                        lblMsg.CssClass = "badge badge-danger animated shake";
                        lblMsg.Text = "刪除失敗2";
                    }
                }
            }
        }
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            Response.Redirect("AuthRoleEdit.aspx");
        }
        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            var rs = AccessData.GetRoleList(_User, CompanySetting);
            var dt = rs.CopyToDataTable();

            //移除不顯示的欄位

            //更改欄位名稱
            var ListGroupCode = new List<string>();
            ListGroupCode.Add("AuthRole");
            AccessData.SetColumnsName(dt, ListGroupCode);

            var stream = CNPOI.RenderDataTableToExcel(dt);
            var FileName = (Page.Master as Main).FormTitle + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";

            Byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, int.Parse(stream.Length.ToString()));
            stream.Close();

            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=" + HttpUtility.UrlEncode(FileName, Encoding.UTF8));
            //Response.ContentType = "application/vnd.ms-excel";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.OutputStream.Write(bytes, 0, bytes.Length);
            Response.OutputStream.Flush();
            Response.OutputStream.Close();
            Response.Flush();
            Response.End();
        }
    } 
}