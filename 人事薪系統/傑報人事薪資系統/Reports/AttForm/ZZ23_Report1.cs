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
    public partial class ZZ23_Report1 : JBControls.JBForm
    {
        attenddata ds = new attenddata();
        string check_rote, type_data, lcstr, str1;
        string nobr_b, nobr_e, dept_b, dept_e, comp_b, comp_e, h_codeb, h_codee, username, comp_name;
        string yymm_b, yymm_e, date_b, date_e, reporttype, saladr_b, saladr_e;
        bool exportexcel;
        public ZZ23_Report1(string nobrb, string nobre, string deptb, string depte, string compb, string compe, string hcodeb, string hcodee, string saladrb, string saladre, string yymmb, string yymme, string dateb, string datee, string checkrote, string typedata, string _lcstr, string _reporttype, bool _exportexcel, string _username, string compname)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; comp_b = compb; comp_e = compe;
            h_codeb = hcodeb; h_codee = hcodee; yymm_b = yymmb; yymm_e = yymme; date_b = dateb;
            date_e = datee; reporttype = _reporttype; exportexcel = _exportexcel; check_rote = checkrote;
            type_data = typedata; lcstr = _lcstr; username = _username; saladr_b = saladrb; saladr_e = saladre;
            comp_name = compname;
        }

        private void ZZ23_Report1_Load(object sender, EventArgs e)
        {
             try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select b.nobr,a.name_c,a.name_e,b.dept,c.d_name,c.d_ename,b.depts,d.d_name as ds_name";
                sqlCmd += "  from base a,basetts b ";
                sqlCmd += " left outer join dept c on b.dept=c.d_no";
                sqlCmd += " left outer join depts d on b.depts=d.d_no";
                sqlCmd += string.Format(@" where a.nobr=b.nobr and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                sqlCmd += string.Format(@" and b.dept between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd += string.Format(@" and b.comp between '{0}' and '{1}'", comp_b, comp_e);
                sqlCmd += string.Format(@" and b.saladr between '{0}' and '{1}'", saladr_b, saladr_e);
                sqlCmd += type_data;
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                 //系統自動產生忘刷3次及遲到15分事假1小時,btime及etime空白或00是可產生此資料
                string sqlAbs = "select a.nobr,a.bdate,a.btime,a.etime,b.h_code_disp as h_code,b.h_name,b.unit,a.tol_hours,datename(dw,a.bdate) as dw,";
                sqlAbs += "a.note,c.forget";
                sqlAbs += "  from abs a ,hcode b ,attend c where a.h_code=b.h_code and a.nobr=c.nobr and a.bdate=c.adate";
                sqlAbs += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlAbs += string.Format(@" and b.h_code_disp between '{0}' and '{1}'", h_codeb, h_codee);
                sqlAbs += "  and b.flag='-' and b.not_del=0  and c.forget>0";
                sqlAbs += lcstr;
                DataTable rq_abs = SqlConn.GetDataTable(sqlAbs);
                DataTable rq_zz231 = new DataTable();
                rq_zz231 = ds.Tables["zz231"].Clone();
                
                foreach (DataRow Row in rq_abs.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        DataRow aRow = rq_zz231.NewRow();
                        aRow["dept"] = row["depts"].ToString();
                        aRow["d_name"] = row["d_name"].ToString();
                        aRow["d_ename"] = row["d_ename"].ToString();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["name_c"] = row["name_c"].ToString();
                        aRow["name_e"] = row["name_e"].ToString();
                        aRow["bdate"] = DateTime.Parse(Row["bdate"].ToString());
                        aRow["h_code"] = Row["h_code"].ToString();
                        aRow["h_name"] = Row["h_name"].ToString();
                        aRow["unit"] = Row["unit"].ToString();
                        aRow["btime"] = Row["btime"].ToString();
                        aRow["etime"] = Row["etime"].ToString();
                        aRow["tol_hrs"] = decimal.Parse(Row["tol_hours"].ToString());
                        aRow["note"] = Row["note"].ToString();
                        aRow["forget"] = decimal.Round(decimal.Parse(Row["forget"].ToString()), 0);
                        rq_zz231.Rows.Add(aRow);
                    }
                }

                if (rq_zz231.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                DataRow[] SRow = rq_zz231.Select("", "dept,nobr");
                foreach (DataRow Row in SRow)
                {
                    ds.Tables["zz231"].ImportRow(Row);
                }
                rq_abs = null; rq_base = null; rq_zz231 = null;

                if (exportexcel)
                {
                    Export(ds.Tables["zz231"]);
                    this.Close();
                }
                else
                {                   
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "AttReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "AttReport", "*.rdlc");

                   RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz236.rdlc";

                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_zz231", ds.Tables["zz231"]));
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
            ExporDt.Columns.Add("請假日期", typeof(string));
            ExporDt.Columns.Add("時間起", typeof(string));
            ExporDt.Columns.Add("時間迄", typeof(string));
            ExporDt.Columns.Add("單位", typeof(string));
            ExporDt.Columns.Add("時數", typeof(decimal));
            ExporDt.Columns.Add("忘刷", typeof(int));
            ExporDt.Columns.Add("備註", typeof(string));            
            foreach (DataRow Row in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row["dept"].ToString();
                aRow["部門名稱"] = Row["d_name"].ToString();
                aRow["英文部門名稱"] = Row["d_ename"].ToString();
                aRow["員工編號"] = Row["nobr"].ToString();
                aRow["員工姓名"] = Row["name_c"].ToString();
                aRow["英文姓名"] = Row["name_e"].ToString();
                aRow["假別"] = Row["h_name"].ToString();
                aRow["請假日期"] = DateTime.Parse(Row["bdate"].ToString());
                aRow["時間起"] = Row["btime"].ToString();
                aRow["時間迄"] = Row["etime"].ToString();
                aRow["單位"] = Row["unit"].ToString();
                aRow["時數"] = decimal.Parse(Row["tol_hrs"].ToString());
                aRow["忘刷"] = int.Parse(Row["forget"].ToString());
                aRow["備註"] = Row["note"].ToString();
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
