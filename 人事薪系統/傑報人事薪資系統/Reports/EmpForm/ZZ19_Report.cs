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
    public partial class ZZ19_Report : JBControls.JBForm
    {
        empdata ds = new empdata();
        string date_b, date_e, nobr_b, nobr_e, dept_b, dept_e, comp_b, comp_e, data_report, comp_name;
        bool exportexcel;
        public ZZ19_Report(string dateb, string datee, string nobrb, string nobre, string deptb, string depte, string compb, string compe, bool _exportexcel, string datareport, string compname)
        {
            InitializeComponent();
            date_b = dateb; date_e = datee; nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte;
            comp_b = compb; comp_e = compe; exportexcel = _exportexcel; data_report = datareport;
            comp_name = compname;
        }

        private void ZZ19_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "SELECT B.NOBR,B.ADATE,B.TTSCODE,C.d_no_disp AS DEPT,C.D_NAME,D.d_no_disp AS DEPTS,D.d_no_disp AS D_NO" +
                        ",E.JOB_DISP AS JOB,E.JOB_NAME,F.JOBS_DISP AS JOBS,F.JOB_NAME AS JOBS_NAME,G.JOBL_DISP AS JOBL" +
                        ",G.JOB_NAME AS JOBL_NAME,B.CARCD,H.CARNAME,B.CARD,B.EMPCD,I.EMPDESCR,B.YR_DAYS,B.NOTER,J.ROTET_DISP AS ROTET" +
                        ",J.ROTETNAME,B.WORKCD,B.CARD,K.WORK_ADDR,A.NAME_C,A.NAME_E,'' AS NDEPT,'' AS ND_NAME,D.D_NAME AS DS_NAME" +
                        ",L.TTSNAME"+
                        " FROM BASE A,BASETTS B" +
                        " LEFT OUTER JOIN DEPT C ON B.DEPT=C.D_NO" +
                        " LEFT OUTER JOIN DEPTS D ON B.DEPTS=D.D_NO" +
                        " LEFT OUTER JOIN JOB E ON B.JOB=E.JOB " +
                        " LEFT OUTER JOIN JOBS F ON B.JOBS=F.JOBS " +
                        " LEFT OUTER JOIN JOBL G ON B.JOBL=G.JOBL" +
                        " LEFT OUTER JOIN CARCD H ON B.CARCD=H.CARCD" +
                        " LEFT OUTER JOIN EMPCD I ON B.EMPCD=I.EMPCD" +
                        " LEFT OUTER JOIN ROTET J ON B.ROTET=J.ROTET" +
                        " LEFT OUTER JOIN WORKCD K ON B.WORKCD=K.WORK_CODE" +
                        " LEFT OUTER JOIN TTSCD L ON B.TTSCD=L.TTSCD" +
                        " WHERE A.NOBR=B.NOBR" +
                        " AND B.NOBR BETWEEN '" + nobr_b + "' AND '" + nobr_e + "'" +
                        " AND B.ADATE BETWEEN '" + date_b + "' AND '" + date_e + "'" +
                        " AND C.d_no_disp BETWEEN '" + dept_b + "' AND '" + dept_e + "'" +
                        " AND B.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +
                        "" + data_report + "" +
                        " ORDER BY B.NOBR";
                DataTable rq_zz19s1 = SqlConn.GetDataTable(sqlCmd);
                DataTable ttscode = SqlConn.GetDataTable("select code,name from mtcode where category='TTSCODE'");
                ttscode.PrimaryKey = new DataColumn[] { ttscode.Columns["code"] };
                if (rq_zz19s1.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                foreach (DataRow Row in rq_zz19s1.Rows)
                {
                    DataRow row = ttscode.Rows.Find(Row["ttscode"].ToString());
                    if (row != null)
                        Row["ttscode"] = row["name"].ToString();
                    ds.Tables["rq_zz19s1"].ImportRow(Row);
                }
                rq_zz19s1 = null; ttscode = null;

                string sqlCmd1 = "SELECT B.NOBR,C.d_no_disp AS NDEPT,C.D_NAME AS ND_NAME" +
                    " FROM BASETTS B" +
                    " LEFT OUTER JOIN DEPT C ON B.DEPT=C.D_NO" +
                    " WHERE B.NOBR BETWEEN '" + nobr_b + "' AND '" + nobr_e + "'" +
                    " AND B.ADATE BETWEEN '" + date_b + "' AND '" + date_e + "'" +
                    " AND B.NOBR+CONVERT(CHAR,B.ADATE,112) IN (SELECT C.NOBR+MAX( CONVERT(CHAR,C.ADATE,112)) FROM BASETTS C" +
                    " LEFT OUTER JOIN DEPT F ON C.DEPT=F.D_NO" +
                    " WHERE C.NOBR BETWEEN '" + nobr_b + "' AND '" + nobr_e + "'" +
                    " AND C.ADATE BETWEEN '" + date_b + "' AND '" + date_e + "'" +
                    " AND F.d_no_disp BETWEEN '" + dept_b + "' AND '" + dept_e + "'" +
                    " AND B.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +
                     "" + data_report + "" +
                    " GROUP BY C.NOBR)" +
                    " ORDER BY B.NOBR";
                DataTable rq_zz19s2 = SqlConn.GetDataTable(sqlCmd1);

                rq_zz19s2.PrimaryKey = new DataColumn[] { rq_zz19s2.Columns["nobr"] };

                for (int i = 0; i < ds.Tables["rq_zz19s1"].Rows.Count; i++)
                {
                    DataRow row1 = rq_zz19s2.Rows.Find(ds.Tables["rq_zz19s1"].Rows[i]["nobr"].ToString());
                    if (row1 != null)
                    {
                        ds.Tables["rq_zz19s1"].Rows[i]["ndept"] = row1["ndept"].ToString();
                        ds.Tables["rq_zz19s1"].Rows[i]["nd_name"] = row1["nd_name"].ToString();
                    }
                }
                rq_zz19s2 = null;
                if (exportexcel)
                {
                    RptViewer.Visible = false;
                    Export(ds.Tables["rq_zz19s1"]);
                    this.Close();
                }
                else
                {                    
                    RptViewer.Visible = true;
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "EmpReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "EmpReport", "*.rdlc");
                    
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz19.rdlc";
                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("empdata_rq_zz19s1", ds.Tables["rq_zz19s1"]));
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
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            ExporDt.Columns.Add("異動日期", typeof(DateTime));
            ExporDt.Columns.Add("異動類別", typeof(string));
            ExporDt.Columns.Add("編制代碼", typeof(string));
            ExporDt.Columns.Add("編制名稱", typeof(string));
            ExporDt.Columns.Add("成本代碼", typeof(string));
            ExporDt.Columns.Add("成本名稱", typeof(string));
            //ExporDt.Columns.Add("班別代碼", typeof(string));
            //ExporDt.Columns.Add("班別名稱", typeof(string));
            ExporDt.Columns.Add("輪班代碼", typeof(string));
            ExporDt.Columns.Add("輪班名稱", typeof(string));
            //ExporDt.Columns.Add("週末班別代碼", typeof(string));
            //ExporDt.Columns.Add("週末班別名稱", typeof(string));
            ExporDt.Columns.Add("刷卡", typeof(string));
            ExporDt.Columns.Add("職類代碼", typeof(string));
            ExporDt.Columns.Add("職類名稱", typeof(string));
            ExporDt.Columns.Add("職等代碼", typeof(string));
            ExporDt.Columns.Add("職等名稱", typeof(string));
            ExporDt.Columns.Add("職稱代碼", typeof(string));
            ExporDt.Columns.Add("職稱", typeof(string));
            ExporDt.Columns.Add("員別代碼", typeof(string));
            ExporDt.Columns.Add("員別名稱", typeof(string));
            //ExporDt.Columns.Add("交通車代碼", typeof(string));
            //ExporDt.Columns.Add("交通車名稱", typeof(string));
            ExporDt.Columns.Add("工作地代碼", typeof(string));
            ExporDt.Columns.Add("工作地名稱", typeof(string));
            //ExporDt.Columns.Add("特休天數", typeof(decimal));
            ExporDt.Columns.Add("主管不判", typeof(string));
            ExporDt.Columns.Add("異動原因", typeof(string));

            foreach (DataRow Row in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["員工編號"] = Row["nobr"].ToString();
                aRow["員工姓名"] = Row["name_c"].ToString();
                aRow["英文姓名"] = Row["name_e"].ToString();
                aRow["異動日期"] = DateTime.Parse(Row["adate"].ToString());
                aRow["異動類別"] = Row["ttscode"].ToString();
                aRow["編制代碼"] = Row["dept"].ToString();
                aRow["編制名稱"] = Row["d_name"].ToString();
                aRow["成本代碼"] = Row["depts"].ToString();
                aRow["成本名稱"] = Row["ds_name"].ToString();
                //aRow["班別代碼"] = Row["rote"].ToString();
                //aRow["班別名稱"] = Row["rotename"].ToString();
                aRow["輪班代碼"] = Row["rotet"].ToString();
                aRow["輪班名稱"] = Row["rotetname"].ToString();               
                aRow["刷卡"] = Row["card"].ToString();
                aRow["職類代碼"] = Row["jobs"].ToString();
                aRow["職類名稱"] = Row["jobs_name"].ToString();
                aRow["職等代碼"] = Row["jobl"].ToString();
                aRow["職等名稱"] = Row["jobl_name"].ToString();
                aRow["職稱代碼"] = Row["job"].ToString();
                aRow["職稱"] = Row["job_name"].ToString();
                aRow["員別代碼"] = Row["empcd"].ToString();
                aRow["員別名稱"] = Row["empdescr"].ToString();
                //aRow["交通車代碼"] = Row["carcd"].ToString();
                //aRow["交通車名稱"] = Row["carname"].ToString();
                aRow["工作地代碼"] = Row["workcd"].ToString();
                aRow["工作地名稱"] = Row["work_addr"].ToString();
                //aRow["特休天數"] = decimal.Parse(Row["yr_days"].ToString());
                aRow["主管不判"] = (bool.Parse(Row["noter"].ToString())) ? "是" : "否";
                aRow["異動原因"] = Row["ttsname"].ToString();
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
