using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BL;
using JB.WebModules.Authentication;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using Telerik.Web.UI;

public partial class MasterPageNotSubMenu : JMasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Juser.IsInRole("HR"))
            {
                loadCbComp();
                cbCompany.Visible = true;
            }
            else
            {
                cbCompany.Visible = false;
            }

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            string clientLoginPath = @"http://" + Request.Url.Authority + Request.ApplicationPath + @"/login.aspx";
            if (!Page.ClientScript.IsStartupScriptRegistered("Logout"))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Logout", @"function Logout(){window.location = '" + clientLoginPath + @"';}", true);
            }
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect(BaseUrl + "Login.aspx");
    }

    public string BaseUrl
    {
        get
        {
            string url = this.Request.ApplicationPath;
            if (url.EndsWith("/"))
                return url;
            else
                return url + "/";
        }
    }
    protected void RadMenu1_ItemDataBound(object sender, RadMenuEventArgs e)
    {
        if (Context.User.Identity.IsAuthenticated)
        {
            JB.WebModules.Accounts.User Jbuser = ((SiteIdentity)Context.User.Identity).JbUser;
            SiteMapSalaDr_REPO siteMapSdRepo = new SiteMapSalaDr_REPO();
            List<SiteMapSalaDr> siteMapSalaDrList = siteMapSdRepo.GetBySalaDrCodeFromCache(Jbuser.SalaDr);

            bool value = (from c in siteMapSalaDrList
                          where e.Item.NavigateUrl.Contains(c.SiteMapUrl)
                          select c).Any();

            if (value)
            {
                e.Item.Visible = false;
            }
        }
    }
    protected void RadMenu2_ItemDataBound(object sender, Telerik.Web.UI.RadMenuEventArgs e)
    {
        if (Context.User.Identity.IsAuthenticated)
        {
            JB.WebModules.Accounts.User Jbuser = ((SiteIdentity)Context.User.Identity).JbUser;
            SiteMapSalaDr_REPO siteMapSdRepo = new SiteMapSalaDr_REPO();
            List<SiteMapSalaDr> siteMapSalaDrList = siteMapSdRepo.GetBySalaDrCodeFromCache(Jbuser.SalaDr);

            bool value = (from c in siteMapSalaDrList
                          where e.Item.NavigateUrl.Contains(c.SiteMapUrl)
                          select c).Any();

            if (value)
            {
                e.Item.Visible = false;
            }
        }
    }
    protected void cbCompany_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        Juser.ManageComp = cbCompany.SelectedValue;
        Response.Redirect(Request.Path, true);
    }

    private void loadCbComp()
    {
        BASE_REPO baseRepo = new BASE_REPO();
        List<COMP> compList = baseRepo.GetHrManageCompByNobr(Juser.Nobr);
        cbCompany.Items.Clear();
        foreach (var c in compList)
        {
            RadComboBoxItem item = new RadComboBoxItem();
            item.Value = c.COMP1;
            item.Text = c.COMPNAME;
            cbCompany.Items.Add(item);

            if (Juser.ManageComp.Equals(item.Value))
            {
                item.Selected = true;
            }
        }
    }
}
