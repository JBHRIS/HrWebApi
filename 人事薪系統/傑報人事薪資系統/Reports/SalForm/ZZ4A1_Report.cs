/* ======================================================================================================
 * 功能名稱：薪資分攤表
 * 功能代號：ZZ4A1
 * 功能路徑：報表列印 > 薪資 > 薪資分攤表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ4A1_Report.cs
 * 功能用途：
 *  用於產出薪資分攤表
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/05/19    Daniel Chih    Ver 1.0.01     1. 增加【清展】顯示的儲蓄金（外籍）為正數的判斷
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/05/19
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
    public partial class ZZ4A1_Report : JBControls.JBForm
    {
        SalDataSet ds = new SalDataSet();
        string type_data, dept_type, nobr_b, nobr_e, dept_b, dept_e, depts_b, depts_e, year, month, seq, date_b;
        string username, workadr, note, yymm, reporttype, repo_name, adate, emp_b, emp_e, comp_name, work_b, work_e, CompId;
        bool exportexcel;
        public ZZ4A1_Report(string typedata, string depttype, string nobrb, string nobre, string deptsb, string deptse, string empb, string empe, string workb, string worke, string _year, string _month, string _seq, string dateb, string _username, string _workadr, string _reporttype, string reponame, bool _exportexcel, string _CompId, string compname)
        {
            InitializeComponent();
            type_data = typedata; nobr_b = nobrb; nobr_e = nobre; depts_b = deptsb;
            depts_e = deptse; year = _year; month = _month; seq = _seq; date_b = dateb;
            username = _username; workadr = _workadr; exportexcel = _exportexcel;
            dept_type = depttype; yymm = year + month; reporttype = _reporttype; repo_name = reponame;
            emp_b = empb; emp_e = empe; comp_name = compname; work_b = workb; work_e = worke;
            CompId = _CompId;
        }

        private void ZZ4A1_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                //人事資料
                string sqlCmd = "select b.nobr,a.name_c,a.name_e,b.di,b.comp,e.compname,b.adate,a.count_ma,e.account";
                sqlCmd += ", c.d_no_disp as depts,c.d_name";
                sqlCmd += " from base a,basetts b";
                sqlCmd += " left outer join depts c on b.depts=c.d_no";
                sqlCmd += " left outer join comp e on b.comp=e.comp";
                sqlCmd += string.Format(@" where a.nobr=b.nobr and '{0}' between b.adate and b.ddate", date_b);
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", depts_b, depts_e);
                sqlCmd += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);
                sqlCmd += type_data;
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                //部門分攤
                string sqlCmd4 = "select a.nobr,b.d_no_disp as depts,b.d_name,a.rate as rate from cost a";
                sqlCmd4 += " left outer join depts b on a.depts=b.d_no";
                sqlCmd4 += string.Format(@" where a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd4 += string.Format(@" and '{0}' between a.cadate and a.cddate", date_b);
                sqlCmd4 += " order by a.nobr,b.d_no_disp";
                DataTable rq_cost = SqlConn.GetDataTable(sqlCmd4);
                rq_cost.Columns.Add("amt", typeof(int));

                //薪資相關代碼
                string CmdSalcode = "select a.sal_code,a.sal_code_disp,a.sal_name,b.salattr,b.flag,b.type,b.tax";
                CmdSalcode += " from salcode a,salattr b where a.sal_attr=b.salattr ";
                DataTable rq_salcode = SqlConn.GetDataTable(CmdSalcode);
                rq_salcode.PrimaryKey = new DataColumn[] { rq_salcode.Columns["sal_code"] };

                //薪資主檔
                string sqlCmd1 = "select nobr,cash,adate from wage";
                sqlCmd1 += string.Format(@" where nobr between '{0}' and '{1}' ", nobr_b, nobr_e);
                sqlCmd1 += string.Format(@" and yymm='{0}' and seq='{1}'", yymm, seq);
                sqlCmd1 += workadr;
                DataTable rq_wage = SqlConn.GetDataTable(sqlCmd1);
                rq_wage.PrimaryKey = new DataColumn[] { rq_wage.Columns["nobr"] };
                if (rq_wage.Rows.Count > 0)
                    adate = DateTime.Parse(rq_wage.Rows[0]["adate"].ToString()).ToString("yyyy/MM/dd");

                //薪資明細
                string sqlCmd2 = "select nobr,sal_code,amt from waged";
                sqlCmd2 += string.Format(@" where nobr between '{0}' and '{1}' ", nobr_b, nobr_e);
                sqlCmd2 += string.Format(@" and yymm='{0}' and seq='{1}'", yymm, seq);
                sqlCmd2 += " and sal_code<> '' order by nobr";
                DataTable rq_waged = SqlConn.GetDataTable(sqlCmd2);
                rq_waged.Columns.Add("adate", typeof(DateTime));
                rq_waged.Columns.Add("name_c", typeof(string));
                rq_waged.Columns.Add("depts", typeof(string));
                rq_waged.Columns.Add("ds_name", typeof(string));
                rq_waged.Columns.Add("di", typeof(string));
                rq_waged.Columns.Add("sal_name", typeof(string));
                rq_waged.Columns.Add("salattr", typeof(string));
                rq_waged.Columns.Add("flag", typeof(string));
                rq_waged.Columns.Add("count_ma", typeof(bool));
                rq_waged.Columns.Add("rate", typeof(decimal));
                foreach (DataRow Row in rq_waged.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    DataRow row1 = rq_wage.Rows.Find(Row["nobr"].ToString());
                    DataRow row2 = rq_salcode.Rows.Find(Row["sal_code"].ToString());
                    if (row != null && row1 != null)
                    {
                        Row["name_c"] = row["name_c"].ToString();
                        Row["di"] = row["di"].ToString();
                        Row["depts"] = row["depts"].ToString();
                        Row["ds_name"] = row["d_name"].ToString();
                        if (row2 != null)
                        {
                            Row["sal_code"] = row2["sal_code_disp"].ToString();
                            Row["salattr"] = row2["salattr"].ToString();
                            Row["sal_name"] = row2["sal_name"].ToString().Trim();
                            Row["flag"] = row2["flag"].ToString();
                        }
                        if (Row["flag"].ToString().Trim() == "-")
                        {
                            //判斷是不是清展
                            //Added By Daniel Chih - 2021/05/19
                            if (comp_name == "清展科技有限公司")
                            {
                                //若是則判斷薪資代碼是否為儲蓄金（外籍）
                                if (Row["sal_code"].ToString().Trim() == "B06")
                                {
                                    //若是，則顯示為正數
                                    Row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));
                                }
                                else
                                {
                                    Row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString())) * (-1);
                                }
                            }
                            //若不是則維持原規則
                            else
                            {
                                Row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString())) * (-1);
                            }
                        }
                        else
                            Row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));
                    }
                    else
                        Row.Delete();
                }
                rq_waged.AcceptChanges();
                if (rq_waged.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                DataTable rq_wagedb = new DataTable();
                rq_wagedb = rq_waged.Clone();
                rq_wagedb.TableName = "rq_wagedb";
                rq_wagedb.Columns.Add("rowcnt", typeof(int));
                JBHR.Reports.SalForm.ZZ4A1Class.GeWagedb(rq_cost, rq_waged, rq_wagedb);

                DataTable rq_wagedc = new DataTable();
                JBHR.Reports.SalForm.ZZ4A1Class.GeWagedc(rq_wagedb, rq_wagedc);
                JBHR.Reports.SalForm.ZZ4A1Class.GetWaged1(rq_waged, rq_wagedb, rq_wagedc);

                //求得應稅合計金額
                DataTable rq_wages1 = new DataTable();
                rq_wages1.Columns.Add("nobr", typeof(string));
                rq_wages1.Columns.Add("depts", typeof(string));
                rq_wages1.Columns.Add("amt", typeof(int));
                JBHR.Reports.SalForm.ZZ4A1Class.GetWageds1(rq_wages1, rq_waged);

                //求得應發合計金額
                DataTable rq_sys41 = SqlConn.GetDataTable("select retsalcode from u_sys4 where comp='" + CompId + "'");
                string retsalcode = "";
                if (rq_sys41.Rows.Count > 0)
                {
                    DataRow row1 = rq_salcode.Rows.Find(rq_sys41.Rows[0]["retsalcode"].ToString());
                    if (row1 != null)
                        retsalcode = row1["sal_code_disp"].ToString();
                }
                DataTable rq_wages2 = new DataTable();
                rq_wages2.Columns.Add("nobr", typeof(string));
                rq_wages2.Columns.Add("depts", typeof(string));
                rq_wages2.Columns.Add("amt", typeof(int));
                JBHR.Reports.SalForm.ZZ4A1Class.GetWageds2(rq_wages2, rq_waged, retsalcode);

                //求得合計金額
                DataTable rq_wagesz = new DataTable();
                rq_wagesz.Columns.Add("nobr", typeof(string));
                rq_wagesz.Columns.Add("depts", typeof(string));
                rq_wagesz.Columns.Add("amt", typeof(int));
                JBHR.Reports.SalForm.ZZ4A1Class.GetWagedsz(rq_wagesz, rq_waged);

                //產生橫向表頭
                DataTable rq_zz4a1t = new DataTable();
                rq_zz4a1t.Columns.Add("sal_code", typeof(string));
                rq_zz4a1t.Columns.Add("sal_name", typeof(string));
                rq_zz4a1t.PrimaryKey = new DataColumn[] { rq_zz4a1t.Columns["sal_code"] };

                JBHR.Reports.SalForm.ZZ4A1Class.GetZz4a1t(rq_zz4a1t, rq_waged, ds.Tables["zz4a1ta2"]);
                //JBHR.Reports.ReportClass.Export(rq_zz4a1t, this.Name);

                JBHR.Reports.SalForm.ZZ4A1Class.Get_ZZ4a1td(ds.Tables["zz4a1td2"], rq_waged, rq_wages1, rq_wages2, rq_wagesz, rq_zz4a1t);

                if (reporttype == "1")
                    JBHR.Reports.SalForm.ZZ4A1Class.Get_ZZ4a1td4(ds.Tables["zz4a1td2"], rq_zz4a1t);
                rq_base = null; rq_cost = null; rq_salcode = null; rq_sys41 = null; rq_wage = null;
                rq_waged = null; rq_wagedb = null; rq_wagedc = null; rq_wages1 = null; rq_wages2 = null;
                rq_wagesz = null; rq_zz4a1t = null;
                if (exportexcel)
                {
                    JBHR.Reports.SalForm.ZZ4A1Class.ExPort(ds.Tables["zz4a1td2"], ds.Tables["zz4a1ta2"], this.Name, reporttype);
                    this.Close();
                }
                else
                {
                    RptViewer.Reset();
                    RptViewer.Visible = true;
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "SalReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "SalReport", "*.rdlc");
                    if (reporttype == "0")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4a1a.rdlc";
                    else
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4a1b.rdlc";

                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("UserName", username) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYMM", yymm) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Seq", seq) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4a1td2", ds.Tables["zz4a1td2"]));
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4a1ta2", ds.Tables["zz4a1ta2"]));
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
