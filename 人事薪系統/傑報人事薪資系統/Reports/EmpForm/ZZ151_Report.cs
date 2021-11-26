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
    public partial class ZZ151_Report : JBControls.JBForm
    {
        empdata ds = new empdata();
        string date_b, date_e, dept_b, dept_e, emp_b, emp_e, comp_b, comp_e, out_code, type_data, username, comp_name;
        decimal outday;
        bool exportexcel;

        public ZZ151_Report(string dateb, string datee, string deptb, string depte, string empb, string empe, string compb, string compe, string _outcode, decimal _outday, bool _exportexcel, string typedata, string _username, string compname)
        {
            InitializeComponent();
            date_b = dateb; date_e = datee; dept_b = deptb; dept_e = depte; emp_b = empb;
            emp_e = empe; comp_b = compb; comp_e = compe; username = _username;
            outday = _outday; exportexcel = _exportexcel; type_data = typedata; out_code = _outcode;
            comp_name = compname;
        }

        private void ZZ151_Report_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable rq_zz151s1 = new DataTable();
                rq_zz151s1 = ds.Tables["rq_zz151s1"].Clone();
                rq_zz151s1.TableName = "rq_zz151s1";
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string rdateb = date_b;
                string rdatee = date_e;
                decimal str_i = Convert.ToDecimal(Convert.ToDateTime(date_b).Year.ToString() + Convert.ToDateTime(date_b).Month.ToString().PadLeft(2, '0'));
                decimal str_j = Convert.ToDecimal(Convert.ToDateTime(date_e).Year.ToString() + Convert.ToDateTime(date_e).Month.ToString().PadLeft(2, '0'));
                int str2 = 0;
                for (decimal t = str_i; t <= str_j; t++)
                {

                    int _monb = Convert.ToInt32(Convert.ToString(t).Substring(4, Convert.ToString(t).Length - 4));
                    int _yearb = Convert.ToInt32(Convert.ToString(t).Substring(0, 4));                   
                    if (_monb > 12)
                    {
                        t = Convert.ToInt32(Convert.ToString(_yearb + 1) + "01");
                    }
               
                    str2 += 1;
                }
                date_e = Convert.ToString(DateTime.Parse(date_b).Year) + "/" + Convert.ToString(DateTime.Parse(date_b).Month) + "/" + Convert.ToString(DateTime.DaysInMonth(DateTime.Parse(date_b).Year, DateTime.Parse(date_b).Month));
                //decimal str2 = str_j - str_i + 1;
                
                string sqlCmd = "select top " + str2 + " space(10) as yymm,0000000 as in_cnt,0000000 as new_cnt," +
                    "0000000 as new_cnt1,0000000 as new_cnt2,0000000 as new_cnt3,0000000 as new_cnt4,0000000 as in_cnt1" +
                    " from base";
                rq_zz151s1 = SqlConn.GetDataTable(sqlCmd);
                foreach (DataRow Row in rq_zz151s1.Rows)
                {
                    ds.Tables["rq_zz151s1"].ImportRow(Row);
                }
                rq_zz151s1 = null;
                decimal i;
                int s = 0;
                for (i = str_i; i <= str_j; i++)
                {
                    int _monb = Convert.ToInt32(Convert.ToString(i).Substring(4, Convert.ToString(i).Length - 4));
                    int _yearb = Convert.ToInt32(Convert.ToString(i).Substring(0, 4));
                    if (_monb > 12)
                    {
                        i = Convert.ToInt32(Convert.ToString(_yearb + 1) + "01");
                    }
                    //期初人數  DATEADD(DAY,-1,'" + date_b + "')
                    string sqlCmd1 = "SELECT COUNT(A.NOBR) AS IN_CNT FROM BASETTS A,BASE B" +
                        " WHERE DATEADD(DAY,-1,'" + date_b + "')  BETWEEN A.ADATE AND A.DDATE" +
                        " AND A.EMPCD BETWEEN '" + emp_b + "' AND '" + emp_e + "'" +
                        " AND A.NOBR = B.NOBR" +
                        " AND NOT EXISTS (SELECT T.NOBR FROM BASETTS T WHERE A.NOBR=T.NOBR  AND T.OUDT=DATEADD(DAY,-1,'" + date_b + "') )" +
                        " " + type_data + "" +
                        " AND A.TTSCODE IN('1','6','4')";
                    DataTable rq_zz151s2 = SqlConn.GetDataTable(sqlCmd1);

                    //新進
                    string sqlCmd2 = "SELECT COUNT(A.NOBR) AS NEW_CNT FROM BASETTS A,BASE B" +
                        " WHERE  A.INDT BETWEEN '" + date_b + "' AND '" + date_e + "'" +
                        " AND A.NOBR = B.NOBR" +
                        " AND A.EMPCD BETWEEN '" + emp_b + "' AND '" + emp_e + "'" +
                        " " + type_data + "" +
                        " AND '" + date_e + "' BETWEEN A.ADATE AND A.DDATE";
                    DataTable rq_zz151s3 = SqlConn.GetDataTable(sqlCmd2);

                    //離職
                    //string sqlCmd3 = "SELECT COUNT(A.NOBR) AS NEW_CNT FROM BASETTS A,BASE B" +
                    //    " WHERE A.NOBR+CONVERT(CHAR,A.ADATE,112) IN (SELECT NOBR+CONVERT(CHAR,MAX(ADATE),112) FROM BASETTS" +
                    //    " WHERE ADATE<='" + date_e + "' GROUP BY NOBR)" +
                    //    " AND A.TTSCODE IN('2')" +
                    //    " AND A.EMPCD BETWEEN '" + emp_b + "' AND '" + emp_e + "'" +
                    //    " AND A.NOBR = B.NOBR " +
                    //    " " + type_data + "" +
                    //    " AND A.ADATE BETWEEN '" + date_b + "' AND '" + date_e + "'";
                    string sqlCmd3 = "SELECT COUNT(A.NOBR) AS NEW_CNT FROM BASETTS A,BASE B" +
                       " WHERE A.OUDT BETWEEN '" + date_b + "' AND '" + date_e + "'" +
                       " AND A.TTSCODE ='2'" +
                       " AND A.EMPCD BETWEEN '" + emp_b + "' AND '" + emp_e + "'" +
                       " AND A.NOBR = B.NOBR " +
                       " AND DATEDIFF(DAY,A.INDT,A.OUDT) >= " + outday +
                    " " + type_data + "";                      
                    DataTable rq_zz151s4 = SqlConn.GetDataTable(sqlCmd3);


                    //復職
                    string sqlCmd4 = "SELECT COUNT(A.NOBR) AS NEW_CNT FROM BASETTS A,BASE B" +
                        " WHERE  A.STINDT BETWEEN '" + date_b + "' AND '" + date_e + "'" +
                        " AND A.NOBR = B.NOBR" +
                        " AND A.EMPCD BETWEEN '" + emp_b + "' AND '" + emp_e + "'" +
                        " " + type_data + "" +
                        " AND '" + date_e + "' BETWEEN A.ADATE AND A.DDATE";
                    DataTable rq_zz151s5 = SqlConn.GetDataTable(sqlCmd4);

                    //留職停薪
                    string sqlCmd5 = "SELECT COUNT(A.NOBR) AS NEW_CNT FROM BASETTS A,BASE B" +                       
                        " WHERE A.TTSCODE IN('3')" +
                        " AND A.EMPCD BETWEEN '" + emp_b + "' AND '" + emp_e + "'" +
                        " AND A.NOBR = B.NOBR " +
                        " " + type_data + "" +
                        " AND A.STDT BETWEEN '" + date_b + "' AND '" + date_e + "'";
                    DataTable rq_zz151s6 = SqlConn.GetDataTable(sqlCmd5);

                    //停薪離職
                    string sqlCmd6 = "SELECT COUNT(A.NOBR) AS NEW_CNT FROM BASETTS A,BASE B" +                       
                        " WHERE A.TTSCODE IN('5')" +
                        " AND A.EMPCD BETWEEN '" + emp_b + "' AND '" + emp_e + "'" +
                        " AND A.NOBR = B.NOBR " +
                        " " + type_data + "" +
                        " AND A.STOUDT BETWEEN '" + date_b + "' AND '" + date_e + "'";
                    DataTable rq_zz151s7 = SqlConn.GetDataTable(sqlCmd6);

                    //期末人數
                    string sqlCmd7 = "SELECT COUNT(A.NOBR) AS IN_CNT FROM BASETTS A,BASE B" +
                        " WHERE '" + date_e + "' BETWEEN A.ADATE AND A.DDATE" +
                        " AND A.NOBR = B.NOBR " +
                        " AND A.EMPCD BETWEEN '" + emp_b + "' AND '" + emp_e + "'" +
                        " AND NOT EXISTS (SELECT T.NOBR FROM BASETTS T WHERE A.NOBR=T.NOBR  AND T.OUDT='" + date_e + "' )" +
                        " " + type_data + "" +
                        " AND A.TTSCODE IN('1','6','4')";
                    DataTable rq_zz151s8 = SqlConn.GetDataTable(sqlCmd7);
                    //	
                    this.ds.Tables["rq_zz151s1"].Rows[s]["yymm"] = (Convert.ToDecimal(Convert.ToDateTime(date_b).Year.ToString()) - 1911) + "/" + Convert.ToDateTime(date_b).Month.ToString();
                    this.ds.Tables["rq_zz151s1"].Rows[s]["in_cnt"] = decimal.Parse(rq_zz151s2.Rows[0]["in_cnt"].ToString());
                    this.ds.Tables["rq_zz151s1"].Rows[s]["new_cnt"] = decimal.Parse(rq_zz151s3.Rows[0]["new_cnt"].ToString());
                    this.ds.Tables["rq_zz151s1"].Rows[s]["new_cnt1"] = decimal.Parse(rq_zz151s4.Rows[0]["new_cnt"].ToString());//離職
                    this.ds.Tables["rq_zz151s1"].Rows[s]["new_cnt2"] = decimal.Parse(rq_zz151s5.Rows[0]["new_cnt"].ToString());//復職
                    this.ds.Tables["rq_zz151s1"].Rows[s]["new_cnt3"] = decimal.Parse(rq_zz151s6.Rows[0]["new_cnt"].ToString());//留職停薪
                    this.ds.Tables["rq_zz151s1"].Rows[s]["new_cnt4"] = decimal.Parse(rq_zz151s7.Rows[0]["new_cnt"].ToString());//停薪離職
                    this.ds.Tables["rq_zz151s1"].Rows[s]["in_cnt1"] = decimal.Parse(rq_zz151s8.Rows[0]["in_cnt"].ToString());//期末人數
                    s = s + 1;
                    rq_zz151s2 = null;
                    rq_zz151s3 = null;
                    rq_zz151s4 = null;
                    rq_zz151s5 = null;
                    rq_zz151s6 = null;
                    rq_zz151s7 = null;
                    rq_zz151s8 = null;
                    date_b = Convert.ToDateTime(date_e).AddDays(1).ToShortDateString();                   
                    date_e = Convert.ToDateTime(date_b).AddMonths(1).AddDays(-1).ToShortDateString();
                }
                if (exportexcel)
                {
                    RptViewer.Visible = false;
                    Export(ds.Tables["rq_zz151s1"]);
                    this.Close();
                }
                else
                {                   
                    RptViewer.Visible = true;
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "EmpReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "EmpReport", "*.rdlc");
                    
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz151.rdlc";
                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", rdateb) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", rdatee) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("empdata_rq_zz151s1", ds.Tables["rq_zz151s1"]));
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
            ExporDt.Columns.Add("月份", typeof(string));
            ExporDt.Columns.Add("期初人數", typeof(int));
            ExporDt.Columns.Add("新進", typeof(int));
            ExporDt.Columns.Add("復職", typeof(int));
            ExporDt.Columns.Add("離職", typeof(int));
            ExporDt.Columns.Add("留職", typeof(int));
            ExporDt.Columns.Add("期末人數", typeof(int));
            ExporDt.Columns.Add("離職率", typeof(decimal));
            ExporDt.Columns.Add("留離", typeof(int));
            foreach (DataRow Row in DT.Rows)
            {
                decimal _str1 = decimal.Parse(Row["new_cnt1"].ToString()) + decimal.Parse(Row["new_cnt3"].ToString());
                decimal _str2 = (decimal.Parse(Row["in_cnt"].ToString()) + decimal.Parse(Row["in_cnt1"].ToString())) / 2;
                DataRow aRow = ExporDt.NewRow();
                aRow["月份"] = Row["yymm"].ToString();
                aRow["期初人數"] = int.Parse(Row["in_cnt"].ToString());
                aRow["新進"] = int.Parse(Row["new_cnt"].ToString());
                aRow["復職"] = int.Parse(Row["new_cnt2"].ToString());
                aRow["離職"] = int.Parse(Row["new_cnt1"].ToString());
                aRow["留職"] = int.Parse(Row["new_cnt3"].ToString());
                aRow["期末人數"] = int.Parse(Row["in_cnt1"].ToString());
                aRow["離職率"] = (decimal.Round((_str1 / _str2) * 100, 2) > 100) ? 100 : decimal.Round((_str1 / _str2) * 100, 2);
                aRow["留離"] = int.Parse(Row["new_cnt4"].ToString());

                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
