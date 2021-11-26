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
    public partial class ZZ4E_Report : JBControls.JBForm
    {
        SalDataSet ds = new SalDataSet();
        string type_data, nobr_b, nobr_e, dept_b, dept_e, work_b, work_e,emp_b,emp_e, date_b, reporttype, workadr, ttstype, comp_name;
        bool exportexcel, mangsuper;
        public ZZ4E_Report(string typedata, string nobrb, string nobre, string deptb, string depte, string workb, string worke, string empb, string empe, string dateb, string _reporttype, string _workadr, string _ttstype, bool _exportexcel, string compname)
        {
            InitializeComponent();            
            type_data = typedata; nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; work_b = workb;
            work_e = worke; date_b = dateb; reporttype = _reporttype; workadr = _workadr; ttstype = _ttstype;
            exportexcel = _exportexcel; comp_name = compname; emp_b = empb; emp_e = empe;
        }

        private void ZZ4E_Report_Load(object sender, EventArgs e)
        {
            try
            {
                string _dateb = DateTime.Parse(Convert.ToString(DateTime.Parse(date_b).Year) + "/" + Convert.ToString(DateTime.Parse(date_b).Month) + "/01").ToString("yyyy/MM/dd");
                string _datee = DateTime.Parse(_dateb).AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd");
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select b.nobr,a.name_c,a.name_e,a.count_ma,b.indt,c.d_no_disp as dept,c.d_name,c.d_ename";
                sqlCmd += ",e.job_disp as job,e.job_name";
                sqlCmd += string.Format(@",Round(datediff(day,a.birdt,'{0}')/365.24,2) as age", date_b);
                sqlCmd += "  from base a,basetts b left outer join dept c on b.dept=c.d_no";               
                sqlCmd += " left outer join job e on b.job=e.job";
                sqlCmd += string.Format(@" where a.nobr=b.nobr and '{0}' between b.adate and b.ddate", date_b);
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);
                sqlCmd +=workadr;
                sqlCmd += string.Format(@" and b.saladr between '{0}' and '{1}'", work_b, work_e);
                if (ttstype == "0") sqlCmd += " and b.ttscode in ('1','4','6')";
                if (ttstype == "2") sqlCmd += string.Format(@" and b.ttscode in ('1','4','6') and b.adate between '{0}' and '{1}'", _dateb, _datee);
                if (ttstype == "3") sqlCmd += string.Format(@" and b.ttscode in ('2','3','5') and b.adate between '{0}' and '{1}'", _dateb, _datee);
                sqlCmd += type_data;
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                string sqlCmd1 = sqlCmd1 = "select a.nobr,a.adate,b.sal_code_disp as sal_code,b.sal_name,a.amt ";
                sqlCmd1 += " from salbasd a,salcode b";
                sqlCmd1 += " where a.sal_code=b.sal_code";
                sqlCmd1 += " and b.sal_attr in ('A','G')";               
                sqlCmd1 += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);                
                sqlCmd1 += " and a.nobr+convert(char(10),a.adate,112)+a.sal_code in ";
                sqlCmd1 += "(select distinct a.nobr+max(convert(char(10),a.adate,112))+a.sal_code from  salbasd a where";
                sqlCmd1 += string.Format(@" a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd1 += string.Format(@" and a.adate <='{0}'", date_b);
                sqlCmd1 += " group by a.nobr,a.sal_code)";
                sqlCmd1 += " order by a.nobr,a.adate,a.sal_code";
                DataTable rq_salbasd = SqlConn.GetDataTable(sqlCmd1);
                if (rq_salbasd.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                DataTable rq_zz4e = new DataTable();
                rq_zz4e.Columns.Add("nobr", typeof(string));
                rq_zz4e.Columns.Add("name_c", typeof(string));
                rq_zz4e.Columns.Add("name_e", typeof(string));
                rq_zz4e.Columns.Add("dept", typeof(string));
                rq_zz4e.Columns.Add("d_name", typeof(string));
                rq_zz4e.Columns.Add("d_ename", typeof(string));
                rq_zz4e.Columns.Add("job", typeof(string));
                rq_zz4e.Columns.Add("job_name", typeof(string));
                rq_zz4e.Columns.Add("amt", typeof(int));
                rq_zz4e.Columns.Add("age", typeof(decimal));
                rq_zz4e.PrimaryKey = new DataColumn[] { rq_zz4e.Columns["nobr"] };
                foreach (DataRow Row in rq_salbasd.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        Row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));
                        DataRow row1 = rq_zz4e.Rows.Find(Row["nobr"].ToString());
                        if (row1 != null)
                            row1["amt"] = int.Parse(row1["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                        else
                        {
                            DataRow aRow = rq_zz4e.NewRow();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["name_c"] = row["name_c"].ToString();
                            aRow["name_e"] = row["name_e"].ToString();
                            aRow["dept"] = row["dept"].ToString();
                            aRow["d_name"] = row["d_name"].ToString();
                            aRow["d_ename"] = row["d_ename"].ToString();
                            aRow["job"] = row["job"].ToString();
                            aRow["job_name"] = row["job_name"].ToString();
                            aRow["amt"] = int.Parse(Row["amt"].ToString());
                            aRow["age"] = decimal.Parse(row["age"].ToString());
                            rq_zz4e.Rows.Add(aRow);
                        }
                    }
                }
                
                DataRow[] Srow = null;
                if (reporttype == "0")
                {
                    ds.Tables["zz4e"].PrimaryKey = new DataColumn[] { ds.Tables["zz4e"].Columns["dept"] };
                    Srow = rq_zz4e.Select("", "dept asc");
                }
                else if (reporttype == "1")
                {
                    ds.Tables["zz4e"].PrimaryKey = new DataColumn[] { ds.Tables["zz4e"].Columns["job"] };
                    Srow = rq_zz4e.Select("", "job asc");
                }
                else if (reporttype == "2")
                {
                    DataColumn [] _key = new DataColumn[2];
                    _key[0] = ds.Tables["zz4e"].Columns["dept"];
                    _key[1] = ds.Tables["zz4e"].Columns["job"];
                    ds.Tables["zz4e"].PrimaryKey = _key;
                    Srow = rq_zz4e.Select("", "dept,job asc");
                }
                
                foreach (DataRow Row in Srow)
                {
                    DataRow row = null;
                    if (reporttype=="0")
                        row = ds.Tables["zz4e"].Rows.Find(Row["dept"].ToString());
                    else if (reporttype == "1")
                        row = ds.Tables["zz4e"].Rows.Find(Row["job"].ToString());
                    else if (reporttype == "2")
                    {
                        object[] _value = new object[2];
                        _value[0] = Row["dept"].ToString();
                        _value[1] = Row["job"].ToString();
                        row = ds.Tables["zz4e"].Rows.Find(_value);
                    }
                    if (row != null)
                    {
                        if (int.Parse(Row["amt"].ToString()) > int.Parse(row["h_amt"].ToString()))
                            row["h_amt"] = int.Parse(Row["amt"].ToString());
                        if (int.Parse(Row["amt"].ToString()) < int.Parse(row["l_amt"].ToString()))
                            row["l_amt"] = int.Parse(Row["amt"].ToString());
                        row["amt"] = int.Parse(row["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                        row["pno"] = int.Parse(row["pno"].ToString()) + 1;
                        row["avg_amt"] = Math.Round(decimal.Parse(row["amt"].ToString()) / decimal.Parse(row["pno"].ToString()), MidpointRounding.AwayFromZero);
                        row["age"] =  Math.Round(decimal.Parse(row["age"].ToString()) + decimal.Parse(Row["age"].ToString()),2);
                        row["avg_age"] = Math.Round(decimal.Parse(row["age"].ToString()) / decimal.Parse(row["pno"].ToString()), 2);
                    }
                    else
                    {
                        DataRow aRow = ds.Tables["zz4e"].NewRow();
                        aRow["dept"] = "";
                        aRow["d_name"] = "";
                        aRow["d_ename"] = "";
                        aRow["job"] = "";
                        aRow["job_name"] = "";
                        if (reporttype == "0" || reporttype == "2")
                        {
                            aRow["dept"] = Row["dept"].ToString();
                            aRow["d_name"] = Row["d_name"].ToString();
                            aRow["d_ename"] = Row["d_ename"].ToString();
                        }
                        if (reporttype == "1" || reporttype == "2")
                        {
                            aRow["job"] = Row["job"].ToString();
                            aRow["job_name"] = Row["job_name"].ToString();
                        }                        
                        aRow["pno"] = 1;
                        aRow["h_amt"] = int.Parse(Row["amt"].ToString());
                        aRow["l_amt"] = int.Parse(Row["amt"].ToString());
                        aRow["avg_amt"] = int.Parse(Row["amt"].ToString());
                        aRow["amt"] = int.Parse(Row["amt"].ToString());
                        aRow["age"] = Math.Round(decimal.Parse(Row["age"].ToString()), 2);
                        aRow["avg_age"] = Math.Round(decimal.Parse(Row["age"].ToString()), 2);
                        ds.Tables["zz4e"].Rows.Add(aRow);
                    }
                }
                rq_base = null; rq_salbasd = null; rq_zz4e = null;
                if (ds.Tables["zz4e"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                if (exportexcel)
                {
                    Export(ds.Tables["zz4e"]);
                    this.Close();
                }
                else
                {
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "SalReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "SalReport", "*.rdlc");
                    if (reporttype=="0")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4e.rdlc";
                    else if (reporttype == "1")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4e1.rdlc";
                    else if (reporttype == "2")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4e2.rdlc";
                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });                   
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4e", ds.Tables["zz4e"]));
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

            if (reporttype == "0" || reporttype == "2")
            {
                ExporDt.Columns.Add("部門代碼", typeof(string));
                ExporDt.Columns.Add("部門名稱", typeof(string));
                ExporDt.Columns.Add("英文部門名稱", typeof(string));
            }
            if (reporttype == "1" || reporttype == "2")
            {
                ExporDt.Columns.Add("職稱代碼", typeof(string));
                ExporDt.Columns.Add("職稱名稱", typeof(string));
            }
            ExporDt.Columns.Add("人數", typeof(int));
            ExporDt.Columns.Add("最高薪資", typeof(int));
            ExporDt.Columns.Add("最低薪資", typeof(int));
            ExporDt.Columns.Add("平均薪資", typeof(int));
            ExporDt.Columns.Add("平均年齡", typeof(decimal));
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                if (reporttype == "0" || reporttype == "2")
                {
                    aRow["部門代碼"] = Row01["dept"].ToString();
                    aRow["部門名稱"] = Row01["d_name"].ToString();
                    aRow["英文部門名稱"] = Row01["d_ename"].ToString();
                }
                if (reporttype == "1" || reporttype == "2")
                {
                    aRow["職稱代碼"] = Row01["job"].ToString();
                    aRow["職稱名稱"] = Row01["job_name"].ToString();
                }
                aRow["人數"] = int.Parse(Row01["pno"].ToString());
                aRow["最高薪資"] = int.Parse(Row01["h_amt"].ToString());
                aRow["最低薪資"] = int.Parse(Row01["l_amt"].ToString());
                aRow["平均薪資"] = int.Parse(Row01["avg_amt"].ToString());
                aRow["平均年齡"] = decimal.Parse(Row01["avg_age"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
