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
    public partial class ManageShareMessage : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                UnobtrusiveSession.Session["ActivePage"] = WebPage.GetActivePage;

                ddlSystemCate_DataBind();
                ddlMessageType_DataBind();
                ddlHandleStatus_DataBind();
            }
        }

        public void ddlSystemCate_DataBind()
        {
            var rs = oMainDao.ShareCodeTextValue("SystemCate");

            ddlSystemCate.DataSource = rs;
            ddlSystemCate.DataTextField = "Text";
            ddlSystemCate.DataValueField = "Value";
            ddlSystemCate.DataBind();
        }

        public void ddlMessageType_DataBind()
        {
            var rs = oMainDao.ShareCodeTextValue("MessageType");

            var r = new TextValueRow();
            r.Text = "全部";
            r.Value = "-";
            rs.Add(r);

            ddlMessageType.DataSource = rs;
            ddlMessageType.DataTextField = "Text";
            ddlMessageType.DataValueField = "Value";
            ddlMessageType.DataBind();

            if (ddlMessageType.FindItemByValue("-") != null)
                ddlMessageType.FindItemByValue("-").Selected = true;
        }

        public void ddlHandleStatus_DataBind()
        {
            var rs = oMainDao.ShareCodeTextValue("HandleStatus");

            var r = new TextValueRow();
            r.Text = "全部";
            r.Value = "-";
            rs.Add(r);

            ddlHandleStatus.DataSource = rs;
            ddlHandleStatus.DataTextField = "Text";
            ddlHandleStatus.DataValueField = "Value";
            ddlHandleStatus.DataBind();

            if (ddlHandleStatus.FindItemByValue("-") != null)
                ddlHandleStatus.FindItemByValue("-").Selected = true;
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
            if (ddlSystemCate.SelectedItem == null || ddlMessageType.SelectedItem == null || ddlHandleStatus.SelectedItem == null)
                return;

            var SystemCateCode = ddlSystemCate.SelectedItem.Value;
            var MessageTypeCode = ddlMessageType.SelectedItem.Value;
            var HandleStatusCode = ddlHandleStatus.SelectedItem.Value;

            var rs = (from c in dcShare.ShareMessage
                      where c.SystemCode == SystemCateCode
                      && (c.MessageTypeCode == MessageTypeCode || MessageTypeCode == "-")
                      && (c.HandleStatusCode == HandleStatusCode || HandleStatusCode == "-")
                      orderby c.AutoKey descending
                      select c).Take(100).ToList();

            //處理html
            foreach (var r in rs)
            {

            }

            var dt = rs.CopyToDataTable();

            //移除不顯示的欄位

            //更改欄位名稱
            var ListGroupCode = new List<string>();
            ListGroupCode.Add("ShareMessage");
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
            if (ddlSystemCate.SelectedItem == null || ddlMessageType.SelectedItem == null || ddlHandleStatus.SelectedItem == null)
                return;

            var SystemCateCode = ddlSystemCate.SelectedItem.Value;
            var MessageTypeCode = ddlMessageType.SelectedItem.Value;
            var HandleStatusCode = ddlHandleStatus.SelectedItem.Value;

            var rs = (from c in dcShare.ShareMessage
                      where c.SystemCode == SystemCateCode
                      && (c.MessageTypeCode == MessageTypeCode || MessageTypeCode == "-")
                      && (c.HandleStatusCode == HandleStatusCode || HandleStatusCode == "-")
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

            var SystemCateCode = ddlSystemCate.SelectedItem.Value;
            var MessageTypeCode = ddlMessageType.SelectedItem.Value;
            var HandleStatusCode = ddlHandleStatus.SelectedItem.Value;

            if (cn == "Content")
            {
                e.Canceled = true;

                RadListViewDataItem item = e.ListViewItem as RadListViewDataItem;
                var AutoKey = item.GetDataKeyValue("AutoKey").ToString();
                UnobtrusiveSession.Session["AutoKey"] = ca;

                Response.Redirect("ManageShareMessageContent.aspx?AutoKey=" + AutoKey);
            }
            else if (cn == "HandleStatus")
            {
                int AutoKey = Convert.ToInt32(ca);

                e.Canceled = true;

                var r = (from c in dcShare.ShareMessage
                         where c.AutoKey == AutoKey
                         select c).FirstOrDefault();

                if (r != null)
                {
                    r.HandleStatusCode = "03";

                    dcShare.SubmitChanges();

                    lvMain.Rebind();

                    oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：" + JsonConvert.SerializeObject(r), "", "Performance-訊息管理完成", "", _User.UserCode);
                }
            }
        }
    }
}