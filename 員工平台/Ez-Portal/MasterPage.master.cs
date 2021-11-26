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
using System.Web.UI.WebControls.Adapters;
using JB.WebModules.Authentication;
using BL;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using Telerik.Web.UI;

public partial class MasterPage_MasterPage : JMasterPage, IBindNeedAssignedNum
{
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) 
        {

            if (Juser.IsInRole("HR"))
            {
                loadCbComp();
                //cbCompany.Visible = true;
            }
            else
            {
                cbCompany.Visible = false;
            }
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            string clientLoginPath = @"http://" + Request.Url.Authority + Request.ApplicationPath + @"/login.aspx";

            if ( !Page.ClientScript.IsStartupScriptRegistered("Logout") )
            {
                Page.ClientScript.RegisterStartupScript(this.GetType() , "Logout" , @"function Logout(){window.location = '"+clientLoginPath+@"';}" , true);
            }

            bindMenu();

            BindNeedAssignedNum();

            lbEmpInfo.Text = Juser.Nobr + " " + Juser.NameC;
        }

       // pageurl =BaseUrl;
    }



    private void bindMenu()
    {
        SiteHelper sh = new SiteHelper();
        TreeView tv = new TreeView();
        sh.SetMainTvRootValues("Root", tv, Juser);
        sh.ConvertTv2RadMenu(tv, RadMenu2);
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
    protected void cbCompany_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        Juser.ManageComp = cbCompany.SelectedValue;
        Response.Redirect(Request.Path, true);
    }

    protected void lbtnHome_Click(object sender, EventArgs e)
    {
        Response.Redirect(BaseUrl + "Default.aspx");
    }

    private void BindNeedAssignedNum()
    {
        try
        {
            JbFlow.ServiceClient sc = new JbFlow.ServiceClient();
            //var flowList = sc.GetFlowProgressFlow(Juser.Nobr);
            int count = sc.GetFlowProgressFlowCount(Juser.Nobr);
            if (count > 0)
            {
                lblNeedAssignedNum.ForeColor = System.Drawing.Color.Red;
                lblNeedAssignedNum.Text = "(" + count.ToString() + ")";
            }
        }
        catch
        {
        }
    }


    void IBindNeedAssignedNum.BindNeedAssignedNum()
    {
        BindNeedAssignedNum();
    }
}
