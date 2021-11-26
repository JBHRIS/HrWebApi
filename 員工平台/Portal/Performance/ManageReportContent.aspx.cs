using Bll;
using Bll.Tools;
using Dal;
using Dal.Dao;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Performance
{
    public partial class ManageReportContent : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                UnobtrusiveSession.Session["ActivePage"] = WebPage.GetActivePage;

                ddlReportType_DataBind();
                ddlReportContent_DataBind();
            }
        }

        public void ddlReportType_DataBind()
        {
            var rs = (from c in dcMain.PerformanceReportType
                      select new TextValueRow
                      {
                          Value = c.Code,
                          Text = c.Name,
                      }).ToList();

            ddlReportType.DataSource = rs;
            ddlReportType.DataTextField = "Text";
            ddlReportType.DataValueField = "Value";
            ddlReportType.DataBind();

            if (UnobtrusiveSession.Session["ReportType"] != null)
            {
                var ReportType = (string)UnobtrusiveSession.Session["ReportType"];
                if (ddlReportType.FindItemByValue(ReportType) != null)
                    ddlReportType.FindItemByValue(ReportType).Selected = true;
            }
        }

        public void ddlReportContent_DataBind()
        {
            var rs = oMainDao.ShareCodeTextValue("ReportContent");

            var r = new TextValueRow();
            r.Text = "全部";
            r.Value = "0";
            r.Sort = 0;
            rs.Add(r);

            rs = rs.OrderBy(p => p.Sort).ToList();

            ddlReportContent.DataSource = rs;
            ddlReportContent.DataTextField = "Text";
            ddlReportContent.DataValueField = "Value";
            ddlReportContent.DataBind();

            if (UnobtrusiveSession.Session["ReportContent"] != null)
            {
                var ReportContent = (string)UnobtrusiveSession.Session["ReportContent"];
                if (ddlReportContent.FindItemByValue(ReportContent) != null)
                    ddlReportContent.FindItemByValue(ReportContent).Selected = true;
            }
        }

        protected void ddlReportType_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            lvMain.Rebind();

            if (ddlReportType.SelectedItem != null)
                UnobtrusiveSession.Session["ReportType"] = ddlReportType.SelectedItem.Value;
        }

        protected void ddlReportContent_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            lvMain.Rebind();

            if (ddlReportContent.SelectedItem != null)              
                UnobtrusiveSession.Session["ReportContent"] = ddlReportContent.SelectedItem.Value;
        }

        public void _DataBind()
        {

        }

        public class ReportContentRow
        {
            public int AutoKey { get; set; }
            public string Code { get; set; }
            public string ReportContentCode { get; set; }
            public string ReportContentName { get; set; }
            public string ContentTargetType { get; set; }
            public string ContentTargetRef { get; set; }
            public int ReportContentSort { get; set; }
            public int Sort { get; set; }
            public string UpdateMan { get; set; }
            public DateTime UpdateDate { get; set; }
        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (ddlReportType.SelectedItem == null || ddlReportContent.SelectedItem ==  null)
                return;

            var ReportTypeCode = ddlReportType.SelectedItem.Value;
            var ReportContentCode = ddlReportContent.SelectedItem.Value;

            var rs = (from c in dcMain.PerformanceReportContent
                      where c.PerformanceReportTypeCode == ReportTypeCode
                      && (ReportContentCode == "0" || c.ReportContentCode == ReportContentCode)
                      orderby c.ReportContentCode, c.Sort
                      select new ReportContentRow
                      {
                          AutoKey = c.AutoKey,
                          Code = c.Code,
                          ReportContentCode = c.ReportContentCode,
                          ReportContentName = "",
                          ContentTargetType = c.ContentTargetType,
                          ContentTargetRef = c.ContentTargetRef,
                          ReportContentSort = 0,
                          Sort = c.Sort,
                          UpdateMan = c.UpdateMan,
                          UpdateDate = c.UpdateDate.GetValueOrDefault(oMainDao._NowDate),
                      }).ToList();

            var rsReportContent = oMainDao.ShareCodeTextValue("ReportContent");

            foreach (var r in rs)
            {
                var rReportContent = rsReportContent.FirstOrDefault(p => p.Value == r.ReportContentCode);
                if (rReportContent != null)
                {
                    r.ReportContentName = rReportContent.Text;
                    r.ReportContentSort = rReportContent.Sort;
                }
            }

            rs = rs.OrderBy(p => p.ReportContentSort).ThenBy(p => p.Sort).ToList();

            var dt = rs.CopyToDataTable();

            //移除不顯示的欄位

            //更改欄位名稱
            var ListGroupCode = new List<string>();
            ListGroupCode.Add("Report");
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

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            if (ddlReportType.SelectedItem == null || ddlReportContent.SelectedItem == null)
                return;

            var ReportTypeCode = ddlReportType.SelectedItem.Value;
            var ReportContentCode = ddlReportContent.SelectedItem.Value;

            if (ReportContentCode == "0")
            {
                lblMsg.Text = "請先選擇一個評核內容再按新增";
                return;
            }

            var rs = (from c in dcMain.PerformanceReportContent
                      where c.PerformanceReportTypeCode == ReportTypeCode
                      && c.ReportContentCode == ReportContentCode
                      select c).ToList();

            int Sort = 5;
            if (rs.Count > 0)
                Sort = rs.Max(p => p.Sort) + 5;

            var r = new PerformanceReportContent();
            r.Code = Guid.NewGuid().ToString();
            r.PerformanceReportTypeCode = ReportTypeCode;
            r.ReportContentCode = ReportContentCode;
            r.ContentTargetType = "";
            r.ContentTargetRef = "";
            r.Note = "";
            r.Sort = Sort;
            r.InsertMan = _User.UserCode;
            r.InsertDate = DateTime.Now;
            r.UpdateMan = _User.UserCode;
            r.UpdateDate = DateTime.Now;
            dcMain.PerformanceReportContent.InsertOnSubmit(r);

            dcMain.SubmitChanges();

            oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：" + JsonConvert.SerializeObject(r), "", "Performance-新增報表內容", "", _User.UserCode);

            lvMain.Rebind();
        }

        protected void lvMain_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            if (ddlReportType.SelectedItem == null || ddlReportContent.SelectedItem == null)
                return;

            var ReportTypeCode = ddlReportType.SelectedItem.Value;
            var ReportContentCode = ddlReportContent.SelectedItem.Value;

            var rs = (from c in dcMain.PerformanceReportContent
                      where c.PerformanceReportTypeCode == ReportTypeCode
                      && (ReportContentCode == "0" || c.ReportContentCode == ReportContentCode)
                      orderby c.ReportContentCode, c.Sort
                      select new ReportContentRow
                      {
                          AutoKey = c.AutoKey,
                          Code = c.Code,
                          ReportContentCode = c.ReportContentCode,
                          ReportContentName = "",
                          ContentTargetType = c.ContentTargetType,
                          ContentTargetRef = c.ContentTargetRef,
                          ReportContentSort = 0,
                          Sort = c.Sort,
                          UpdateMan = c.UpdateMan,
                          UpdateDate = c.UpdateDate.GetValueOrDefault(oMainDao._NowDate),
                      }).ToList();

            var rsReportContent = oMainDao.ShareCodeTextValue("ReportContent");

            foreach (var r in rs)
            {
                var rReportContent = rsReportContent.FirstOrDefault(p => p.Value == r.ReportContentCode);
                if (rReportContent != null)
                {
                    r.ReportContentName = rReportContent.Text;
                    r.ReportContentSort = rReportContent.Sort;
                }
            }

            rs = rs.OrderBy(p => p.ReportContentSort).ThenBy(p => p.Sort).ToList();

            lvMain.DataSource = rs;

            var Script = "$(document).ready(function() {$('.footable').footable();});";
            ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
        }

        protected void lvMain_DataBound(object sender, EventArgs e)
        {
        }
        protected void lvMain_ItemCommand(object sender, RadListViewCommandEventArgs e)
        {
            string cn = e.CommandName;
            string ca = e.CommandArgument.ToString();

            if (cn == "ContentType")
            {
                e.Canceled = true;

                RadListViewDataItem item = e.ListViewItem as RadListViewDataItem;
                var AutoKey = item.GetDataKeyValue("AutoKey").ToString(); ;
                UnobtrusiveSession.Session["AutoKey"] = ca;

                Response.Redirect("ManageReportContentEdit.aspx?AutoKey=" + AutoKey + "&ColumnName=Type");
            }
            else if (cn == "ContentRef")
            {
                e.Canceled = true;

                RadListViewDataItem item = e.ListViewItem as RadListViewDataItem;
                var AutoKey = item.GetDataKeyValue("AutoKey").ToString(); ;
                UnobtrusiveSession.Session["AutoKey"] = ca;

                Response.Redirect("ManageReportContentEdit.aspx?AutoKey=" + AutoKey + "&ColumnName=Ref");

            }
            else if (cn == "Delete")
            {
                int AutoKey = Convert.ToInt32(ca);

                e.Canceled = true;

                var r = (from c in dcMain.PerformanceReportContent
                         where c.AutoKey == AutoKey
                         select c).FirstOrDefault();

                dcMain.PerformanceReportContent.DeleteOnSubmit(r);
                dcMain.SubmitChanges();

                oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：" + JsonConvert.SerializeObject(r), "", "Performance-報表內容刪除", "", _User.UserCode);

                lblMsg.Text = "刪除成功";

                lvMain.Rebind();
            }
        }
    }
}