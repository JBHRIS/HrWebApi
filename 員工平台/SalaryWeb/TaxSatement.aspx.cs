using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using Microsoft.Reporting.WebForms;

namespace SalaryWeb
{
    public partial class TaxSatement : ExtendPage
    {
        private dsBas Nds = new dsBas();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!this.IsPostBack)
            //{
            //    Panel1.Visible = true;
            //    lblNobr.Text = "G00001";
            //    lblYear.Text = "2014";
            //}

            string empId = Request.QueryString["salary_nobr"] as string;
            string year = Request.QueryString["salary_year"] as string;

            lblNobr.Text = empId;
            lblYear.Text = year;
            ShowMethod();
        }

        //protected void btnSearch_Click(object sender, EventArgs e)
        //{
        //    ShowMethod();
        //}

        private void ShowMethod()
        {
            string sYear = lblYear.Text;
            //if (Panel1.Visible == true)
            //{
            //    if (ddlYear.SelectedIndex >= 0)
            //        sYear = ddlYear.SelectedItem.Value;
            //    else
            //    {
            //        lblMsg.Text = "查無此資料";
            //        return;
            //    }
            //}
            //else
            //{
            //    sYear = ddlYear1.SelectedItem.Value;
            //}

            BasClass bc = new BasClass();

            string sComp = string.Empty;
            string sNobr = lblNobr.Text;
            DataTable rq_base = bc.GetBase(sNobr, sYear + "/12/31");
            string Idno = string.Empty;
            if (rq_base.Rows.Count > 0)
            {
                Idno = rq_base.Rows[0]["idno"].ToString();
                sComp = rq_base.Rows[0]["comp"].ToString();
            }
            DataTable rq_yrtax = bc.GetYrtax(sNobr, sYear);
            //DataTable rq_comp = Salary.Base.bc.GetComp(sComp);
            //string compname = string.Empty; string chairman = string.Empty; string addr = string.Empty; string compid = string.Empty;
            //if (rq_comp.Rows.Count > 0)
            //{
            //    compname = rq_comp.Rows[0]["compname"].ToString();
            //    chairman = rq_comp.Rows[0]["chairman"].ToString();
            //    addr = rq_comp.Rows[0]["addr"].ToString();
            //    compid = rq_comp.Rows[0]["compid"].ToString();
            //}
            Nds.Tables["rq_yrtax"].Merge(rq_yrtax);

            if (Nds.Tables["rq_yrtax"].Rows.Count > 0)
            {
                RptViewer.Visible = true;
                RptViewer.Reset();
                RptViewer.LocalReport.ReportPath = Server.MapPath("Rpt_TaxSatement.rdlc");
                RptViewer.LocalReport.DataSources.Clear();
                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Year", sYear) });
                //RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", compname) });
                //RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Compaddr", addr) });
                //RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Compman", chairman) });
                //RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Compid", compid) });
                RptViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", Nds.Tables["rq_yrtax"]));
                this.RptViewer.LocalReport.Refresh();
            }
            else
            {
                lblMsg.Text = "查無此資料";
                return;
            }
        }
    }
}