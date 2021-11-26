/* ======================================================================================================
 * 功能名稱：其他費用總表
 * 功能代號：ZZ4B
 * 功能路徑：報表列印 > 薪資 > 其他費用總表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ4B_Report.cs
 * 功能用途：
 *  
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/04/15    Daniel Chih    Ver 1.0.01     1. 增加報表內容的控制項：允許選擇全部、退休金提撥表、年終獎金提撥表
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/04/15
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
    public partial class ZZ4B_Report : JBControls.JBForm
    {
        SalDataSet ds = new SalDataSet();
        string nobr_b, nobr_e, depts_b, depts_e, year, month, seq, date_b, workadr, note, yymm, reporttype, comp_b, comp_e,emp_b,emp_e, comp_name, CompId, report_content;       
        bool exportexcel;
        public ZZ4B_Report(string nobrb, string nobre, string deptsb, string deptse,string compb,string compe,string empb,string empe, string _year, string _month, string _seq, string dateb, string _workadr, string _reporttype, string _report_content, bool _exportexcel,string compname,string _CompId)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre;depts_b = deptsb;depts_e = deptse; year = _year; month = _month; seq = _seq;
            date_b = dateb; workadr = _workadr; exportexcel = _exportexcel; comp_name = compname;
            yymm = year + month; reporttype = _reporttype; comp_b = compb; comp_e = compe; CompId = _CompId;
            emp_b = empb; emp_e = empe; report_content = _report_content;
        }

        private void ZZ4B_Report_Load(object sender, EventArgs e)
        {
            try 
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select b.nobr,a.name_c,a.name_e,a.count_ma,b.indt,c.d_no_disp as depts,c.d_name,b.comp,d.compname,b.di,b.nooldret";
                sqlCmd += "  from base a,basetts b left outer join depts c on b.depts=c.d_no";
                sqlCmd += " left outer join comp d on b.comp=d.comp";
                sqlCmd += string.Format(@" where a.nobr=b.nobr and '{0}' between b.adate and b.ddate", date_b);
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", depts_b, depts_e);
                sqlCmd += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                string sqlCmd1 = "select nobr from wage";
                sqlCmd1 += string.Format(@" where yymm='{0}' and seq='{1}'", yymm, seq);
                sqlCmd1 += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd1 += string.Format(@" and comp between '{0}' and '{1}'", comp_b, comp_e);
                sqlCmd1 +=workadr;
                sqlCmd1 += " order by nobr";
                DataTable rq_wage = SqlConn.GetDataTable(sqlCmd1);
                rq_wage.PrimaryKey = new DataColumn[] { rq_wage.Columns["nobr"] };

                string sqlCmd2 = "select nobr,yymm,seq,sal_code,amt from waged";
                sqlCmd2 += string.Format(@" where nobr between '{0}' and '{1}' ", nobr_b, nobr_e);
                sqlCmd2 += string.Format(@" and yymm='{0}' and seq='{1}'", yymm, seq);
                sqlCmd2 += " and sal_code<> '' order by nobr";                
                DataTable rq_waged = SqlConn.GetDataTable(sqlCmd2);
                if (rq_waged.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }  
                rq_waged.Columns.Add("comp", typeof(string));
                rq_waged.Columns.Add("compname", typeof(string));
                rq_waged.Columns.Add("name_c", typeof(string));
                rq_waged.Columns.Add("name_e", typeof(string));
                rq_waged.Columns.Add("noret", typeof(bool));
                rq_waged.Columns.Add("dept", typeof(string));
                rq_waged.Columns.Add("d_name", typeof(string));
                rq_waged.Columns.Add("di", typeof(string));
                rq_waged.Columns.Add("indt", typeof(DateTime));
                rq_waged.Columns.Add("count_ma", typeof(bool));
                rq_waged.Columns.Add("sal_name", typeof(string));
                rq_waged.Columns.Add("flag", typeof(string));
                rq_waged.Columns.Add("retire", typeof(bool));
                rq_waged.Columns.Add("yearpay", typeof(bool));
                rq_waged.Columns.Add("salattr", typeof(string));
                rq_waged.Columns.Add("rowcnt", typeof(int));
                rq_waged.Columns.Add("pno", typeof(decimal));
                string sqlCmd3 = "select a.sal_code,a.sal_code_disp,a.sal_name,b.flag,b.salattr,a.retire,a.yearpay";
                sqlCmd3 += " from salcode a,salattr b";
                sqlCmd3 += " where a.sal_attr=b.salattr ";
                sqlCmd3 += " and (a.yearpay='1' or a.retire='1')";
                DataTable rq_salcode = SqlConn.GetDataTable(sqlCmd3);
                rq_salcode.PrimaryKey = new DataColumn[] { rq_salcode.Columns["sal_code"] };

                string str_nobr1 = "";
                foreach (DataRow Row in rq_waged.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    DataRow row1 = rq_wage.Rows.Find(Row["nobr"].ToString());
                    DataRow row2 = rq_salcode.Rows.Find(Row["sal_code"].ToString());
                    if (row != null && row1 != null && row2!=null)
                    {
                        Row["comp"] = row["comp"].ToString();
                        Row["compname"] = row["compname"].ToString();
                        Row["name_c"] = row["name_c"].ToString();
                        Row["name_e"] = row["name_e"].ToString();
                        Row["di"] = row["di"].ToString();
                        Row["dept"] = row["depts"].ToString();
                        Row["d_name"] = row["d_name"].ToString();
                        Row["indt"] = DateTime.Parse(row["indt"].ToString());
                        Row["count_ma"] = bool.Parse(row["count_ma"].ToString());
                        Row["noret"] = bool.Parse(row["nooldret"].ToString());
                        if (row2 != null)
                        {
                            Row["sal_code"] = row2["sal_code_disp"].ToString();
                            Row["sal_name"] = row2["sal_name"].ToString();
                            Row["flag"] = row2["flag"].ToString();                           
                            Row["salattr"] = row2["salattr"].ToString();
                            Row["retire"] = bool.Parse(row2["retire"].ToString());
                            Row["yearpay"] = bool.Parse(row2["yearpay"].ToString());
                        }
                        if (Row["flag"].ToString().Trim() == "-")
                            Row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString())) * (-1);
                        else
                            Row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));
                        if (Row["nobr"].ToString() != str_nobr1)
                            Row["pno"] = 1;
                        else
                            Row["pno"] = 0;
                        str_nobr1 = Row["nobr"].ToString();
                        
                    }
                    else
                        Row.Delete();
                }
                rq_waged.AcceptChanges();
                //JBHR.Reports.ReportClass.Export(rq_waged, this.Name);
                
                //費用分攤
                string sqlCmd4 = "select a.nobr,b.d_no_disp as depts,b.d_name,a.rate from cost a";
                sqlCmd4 += " left outer join depts b on a.depts=b.d_no";
                sqlCmd4 += string.Format(@" where a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd4 += string.Format(@" and '{0}' between a.cadate and a.cddate", date_b);
                sqlCmd4 += " order by a.nobr,b.d_no_disp";
                DataTable rq_cost = SqlConn.GetDataTable(sqlCmd4);

                //提撥比率
                DataTable rq_usys4 = SqlConn.GetDataTable("select ljobper,ljobper1,retirerate,retirerate1 from u_sys4 where comp='" + CompId + "'");
                //DataTable rq_wagedb = new DataTable();
                //rq_wagedb = rq_waged.Clone();
                //rq_wagedb.TableName = "rq_wagedb";
                //JBHR.Reports.SalForm.ZZ4BClass.GetWagedb(rq_cost, rq_waged, rq_wagedb);
                
                //DataTable rq_wagedc = new DataTable();
                //rq_wagedc.Columns.Add("nobr", typeof(string));
                //rq_wagedc.Columns.Add("sal_code", typeof(string));
                //rq_wagedc.Columns.Add("amt", typeof(int));
                //rq_wagedc.PrimaryKey = new DataColumn[] { rq_wagedc.Columns["nobr"], rq_wagedc.Columns["sal_code"] };
                //JBHR.Reports.SalForm.ZZ4BClass.GetWagedc(rq_wagedb, rq_wagedc);
                //JBHR.Reports.SalForm.ZZ4BClass.GetWaged1(rq_waged, rq_wagedb, rq_wagedc);                
                
                //DataTable rq_zz4bc = new DataTable();
                //rq_zz4bc.Columns.Add("comp", typeof(string));
                //rq_zz4bc.Columns.Add("dept", typeof(string));
                //rq_zz4bc.Columns.Add("di", typeof(string));
                //rq_zz4bc.Columns.Add("ma", typeof(string));                
                //rq_zz4bc.Columns.Add("pepo", typeof(int));
                //JBHR.Reports.SalForm.ZZ4BClass.GetZz4bc(rq_waged, rq_zz4bc);

                DataTable rq_waged1 = new DataTable();
                rq_waged1 = rq_waged.Clone();
                JBHR.Reports.SalForm.ZZ4BClass.GetWagedN(rq_cost, rq_waged, rq_waged1);

                //JBHR.Reports.ReportClass.Export(rq_waged1, "rq_waged1");
                
                if (reporttype == "1")
                {
                    JBHR.Reports.SalForm.ZZ4BClass.GetZz4b(rq_waged1, ds.Tables["zz4b"], rq_usys4, report_content);
                    if (ds.Tables["zz4b"].Rows.Count < 1)
                    {
                        MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                        this.Close();
                        return;
                    }
                }
                else
                {
                    JBHR.Reports.SalForm.ZZ4BClass.GetZz4b1(rq_waged1, ds.Tables["zz4b1"], rq_usys4, report_content);
                    if (ds.Tables["zz4b1"].Rows.Count < 1)
                    {
                        MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                        this.Close();
                        return;
                    } 
                }
                
                rq_base = null; rq_cost = null;
                rq_salcode = null; rq_usys4 = null; rq_wage = null; rq_waged = null;
                //rq_wagedb = null; rq_wagedc = null; rq_zz4bc = null;
                
                if (exportexcel)
                {
                    if (reporttype=="1")
                        JBHR.Reports.SalForm.ZZ4BClass.ExPort1(ds.Tables["zz4b"], this.Name);
                    else
                        JBHR.Reports.SalForm.ZZ4BClass.ExPort2(ds.Tables["zz4b1"], this.Name);
                    this.Close();
                }
                else
                {                   
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "SalReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "SalReport", "*.rdlc");
                    if (reporttype=="1")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4b.rdlc";
                    else
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4b1.rdlc";
                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YY", year) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("MM", month) });
                    if (reporttype == "1")
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4b", ds.Tables["zz4b"]));
                    else
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4b1", ds.Tables["zz4b1"]));
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
