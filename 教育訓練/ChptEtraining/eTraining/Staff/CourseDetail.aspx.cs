using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repo;
public partial class eTraining_Staff_CourseDetail : JBWebPage
{
    dcTrainingDataContext dcTrain = new dcTrainingDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if ( !IsPostBack )
        {
            lblClassID.Text = Request.QueryString["ClassID"];
            var couName = (from tm in dcTrain.trTrainingDetailM
                           join co in dcTrain.trCourse on tm.trCourse_sCode equals co.sCode
                           where tm.iAutoKey == Convert.ToInt32(Request.QueryString["ClassID"])
                           select co.sName).FirstOrDefault();
            lblCourse.Text = couName;

        }
        //查詢此人是否已在訓練名單內
        var al = (from c in dcTrain.trTrainingStudentM
                  where c.sNobr == User.Identity.Name && c.iClassAutoKey == Convert.ToInt32(lblClassID.Text)
                  select c).FirstOrDefault();
        //已在訓練名單內
        if (al != null)
        {
            btnAdd.Enabled = false;
            btnAdd.Text = "已報名";
        }
    }
    protected void RadButton1_Click(object sender, EventArgs e)
    {

        int classID = Convert.ToInt32(lblClassID.Text);
        var al = (from c in dcTrain.trTrainingStudentM
                  where c.sNobr == User.Identity.Name && c.iClassAutoKey == classID
                  select c).FirstOrDefault();

        if (al != null)
        {
            btnAdd.Enabled = false;
            AlertMsg("已報名");
            return;
        }

        DoHelper doHelper = new DoHelper();

        if (doHelper.IsClassTeacher(classID, User.Identity.Name))
        {
            AlertMsg("已為課程講師不得報名");
            return;
        }

        try
        {
            trTrainingStudentM_Repo tsmRepo = new trTrainingStudentM_Repo();            
            tsmRepo.AddStudent(classID , User.Identity.Name , User.Identity.Name);
            btnAdd.Enabled = false;
            btnAdd.Text = "已報名";
        }
        catch (Exception ex)
        {
            AlertMsg(ex.Message);
        }
    }
}