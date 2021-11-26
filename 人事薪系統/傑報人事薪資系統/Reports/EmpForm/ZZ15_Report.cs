/* ======================================================================================================
 * 功能名稱：離職率統計表
 * 功能代號：ZZ15
 * 功能路徑：報表列印 > 人事 > 離職率統計表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\EmpForm\ZZ15_Report.cs
 * 功能用途：
 *  用於產出離職率統計表
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/06/10    Daniel Chih    Ver 1.0.01     1. 修改條件判斷語法，統一讀ADATE，並移除排除最後一天資料的判斷式
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/06/10
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
    public partial class ZZ15_Report : JBControls.JBForm
    {
        empdata ds = new empdata();
        string date_b, date_e, dept_b, dept_e, emp_b, emp_e, comp_b, comp_e, out_code, depttype, type_data, type_data1, username, comp_name;        
        decimal outday;
        bool exportexcel;

        public ZZ15_Report(string dateb, string datee, string deptb, string depte, string empb, string empe, string compb, string compe, string _outcode, string _depttype, decimal _outday, bool _exportexcel, string typedata, string typedata1, string _username, string compname)
        {
            InitializeComponent();
            date_b = dateb; date_e = datee; dept_b = deptb; dept_e = depte; emp_b = empb;
            emp_e = empe; comp_b = compb; comp_e = compe; username = _username;
            outday = _outday; exportexcel = _exportexcel; type_data = typedata; out_code = _outcode;
            comp_name = compname; type_data1 = typedata1; depttype = _depttype;
        }

        private void ZZ15_Report_Load(object sender, EventArgs e)
        {
            try
            {                
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select a.d_no_disp,a.d_no as dept,a.d_name,0000000 as tin_cnt,0000000 as tout_cnt,00000000 as count1,";
                sqlCmd += "0000000 as in_cnt,0000000 as new_cnt,0000000 as out_cnt,0000000 as out_cnt1,0000000 as out_cnt2,";
                sqlCmd += "0000000 as out_cnt3,0000000 as stin_cnt,0000000 as stdt_cnt,0000000 as stut_cnt,0000000 as stout_cnt,";
                sqlCmd += "0000000 as injob_cnt";
                //sqlCmd += "a.dept_tree";
                if (depttype=="1")
                {
                    sqlCmd += " from dept a ";
                }                    
                else
                {
                    sqlCmd += " from depts a ";
                }
                    
                DataTable rq_zz15s1a = SqlConn.GetDataTable(sqlCmd);               
                rq_zz15s1a.PrimaryKey = new DataColumn[] { rq_zz15s1a.Columns["dept"] };               

                DataTable zz_tin = new DataTable("zz_tin");
                zz_tin.Columns.Add("dept", typeof(string));
                zz_tin.Columns.Add("tin_cnt", typeof(decimal));
                zz_tin.Columns.Add("tout_cnt", typeof(decimal));
                ds.Tables.Add(zz_tin);
                ds.Tables["zz_tin"].PrimaryKey = new DataColumn[] { ds.Tables["zz_tin"].Columns["dept"] };

                //DataTable rq_depttree = SqlConn.GetDataTable("select d_no,d_no_disp,d_name,dept_tree from dept");
                //rq_depttree.PrimaryKey = new DataColumn[] { rq_depttree.Columns["d_no"] };

                for (int i = 0; i < rq_zz15s1a.Rows.Count; i++)
                {
                    //int _len = 0;
                    //if (rq_zz15s1a.Rows[i]["dept"].ToString().Trim().Length < 6)
                    //    _len = rq_zz15s1a.Rows[i]["dept"].ToString().Trim().Length;
                    //else
                    //    _len = 6;
                    DataRow row30 = ds.Tables["zz_tin"].Rows.Find(rq_zz15s1a.Rows[i]["dept"].ToString());
                    if (row30 == null)
                    {
                        DataRow aRow5 = ds.Tables["zz_tin"].NewRow();
                        aRow5["dept"] = rq_zz15s1a.Rows[i]["dept"].ToString();
                        aRow5["tin_cnt"] = 0;
                        aRow5["tout_cnt"] = 0;
                        ds.Tables["zz_tin"].Rows.Add(aRow5);
                    }
                }

                DataTable zz15_tin = new DataTable();
                zz15_tin = rq_zz15s1a.Copy();
                zz15_tin.TableName = "zz15_tin";
                ds.Tables.Add(zz15_tin);

                string dept = string.Empty; string StrDept = string.Empty; string groupdept = string.Empty;
                dept = "A.DEPT";
                groupdept = "A.DEPT";
                StrDept = " LEFT OUTER JOIN DEPT C ON A.DEPT=C.D_NO"; 
                if (depttype == "2")
                {
                    dept = "A.DEPTS AS DEPT";
                    StrDept = " LEFT OUTER JOIN DEPTS C ON A.DEPTS=C.D_NO";
                    groupdept = "A.DEPTS";
                }
                    

                string sqlCmd1 = "SELECT ";
                sqlCmd1 += string.Format(@"{0}", dept);
                sqlCmd1 += ",COUNT(A.NOBR) AS IN_CNT";
                sqlCmd1 += " FROM BASE B,BASETTS A";
                sqlCmd1 += StrDept;
                sqlCmd1 += string.Format(@" WHERE DATEADD(DAY,-1,'{0}') BETWEEN A.ADATE AND A.DDATE", date_b);  //WHERE '{0}' BETWEEN A.ADATE AND A.DDATE
                sqlCmd1 += string.Format(@" AND A.EMPCD BETWEEN '{0}' AND '{1}'", emp_b, emp_e);
                sqlCmd1 += string.Format(@" AND C.d_no_disp BETWEEN '{0}' AND '{1}'", dept_b, dept_e);
                sqlCmd1 += " AND A.NOBR = B.NOBR ";
                sqlCmd1 += " AND A.TTSCODE IN ('1','4','6')";
                sqlCmd1 += string.Format(@" AND A.COMP BETWEEN '{0}' AND '{1}'", comp_b, comp_e);
                //sqlCmd1 += string.Format(@" AND NOT EXISTS (SELECT T.NOBR FROM BASETTS T WHERE A.NOBR=T.NOBR  AND T.OUDT=DATEADD(DAY,-1,'{0}') )", date_b);
                sqlCmd1 += type_data;
                sqlCmd1 += string.Format(@" GROUP BY {0}", groupdept);
                DataTable rq_zz15s2= SqlConn.GetDataTable(sqlCmd1);
               

                for (int i = 0; i < rq_zz15s2.Rows.Count; i++)
                {
                    DataRow row = rq_zz15s1a.Rows.Find(rq_zz15s2.Rows[i]["dept"]);
                    if (row == null)
                    {
                        DataRow aRow1 = rq_zz15s1a.NewRow();
                        aRow1["dept"] = rq_zz15s2.Rows[i]["dept"].ToString();
                        aRow1["dept_tree"] = rq_zz15s2.Rows[i]["dept_tree"].ToString();
                        aRow1["d_name"] = "";
                        aRow1["in_cnt"] = decimal.Parse(rq_zz15s2.Rows[i]["in_cnt"].ToString());
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
                        rq_zz15s1a.Rows.Add(aRow1);
                    }

                    else
                    {
                        row["count1"] = 1;
                        row["in_cnt"] = decimal.Parse(rq_zz15s2.Rows[i]["in_cnt"].ToString());
                    }
                }

                //期未人數
                string sqlCmd1a = "SELECT ";
                sqlCmd1a += string.Format(@"{0}", dept);
                sqlCmd1a += ",COUNT(A.NOBR) AS IN_CNT";
                sqlCmd1a += " FROM BASE B,BASETTS A";
                sqlCmd1a += StrDept;
                sqlCmd1a += string.Format(@" WHERE '{0}' BETWEEN A.ADATE AND A.DDATE", date_e);
                sqlCmd1a += string.Format(@" AND A.EMPCD BETWEEN '{0}' AND '{1}'", emp_b, emp_e);
                sqlCmd1a += string.Format(@" AND C.d_no_disp BETWEEN '{0}' AND '{1}'", dept_b, dept_e);
                sqlCmd1a += " AND A.NOBR = B.NOBR ";
                sqlCmd1a += " AND A.TTSCODE IN ('1','4','6')";
                sqlCmd1a += string.Format(@" AND A.COMP BETWEEN '{0}' AND '{1}'",comp_b,comp_e);
                //sqlCmd1a += string.Format(@" AND NOT EXISTS (SELECT T.NOBR FROM BASETTS T WHERE A.NOBR=T.NOBR  AND T.OUDT='{0}' )", date_e);
                sqlCmd1a +=type_data;
                sqlCmd1a += string.Format(@" GROUP BY {0}", groupdept);
                DataTable rq_zz15s2a = SqlConn.GetDataTable(sqlCmd1a);
                for (int i = 0; i < rq_zz15s2a.Rows.Count; i++)
                {
                    DataRow row = rq_zz15s1a.Rows.Find(rq_zz15s2a.Rows[i]["dept"]);
                    if (row == null)
                    {
                        DataRow aRow1 = rq_zz15s1a.NewRow();
                        aRow1["dept"] = rq_zz15s2a.Rows[i]["dept"].ToString();
                        //aRow1["dept_tree"] = rq_zz15s2a.Rows[i]["dept_tree"].ToString();
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

                //調入調出
                string sqlCmd2 = "SELECT A.NOBR,";
                sqlCmd2 += string.Format(@"{0}", dept);
                sqlCmd2 += ",A.TTSCODE,A.ADATE,A.DDATE,DATEADD(DAY,-1,A.ADATE) AS STR_ADATE ";
                sqlCmd2 += " FROM BASE B,BASETTS A";
                sqlCmd2 += StrDept;
                sqlCmd2 += string.Format(@" WHERE '{0}' BETWEEN A.ADATE AND A.DDATE", date_e);
                sqlCmd2 += " AND A.NOBR = B.NOBR ";
                sqlCmd2 += type_data;
                sqlCmd2 += " AND A.TTSCODE ='6'";
                sqlCmd2 += string.Format(@" AND A.EMPCD BETWEEN '{0}' AND '{1}'", emp_b, emp_e);
                sqlCmd2 += string.Format(@" AND C.d_no_disp BETWEEN '{0}' AND '{1}'", dept_b, dept_e);
                sqlCmd2 += string.Format(@" AND A.COMP BETWEEN '{0}' AND '{1}'", comp_b, comp_e);
                sqlCmd2 += string.Format(@" AND A.ADATE BETWEEN '{0}' AND '{1}'", date_b, date_e);
                sqlCmd2 += " ORDER BY 1";
                 DataTable rq_zz15s3 = SqlConn.GetDataTable(sqlCmd2);                 

                foreach (DataRow row in rq_zz15s3.Rows)
                {
                    //string str_adate = DateTime.Parse(row["adate"].ToString()).AddDays(-1).ToShortDateString();
                    string str_adate = DateTime.Parse(row["str_adate"].ToString()).ToShortDateString();
                    string str_nobr = row["nobr"].ToString();
                    string str_dept = row["dept"].ToString().Trim();
                    string sqlCmd3 = "SELECT A.NOBR,";
                    sqlCmd3 += string.Format(@"{0}", dept);
                    sqlCmd3 += ",A.TTSCODE,A.ADATE,A.DDATE ";
                    sqlCmd3 += " FROM BASE B,BASETTS A";
                    sqlCmd3 += " LEFT OUTER JOIN DEPT C ON A.DEPT=C.D_NO";
                    sqlCmd3 += string.Format(@" WHERE '{0}' BETWEEN A.ADATE AND A.DDATE", str_adate);
                    sqlCmd3 += " AND A.NOBR = B.NOBR";
                    sqlCmd3 += string.Format(@" AND A.EMPCD BETWEEN '{0}' AND '{1}'", emp_b, emp_e);
                    //sqlCmd3 += string.Format(@" AND C.d_no_disp BETWEEN '{0}' AND '{1}'" ,dept_b,dept_e);
                    sqlCmd3 += string.Format(@" AND A.COMP BETWEEN '{0}' AND '{1}'", comp_b, comp_e);
                    sqlCmd3 += type_data1;
                    sqlCmd3 += string.Format(@" AND A.NOBR = '{0}'", str_nobr);
                    DataTable rq_zz15z = SqlConn.GetDataTable(sqlCmd3);                   
                    string str_dept1 = "";
                    if (rq_zz15z.Rows.Count > 0)
                    {
                        str_dept1 = rq_zz15z.Rows[0]["dept"].ToString().Trim();
                        if (str_dept != rq_zz15z.Rows[0]["dept"].ToString().Trim())
                        {
                            DataRow row20 = ds.Tables["zz_tin"].Rows.Find(str_dept);
                            if (row20 != null)
                                row20["tin_cnt"] = decimal.Parse(row20["tin_cnt"].ToString()) + 1;
                            DataRow row21 = ds.Tables["zz_tin"].Rows.Find(str_dept1);
                            if (row21 != null)
                                row21["tout_cnt"] = decimal.Parse(row21["tout_cnt"].ToString()) + 1;
                        }
                    }
                    rq_zz15z.Rows.Clear();
                }
                
                //				新進
                string sqlCmd4 = "SELECT ";
                sqlCmd4 += string.Format(@"{0}", dept);
                sqlCmd4 += ",COUNT(A.NOBR) AS NEW_CNT ";
                sqlCmd4 += " FROM BASE B,BASETTS A";
                sqlCmd4 += " LEFT OUTER JOIN DEPT C ON A.DEPT=C.D_NO";
                sqlCmd4 += " WHERE A.TTSCODE ='1'";
                sqlCmd4 += string.Format(@" AND A.ADATE BETWEEN '{0}' AND '{1}'", date_b, date_e);
                sqlCmd4 += string.Format(@" AND A.EMPCD BETWEEN '{0}' AND '{1}'", emp_b, emp_e);
                sqlCmd4 += string.Format(@" AND C.d_no_disp BETWEEN '{0}' AND '{1}'" ,dept_b,dept_e);
                sqlCmd4 += string.Format(@" AND A.COMP BETWEEN '{0}' AND '{1}'", comp_b, comp_e);
                sqlCmd4 += " AND A.NOBR = B.NOBR ";
                sqlCmd4 += type_data;
                sqlCmd4 += string.Format(@" GROUP BY {0}", groupdept);
                DataTable rq_zz15s4 = SqlConn.GetDataTable(sqlCmd4);


                for (int i = 0; i < rq_zz15s4.Rows.Count; i++)
                {
                    DataRow row1 = rq_zz15s1a.Rows.Find(rq_zz15s4.Rows[i]["dept"]);
                    if (row1 == null)
                    {
                        DataRow aRow2 = rq_zz15s1a.NewRow();
                        aRow2["dept"] = rq_zz15s4.Rows[i]["dept"].ToString();
                        //aRow2["dept_tree"] = rq_zz15s4.Rows[i]["dept_tree"].ToString();
                        aRow2["d_name"] = "";
                        aRow2["in_cnt"] = 0;
                        aRow2["tout_cnt"] = 0;
                        aRow2["tin_cnt"] = 0;
                        aRow2["count1"] = 1;
                        aRow2["new_cnt"] = decimal.Parse(rq_zz15s4.Rows[i]["new_cnt"].ToString());
                        aRow2["out_cnt"] = 0;
                        aRow2["out_cnt1"] = 0;
                        aRow2["out_cnt2"] = 0;
                        aRow2["out_cnt3"] = 0;
                        aRow2["stin_cnt"] = 0;
                        aRow2["stdt_cnt"] = 0;
                        aRow2["stut_cnt"] = 0;
                        aRow2["stout_cnt"] = 0;
                        rq_zz15s1a.Rows.Add(aRow2);
                    }

                    else
                    {
                        row1["count1"] = decimal.Parse(row1["count1"].ToString()) + 1;
                        row1["new_cnt"] = decimal.Parse(rq_zz15s4.Rows[i]["new_cnt"].ToString());
                    }
                }
               

                //				離職&& 進廠小於30天
                string sqlCmd5 = "SELECT ";
                sqlCmd5 += string.Format(@"{0}", dept);
                sqlCmd5 += ",COUNT(A.NOBR) AS OUT_CNT ";
                sqlCmd5 += " FROM BASE B,BASETTS A";
                sqlCmd5 += StrDept;
                sqlCmd5 += " WHERE A.TTSCODE ='2'";
                    //" AND A.ADATE BETWEEN '" + date_b + "' AND '" + date_e + "'" +
                //sqlCmd5 += string.Format(@" AND A.OUDT BETWEEN '{0}' AND '{1}'", date_b, date_e);
                sqlCmd5 += string.Format(@" AND A.ADATE BETWEEN '{0}' AND '{1}'", date_b, date_e);

                sqlCmd5 += string.Format(@" AND A.EMPCD BETWEEN '{0}' AND '{1}'", emp_b, emp_e);
                sqlCmd5 += string.Format(@" AND C.d_no_disp BETWEEN '{0}' AND '{1}'", dept_b, dept_e);
                sqlCmd5 += string.Format(@" AND A.COMP BETWEEN '{0}' AND '{1}'", comp_b, comp_e);
                sqlCmd5 += string.Format(@" AND A.OUDT -A.INDT < {0}", outday);
                sqlCmd5 += " AND A.NOBR = B.NOBR ";
                sqlCmd5 += type_data;
                sqlCmd5 += string.Format(@" AND A.OUTCD <> '{0}' ", out_code);
                sqlCmd5 += string.Format(@" GROUP BY {0}", groupdept);
                DataTable rq_zz15s5 = SqlConn.GetDataTable(sqlCmd5);

                //				離職&& 進廠大於等於30天
                string sqlCmd6 = "SELECT ";
                sqlCmd6 += string.Format(@"{0}", dept);
                sqlCmd6 += ",COUNT(A.NOBR) AS OUT_CNT ";
                sqlCmd6 += " FROM BASE B,BASETTS A";
                sqlCmd6 += StrDept;
                sqlCmd6 += " WHERE A.TTSCODE ='2'";
                sqlCmd6 += string.Format(@" AND A.EMPCD BETWEEN '{0}' AND '{1}'", emp_b, emp_e);
                sqlCmd6 += string.Format(@" AND C.d_no_disp BETWEEN '{0}' AND '{1}'", dept_b, dept_e);
                sqlCmd6 += string.Format(@" AND A.COMP BETWEEN '{0}' AND '{1}'", comp_b, comp_e);
                sqlCmd6 += " AND A.NOBR = B.NOBR ";
                sqlCmd6 += type_data;
                    //" AND A.ADATE BETWEEN '" + date_b + "' AND '" + date_e + "'" +
                //sqlCmd6 += string.Format(@" AND A.OUDT BETWEEN '{0}' AND '{1}'", date_b, date_e);
                sqlCmd6 += string.Format(@" AND A.ADATE BETWEEN '{0}' AND '{1}'", date_b, date_e);

                sqlCmd6 += string.Format(@" AND A.OUDT - A.INDT >= {0}", outday);
                sqlCmd6 += string.Format(@" AND A.OUTCD <> '{0}' ", out_code);
                sqlCmd6 += string.Format(@" GROUP BY {0}", groupdept);
                DataTable rq_zz15s6 = SqlConn.GetDataTable(sqlCmd6);

                //				除名&& 進廠大於等於30天
                string sqlCmd7 = "SELECT ";
                sqlCmd7 += string.Format(@"{0}", dept);
                sqlCmd7 += ",COUNT(A.NOBR) AS OUT_CNT ";
                sqlCmd7 += " FROM BASE B,BASETTS A";
                sqlCmd7 += StrDept;
                sqlCmd7 += " WHERE A.TTSCODE='2'";
                    //" AND A.ADATE BETWEEN '" + date_b + "' AND '" + date_e + "'" +
                //sqlCmd7 += string.Format(@" AND A.OUDT BETWEEN '{0}' AND '{1}'", date_b, date_e);
                sqlCmd7 += string.Format(@" AND A.ADATE BETWEEN '{0}' AND '{1}'", date_b, date_e);

                sqlCmd7 += string.Format(@" AND A.EMPCD BETWEEN '{0}' AND '{1}'", emp_b, emp_e);
                sqlCmd7 += string.Format(@" AND C.d_no_disp BETWEEN '{0}' AND '{1}'", dept_b, dept_e);
                sqlCmd7 += string.Format(@" AND A.COMP BETWEEN '{0}' AND '{1}'", comp_b, comp_e);
                sqlCmd7 += " AND A.NOBR = B.NOBR ";
                sqlCmd7 += type_data;
                sqlCmd7 += string.Format(@" AND A.OUDT - A.INDT >= {0}", outday);
                sqlCmd7 += string.Format(@" AND A.OUTCD = '{0}' ", out_code);
                sqlCmd7 += string.Format(@" GROUP BY {0}", groupdept);
                DataTable rq_zz15s7 = SqlConn.GetDataTable(sqlCmd7);

                //				除名&& 進廠小於30天
                string sqlCmd8 = "SELECT ";
                sqlCmd8 += string.Format(@"{0}", dept);
                sqlCmd8 += ",COUNT(A.NOBR) AS OUT_CNT ";
                sqlCmd8 += " FROM BASE B,BASETTS A";
                sqlCmd8 += StrDept;
                sqlCmd8 += " WHERE A.TTSCODE='2'";
                    //" AND A.ADATE BETWEEN '" + date_b + "' AND '" + date_e + "'" +
                //sqlCmd8 += string.Format(@" AND A.OUDT BETWEEN '{0}' AND '{1}'", date_b, date_e);
                sqlCmd8 += string.Format(@" AND A.ADATE BETWEEN '{0}' AND '{1}'", date_b, date_e);

                sqlCmd8 += string.Format(@" AND A.EMPCD BETWEEN '{0}' AND '{1}'", emp_b, emp_e);
                sqlCmd8 += string.Format(@" AND C.d_no_disp BETWEEN '{0}' AND '{1}'", dept_b, dept_e);
                sqlCmd8 += string.Format(@" AND A.COMP BETWEEN '{0}' AND '{1}'", comp_b, comp_e);
                sqlCmd8 += string.Format(@" AND A.OUDT - A.INDT < {0}", outday);
                sqlCmd8 += " AND A.NOBR = B.NOBR ";
                sqlCmd8 += type_data;
                sqlCmd8 += string.Format(@" AND A.OUTCD = '{0}' ", out_code);
                sqlCmd8 += string.Format(@" GROUP BY {0}", groupdept);
                 DataTable rq_zz15s8 = SqlConn.GetDataTable(sqlCmd8);

                //				復職
                 string sqlCmd9 = "SELECT ";
                 sqlCmd9 += string.Format(@"{0}", dept);
                 sqlCmd9 += ",COUNT(A.NOBR) AS STIN_CNT ";
                 sqlCmd9 += " FROM BASE B,BASETTS A";
                 sqlCmd9 += StrDept;
                 sqlCmd9 += " WHERE A.TTSCODE ='4'";
                 sqlCmd9 += string.Format(@" AND A.ADATE BETWEEN '{0}' AND '{1}'", date_b, date_e);
                 sqlCmd9 += string.Format(@" AND A.EMPCD BETWEEN '{0}' AND '{1}'", emp_b, emp_e);
                 sqlCmd9 += string.Format(@" AND C.d_no_disp BETWEEN '{0}' AND '{1}'", dept_b, dept_e);
                 sqlCmd9 += string.Format(@" AND A.COMP BETWEEN '{0}' AND '{1}'", comp_b, comp_e);
                 sqlCmd9 += " AND A.NOBR = B.NOBR";
                 sqlCmd9 += type_data;
                 sqlCmd9 += string.Format(@" GROUP BY {0}", groupdept);
                DataTable rq_zz15s9 = SqlConn.GetDataTable(sqlCmd9);

                //				留職停薪
                string sqlCmd10 = "SELECT ";
                sqlCmd10 += string.Format(@"{0}", dept);
                sqlCmd10 += ",COUNT(A.NOBR) AS STDT_CNT ";
                sqlCmd10 += " FROM BASE B,BASETTS A";
                sqlCmd10 += StrDept;
                sqlCmd10 += " WHERE A.TTSCODE ='3'";
                //sqlCmd10 += string.Format(@" AND A.STDT BETWEEN '{0}' AND '{1}'", date_b, date_e);
                sqlCmd10 += string.Format(@" AND A.ADATE BETWEEN '{0}' AND '{1}'", date_b, date_e);

                sqlCmd10 += string.Format(@" AND A.EMPCD BETWEEN '{0}' AND '{1}'", emp_b, emp_e);
                sqlCmd10 += string.Format(@" AND C.d_no_disp BETWEEN '{0}' AND '{1}'", dept_b, dept_e);
                sqlCmd10 += string.Format(@" AND A.COMP BETWEEN '{0}' AND '{1}'", comp_b, comp_e);
                sqlCmd10 += " AND A.NOBR = B.NOBR ";
                sqlCmd10 += type_data;
                sqlCmd10 += string.Format(@" GROUP BY {0}", groupdept);
                DataTable rq_zz15s10 = SqlConn.GetDataTable(sqlCmd10);

                //				停薪離職
                string sqlCmd11 = "SELECT ";
                sqlCmd11 += string.Format(@"{0}", dept);
                sqlCmd11 += ",COUNT(A.NOBR) AS STOUT_CNT ";
                sqlCmd11 += " FROM BASE B,BASETTS A";
                sqlCmd11 += StrDept;
                sqlCmd11 += " WHERE A.TTSCODE ='5'";
                    //" AND A.ADATE BETWEEN '" + date_b + "' AND '" + date_e + "'" +
                //sqlCmd11 += string.Format(@" AND A.STOUDT BETWEEN '{0}' AND '{1}'", date_b, date_e);
                sqlCmd11 += string.Format(@" AND A.ADATE BETWEEN '{0}' AND '{1}'", date_b, date_e);

                sqlCmd11 += string.Format(@" AND A.EMPCD BETWEEN '{0}' AND '{1}'", emp_b, emp_e);
                sqlCmd11 += string.Format(@" AND C.d_no_disp BETWEEN '{0}' AND '{1}'", dept_b, dept_e);
                sqlCmd11 += string.Format(@" AND A.COMP BETWEEN '{0}' AND '{1}'", comp_b, comp_e);
                sqlCmd11 += " AND A.NOBR = B.NOBR ";
                sqlCmd11 += type_data;
                sqlCmd11 += string.Format(@" GROUP BY {0}", groupdept);
                DataTable rq_zz15s11 = SqlConn.GetDataTable(sqlCmd11);

                rq_zz15s2.PrimaryKey = new DataColumn[] { rq_zz15s2.Columns["dept"] };


                for (int i = 0; i < rq_zz15s1a.Rows.Count; i++)
                {
                    DataRow row = rq_zz15s2.Rows.Find(rq_zz15s1a.Rows[i]["dept"]);
                    if (row != null)
                    {
                        rq_zz15s1a.Rows[i]["in_cnt"] = row["in_cnt"].ToString();
                        rq_zz15s1a.Rows[i]["count1"] = decimal.Parse(rq_zz15s1a.Rows[i]["count1"].ToString()) + 1;
                        //					row[0]["in_cnt"]=rq_zz15s2.Rows[i]["in_cnt"].ToString();
                        //					row[0]["count1"]=decimal.Parse(row[0]["count1"].ToString())+1;
                    }

                    DataRow[] row1 = rq_zz15s4.Select("dept='" + rq_zz15s1a.Rows[i]["dept"].ToString() + "'");
                    if (row1.Length > 0)
                    {
                        rq_zz15s1a.Rows[i]["new_cnt"] = row1[0]["new_cnt"].ToString();
                        rq_zz15s1a.Rows[i]["count1"] = decimal.Parse(rq_zz15s1a.Rows[i]["count1"].ToString()) + 1;
                    }

                    DataRow[] row2 = rq_zz15s5.Select("dept='" + rq_zz15s1a.Rows[i]["dept"].ToString() + "'");
                    if (row2.Length > 0)
                    {
                        rq_zz15s1a.Rows[i]["out_cnt"] = row2[0]["out_cnt"].ToString();
                        rq_zz15s1a.Rows[i]["count1"] = decimal.Parse(rq_zz15s1a.Rows[i]["count1"].ToString()) + 1;
                    }

                    DataRow[] row3 = rq_zz15s6.Select("dept='" + rq_zz15s1a.Rows[i]["dept"].ToString() + "'");
                    if (row3.Length > 0)
                    {
                        rq_zz15s1a.Rows[i]["out_cnt1"] = row3[0]["out_cnt"].ToString();
                        rq_zz15s1a.Rows[i]["count1"] = decimal.Parse(rq_zz15s1a.Rows[i]["count1"].ToString()) + 1;
                    }

                    DataRow[] row4 = rq_zz15s7.Select("dept='" + rq_zz15s1a.Rows[i]["dept"].ToString() + "'");
                    if (row4.Length > 0)
                    {
                        rq_zz15s1a.Rows[i]["out_cnt2"] = row4[0]["out_cnt"].ToString();
                        rq_zz15s1a.Rows[i]["count1"] = decimal.Parse(rq_zz15s1a.Rows[i]["count1"].ToString()) + 1;
                    }

                    DataRow[] row5 = rq_zz15s8.Select("dept='" + rq_zz15s1a.Rows[i]["dept"].ToString() + "'");
                    if (row5.Length > 0)
                    {
                        rq_zz15s1a.Rows[i]["out_cnt3"] = row5[0]["out_cnt"].ToString();
                        rq_zz15s1a.Rows[i]["count1"] = decimal.Parse(rq_zz15s1a.Rows[i]["count1"].ToString()) + 1;
                    }

                    DataRow[] row6 = rq_zz15s9.Select("dept='" + rq_zz15s1a.Rows[i]["dept"].ToString() + "'");
                    if (row6.Length > 0)
                    {
                        rq_zz15s1a.Rows[i]["stin_cnt"] = row6[0]["stin_cnt"].ToString();
                        rq_zz15s1a.Rows[i]["count1"] = decimal.Parse(rq_zz15s1a.Rows[i]["count1"].ToString()) + 1;
                    }

                    DataRow[] row7 = rq_zz15s10.Select("dept='" + rq_zz15s1a.Rows[i]["dept"].ToString() + "'");
                    if (row7.Length > 0)
                    {
                        rq_zz15s1a.Rows[i]["stdt_cnt"] = row7[0]["stdt_cnt"].ToString();
                        rq_zz15s1a.Rows[i]["count1"] = decimal.Parse(rq_zz15s1a.Rows[i]["count1"].ToString()) + 1;
                    }

                    DataRow[] row8 = rq_zz15s11.Select("dept='" + rq_zz15s1a.Rows[i]["dept"].ToString() + "'");
                    if (row8.Length > 0)
                    {
                        rq_zz15s1a.Rows[i]["stout_cnt"] = row8[0]["stout_cnt"].ToString();
                        //ds.Tables["rq_zz15s1"].Rows[i]["count1"] = decimal.Parse(ds.Tables["rq_zz15s1"].Rows[i]["count1"].ToString()) + 1;
                        rq_zz15s1a.Rows[i]["count1"] = decimal.Parse(rq_zz15s1a.Rows[i]["count1"].ToString()) + 1;
                    }

                    DataRow row9 = ds.Tables["zz_tin"].Rows.Find(rq_zz15s1a.Rows[i]["dept"].ToString());
                    if (row9 != null)
                    {
                        rq_zz15s1a.Rows[i]["tin_cnt"] = decimal.Parse(row9["tin_cnt"].ToString());
                        rq_zz15s1a.Rows[i]["tout_cnt"] = decimal.Parse(row9["tout_cnt"].ToString());
                        //if (decimal.Parse(row9["tin_cnt"].ToString())>0 || decimal.Parse(row9["tout_cnt"].ToString())>0)
                        //    rq_zz15s1a.Rows[i]["count1"] = decimal.Parse(rq_zz15s1a.Rows[i]["count1"].ToString()) + 1;
                    }
                }


                DataRow[] row31 = rq_zz15s1a.Select("count1 >0", "d_no_disp asc");
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
                    //if (in_cnt + new_cnt + stin_cnt + tin_cnt - tout_cnt - out_cnt - out_cnt1 - out_cnt2 - out_cnt3 - stdt_cnt + in_cnt == 0)
                    if (out_cnt1 + out_cnt + stdt_cnt == 0 || in_cnt + injob_cnt==0)
                        count1 = 0;
                    else
                    {
                        //count1 = decimal.Round((out_cnt1 + out_cnt + stdt_cnt) / ((in_cnt + new_cnt + stin_cnt + tin_cnt - tout_cnt - out_cnt - out_cnt1 - out_cnt2 - out_cnt3 - stdt_cnt + in_cnt) / 2) * 100, 2);
                        count1 = decimal.Round((out_cnt1 + out_cnt + stdt_cnt) / ((in_cnt + injob_cnt) / 2) * 100, 2);
                    }

                    DataRow aRow1 = ds.Tables["rq_zz15s1"].NewRow();
                    //DataRow row6a = rq_depttree.Rows.Find(row31[i]["dept_tree"].ToString());
                    //aRow1["dept_tree"] = "";
                    //if (row6a != null)
                    //    aRow1["dept_tree"] = row6a["d_no_disp"].ToString().Trim() + " " + row6a["d_name"].ToString();                    
                    aRow1["dept"] = row31[i]["d_no_disp"].ToString();
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
                rq_zz15s1a = null; rq_zz15s2 = null; rq_zz15s3 = null; rq_zz15s4 = null; rq_zz15s5 = null; rq_zz15s6 = null; rq_zz15s7 = null;
                rq_zz15s8 = null; rq_zz15s9 = null; rq_zz15s10 = null; rq_zz15s11 = null; 
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
                    
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz15.rdlc";
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
            //ExporDt.Columns.Add("報表分析群組", typeof(string));
            if (depttype == "2")
            {
                ExporDt.Columns.Add("成本代碼", typeof(string));
                ExporDt.Columns.Add("成本名稱", typeof(string));
            }
            else
            {
                ExporDt.Columns.Add("部門代碼", typeof(string));
                ExporDt.Columns.Add("部門名稱", typeof(string));
            }
            
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
                //aRow["報表分析群組"] = Row["dept_tree"].ToString();
                if (depttype == "2")
                {
                    aRow["成本代碼"] = Row["dept"].ToString();
                    aRow["成本名稱"] = Row["d_name"].ToString();
                }
                else
                {
                    aRow["部門代碼"] = Row["dept"].ToString();
                    aRow["部門名稱"] = Row["d_name"].ToString();
                }                
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
                //count1 = decimal.Round((out_cnt1 + out_cnt + stdt_cnt) / ((in_cnt + new_cnt + stin_cnt + tin_cnt - tout_cnt - out_cnt - out_cnt1 - out_cnt2 - out_cnt3 - stdt_cnt + in_cnt) / 2) * 100, 2);
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
