using Bll.ApiVoid.Vdb;
using Dal.Dao.ApiVoid;
using System;
using System.Collections.Generic;
using Telerik.Web.UI;
using System.Text;
using System.Web;
using System.Web.UI;

namespace Portal
{
    public partial class AuthApi : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                UnobtrusiveSession.Session["ActivePage"] = WebPage.GetActivePage;
                //ddlApiVoid_Databind();
            }
        }
        public void LoadData(string Key = "")
        {

        }
        protected void lvMain_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            var rs = AccessData.GetApiList(_User,CompanySetting);
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
                Response.Redirect("AuthApiEdit.aspx?AutoKey="+ca.ToString());
            }
            if (cn == "Delete")
            {
                var oDeleteApiVoid = new DeleteApiVoidDao();
                var DeleteApiVoidCond = new DeleteApiVoidConditions();
                DeleteApiVoidCond.AccessToken = _User.AccessToken;
                DeleteApiVoidCond.RefreshToken = _User.RefreshToken;
                DeleteApiVoidCond.CompanySetting = CompanySetting;
                DeleteApiVoidCond.Code = ca.ToString();
                var Result = oDeleteApiVoid.GetData(DeleteApiVoidCond);
                if (Result.Status)
                {
                    if (Result.Data != null)
                    {
                        lblMsg.CssClass = "badge-primary animated shake";
                        lblMsg.Text = "已刪除";
                    }
                    else
                    {
                        lblMsg.CssClass = "badge badge-danger animated shake";
                        lblMsg.Text = "刪除失敗2";
                    }
                }
                lvMain.Rebind();
            }
        }
        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            var rs = new List<ApiVoidRow>();

            //向api取得驗証
            var oApiVoid = new ApiVoidDao();
            var ApiVoidCond = new ApiVoidConditions();
            ApiVoidCond.AccessToken = _User.AccessToken;
            ApiVoidCond.RefreshToken = _User.RefreshToken;
            ApiVoidCond.CompanySetting = CompanySetting;

            var Result = oApiVoid.GetData(ApiVoidCond);

            if (Result.Status)
            {
                if (Result.Data != null)
                {
                    rs = Result.Data as List<ApiVoidRow>;
                }
            }

            var dt = rs.CopyToDataTable();

            //移除不顯示的欄位
            //if (dt.Columns.Contains("ListAbs")) dt.Columns.Remove("ListAbs");
            //if (dt.Columns.Contains("ListOt")) dt.Columns.Remove("ListOt");
            //if (dt.Columns.Contains("ListAbnormal")) dt.Columns.Remove("ListAbnormal");

            //更改欄位名稱
            var ListGroupCode = new List<string>();
            ListGroupCode.Add("ApiVoid");
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
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            Response.Redirect("AuthApiEdit.aspx");
        }
        
    } 
}