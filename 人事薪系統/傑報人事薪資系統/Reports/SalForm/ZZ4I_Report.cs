/* ======================================================================================================
 * 功能名稱：補扣發明細表
 * 功能代號：ZZ4I
 * 功能路徑：報表列印 > 薪資 > 補扣發明細表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ4I_Report.cs
 * 功能用途：
 *  
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/04/14    Daniel Chih    Ver 1.0.01     1. 增加主要與次要排序的項目條件
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/04/14
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
    public partial class ZZ4I_Report : JBControls.JBForm
    {
        SalDataSet ds = new SalDataSet();
        string nobr_b, nobr_e, dept_b, dept_e, date_b , depts_b, depts_e, yy, mm, seq, yymm, salcode_b, salcode_e,emp_b,emp_e, workadr, comp_name, mainsort, minorsort;
        bool exportexcel, page_check;
        public ZZ4I_Report(string nobrb, string nobre, string deptb, string depte, string deptsb, string deptse, string salcodeb, string salcodee
            ,string empb,string empe, string dateb, string _yy, string _mm, string _seq, string _workadr, bool _exportexcel, bool _page_check, string compname
            ,string main_sort, string minor_sort)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; depts_b = deptsb; depts_e = deptse; date_b = dateb;
            yymm = _yy + _mm; seq = _seq; workadr = _workadr; exportexcel = _exportexcel; page_check = _page_check;
            salcode_b = salcodeb; salcode_e = salcodee; comp_name = compname;
            emp_b = empb; emp_e = empe; mainsort = main_sort; minorsort = minor_sort;
        }

        private void ZZ4I_Report_Load(object sender, EventArgs e)
        {
            try 
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select b.nobr,a.name_c,a.name_e,c.d_no_disp as dept,c.d_name,c.d_ename,d.d_no_disp as depts,d.d_name as ds_name from base a,basetts b";
                sqlCmd += " left join dept c on b.dept=c.d_no";
                sqlCmd += " left join depts d on b.depts=d.d_no";
                sqlCmd += " where a.nobr=b.nobr and b.dept=c.d_no";
                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_b);
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd += string.Format(@" and d.d_no_disp between '{0}' and '{1}'", depts_b, depts_e);
                sqlCmd += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);
                sqlCmd += workadr;
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                string sqlCmd1 = "select a.nobr,b.sal_code_disp as sal_code,b.sal_name,a.amt,a.memo from enrich a,salcode b";
                sqlCmd1 += " where a.sal_code=b.sal_code";
                sqlCmd1 += string.Format(@" and yymm='{0}' and seq='{1}'", yymm, seq);
                sqlCmd1 +=string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd1 += string.Format(@" and b.sal_code_disp between '{0}' and '{1}'", salcode_b, salcode_e);
                sqlCmd1 += " order by b.sal_code_disp";
                DataTable rq_enrich = SqlConn.GetDataTable(sqlCmd1);


                foreach (DataRow Row in rq_enrich.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        DataRow aRow = ds.Tables["zz4i"].NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["name_c"] = row["name_c"].ToString();
                        aRow["name_e"] = row["name_e"].ToString();
                        aRow["dept"] = row["dept"].ToString();
                        aRow["d_name"] = row["d_name"].ToString();
                        aRow["depts"] = row["depts"].ToString();
                        aRow["ds_name"] = row["ds_name"].ToString();
                        aRow["d_ename"] = row["d_ename"].ToString();
                        aRow["sal_code"] = Row["sal_code"].ToString();
                        aRow["sal_name"] = Row["sal_name"].ToString();
                        aRow["meno"] = Row["memo"].ToString();
                        aRow["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));
                        ds.Tables["zz4i"].Rows.Add(aRow);
                    }
                }
                rq_base = null; rq_enrich = null;
                if (ds.Tables["zz4i"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                //重新排序
                DataView temp_result = ds.Tables["zz4i"].DefaultView;
                temp_result.Sort = " " + mainsort + ", " + minorsort + " ";
                DataTable result_table = temp_result.ToTable();
                ds.Tables["zz4i"].Clear();
                foreach (DataRow result_row in result_table.Rows)
                {
                    DataRow aRow = ds.Tables["zz4i"].NewRow();
                    aRow["nobr"] = result_row["nobr"].ToString();
                    aRow["name_c"] = result_row["name_c"].ToString();
                    aRow["name_e"] = result_row["name_e"].ToString();
                    aRow["dept"] = result_row["dept"].ToString();
                    aRow["d_name"] = result_row["d_name"].ToString();
                    aRow["depts"] = result_row["depts"].ToString();
                    aRow["ds_name"] = result_row["ds_name"].ToString();
                    aRow["d_ename"] = result_row["d_ename"].ToString();
                    aRow["sal_code"] = result_row["sal_code"].ToString();
                    aRow["sal_name"] = result_row["sal_name"].ToString();
                    aRow["meno"] = result_row["meno"].ToString();
                    aRow["amt"] = Convert.ToDecimal(result_row["amt"].ToString());
                    ds.Tables["zz4i"].Rows.Add(aRow);
                }

                if (exportexcel)
                {
                    Export(ds.Tables["zz4i"]);
                    this.Close();
                }
                else
                {                  
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "SalReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "SalReport", "*.rdlc");
                    if(page_check == true)
                    {
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4i_Page_Check.rdlc";
                    }
                    else
                    {
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4i.rdlc";
                    }

                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYMM", yymm) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Seq", seq) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("MainSort", mainsort) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("MinorSort", minorsort) });

                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4i", ds.Tables["zz4i"]));
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

        void Export(DataTable DT)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("英文部門名稱", typeof(string));
            ExporDt.Columns.Add("成本部門", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            ExporDt.Columns.Add("薪資代碼", typeof(string));
            ExporDt.Columns.Add("薪資名稱", typeof(string));
            ExporDt.Columns.Add("金額", typeof(int));
            ExporDt.Columns.Add("備註", typeof(string));
            DataRow[] Srow = DT.Select("", "dept,sal_code asc");
            foreach (DataRow Row01 in Srow)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row01["dept"].ToString();
                aRow["部門名稱"] = Row01["d_name"].ToString();
                aRow["英文部門名稱"] = Row01["d_ename"].ToString();
                aRow["成本部門"] = Row01["depts"].ToString();
                aRow["員工編號"] = Row01["nobr"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();
                aRow["英文姓名"] = Row01["name_e"].ToString();
                aRow["薪資代碼"] = Row01["sal_code"].ToString();
                aRow["薪資名稱"] = Row01["sal_name"].ToString();
                aRow["金額"] = int.Parse(Row01["amt"].ToString());
                aRow["備註"] = Row01["meno"].ToString();
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
