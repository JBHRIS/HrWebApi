using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repo;
public partial class eTraining_Admin_Do_CourseInfoD : JBWebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = GetRequestQueryStringValue("ID");
        if (!id.Equals(""))
        {
            loadData(Convert.ToInt32(id));
        }
    }

    private void loadData(int id)
    {
        trTrainingDetailM_Repo tdmRepo = new trTrainingDetailM_Repo();
        trTrainingDetailM tdm= tdmRepo.GetByKey_DLO(id);

        lblSession.Text = tdm.iSession.ToString();
        lblStudentNum.Text = tdm.iSession.ToString();
        lblClassBeginDate.Text = tdm.dDateA.Value.ToShortDateString();
        lblClassEndDate.Text = tdm.dDateD.Value.ToShortDateString();

    }
    protected void gvAttendDate_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {

    }
}