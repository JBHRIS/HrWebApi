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
    public partial class ZZ2GA_Report : JBControls.JBForm
    {
        attenddata ds = new attenddata();
        string nobr_b, nobr_e, dept_b, dept_e, comp_b, comp_e, date_b, date_e, yymm_b, yymm_e, type_data, date_type, data_report, comp_name, compid;
        bool exportexcel;
        public ZZ2GA_Report(string nobrb, string nobre, string deptb, string depte, string compb, string compe, string dateb, string datee, string yymmb, string yymme, string typedata, string datetype, bool _exportexcel, string datareport, string compname)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; comp_b = compb;
            comp_e = compe; date_b = dateb; date_e = datee; yymm_b = yymmb; date_type = datetype;
            yymm_e = yymme; type_data = typedata; exportexcel = _exportexcel;
            data_report = datareport; comp_name = compname; 
        }

        private void ZZ2GA_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select b.nobr,a.name_c,d_no_disp as dept,c.d_name,d.job_disp as job,d.job_name";               
                sqlCmd += " from base a,basetts b";
                sqlCmd += " left outer join dept c on b.dept=c.d_no";
                sqlCmd += " left outer join job d on b.job=d.job";
                sqlCmd += " where a.nobr=b.nobr ";
                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and b.comp between '{0}' and '{1}'", comp_b, comp_e);
                sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                //sqlCmd += string.Format(@" and b.empcd between '{0}' and '{1}' ", emp_b, emp_e);
                sqlCmd += data_report;
                sqlCmd += type_data;
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };
                string sqlCmd1 = "select a.nobr,a.bdate,a.tot_hours,rote_disp as rote,a.yymm,datepart(mm,a.bdate) as mm from ot a";
                sqlCmd1 += " left outer join attend b on a.nobr=b.nobr ";
                sqlCmd1 += " left outer join rote c on b.rote=c.rote";
                sqlCmd1 += " where a.bdate=b.adate";
                sqlCmd1 += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                if (date_type == "1")
                    sqlCmd1 += string.Format(@" and a.yymm between '{0}' and '{1}'", yymm_b, yymm_e);
                if (date_type == "2")
                    sqlCmd1 += string.Format(@" and a.bdate between '{0}' and '{1}'", date_b, date_e);
                sqlCmd1 += " order by a.nobr,a.bdate";
                DataTable rq_ot = SqlConn.GetDataTable(sqlCmd1);
                rq_ot.Columns.Add("dept", typeof(string));
                rq_ot.Columns.Add("d_name", typeof(string));
                rq_ot.Columns.Add("job", typeof(string));
                rq_ot.Columns.Add("job_name", typeof(string));  
                rq_ot.Columns.Add("name_c", typeof(string));
                foreach (DataRow Row in rq_ot.Rows)
                { 
                    DataRow row= rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row!=null)
                    {
                        Row["dept"] = row["dept"].ToString();
                        Row["d_name"] = row["d_name"].ToString();
                        Row["job"] = row["job"].ToString();
                        Row["job_name"] = row["job_name"].ToString();
                        Row["name_c"] = row["name_c"].ToString();
                    }
                    else
                        Row.Delete();
                }
                rq_ot.AcceptChanges();

                if (rq_ot.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                ds.Tables["zz2ga"].PrimaryKey = new DataColumn[] { ds.Tables["zz2ga"].Columns["nobr"] };
                DataRow[] SRow = rq_ot.Select("", "dept,nobr asc");
                foreach (DataRow Row in SRow)
                {
                    Row["mm"] = Convert.ToInt32(Row["mm"].ToString()).ToString();
                    decimal wkhrs = 0; decimal holihrs = 0;
                    if (Row["rote"].ToString().Trim() == "00")
                        holihrs = decimal.Parse(Row["tot_hours"].ToString());
                    else
                        wkhrs = decimal.Parse(Row["tot_hours"].ToString());
                    DataRow row = ds.Tables["zz2ga"].Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        row["wk" + Row["mm"].ToString().Trim()] = decimal.Parse(row["wk" + Row["mm"].ToString().Trim()].ToString()) + wkhrs;
                        row["holi" + Row["mm"].ToString().Trim()] = decimal.Parse(row["holi" + Row["mm"].ToString().Trim()].ToString()) + holihrs;
                        row["wktot"] = decimal.Parse(row["wktot"].ToString()) + wkhrs;
                        row["holitot"] = decimal.Parse(row["holitot"].ToString()) + holihrs;
                    }
                    else
                    {
                        DataRow aRow = ds.Tables["zz2ga"].NewRow();
                        aRow["dept"] = Row["dept"].ToString();
                        aRow["d_name"] = Row["d_name"].ToString();
                        aRow["job"] = Row["job"].ToString();
                        aRow["job_name"] = Row["job_name"].ToString();
                        aRow["name_c"] = Row["name_c"].ToString();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["name_c"] = Row["name_c"].ToString();
                        for (int i = 1; i < 13; i++)
                        {
                            aRow["wk" + i] = 0;
                            aRow["holi" + i] = 0;
                        }
                        aRow["wk" + Row["mm"].ToString().Trim()] = wkhrs;
                        aRow["holi" + Row["mm"].ToString().Trim()] = holihrs;
                        aRow["wktot"] = wkhrs;
                        aRow["holitot"] = holihrs;
                        ds.Tables["zz2ga"].Rows.Add(aRow);
                    }
                }
                rq_base = null; rq_ot = null;
                if (exportexcel)
                {
                    Export(ds.Tables["zz2ga"]);
                    this.Close();
                }
                else
                {
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "AttReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "AttReport", "*.rdlc");

                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz2ga.rdlc";

                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    if (date_type == "1")
                    {
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", yymm_b) });
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", yymm_e) });
                    }
                    else
                    {
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                    }
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_zz2ga", ds.Tables["zz2ga"]));
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
            ExporDt.Columns.Add("職稱代碼", typeof(string));
            ExporDt.Columns.Add("職稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));           
            ExporDt.Columns.Add("一月平日", typeof(decimal));
            ExporDt.Columns.Add("一月假日", typeof(decimal));
            ExporDt.Columns.Add("二月平日", typeof(decimal));
            ExporDt.Columns.Add("二月假日", typeof(decimal));
            ExporDt.Columns.Add("三月平日", typeof(decimal));
            ExporDt.Columns.Add("三月假日", typeof(decimal));
            ExporDt.Columns.Add("四月平日", typeof(decimal));
            ExporDt.Columns.Add("四月假日", typeof(decimal));
            ExporDt.Columns.Add("五月平日", typeof(decimal));
            ExporDt.Columns.Add("五月假日", typeof(decimal));
            ExporDt.Columns.Add("六月平日", typeof(decimal));
            ExporDt.Columns.Add("六月假日", typeof(decimal));
            ExporDt.Columns.Add("七月平日", typeof(decimal));
            ExporDt.Columns.Add("七月假日", typeof(decimal));
            ExporDt.Columns.Add("八月平日", typeof(decimal));
            ExporDt.Columns.Add("八月假日", typeof(decimal));
            ExporDt.Columns.Add("九月平日", typeof(decimal));
            ExporDt.Columns.Add("九月假日", typeof(decimal));
            ExporDt.Columns.Add("十月平日", typeof(decimal));
            ExporDt.Columns.Add("十月假日", typeof(decimal));
            ExporDt.Columns.Add("十一月平日", typeof(decimal));
            ExporDt.Columns.Add("十一月假日", typeof(decimal));
            ExporDt.Columns.Add("十二月平日", typeof(decimal));
            ExporDt.Columns.Add("十二月假日", typeof(decimal));
            ExporDt.Columns.Add("合計平日", typeof(decimal));
            ExporDt.Columns.Add("合計假日", typeof(decimal));
            foreach (DataRow Row in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row["dept"].ToString();
                aRow["部門名稱"] = Row["d_name"].ToString();
                aRow["職稱代碼"] = Row["job"].ToString();
                aRow["職稱"] = Row["job_name"].ToString();
                aRow["員工編號"] = Row["nobr"].ToString();
                aRow["員工姓名"] = Row["name_c"].ToString();
                aRow["一月平日"] = decimal.Parse(Row["wk1"].ToString());
                aRow["一月假日"] = decimal.Parse(Row["holi1"].ToString());
                aRow["二月平日"] = decimal.Parse(Row["wk2"].ToString());
                aRow["二月假日"] = decimal.Parse(Row["holi2"].ToString());
                aRow["三月平日"] = decimal.Parse(Row["wk3"].ToString());
                aRow["三月假日"] = decimal.Parse(Row["holi3"].ToString());
                aRow["四月平日"] = decimal.Parse(Row["wk4"].ToString());
                aRow["四月假日"] = decimal.Parse(Row["holi4"].ToString());
                aRow["五月平日"] = decimal.Parse(Row["wk5"].ToString());
                aRow["五月假日"] = decimal.Parse(Row["holi5"].ToString());
                aRow["六月平日"] = decimal.Parse(Row["wk6"].ToString());
                aRow["六月假日"] = decimal.Parse(Row["holi6"].ToString());
                aRow["七月平日"] = decimal.Parse(Row["wk7"].ToString());
                aRow["七月假日"] = decimal.Parse(Row["holi7"].ToString());
                aRow["八月平日"] = decimal.Parse(Row["wk8"].ToString());
                aRow["八月假日"] = decimal.Parse(Row["holi8"].ToString());
                aRow["九月平日"] = decimal.Parse(Row["wk9"].ToString());
                aRow["九月假日"] = decimal.Parse(Row["holi9"].ToString());
                aRow["十月平日"] = decimal.Parse(Row["wk10"].ToString());
                aRow["十月假日"] = decimal.Parse(Row["holi10"].ToString());
                aRow["十一月平日"] = decimal.Parse(Row["wk11"].ToString());
                aRow["十一月假日"] = decimal.Parse(Row["holi11"].ToString());
                aRow["十二月平日"] = decimal.Parse(Row["wk12"].ToString());
                aRow["十二月假日"] = decimal.Parse(Row["holi12"].ToString());
                aRow["合計平日"] = decimal.Parse(Row["wktot"].ToString());
                aRow["合計假日"] = decimal.Parse(Row["holitot"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
