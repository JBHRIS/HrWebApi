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
    public partial class ZZ23A_Report : JBControls.JBForm
    {
        attenddata ds = new attenddata();
        string check_rote, type_data, lcstr, str1;
        string nobr_b, nobr_e, dept_b, dept_e, comp_b, comp_e, h_codeb, h_codee, username, comp_name;
        string yymm_b, yymm_e, date_b, date_e, reporttype, saladr_b, saladr_e;
        bool exportexcel;
        public ZZ23A_Report(string nobrb, string nobre, string deptb, string depte, string compb, string compe, string hcodeb, string hcodee, string saladrb, string saladre, string yymmb, string yymme, string dateb, string datee, string checkrote, string typedata, string _lcstr, string _reporttype, bool _exportexcel, string _username, string compname)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; comp_b = compb; comp_e = compe;
            h_codeb = hcodeb; h_codee = hcodee; yymm_b = yymmb; yymm_e = yymme; date_b = dateb;
            date_e = datee; reporttype = _reporttype; exportexcel = _exportexcel; check_rote = checkrote;
            type_data = typedata; lcstr = _lcstr; username = _username; saladr_b = saladrb; saladr_e = saladre;
            comp_name = compname;
        }

        private void ZZ23A_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select b.nobr,a.name_c,a.name_e,c.d_no_disp as dept,c.d_name,c.d_ename";
                sqlCmd += "  from base a,basetts b,dept c where a.nobr=b.nobr and b.dept=c.d_no";
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd += string.Format(@" and b.comp between '{0}' and '{1}'", comp_b, comp_e);
                sqlCmd += string.Format(@" and b.saladr between '{0}' and '{1}'", saladr_b, saladr_e);
                sqlCmd += type_data;
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                string sqlAbs = "select a.nobr,a.bdate,a.yymm,a.btime,a.etime,b.h_code_disp as h_code,b.h_name,b.not_sum,";
                sqlAbs += "b.unit,a.tol_hours,datename(dw,a.bdate) as dw";
                sqlAbs += "  from absc a ,hcode b where a.h_code=b.h_code";
                sqlAbs += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlAbs += string.Format(@" and b.h_code_disp between '{0}' and '{1}'", h_codeb, h_codee);                
                sqlAbs += lcstr;
                sqlAbs += " order by a.nobr,a.bdate";
                DataTable rq_abs = SqlConn.GetDataTable(sqlAbs);
                foreach (DataRow Row in rq_abs.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        DataRow aRow = ds.Tables["zz23a"].NewRow();
                        aRow["dept"] = row["dept"].ToString();
                        aRow["d_name"] = row["d_name"].ToString();
                        aRow["d_ename"] = row["d_ename"].ToString();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["name_c"] = row["name_c"].ToString();
                        aRow["name_e"] = row["name_e"].ToString();
                        aRow["yymm"] = Row["yymm"].ToString();
                        aRow["bdate"] = DateTime.Parse(Row["bdate"].ToString());
                        aRow["dw"] = Row["dw"].ToString();
                        aRow["h_code"] = Row["h_code"].ToString();
                        aRow["h_name"] = Row["h_name"].ToString();
                        aRow["btime"] = Row["btime"].ToString();
                        aRow["etime"] = Row["etime"].ToString();
                        aRow["tol_hours"] = decimal.Parse(Row["tol_hours"].ToString());
                        ds.Tables["zz23a"].Rows.Add(aRow);
                    }
                }

                if (ds.Tables["zz23a"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                if (exportexcel)
                {
                    Export(ds.Tables["zz23a"]);
                    this.Close();
                }
                else
                {                   
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "AttReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "AttReport", "*.rdlc");
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz23a.rdlc";
                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_zz23a", ds.Tables["zz23a"]));
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
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            ExporDt.Columns.Add("假別", typeof(string));
            ExporDt.Columns.Add("日期", typeof(DateTime));
            ExporDt.Columns.Add("星期", typeof(string));
            ExporDt.Columns.Add("時間起", typeof(string));
            ExporDt.Columns.Add("時間迄", typeof(string));
            ExporDt.Columns.Add("請假時數", typeof(decimal)); 
            DataRow[] DTrow = DT.Select("", "dept,nobr,bdate,h_code asc");
            foreach (DataRow Row in DTrow)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row["dept"].ToString();
                aRow["部門名稱"] = Row["d_name"].ToString();
                aRow["英文部門名稱"] = Row["d_ename"].ToString();
                aRow["員工編號"] = Row["nobr"].ToString();
                aRow["員工姓名"] = Row["name_c"].ToString();
                aRow["英文姓名"] = Row["name_e"].ToString();
                aRow["假別"] = Row["h_name"].ToString();
                aRow["日期"] = DateTime.Parse(Row["bdate"].ToString());
                aRow["星期"] = Row["dw"].ToString();
                aRow["時間起"] = Row["btime"].ToString();
                aRow["時間迄"] = Row["etime"].ToString();
                aRow["請假時數"] = decimal.Parse(Row["tol_hours"].ToString());               
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }

       
    }
}
