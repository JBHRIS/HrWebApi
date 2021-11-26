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
    public partial class ZZ22A_Report : JBControls.JBForm
    {
        attenddata ds = new attenddata();
        string nobr_b, nobr_e, emp_b, emp_e, dept_b, dept_e, date_b, date_e, type_data, username, comp_name;
        bool exportexcel;
        public ZZ22A_Report(string nobrb, string nobre, string empb, string empe, string deptb, string depte, string dateb, string datee, string typedata, string _username, bool _exportexcel, string compname)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; emp_b = empb; emp_e = empe; dept_b = deptb; dept_e = depte;
            date_b = dateb; date_e = datee; type_data = typedata; username = _username;
            exportexcel = _exportexcel; comp_name = compname;
        }

        private void ZZ22A_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string CmdBase = "select b.nobr,a.name_c,c.d_no_disp as dept,c.d_name from base a,basetts b,dept c where ";
                CmdBase += string.Format(@" '{0}' between b.adate and b.ddate ", date_e);
                CmdBase += " and a.nobr=b.nobr and b.dept=c.d_no";
                CmdBase += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                CmdBase += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                CmdBase += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);
                CmdBase += type_data;
                CmdBase += " order by b.nobr";
                DataTable rq_base = SqlConn.GetDataTable(CmdBase);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                string CmdOt = "select a.nobr,a.bdate,right(datename(dw,a.bdate),1) as dw,a.btime,a.etime,a.ot_hrs,a.rest_hrs,";
                CmdOt += "a.ot_rote,c.rotename as ot_rotename,a.otrcd,b.otrname,a.note,d.rote,e.rotename,c.rote_disp";
                CmdOt += " from attend d,rote e,ot a";
                CmdOt += " left outer join otrcd b on a.otrcd=b.otrcd";
                CmdOt += " left outer join rote c on a.ot_rote=c.rote";
                CmdOt += " where d.nobr=a.nobr and d.adate=a.bdate and d.rote=e.rote ";
                CmdOt += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                CmdOt += string.Format(@" and a.bdate between '{0}' and '{1}'", date_b, date_e);
                CmdOt += "  and d.rote <> '00' and d.rote <> a.ot_rote ";
                CmdOt += "  order by a.nobr,a.bdate";
                DataTable rq_ot = SqlConn.GetDataTable(CmdOt);
                DataTable rq_zz22a = new DataTable();
                rq_zz22a = ds.Tables["zz22a"].Clone();
                rq_zz22a.TableName = "rq_zz22a";
                foreach (DataRow Row in rq_ot.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        DataRow aRow = rq_zz22a.NewRow();
                        aRow["dept"] = row["dept"].ToString();
                        aRow["d_name"] = row["d_name"].ToString();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["name_c"] = row["name_c"].ToString();
                        aRow["bdate"] = DateTime.Parse(Row["bdate"].ToString());
                        aRow["dw"] = Row["dw"].ToString();
                        aRow["btime"] = Row["btime"].ToString();
                        aRow["etime"] = Row["etime"].ToString();
                        aRow["ot_hrs"] = decimal.Parse(Row["ot_hrs"].ToString());
                        aRow["rest_hrs"] = decimal.Parse(Row["rest_hrs"].ToString());
                        aRow["ot_rote"] = Row["rote_disp"].ToString();
                        aRow["ot_rotename"] = Row["ot_rotename"].ToString();
                        aRow["rotename"] = Row["rotename"].ToString();
                        aRow["rote"] = Row["rote"].ToString();
                        aRow["otrname"] = Row["otrname"].ToString();
                        aRow["note"] = Row["note"].ToString();
                        rq_zz22a.Rows.Add(aRow);
                    }
                }

                if (rq_zz22a.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                DataRow[] SRow = rq_zz22a.Select("", "dept,nobr");
                foreach (DataRow Row in SRow)
                {
                    ds.Tables["zz22a"].ImportRow(Row);
                }
                rq_base = null; rq_ot = null; rq_zz22a = null;

                if (exportexcel)
                {
                    Export(ds.Tables["zz22a"]);
                    this.Close();
                }
                else
                {                  
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "AttReport");                   
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "AttReport", "*.rdlc");

                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz22a.rdlc";
                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_zz22a", ds.Tables["zz22a"]));
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
            ExporDt.Columns.Add("加班日期", typeof(string));
            ExporDt.Columns.Add("星期", typeof(string));
            ExporDt.Columns.Add("起時間", typeof(string));
            ExporDt.Columns.Add("迄時間", typeof(string));
            ExporDt.Columns.Add("加班時數", typeof(decimal));
            ExporDt.Columns.Add("補休時數", typeof(decimal));
            ExporDt.Columns.Add("出勤班別", typeof(string));
            ExporDt.Columns.Add("加班班別", typeof(string));
            ExporDt.Columns.Add("加班原因", typeof(string));
            ExporDt.Columns.Add("備註", typeof(string));
            foreach (DataRow Row in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row["dept"].ToString();
                aRow["部門名稱"] = Row["d_name"].ToString();
                aRow["員工編號"] = Row["nobr"].ToString();
                aRow["員工姓名"] = Row["name_c"].ToString();                
                aRow["加班日期"] = DateTime.Parse(Row["bdate"].ToString()).ToString("yyyy/MM/dd");
                aRow["星期"] = Row["dw"].ToString();
                aRow["起時間"] = Row["btime"].ToString();
                aRow["迄時間"] = Row["etime"].ToString();
                aRow["加班時數"] = decimal.Parse(Row["ot_hrs"].ToString());
                aRow["補休時數"] = decimal.Parse(Row["rest_hrs"].ToString());
                aRow["出勤班別"] = Row["rotename"].ToString();
                aRow["加班班別"] = Row["ot_rotename"].ToString();
                aRow["加班原因"] = Row["otrname"].ToString();
                aRow["備註"] = Row["note"].ToString();
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
