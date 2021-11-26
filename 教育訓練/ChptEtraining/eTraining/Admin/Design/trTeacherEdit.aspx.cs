using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
public partial class Admin_Design_trTeacherEdit : JBWebPage
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        if (Request.QueryString["iAutoKey"] == null)
        {
            fv.DefaultMode = FormViewMode.Insert;
            this.Page.Title = "新增資料";
        }
        else
        {
            fv.DefaultMode = FormViewMode.Edit;
            this.Page.Title = "編輯資料";
        }
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
        else if (e.CommandName == "LoadDataInsert" || e.CommandName =="LoadDataEdit")
        {
            RadTextBox tbNobr = fv.FindControl("RadTextBox2") as RadTextBox;

            if(tbNobr ==null)
                return;

            var emp = (from b in dcTraining.BASE
                       join tts in dcTraining.BASETTS on b.NOBR equals tts.NOBR
                       where new string[] { "1", "4", "6" }.Contains(tts.TTSCODE)
                       && tts.ADATE <= DateTime.Today && tts.DDATE >= DateTime.Today
                       && b.NOBR == tbNobr.Text
                       select new { b, tts }).FirstOrDefault();

            if (emp != null)
            {
                RadTextBox tb = fv.FindControl("sNameTextBox") as RadTextBox;
                if (tb != null)                
                    tb.Text = emp.b.NAME_C;                

                CheckBox ck = fv.FindControl("ckxEntTeacherType") as CheckBox;
                if (ck != null)
                    ck.Checked = true;

                tb = fv.FindControl("txtsTeacherID") as RadTextBox;
                if (tb != null)
                    tb.Text = emp.b.IDNO;

                tb = fv.FindControl("sEmailTextBox") as RadTextBox;
                if (tb != null)
                    tb.Text = emp.b.EMAIL;

                tb = fv.FindControl("sTelTextBox") as RadTextBox;
                if (tb != null)                    
                    tb.Text = emp.b.TEL1;

                tb = fv.FindControl("sCellPhoneTextBox") as RadTextBox;
                if (tb != null)
                    tb.Text = emp.b.GSM;               
            }
            return;
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
        string sCode = Guid.NewGuid().ToString();
        e.Values["sCode"] = sCode;
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

    protected void fv_ItemUpdated1(object sender, FormViewUpdatedEventArgs e)
    {
        if (e.Exception == null)
            ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", true);
        else
        {
            e.ExceptionHandled = true;
            e.KeepInEditMode = true;
            radShow("更新錯誤", this);
        }
    }
    protected void fv_ItemInserted1(object sender, FormViewInsertedEventArgs e)
    {
        if (e.Exception == null)
            ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind('navigateToInserted');", true);
        else
        {
            radShow("新增錯誤", this);
            e.ExceptionHandled = true;
            e.KeepInInsertMode = true;
        }
            
    }
    protected void btnLoadData_Click(object sender, EventArgs e)
    {




        //RadTextBox2
    }
}