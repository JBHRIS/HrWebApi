/* ======================================================================================================
 * 功能名稱：費用分攤明細表
 * 功能代號：ZZ1B
 * 功能路徑：報表列印 > 人事 > 費用分攤明細表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\EmpForm\ZZ1B_Report.cs
 * 功能用途：
 *  
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/02/01    Daniel Chih    Ver 1.0.01     1. 新增功能：增加【只列印目前在職人員】的判斷
 * 2021/05/19    Daniel Chih    Ver 1.0.02     1. 新增功能：增加【只列印加總非100%的異常人員】的判斷
 *                                             2. 修改：讓異動截止日會對失效日期有卡控作用
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

namespace JBHR.Reports.EmpForm
{
    public partial class ZZ1B_Report : JBControls.JBForm
    {       
        empdata ds = new empdata();
        string date_b, nobr_b, nobr_e, dept_b, dept_e, comp_b, comp_e, username, data_report, comp_name;
        bool exportexcel, only_current, check_sum;

        public ZZ1B_Report(string dateb, string nobrb, string nobre, string deptb, string depte, string compb, string compe, bool _exportexcel, bool _current, string _username, string datareport, string compname, bool _check_sum)
        {
            InitializeComponent();
            date_b = dateb; nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte;
            exportexcel = _exportexcel; comp_b = compb; comp_e = compe; username = _username;
            only_current = _current; data_report = datareport; comp_name = compname; check_sum = _check_sum;
        }

        private void ZZ1B_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "SELECT B.*,A.NAME_C,A.NAME_E,A.NOBR,E.D_NO_DISP AS DEPT,E.D_NAME,E.D_NAME AS DS_NAME,H.JOB_NAME ";

                sqlCmd += " FROM BASE A INNER JOIN COST B ON A.NOBR=B.NOBR ";
                sqlCmd += " INNER JOIN BASETTS D ON A.NOBR=D.NOBR ";
                sqlCmd += " LEFT OUTER JOIN DEPT E ON D.DEPT=E.D_NO ";
                sqlCmd += " LEFT OUTER JOIN JOB H ON D.JOB=H.JOB ";

                sqlCmd += " WHERE 1 = 1 ";

                sqlCmd += string.Format(@" AND '{0}' BETWEEN B.CADATE AND B.CDDATE ",date_b);

                sqlCmd += " AND D.NOBR+CONVERT(CHAR,D.ADATE,112) IN (SELECT NOBR+MAX(CONVERT(CHAR,ADATE,112)) FROM BASETTS";
                sqlCmd += string.Format(@" WHERE ADATE<'{0}' ", date_b);
                sqlCmd += string.Format(@" AND NOBR BETWEEN '{0}' AND '{1}' ", nobr_b, nobr_e);
                sqlCmd += string.Format(@" AND E.D_NO_DISP BETWEEN '{0}' AND '{1}' ", dept_b, dept_e);
                sqlCmd += string.Format(@" AND COMP BETWEEN '{0}' AND '{1}' ", comp_b, comp_e);

                //增加判斷：只列印目前在職人員 - Added By Daniel Chih - 2021/02/01
                if (only_current)
                {
                    sqlCmd += " AND TTSCODE IN ('1','4','6') ";
                    sqlCmd += " AND GETDATE() BETWEEN ADATE AND DDATE";
                }

                sqlCmd += " GROUP BY NOBR)";
                sqlCmd += string.Format(@" {0} ", data_report);

                sqlCmd += " ORDER BY E.D_NO_DISP,B.NOBR";

                DataTable rq_zz1bs1 = SqlConn.GetDataTable(sqlCmd);

                if (rq_zz1bs1.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                string nobr = "";
                decimal rate = 0;
                string nobr_list = "";

                foreach (DataRow Row in rq_zz1bs1.Rows)
                {
                    //是否檢查加總為 100%
                    if (check_sum)
                    {
                        //判斷該員是否與前一筆員工資料的員編相同
                        if (nobr.ToString() == Row["nobr"].ToString())
                        {
                            rate = rate + decimal.Parse(Row["rate"].ToString());
                        }
                        else
                        {
                            if(rate != 1)
                            {
                                nobr_list += ",'" + nobr + "'";
                            }
                            rate = decimal.Parse(Row["rate"].ToString());
                        }
                        nobr = Row["nobr"].ToString();
                        ds.Tables["rq_zz1bs1"].ImportRow(Row);
                    }
                    else
                    {
                        ds.Tables["rq_zz1bs1"].ImportRow(Row);
                    }

                }
                rq_zz1bs1 = null;
                if (nobr_list.Length > 0)
                {
                    nobr_list = nobr_list.Remove(0, 1);
                }

                string strdets = "select d_no,d_no_disp,d_name from depts";
                DataTable rq_depts = SqlConn.GetDataTable(strdets);
                rq_depts.PrimaryKey = new DataColumn[] { rq_depts.Columns["d_no"] };
                foreach (DataRow Row in ds.Tables["rq_zz1bs1"].Rows)
                {
                    if (check_sum)
                    {
                        if (!nobr_list.Contains(Row["nobr"].ToString().Trim())) 
                        {
                            Row.Delete();
                        }
                        else
                        {
                            DataRow row = rq_depts.Rows.Find(Row["depts"].ToString());
                            if (row != null)
                            {
                                Row["depts"] = row["d_no_disp"].ToString();
                                Row["ds_name"] = row["d_name"].ToString();
                            }
                            else
                                Row["ds_name"] = "";
                        }
                    }
                    else
                    {
                        DataRow row = rq_depts.Rows.Find(Row["depts"].ToString());
                        if (row != null)
                        {
                            Row["depts"] = row["d_no_disp"].ToString();
                            Row["ds_name"] = row["d_name"].ToString();
                        }
                        else
                            Row["ds_name"] = "";
                    }
                }
                ds.Tables["rq_zz1bs1"].AcceptChanges();

                if (exportexcel)
                {                    
                    Export(ds.Tables["rq_zz1bs1"]);
                    this.Close();
                }
                else
                {                   
                    RptViewer.Visible = true;
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "EmpReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "EmpReport", "*.rdlc");
                    
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz1B.rdlc";
                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("empdata_rq_zz1bs1", ds.Tables["rq_zz1bs1"]));
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
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            ExporDt.Columns.Add("職稱", typeof(string));
            ExporDt.Columns.Add("成本代碼", typeof(string));
            ExporDt.Columns.Add("成本名稱", typeof(string));
            ExporDt.Columns.Add("分攤比率", typeof(decimal));
            foreach (DataRow Row in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row["dept"].ToString();
                aRow["部門名稱"] = Row["d_name"].ToString();
                aRow["員工編號"] = Row["nobr"].ToString();
                aRow["員工姓名"] = Row["name_c"].ToString();
                aRow["英文姓名"] = Row["name_e"].ToString();
                aRow["職稱"] = Row["job_name"].ToString();
                aRow["成本代碼"] = Row["depts"].ToString();
                aRow["成本名稱"] = Row["ds_name"].ToString();
                aRow["分攤比率"] = decimal.Parse(Row["rate"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
