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
    public partial class ZZ152_Report : JBControls.JBForm
    {
        empdata ds = new empdata();
        string date_b, date_e, dept_b, dept_e, emp_b, emp_e, comp_b, comp_e, out_code, type_data, type_data1, username, comp_name;
        decimal outday;
        bool exportexcel;

        public ZZ152_Report(string dateb, string datee, string deptb, string depte, string empb, string empe, string compb, string compe, string _outcode, decimal _outday, bool _exportexcel, string typedata, string typedata1, string _username, string compname)
        {
            InitializeComponent();
            date_b = dateb; date_e = datee; dept_b = deptb; dept_e = depte; emp_b = empb;
            emp_e = empe; comp_b = compb; comp_e = compe; username = _username;
            outday = _outday; exportexcel = _exportexcel; type_data = typedata; out_code = _outcode;
            comp_name = compname; type_data1 = typedata1;
        }

        private void ZZ152_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select job_disp,job as dept,job_name as d_name,0000000 as tin_cnt,0000000 as tout_cnt,00000000 as count1," +
                    "0000000 as in_cnt,0000000 as new_cnt,0000000 as out_cnt,0000000 as out_cnt1,0000000 as out_cnt2," +
                    "0000000 as out_cnt3,0000000 as stin_cnt,0000000 as stdt_cnt,0000000 as stut_cnt,0000000 as stout_cnt," +
                    "0000000 as injob_cnt" +
                    " from job order by job_disp ";
                DataTable rq_zz15s1a = SqlConn.GetDataTable(sqlCmd);
                rq_zz15s1a.PrimaryKey = new DataColumn[] { rq_zz15s1a.Columns["dept"] };

                string sqlCmd1 = "SELECT A.JOB AS DEPT,COUNT(A.NOBR) AS IN_CNT,SPACE(30) AS D_NAME " +
                    " FROM BASE B,BASETTS A" +
                    " LEFT OUTER JOIN DEPT C ON A.DEPT=C.D_NO" +
                    " WHERE DATEADD(DAY,-1,'" + date_b + "') BETWEEN A.ADATE AND A.DDATE" +
                    " AND A.EMPCD BETWEEN '" + emp_b + "' AND '" + emp_e + "'" +
                    " AND C.d_no_disp BETWEEN '" + dept_b + "' AND '" + dept_e + "'" +
                    " AND A.NOBR = B.NOBR " +
                    " AND A.TTSCODE IN ('1','6','4')" +
                    " AND NOT EXISTS (SELECT T.NOBR FROM BASETTS T WHERE A.NOBR=T.NOBR  AND T.OUDT=DATEADD(DAY,-1,'" + date_b + "') )" +
                    " " + type_data + "" +
                    " AND A.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +
                    " GROUP BY A.JOB";
                DataTable rq_zz15s2 = SqlConn.GetDataTable(sqlCmd1);
                rq_zz15s2.PrimaryKey = new DataColumn[] { rq_zz15s2.Columns["dept"] };

                //期未人數
                string sqlCmd1a = "SELECT A.JOB AS DEPT,COUNT(A.NOBR) AS IN_CNT" +
                    " FROM BASE B,BASETTS A" +
                    " LEFT OUTER JOIN DEPT C ON A.DEPT=C.D_NO" +
                    " WHERE '" + date_e + "' BETWEEN A.ADATE AND A.DDATE" +
                    " AND A.EMPCD BETWEEN '" + emp_b + "' AND '" + emp_e + "'" +
                    " AND C.d_no_disp BETWEEN '" + dept_b + "' AND '" + dept_e + "'" +
                    " AND A.NOBR = B.NOBR " +
                    " AND A.TTSCODE IN ('1','4','6')" +
                    " AND A.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +
                    " AND NOT EXISTS (SELECT T.NOBR FROM BASETTS T WHERE A.NOBR=T.NOBR  AND T.OUDT='" + date_e + "' )" +
                    " " + type_data + "" +
                    " GROUP BY A.JOB";
                DataTable rq_zz15s2a = SqlConn.GetDataTable(sqlCmd1a);
                for (int i = 0; i < rq_zz15s2a.Rows.Count; i++)
                {
                    DataRow row = rq_zz15s1a.Rows.Find(rq_zz15s2a.Rows[i]["dept"]);
                    if (row == null)
                    {
                        DataRow aRow1 = rq_zz15s1a.NewRow();
                        aRow1["dept"] = rq_zz15s2a.Rows[i]["dept"].ToString();                        
                        aRow1["d_name"] = "";
                        aRow1["in_cnt"] = 0;
                        aRow1["tout_cnt"] = 0;
                        aRow1["tin_cnt"] = 0;
                        aRow1["count1"] = 1;
                        aRow1["new_cnt"] = 0;
                        aRow1["out_cnt"] = 0;
                        aRow1["out_cnt1"] = 0;
                        aRow1["out_cnt2"] = 0;
                        aRow1["out_cnt3"] = 0;
                        aRow1["stin_cnt"] = 0;
                        aRow1["stdt_cnt"] = 0;
                        aRow1["stut_cnt"] = 0;
                        aRow1["stout_cnt"] = 0;
                        aRow1["injob_cnt"] = decimal.Parse(rq_zz15s2a.Rows[i]["in_cnt"].ToString());
                        rq_zz15s1a.Rows.Add(aRow1);
                    }
                    else
                    {
                        row["count1"] = 1;
                        row["injob_cnt"] = decimal.Parse(rq_zz15s2a.Rows[i]["in_cnt"].ToString());
                    }
                }

                //	調入調出
                string sqlCmd2 = "SELECT A.NOBR,A.JOB AS DEPT,A.TTSCODE,A.ADATE,A.DDATE" +
                    ",DATEADD(day,-1,A.ADATE) AS STR_ADATE " +
                    " FROM BASE B,BASETTS A" +
                    " LEFT OUTER JOIN DEPT C ON A.DEPT=C.D_NO" +
                    " WHERE '" + date_e + "' BETWEEN A.ADATE AND A.DDATE" +
                    " AND A.NOBR = B.NOBR " +
                    " " + type_data + "" +
                    " AND A.TTSCODE ='6'" +
                    " AND A.EMPCD BETWEEN '" + emp_b + "' AND '" + emp_e + "'" +
                    " AND C.d_no_disp BETWEEN '" + dept_b + "' AND '" + dept_e + "'" +
                    " AND A.ADATE BETWEEN '" + date_b + "'AND '" + date_e + "'" +
                    " AND A.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +
                    " ORDER BY 2";
                DataTable rq_zz15s3 = SqlConn.GetDataTable(sqlCmd2);

                foreach (DataRow row in rq_zz15s3.Rows)
                {
                    //string str_adate = Convert.ToString(DateTime.Parse(row["adate"].ToString()).AddDays(-1).ToShortDateString());
                    string str_adate = DateTime.Parse(row["str_adate"].ToString()).ToShortDateString();
                    string str_dept = row["dept"].ToString();
                    string str_nobr = row["nobr"].ToString();
                    string sqlCmd3 = "SELECT A.NOBR,A.JOB AS DEPT,A.TTSCODE,A.ADATE,A.DDATE " +
                        " FROM BASE B,BASETTS A" +
                        " LEFT OUTER JOIN DEPT C ON A.DEPT=C.D_NO" +
                        " WHERE '" + str_adate + "' BETWEEN A.ADATE AND A.DDATE" +
                        " AND A.NOBR = B.NOBR" +
                        " AND A.EMPCD BETWEEN '" + emp_b + "' AND '" + emp_e + "'" +
                        //" AND C.d_no_disp BETWEEN '" + dept_b + "' AND '" + dept_e + "'" +
                        " " + type_data1 + "" +
                        " AND A.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +
                        " AND A.NOBR = '" + str_nobr + "'";
                    DataTable rq_zz15z = SqlConn.GetDataTable(sqlCmd3);

                    decimal count = Convert.ToDecimal(rq_zz15z.Rows.Count.ToString());
                    string str_dept1 = "";
                    if (count > 0)
                        str_dept1 = rq_zz15z.Rows[0]["dept"].ToString();
                    rq_zz15z = null;

                    if (str_dept != str_dept1)
                    {
                        DataRow row71 = rq_zz15s1a.Rows.Find(str_dept);
                        if (row71 != null)
                            row71["tin_cnt"] = decimal.Parse(row71["tin_cnt"].ToString()) + 1;

                        DataRow row72 = rq_zz15s1a.Rows.Find(str_dept1);
                        if (row72 != null)
                            row72["tout_cnt"] = decimal.Parse(row72["tout_cnt"].ToString()) + 1;
                    }
                }                

                //新進
                string sqlCmd4 = "SELECT A.JOB AS DEPT,COUNT(A.NOBR) AS NEW_CNT " +
                    " FROM BASE B,BASETTS A" +
                    " LEFT OUTER JOIN DEPT C ON A.DEPT=C.D_NO" +
                    " WHERE A.TTSCODE ='1'" +
                    " AND A.ADATE BETWEEN '" + date_b + "' AND '" + date_e + "'" +
                    " AND A.EMPCD BETWEEN '" + emp_b + "' AND '" + emp_e + "'" +
                    " AND C.d_no_disp BETWEEN '" + dept_b + "' AND '" + dept_e + "'" +
                    " AND A.NOBR = B.NOBR " +
                    " " + type_data + "" +
                    " AND A.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +
                    " GROUP BY A.JOB";
                DataTable rq_zz15s4 = SqlConn.GetDataTable(sqlCmd4);
                rq_zz15s4.PrimaryKey = new DataColumn[] { rq_zz15s4.Columns["dept"] };

                //離職&& 進廠小於30天
                string sqlCmd5 = "SELECT A.JOB AS DEPT,COUNT(A.NOBR) AS OUT_CNT " +
                    " FROM BASE B,BASETTS A" +
                    " LEFT OUTER JOIN DEPT C ON A.DEPT=C.D_NO" +
                    " WHERE A.TTSCODE ='2'" +
                    //" AND A.ADATE BETWEEN '" + date_b + "' AND '" + date_e + "'" +
                    " AND A.OUDT BETWEEN '" + date_b + "' AND '" + date_e + "'" +
                    " AND A.EMPCD BETWEEN '" + emp_b + "' AND '" + emp_e + "'" +
                    " AND C.d_no_disp BETWEEN '" + dept_b + "' AND '" + dept_e + "'" +
                    " AND A.OUDT -A.INDT <  " + outday + "" +
                    " AND A.NOBR = B.NOBR " +
                    " " + type_data + "" +
                    " AND A.OUTCD <> '" + out_code + "' " +
                    " AND A.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +
                    " GROUP BY A.JOB";
                DataTable rq_zz15s5 = SqlConn.GetDataTable(sqlCmd5);
                rq_zz15s5.PrimaryKey = new DataColumn[] { rq_zz15s5.Columns["dept"] };

                //離職&& 進廠大於等於30天
                string sqlCmd6 = "SELECT A.JOB AS DEPT,COUNT(A.NOBR) AS OUT_CNT " +
                    " FROM BASE B,BASETTS A" +
                    " LEFT OUTER JOIN DEPT C ON A.DEPT=C.D_NO" +
                    " WHERE A.TTSCODE ='2'" +
                    " AND A.EMPCD BETWEEN '" + emp_b + "' AND '" + emp_e + "'" +
                    " AND C.d_no_disp BETWEEN '" + dept_b + "' AND '" + dept_e + "'" +
                    " AND A.NOBR = B.NOBR " +
                    " " + type_data + "" +
                    //" AND A.ADATE BETWEEN '" + date_b + "' AND '" + date_e + "'" +
                    " AND A.OUDT BETWEEN '" + date_b + "' AND '" + date_e + "'" +
                    " AND A.OUDT - A.INDT >= " + outday + "" +
                    " AND A.OUTCD <> '" + out_code + "' " +
                    " AND A.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +
                    " GROUP BY A.JOB";
                DataTable rq_zz15s6 = SqlConn.GetDataTable(sqlCmd6);
                rq_zz15s6.PrimaryKey = new DataColumn[] { rq_zz15s6.Columns["dept"] };

                //除名&& 進廠大於等於30天
                string sqlCmd7 = "SELECT A.JOB AS DEPT,COUNT(A.NOBR) AS OUT_CNT " +
                    " FROM BASE B,BASETTS A" +
                    " LEFT OUTER JOIN DEPT C ON A.DEPT=C.D_NO" +
                    " WHERE A.TTSCODE ='2'" +
                    //" AND A.ADATE BETWEEN '" + date_b + "' AND '" + date_e + "'" +
                    " AND A.OUDT BETWEEN '" + date_b + "' AND '" + date_e + "'" +
                    " AND A.EMPCD BETWEEN '" + emp_b + "' AND '" + emp_e + "'" +
                    " AND C.d_no_disp BETWEEN '" + dept_b + "' AND '" + dept_e + "'" +
                    " AND A.NOBR = B.NOBR " +
                    " " + type_data + "" +
                    " AND A.OUDT - A.INDT >= " + outday + "" +
                    " AND A.OUTCD = '" + out_code + "' " +
                    " AND A.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +
                    " GROUP BY A.JOB";
                DataTable rq_zz15s7 = SqlConn.GetDataTable(sqlCmd7);
                rq_zz15s7.PrimaryKey = new DataColumn[] { rq_zz15s7.Columns["dept"] };

                //除名&& 進廠小於30天
                string sqlCmd8 = "SELECT A.JOB AS DEPT,COUNT(A.NOBR) AS OUT_CNT " +
                    " FROM BASE B,BASETTS A" +
                    " LEFT OUTER JOIN DEPT C ON A.DEPT=C.D_NO" +
                    " WHERE A.TTSCODE ='2'" +
                    //" AND A.ADATE BETWEEN '" + date_b + "' AND '" + date_e + "'" +
                    " AND A.OUDT BETWEEN '" + date_b + "' AND '" + date_e + "'" +
                    " AND A.EMPCD BETWEEN '" + emp_b + "' AND '" + emp_e + "'" +
                    " AND C.d_no_disp BETWEEN '" + dept_b + "' AND '" + dept_e + "'" +
                    " AND A.OUDT - A.INDT < " + outday + "" +
                    " AND A.NOBR = B.NOBR " +
                    " " + type_data + "" +
                    " AND A.OUTCD = '" + out_code + "' " +
                    " AND A.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +
                    " GROUP BY A.JOB";
                DataTable rq_zz15s8 = SqlConn.GetDataTable(sqlCmd8);
                rq_zz15s8.PrimaryKey = new DataColumn[] { rq_zz15s8.Columns["dept"] };

                //復職
                string sqlCmd9 = "SELECT A.JOB AS DEPT,COUNT(A.NOBR) AS STIN_CNT " +
                    " FROM BASE B,BASETTS A" +
                    " LEFT OUTER JOIN DEPT C ON A.DEPT=C.D_NO" +
                    " WHERE A.TTSCODE ='4'" +
                    " AND A.ADATE BETWEEN '" + date_b + "' AND '" + date_e + "'" +
                    " AND A.EMPCD BETWEEN '" + emp_b + "' AND '" + emp_e + "'" +
                    " AND C.d_no_disp BETWEEN '" + dept_b + "' AND '" + dept_e + "'" +
                    " AND A.NOBR = B.NOBR" +
                    " " + type_data + "" +
                    " AND A.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +
                    " GROUP BY A.JOB";
                DataTable rq_zz15s9 = SqlConn.GetDataTable(sqlCmd9);
                rq_zz15s9.PrimaryKey = new DataColumn[] { rq_zz15s9.Columns["dept"] };

                //留職停薪
                string sqlCmd10 = "SELECT A.JOB AS DEPT,COUNT(A.NOBR) AS STDT_CNT " +
                    " FROM BASE B,BASETTS A" +
                    " LEFT OUTER JOIN DEPT C ON A.DEPT=C.D_NO" +
                    " WHERE A.TTSCODE ='3'" +
                    " AND A.STDT BETWEEN '" + date_b + "' AND '" + date_e + "'" +
                    " AND A.EMPCD BETWEEN '" + emp_b + "' AND '" + emp_e + "'" +
                    " AND C.d_no_disp BETWEEN '" + dept_b + "' AND '" + dept_e + "'" +
                    " AND A.NOBR = B.NOBR " +
                    " " + type_data + "" +
                    " AND A.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +
                    " GROUP BY A.JOB";
                DataTable rq_zz15s10 = SqlConn.GetDataTable(sqlCmd10);
                rq_zz15s10.PrimaryKey = new DataColumn[] { rq_zz15s10.Columns["dept"] };


                //停薪離職
                string sqlCmd11 = "SELECT A.JOB AS DEPT,COUNT(A.NOBR) AS STOUT_CNT " +
                    " FROM BASE B,BASETTS A" +
                    " LEFT OUTER JOIN DEPT C ON A.DEPT=C.D_NO" +
                    " WHERE A.TTSCODE ='5'" +
                    //" AND A.ADATE BETWEEN '" + date_b + "' AND '" + date_e + "'" +
                    " AND A.STOUDT BETWEEN '" + date_b + "' AND '" + date_e + "'" +
                    " AND A.EMPCD BETWEEN '" + emp_b + "' AND '" + emp_e + "'" +
                    " AND C.d_no_disp BETWEEN '" + dept_b + "' AND '" + dept_e + "'" +
                    " AND A.NOBR = B.NOBR " +
                    " " + type_data + "" +
                    " AND A.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +
                    " GROUP BY A.JOB";
                DataTable rq_zz15s11 = SqlConn.GetDataTable(sqlCmd11);
                rq_zz15s11.PrimaryKey = new DataColumn[] { rq_zz15s11.Columns["dept"] };

                foreach (DataRow rows1 in rq_zz15s1a.Rows)
                {
                    string str_dept = rows1["dept"].ToString();

                    DataRow rows2 = rq_zz15s2.Rows.Find(str_dept);
                    if (rows2 != null)
                    {
                        rows1["in_cnt"] = rows2["in_cnt"].ToString();
                        rows1["count1"] = Convert.ToDecimal(rows1["count1"].ToString()) + 1;
                    }


                    DataRow rows3 = rq_zz15s4.Rows.Find(str_dept);
                    if (rows3 != null)
                    {
                        rows1["new_cnt"] = rows3["new_cnt"].ToString();
                        rows1["count1"] = Convert.ToDecimal(rows1["count1"].ToString()) + 1;
                    }


                    DataRow rows4 = rq_zz15s5.Rows.Find(str_dept);
                    if (rows4 != null)
                    {
                        rows1["out_cnt"] = rows4["out_cnt"].ToString();
                        rows1["count1"] = Convert.ToDecimal(rows1["count1"].ToString()) + 1;
                    }


                    DataRow rows5 = rq_zz15s6.Rows.Find(str_dept);
                    if (rows5 != null)
                    {
                        rows1["out_cnt1"] = rows5["out_cnt"].ToString();
                        rows1["count1"] = Convert.ToDecimal(rows1["count1"].ToString()) + 1;
                    }


                    DataRow rows6 = rq_zz15s7.Rows.Find(str_dept);
                    if (rows6 != null)
                    {
                        rows1["out_cnt2"] = rows6["out_cnt"].ToString();
                        rows1["count1"] = Convert.ToDecimal(rows1["count1"].ToString()) + 1;
                    }


                    DataRow rows7 = rq_zz15s8.Rows.Find(str_dept);
                    if (rows7 != null)
                    {
                        rows1["out_cnt3"] = rows7["out_cnt"].ToString();
                        rows1["count1"] = Convert.ToDecimal(rows1["count1"].ToString()) + 1;
                    }


                    DataRow rows8 = rq_zz15s9.Rows.Find(str_dept);
                    if (rows8 != null)
                    {
                        rows1["stin_cnt"] = rows8["stin_cnt"].ToString();
                        rows1["count1"] = Convert.ToDecimal(rows1["count1"].ToString()) + 1;
                    }


                    DataRow rows9 = rq_zz15s10.Rows.Find(str_dept);
                    if (rows9 != null)
                    {
                        rows1["stdt_cnt"] = rows9["stdt_cnt"].ToString();
                        rows1["count1"] = Convert.ToDecimal(rows1["count1"].ToString()) + 1;
                    }


                    DataRow rows10 = rq_zz15s11.Rows.Find(str_dept);
                    if (rows10 != null)
                    {
                        rows1["stout_cnt"] = rows10["stout_cnt"].ToString();
                        rows1["count1"] = Convert.ToDecimal(rows1["count1"].ToString()) + 1;
                    }

                }

                DataRow[] row31 = rq_zz15s1a.Select("count1 >0", "job_disp asc");
                for (int i = 0; i < row31.Length; i++)
                {
                    decimal tin_cnt = decimal.Parse(row31[i]["tin_cnt"].ToString());
                    decimal tout_cnt = decimal.Parse(row31[i]["tout_cnt"].ToString());
                    decimal in_cnt = decimal.Parse(row31[i]["in_cnt"].ToString());
                    decimal new_cnt = decimal.Parse(row31[i]["new_cnt"].ToString());
                    decimal out_cnt = decimal.Parse(row31[i]["out_cnt"].ToString());
                    decimal out_cnt1 = decimal.Parse(row31[i]["out_cnt1"].ToString());
                    decimal out_cnt2 = decimal.Parse(row31[i]["out_cnt2"].ToString());
                    decimal out_cnt3 = decimal.Parse(row31[i]["out_cnt3"].ToString());
                    decimal stin_cnt = decimal.Parse(row31[i]["stin_cnt"].ToString());
                    decimal stdt_cnt = decimal.Parse(row31[i]["stdt_cnt"].ToString());
                    decimal stut_cnt = decimal.Parse(row31[i]["stut_cnt"].ToString());
                    decimal stout_cnt = decimal.Parse(row31[i]["stout_cnt"].ToString());
                    decimal injob_cnt = decimal.Parse(row31[i]["injob_cnt"].ToString());
                    decimal count1 = 0;
                    if (in_cnt + new_cnt + stin_cnt + tin_cnt - tout_cnt - out_cnt - out_cnt1 - out_cnt2 - out_cnt3 - stdt_cnt + in_cnt == 0)
                        count1 = 0;
                    else
                    {
                        //count1 = decimal.Round(((out_cnt1 + out_cnt + stdt_cnt) / ((in_cnt + new_cnt + stin_cnt + tin_cnt - tout_cnt - out_cnt - out_cnt1 - out_cnt2 - out_cnt3 - stdt_cnt + in_cnt) / 2)) * 100, 2);
                        if ((out_cnt1 + out_cnt + stdt_cnt) == 0 || (in_cnt + injob_cnt) == 0)
                        {
                            count1 = 0;
                        }
                        else
                        {
                            count1 = decimal.Round((out_cnt1 + out_cnt + stdt_cnt) / ((in_cnt + injob_cnt) / 2) * 100, 2);
                        }
                    }

                    DataRow aRow1 = ds.Tables["rq_zz15s1"].NewRow();
                    aRow1["dept"] = row31[i]["job_disp"].ToString();
                    aRow1["d_name"] = row31[i]["d_name"].ToString();
                    aRow1["tin_cnt"] = decimal.Parse(row31[i]["tin_cnt"].ToString());
                    aRow1["tout_cnt"] = decimal.Parse(row31[i]["tout_cnt"].ToString());
                    aRow1["count1"] = count1;
                    aRow1["in_cnt"] = decimal.Parse(row31[i]["in_cnt"].ToString());
                    aRow1["new_cnt"] = decimal.Parse(row31[i]["new_cnt"].ToString());
                    aRow1["out_cnt"] = decimal.Parse(row31[i]["out_cnt"].ToString());
                    aRow1["out_cnt1"] = decimal.Parse(row31[i]["out_cnt1"].ToString());
                    aRow1["out_cnt2"] = decimal.Parse(row31[i]["out_cnt2"].ToString());
                    aRow1["out_cnt3"] = decimal.Parse(row31[i]["out_cnt3"].ToString());
                    aRow1["stin_cnt"] = decimal.Parse(row31[i]["stin_cnt"].ToString());
                    aRow1["stdt_cnt"] = decimal.Parse(row31[i]["stdt_cnt"].ToString());
                    aRow1["stut_cnt"] = decimal.Parse(row31[i]["stut_cnt"].ToString());
                    aRow1["stout_cnt"] = decimal.Parse(row31[i]["stout_cnt"].ToString());
                    aRow1["injob_cnt"] = decimal.Parse(row31[i]["injob_cnt"].ToString());
                    ds.Tables["rq_zz15s1"].Rows.Add(aRow1);
                }
                rq_zz15s2 = null;
                rq_zz15s3 = null;
                rq_zz15s4 = null;
                rq_zz15s5 = null;
                rq_zz15s6 = null;
                rq_zz15s7 = null;
                rq_zz15s8 = null;
                rq_zz15s9 = null;
                rq_zz15s10 = null;
                rq_zz15s11 = null;

                if (exportexcel)
                {
                    RptViewer.Visible = false;
                    Export(ds.Tables["rq_zz15s1"]);
                    this.Close();
                }
                else
                {
                    RptViewer.Visible = true;
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "EmpReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "EmpReport", "*.rdlc");
                    
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz152.rdlc";
                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Out_Day", Convert.ToString(outday)) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("empdata_rq_zz15s1", ds.Tables["rq_zz15s1"]));
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
            ExporDt.Columns.Add("職稱代碼", typeof(string));
            ExporDt.Columns.Add("職稱", typeof(string));
            ExporDt.Columns.Add("期初人數", typeof(int));
            ExporDt.Columns.Add("新進", typeof(int));
            ExporDt.Columns.Add("復職", typeof(int));
            ExporDt.Columns.Add("調入", typeof(int));
            ExporDt.Columns.Add("調出", typeof(int));
            ExporDt.Columns.Add(">=" + outday.ToString() + "天離職", typeof(int));
            ExporDt.Columns.Add("<" + outday.ToString() + "天離職", typeof(int));
            ExporDt.Columns.Add(">=" + outday.ToString() + "天除名", typeof(int));
            ExporDt.Columns.Add("<" + outday.ToString() + "天除名", typeof(int));
            ExporDt.Columns.Add("留職", typeof(int));
            ExporDt.Columns.Add("期末人數", typeof(int));
            ExporDt.Columns.Add("離職率", typeof(decimal));
            ExporDt.Columns.Add("留離", typeof(int));
            foreach (DataRow Row in DT.Rows)
            {
                int _str1 = int.Parse(Row["in_cnt"].ToString()) + int.Parse(Row["new_cnt"].ToString()) + int.Parse(Row["stin_cnt"].ToString()) + int.Parse(Row["tin_cnt"].ToString());
                int _str2 = int.Parse(Row["tout_cnt"].ToString()) + int.Parse(Row["out_cnt"].ToString()) + int.Parse(Row["out_cnt1"].ToString()) + int.Parse(Row["out_cnt2"].ToString()) + int.Parse(Row["out_cnt3"].ToString()) + int.Parse(Row["stdt_cnt"].ToString());
                DataRow aRow = ExporDt.NewRow();
                aRow["職稱代碼"] = Row["dept"].ToString();
                aRow["職稱"] = Row["d_name"].ToString();
                aRow["期初人數"] = int.Parse(Row["in_cnt"].ToString());
                aRow["新進"] = int.Parse(Row["new_cnt"].ToString());
                aRow["復職"] = int.Parse(Row["stin_cnt"].ToString());
                aRow["調入"] = int.Parse(Row["tin_cnt"].ToString());
                aRow["調出"] = int.Parse(Row["tout_cnt"].ToString());
                aRow[">=" + outday.ToString() + "天離職"] = int.Parse(Row["out_cnt1"].ToString());
                aRow["<" + outday.ToString() + "天離職"] = int.Parse(Row["out_cnt"].ToString());
                aRow[">=" + outday.ToString() + "天除名"] = int.Parse(Row["out_cnt2"].ToString());
                aRow["<" + outday.ToString() + "天除名"] = int.Parse(Row["out_cnt3"].ToString());
                aRow["留職"] = int.Parse(Row["stdt_cnt"].ToString());
                aRow["期末人數"] = int.Parse(Row["injob_cnt"].ToString());//_str1 - _str2
                aRow["離職率"] = decimal.Parse(Row["count1"].ToString());
                aRow["留離"] = int.Parse(Row["stout_cnt"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
