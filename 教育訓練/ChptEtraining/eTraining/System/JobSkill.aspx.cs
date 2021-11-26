using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class eTraining_System_JobSkill : JBWebPage
{
    dcTrainingDataContext dcTrain = new dcTrainingDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Title = "教學資源";
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {              
        fv.ChangeMode(FormViewMode.Insert);
        fv.DataBind();
        fv.Visible = true;
    }                     
    protected void fv_ItemInserting(object sender, FormViewInsertEventArgs e)
    {
        e.Values["dKeyDate"] = DateTime.Now;
        e.Values["sKeyMan"] = User.Identity.Name;
    }
    protected void fv_ItemInserted(object sender, FormViewInsertedEventArgs e)
    {
        if ( e.Exception == null )
        {
            gv.Rebind();
            fv.Visible = false;
        }
        else
        {
            e.ExceptionHandled = true;
            e.KeepInInsertMode = true;
            RadAjaxPanel1.Alert("新增失敗");
        }
    }
    protected void gv_SelectedIndexChanged(object sender , EventArgs e)
    {
        fv.ChangeMode(FormViewMode.Edit);
        fv.DataBind();
        fv.Visible = true;
    }
    protected void fv_ItemCommand(object sender , FormViewCommandEventArgs e)
    {
        if ( e.CommandName == "Cancel" )
        {
            fv.ChangeMode(FormViewMode.Insert);
            fv.Visible = false;
        }
    }
    protected void fv_ItemUpdated(object sender , FormViewUpdatedEventArgs e)
    {
        if ( e.Exception == null )
        {
            gv.Rebind();
            fv.Visible = false;
        }
        else
        {
            e.ExceptionHandled = true;
            e.KeepInEditMode = true;
            RadAjaxPanel1.Alert("更新失敗");
        }
    }
    protected void fv_ItemUpdating(object sender , FormViewUpdateEventArgs e)
    {

    }
}