using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BL;
public partial class System_FileGroupEdit:JBWebPage
{
    private FileGroup_Repo fgRepo = new FileGroup_Repo();
    protected void Page_Load(object sender , EventArgs e)
    {
        if ( !IsPostBack )
        {
            if(Request.QueryString["Id"]==null)
                throw new ApplicationException("錯誤參數");

            SiteHelper siteHelper = new SiteHelper();
            siteHelper.BuildAdminMainTv(tv);

            int id = Convert.ToInt32(Request.QueryString["Id"]);
            bind_lb(id);
        }
    }


    protected void RadAjaxPanel1_AjaxRequest(object sender , AjaxRequestEventArgs e)
    {

    }


    private void bind_lb(int id)
    {
        FileStructureGroup_Repo fsgRepo = new FileStructureGroup_Repo();
        var list = fsgRepo.GetByGroupId_Dlo(id).OrderBy(p => p.Sequence).ToList();

        foreach ( var l in list )
        {
            RadListBoxItem item = new RadListBoxItem();
            item.Value = l.FileStructure.Code;
            item.Text = l.FileStructure.sFileTitle;
            lb.Items.Add(item);
        }
    }
    protected void btnSelect_Click(object sender , EventArgs e)
    {
        if ( tv.SelectedNode == null )
        {
            Show("Need to Select one");
            return;
        }

        var selectedItem=lb.Items.FindAll(p => p.Value == tv.SelectedValue);
        if ( selectedItem.Count() == 0 )
        {
            RadListBoxItem item = new RadListBoxItem();
            item.Value = tv.SelectedValue;
            item.Text = tv.SelectedNode.Text;
            lb.Items.Add(item);
        }
    }
    protected void btnSave_Click(object sender , EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["Id"]);
        FileStructureGroup_Repo fsgRepo = new FileStructureGroup_Repo();
        var list = fsgRepo.GetByGroupId_Dlo(id).ToList();

        foreach ( var l in list )
        {
            fsgRepo.Delete(l);
        }

        int i=0;
        foreach (  RadListBoxItem item in lb.Items )
        {
            FileStructureGroup fsgObj = new FileStructureGroup();
            fsgObj.GroupId = id;
            fsgObj.FileStructureCode = item.Value;
            fsgObj.Sequence = i++;
            fsgRepo.Add(fsgObj);
        }

        fsgRepo.Save();
    }
}