using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class eTraining_Questionary_QTplEdit : JBWebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        if (Request.QueryString["Id"] == null)
            fv.DefaultMode = FormViewMode.Insert;
        else
            fv.DefaultMode = FormViewMode.Edit;

        //this.Page.Title = "編輯資料";
    }

    protected void fv_ItemCommand(object sender, FormViewCommandEventArgs e)
    {
        if (e.CommandName == "Update")
        {
            // ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", true);
        }
        else if (e.CommandName == "Insert")
        {
            // ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind('navigateToInserted');", true);
        }
        else
        {
            ClientScript.RegisterStartupScript(Page.GetType(), this.GetType().ToString(), "CancelEdit();", true);
        }

    }

    protected void fv_ItemUpdating(object sender, FormViewUpdateEventArgs e)
    {
        e.NewValues["KeyMan"] = User.Identity.Name;
        e.NewValues["KeyDate"] = DateTime.Now;
    }
    protected void fv_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
    {
        if (e.Exception == null)
            ClientScript.RegisterStartupScript(Page.GetType(), this.GetType().ToString(), "CloseAndRebind();", true);
        else
        {
            e.ExceptionHandled = true;
            e.KeepInEditMode = true;
            //radShow("更新錯誤", this);
        }
    }
    protected void fv_ItemInserting(object sender, FormViewInsertEventArgs e)
    {
        e.Values["Code"] = Guid.NewGuid().ToString();
        e.Values["KeyMan"] = User.Identity.Name;
        e.Values["KeyDate"] = DateTime.Now;
        e.Values["IsTeacherGrade"] = false;
    }
    protected void fv_ItemInserted(object sender, FormViewInsertedEventArgs e)
    {
        if (e.Exception == null)
            ClientScript.RegisterStartupScript(Page.GetType(), this.GetType().ToString(), "CloseAndRebind('navigateToInserted');", true);
        else
        {
            radShow("新增錯誤", this);
            e.ExceptionHandled = true;
            e.KeepInInsertMode = true;
        }
    }
    protected void fv_ItemDeleting(object sender, FormViewDeleteEventArgs e)
    {

    }
    protected void fv_ItemDeleted(object sender, FormViewDeletedEventArgs e)
    {

    }
}