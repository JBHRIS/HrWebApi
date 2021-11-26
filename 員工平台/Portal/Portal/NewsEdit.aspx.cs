using Bll.News.Vdb;
using Dal.Dao.News;
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
using Bll.Token.Vdb;

namespace Portal
{
    public partial class NewsEdit : WebPageBase
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

            var rs = new List<NewsRow>();

            var oNews = new NewsDao();
            var NewsCond = new NewsConditions();
            NewsCond.AccessToken = _User.AccessToken;
            NewsCond.RefreshToken = _User.RefreshToken;
            NewsCond.CompanySetting = CompanySetting;
            var Result = oNews.GetData(NewsCond);
            if (Result.Status)
            {
                if (Result.Data != null)
                {
                    rs = Result.Data as List<NewsRow>;
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
            if (cn == "Edit")
            {
                Response.Redirect("NewsManage.aspx?AutoKey=" + ca);
            }
            if (cn == "Delete")
            {
                var oDeleteNewsById = new DeleteNewsByIdDao();
                var DeleteNewsByIdCond = new DeleteNewsByIdConditions();
                DeleteNewsByIdCond.AccessToken = _User.AccessToken;
                DeleteNewsByIdCond.RefreshToken = _User.RefreshToken;
                DeleteNewsByIdCond.CompanySetting = CompanySetting;
                DeleteNewsByIdCond.id = ca.ToString();
                var Result = oDeleteNewsById.GetData(DeleteNewsByIdCond);
                if (Result.Status)
                {
                    lblMsg.CssClass = "badge-primary animated shake";
                    lblMsg.Text = "已刪除";
                }
                else
                {
                    lblMsg.CssClass = "badge-danger animated shake";
                    lblMsg.Text = "刪除失敗";
                }
                lvMain.Rebind();
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewsManage.aspx?AutoKey=0");
        }
        protected void btnExportExcel_Click(object sender, EventArgs e)
        {


            var rs = new List<NewsRow>();

            var oNews = new NewsDao();
            var NewsCond = new NewsConditions();
            NewsCond.AccessToken = _User.AccessToken;
            NewsCond.RefreshToken = _User.RefreshToken;
            NewsCond.CompanySetting = CompanySetting;
            var Result = oNews.GetData(NewsCond);
            if (Result.Status)
            {
                if (Result.Data != null)
                {
                    rs = Result.Data as List<NewsRow>;
                }
            }

            var dt = rs.CopyToDataTable();

            //移除不顯示的欄位
            //if (dt.Columns.Contains("ListAbs")) dt.Columns.Remove("ListAbs");
            //if (dt.Columns.Contains("ListOt")) dt.Columns.Remove("ListOt");
            //if (dt.Columns.Contains("ListAbnormal")) dt.Columns.Remove("ListAbnormal");

            //更改欄位名稱
            var ListGroupCode = new List<string>();
            ListGroupCode.Add("News");
            AccessData.SetColumnsName(dt, ListGroupCode);

            var stream = CNPOI.RenderDataTableToExcel(dt);
            var FileName = Guid.NewGuid().ToString() + ".xls";

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