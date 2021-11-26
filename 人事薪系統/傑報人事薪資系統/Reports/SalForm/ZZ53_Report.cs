/* ======================================================================================================
 * 功能名稱：所得人年度資料表
 * 功能代號：ZZ53
 * 功能路徑：報表列印 > 媒體申報 > 所得人年度資料表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ53_Report.cs
 * 功能用途：
 *  用於產出所得人年度資料表
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/06/23    Daniel Chih    Ver 1.0.00     1. Create
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/06/23
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
    public partial class ZZ53_Report : JBControls.JBForm
    {
        SalDataSet ds = new SalDataSet();
        string nobr_b, nobr_e, dept_b, dept_e, year, ser_nob, ser_noe, type_data, ordertype, reporttype, username, comp_name, CompId;
        bool exportexcel;
        public ZZ53_Report(string nobrb, string nobre, string deptb, string depte, string _year, string sernob, string sernoe, string typedata, string _ordertype, string _username, string compname, string _CompId)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; year = _year; ser_nob = sernob;
            ser_noe = sernoe; type_data = typedata; ordertype = _ordertype;
             username = _username; comp_name = compname; CompId = _CompId;
        }

        private void ZZ53_Report_Load(object sender, EventArgs e)
        {
            try
            {
                string date_b = year + "/12/31";
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select e.d_no_disp as dept,e.d_name,e.d_ename,c.* ";
                sqlCmd += " from base a inner join basetts b on a.nobr=b.nobr ";
                sqlCmd += " inner join tyrtax c on c.nobr=b.nobr ";
                sqlCmd += " left outer join dept e on b.dept=e.d_no ";
                sqlCmd += " where 1 = 1 ";
                sqlCmd += string.Format(@" and c.year='{0}'", year);
                //sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_b);
                sqlCmd += string.Format(@" and c.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and c.series between '{0}' and '{1}'", ser_nob, ser_noe);
                //sqlCmd += string.Format(@" and e.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                //sqlCmd += type_data;
                sqlCmd += ordertype;
                DataTable rq_yrtax = SqlConn.GetDataTable(sqlCmd);
                if (rq_yrtax.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                foreach (DataRow Row in rq_yrtax.Rows)
                {
                    Row["nobr"] = Row["nobr"].ToString().Trim();

                    Row["tot_amt"] = Math.Round(JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["tot_amt"].ToString())), MidpointRounding.AwayFromZero);
                    Row["rel_amt"] = Math.Round(JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["rel_amt"].ToString())), MidpointRounding.AwayFromZero);
                    Row["tax_amt"] = Math.Round(JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["tax_amt"].ToString())), MidpointRounding.AwayFromZero);

                    ds.Tables["zz53"].ImportRow(Row);
                }
                rq_yrtax = null;

                RptViewer.Reset();

                string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "SalReport", "*.rdlc");

                RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz53.rdlc";
                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Year", year) });
                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("UserName", username) });

                RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz53", ds.Tables["zz53"]));
                RptViewer.SetDisplayMode(DisplayMode.PrintLayout);
                RptViewer.ZoomMode = ZoomMode.FullPage;
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
            ExporDt.Columns.Add("流水編號", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("身分證號", typeof(string));
            ExporDt.Columns.Add("格式", typeof(string));
            ExporDt.Columns.Add("給付總額", typeof(int));
            ExporDt.Columns.Add("扣繳稅額", typeof(int));
            ExporDt.Columns.Add("實付總額", typeof(int));
            ExporDt.Columns.Add("退休金", typeof(int));
            ExporDt.Columns.Add("戶籍地址", typeof(string));
            ExporDt.Columns.Add("所得代號", typeof(string));
            ExporDt.Columns.Add("機關", typeof(string));
            ExporDt.Columns.Add("媒體", typeof(string));
            ExporDt.Columns.Add("統編", typeof(string));
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row01["dept"].ToString();
                aRow["部門名稱"] = Row01["d_name"].ToString();
                aRow["英文部門名稱"] = Row01["d_ename"].ToString();
                aRow["流水編號"] = Row01["series"].ToString();
                aRow["員工編號"] = Row01["nobr"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();
                aRow["身分證號"] = Row01["id"].ToString();
                aRow["格式"] = Row01["format"].ToString();
                aRow["給付總額"] = int.Parse(Row01["tot_amt"].ToString());
                aRow["扣繳稅額"] = int.Parse(Row01["tax_amt"].ToString());
                aRow["實付總額"] = int.Parse(Row01["rel_amt"].ToString());
                aRow["退休金"] = int.Parse(Row01["ret_amt"].ToString());
                aRow["戶籍地址"] = Row01["addr_2"].ToString();
                aRow["所得代號"] = Row01["acc_no"].ToString();
                aRow["機關"] = Row01["f0103"].ToString();
                aRow["媒體"] = Row01["f0407"].ToString();
                aRow["統編"] = Row01["id1"].ToString() + " " + Row01["mark"].ToString() + " " + Row01["idcode"].ToString() + " " + Row01["err_mark"].ToString();
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
