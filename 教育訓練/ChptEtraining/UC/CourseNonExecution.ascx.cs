using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Telerik.Web.UI;
using Repo;
public partial class UC_CourseNonExecution : JUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }



    protected void gv_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
            trTrainingDetailM_Repo tdmRepo = new trTrainingDetailM_Repo();
            gv.DataSource = (from c in tdmRepo.GetByCourseNonExecution_Dlo()
                             orderby c.dDateTimeA ascending
                             select new { c.iAutoKey, courseName = c.trCourse.sName, startDate = c.dDateTimeA.Value, studentNum = c.iStudentNum }
                             ).ToList();
    }
}