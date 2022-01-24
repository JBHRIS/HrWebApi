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
    public partial class ManageMailView : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                UnobtrusiveSession.Session["ActivePage"] = WebPage.GetActivePage;

                ddlKey1_DataBind();
            }
        }

        public void ddlKey1_DataBind()
        {
            var rs = oMainDao.ShareCodeTextValue("SystemCate");

            ddlKey1.DataSource = rs;
            ddlKey1.DataTextField = "Text";
            ddlKey1.DataValueField = "Value";
            ddlKey1.DataBind();
        }

        public void _DataBind()
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            lvMain.Rebind();
        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (ddlKey1.SelectedItem == null)
                return;

            var Key = ddlKey1.SelectedItem.Value;
            var Search = txtSearch.Text.Trim();

            var rs = (from c in dcShare.ShareSendQueue
                      where c.FromName == Key
                      && (Search.Length == 0 || c.ToAddr.IndexOf(Search) >= 0 || c.ToName.IndexOf(Search) >= 0 || c.Subject.IndexOf(Search) >= 0 || c.Body.IndexOf(Search) >= 0)
                      orderby c.AutoKey descending
                      select c).Take(100).ToList();

            //處理html
            foreach (var r in rs)
            {
                r.Subject = HtmlToText.ConvertHtml(r.Subject);
                r.Body = HtmlToText.ConvertHtml(r.Body);
            }

            var dt = rs.CopyToDataTable();

            //移除不顯示的欄位
            if (dt.Columns.Contains("SendTypeCode")) dt.Columns.Remove("SendTypeCode");
            if (dt.Columns.Contains("ToAddrCopy")) dt.Columns.Remove("ToAddrCopy");
            if (dt.Columns.Contains("ToNameCopy")) dt.Columns.Remove("ToNameCopy");
            if (dt.Columns.Contains("ToAddrConfidential")) dt.Columns.Remove("ToAddrConfidential");
            if (dt.Columns.Contains("ToNameConfidential")) dt.Columns.Remove("ToNameConfidential");
            if (dt.Columns.Contains("Retry")) dt.Columns.Remove("Retry");
            if (dt.Columns.Contains("Suspend")) dt.Columns.Remove("Suspend");
            if (dt.Columns.Contains("Sort")) dt.Columns.Remove("Sort");

            //更改欄位名稱
            var ListGroupCode = new List<string>();
            ListGroupCode.Add("ShareSendQueue");
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
            if (ddlKey1.SelectedItem == null)
                return;

            var Key = ddlKey1.SelectedItem.Value;
            var Search = txtSearch.Text.Trim();


            var rs = (from c in dcShare.ShareSendQueue
                      where c.SystemCode == Key
                      && (Search.Length == 0 || c.ToAddr.IndexOf(Search) >= 0 || c.ToName.IndexOf(Search) >= 0 || c.Subject.IndexOf(Search) >= 0 || c.Body.IndexOf(Search) >= 0)
                      orderby c.AutoKey descending
                      select c).Take(100).ToList();

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

            var Key = ddlKey1.SelectedItem.Value;

            if (cn == "ReSend")
            {
                int AutoKey = Convert.ToInt32(ca);

                e.Canceled = true;

                var r = (from c in dcShare.ShareSendQueue
                         where c.AutoKey == AutoKey
                         select c).FirstOrDefault();

                if (r != null)
                {
                    r.Sucess = false;
                    r.UpdateMan = _User.UserCode;
                    r.UpdateDate = DateTime.Now;

                    dcShare.SubmitChanges();

                    lvMain.Rebind();

                    oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：" + JsonConvert.SerializeObject(r), "", "Performance-郵件重送", "", _User.UserCode);
                }
            }
            else if (cn == "Body")
            {
                e.Canceled = true;

                RadListViewDataItem item = e.ListViewItem as RadListViewDataItem;
                var AutoKey = item.GetDataKeyValue("AutoKey").ToString(); ;
                UnobtrusiveSession.Session["AutoKey"] = ca;

                Response.Redirect("ManageMailViewBody.aspx?AutoKey=" + AutoKey);

                //Dialog("ManageMailViewBody.aspx", "", ca);

            }
            else if (cn == "Delete")
            {
                int AutoKey = Convert.ToInt32(ca);

                e.Canceled = true;

                var r = (from c in dcShare.ShareSendQueue
                         where c.AutoKey == AutoKey
                         select c).FirstOrDefault();

                dcShare.ShareSendQueue.DeleteOnSubmit(r);
                dcShare.SubmitChanges();

                lvMain.Rebind();

                oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：" + JsonConvert.SerializeObject(r), "", "Performance-郵件刪除", "", _User.UserCode);
            }
            else if (cn == "Save")
            {
                int AutoKey = Convert.ToInt32(ca);

                e.Canceled = true;

                var item = e.ListViewItem as RadListViewDataItem;
                var txtAddr = item.FindControl("txtAddr") as RadTextBox;

                var r = (from c in dcShare.ShareSendQueue
                         where c.AutoKey == AutoKey
                         select c).FirstOrDefault();

                r.ToAddr = txtAddr.Text;

                dcShare.SubmitChanges();

                lvMain.Rebind();

                oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：" + JsonConvert.SerializeObject(r), "", "Performance-郵件儲存", "", _User.UserCode);
            }

        }
    }
}