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
    public partial class ZZ2Z2_Report : JBControls.JBForm
    {
        attenddata ds = new attenddata();
        string nobr_b, nobr_e, dept_b, dept_e, depts_b, depts_e, jobl_b, jobl_e, date_b, date_e, yymm_b, yymm_e, comp_name;
        string emp_b, emp_e, comp_b, comp_e, work_b, work_e, data_report, report_type;
        string responsibility_b, responsibility_e;
        bool exportexcel;
        public ZZ2Z2_Report(string nobrb, string nobre, string deptb, string depte, string deptsb, string deptse, string joblb, string joble, string dateb, string datee, string yymmb, string yymme, string empb, string empe, string compb, string compe, string workb, string worke, string responsibilityb, string responsibilitye, string datareport, bool _exportexcel, string compname)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; depts_b = deptsb;
            depts_e = deptse; jobl_b = joblb; jobl_e = joble; date_b = dateb; date_e = datee;
            yymm_b = yymmb; yymm_e = yymme; emp_b = empb; emp_e = empe; comp_b = compb;
            comp_e = compe; work_b = workb; work_e = worke; data_report = datareport;
            exportexcel = _exportexcel; comp_name = compname;
            responsibility_b = responsibilityb; responsibility_e = responsibilitye;
        }

        private void ZZ2Z2_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlBase = "select b.nobr,a.name_c,a.name_e,c.d_no_disp as dept,c.d_name,c.d_ename,b.comp";
                sqlBase += " from base a,basetts b";
                sqlBase += " left outer join dept c on b.dept=c.d_no";
                sqlBase += " left outer join depts d on b.depts=d.d_no";
                sqlBase += " left outer join jobl e on  b.jobl=e.jobl";
                sqlBase += " where a.nobr=b.nobr ";
                sqlBase += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                sqlBase += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlBase += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlBase += string.Format(@" and d.d_no_disp between '{0}' and '{1}'", depts_b, depts_e);
                sqlBase += string.Format(@" and b.comp between '{0}' and '{1}'", comp_b, comp_e);
                sqlBase += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);
                sqlBase += string.Format(@" and e.jobl_disp between '{0}' and '{1}'", jobl_b, jobl_e);
                sqlBase += string.Format(@" and b.workcd between '{0}' and '{1}'", work_b, work_e);
                //sqlBase += string.Format(@" and b.carcd between '{0}' and '{1}'", responsibility_b, responsibility_e);
                sqlBase += data_report;
                DataTable rq_base = SqlConn.GetDataTable(sqlBase);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                string sqlAbs = "select a.nobr,substring (convert(char,bdate,112),1,6) as yymm,b.h_code_disp as h_code,b.h_name";
                sqlAbs += ",sum(a.tol_hours) as tol_hours";
                sqlAbs += " from abs a,hcode b where a.h_code=b.h_code";
                sqlAbs += string.Format(@"  and a.bdate between '{0}' and '{1}'", date_b, date_e);
                sqlAbs += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                //判斷and mang = 0不是系統才會顯示
                //sqlAbs += " and b.mang=0 group by a.nobr,substring (convert(char,bdate,112),1,6),a.h_code,b.h_name";
                sqlAbs += " group by a.nobr,substring (convert(char,bdate,112),1,6),b.h_code_disp,b.h_name";
                sqlAbs += " order by a.nobr,substring (convert(char,bdate,112),1,6),b.h_code_disp";
                DataTable rq_abs = SqlConn.GetDataTable(sqlAbs);
                //rq_abs.PrimaryKey = new DataColumn[] { rq_abs.Columns["nobr"], rq_abs.Columns["yymm"] };
                foreach (DataRow Row in rq_abs.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row == null)
                        Row.Delete();
                }
                rq_abs.AcceptChanges();
                if (rq_abs.Rows.Count == 0)
                {
                    DataRow aRow = rq_abs.NewRow();
                    aRow["nobr"] = "YYYYYYYYY";
                    aRow["h_code"] = "ZZ";
                    aRow["tol_hours"] = 999.99;
                    rq_abs.Rows.Add(aRow);

                    DataRow aRow1 = rq_abs.NewRow();
                    aRow1["nobr"] = "ZZZZZZZZZA";
                    aRow1["h_code"] = "ZZ";
                    aRow1["tol_hours"] = 999.99;
                    rq_abs.Rows.Add(aRow1);
                }

                //忘刷次數
                string sqlCard = "select a.nobr,substring (convert(char,a.adate,112),1,6) as yymm,count(a.nobr) as los_no";
                sqlCard += " from card a,cardlosd b where a.reason=b.code";
                sqlCard += string.Format(@" and a.adate between '{0}' and '{1}'", date_b, date_e);
                sqlCard += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCard += " and b.att=1 group by a.nobr,substring (convert(char,a.adate,112),1,6)";
                DataTable rq_card = SqlConn.GetDataTable(sqlCard);
                rq_card.PrimaryKey = new DataColumn[] { rq_card.Columns["nobr"], rq_card.Columns["yymm"] };

                //遲到次數
                string sqlAttend = "select nobr,substring (convert(char,adate,112),1,6) as yymm,count(nobr) as late_no from attend";
                sqlAttend += string.Format(@" where adate between '{0}' and '{1}'", date_b, date_e);
                sqlAttend += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlAttend += " and late_mins >0 group by nobr,substring (convert(char,adate,112),1,6)";
                sqlAttend += " order by nobr,substring (convert(char,adate,112),1,6)";
                DataTable rq_attend = SqlConn.GetDataTable(sqlAttend);

                DataTable rq_hcode1 = new DataTable();
                rq_hcode1.Columns.Add("h_code", typeof(string));
                rq_hcode1.Columns.Add("h_name", typeof(string));
                rq_hcode1.PrimaryKey = new DataColumn[] { rq_hcode1.Columns["h_code"] };

                foreach (DataRow Row in rq_attend.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        object[] _value = new object[2];
                        _value[0] = Row["nobr"].ToString();
                        _value[1] = Row["yymm"].ToString();
                        DataRow[] row1 = rq_abs.Select(" nobr='" + Row["nobr"].ToString() + "' and yymm='" + Row["yymm"].ToString() + "'");
                        for (int i = 0; i < row1.Length; i++)
                        {
                            DataRow row3 = rq_hcode1.Rows.Find(row1[i]["h_code"].ToString());
                            if (row3 == null)
                            {
                                DataRow aRow = rq_hcode1.NewRow();
                                aRow["h_code"] = row1[i]["h_code"].ToString();
                                aRow["h_name"] = row1[i]["h_name"].ToString();
                                rq_hcode1.Rows.Add(aRow);
                            }
                        }

                        DataRow row2 = rq_card.Rows.Find(_value);
                        DataRow aRow1 = ds.Tables["zz2z2"].NewRow();
                        aRow1["yymm"] = Row["yymm"].ToString();
                        aRow1["nobr"] = Row["nobr"].ToString();
                        aRow1["name_c"] = row["name_c"].ToString();
                        aRow1["name_e"] = row["name_e"].ToString();
                        aRow1["dept"] = row["dept"].ToString();
                        aRow1["d_name"] = row["d_name"].ToString();
                        aRow1["d_ename"] = row["d_ename"].ToString();
                        aRow1["late_no"] = int.Parse(Row["late_no"].ToString());
                        aRow1["los_no"] = row2 != null ? int.Parse(row2["los_no"].ToString()) : 0;
                        ds.Tables["zz2z2"].Rows.Add(aRow1);
                    }
                }

                DataTable rq_hcode = new DataTable();
                rq_hcode.Columns.Add("h_name", typeof(string));
                rq_hcode.PrimaryKey = new DataColumn[] { rq_hcode.Columns["h_name"] };
                DataRow[] rowt = rq_hcode1.Select("", "h_code asc");
                foreach (DataRow Row in rowt)
                {
                    DataRow row = rq_hcode.Rows.Find(Row["h_name"].ToString().Trim());                    
                    if (row == null)
                    {
                        DataRow aRow = rq_hcode.NewRow();                      
                        aRow["h_name"] =Row["h_name"].ToString().Trim();
                        rq_hcode.Rows.Add(aRow);
                    }
                }
                rq_hcode1 = null;

                DataRow aRowt = ds.Tables["zz2z2_t"].NewRow();
                for (int i = 0; i < rq_hcode.Rows.Count; i++)
                {
                    aRowt["Fld" + (i + 1)] = rq_hcode.Rows[i]["h_name"].ToString();
                }
                ds.Tables["zz2z2_t"].Rows.Add(aRowt);

                foreach (DataRow Row in ds.Tables["zz2z2"].Rows)
                {
                    for (int t = 0; t < rq_hcode.Rows.Count; t++)
                    {
                        Row["Fld" + (t + 1)] = 0;
                    }
                    DataRow[] row = rq_abs.Select(" nobr='" + Row["nobr"].ToString() + "' and yymm='" + Row["yymm"].ToString() + "'", "h_code");
                    for (int j = 0; j < row.Length; j++)
                    {
                        for (int i = 0; i < rq_hcode.Rows.Count; i++)
                        {
                            //string adfad = rq_hcode.Rows[i]["h_code"].ToString().Trim();
                            //string dfd = row[j]["h_code"].ToString().Trim();
                            decimal addf = decimal.Parse(row[j]["tol_hours"].ToString());
                            if (rq_hcode.Rows[i]["h_name"].ToString().Trim() != null)
                            {
                                if (row[j]["h_name"].ToString().Trim() == rq_hcode.Rows[i]["h_name"].ToString().Trim())
                                    Row["Fld" + (i + 1)] = decimal.Parse(row[j]["tol_hours"].ToString());
                            }
                            else
                                break;
                        }
                    }
                }

                if (ds.Tables["zz2z2"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                if (exportexcel)
                {
                    Export(ds.Tables["zz2z2"], ds.Tables["zz2z2_t"]);
                    this.Close();
                }
                else
                {
                    RptViewer.Reset();
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "AttReport", "*.rdlc");
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz2z2.rdlc";
                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_zz2z2", ds.Tables["zz2z2"]));
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_zz2z2_t", ds.Tables["zz2z2_t"]));
                    RptViewer.SetDisplayMode(DisplayMode.PrintLayout);
                    RptViewer.ZoomMode = ZoomMode.Percent;
                    RptViewer.ZoomPercent = 100;
                }

            }
            catch (Exception Ex)
            {
                JBModule.Message.TextLog.WriteLog(Ex);
                MessageBox.Show(Resources.All.ExceptionStr1 + "\n" + Ex.Message + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }       
        }

        void Export(DataTable DT, DataTable DT1)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));            
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            ExporDt.Columns.Add("年月", typeof(string));
            ExporDt.Columns.Add("遲到(次)", typeof(int));
            ExporDt.Columns.Add("忘刷(次)", typeof(int));
            for (int i = 0; i < DT1.Columns.Count; i++)
            {
                if (DT1.Rows[0][i].ToString().Trim() != "")
                    ExporDt.Columns.Add(DT1.Rows[0][i].ToString().Trim(), typeof(decimal));
                else
                    break;
            }

            foreach (DataRow Row in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row["dept"].ToString();
                aRow["部門名稱"] = Row["d_name"].ToString();                
                aRow["員工編號"] = Row["nobr"].ToString();
                aRow["員工姓名"] = Row["name_c"].ToString();
                aRow["英文姓名"] = Row["name_e"].ToString();
                aRow["年月"] = Row["yymm"].ToString();
                aRow["遲到(次)"] = int.Parse(Row["late_no"].ToString());
                aRow["忘刷(次)"] = int.Parse(Row["los_no"].ToString());
                for (int i = 0; i < DT1.Columns.Count; i++)
                {
                    if (DT1.Rows[0][i].ToString().Trim() != "")
                        aRow[DT1.Rows[0][i].ToString().Trim()] = decimal.Parse(Row["Fld" + (i + 1)].ToString());
                    else
                        break;
                }
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
