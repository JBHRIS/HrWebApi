using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Desing_trTeachingMaterialEdit : JBWebPage
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        SiteHelper.ConverToChinese(gvCourse);
        if (Juser.IsInRole("1"))
        {
            cb_bSaved.Enabled = true;
        }
        else
        {
            cb_bSaved.Enabled = false;
        }

        if(!IsPostBack)
        {
            //新增
            if (Request.QueryString["iAutoKey"] == null)
            {
                lblAutoKey.Text = ""; 
                //throw new Exception("傳入值錯誤");
            }
            else//更新
            {
                lblAutoKey.Text = Request.QueryString["iAutoKey"];
                loadData();
            }
            this.Page.Title = "編輯資料";
        }
    }

    private void loadData()
    {
        lblSelectedCourseCode.Text = "";

        var obj = (from c in dcTraining.trTeachingMaterial
                   where
                       c.iAutoKey == Convert.ToInt32(lblAutoKey.Text)
                   select c).FirstOrDefault();

        if (obj != null)
        {
            if (obj.dTeachingTime.HasValue)
                ntbTeachTimeMins.Text = obj.dTeachingTime.ToString();
            else
            {
                ntbTeachTimeMins.Text = "0";
            }
                                    
            tbVersion.Text =obj.sVersion;
            tbScontent.Text = obj.sContent;            
            tbExpect.Text =obj.sCourseExpect;            
            tbPolicy.Text=obj.sCoursePolicy ;
            cb_bSaved.Checked = obj.bSaved;
            var course = (from c in dcTraining.trCourse
                          where c.sCode == obj.trCourse_sCode
                          select c).FirstOrDefault();

            if (course != null)
            {
                lblSelectedCourseCode.Text = obj.trCourse_sCode;
                tbCourseName.Text = course.sName;
            }                            
        }

    }
    
    protected void gvCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        var course = (from c in dcTraining.trCourse
                      where c.sCode == gvCourse.SelectedValue.ToString()
                      select c).FirstOrDefault();

        if (course != null)
        {
            lblSelectedCourseCode.Text = gvCourse.SelectedValue.ToString();
            tbCourseName.Text = course.sName;
        }        
    }


    protected void UpdateRbtn_Click(object sender, EventArgs e)
    {
        
        if (lblAutoKey.Text.Trim().Length > 0) //更新
        {
          var   obj = (from c in dcTraining.trTeachingMaterial
                       where
                           c.iAutoKey == Convert.ToInt32(lblAutoKey.Text)
                       select c).FirstOrDefault();

            if (obj != null)
            {
                obj.dKeyDate = DateTime.Now;

                if (ntbTeachTimeMins.Value.HasValue)
                {
                    obj.dTeachingTime = Convert.ToInt32(ntbTeachTimeMins.Value.Value);
                }
                obj.sVersion = tbVersion.Text;
                obj.sContent = tbScontent.Text;
                obj.sCourseExpect = tbExpect.Text;
                obj.sCoursePolicy = tbPolicy.Text;
                obj.bSaved = cb_bSaved.Checked;
                obj.sKeyMan = User.Identity.Name;
                obj.trCourse_sCode = lblSelectedCourseCode.Text;

                dcTraining.SubmitChanges();
            }
        }
        else //新增
        {
            trTeachingMaterial obj = new trTeachingMaterial();
            obj.dKeyDate = DateTime.Now;

            if (ntbTeachTimeMins.Value.HasValue)
            {
                obj.dTeachingTime = Convert.ToInt32(ntbTeachTimeMins.Value.Value);
            }
            obj.sVersion = tbVersion.Text;
            obj.sContent = tbScontent.Text;
            obj.sCourseExpect = tbExpect.Text;
            obj.sCoursePolicy = tbPolicy.Text;
            obj.bSaved = cb_bSaved.Checked;
            obj.sKeyMan = User.Identity.Name;
            obj.trCourse_sCode = lblSelectedCourseCode.Text;

            dcTraining.trTeachingMaterial.InsertOnSubmit(obj);
            dcTraining.SubmitChanges();
        }

        ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind('navigateToInserted');", true);

    }
    protected void UpdateCancelRbtn_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CancelEdit();", true);
    }
}