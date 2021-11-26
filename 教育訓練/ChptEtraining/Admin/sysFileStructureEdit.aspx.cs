using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_sysFileStructureEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        this.Page.Title = "新增資料";

        if (Request.QueryString["iAutoKey"] != null)
        {
            fv.DefaultMode = FormViewMode.Edit;
            this.Page.Title = "編輯資料";
        }

        
    }

    protected void fv_ItemCommand(object sender, FormViewCommandEventArgs e)
    {
        if (e.CommandName == "Update")
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", true);
        }
        else if (e.CommandName == "Insert")
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind('navigateToInserted');", true);
        }
        else
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CancelEdit();", true);
        }

    }

    protected void fv_ItemUpdating(object sender, FormViewUpdateEventArgs e)
    {
        e.NewValues["sKeyMan"] = "ming";
        e.NewValues["dKeyDate"] = DateTime.Now;
    }
    protected void fv_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
    {

    }
    protected void fv_ItemInserting(object sender, FormViewInsertEventArgs e)
    {
        e.Values["sKeyMan"] = "ming";
        e.Values["dKeyDate"] = DateTime.Now;
    }
    protected void fv_ItemInserted(object sender, FormViewInsertedEventArgs e)
    {

    }
    protected void fv_ItemDeleting(object sender, FormViewDeleteEventArgs e)
    {

    }
    protected void fv_ItemDeleted(object sender, FormViewDeletedEventArgs e)
    {

    }
}