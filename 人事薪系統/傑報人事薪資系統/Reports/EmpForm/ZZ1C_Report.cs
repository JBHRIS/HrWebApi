/* ======================================================================================================
 * 功能名稱：學經歷明細表
 * 功能代號：ZZ1C
 * 功能路徑：報表列印 > 人事 > 學經歷明細表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\EmpForm\ZZ1C_Report.cs
 * 功能用途：
 *  用於產出學經歷明細表
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/07/27    Daniel Chih    Ver 1.0.01     1. 修改學經歷明細表的科系資料來源
 * 2021/08/09    Daniel Chih    Ver 1.0.02     1. 修正無法印出報表的問題
 * 2021/08/10    Daniel Chih    Ver 1.0.03     1. 科系資料無法撈取時，顯示科系詳細資料
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/08/10
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
    public partial class ZZ1C_Report : JBControls.JBForm
    {
		//string in_out;
        string only_schl, report_type, data_report,username;
        empdata ds = new empdata();
        DataTable rq_basetts = new DataTable();
        string date_b, nobr_b, nobr_e, dept_b, dept_e, emp_b, emp_e, comp_b, comp_e, edu_b, edu_e, date_t, comp_name;
        bool exportexcel;
        public ZZ1C_Report(string dateb, string nobrb, string nobre, string deptb, string depte, string empb, string empe, string compb, string compe, string edub, string edue, string datet, string onlyschl, string reporttype, string datareport, bool _exportexcel, string _username, string compname)
        {
            InitializeComponent();
            date_b = dateb; date_t = datet; nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte;
            emp_b = empb; emp_e = empe; comp_b = compb; comp_e = compe; edu_b = edub; edu_e = edue;            
            only_schl = onlyschl; report_type = reporttype; data_report = datareport;
            exportexcel = _exportexcel; username = _username; comp_name = compname;
        }

        private void ZZ1C_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");

                string sqlCmd = "select job,job_disp,job_name from job";
                DataTable rq_job = SqlConn.GetDataTable(sqlCmd);
                rq_job.PrimaryKey = new DataColumn[] { rq_job.Columns["job"] };

                string sqlCmd0 = "select jobl,jobl_disp,job_name from jobl";
                DataTable rq_jobl = SqlConn.GetDataTable(sqlCmd0);
                rq_jobl.PrimaryKey = new DataColumn[] { rq_jobl.Columns["jobl"] };

                string sqlCmd01 = "select jobs,job_name from jobs";
                DataTable rq_jobs = SqlConn.GetDataTable(sqlCmd01);
                rq_jobs.PrimaryKey = new DataColumn[] { rq_jobs.Columns["jobs"] };

                DataTable rq_depttree = SqlConn.GetDataTable("select d_no,d_no_disp,d_name from dept");
                rq_depttree.PrimaryKey = new DataColumn[] { rq_depttree.Columns["d_no"] };

                DataTable rq_subj = SqlConn.GetDataTable("select subcode,subdesc from subcode");
                rq_subj.PrimaryKey = new DataColumn[] { rq_subj.Columns["subcode"] };

                //string sqlCmd31 = "SELECT SCHLCODE,SCHLAY FROM SCHLCODE";
                //DataTable rq_schlcode = SqlConn.GetDataTable(sqlCmd31);
                //rq_schlcode.PrimaryKey = new DataColumn[] { rq_schlcode.Columns["schlcode"] };

                //string sqlCmd21 = "SELECT B.NOBR,B.INDT,B.STDT,B.STINDT,B.TTSCODE " +
                //         " FROM BASETTS B " +
                //         " WHERE B.DEPT BETWEEN '" + dept_b + "' AND '" + dept_e + "'" +
                //         " AND B.NOBR BETWEEN '" + nobr_b + "' AND '" + nobr_e + "'" +
                //         " AND TTSCODE in('3','4')";
                //DataTable rq_basetts = SqlConn.GetDataTable(sqlCmd21);
                string sqlCmd6 = "SELECT B.NOBR,SUM(DATEDIFF(DAY,B.STDT,B.STINDT)) AS DAYS " +
                        " FROM BASE A,BASETTS B" +
                      "  LEFT OUTER JOIN DEPT D ON B.DEPT=D.D_NO"+
                      " WHERE A.NOBR=B.NOBR" +
                      " AND B.NOBR BETWEEN '" + nobr_b + "' AND '" + nobr_e + "'" +
                      " AND D.D_NO_DISP BETWEEN '" + dept_b + "' AND '" + dept_e + "'" +
                      " AND B.STDT is not null AND B.STINDT is not null " +
                      " AND TTSCODE ='4'" +
                      " GROUP BY B.NOBR";
                DataTable rq_basetts = SqlConn.GetDataTable(sqlCmd6);
                rq_basetts.PrimaryKey = new DataColumn[] { rq_basetts.Columns["nobr"] };

                if (report_type == "1")
                {
                    string sqlCmd1 = "SELECT D.D_NO_DISP AS DEPT,B.JOB,B.INDT,A.NAME_C,A.NAME_E,A.BIRDT,C.NOBR,C.EDUCCODE,H.NAME AS EDUDESC,C.ADATE,C.SCHL," +
                        "C.SUBJ,C.DATE_B,C.DATE_E,D.D_NAME,'' AS COMPANY,'' AS TITLE,'' AS JOBW,DATEDIFF(DAY,B.INDT,'" + date_b + "') AS WK_YRS1," +
                        "C.DATE_B,C.DATE_E,C.OK,B.DI,B.EMPCD,B.TTSCODE,B.JOBL,B.JOBS,B.OUDT,B.STDT,B.WK_YRS AS WKYRS, F.SUBDESC AS SUBJ_DETAIL, C.SUBJ_DETAIL AS SUBJ_DETAIL_BAK, B.DI, D.DEPT_TREE," +
                        "DATEDIFF(DAY,A.BIRDT,'" + date_b + "')/365.24 AS AGE"+
                        " FROM BASETTS B,DEPT D,EDUCODE G,BASE A " +
                        " LEFT OUTER JOIN SCHL C ON A.NOBR=C.NOBR" +
                        " LEFT OUTER JOIN SUBCODE F ON C.SUBJ = F.SUBCODE" +
                        " LEFT OUTER JOIN EDUCODE H ON C.EDUCCODE = H.CODE" +                       
                        " WHERE A.NOBR=B.NOBR" +
                        " " + data_report + "" +                       
                        " AND B.DEPT=D.D_NO" +
                        " AND G.CODE=C.EDUCCODE" +
                        " AND '" + date_b + "' BETWEEN B.ADATE AND B.DDATE" +
                        " AND D.D_NO_DISP BETWEEN '" + dept_b + "' AND '" + dept_e + "'" +
                        " AND A.NOBR BETWEEN '" + nobr_b + "' AND '" + nobr_e + "'" +
                        " AND B.EMPCD BETWEEN '" + emp_b + "' AND '" + emp_e + "'" +
                        " AND B.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +
                        " AND B.TTSCODE IN ('1','4','6') "+
                        " " + only_schl + "" +
                        " ORDER BY D.D_NO_DISP,B.NOBR";
                    DataTable rq_zz1cs1 = SqlConn.GetDataTable(sqlCmd1);
                    if (rq_zz1cs1.Rows.Count < 1)
                    {
                        MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                        this.Close();
                        return;
                    }
                    foreach (DataRow Row in rq_zz1cs1.Rows)
                    {
                        //if (Row.IsNull("date_b") || Row["date_b"].ToString().Trim()=="")
                        //    Row["date_b"] = DateTime.Parse("1911/01/01");
                        //if (Row.IsNull("date_e") || Row["date_e"].ToString().Trim() == "")
                        //    Row["date_e"] = DateTime.Parse("1911/01/01");

                        if (string.IsNullOrEmpty(Row["SUBJ_DETAIL"].ToString()))
                        {
                            Row["SUBJ_DETAIL"] = Row["SUBJ_DETAIL_BAK"].ToString();
                        }

                        ds.Tables["rq_zz1cs1"].ImportRow(Row);
                    }
                    rq_zz1cs1 = null;

                   

                    foreach (DataRow Row in ds.Tables["rq_zz1cs1"].Rows)
                    {

                        DataRow row1 = rq_job.Rows.Find(Row["job"].ToString());
                        if (row1 != null)
                        {
                            Row["job"] = row1["job_disp"].ToString();
                            Row["job_name"] = row1["job_name"].ToString();
                        }

                        DataRow row2 = rq_jobl.Rows.Find(Row["jobl"].ToString());
                        if (row2 != null)
                        {
                            Row["jobl"] = row2["jobl_disp"].ToString();
                        }

                        //DataRow row3 = rq_jobs.Rows.Find(Row["jobs"].ToString());
                        //if (row3 != null)
                        //{
                        //    Row["jobs"] = row3["jobs_disp"].ToString();
                        //}

                        //DataRow row2 = rq_schlcode.Rows.Find(Row["schlcode"].ToString());
                        //if (row2 != null)
                        //    Row["schlay"] = row2["schlay"].ToString();

                        //DataRow[] row6 = rq_basetts.Select("nobr='" + Row["nobr"].ToString() + "'");
                        //for (int j = 0; j < row6.Length; j++)
                        //{

                        //    DateTime str_stdt = DateTime.Parse(row6[j]["stdt"].ToString());
                        //    DateTime str_stindt = DateTime.Parse(row6[j]["stindt"].ToString());
                        //    decimal str_st = 0;
                        //    string str_ttscode = row6[j]["ttscode"].ToString().Trim();
                        //    if (str_ttscode == "3")
                        //    {
                        //        str_st = ((TimeSpan)(DateTime.Parse(date_t) - str_stdt)).Days + 1;
                        //        Row["wk_yrs1"] = decimal.Parse(Row["wk_yrs1"].ToString()) + 1 - str_st;
                        //    }
                        //    else
                        //    {
                        //        str_st = ((TimeSpan)(DateTime.Parse(date_t) - str_stindt)).Days + 1;
                        //        Row["wk_yrs1"] = decimal.Parse(Row["wk_yrs1"].ToString()) + 1 + str_st;
                        //    }
                        //}
                        DataRow row6 = rq_basetts.Rows.Find(Row["nobr"].ToString());
                        if (row6 != null) Row["wk_yrs1"] = decimal.Parse(Row["wk_yrs1"].ToString()) - int.Parse(row6["days"].ToString()) + 1;
                        Row["wk_yrs"] = decimal.Round(decimal.Parse(Row["wk_yrs1"].ToString()) / Convert.ToDecimal(365.24), 2);
                        DataRow row5 = rq_depttree.Rows.Find(Row["dept_tree"].ToString());
                        Row["dept_tree"] = (row5 != null) ? row5["d_no_disp"].ToString().Trim() + " " + row5["d_name"].ToString() : "";
                        Row["age"] = decimal.Round(decimal.Parse(Row["age"].ToString()), 2);
                    }
                    rq_basetts = null;
                }
                else if (report_type == "2")
                {
                    string sqlCmd3 = "SELECT D.D_NO_DISP AS DEPT,E.JOB_DISP AS JOB,E.JOB_NAME,B.INDT,A.NAME_C,A.NAME_E,A.BIRDT," +
                        "C.NOBR,C.EDUCCODE,G.NAME AS EDUDESC,C.ADATE,C.SCHL,C.SUBJ,C.DATE_B,C.DATE_E,D.D_NAME,'' AS COMPANY," +
                        "'' AS TITLE,'' AS JOBW,DATEDIFF(DAY,B.INDT,'" + date_b + "') AS WK_YRS1,C.DATE_B,C.DATE_E,C.OK, H.SUBDESC AS SUBJ_DETAIL, C.SUBJ_DETAIL AS SUBJ_DETAIL_BAK, B.DI,B.EMPCD," +
                        "B.TTSCODE,B.JOBL,B.JOBS,B.OUDT,B.STDT,B.WK_YRS AS WKYRS,B.DI,D.DEPT_TREE," +
                        "DATEDIFF(DAY,A.BIRDT,'" + date_b + "')/365.24 AS AGE" +
                        " FROM BASE A,DEPT D,JOB E,BASETTS B " +
                        " LEFT OUTER JOIN SCHL C ON B.NOBR=C.NOBR" +
                        " LEFT OUTER JOIN SUBCODE H ON C.SUBJ = H.SUBCODE" +
                        " LEFT OUTER JOIN EDUCODE G ON C.EDUCCODE=G.CODE" +
                        " LEFT OUTER JOIN JOBS F ON B.JOBS=F.JOBS" +
                        " WHERE A.NOBR=B.NOBR" +
                        " " + data_report + "" +
                        //" " + in_out + "" +
                        " AND B.DEPT=D.D_NO" +
                        " AND B.JOB=E.JOB" +
                        " AND '" + date_b + "' BETWEEN B.ADATE AND B.DDATE" +
                        " AND D.D_NO_DISP BETWEEN '" + dept_b + "' AND '" + dept_e + "'" +
                        " AND A.NOBR BETWEEN '" + nobr_b + "' AND '" + nobr_e + "'" +
                        " AND B.EMPCD BETWEEN '" + emp_b + "' AND '" + emp_e + "'" +
                        " AND B.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +
                        " AND B.TTSCODE IN ('1','4','6') " +
                        " " + only_schl + "" +
                        " ORDER BY D.D_NO_DISP,B.NOBR";
                    DataTable rq_zz1cs4 = SqlConn.GetDataTable(sqlCmd3);

                    if (rq_zz1cs4.Rows.Count < 1)
                    {
                        MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                        this.Close();
                        return;
                    }

                    string sqlCmd5 = "SELECT C.NOBR,COUNT(C.NOBR) AS _NO" +
                        " FROM BASE A,DEPT D,EDUCODE G,BASETTS B " +
                        " LEFT OUTER JOIN SCHL C ON B.NOBR=C.NOBR" +
                        " LEFT OUTER JOIN JOB E ON B.JOB=E.JOB" +
                        " WHERE A.NOBR=B.NOBR" +
                        " " + data_report + "" +
                        //" " + in_out + "" +
                        " AND B.DEPT=D.D_NO" +
                        " AND G.CODE=C.EDUCCODE" +
                        " AND '" + date_b + "' BETWEEN B.ADATE AND B.DDATE" +
                        " AND D.D_NO_DISP BETWEEN '" + dept_b + "' AND '" + dept_e + "'" +
                        " AND A.NOBR BETWEEN '" + nobr_b + "' AND '" + nobr_e + "'" +
                        " AND B.EMPCD BETWEEN '" + emp_b + "' AND '" + emp_e + "'" +
                        " AND B.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +
                        " AND B.TTSCODE IN ('1','4','6') " +
                        " " + only_schl + "" +
                        " GROUP BY C.NOBR" +
                        " ORDER BY C.NOBR";
                    DataTable rq_nobr = SqlConn.GetDataTable(sqlCmd5);

                    string sqlCmd4 = "SELECT C.NOBR,A.NAME_C,A.NAME_E,A.BIRDT,C.COMPANY,C.TITLE,C.BDATE,C.EDATE,E.JOB_DISP AS JOB," +
                        "E.JOB_NAME,D.D_NO_DISP AS DEPT,D.D_NAME,B.INDT,D.DEPT_TREE" +
                        " FROM WORKS C ,BASE A,BASETTS B" +
                        " LEFT OUTER JOIN DEPT D ON B.DEPT=D.D_NO"+
                        " LEFT OUTER JOIN JOB E ON B.JOB=E.JOB"+
                        " WHERE C.NOBR=B.NOBR" +
                        " AND A.NOBR = B.NOBR " +                        
                        " " + data_report + "" +
                        //" " + in_out + "" +
                        " AND '" + date_b + "' BETWEEN B.ADATE AND B.DDATE" +
                        " AND D.D_NO_DISP BETWEEN '" + dept_b + "' AND '" + dept_e + "'" +
                        " AND B.EMPCD BETWEEN '" + emp_b + "' AND '" + emp_e + "'" +
                        " AND B.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +
                        " AND B.TTSCODE IN ('1','4','6') " +
                        " AND C.COMPANY!=''" +
                        " ORDER BY D.D_NO_DISP,C.NOBR";
                    DataTable rq_zz1cs3 = SqlConn.GetDataTable(sqlCmd4);

                    for (int i = 0; i < rq_nobr.Rows.Count; i++)
                    {
                        DataRow[] row1 = rq_zz1cs4.Select("nobr='" + rq_nobr.Rows[i]["nobr"].ToString() + "'");
                        DataRow[] row2 = rq_zz1cs3.Select("nobr='" + rq_nobr.Rows[i]["nobr"].ToString() + "'");
                       
                        if (row1.Length > row2.Length)
                        {
                            for (int j = 0; j < row1.Length; j++)
                            {
                                DataRow aRow2 = ds.Tables["rq_zz1cs1"].NewRow();
                                //DataRow row_subj = rq_subj.Rows.Find(row1[j]["subj"].ToString());

                                aRow2["nobr"] = row1[j]["nobr"].ToString();
                                aRow2["name_c"] = row1[j]["name_c"].ToString();
                                aRow2["name_e"] = row1[j]["name_e"].ToString();
                                aRow2["dept"] = row1[j]["dept"].ToString();
                                aRow2["d_name"] = row1[j]["d_name"].ToString();
                                aRow2["job"] = row1[j]["job"].ToString();
                                aRow2["job_name"] = row1[j]["job_name"].ToString();
                                aRow2["educcode"] = row1[j]["educcode"].ToString();
                                aRow2["edudesc"] = row1[j]["edudesc"].ToString();                                
                                aRow2["wkyrs"] = decimal.Parse(row1[j]["wkyrs"].ToString());
                                aRow2["age"] = decimal.Round(decimal.Parse(row1[j]["age"].ToString()), 2);
                                //DataRow row5 = rq_schlcode.Rows.Find(row1[j]["schlcode"].ToString());
                                //if (row5 != null)
                                //    aRow2["schlay"] = row5["schlay"].ToString();
                                aRow2["schl"] = row1[j]["schl"].ToString();

                                if (string.IsNullOrEmpty(row1[j]["SUBJ_DETAIL"].ToString()))
                                {
                                    aRow2["subj_detail"] = row1[j]["SUBJ_DETAIL_BAK"].ToString();
                                }
                                else
                                {
                                    aRow2["subj_detail"] = row1[j]["SUBJ_DETAIL"].ToString();
                                }
                                aRow2["subj"] = row1[j]["subj"].ToString();
                                aRow2["indt"] = DateTime.Parse(row1[j]["indt"].ToString());
                                aRow2["birdt"] = DateTime.Parse(row1[j]["birdt"].ToString());
                                aRow2["age"] = decimal.Parse(row1[j]["age"].ToString());
                                aRow2["date_b"] = row1[j]["date_b"].ToString();
                                aRow2["date_e"] = row1[j]["date_e"].ToString();
                                aRow2["jobl"] = row1[j]["jobl"].ToString();
                                aRow2["jobs"] = row1[j]["jobs"].ToString();
                                if (!row1[j].IsNull("oudt")) aRow2["oudt"] =  DateTime.Parse(row1[j]["oudt"].ToString());
                                if (!row1[j].IsNull("stdt")) aRow2["stdt"] = DateTime.Parse(row1[j]["stdt"].ToString());
                                if (row2.Length > j)
                                {
                                    aRow2["company"] = row2[j]["company"].ToString();
                                    aRow2["title"] = row2[j]["title"].ToString();
                                    aRow2["jobw"] = row2[j]["job"].ToString();
                                    aRow2["bdate"] = DateTime.Parse(row2[j]["bdate"].ToString());
                                    aRow2["edate"] = DateTime.Parse(row2[j]["edate"].ToString());

                                }
                                aRow2["wk_yrs1"] = decimal.Parse(row1[j]["wk_yrs1"].ToString());
                                aRow2["ok"] = row1[j]["ok"].ToString();
                                aRow2["di"] = row1[j]["di"].ToString();
                                aRow2["empcd"] = row1[j]["empcd"].ToString();
                                aRow2["ttscode"] = row1[j]["ttscode"].ToString();
                                DataRow row5 = rq_depttree.Rows.Find(row1[j]["dept_tree"].ToString());
                                aRow2["dept_tree"] = (row5 != null) ? row5["d_no_disp"].ToString().Trim() + " " + row5["d_name"].ToString() : "";
                                    
                                ds.Tables["rq_zz1cs1"].Rows.Add(aRow2);
                            }
                        }
                        else
                        {
                            for (int j = 0; j < row2.Length; j++)
                            {
                                DataRow aRow = ds.Tables["rq_zz1cs1"].NewRow();
                                //DataRow row_subj = rq_subj.Rows.Find(row1[j]["subj"].ToString());

                                aRow["nobr"] = row2[j]["nobr"].ToString();
                                aRow["name_c"] = row2[j]["name_c"].ToString();
                                aRow["name_e"] = row2[j]["name_e"].ToString();
                                aRow["dept"] = row2[j]["dept"].ToString();
                                aRow["d_name"] = row2[j]["d_name"].ToString();
                                aRow["job"] = row2[j]["job"].ToString();
                                aRow["job_name"] = row2[j]["job_name"].ToString();
                                aRow["indt"] = DateTime.Parse(row2[j]["indt"].ToString());
                                aRow["birdt"] = DateTime.Parse(row2[j]["birdt"].ToString());                                
                                DataRow row5 = rq_depttree.Rows.Find(row2[j]["dept_tree"].ToString());
                                aRow["dept_tree"] = (row5 != null) ? row5["d_no_disp"].ToString().Trim() + " " + row5["d_name"].ToString() : "";
                                if (row1.Length > j)
                                {
                                    aRow["wkyrs"] = decimal.Parse(row1[j]["wkyrs"].ToString());
                                    aRow["educcode"] = row1[j]["educcode"].ToString();
                                    aRow["edudesc"] = row1[j]["edudesc"].ToString();
                                    aRow["schl"] = row1[j]["schl"].ToString();

                                    if (string.IsNullOrEmpty(row1[j]["SUBJ_DETAIL"].ToString()))
                                    {
                                        aRow["subj_detail"] = row1[j]["SUBJ_DETAIL_BAK"].ToString();
                                    }
                                    else
                                    {
                                        aRow["subj_detail"] = row1[j]["SUBJ_DETAIL"].ToString();
                                    }

                                    aRow["subj"] = row1[j]["subj"].ToString();
                                    aRow["wk_yrs1"] = decimal.Parse(row1[j]["wk_yrs1"].ToString());
                                    aRow["age"] = decimal.Round(decimal.Parse(row1[j]["age"].ToString()), 2);
                                    aRow["date_b"] = row1[j]["date_b"].ToString();
                                    aRow["date_e"] = row1[j]["date_e"].ToString();
                                    //DataRow row4 = rq_schlcode.Rows.Find(row1[j]["schlcode"].ToString());
                                    //if (row4 != null)
                                    //    aRow["schlay"] = row4["schlay"].ToString();
                                    aRow["ok"] = row1[j]["ok"].ToString();
                                    aRow["di"] = row1[j]["di"].ToString();
                                    aRow["empcd"] = row1[j]["empcd"].ToString();
                                    aRow["ttscode"] = row1[j]["ttscode"].ToString();
                                    aRow["jobl"] = row1[j]["jobl"].ToString();
                                    aRow["jobs"] = row1[j]["jobs"].ToString();

                                    if (!row1[j].IsNull("oudt")) aRow["oudt"] = DateTime.Parse(row1[j]["oudt"].ToString());
                                    if (!row1[j].IsNull("stdt")) aRow["stdt"] = DateTime.Parse(row1[j]["stdt"].ToString());
                                }
                                aRow["company"] = row2[j]["company"].ToString();
                                aRow["title"] = row2[j]["title"].ToString();
                                aRow["jobw"] = row2[j]["job"].ToString();
                                aRow["bdate"] = DateTime.Parse(row2[j]["bdate"].ToString());
                                aRow["edate"] = DateTime.Parse(row2[j]["edate"].ToString());
                                ds.Tables["rq_zz1cs1"].Rows.Add(aRow);
                            }

                        }
                    }
                    rq_zz1cs3 = null;
                    rq_zz1cs4 = null;
                    rq_nobr = null;                    

                    //string sqlCmd21 = "SELECT B.NOBR,B.INDT,B.STDT,B.STINDT,B.TTSCODE " +
                    //            " FROM BASETTS B,BASE A" +
                    //            " WHERE A.NOBR=B.NOBR" +
                    //            " AND B.DEPT BETWEEN '" + dept_b + "' AND '" + dept_e + "'" +
                    //            " AND B.EMPCD BETWEEN '" + emp_b + "' AND '" + emp_e + "'" +
                    //            " AND B.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +
                    //            " " + data_report + "" +
                    //            " AND B.TTSCODE in('3','4')";
                    //SqlDataAdapter SqlCmd21 = new SqlDataAdapter(sqlCmd21, PPT_ReportForm.DataClass.GetConn());
                    //SqlCmd21.Fill(rq_basetts);


                    foreach (DataRow Row in ds.Tables["rq_zz1cs1"].Rows)
                    {
                        DataRow row1 = rq_job.Rows.Find(Row["job"].ToString());
                        if (row1 != null)
                        {
                            Row["job"] = row1["job_disp"].ToString();
                            Row["job_name"] = row1["job_name"].ToString();
                        }

                        DataRow row2 = rq_jobl.Rows.Find(Row["jobl"].ToString());
                        if (row2 != null)
                        {
                            Row["jobl"] = row2["jobl_disp"].ToString();
                        }

                        //DataRow row2 = rq_schlcode.Rows.Find(Row["schlcode"].ToString());
                        //if (row2 != null)
                        //    Row["schlay"] = row2["schlay"].ToString();

                        if (Row["wk_yrs1"].ToString() != "")
                        {
                            //DataRow[] row6 = rq_basetts.Select("nobr='" + Row["nobr"].ToString() + "'");
                            //for (int j = 0; j < row6.Length; j++)
                            //{
                            //    DateTime str_stdt = DateTime.Parse(row6[j]["stdt"].ToString());
                            //    DateTime str_stindt = DateTime.Parse(row6[j]["stindt"].ToString());
                            //    decimal str_st = 0;
                            //    string str_ttscode = row6[j]["ttscode"].ToString().Trim();
                            //    if (str_ttscode == "3")
                            //    {
                            //        str_st = ((TimeSpan)(DateTime.Parse(date_t) - str_stdt)).Days + 1;
                            //        Row["wk_yrs1"] = decimal.Parse(Row["wk_yrs1"].ToString()) + 1 - str_st;
                            //    }
                            //    else
                            //    {
                            //        str_st = ((TimeSpan)(DateTime.Parse(date_t) - str_stindt)).Days + 1;
                            //        Row["wk_yrs1"] = decimal.Parse(Row["wk_yrs1"].ToString()) + 1 + str_st;
                            //    }
                            //}
                            DataRow row6 = rq_basetts.Rows.Find(Row["nobr"].ToString());
                            if (row6 != null) Row["wk_yrs1"] = decimal.Parse(Row["wk_yrs1"].ToString()) - int.Parse(row6["days"].ToString()) + 1;
                            Row["wk_yrs"] = decimal.Round(decimal.Parse(Row["wk_yrs1"].ToString()) / Convert.ToDecimal(365.24), 2);
                        }
                    }
                    rq_basetts = null;
                    //rq_schlcode = null;
                }
                rq_job = null; rq_jobl = null; rq_depttree = null;

                if (exportexcel)
                {
                    Export(ds.Tables["rq_zz1cs1"],rq_subj);
                    rq_subj = null;
                    this.Close();
                }
                else
                {
                    rq_subj = null;
                    RptViewer.Visible = true;
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "EmpReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "EmpReport", "*.rdlc");
                    
                    if (report_type == "1")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz1C.rdlc";
                    else
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz1Ca.rdlc";
                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("empdata_rq_zz1cs1", ds.Tables["rq_zz1cs1"]));
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

        void Export(DataTable DT,DataTable DT1)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("報表分析群組", typeof(string));
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            ExporDt.Columns.Add("職稱代碼", typeof(string));
            ExporDt.Columns.Add("職稱", typeof(string));
            ExporDt.Columns.Add("到職日期", typeof(DateTime));
            ExporDt.Columns.Add("年資", typeof(decimal));            
            ExporDt.Columns.Add("教育程度", typeof(string));
            ExporDt.Columns.Add("學校", typeof(string));
            ExporDt.Columns.Add("科系代碼", typeof(string));            
            ExporDt.Columns.Add("科系", typeof(string));
            ExporDt.Columns.Add("年齡", typeof(decimal));
            ExporDt.Columns.Add("直間接", typeof(string));
            if (report_type == "2")
            {
                ExporDt.Columns.Add("公司", typeof(string));
                ExporDt.Columns.Add("經歷職稱", typeof(string));
                ExporDt.Columns.Add("起日", typeof(DateTime));
                ExporDt.Columns.Add("迄日", typeof(DateTime));
            }
            string _nobr1 = "";
            string _nobr2 = "";
            decimal _wkyrs2 = 0;
            decimal _age = 0;
            foreach (DataRow Row in DT.Rows)
            {
                _nobr1 = Row["nobr"].ToString();
                DataRow aRow = ExporDt.NewRow();
                aRow["報表分析群組"] = Row["dept_tree"].ToString();
                aRow["部門代碼"] = Row["dept"].ToString();
                aRow["部門名稱"] = Row["d_name"].ToString();
                aRow["員工編號"] = Row["nobr"].ToString();
                aRow["員工姓名"] = Row["name_c"].ToString();
                aRow["英文姓名"] = Row["name_e"].ToString();
                aRow["職稱代碼"] = Row["job"].ToString();
                aRow["職稱"] = Row["job_name"].ToString();
                aRow["到職日期"] = DateTime.Parse(Row["indt"].ToString());
                aRow["直間接"] = Row["di"].ToString();
                if (_nobr1 == _nobr2)
                {

                    aRow["年資"] = _wkyrs2;
                    aRow["年齡"] = _age;
                }
                else
                {
                    if (!Row.IsNull("wk_yrs"))
                        aRow["年資"] = decimal.Parse(Row["wk_yrs"].ToString());
                    else
                        aRow["年資"] = _wkyrs2;

                    if (!Row.IsNull("age"))
                        aRow["年齡"] = decimal.Parse(Row["age"].ToString());
                    else
                        aRow["年齡"] = _age;
                }
                _wkyrs2 = decimal.Parse(aRow["年資"].ToString());
                _age = decimal.Parse(aRow["年齡"].ToString());

                if (!Row.IsNull("edudesc"))
                    aRow["教育程度"] = Row["edudesc"].ToString();
                if (!Row.IsNull("schl"))
                    aRow["學校"] = Row["schl"].ToString();
                
                if (!Row.IsNull("subj"))
                {
                    DataRow row2 = DT1.Rows.Find(Row["subj"].ToString());
                    if (row2 != null)
                        Row["SUBJ_DETAIL"] = row2["subdesc"].ToString();
                    aRow["科系代碼"] = Row["subj"].ToString();                    
                }
                aRow["科系"] = Row["subj_detail"].ToString();
               
                //if (!Row.IsNull("birdt"))
                //{
                //    aRow["年齡"] = (((TimeSpan)(DateTime.Now - DateTime.Parse(Row["birdt"].ToString()))).Days) / 365.24;
                //    aRow["年齡"] = decimal.Round(decimal.Parse(aRow["年齡"].ToString()), 2);
                //}
                if (report_type == "2")
                {
                    if (!Row.IsNull("company"))
                        aRow["公司"] = Row["company"].ToString();
                    if (!Row.IsNull("title"))
                        aRow["經歷職稱"] = Row["title"].ToString();
                    if (!Row.IsNull("bdate"))
                        aRow["起日"] = DateTime.Parse(Row["bdate"].ToString());
                    if (!Row.IsNull("edate"))
                        aRow["迄日"] = DateTime.Parse(Row["edate"].ToString());
                }
                _nobr2 = _nobr1;

                ExporDt.Rows.Add(aRow);
            }

            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }  
    }
}
