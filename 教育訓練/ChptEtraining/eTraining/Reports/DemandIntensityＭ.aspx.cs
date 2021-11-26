using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

public partial class eTraining_Reports_DemandIntensityＭ : System.Web.UI.Page
{
    dcTrainingDataContext dcTrain = new dcTrainingDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            ReportViewer1.Reset();
    }
    protected void RadButton1_Click(object sender, EventArgs e)
    {
        ReportViewer1.Reset();
        ReportViewer1.LocalReport.ReportPath = Server.MapPath(@"~/eTraining/Reports/DemandIntensityM.rdlc");
        ReportViewer1.LocalReport.DataSources.Clear();
        IEnumerable<DemandIntensityM> DemandIntensityM1 = from a in dcTrain.BASE
                                                          join b in dcTrain.BASETTS on a.NOBR equals b.NOBR
                                                          join c in dcTrain.trTrainingQuest on a.NOBR equals c.sNobr
                                                          join d in dcTrain.trCategory on c.sKey equals d.sCode
                                                          where Convert.ToDateTime(DateTime.Today) >= b.ADATE && Convert.ToDateTime(DateTime.Today) <= b.DDATE
                                                          select new DemandIntensityM { Dept = b.DEPT, Name = a.NAME_C, sKey = d.sName, trCourse_sCode = c.trCourse_sCode, iDemandIntensitym = c.iDemandIntensityM };
        ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", DemandIntensityM1));
        ReportViewer1.DataBind();
        ReportViewer1.ServerReport.Refresh();
    }
}