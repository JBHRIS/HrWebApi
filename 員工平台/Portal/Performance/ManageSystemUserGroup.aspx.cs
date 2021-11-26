using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bll.Share.Vdb;
using Dal.Dao.Share;

namespace Performance
{
    public partial class ManageSystemUserGroup : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                UnobtrusiveSession.Session["ActivePage"] = WebPage.GetActivePage;
            }
        }

        protected void lvMain_NeedDataSource(object sender, Telerik.Web.UI.RadListViewNeedDataSourceEventArgs e)
        {
            var oUser = new ShareDefaultDao(dcShare);
            var ShareUserGroupCond = new ShareUserGroupConditions();
            //ShareUserGroupCond.GroupCode = "Share";
            var UserGroup = (from c in dcShare.SystemUserGroup
                             select c).ToList();
            lvMain.DataSource = UserGroup;

        }

        protected void lvMain_DataBound(object sender, EventArgs e)
        {

        }

        protected void lvMain_ItemCommand(object sender, Telerik.Web.UI.RadListViewCommandEventArgs e)
        {
            string ca = e.CommandArgument.ToString();
            if (e.CommandName == "Edit")
            {
                Response.Redirect("ManageSystemUserGroupEdit.aspx?AutoKey=" + e.CommandArgument);
            }
            if (e.CommandName == "Delete")
            {
                var r = (from c in dcShare.SystemUserGroup
                         where c.AutoKey == Convert.ToInt32(ca)
                         select c).FirstOrDefault();
                dcShare.SystemUserGroup.DeleteOnSubmit(r);
                dcShare.SubmitChanges();
                lblMsg.Text = "刪除成功";
            }
        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageSystemUserGroupEdit.aspx");
        }
    }
}