using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using Microsoft.Reporting.WebForms;

namespace SalaryWeb
{
    public partial class InsCertificate : ExtendPage
    {
        private dsBas Nds = new dsBas();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!this.IsPostBack)
            //{
            //    RptViewer.KeepSessionAlive = false;
            //    lblNobr.Text = "G00001";
            //    Panel1.Visible = true;
            //    lblYear.Text = "2014";
                   
            //}

            lblNobr.Text = Request.QueryString["salary_nobr"] as string;
            lblYear.Text = Request.QueryString["salary_year"] as string;
            ShowMethod();
        }

        private void ShowMethod()
        {
            string sYear = lblYear.Text;
            string sComp = string.Empty;
            string sNobr = lblNobr.Text;
            //DataTable rq_base = Salary.Base.bc.GetBase(sNobr, sYear + "/12/31");
            BasClass bc = new BasClass();

            DataTable rq_base = bc.GetBase(sNobr, DateTime.Now.ToString("yyyy/MM/dd"));
            string Idno = string.Empty;
            if (rq_base.Rows.Count > 0)
            {
                sComp = rq_base.Rows[0]["comp"].ToString();
            }
            DataTable rq_yrinsur = bc.GetYrinsur(sNobr, sYear);
            DataTable rq_comp = bc.GetComp(sComp);
            string compname = string.Empty; string chairman = string.Empty; string addr = string.Empty; string tel = string.Empty;
            if (rq_comp.Rows.Count > 0)
            {
                compname = rq_comp.Rows[0]["compname"].ToString();
                chairman = rq_comp.Rows[0]["chairman"].ToString();
                addr = rq_comp.Rows[0]["addr"].ToString();
                tel = rq_comp.Rows[0]["tel"].ToString();
            }
            if (rq_yrinsur.Rows.Count > 0)
            {
                RptViewer.Visible = true;
                RptViewer.Reset();
                lblMsg.Text = "";
                bc.GetYrinsur1(Nds.Tables["rq_yrinsur"], rq_yrinsur);
                RptViewer.LocalReport.ReportPath = Server.MapPath("Rpt_InsCertificate.rdlc");
                if (Nds.Tables["rq_yrinsur"].Rows.Count > 0)
                {
                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Year", sYear) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", compname) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Compaddr", addr) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Compman", chairman) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Tel", tel) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", Nds.Tables["rq_yrinsur"]));
                }
                else
                {
                    RptViewer.Visible = false;
                    lblMsg.Text = "查無此資料";
                    return;
                }
                this.RptViewer.LocalReport.Refresh();
            }
            else
            {
                RptViewer.Visible = false;
                lblMsg.Text = "查無此資料";
                return;
            }
        }
    }
}