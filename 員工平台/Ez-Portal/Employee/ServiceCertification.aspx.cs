using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using Microsoft.Reporting.WebForms;

public partial class Employee_ServiceCertification : JBWebPage
{
    private dsBas Nds = new dsBas();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Nds.Tables["rq_injob"].Merge(Salary.Base.BasClass.GetInJob(JbUser.NOBR));
        if (!IsPostBack)
        {
            DataTable rq_test = Salary.Base.BasClass.GetInJob(JbUser.NOBR);
            Nds.Tables["rq_injob"].Merge(rq_test);
            if (Nds.Tables["rq_injob"].Rows.Count > 0)
            {
                //Label1.Text = Nds.Tables["rq_injob"].Rows[0][0].ToString();
                DataSet RptDs = new DataSet();
                RptDs.Tables.Add("RptDT");
                RptDs.Tables["RptDT"].Merge(Nds.Tables["rq_injob"]);
                RptViewer.Visible = true;
                RptViewer.Reset();
                RptViewer.LocalReport.ReportPath = Server.MapPath("~/Employee/Rpt_Certificate.rdlc");
                RptViewer.LocalReport.DataSources.Clear();
                RptViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", Nds.Tables["rq_injob"]));
                this.RptViewer.LocalReport.Refresh();
                //ClientScript.RegisterStartupScript(this.GetType(), "123", "run();", true);
            }
        }

        //string args = Request.Params["__EVENTARGUMENT"];

        //if (args == "scriptback")
        //{
        //    RptViewer.Visible = false;
        //}
    }
    
}