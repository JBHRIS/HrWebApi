/* ======================================================================================================
 * 功能名稱：服務證明
 * 功能代號：ZZ1D
 * 功能路徑：報表列印 > 人事 > 服務證明
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\EmpForm\ZZ1D_Report.cs
 * 功能用途：
 *  
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/03/10    Daniel Chih    Ver 1.0.01     1. 新增報表選項：非自願離職證明
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/03/10
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

namespace JBHR.Reports.EmpForm
{
    public partial class ZZ1D_Report : JBControls.JBForm 
    {       
        empdata ds = new empdata();
        string nobr_b, nobr_e, date_b, dept_b, dept_e, comp_b, comp_e, type_indt, data_type, note, note1, comp_name;
        bool reporttype1, reporttype2, nonself_resign_report_type;
        JBModule.Data.ApplicationConfigSettings AppConfig = new JBModule.Data.ApplicationConfigSettings("ZZ1D", MainForm.COMPANY);
        public ZZ1D_Report(string nobrb, string nobre, string dateb, string deptb, string depte, string compb, string compe, bool _reporttype1, bool _reporttype2, bool _nonself_resign_report_type, string typeindt, string datatype, string _note, string _note1, string compname)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; date_b = dateb; dept_b = deptb; dept_e = depte;
            comp_b = compb; comp_e = compe; note1 = _note1;
            reporttype1 = _reporttype1; reporttype2 = _reporttype2; nonself_resign_report_type = _nonself_resign_report_type;
            type_indt = typeindt;
            data_type = datatype; note = _note; comp_name = compname;
        }

        private void ZZ1D_Report_Load(object sender, EventArgs e)
        {
            try
            {
                var CompTitleDisplay = AppConfig.GetConfig("CompTitleDisplay").GetString() == "False" ? false : true;
                RptViewer.LocalReport.SubreportProcessing += new Microsoft.Reporting.WinForms.SubreportProcessingEventHandler(SubReportProcessingEventHandler);
                DataTable rq_zz1ds1 = new DataTable();
                rq_zz1ds1 = ds.Tables["rq_zz1ds1"].Clone();
                rq_zz1ds1.TableName = "rq_zz1ds1";
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");

                if (reporttype1)
                {
                    string sqlCmd = "SELECT DISTINCT A.NOBR,A.NAME_C,A.NAME_E,A.BIRDT,A.IDNO,B.ADATE,A.COUNT_MA,B.COMP" +
                        ",D.D_NO_DISP AS DEPT,D.D_NAME,D_ENAME,E.JOB_DISP AS JOB,E.JOB_NAME,E.JOB_ENAME,A.KEY_DATE" +
                        "," + type_indt + ",A. BORN_ADDR,DBO.GETTOTALYEARS(A.NOBR,B.OUDT) AS WK_YRS,A.NAME_C,A.SEX" +
                        ",F.LessonName,G.GroupName,H.D_NO_DISP AS DEPTS,H.D_NAME AS DS_NAME"+
                        " FROM  BASE A,BASETTS B" +
                         " LEFT OUTER JOIN DEPT D ON B.DEPT =D.D_NO" +
                        " LEFT OUTER JOIN JOB E ON B.JOB=E.JOB" +
                        " LEFT OUTER JOIN LessonType F ON B.STATION=F.Lessoncode"+
                        " LEFT OUTER JOIN GROUPTYPE G ON B.APGRPCD=G.Groupcode" +
                        " LEFT OUTER JOIN DEPTS H ON B.DEPTS=H.D_NO" +
                        " WHERE A.NOBR=B.NOBR" +
                        " AND '" + date_b + "' BETWEEN B.ADATE AND B.DDATE" +
                        " AND D.D_NO_DISP BETWEEN '" + dept_b + "'AND '" + dept_e + "'" +
                        " AND A.NOBR BETWEEN '" + nobr_b + "' AND '" + nobr_e + "'" +
                        " AND TTSCODE IN ('1','4','6')" +
                        " AND B.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +
                        " " + data_type + "" +
                        " ORDER BY D.D_NO_DISP,A.NOBR";
                    rq_zz1ds1 = SqlConn.GetDataTable(sqlCmd);
                }
                //離職證明 OR 非自願離職證明
                else if (reporttype2 || nonself_resign_report_type)
                {
                    string _dateb = Convert.ToString(DateTime.Now.Year) + "/01/01";
                    string sqlCmd1 = "SELECT DISTINCT A.NOBR,A.NAME_C,A.NAME_E,A.BIRDT,A.IDNO,B.ADATE,A.COUNT_MA,B.COMP" +
                        ",D.D_NO_DISP AS DEPT,D.D_NAME,D_ENAME,E.JOB_DISP AS JOB,E.JOB_NAME,E.JOB_ENAME,A.KEY_DATE" +
                        "," + type_indt + ",B.OUDT,A. BORN_ADDR,DBO.GETTOTALYEARS(A.NOBR,B.OUDT) AS WK_YRS,A.NAME_C,A.SEX" +
                        ",F.LessonName,G.GroupName,H.D_NO_DISP AS DEPTS,H.D_NAME AS DS_NAME,B.TTSCODE,B.STOUDT" +
                        " FROM  BASE A,BASETTS B" +
                        " LEFT OUTER JOIN DEPT D ON B.DEPT =D.D_NO" +
                        " LEFT OUTER JOIN JOB E ON B.JOB=E.JOB" +
                        " LEFT OUTER JOIN LessonType F ON B.STATION=F.Lessoncode" +
                        " LEFT OUTER JOIN GROUPTYPE G ON B.APGRPCD=G.Groupcode" +
                        " LEFT OUTER JOIN DEPTS H ON B.DEPTS=H.D_NO" +
                        " WHERE A.NOBR=B.NOBR" +
                        " AND '" + date_b + "' BETWEEN B.ADATE AND B.DDATE" +
                        " AND D.D_NO_DISP BETWEEN '" + dept_b + "'AND '" + dept_e + "'" +
                        " AND A.NOBR BETWEEN '" + nobr_b + "' AND '" + nobr_e + "'" +
                        " AND TTSCODE IN ('2','3','5')" +
                        " AND B.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +
                        " " + data_type + "" +
                        " ORDER BY D.D_NO_DISP,A.NOBR";
                    rq_zz1ds1 = SqlConn.GetDataTable(sqlCmd1); 
                }
                rq_zz1ds1.Columns.Add("compname", typeof(string));
                rq_zz1ds1.Columns.Add("chairman", typeof(string));
                rq_zz1ds1.Columns.Add("addr", typeof(string));
                rq_zz1ds1.Columns.Add("addr1", typeof(string));
                rq_zz1ds1.Columns.Add("tel", typeof(string));
                rq_zz1ds1.Columns.Add("fax", typeof(string));
                rq_zz1ds1.Columns.Add("compid", typeof(string));
                DataTable rq_comp = SqlConn.GetDataTable("select comp,compname,chairman,addr,tel,fax,compid from comp");
                rq_comp.PrimaryKey = new DataColumn[] { rq_comp.Columns["comp"] };
                if (rq_zz1ds1.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                foreach (DataRow Row in rq_zz1ds1.Rows)
                {
                    if (Row["sex"].ToString().Trim() == "F")
                    {
                        Row["sex"] = "女";                       
                    }
                    else if (Row["sex"].ToString().Trim() == "M")
                    {
                        Row["sex"] = "男";                       
                    }
                    DataRow row = rq_comp.Rows.Find(Row["comp"].ToString());
                    if (row != null)
                    {
                        Row["compname"] = CompTitleDisplay ? row["compname"].ToString() : string.Empty;
                        Row["chairman"] = row["chairman"].ToString();
                        Row["addr"] = row["addr"].ToString();
                        //Row["addr1"] = row["addr_e"].ToString();
                        Row["tel"] = row["tel"].ToString();
                        Row["fax"] = row["fax"].ToString();
                        Row["compid"] = row["compid"].ToString();
                    }
                    if (reporttype2)
                    {
                        if (Row["ttscode"].ToString()=="5")
                        {
                            if (!Row.IsNull("stoudt")) Row["oudt"] = DateTime.Parse(Row["stoudt"].ToString());
                        }
                    }
                    ds.Tables["rq_zz1ds1"].ImportRow(Row);
                }
                rq_zz1ds1 = null;

                string _no = DateTime.Now.ToString("yyyy").Substring(2, 2) + DateTime.Now.ToString("MMddhhs");

                for (int i = 0; i < ds.Tables["rq_zz1ds1"].Rows.Count; i++)
                {
                   
                    ds.Tables["rq_zz1ds1"].Rows[i]["number"] = _no + i;
                }
              

                RptViewer.Visible = true;
                RptViewer.Reset();
                RptViewer.LocalReport.SubreportProcessing += new Microsoft.Reporting.WinForms.SubreportProcessingEventHandler(SubReportProcessingEventHandler);              
                string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "EmpReport", "*.rdlc");

                if (reporttype1)
                {
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz1D.rdlc";                   
                }
                //離職證明
                else if (reporttype2)
                {
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz1DA.rdlc";                    
                }
                //非自願離職證明 - Added By Daniel Chih - 2021/03/10
                else if (nonself_resign_report_type)
                {
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz1D_NonSelf_Resign.rdlc";
                }

                RptViewer.LocalReport.DataSources.Clear();
               
                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Note", note) });
                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Note1", note1) });
                RptViewer.LocalReport.DataSources.Add(new ReportDataSource("empdata_rq_zz1ds1", ds.Tables["rq_zz1ds1"]));
                RptViewer.SetDisplayMode(DisplayMode.PrintLayout);
                RptViewer.ZoomMode = ZoomMode.FullPage;
                //RptViewer.ZoomPercent = JBHR.Reports.ReportClass.GetReportPercent();
            }
            catch (Exception Ex)
            {
                JBModule.Message.TextLog.WriteLog(Ex);
                MessageBox.Show(Resources.All.ExceptionStr1 + "\n" + Ex.Message + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
           
        }

        private void SubReportProcessingEventHandler(object sender, Microsoft.Reporting.WinForms.SubreportProcessingEventArgs e)
        {
            e.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("empdata_rq_zz1ds1", ds.Tables["rq_zz1ds1"]));
        }

    }
}
