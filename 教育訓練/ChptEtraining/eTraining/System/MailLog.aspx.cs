using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Repo;
public partial class eTraining_System_MailLog : JBWebPage
{
    private MailLog_Repo mailLogRepo = new MailLog_Repo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            rdpB.SelectedDate = DateTime.Now.AddMonths(-1);
            rdpE.SelectedDate = DateTime.Now.AddDays(1);
        }

        SiteHelper.ConverToChinese(gv);
    }


    protected void gv_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        gv.DataSource = mailLogRepo.GetByDateRange_DLO(rdpB.SelectedDate.Value, rdpE.SelectedDate.Value).OrderByDescending(p=>p.iAutoKey);
    }
}