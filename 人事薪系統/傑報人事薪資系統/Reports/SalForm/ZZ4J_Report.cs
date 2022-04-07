/* ======================================================================================================
 * 功能名稱：實際發放薪資平均表
 * 功能代號：ZZ4J
 * 功能路徑：報表列印 > 薪資 > 實際發放薪資平均表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ4J_Report.cs
 * 功能用途：
 *  用於產出實際發放薪資平均表
 */
/* 版本記錄：
 * ======================================================================================================
 *    日期           人員               版本              單號              說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/11/16    Daniel Chih        Ver 1.0.01    20211116-DC0492-03    1. 報表文字修改
 * 
 */
/* ======================================================================================================
 *
 * 最後修改：Daniel Chih (0492) - 2021/11/16
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace JBHR.Reports.SalForm
{
    public partial class ZZ4J_Report : JBControls.JBForm
    {
        SalDataSet ds = new SalDataSet();
        string nobr_b, nobr_e, dept_b, dept_e, date_b,seq_b, yymm_b, seq_e, yymm_e, jobl_b, jobl_e;
        string typedata, workadr, reporttype, typedataname, comp_name, CompId,emp_b,emp_e;
        bool exportexcel;
        public ZZ4J_Report(string nobrb, string nobre, string deptb, string depte,string joblb, string joble, string empb,string empe, string dateb, string _yyb, string _mmb, string _seqb, string _yye, string _mme, string _seqe, string _typedata, string _workadr, string _reporttype, bool _exportexcel, string compname, string _CompId)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; typedata = _typedata;
            workadr = _workadr; exportexcel = _exportexcel; date_b = dateb; reporttype = _reporttype;
            yymm_b = _yyb + _mmb; seq_b = _seqb; yymm_e = _yye + _mme; seq_e = _seqe; CompId = _CompId;
            comp_name = compname; emp_b = empb; emp_e = empe; jobl_b = joblb; jobl_e = joble;
        }

        private void ZZ4J_Report_Load(object sender, EventArgs e)
        {
            try
            {
                //需求單號：20211116-DC0492-03
                typedataname = (typedata == "1") ? "含加班費,伙食費" : "不含加班費,伙食費";
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select a.nobr,a.name_c,a.name_e,c.d_no_disp as dept,c.d_name,c.d_ename,b.indt,b.stdt,b.stindt,a.birdt";
                sqlCmd += ",d.job_disp as job,d.job_name,e.jobl_disp as jobl,e.job_name as jobl_name ";
                sqlCmd += " from base a,basetts b";
                sqlCmd += " left outer join dept c on b.dept=c.d_no";
                sqlCmd += " left outer join job d on b.job=d.job";
                sqlCmd += " left outer join jobl e on b.jobl =e.jobl";
                sqlCmd += " where a.nobr=b.nobr";
                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_b);
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);
                sqlCmd += string.Format(@" and e.jobl_disp between '{0}' and '{1}'", jobl_b, jobl_e);
                sqlCmd += " and b.ttscode in ('1','4','6')";                
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                string sqlCmd1 = "select nobr,yymm,seq from wage";
                sqlCmd1 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd1 += string.Format(@" and yymm between '{0}' and '{1}'", yymm_b, yymm_e);
                sqlCmd1 += string.Format(@" and seq between '{0}' and '{1}'", seq_b, seq_e);
                sqlCmd1 += workadr;
                DataTable rq_wage = SqlConn.GetDataTable(sqlCmd1);
                DataColumn[] _key = new DataColumn[3];
                _key[0] = rq_wage.Columns["nobr"];
                _key[1] = rq_wage.Columns["yymm"];
                _key[2] = rq_wage.Columns["seq"];
                rq_wage.PrimaryKey = _key;

                DataTable rq_sys4 = SqlConn.GetDataTable("select retsalcode from u_sys4 where comp='" + CompId + "'");
                string retsalcode = (rq_sys4.Rows.Count > 0) ? rq_sys4.Rows[0]["retsalcode"].ToString() : "";
                DataTable rq_sys3 = SqlConn.GetDataTable("select notaxsalcode,totaxsalcode from u_sys3 where comp='" + CompId + "'");
                string notaxsalcode = ""; string totaxsalcode = "";
                if (rq_sys3.Rows.Count > 0)
                {
                    notaxsalcode = rq_sys3.Rows[0]["notaxsalcode"].ToString();
                    totaxsalcode = rq_sys3.Rows[0]["totaxsalcode"].ToString();
                }
                string sqlCmd2 = "select nobr,yymm,seq,sal_code,amt from waged";
                sqlCmd2 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd2 += string.Format(@" and yymm between '{0}' and '{1}'", yymm_b, yymm_e);
                sqlCmd2 += string.Format(@" and seq between '{0}' and '{1}'", seq_b, seq_e);
                //sqlCmd2 += " and sal_code not in ('D02','D04','D06')";
                if (typedata == "2") sqlCmd2 += string.Format(@" and sal_code !='{0}' and sal_code!='{1}'", notaxsalcode, totaxsalcode);
                sqlCmd2 += string.Format(@" and sal_code <> '{0}'", retsalcode);
                sqlCmd2 += " order by nobr,yymm";
                DataTable rq_waged = SqlConn.GetDataTable(sqlCmd2);
                rq_waged.Columns.Add("flag", typeof(string));

                string sqlCmd3 = "select a.sal_code,a.sal_code_disp,b.flag from salcode a,salattr b";
                sqlCmd3 += string.Format(@" where a.sal_attr=b.salattr and a.sal_code <> '{0}'", retsalcode);
                sqlCmd3 += " and  a.sal_attr <='L'";
                DataTable rq_salcode = SqlConn.GetDataTable(sqlCmd3);
                rq_salcode.PrimaryKey = new DataColumn[] { rq_salcode.Columns["sal_code"] };
                

                //計算停薪留職
                string sqlCmd4 = "select nobr,sum(datediff(day,stdt,stindt)) as day from basetts";
                sqlCmd4 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd4 += string.Format(@" and dept between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd4 += " and stdt is not null and stindt is not null and ttscode='4'";
                sqlCmd4 += " group by nobr";
                DataTable rq_day = SqlConn.GetDataTable(sqlCmd4);
                rq_day.PrimaryKey = new DataColumn[] { rq_day.Columns["nobr"] };
                switch (reporttype)
                {
                    case "0":
                        JBHR.Reports.SalForm.ZZ4JClass.Get_ZZ4J(ds.Tables["zz4j"], rq_waged, rq_wage, rq_salcode, rq_day, rq_base, date_b);
                        //JBModule.Data.CNPOI.RenderDataTableToExcel(ds.Tables["zz4j"], "C:\\TEMP\\" + this.Name + ".xls");
                        //System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
                        if (ds.Tables["zz4j"].Rows.Count < 1)
                        {
                            MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                            this.Close();
                            return;
                        }
                        break;
                    case "1":
                        JBHR.Reports.SalForm.ZZ4JClass.Get_ZZ4J1(ds.Tables["zz4j1"], rq_waged, rq_wage, rq_salcode, rq_day, rq_base, date_b);
                        if (ds.Tables["zz4j1"].Rows.Count < 1)
                        {
                            MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                            this.Close();
                            return;
                        }
                        break;
                    case "2":
                        string sqlCmd5 = "select nobr,sal_code,amt from salbasd";
                        sqlCmd5 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                        sqlCmd5 += string.Format(@" and '{0}' between adate and ddate", date_b);
                        sqlCmd5 += string.Format(@" and sal_code <> '{0}'", retsalcode);
                        DataTable rq_salbasd = SqlConn.GetDataTable(sqlCmd5);
                        JBHR.Reports.SalForm.ZZ4JClass.Get_ZZ4J2(ds.Tables["zz4j2"], rq_waged, rq_wage, rq_salcode, rq_base, rq_salbasd);
                        rq_salbasd = null;
                        if (ds.Tables["zz4j2"].Rows.Count < 1)
                        {
                            MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                            this.Close();
                            return;
                        }
                        break;
                    default:
                        break;
                }
                rq_base = null;
                rq_day = null;
                rq_salcode = null;
                rq_sys4 = null;
                rq_wage = null;
                rq_waged = null;



                int Count_Number = 0;
                decimal Total_Amt = 0;
                decimal Total_Amt_B = 0;

                decimal Avg_Amt = 0;
                decimal Avg_Amt_B = 0;

                decimal Total_avgiyear = 0;
                decimal Total_avgyyear = 0;
                decimal Total_avg_amt = 0;
                decimal Total_l_amt = 0;
                decimal Total_h_amt = 0;

                decimal Avg_avgiyear = 0;
                decimal Avg_avgyyear = 0;
                decimal Avg_avg_amt = 0;
                decimal Avg_l_amt = 0;
                decimal Avg_h_amt = 0;


                if (reporttype == "0")
                {
                    foreach (DataRow Result_Row in ds.Tables["zz4j"].Rows)
                    {
                        Count_Number = Count_Number + 1;
                        Total_Amt = Total_Amt + decimal.Parse(Result_Row["avgamt"].ToString());
                    }

                    Avg_Amt = Math.Round((Total_Amt / Count_Number), 2);
                }
                else if (reporttype == "1")
                {
                    foreach (DataRow Result_Row in ds.Tables["zz4j1"].Rows)
                    {

                        Count_Number = Count_Number + 1;
                        Total_avgiyear = Total_avgiyear + decimal.Parse(Result_Row["avgiyear"].ToString());
                        Total_avgyyear = Total_avgyyear + decimal.Parse(Result_Row["avgyyear"].ToString());
                        Total_avg_amt = Total_avg_amt + int.Parse(Result_Row["avg_amt"].ToString());
                        Total_l_amt = Total_l_amt + int.Parse(Result_Row["l_amt"].ToString());
                        Total_h_amt = Total_h_amt + int.Parse(Result_Row["h_amt"].ToString());
                    }
                    Avg_avgiyear = Math.Round((Total_avgiyear / Count_Number), 2);
                    Avg_avgyyear = Math.Round((Total_avgyyear / Count_Number), 2);
                    Avg_avg_amt = Math.Round((Total_avg_amt / Count_Number), 2);
                    Avg_l_amt = Math.Round((Total_l_amt / Count_Number), 2);
                    Avg_h_amt = Math.Round((Total_h_amt / Count_Number), 2);
                }
                else if (reporttype == "2")
                {
                    foreach (DataRow Result_Row in ds.Tables["zz4j2"].Rows)
                    {
                        Count_Number = Count_Number + 1;
                        Total_Amt = Total_Amt + decimal.Parse(Result_Row["mamt"].ToString());
                        Total_Amt_B = Total_Amt_B + decimal.Parse(Result_Row["a01amt"].ToString());
                    }

                    Avg_Amt = Math.Round((Total_Amt / Count_Number), 2);
                    Avg_Amt_B = Math.Round((Total_Amt_B / Count_Number), 2);
                }

                if (exportexcel)
                {
                    if (reporttype == "0")
                        JBHR.Reports.SalForm.ZZ4JClass.ExPort1(ds.Tables["zz4j"], this.Name, Count_Number, Avg_Amt);
                    else if (reporttype == "1")
                        JBHR.Reports.SalForm.ZZ4JClass.ExPort2(ds.Tables["zz4j1"], this.Name, Avg_avgiyear, Avg_avgyyear, Avg_avg_amt, Avg_l_amt, Avg_h_amt);
                    else if (reporttype == "2")
                        JBHR.Reports.SalForm.ZZ4JClass.ExPort3(ds.Tables["zz4j2"], this.Name, Count_Number, Avg_Amt, Avg_Amt_B);
                    this.Close();
                }
                else
                {
                    //string company = "";
                    //DataTable rq_sys = ReportClass.GetU_Sys();
                    //if (rq_sys.Rows.Count > 0)
                    //    company = rq_sys.Rows[0]["company"].ToString();
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "SalReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "SalReport", "*.rdlc");
                    if (reporttype == "0")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4j.rdlc";
                    else if (reporttype == "1")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4j1.rdlc";
                    else if (reporttype == "2")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4j2.rdlc";

                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    if (reporttype == "0" || reporttype == "1")
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Data_Type", typedataname) });
                    if (reporttype == "0")
                    {
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4j", ds.Tables["zz4j"]));

                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Count_Number", Count_Number.ToString()) });
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Avg_Amt", Avg_Amt.ToString()) });
                    }
                    else if (reporttype == "1")
                    {
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4j1", ds.Tables["zz4j1"]));

                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Avg_avgiyear", Avg_avgiyear.ToString()) });
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Avg_avgyyear", Avg_avgyyear.ToString()) });
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Avg_avg_amt", Avg_avg_amt.ToString()) });
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Avg_l_amt", Avg_l_amt.ToString()) });
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Avg_h_amt", Avg_h_amt.ToString()) });
                    }
                    else if (reporttype == "2")
                    {
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4j2", ds.Tables["zz4j2"]));

                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Count_Number", Count_Number.ToString()) });
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Avg_Amt", Avg_Amt.ToString()) });
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Avg_Amt_B", Avg_Amt_B.ToString()) });
                    }
                    RptViewer.SetDisplayMode(DisplayMode.PrintLayout);
                    RptViewer.ZoomMode = ZoomMode.FullPage;
                    //RptViewer.ZoomPercent = JBHR.Reports.ReportClass.GetReportPercent();
                }
            }
            catch (Exception Ex)
            {
                JBModule.Message.TextLog.WriteLog(Ex);
                MessageBox.Show(Resources.All.ExceptionStr1 + "\n" + Ex.Message + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            } 
            
        }
    }
}
