using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Performance
{
    public partial class ManageSystemUser : WebPageBase
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
            //var oUser = new ShareDefaultDao(dcShare);
            //var ShareUserGroupCond = new ShareUserGroupConditions();
            //ShareUserGroupCond.GroupCode = "Share";
            var UserData = (from c in dcShare.SystemUser
                             select c).ToList();
            lvMain.DataSource = UserData;

        }

        protected void lvMain_DataBound(object sender, EventArgs e)
        {

        }

        protected void lvMain_ItemCommand(object sender, Telerik.Web.UI.RadListViewCommandEventArgs e)
        {
            string ca = e.CommandArgument.ToString();
            if (e.CommandName=="Edit")
            {
                Response.Redirect("ManageSystemUserEdit.aspx?AutoKey=" + e.CommandArgument);
            }
            if(e.CommandName == "Delete")
            {
                var r = (from c in dcShare.SystemUser
                         where c.AutoKey == Convert.ToInt32(ca)
                         select c).FirstOrDefault();
                dcShare.SystemUser.DeleteOnSubmit(r);
                dcShare.SubmitChanges();
                lblMsg.Text = "刪除成功";
            }
        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
        }
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageSystemUserEdit.aspx");
        }
    }
}