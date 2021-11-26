using Bll;
using Bll.Share.Vdb;
using Bll.Tools;
using Dal;
using Dal.Dao;
using Dal.Dao.Share;
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
    public partial class ManageShareIssue : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                UnobtrusiveSession.Session["ActivePage"] = WebPage.GetActivePage;

                ddlIssueType_DataBind();
            }
        }

        public void ddlIssueType_DataBind()
        {
            var rs = oMainDao.ShareCodeTextValue("IssueType");

            var r = new TextValueRow();
            r.Text = "全部";
            r.Value = "*";
            r.Sort = 0;
            rs.Add(r);

            rs = rs.OrderBy(p => p.Sort).ToList();

            ddlIssueType.DataSource = rs;
            ddlIssueType.DataTextField = "Text";
            ddlIssueType.DataValueField = "Value";
            ddlIssueType.DataBind();
        }

        protected void ddlIssueType_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            lvMain.Rebind();
        }

        public void _DataBind()
        {

        }

        public List<IssueRow> ListIssue
        {
            get
            {
                var Value = new List<IssueRow>();
                if (WebPage.DataCache &&
                    UnobtrusiveSession.Session["Issue"] != null)
                {
                    Value = (List<IssueRow>)UnobtrusiveSession.Session["Issue"];
                }
                else
                {

                    if (ddlIssueType.SelectedItem == null)
                        return Value;

                    var IssueTypeCody = ddlIssueType.SelectedItem.Value;

                    Value = (from c in dcShare.ShareIssue
                             where c.IssueTypeCode == IssueTypeCody || IssueTypeCody == "*"
                             orderby c.UpdateDate descending, c.Sort
                             select new IssueRow
                             {
                                 AutoKey = c.AutoKey,
                                 IssueTypeCode = c.IssueTypeCode,
                                 IssueTypeName = "",
                                 Serial = c.Serial,
                                 IssueContent = c.IssueContent,
                                 Sort = c.Sort,
                                 Note = c.Note,
                                 UpdateMan = c.UpdateMan,
                                 UpdateDate = c.UpdateDate.GetValueOrDefault(oMainDao._NowDate),
                             }).ToList();

                    var rsIssueType = oMainDao.ShareCodeNameCode("IssueType");

                    foreach (var r in Value)
                    {
                        r.IssueTypeName = rsIssueType.FirstOrDefault(p => p.Code == r.IssueTypeCode)?.Name ?? "";
                        r.IssueTypeCss = rsIssueType.FirstOrDefault(p => p.Code == r.IssueTypeCode)?.Column1 ?? "";
                    }

                    UnobtrusiveSession.Session["Issue"] = Value;
                }

                return Value;
            }
        }

        public class IssueRow
        {
            public int AutoKey { get; set; }
            public string IssueTypeCode { get; set; }
            public string IssueTypeName { get; set; }
            public string IssueTypeCss { get; set; }
            public string Serial { get; set; }
            public string IssueContent { get; set; }
            public int Sort { get; set; }
            public string Note { get; set; }
            public string UpdateMan { get; set; }
            public DateTime UpdateDate { get; set; }
        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            var rs = ListIssue;

            //處理html
            foreach (var r in rs)
            {

            }

            var dt = rs.CopyToDataTable();

            //移除不顯示的欄位

            //更改欄位名稱
            var ListGroupCode = new List<string>();
            ListGroupCode.Add("ShareIssue");
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

        protected void lvMain_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            var rs = ListIssue;

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

            var IssueTypeCody = ddlIssueType.SelectedItem.Value;

            if (cn == "Edit")
            {
                RadListViewDataItem item = e.ListViewItem as RadListViewDataItem;
                var AutoKey = item.GetDataKeyValue("AutoKey").ToString(); ;
                UnobtrusiveSession.Session["AutoKey"] = ca;

                Response.Redirect("ManageShareIssueEdit.aspx?AutoKey=" + AutoKey);
            }
            if (cn == "Delete")
            {
                int AutoKey = Convert.ToInt32(ca);

                e.Canceled = true;

                var r = (from c in dcShare.ShareIssue
                         where c.AutoKey == AutoKey
                         select c).FirstOrDefault();

                dcShare.ShareIssue.DeleteOnSubmit(r);
                dcShare.SubmitChanges();

                oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：" + JsonConvert.SerializeObject(r), "", "Performance-刪除Issue", "", _User.UserCode);

                lblMsg.Text = "刪除成功";

                lvMain.Rebind();
            }
        }
    }
}