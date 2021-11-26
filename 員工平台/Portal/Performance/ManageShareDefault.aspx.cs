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
    public partial class ManageShareDefault : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                UnobtrusiveSession.Session["ActivePage"] = WebPage.GetActivePage;

                ddlGroup_DataBind();
            }
        }

        public void ddlGroup_DataBind()
        {
            var rs = oMainDao.ShareCodeTextValue("ShareDefault");
            ddlGroup.DataSource = rs;
            ddlGroup.DataTextField = "Text";
            ddlGroup.DataValueField = "Value";
            ddlGroup.DataBind();
        }

        protected void ddlGroup_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            lvMain.Rebind();
        }

        public void _DataBind()
        {

        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (ddlGroup.SelectedItem == null)
                return;

            var GroupCode = ddlGroup.SelectedItem.Value;

            var oShareDefault = new ShareDefaultDao(dcShare);
            var ShareDefaultCond = new ShareDefaultConditions();
            ShareDefaultCond.GroupCode = GroupCode;
            var rs = oShareDefault.GetShareDefault(ShareDefaultCond);

            //處理html
            foreach (var r in rs)
            {

            }

            var dt = rs.CopyToDataTable();

            //移除不顯示的欄位

            //更改欄位名稱
            var ListGroupCode = new List<string>();
            ListGroupCode.Add("ShareDefault");
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
            if (ddlGroup.SelectedItem == null)
                return;

            var GroupCode = ddlGroup.SelectedItem.Value;

            var oShareDefault = new ShareDefaultDao(dcShare);
            var ShareDefaultCond = new ShareDefaultConditions();
            ShareDefaultCond.GroupCode = GroupCode;
            var rs = oShareDefault.GetShareDefault(ShareDefaultCond);

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

            var GroupCode = ddlGroup.SelectedItem.Value;

            if (cn == "Edit")
            {
                RadListViewDataItem item = e.ListViewItem as RadListViewDataItem;
                var AutoKey = item.GetDataKeyValue("AutoKey").ToString(); ;
                UnobtrusiveSession.Session["AutoKey"] = ca;

                Response.Redirect("ManageShareDefaultEdit.aspx?AutoKey=" + AutoKey);
            }
            if (cn == "Delete")
            {
                int AutoKey = Convert.ToInt32(ca);

                e.Canceled = true;

                var r = (from c in dcShare.ShareDefault
                         where c.AutoKey == AutoKey
                         select c).FirstOrDefault();

                dcShare.ShareDefault.DeleteOnSubmit(r);
                dcShare.SubmitChanges();

                oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：" + JsonConvert.SerializeObject(r), "", "Performance-刪除共用參數", "", _User.UserCode);

                lblMsg.Text = "刪除成功";

                lvMain.Rebind();
            }
        }
    }
}