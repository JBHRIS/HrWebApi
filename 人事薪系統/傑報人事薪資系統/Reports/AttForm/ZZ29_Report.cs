/* ======================================================================================================
 * 功能名稱：加班排名表
 * 功能代號：ZZ29
 * 功能路徑：報表列印 > 出勤 > 加班排名表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\AttForm\ZZ29_Report.cs
 * 功能用途：
 *  用於產出加班排名表
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/05/10    Daniel Chih    Ver 1.0.01     1. 移除Excel中的英文部門名稱欄位
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/05/10
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

namespace JBHR.Reports.AttForm
{
    public partial class ZZ29_Report : JBControls.JBForm
    {
        attenddata ds = new attenddata();
        string dept_b, dept_e, comp_b, comp_e, date_b, date_e, report_type, type_data, comp_name;
        bool exportexcel;
        public ZZ29_Report(string deptb, string depte, string compb, string compe, string dateb, string datee, bool _exportexcel, string reporttype, string typedata, string compname)
        {
            InitializeComponent();
            dept_b = deptb; dept_e = depte; comp_b = compb; comp_e = compe;
            date_b = dateb; date_e = datee; type_data = typedata; comp_name = compname;
            exportexcel = _exportexcel; report_type = reporttype;
        }       

        private void ZZ29_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select b.nobr,a.name_c,a.name_e,c.d_no_disp as dept ,c.d_name,c.d_ename from base a,basetts b";
                sqlCmd += " left outer join dept c on b.dept=c.d_no";
                sqlCmd += string.Format(@" where a.nobr=b.nobr and '{0}' between b.adate and b.ddate", date_e);
                sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd += string.Format(@" and b.comp between '{0}' and '{1}'", comp_b, comp_e);
                sqlCmd += type_data;
                sqlCmd += " order by c.d_no_disp,b.nobr";
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);

                if (rq_base.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };
                string sqlCmd2 = "SELECT A.NOBR,SUM(OT_HRS+REST_HRS) AS TOL_HOURS" +
                    " FROM OT A " +
                    " WHERE A.BDATE BETWEEN '" + date_b + "' AND '" + date_e + "'" +                   
                    " GROUP BY A.NOBR";
                DataTable rq_otc = SqlConn.GetDataTable(sqlCmd2);

                if (rq_otc.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                decimal str_tol = 0;
                DataRow[] ORow = rq_otc.Select("", "tol_hours desc");
                foreach (DataRow row in ORow)
                {
                    string str_nobr = row["nobr"].ToString();
                    DataRow row1 = rq_base.Rows.Find(str_nobr);
                    if (row1 != null)
                    {
                        DataRow aRow = ds.Tables["zz29"].NewRow();
                        aRow["nobr"] = str_nobr;
                        aRow["name_c"] = row1["name_c"].ToString();
                        aRow["name_e"] = row1["name_e"].ToString();
                        aRow["dept"] = row1["dept"].ToString();
                        aRow["d_name"] = row1["d_name"].ToString();
                        aRow["d_ename"] = row1["d_ename"].ToString();
                        aRow["tol_hours"] = row["tol_hours"].ToString();
                        ds.Tables["zz29"].Rows.Add(aRow);
                    }
                    str_tol = str_tol + decimal.Parse(row["tol_hours"].ToString());
                }
                rq_base = null;
                rq_otc = null;

                if (exportexcel)
                {                   
                    Export(ds.Tables["zz29"], str_tol);
                    this.Close();
                }
                else
                {                   
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "AttReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "AttReport", "*.rdlc");
                    
                    if (report_type == "1")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz29.rdlc";
                    else
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz291.rdlc";
                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_zz29", ds.Tables["zz29"]));
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

        void Export(DataTable DT, decimal CNT)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));           
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            ExporDt.Columns.Add("加班時數", typeof(decimal));
            ExporDt.Columns.Add("百分比", typeof(decimal));
            if (report_type == "2")
            {
                DataRow[] DTRow = DT.Select("", "dept,nobr asc");
                foreach (DataRow Row in DTRow)
                {
                    DataRow aRow = ExporDt.NewRow();
                    aRow["部門代碼"] = Row["dept"].ToString();
                    aRow["部門名稱"] = Row["d_name"].ToString();                   
                    aRow["員工編號"] = Row["nobr"].ToString();
                    aRow["員工姓名"] = Row["name_c"].ToString();
                    aRow["英文姓名"] = Row["name_e"].ToString();
                    aRow["加班時數"] = decimal.Parse(Row["tol_hours"].ToString());
                    aRow["百分比"] = decimal.Round((decimal.Parse(Row["tol_hours"].ToString()) / CNT) * 100, 2);
                    ExporDt.Rows.Add(aRow);
                }
            }
            else
            {
                foreach (DataRow Row in DT.Rows)
                {
                    DataRow aRow = ExporDt.NewRow();
                    aRow["部門代碼"] = Row["dept"].ToString();
                    aRow["部門名稱"] = Row["d_name"].ToString();
                    //aRow["英文部門名稱"] = Row["d_ename"].ToString();
                    aRow["員工編號"] = Row["nobr"].ToString();
                    aRow["員工姓名"] = Row["name_c"].ToString();
                    aRow["英文姓名"] = Row["name_e"].ToString();
                    aRow["加班時數"] = decimal.Parse(Row["tol_hours"].ToString());
                    aRow["百分比"] = decimal.Round((decimal.Parse(Row["tol_hours"].ToString()) / CNT) * 100, 2);
                    ExporDt.Rows.Add(aRow);
                }
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
