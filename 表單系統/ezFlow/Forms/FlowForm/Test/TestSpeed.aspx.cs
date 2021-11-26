using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Test_TestSpeed : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnDll_Click(object sender, EventArgs e)
    {
        DateTime d1 = DateTime.Now;

        dcFlowDataContext dcFlow = new dcFlowDataContext();
        Dal.Dao.Flow.MainDao oMainDao = new Dal.Dao.Flow.MainDao(dcFlow.Connection);
        gv.DataSource = oMainDao.GetFlowSearchComplete(txtNobr.Text, new DateTime(1900, 1, 1), new DateTime(9999, 12, 31));
        gv.DataBind();

        DateTime d2 = DateTime.Now;

        TimeSpan ts = d2 - d1;

        lblTime.Text = ts.TotalSeconds.ToString();
    }
    protected void btnService_Click(object sender, EventArgs e)
    {
        DateTime d1 = DateTime.Now;

        FlowWebServices.ServiceClient oServiceClient = new FlowWebServices.ServiceClient();
        gv.DataSource = oServiceClient.GetFlowSearchComplete(txtNobr.Text, new DateTime(1900, 1, 1), new DateTime(9999, 12, 31));
        gv.DataBind();

        DateTime d2 = DateTime.Now;

        TimeSpan ts = d2 - d1;

        lblTime.Text = ts.TotalSeconds.ToString();
    }
    protected void btnOldService_Click(object sender, EventArgs e)
    {
        DateTime d1 = DateTime.Now;

        FlowWebServicesOld.Service oService = new FlowWebServicesOld.Service();
        gv.DataSource = oService.GetFlowSearchComplete(txtNobr.Text, new DateTime(1900, 1, 1), true, new DateTime(9999, 12, 31), true);
        gv.DataBind();

        DateTime d2 = DateTime.Now;

        TimeSpan ts = d2 - d1;

        lblTime.Text = ts.TotalSeconds.ToString();
    }
}