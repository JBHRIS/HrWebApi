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
    public partial class ZZ18_Report : JBControls.JBForm
    {
        empdata ds = new empdata();
        string date_b, date_e, nobr_b, nobr_e, emp_b, emp_e, ttscd_b, ttscd_e, data_report, comp_name;
        bool exportexcel;
        public ZZ18_Report(string dateb, string datee, string nobrb, string nobre, string empb, string empe, string ttscdb, string ttscde, bool _exportexcel, string datareport, string compname)
        {
            InitializeComponent();
            date_b = dateb; date_e = datee; nobr_b = nobrb; nobr_e = nobre; emp_b = empb; emp_e = empe;
            comp_name = compname; exportexcel = _exportexcel; data_report = datareport;
            ttscd_b = ttscdb; ttscd_e = ttscde;
        }

        private void ZZ18_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                DataTable rq_zz18s1 = new DataTable();
                rq_zz18s1 = ds.Tables["rq_zz18s1"].Clone();
                rq_zz18s1.TableName = "rq_zz18s1";
                string sqlCmd = "SELECT B.NOBR,C.d_no_disp AS DEPT,D.d_no_disp AS DEPTS,D.D_NAME AS DS_NAME,E.JOB_DISP AS JOB" +
                         ",E.JOB_NAME,F.JOBS_DISP AS JOBS,F.JOB_NAME AS JOBS_NAME,G.JOBL_DISP AS JOBL,G.JOB_NAME AS JOBL_NAME" +
                         ",I.ROTET_DISP AS ROTET,I.ROTETNAME,B.INDT,B.CARD,B.EMPCD,N.EMPDESCR,B.CARCD,K.CARNAME" +
                         ",B.WORKCD,L.WORK_ADDR,B.YR_DAYS,B.MANG,B.NOTER,B.ADATE,A.NAME_C,C.D_NAME,B.COMP,M.COMPNAME" +
                         ",T.TTSCD_DISP AS TTSCD,T.TTSNAME"+
                         " FROM BASE A,DEPT C ,BASETTS B" +
                         " LEFT OUTER JOIN DEPTS D ON B.DEPTS=D.D_NO" +
                         " LEFT OUTER JOIN JOB E ON B.JOB=E.JOB" +
                         " LEFT OUTER JOIN JOBS F ON B.JOBS=F.JOBS" +
                         " LEFT OUTER JOIN JOBL G ON B.JOBL=G.JOBL" +
                         //" LEFT OUTER JOIN ROTE H ON B.ROTE =H.ROTE" +
                         " LEFT OUTER JOIN ROTET I ON B.ROTET=I.ROTET" +
                         //" LEFT OUTER JOIN ROTE J ON B.ROTE_W=J.ROTE" +
                         " LEFT OUTER JOIN CARCD K ON B.CARCD=K.CARCD" +
                         " LEFT OUTER JOIN WORKCD L ON B.WORKCD=L.WORK_CODE" +
                         " LEFT OUTER JOIN EMPCD N ON B.EMPCD=N.EMPCD" +
                         " LEFT OUTER JOIN COMP M ON B.COMP=M.COMP" +
                         " LEFT OUTER JOIN TTSCD T ON B.TTSCD=T.TTSCD" +
                         " WHERE A.NOBR=B.NOBR" +
                         " AND B.NOBR BETWEEN '" + nobr_b + "' AND '" + nobr_e + "'" +
                         " AND B.ADATE BETWEEN '" + date_b + "' AND '" + date_e + "'" +
                         " AND T.TTSCD_DISP BETWEEN '" + ttscd_b + "' AND '" + ttscd_e + "'" +
                         " AND B.DEPT=C.D_NO" +
                         " AND TTSCODE='6'" +
                         "" + data_report + "" +
                         " ORDER BY B.NOBR";
                rq_zz18s1 = SqlConn.GetDataTable(sqlCmd);


                if (rq_zz18s1.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                foreach (DataRow Row in rq_zz18s1.Rows)
                {
                    ds.Tables["rq_zz18s1"].ImportRow(Row);
                }
                rq_zz18s1 = null;

                foreach (DataRow row in ds.Tables["rq_zz18s1"].Rows)
                {
                    string nobradate = "";
                    string str_nobr = row["nobr"].ToString();
                    string str_adate = Convert.ToDateTime(row["adate"].ToString()).ToShortDateString();
                    string sqlCmd14 = "SELECT NOBR+MAX(CONVERT(CHAR,ADATE,112)) FROM BASETTS" +
                        " WHERE ADATE < '" + str_adate + "' AND NOBR='" + str_nobr + "' GROUP BY NOBR";
                    DataTable dtRq_Basetts = SqlConn.GetDataTable(sqlCmd14);
                    if (dtRq_Basetts.Rows.Count > 0) nobradate = dtRq_Basetts.Rows[0][0].ToString();
                    dtRq_Basetts = null;

                    string sqlCmd13 = "SELECT B.NOBR,C.d_no_disp AS DEPT,E.d_no_disp AS DEPTS,E.D_NAME AS DS_NAME,F.JOB_DISP AS JOB" +
                    ",F.JOB_NAME,G.JOBS_DISP AS JOBS,G.JOB_NAME AS JOBS_NAME,H.JOBL_DISP AS JOBL,H.JOB_NAME AS JOBL_NAME" +
                    ",J.ROTET_DISP AS ROTET, J.ROTETNAME,B.CARD,B.EMPCD,L.EMPDESCR,B.CARCD,M.CARNAME,B.WORKCD,N.WORK_ADDR,B.YR_DAYS" +
                    ",B.MANG,B.NOTER,B.ADATE,A.NAME_C,C.D_NAME,B.COMP ,O.COMPNAME" +
                    ",T.TTSCD_DISP,T.TTSNAME" +
                    " FROM BASE A,DEPT C,BASETTS B" +
                    " LEFT OUTER JOIN DEPTS E ON B.DEPTS=E.D_NO" +
                    " LEFT OUTER JOIN JOB F ON B.JOB=F.JOB" +
                    " LEFT OUTER JOIN JOBS G ON B.JOBS=G.JOBS" +
                    " LEFT OUTER JOIN JOBL H ON B.JOBL=H.JOBL" +
                    //" LEFT OUTER JOIN ROTE I ON B.ROTE=I.ROTE" +
                    " LEFT OUTER JOIN ROTET J ON B.ROTET=J.ROTET" +
                    //" LEFT OUTER JOIN ROTE K ON B.ROTE_W =K.ROTE" +
                    " LEFT OUTER JOIN EMPCD L ON B.EMPCD=L.EMPCD" +
                    " LEFT OUTER JOIN CARCD M ON B.CARCD=M.CARCD" +
                    " LEFT OUTER JOIN WORKCD N ON B.WORKCD=N.WORK_CODE" +
                    " LEFT OUTER JOIN COMP O ON B.COMP=O.COMP" +
                    " LEFT OUTER JOIN TTSCD T ON B.TTSCD=T.TTSCD" +
                    " WHERE B.NOBR+CONVERT(CHAR,B.ADATE,112) = '" + nobradate + "'" +
                    " AND A.NOBR=B.NOBR" +
                    " AND B.NOBR='" + str_nobr + "'" +
                    " AND B.DEPT=C.D_NO";
                    DataTable dtRq_zz18s3 = SqlConn.GetDataTable(sqlCmd13);

                    if (dtRq_zz18s3.Rows.Count > 0)
                    {
                        row["dept2"] = dtRq_zz18s3.Rows[0]["dept"].ToString();
                        row["d_name2"] = dtRq_zz18s3.Rows[0]["d_name"].ToString();
                        row["depts2"] = dtRq_zz18s3.Rows[0]["depts"].ToString();
                        row["ds_name2"] = dtRq_zz18s3.Rows[0]["ds_name"].ToString();
                        row["job2"] = dtRq_zz18s3.Rows[0]["job"].ToString();
                        row["job_name2"] = dtRq_zz18s3.Rows[0]["job_name"].ToString();
                        row["jobs2"] = dtRq_zz18s3.Rows[0]["jobs"].ToString();
                        row["jobs_name2"] = dtRq_zz18s3.Rows[0]["jobs_name"].ToString();
                        row["jobl2"] = dtRq_zz18s3.Rows[0]["jobl"].ToString();
                        row["jobl_name2"] = dtRq_zz18s3.Rows[0]["jobl_name"].ToString();
                        //row["rote2"] = dtRq_zz18s3.Rows[0]["rote"].ToString();
                        //row["rotename2"] = dtRq_zz18s3.Rows[0]["rotename"].ToString();
                        row["rotet2"] = dtRq_zz18s3.Rows[0]["rotet"].ToString();
                        row["rotetname2"] = dtRq_zz18s3.Rows[0]["rotetname"].ToString();
                        //row["rote_w2"] = dtRq_zz18s3.Rows[0]["rote_w"].ToString();
                        //row["rotewname2"] = dtRq_zz18s3.Rows[0]["rotewname"].ToString();
                        row["card2"] = dtRq_zz18s3.Rows[0]["card"].ToString();
                        row["empcd2"] = dtRq_zz18s3.Rows[0]["empcd"].ToString();
                        row["empdescr2"] = dtRq_zz18s3.Rows[0]["empdescr"].ToString();
                        row["carcd2"] = dtRq_zz18s3.Rows[0]["carcd"].ToString();
                        row["carname2"] = dtRq_zz18s3.Rows[0]["carname"].ToString();
                        row["workcd2"] = dtRq_zz18s3.Rows[0]["workcd"].ToString();
                        row["work_addr2"] = dtRq_zz18s3.Rows[0]["work_addr"].ToString();
                        row["yr_days2"] = dtRq_zz18s3.Rows[0]["yr_days"].ToString();
                        row["mang2"] = bool.Parse(dtRq_zz18s3.Rows[0]["mang"].ToString());
                        row["noter2"] = bool.Parse(dtRq_zz18s3.Rows[0]["noter"].ToString());
                        row["comp2"] = dtRq_zz18s3.Rows[0]["comp"].ToString();
                        row["compname2"] = dtRq_zz18s3.Rows[0]["compname"].ToString();
                        row["ttscd2"] = dtRq_zz18s3.Rows[0]["ttscd_disp"].ToString();
                        row["ttsname2"] = dtRq_zz18s3.Rows[0]["ttsname"].ToString();
                    }
                    dtRq_zz18s3 = null;
                }

                if (ds.Tables["rq_zz18s1"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                if (exportexcel)
                {
                    RptViewer.Visible = false;
                    Export(ds.Tables["rq_zz18s1"]);
                    this.Close();
                }               
                else
                {                     
                    RptViewer.Visible = true;
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "EmpReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "EmpReport", "*.rdlc");
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz18.rdlc";
                    //RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", company) });
                    //RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    //RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                    RptViewer.LocalReport.DataSources.Clear(); 
                   
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("empdata_rq_zz18s1", ds.Tables["rq_zz18s1"]));
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
            ExporDt.Columns.Add("異動日期", typeof(DateTime));
            ExporDt.Columns.Add("到職日期", typeof(DateTime));
            ExporDt.Columns.Add("異動前公司代碼", typeof(string));           
            ExporDt.Columns.Add("異動前公司名稱", typeof(string));
            ExporDt.Columns.Add("異動後公司代碼", typeof(string));
            ExporDt.Columns.Add("異動後公司名稱", typeof(string));
            ExporDt.Columns.Add("異動前編制代碼", typeof(string));            
            ExporDt.Columns.Add("異動前編制名稱", typeof(string));
            ExporDt.Columns.Add("異動後編制代碼", typeof(string));
            ExporDt.Columns.Add("異動後編制名稱", typeof(string));
            ExporDt.Columns.Add("異動前成本代碼", typeof(string));
            ExporDt.Columns.Add("異動前成本名稱", typeof(string));
            ExporDt.Columns.Add("異動後成本代碼", typeof(string));                    
            ExporDt.Columns.Add("異動後成本名稱", typeof(string));
            ExporDt.Columns.Add("異動前班別代碼", typeof(string));            
            ExporDt.Columns.Add("異動前班別名稱", typeof(string));
            ExporDt.Columns.Add("異動後班別代碼", typeof(string));
            ExporDt.Columns.Add("異動後班別名稱", typeof(string));
            ExporDt.Columns.Add("異動前刷卡", typeof(string));
            ExporDt.Columns.Add("異動後刷卡", typeof(string));
            ExporDt.Columns.Add("異動前職類代碼", typeof(string));            
            ExporDt.Columns.Add("異動前職類名稱", typeof(string));
            ExporDt.Columns.Add("異動後職類代碼", typeof(string));
            ExporDt.Columns.Add("異動後職類名稱", typeof(string));
            ExporDt.Columns.Add("異動前職等代碼", typeof(string));            
            ExporDt.Columns.Add("異動前職等名稱", typeof(string));
            ExporDt.Columns.Add("異動後職等代碼", typeof(string));
            ExporDt.Columns.Add("異動後職等名稱", typeof(string));
            ExporDt.Columns.Add("異動前職稱代碼", typeof(string));            
            ExporDt.Columns.Add("異動前職稱", typeof(string));
            ExporDt.Columns.Add("異動後職稱代碼", typeof(string));
            ExporDt.Columns.Add("異動後職稱", typeof(string));
            ExporDt.Columns.Add("異動前員別代碼", typeof(string));            
            ExporDt.Columns.Add("異動前員別名稱", typeof(string));
            ExporDt.Columns.Add("異動後員別代碼", typeof(string));
            ExporDt.Columns.Add("異動後員別名稱", typeof(string)); 
            ExporDt.Columns.Add("異動前工作地代碼", typeof(string));            
            ExporDt.Columns.Add("異動前工作地名稱", typeof(string));
            ExporDt.Columns.Add("異動後工作地代碼", typeof(string));
            ExporDt.Columns.Add("異動後工作地名稱", typeof(string));
            ExporDt.Columns.Add("異動前異動代碼", typeof(string));            
            ExporDt.Columns.Add("異動前異動名稱", typeof(string));
            ExporDt.Columns.Add("異動後異動代碼", typeof(string));
            ExporDt.Columns.Add("異動後異動名稱", typeof(string));
            //ExporDt.Columns.Add("異動前特休天數", typeof(decimal));
            ExporDt.Columns.Add("異動前主管", typeof(string));
            ExporDt.Columns.Add("異動後主管", typeof(string));
            ExporDt.Columns.Add("異動前不判斷早退", typeof(string));
            ExporDt.Columns.Add("異動後不判斷早退", typeof(string));
            //ExporDt.Columns.Add("異動後特休天數", typeof(decimal));
           
            foreach (DataRow Row in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["員工編號"] = Row["nobr"].ToString();
                aRow["員工姓名"] = Row["name_c"].ToString();
                aRow["異動日期"] = DateTime.Parse(Row["adate"].ToString());
                aRow["到職日期"] = DateTime.Parse(Row["indt"].ToString());
                aRow["異動前公司代碼"] = Row["comp2"].ToString();
                aRow["異動前公司名稱"] = Row["compname2"].ToString();
                aRow["異動前編制代碼"] = Row["dept2"].ToString();
                aRow["異動前編制名稱"] = Row["d_name2"].ToString();
                aRow["異動前成本代碼"] = Row["depts2"].ToString();
                aRow["異動前成本名稱"] = Row["ds_name2"].ToString();
                aRow["異動前班別代碼"] = Row["rotet2"].ToString();
                aRow["異動前班別名稱"] = Row["rotetname2"].ToString();
                aRow["異動前刷卡"] = Row["card2"].ToString();
                aRow["異動前職類代碼"] = Row["jobs2"].ToString();
                aRow["異動前職類名稱"] = Row["jobs_name2"].ToString();
                aRow["異動前職等代碼"] = Row["jobl2"].ToString();
                aRow["異動前職等名稱"] = Row["jobl_name2"].ToString();
                aRow["異動前職稱代碼"] = Row["job2"].ToString();
                aRow["異動前職稱"] = Row["job_name2"].ToString();
                aRow["異動前員別代碼"] = Row["empcd2"].ToString();
                aRow["異動前員別名稱"] = Row["empdescr2"].ToString();               
                aRow["異動前工作地代碼"] = Row["workcd2"].ToString();
                aRow["異動前工作地名稱"] = Row["work_addr2"].ToString();
                //aRow["異動前特休天數"] = decimal.Parse(Row["yr_days2"].ToString());
                aRow["異動前主管"] = (bool.Parse(Row["mang2"].ToString())) ? "是" : "否";
                aRow["異動前不判斷早退"] = (bool.Parse(Row["noter2"].ToString())) ? "是" : "否";
                aRow["異動後公司代碼"] = Row["comp"].ToString();
                aRow["異動後公司名稱"] = Row["compname"].ToString();
                aRow["異動後編制代碼"] = Row["dept"].ToString();
                aRow["異動後編制名稱"] = Row["d_name"].ToString();
                aRow["異動後成本代碼"] = Row["depts"].ToString();
                aRow["異動後成本名稱"] = Row["ds_name"].ToString();
                aRow["異動後班別代碼"] = Row["rotet"].ToString();
                aRow["異動後班別名稱"] = Row["rotetname"].ToString();
                aRow["異動後刷卡"] = Row["card"].ToString();
                aRow["異動後職類代碼"] = Row["jobs"].ToString();
                aRow["異動後職類名稱"] = Row["jobs_name"].ToString();
                aRow["異動後職等代碼"] = Row["jobl"].ToString();
                aRow["異動後職等名稱"] = Row["jobl_name"].ToString();
                aRow["異動後職稱代碼"] = Row["job"].ToString();
                aRow["異動後職稱"] = Row["job_name"].ToString();
                aRow["異動後員別代碼"] = Row["empcd"].ToString();
                aRow["異動後員別名稱"] = Row["empdescr"].ToString();                
                aRow["異動後工作地代碼"] = Row["workcd"].ToString();
                aRow["異動後工作地名稱"] = Row["work_addr"].ToString();
                aRow["異動前異動代碼"] = Row["ttscd2"].ToString();
                aRow["異動前異動名稱"] = Row["ttsname2"].ToString();
                aRow["異動後異動代碼"] = Row["ttscd"].ToString();
                aRow["異動後異動名稱"] = Row["ttsname"].ToString();
                //aRow["異動後特休天數"] = decimal.Parse(Row["yr_days"].ToString());
                aRow["異動後主管"] = (bool.Parse(Row["mang"].ToString())) ? "是" : "否";
                aRow["異動後不判斷早退"] = (bool.Parse(Row["noter"].ToString())) ? "是" : "否";
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }

        
    }
}
