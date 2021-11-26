using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repo;

public partial class UC_TeacherAttendedClass : JUserControl
{
    private BASETTS_Repo basettsRepo = new BASETTS_Repo();
    private trTrainingStudentM_Repo tsmRepo = new trTrainingStudentM_Repo();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        if (!Juser.IsInRole("64"))
        {
            return;
        }

        DateTime Bdate = DateTime.Now.Date;
        DateTime Edate = Bdate.AddMonths(3);
        trTrainingDetailM_Repo tdmRepo = new trTrainingDetailM_Repo();
        trTeacher_Repo teacherRepo = new trTeacher_Repo();
        trTeacher teacherObj = teacherRepo.GetByNobr(Page.User.Identity.Name);
        if (teacherObj == null)
            return;

        List<trTrainingDetailM> tdmList = tdmRepo.GetByDateRange_Dlo(Bdate, Edate, teacherObj.sCode).Where(p => p.bIsPublished).ToList(); ;
        RadGrid1.DataSource = (from c in tdmList select new { c.iAutoKey, c.iStudentNum, c.dDateTimeA, CourseName = c.trCourse.sName }).ToList();
    }
}