using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Repo;
public partial class Admin_Plan_trCourseEdit : JBWebPage
{
    private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    private trCategoryCourse_Repo ccRepo = new trCategoryCourse_Repo();
    private trCategory_Repo catRepo = new trCategory_Repo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SiteHelper util = new SiteHelper();
            util.SetTvCourseCat(tvCat);  

            if (Request.QueryString["mode"] != null)
            {
                fv.ChangeMode(FormViewMode.Edit);
                
                int id =0;
                int.TryParse(GetRequestQueryStringValue("pid"),out id);
                trCourse_Repo trCourseRepo = new trCourse_Repo();
                trCourse trCourseObj= trCourseRepo.GetByPK(id);
                trCategoryCourse ccObj= ccRepo.GetByCourseCode(trCourseObj.sCode);
                if (ccObj != null)
                {
                    util.SetTvSelectedNode(tvCat, ccObj.sCateCode);
                }
                else
                {

                }
            }

            if (fv.CurrentMode == FormViewMode.Insert)
            {
                RadTextBox tb = fv.FindControl("iJobScoreTextBox") as RadTextBox;
                if (tb != null)
                    tb.Text = "0";

                RadTextBox tb2 = fv.FindControl("iCourseTimeTextBox") as RadTextBox;
                if (tb2 != null)
                    tb2.Text = "0";
            }            
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        if (Request.QueryString["m"] != null)
        {
            if (Request.QueryString["m"].ToString() == "I")
                fv.ChangeMode(FormViewMode.Insert);
            else
                fv.ChangeMode(FormViewMode.Edit);                
        }

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
        lblMsg.Visible = false;
        int iAutokey = Convert.ToInt32(Request.QueryString["pid"]);

        var obj = (from c in dcTraining.trCourse where c.iAutoKey == iAutokey select c).FirstOrDefault();
        try
        {
            if (tvCat.SelectedNode == null)
                throw new ApplicationException("課程類別需選擇!!");

            if (!catRepo.IsLastCategoryLevel(tvCat.SelectedValue))
                throw new ApplicationException("階層類別才可以選擇開課");

            RadTextBox tb = fv.FindControl("iCourseTimeTextBox") as RadTextBox;
            if ( tb != null )
            {
                e.NewValues["iCourseTime"] = Convert.ToInt32(float.Parse(tb.Text) * 60);
            }

            e.NewValues["sKeyMan"] = User.Identity.Name;
            e.NewValues["dKeyDate"] = DateTime.Now;
            e.NewValues["sysRole_iKey"] = obj.sysRole_iKey;
            e.NewValues["trTeachingMethod_sCode"] = obj.trTeachingMethod_sCode;
            e.NewValues["iEdition"] = obj.iEdition;
            //e.NewValues["iValidityDay"] = obj.iValidityDay;
            e.NewValues["iLeftDay"] = obj.iLeftDay;
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
            lblMsg.Visible = true;
            logger.Error(ex.Message);
            e.Cancel = true;            
        }
    }
    protected void fv_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
    {
        if (e.Exception == null)
        {                       
            string courseCode = e.NewValues["sCode"].ToString();

            trCategoryCourse catCourseObj =ccRepo.GetByCourseCode(courseCode);
            if (catCourseObj != null)
            {
                catCourseObj.sCateCode = tvCat.SelectedValue;
                catCourseObj.sKeyMan = User.Identity.Name;
                catCourseObj.dKeyDate = DateTime.Now;
                ccRepo.Update(catCourseObj);
                ccRepo.Save();
            }
            else
            {
                trCategoryCourse obj = new trCategoryCourse();
                obj.iOrder = 1;
                obj.sCateCode = tvCat.SelectedValue;
                obj.sCourseCode = courseCode;
                obj.dKeyDate = DateTime.Now;
                obj.sKeyMan = User.Identity.Name;
                ccRepo.Add(obj);
                ccRepo.Save();
            }

            ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", true);

        }
        else
        {
            logger.Error(FullBaseUrl + "更新錯誤" + e.Exception.Message);
            e.ExceptionHandled = true;
            e.KeepInEditMode = true;
            radShow("更新錯誤", this);
        }
    }
    protected void fv_ItemInserting(object sender, FormViewInsertEventArgs e)
    {
        lblMsg.Visible = false;
        try
        {
            if (tvCat.SelectedNode == null)
                throw new ApplicationException("課程類別需選擇!!");

            if (!catRepo.IsLastCategoryLevel(tvCat.SelectedValue))
                throw new ApplicationException("階層類別才可以選擇開課");

            RadTextBox tb = fv.FindControl("iCourseTimeTextBox") as RadTextBox;
            if ( tb != null )
            {
                e.Values["iCourseTime"] = Convert.ToInt32(float.Parse(tb.Text) * 60);
            }

            //自動給代碼
            e.Values["sCode"] = Guid.NewGuid().ToString();

            e.Values["sysRole_iKey"] = 0;
            e.Values["sKeyMan"] = User.Identity.Name;
            e.Values["dKeyDate"] = DateTime.Now;
        }
        catch ( Exception ex )
        {
            lblMsg.Text = ex.Message;
            lblMsg.Visible = true;
            logger.Error(ex.Message);
            e.Cancel = true;                
        }
        //e.Values["trCategory_sCode"] = Request.QueryString["pid"].ToString();
    }

    protected void fv_ItemInserted(object sender, FormViewInsertedEventArgs e)
    {
        if (e.Exception == null)
        {
                      
            string courseCode= e.Values["sCode"].ToString();
            if (ccRepo.GetByCatCourse(tvCat.SelectedValue, courseCode) == null)
            {
                trCategoryCourse obj = new trCategoryCourse();
                obj.iOrder = 1;
                obj.sCateCode = tvCat.SelectedValue;
                obj.sCourseCode = courseCode;
                obj.dKeyDate = DateTime.Now;
                obj.sKeyMan = User.Identity.Name;
                ccRepo.Add(obj);
                ccRepo.Save();
            }

            ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind('navigateToInserted');", true);
        }
        else
        {
            lblMsg.Text = lblMsg.Text + e.Exception.Message;
            lblMsg.Visible = true;
            e.ExceptionHandled = true;
            e.KeepInInsertMode = true;
        }

    }
    protected void fv_DataBound(object sender, EventArgs e)
    {
        if(fv.CurrentMode ==FormViewMode.Insert)
        {
            ((RadDatePicker)fv.FindControl("dDateATextBox")).SelectedDate = DateTime.Now;
            ((RadNumericTextBox) fv.FindControl("ntb_iValidityDay")).Text ="99999";
        }

        if ( fv.CurrentMode == FormViewMode.Edit )
        {
            //iCourseTimeTextBox
            RadTextBox tb = fv.FindControl("iCourseTimeTextBox") as RadTextBox;
            if(tb !=null)
                tb.Text = string.Format("{0:#,0.0}" , float.Parse(tb.Text) / 60);            
            
        }
    }

}