using Bll.Menu.Vdb;
using Bll.System.Vdb;
using Dal.Dao.Menu;
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
    public partial class AuthMenu : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                UnobtrusiveSession.Session["ActivePage"] = WebPage.GetActivePage;
                //ddlMenu_Databind();
            }
        }
        public void LoadData(string Key = "")
        {

        }
        protected void lvMain_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            var oAllMenu = new AllMenuDao();
            var AllMenuCond = new AllMenuConditions();
            AllMenuCond.AccessToken = _User.AccessToken;
            AllMenuCond.RefreshToken = _User.RefreshToken;
            AllMenuCond.CompanySetting = CompanySetting;
            AllMenuCond.code = "Root";
            var rs = new List<AllMenuRow>();

            var Result = oAllMenu.GetData(AllMenuCond);
            if (Result.Status)
            {
                if (Result.Data != null)
                {
                    rs = Result.Data as List<AllMenuRow>;
                }
            }
            lvMain.DataSource = rs;
            var Script = "$(document).ready(function() {$('.footable').footable();});";
            ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
        }
        protected void lvMain_ItemCommand(object sender, RadListViewCommandEventArgs e)
        {
            var cn = e.CommandName;
            var ca = e.CommandArgument;
            if (cn == "Insert")
            {
                Response.Redirect("AuthMenuEdit.aspx?InsertKey=" + ca);
            }
            if (cn == "Edit")
            {
                Response.Redirect("AuthMenuEdit.aspx?AutoKey=" + ca);
            }
            if (cn == "Delete")
            {
                var oDeleteMenu = new DeleteMenuDao();
                var DeleteMenuCond = new DeleteMenuConditions();
                DeleteMenuCond.AccessToken = _User.AccessToken;
                DeleteMenuCond.RefreshToken = _User.RefreshToken;
                DeleteMenuCond.CompanySetting = CompanySetting;
                DeleteMenuCond.Code = ca.ToString();
                var Result = oDeleteMenu.GetData(DeleteMenuCond);
                if (Result.Status)
                {
                    if (Result.Data != null)
                    {
                        var rs = Result.Data as DeleteMenuRow;
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
                lvMain.Rebind();
            }
            if (cn == "Copy")
            {
                Response.Redirect("AuthMenuEdit.aspx?Copy=" + ca);
            }
        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            

            var rs = new List<AllMenuRow>();

            //向api取得驗証
            var oAllMenu = new AllMenuDao();
            var AllMenuCond = new AllMenuConditions();
            AllMenuCond.AccessToken = _User.AccessToken;
            AllMenuCond.RefreshToken = _User.RefreshToken;
            AllMenuCond.CompanySetting = CompanySetting;
            AllMenuCond.code = "Root";

            var Result = oAllMenu.GetData(AllMenuCond);

            if (Result.Status)
            {
                if (Result.Data != null)
                {
                    rs = Result.Data as List<AllMenuRow>;
                }
            }

            var dt = rs.CopyToDataTable();

            //移除不顯示的欄位
            if (dt.Columns.Contains("TypeCode")) dt.Columns.Remove("TypeCode");
            if (dt.Columns.Contains("TypeName")) dt.Columns.Remove("TypeName");
            if (dt.Columns.Contains("FilePath")) dt.Columns.Remove("FilePath");
            if (dt.Columns.Contains("RoleKey")) dt.Columns.Remove("RoleKey");
            if (dt.Columns.Contains("PathName")) dt.Columns.Remove("PathName");
            if (dt.Columns.Contains("IsAuth")) dt.Columns.Remove("IsAuth");
            //if (dt.Columns.Contains("ListAbs")) dt.Columns.Remove("ListAbs");
            //if (dt.Columns.Contains("ListOt")) dt.Columns.Remove("ListOt");
            //if (dt.Columns.Contains("ListAbnormal")) dt.Columns.Remove("ListAbnormal");

            //更改欄位名稱
            var ListGroupCode = new List<string>();
            ListGroupCode.Add("Menu");
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
        //protected void ddlMenu_Databind()
        //{
        //    //從Main.Master中取得Menu後建立Tree
        //    var Value = new List<SystemPageRow>();
        //    if (WebPage.DataCache && UnobtrusiveSession.Session["SystemPage"] != null)
        //    {
        //        Value = (List<SystemPageRow>)UnobtrusiveSession.Session["SystemPage"];
        //    }
        //    else
        //    {

        //        var oMenu = new MenuDao();
        //        var MenuCond = new MenuConditions();
        //        MenuCond.AccessToken = _User.AccessToken;
        //        MenuCond.RefreshToken = _User.RefreshToken;
        //        MenuCond.code = "Menu";
        //        var rs = new List<MenuRow>();

        //        var Result = oMenu.GetData(MenuCond);
        //        if (Result.Status)
        //        {
        //            if (Result.Data != null)
        //            {
        //                rs = Result.Data as List<MenuRow>;
        //            }
        //        }

        //        foreach (var rTarget in rs)
        //        {
        //            var rSystemPage = new SystemPageRow();
        //            rSystemPage.TypeCode = rTarget.TypeCode;
        //            rSystemPage.TypeName = rTarget.TypeName;
        //            rSystemPage.Code = rTarget.Code;
        //            rSystemPage.FilePath = rTarget.FilePath;
        //            rSystemPage.FileName = rTarget.FileName;
        //            rSystemPage.FileTitle = rTarget.FileTitle;
        //            rSystemPage.RoleKey = rTarget.RoleKey;
        //            rSystemPage.ParentCode = rTarget.ParentCode;
        //            rSystemPage.PathCode = rTarget.PathCode;
        //            rSystemPage.PathName = rTarget.PathName;
        //            rSystemPage.IsAuth = rTarget.IsAuth;
        //            Value.Add(rSystemPage);
        //        }
        //    }

        //    var ListId = new Dictionary<string, int>();

        //    //處理代碼資料
        //    int i = 1;
        //    foreach (var rVdb in Value)
        //    {
        //        //產生id
        //        ListId.Add(rVdb.Code, i);
        //        rVdb.CodeId = i;

        //        i++;
        //    }

        //    foreach (var r in Value)
        //    {
        //        //將上層的代碼轉換為id
        //        if (ListId.ContainsKey(r.ParentCode))
        //            r.ParentId = ListId[r.ParentCode];
        //        else
        //            r.ParentId = 0;  //如果沒有找到 就以0取代
        //    }

        //    ddlMenu.DataSource = Value;
        //    ddlMenu.DataValueField = "Code";
        //    ddlMenu.DataTextField = "FileTitle";
        //    ddlMenu.DataFieldID = "CodeId";
        //    ddlMenu.DataFieldParentID = "ParentId";
        //    ddlMenu.DataBind();

        //    ddlMenu.ExpandAllDropDownNodes();
        //}
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            Response.Redirect("AuthMenuEdit.aspx");
        }
    } 
}