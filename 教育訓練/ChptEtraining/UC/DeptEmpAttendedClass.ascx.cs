using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repo;

public partial class UC_DeptEmpAttendedClass : System.Web.UI.UserControl
{
    private BASETTS_Repo basettsRepo = new BASETTS_Repo();
    private trTrainingStudentM_Repo tsmRepo = new trTrainingStudentM_Repo();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void sdsGv_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        e.Command.Parameters["@nobr"].Value = Page.User.Identity.Name;
    }
    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        BASETTS btts = basettsRepo.GetEmpByNobrNow_DLO(Page.User.Identity.Name);
        if (btts != null )
        {
           RadGrid1.DataSource= (from c in tsmRepo.GetRegisteredByDept_DLO(btts.DEPT)
                                 select new {courseName=c.trTrainingDetailM.trCourse.sName,
                                     //cateName=c.trTrainingDetailM.trCategory.sName,
                                     cateName = c.trTrainingDetailM.trCourse.trCategoryCourse[0].trCategory.sName ,
                                     dDateTimeA = c.trTrainingDetailM.dDateTimeA,
                                     name_c=c.BASE.NAME_C,
                                     iAutokey=c.iAutoKey}).ToList();

        }

    }
}