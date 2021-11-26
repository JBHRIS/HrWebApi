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
    public partial class Payslip : ExtendPage
    {
        private dsBas Nds = new dsBas();

        

        private void DisableClientBehavior(IAttributeAccessor control)
        {
            // disable copy
            control.SetAttribute("oncopy", "return false;");
            // disable right mouse button
            control.SetAttribute("oncontextmenu", "return false;");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //Page.Init += (o, args) => { Response.Write("In Page Init"); };

            //this.Page.EnableViewState = false;
            DisableClientBehavior(Page.Form);

            if (!this.IsPostBack)
            {
                string salaryEmpId = Request.QueryString["salary_nobr"] as string;
                string salaryYear =  Request.QueryString["salary_year"] as string;
                string salaryMonth = Request.QueryString["salary_month"] as string;
                string salarySeq =   Request.QueryString["salary_seq"] as string;
                string salaryLang = Request.QueryString["salary_lang"] as string;
                //string plainTextPassword = Request.QueryString["PTP"] as string;
                //plainTextPassword = "123";

                //bool isAuth = Authentication.isAuthentication(salaryEmpId, plainTextPassword);
                //isAuth = true;

                //if (isAuth)
                //{
                //    //RptViewer.KeepSessionAlive = false;
                //    lblNobr.Text = salaryEmpId;
                //    //Panel1.Visible = true;
                //    lblYear.Text = "2015";
                //	lblMonth.Text = "02";
                //	lblSeq.Text = "2";
                //    //btnSearch_Click(null, null);NewMethod
                //    NewMethod();
                //}
                //else
                //{
                //    Page.Visible = false;
                //}

                //測試用
                //salaryEmpId = "960142";
                //salaryYear = "2017";
                //salaryMonth = "01";
                //salarySeq = "2";

                lblNobr.Text = salaryEmpId;
                lblYear.Text = salaryYear;
                lblMonth.Text = salaryMonth;
                lblSeq.Text = salarySeq;
                lblLang.Text = salaryLang;
                ShowData();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //string sYear = ddlYear.SelectedItem.Value;
            //string sMonth = ddlMonth.SelectedItem.Value;
            //string sSeq = ddlSeq.SelectedItem.Value;
            ShowData();
        }

        private void ShowData()
        {
            string sYear = lblYear.Text;
            string sMonth = lblMonth.Text;
            string sSeq = lblSeq.Text;
            string sLang = lblLang.Text;
            bool salaryen = (sLang == "EN") ? bool.Parse("True") : bool.Parse("False");           

            string sYYMM = sYear + sMonth;
            DateTime dDateB, dDateE;
            dDateB = DateTime.Parse(Convert.ToString(Convert.ToInt32(sYear)) + "/01/01");
            dDateE = DateTime.Parse(Convert.ToString(Convert.ToInt32(sYear)) + "/" + sMonth + "/01").AddMonths(1).AddDays(-1);

            lblMsg.Text = "查詢成功(Review success)";

            string yymm, seq, date_b, nobr;
            DateTime bdate;
            yymm = sYear + sMonth;
            seq = sSeq;
            date_b = Convert.ToString(DateTime.Parse(Convert.ToString(decimal.Parse(sYear)) + "/" + sMonth + "/01").AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd"));
            nobr = lblNobr.Text;

            bdate = DateTime.Parse(Convert.ToString(decimal.Parse(sYear)) + "/01/01");

            BasClass bc = new BasClass();
            //薪資查詢
            DataTable rq_base = bc.GetBase(nobr, date_b);
            string comp = string.Empty; string compname = string.Empty; string jobs_name = string.Empty; string workcd = string.Empty; string Note = string.Empty;
            if (rq_base.Rows.Count > 0)
            {
                comp = rq_base.Rows[0]["comp"].ToString();
                compname = rq_base.Rows[0]["compname"].ToString();
                jobs_name = rq_base.Rows[0]["jobs_name"].ToString();
                workcd = rq_base.Rows[0]["workcd"].ToString();
                if (jobs_name == "Contractor")
                    jobs_name = "Non - Exempt";
            }
            DataTable rq_waged = bc.GetWaged(nobr, yymm, seq, rq_base, salaryen);
            //if (rq_waged.Rows.Count < 1)
            //{
            //    lblMsg.Text = "無此條件的發薪資料";
            //    //lblMsg.Text = "No data";
            //    return;
            //}
            JBModule.Data.ApplicationConfigSettings AppConfig = new JBModule.Data.ApplicationConfigSettings("ZZ42", comp);
            Note = AppConfig.GetConfig("SalaryNOte").Value;
            //薪資計算出勤區間
            string att_dateb = string.Empty;
            string att_datee = string.Empty;
            if (rq_waged.Rows[0].IsNull("att_dateb"))
            {
                att_dateb = DateTime.Parse(rq_waged.Rows[0]["date_e"].ToString()).AddMonths(-1).AddDays(26).ToString("yyyy/MM/dd");
                att_datee = DateTime.Parse(rq_waged.Rows[0]["date_e"].ToString()).AddDays(25).ToString("yyyy/MM/dd");
            }
            else
            {
                //att_dateb = DateTime.Parse(rq_waged.Rows[0]["att_dateb"].ToString()).ToString("yyyy/MM/dd");
                //att_datee = DateTime.Parse(rq_waged.Rows[0]["att_datee"].ToString()).ToString("yyyy/MM/dd");
                att_dateb = DateTime.Parse(Convert.ToString(Convert.ToInt32(sYear)) + "/" + sMonth + "/01").ToString("yyyy/MM/dd");
                att_datee = DateTime.Parse(Convert.ToString(Convert.ToInt32(sYear)) + "/" + sMonth + "/01").AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd");
            }

            //加班資料
            //DataTable rq_ot1 = bc.GetOt(nobr, yymm);
            //DataTable rq_ot = new DataTable();
            //rq_ot.Columns.Add("nobr", typeof(string));
            //rq_ot.Columns.Add("ot_100", typeof(decimal));
            //rq_ot.Columns.Add("ot_133", typeof(decimal));
            //rq_ot.Columns.Add("ot_150", typeof(decimal));
            //rq_ot.Columns.Add("ot_167", typeof(decimal));
            //rq_ot.Columns.Add("ot_200", typeof(decimal));
            //rq_ot.Columns.Add("ot_200_h", typeof(decimal));
            //rq_ot.Columns.Add("ot_250_h", typeof(decimal));
            //rq_ot.Columns.Add("weekhrs", typeof(decimal));
            //rq_ot.Columns.Add("holihrs", typeof(decimal));
            //rq_ot.PrimaryKey = new DataColumn[] { rq_ot.Columns["nobr"] };
            DataTable rq_ot = new DataTable();
            rq_ot.Columns.Add("nobr", typeof(string));
            rq_ot.Columns.Add("rate", typeof(decimal));
            rq_ot.Columns.Add("othrs", typeof(decimal));
            rq_ot.PrimaryKey = new DataColumn[] { rq_ot.Columns["nobr"], rq_ot.Columns["rate"] };
            if(seq=="2")
            {
                DataTable rq_ot1 = bc.GetOt(nobr, yymm);
                bc.Get_Ot1(rq_ot, rq_ot1);
            }

            
            
            
            //加入勞退金額及計算在保眷屬人數
            DataTable rq_reta = bc.Get_Reta(nobr, att_dateb, att_datee);
            rq_reta.PrimaryKey = new DataColumn[] { rq_reta.Columns["nobr"] };

            //請假資料
            DataTable rq_abs = bc.Get_Abs(nobr, yymm, salaryen);

            //string[] workcds = new string[] { "0", "1", "2" };
            //if (!workcds.Contains(workcd))
            //{
            //    att_dateb = DateTime.Parse(att_dateb).AddMonths(-1).ToString("yyyy/MM/dd");
            //    att_datee = DateTime.Parse(att_dateb).AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd");
            //}
            //出勤遲到
            DataTable rq_attend = bc.Get_Attend(nobr, att_dateb, att_datee);
            rq_attend.PrimaryKey = new DataColumn[] { rq_attend.Columns["nobr"] };


            //特休及補休剩餘時數
            string attdateb = sYear + "/01/01";
            string attdatee = DateTime.Now.ToString("yyyy/MM/dd");
            DataTable rq_abs1 = bc.Get_Abs1(nobr, attdatee);
            rq_abs1.PrimaryKey = new DataColumn[] { rq_abs1.Columns["nobr"] };
            //DataTable rq_annua = bc.Get_Annua(nobr, attdateb, attdatee);

            //勞退公司負擔
            DataTable rq_ret = bc.Get_Ret(nobr, yymm, date_b);
            rq_ret.PrimaryKey = new DataColumn[] { rq_ret.Columns["nobr"] };

            //勞退公司負擔總額
            DataTable rq_yretcomp = bc.Get_AllRet(nobr, yymm);

            ////累計自提退休金
            //DataTable rq_personret = bc.Get_PersonRet(nobr, yymm, comp);

            ////扣項及免稅合計
            //DataTable rq_sala = bc.Get_Sala(rq_waged);

            

            //產生薪資單資料        
            Nds.Tables["rq_salary"].PrimaryKey = new DataColumn[] { Nds.Tables["rq_salary"].Columns["nobr"] };
            DataTable dt_salary = Nds.Tables["rq_salary"].Clone();
            bc.GetSalay(dt_salary, rq_waged, rq_ot, rq_abs, rq_abs1, rq_attend, rq_ret, rq_reta, rq_yretcomp, comp, salaryen);
            Nds.Tables["rq_salary"].Merge(dt_salary);
           
            dsBas ds = new dsBas();

            ds.Tables["rq_salary"].Merge(dt_salary);
            

            if (ds.Tables["rq_salary"].Rows.Count > 0)
            {

                RptViewer.Visible = true;
                RptViewer.Reset();
                //RptViewer.LocalReport.ReportPath = Server.MapPath("~/Salary/Rpt_Salary2.rdlc");
                if (sSeq.Trim() == "2")
                    RptViewer.LocalReport.ReportPath = Server.MapPath("Rpt_zz4219.rdlc");
                else
                    RptViewer.LocalReport.ReportPath = Server.MapPath("Rpt_zz4219a.rdlc");
                //if (salaryen)
                //{
                //    if (sSeq.Trim() == "2")
                //        RptViewer.LocalReport.ReportPath = Server.MapPath("Rpt_zz4219c.rdlc");
                //    else
                //        RptViewer.LocalReport.ReportPath = Server.MapPath("Rpt_zz4219ac.rdlc");
                //}
                //else
                //{
                //    if (sSeq.Trim() == "2")
                //        RptViewer.LocalReport.ReportPath = Server.MapPath("Rpt_Salary2.rdlc");
                //    else
                //        RptViewer.LocalReport.ReportPath = Server.MapPath("Rpt_Salary2a.rdlc");

                //}
                RptViewer.LocalReport.DataSources.Clear();
                RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4219", Nds.Tables["rq_salary"]));               
                RptViewer.LocalReport.SetParameters(new ReportParameter("YY", sYear));
                RptViewer.LocalReport.SetParameters(new ReportParameter("MM", sMonth));
                RptViewer.LocalReport.SetParameters(new ReportParameter("Company", compname));
                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("SEQ", sSeq) });
                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Note", Note) });
                this.RptViewer.LocalReport.Refresh();
            }
        }
    }
}