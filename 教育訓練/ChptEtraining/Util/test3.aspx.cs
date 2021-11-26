using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repo;

public partial class test3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void RadButton2_Click(object sender, EventArgs e)
    {

    }
    protected void RadButton3_Click(object sender, EventArgs e)
    {
        trTrainingDetailM_Repo tdmRepo = new trTrainingDetailM_Repo();
        trTrainingStudentM_Repo tsmRepo = new trTrainingStudentM_Repo();
        List<trTrainingDetailM> list= tdmRepo.GetByAll();


        foreach ( var l in list )
        {
            if ( l.bIsPublished )
            {
                tdmRepo.CheckIsTeacherFinishClassScore(l.iAutoKey);
            }

        }



        //Course c = new Course();
        //string s= c.GetTeacherClassDateByClassTeacher(167, "dc0307a6-d797-4f4f-816f-22f132e63edc");
        
    }
}