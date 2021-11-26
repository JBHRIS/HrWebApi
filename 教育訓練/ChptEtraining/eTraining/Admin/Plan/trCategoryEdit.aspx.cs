using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Plan_trCategoryEdit : JBWebPage
{
    //private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["mode"] != null)
            {
                fv.DefaultMode = FormViewMode.Edit;                
            }
            else
            {
                fv.DefaultMode = FormViewMode.Insert;                
            }
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        if (Request.QueryString["pid"] != null)
            fv.DefaultMode = FormViewMode.Insert;
        else if(Request.QueryString["iAutoKey"]!=null)
            fv.DefaultMode = FormViewMode.Edit;

        this.Page.Title = "編輯資料";
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
            ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CancelEdit();", true);
        }

    }

    protected void fv_ItemUpdating(object sender, FormViewUpdateEventArgs e)
    {
        //★參考
        string sCode = Request.QueryString["pid"].ToString();
        var obj = (from c in dcTraining.trCategory where c.sCode == sCode select c).FirstOrDefault();

        e.NewValues["sKeyMan"] = Page.User.Identity.Name;
        e.NewValues["dKeyDate"] = DateTime.Now;
        e.NewValues["sysRole_iKey"] = obj.sysRole_iKey;
        e.NewValues["sParentCode"] = obj.sParentCode;
    }

    protected void fv_ItemInserting(object sender, FormViewInsertEventArgs e)
    {
        if (Request.QueryString["pid"] == null)
        {
            lblMsg.Text = "無父節點";
            e.Cancel = true;

        }
            //throw new Exception("無父節點");
        e.Values["sysRole_iKey"] = 0;
        e.Values["sKeyMan"] = User.Identity.Name;
        e.Values["dKeyDate"] = DateTime.Now;
        e.Values["sParentCode"] = Request.QueryString["pid"].ToString();       
    }

    protected void fv_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
    {
        if (e.Exception == null)
            ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", true);
            //ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", true);
        else
        {
            e.ExceptionHandled = true;
            e.KeepInEditMode = true;
            logger.Error(FullBaseUrl + "更新錯誤" + e.Exception.Message);
            lblMsg.Visible = true;
            lblMsg.Text = e.Exception.Message;    
        }
    }
    protected void fv_ItemInserted(object sender, FormViewInsertedEventArgs e)
    {
        if (e.Exception == null)
            ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind('navigateToInserted');", true);
        else
        {            
            lblMsg.Visible = true;
            lblMsg.Text = e.Exception.Message;
            e.ExceptionHandled = true;
            e.KeepInInsertMode = true;
        }
            
    }
    protected void fv_DataBound(object sender, EventArgs e)
    {
        if (fv.DefaultMode == FormViewMode.Insert)
        {
            ((Telerik.Web.UI.RadDatePicker)fv.FindControl("dDateATextBox")).SelectedDate = DateTime.Now;
            ((Telerik.Web.UI.RadTextBox)fv.FindControl("iOrderTextBox")).Text = "1";
        }
    }
}