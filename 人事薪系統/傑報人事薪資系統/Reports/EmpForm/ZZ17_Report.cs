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
    public partial class ZZ17_Report : JBControls.JBForm
    {
        string type_data, str_sex, str_field, _datee;
        empdata ds = new empdata();

        string date_b, sextype, dept_b, dept_e, emp_b, emp_e, comp_b, comp_e, report_type, username, comp_name;
        string grp1_1, grp1_2, grp2_1, grp2_2, grp3_1, grp3_2, grp4_1, grp4_2, grp5_1, grp5_2, grp6_1, grp6_2, grp7_1, grp7_2, grp8_1, grp8_2, grp9_1, grp9_2, grp10_1, grp10_2;        
        bool exportexcel;

        public ZZ17_Report(string dateb, string deptb, string depte, string empb, string empe, string compb, string compe, string reporttype, string grp11, string grp12, string grp21, string grp22, string grp31, string grp32, string grp41, string grp42, string grp51, string grp52, string grp61, string grp62, string grp71, string grp72, string grp81, string grp82, string grp91, string grp92, string grp101, string grp102, string typedata, string strsex, string strfield, bool _exportexcel, string _sextype, string _username, string compname)
        {
            InitializeComponent();
            date_b = dateb; dept_b = deptb; dept_e = depte; emp_b = empb;
            emp_e = empe; comp_b = compb; comp_e = compe;
            report_type = reporttype; grp1_1 = grp11; grp1_2 = grp12; grp2_1 = grp21; grp2_2 = grp22;
            grp3_1 = grp31; grp3_2 = grp32; grp4_1 = grp41; grp4_2 = grp42; grp5_1 = grp51; grp5_2 = grp52; grp6_1 = grp61;
            grp6_2 = grp62; grp7_1 = grp71; grp7_2 = grp72; grp8_1 = grp81; grp8_2 = grp82; grp9_1 = grp91; grp9_2 = grp92;
            grp10_1 = grp101; grp10_2 = grp102; type_data = typedata; str_sex = strsex;
            exportexcel = _exportexcel; str_field = strfield; sextype = _sextype; username = _username;
            comp_name = compname;
        }

        private void ZZ17_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlBase = "select a.nobr,b.job_disp as job,b.job_name,di,d.rotet_disp as rotet,rotetname,c.dept_tree from basetts a";
                sqlBase += " left outer join job b on a.job=b.job";
                sqlBase += " left outer join dept c on a.dept=c.d_no";
                sqlBase += " left outer join rotet d on a.rotet=d.rotet";
                sqlBase += string.Format(@" where '{0}' between a.adate and a.ddate", date_b);
                sqlBase += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                DataTable rq_base = SqlConn.GetDataTable(sqlBase);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                DataTable rq_depttree = SqlConn.GetDataTable("select d_no,d_no_disp,d_name from dept");
                rq_depttree.PrimaryKey = new DataColumn[] { rq_depttree.Columns["d_no"] };
                DataTable rq_zz16s1 = new DataTable();                
                decimal str_grp1_1 = Convert.ToDecimal(grp1_1);
                decimal str_grp1_2 = Convert.ToDecimal(grp1_2);
                decimal str_grp2_1 = Convert.ToDecimal(grp2_1);
                decimal str_grp2_2 = Convert.ToDecimal(grp2_2);
                decimal str_grp3_1 = Convert.ToDecimal(grp3_1);
                decimal str_grp3_2 = Convert.ToDecimal(grp3_2);
                decimal str_grp4_1 = Convert.ToDecimal(grp4_1);
                decimal str_grp4_2 = Convert.ToDecimal(grp4_2);
                decimal str_grp5_1 = Convert.ToDecimal(grp5_1);
                decimal str_grp5_2 = Convert.ToDecimal(grp5_2);
                decimal str_grp6_1 = Convert.ToDecimal(grp6_1);
                decimal str_grp6_2 = Convert.ToDecimal(grp6_2);
                decimal str_grp7_1 = Convert.ToDecimal(grp7_1);
                decimal str_grp7_2 = Convert.ToDecimal(grp7_2);
                decimal str_grp8_1 = Convert.ToDecimal(grp8_1);
                decimal str_grp8_2 = Convert.ToDecimal(grp8_2);
                decimal str_grp9_1 = Convert.ToDecimal(grp9_1);
                decimal str_grp9_2 = Convert.ToDecimal(grp9_2);
                decimal str_grp10_1 = Convert.ToDecimal(grp10_1);
                decimal str_grp10_2 = Convert.ToDecimal(grp10_2);
                if (report_type == "0")
                {
                    string sqlCmd1 = "SELECT C.d_no_disp AS DEPTS,H.JOB_DISP AS JOB,B.NOBR,'  ' AS GRP,B.INDT,B.WK_YRS," +
                           "ROUND(DATEDIFF(DAY,A.BIRDT,'" + date_b + "')/365.24,2) AS REL_WK_YRS,A.BIRDT" +
                           ",C.d_no_disp+SPACE(1)+LTRIM(C.D_NAME) AS DEPT,A.NAME_C,A.NAME_E,C.D_NAME,A.SEX,A.SEX,C.d_no_disp AS ITEM" +
                           " FROM BASE A,BASETTS B" +
                           " LEFT OUTER JOIN DEPT C ON B.DEPT=C.D_NO" +
                           " LEFT OUTER JOIN JOB H ON B.JOB=H.JOB" +
                           " WHERE B.NOBR+CONVERT(CHAR,B.ADATE,112) IN (SELECT NOBR+MAX(CONVERT(CHAR,ADATE,112)) FROM BASETTS" +
                           " WHERE ADATE<='" + date_b + "' GROUP BY NOBR)" +
                           " AND A.NOBR=B.NOBR" +                          
                           " AND '" + date_b + "' BETWEEN B.ADATE AND B.DDATE" +
                           " " + str_sex + "" +
                           " AND B.TTSCODE IN ('1','4','6')" +
                           " " + type_data + "" +
                           " AND C.d_no_disp BETWEEN '" + dept_b + "' AND '" + dept_e + "'" +
                           " AND B.EMPCD BETWEEN '" + emp_b + "' AND '" + emp_e + "'" +                          
                           " AND B.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +
                           " AND A.BIRDT is not null" +
                           " ORDER BY C.d_no_disp,B.NOBR";
                    rq_zz16s1 = SqlConn.GetDataTable(sqlCmd1);

                }

                else if (report_type == "1")
                {
                    string sqlCmd3 = "SELECT E.d_no_disp AS DEPTS,C.JOB_DISP+SPACE(1)+LTRIM(C.JOB_NAME) AS DEPT,B.NOBR,'  ' AS GRP,B.INDT,B.WK_YRS," +
                           "ROUND(DATEDIFF(DAY,A.BIRDT,'" + date_b + "')/365.24,2) AS REL_WK_YRS,A.BIRDT" +
                           ",A.NAME_C,A.NAME_E,C.JOB_NAME AS D_NAME,A.SEX,C.JOB_DISP AS ITEM FROM BASE A,BASETTS B" +
                           "  LEFT OUTER JOIN JOB C ON  B.JOB=C.JOB" +
                           "  LEFT OUTER JOIN DEPT D ON  B.DEPT=D.D_NO" +
                           "  LEFT OUTER JOIN DEPTS E ON  B.DEPTS=E.D_NO" +
                           " WHERE B.NOBR+CONVERT(CHAR,B.ADATE,112) IN (SELECT NOBR+MAX(CONVERT(CHAR,ADATE,112)) FROM BASETTS" +
                           " WHERE ADATE<='" + date_b + "' GROUP BY NOBR)" +
                           " AND A.NOBR=B.NOBR" +
                           " AND '" + date_b + "' BETWEEN B.ADATE AND B.DDATE" +                          
                           " " + str_sex + "" +
                           " AND B.TTSCODE IN ('1','4','6')" +
                           " " + type_data + "" +
                           " AND D.d_no_disp BETWEEN '" + dept_b + "' AND '" + dept_e + "'" +
                           " AND B.EMPCD BETWEEN '" + emp_b + "' AND '" + emp_e + "'" +                          
                           " AND B.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +
                           " AND A.BIRDT is not null" +
                           " ORDER BY C.JOB_DISP,B.NOBR";
                    rq_zz16s1 = SqlConn.GetDataTable(sqlCmd3);

                }

                else if (report_type == "2")
                {

                    string sqlCmd5 = "SELECT C.d_no_disp+SPACE(1)+LTRIM(C.D_NAME) AS DEPT,H.JOB_DISP AS JOB,B.NOBR,'  ' AS GRP,B.INDT,B.WK_YRS," +
                            "ROUND(DATEDIFF(DAY,A.BIRDT,'" + date_b + "')/365.24,2) AS REL_WK_YRS,A.BIRDT" +
                            ",A.NAME_C,A.NAME_E,C.D_NAME,A.SEX,C.d_no_disp AS ITEM FROM BASE A,BASETTS B" +
                            "  LEFT OUTER JOIN DEPTS C ON  B.DEPTS=C.D_NO" +
                            "  LEFT OUTER JOIN DEPT D ON  B.DEPT=D.D_NO" +
                            " LEFT OUTER JOIN JOB H ON B.JOB=H.JOB" +
                            " WHERE B.NOBR+CONVERT(CHAR,B.ADATE,112) IN (SELECT NOBR+MAX(CONVERT(CHAR,ADATE,112)) FROM BASETTS" +
                            " WHERE ADATE<='" + date_b + "' GROUP BY NOBR)" +
                            " AND A.NOBR=B.NOBR" +
                            " AND '" + date_b + "' BETWEEN B.ADATE AND B.DDATE" +
                            " " + str_sex + "" +
                            " AND B.TTSCODE IN ('1','4','6')" +
                            " " + type_data + "" +
                            " AND D.d_no_disp BETWEEN '" + dept_b + "' AND '" + dept_e + "'" +
                            " AND B.EMPCD BETWEEN '" + emp_b + "' AND '" + emp_e + "'" +
                            " AND B.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +
                            " AND A.BIRDT is not null" +
                            " ORDER BY B.DEPTS,B.NOBR";
                    rq_zz16s1 = SqlConn.GetDataTable(sqlCmd5);
                }
                
                if (rq_zz16s1.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                foreach (DataRow row in rq_zz16s1.Rows)
                {
                    //年齡-承認年資
                    //row["rel_wk_yrs"] = Convert.ToDecimal(row["rel_wk_yrs"].ToString()) - Convert.ToDecimal(row["wk_yrs"].ToString());
                    decimal str_rel = Convert.ToDecimal(row["rel_wk_yrs"].ToString());
                    if (str_rel > str_grp1_1 && str_rel <= str_grp1_2)
                        row["grp"] = str_grp1_1 + "-" + str_grp1_2;
                    else if (str_rel > str_grp2_1 && str_rel <= str_grp2_2)
                        row["grp"] = str_grp2_1 + "-" + str_grp2_2;
                    else if (str_rel > str_grp3_1 && str_rel <= str_grp3_2)
                        row["grp"] = str_grp3_1 + "-" + str_grp3_2;
                    else if (str_rel > str_grp4_1 && str_rel <= str_grp4_2)
                        row["grp"] = str_grp4_1 + "-" + str_grp4_2;
                    else if (str_rel > str_grp5_1 && str_rel <= str_grp5_2)
                        row["grp"] = str_grp5_1 + "-" + str_grp5_2;
                    else if (str_rel > str_grp6_1 && str_rel <= str_grp6_2)
                        row["grp"] = str_grp6_1 + "-" + str_grp6_2;
                    else if (str_rel > str_grp7_1 && str_rel <= str_grp7_2)
                        row["grp"] = str_grp7_1 + "-" + str_grp7_2;
                    else if (str_rel > str_grp8_1 && str_rel <= str_grp8_2)
                        row["grp"] = str_grp8_1 + "-" + str_grp8_2;
                    else if (str_rel > str_grp9_1 && str_rel <= str_grp9_2)
                        row["grp"] = str_grp9_1 + "-" + str_grp9_2;
                    else if (str_rel > str_grp10_1 && str_rel <= str_grp10_2)
                        row["grp"] = str_grp10_1 + "-" + str_grp10_2;

                }

                DataTable rq_edu = new DataTable();
                rq_edu.Columns.Add("grp", typeof(string));
                rq_edu.PrimaryKey = new DataColumn[] { rq_edu.Columns["grp"] };

                for (int i = 1; i < 11; i++)
                {
                    DataRow aRow = rq_edu.NewRow();
                    if (i == 1) aRow["grp"] = str_grp1_1 + "-" + str_grp1_2;
                    else if (i == 2) aRow["grp"] = str_grp2_1 + "-" + str_grp2_2;
                    else if (i == 3) aRow["grp"] = str_grp3_1 + "-" + str_grp3_2;
                    else if (i == 4) aRow["grp"] = str_grp4_1 + "-" + str_grp4_2;
                    else if (i == 5) aRow["grp"] = str_grp5_1 + "-" + str_grp5_2;
                    else if (i == 6) aRow["grp"] = str_grp6_1 + "-" + str_grp6_2;
                    else if (i == 7) aRow["grp"] = str_grp7_1 + "-" + str_grp7_2;
                    else if (i == 8) aRow["grp"] = str_grp8_1 + "-" + str_grp8_2;
                    else if (i == 9) aRow["grp"] = str_grp9_1 + "-" + str_grp9_2;
                    else if (i == 10) aRow["grp"] = str_grp10_1 + "-" + str_grp10_2;
                    rq_edu.Rows.Add(aRow);
                }

                DataRow aRow1 = rq_edu.NewRow();
                aRow1["grp"] = "合計";
                rq_edu.Rows.Add(aRow1);
                DataRow aRowa1 = rq_edu.NewRow();
                aRowa1["grp"] = "平均";
                rq_edu.Rows.Add(aRowa1);

                DataRow aRow2 = ds.Tables["matrixtitle"].NewRow();
                for (int i = 0; i < rq_edu.Rows.Count; i++)
                {
                    aRow2["Fld" + (i + 1)] = rq_edu.Rows[i]["grp"].ToString();
                }
                ds.Tables["matrixtitle"].Rows.Add(aRow2);

                ds.Tables["rq_zz17td"].PrimaryKey = new DataColumn[] { ds.Tables["rq_zz17td"].Columns["dept"] };
                DataRow[] ORow1 = rq_zz16s1.Select("", "grp asc");
                foreach (DataRow Row in ORow1)
                {
                    DataRow row = ds.Tables["rq_zz17td"].Rows.Find(Row["dept"].ToString());
                    if (row != null)
                    {
                        for (int i = 0; i < rq_edu.Rows.Count; i++)
                        {
                            if (rq_edu.Rows[i]["grp"].ToString().Trim() != "")
                            {
                                if (rq_edu.Rows[i]["grp"].ToString().Trim() == Row["grp"].ToString().Trim())
                                {
                                    row["Fld" + (i + 1)] = int.Parse(row["Fld" + (i + 1)].ToString()) + 1;
                                    row["Fld11"] = int.Parse(row["Fld11"].ToString()) + 1;
                                    row["cnt"] = int.Parse(row["cnt"].ToString()) + 1;
                                    row["total"] = decimal.Parse(row["total"].ToString()) + decimal.Parse(Row["rel_wk_yrs"].ToString());
                                    row["Fld12"] = decimal.Round(decimal.Parse(row["total"].ToString()) / int.Parse(row["cnt"].ToString()), 2);
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        DataRow aRow = ds.Tables["rq_zz17td"].NewRow();
                        aRow["dept"] = Row["dept"].ToString();
                        aRow["d_name"] = Row["d_name"].ToString();
                        for (int i = 0; i < rq_edu.Rows.Count; i++)
                        {
                            if (rq_edu.Rows[i]["grp"].ToString().Trim() != "")
                            {
                                aRow["Fld" + (i + 1)] = 0;
                                if (rq_edu.Rows[i]["grp"].ToString().Trim() == Row["grp"].ToString().Trim())
                                {
                                    aRow["Fld" + (i + 1)] = 1;
                                }
                            }
                            else
                                break;
                        }
                        aRow["Fld11"] = 1;
                        aRow["Fld12"] = decimal.Round(decimal.Parse(Row["rel_wk_yrs"].ToString()), 2);
                        aRow["cnt"] = 1;
                        aRow["total"] = decimal.Parse(Row["rel_wk_yrs"].ToString());
                        ds.Tables["rq_zz17td"].Rows.Add(aRow);
                    }
                }
                rq_edu = null;
                
                //if (report_type == "3")
                //{
                //    //期初人數
                //    _datee = Convert.ToString(DateTime.Parse(date_b).Year - 1) + "/12/31";
                //    string sqlCmd8 = "SELECT B.NOBR,A.NAME_C,B.DEPT,C.D_NAME,'年初人數' AS TYPE," +
                //            "ROUND(DATEDIFF(DAY,A.BIRDT,'" + date_b + "')/365.24,1) AS AGE,B.WORKCD" +
                //            " FROM BASE A,BASETTS B,DEPT C" +
                //            " WHERE B.NOBR+CONVERT(CHAR,B.ADATE,112) IN (SELECT NOBR+MAX(CONVERT(CHAR,ADATE,112)) FROM BASETTS" +
                //            " WHERE '" + _datee + "' BETWEEN ADATE AND DDATE  GROUP BY NOBR)" +
                //            " AND A.NOBR=B.NOBR" +
                //            " AND B.DEPT=C.D_NO" +
                //            " AND B.TTSCODE IN ('1','4','6')" +
                //            " AND '" + _datee + "' BETWEEN B.ADATE AND B.DDATE" +
                //            " " + type_data + "" +
                //            " AND B.DEPT BETWEEN '" + dept_b + "' AND '" + dept_e + "'" +
                //            " AND B.EMPCD BETWEEN '" + emp_b + "' AND '" + emp_e + "'" +
                //            " AND B.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +
                //            " AND A.BIRDT is not null" +
                //            " AND A.COUNT_MA=0" +
                //            " and B.RETCHOO!=''" +
                //            " ORDER BY B.NOBR";
                //    DataTable rq_begin = SqlConn.GetDataTable(sqlCmd8);
                   
                //    //新進人員
                //    string sqlCmd9 = "SELECT B.NOBR,A.NAME_C,B.DEPT,C.D_NAME,'新進人員' AS TYPE," +
                //            "ROUND(DATEDIFF(DAY,A.BIRDT,'" + date_b + "')/365.24,1) AS AGE,B.WORKCD" +
                //            " FROM BASE A,BASETTS B,DEPT C" +
                //            " WHERE A.NOBR=B.NOBR" +
                //            " AND B.NOBR+CONVERT(CHAR,B.ADATE,112) IN (SELECT NOBR+MAX(CONVERT(CHAR,ADATE,112)) FROM BASETTS" +
                //            " WHERE ADATE BETWEEN  '" + _datee + "' AND '" + date_b + "'" +
                //            " AND TTSCODE IN ('1','4') GROUP BY NOBR)" +
                //            " AND B.DEPT=C.D_NO" +
                //            " AND B.ADATE BETWEEN  '" + _datee + "' AND '" + date_b + "'" +
                //            " AND B.TTSCODE IN ('1','4')" +
                //            " " + type_data + "" +
                //            " AND B.DEPT BETWEEN '" + dept_b + "' AND '" + dept_e + "'" +
                //            " AND B.EMPCD BETWEEN '" + emp_b + "' AND '" + emp_e + "'" +
                //            " AND B.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +
                //            " AND A.BIRDT is not null" +
                //             " AND A.COUNT_MA=0" +
                //            " ORDER BY B.NOBR";
                //    DataTable rq_in = SqlConn.GetDataTable(sqlCmd9);

                //    //離職人員
                //    string sqlCmd10 = "SELECT B.NOBR,A.NAME_C,B.DEPT,C.D_NAME,'離職人員' AS TYPE," +
                //            "ROUND(DATEDIFF(DAY,A.BIRDT,'" + date_b + "')/365.24,1) AS AGE,B.WORKCD" +
                //            " FROM BASE A,BASETTS B,DEPT C" +
                //            " WHERE A.NOBR=B.NOBR" +
                //            " AND B.NOBR+CONVERT(CHAR,B.ADATE,112) IN (SELECT NOBR+MAX(CONVERT(CHAR,ADATE,112)) FROM BASETTS" +
                //            " WHERE ADATE BETWEEN  '" + _datee + "' AND '" + date_b + "'" +
                //            " AND TTSCODE IN ('2','3','5') GROUP BY NOBR)" +
                //            " AND B.DEPT=C.D_NO" +
                //            " AND B.ADATE BETWEEN  '" + _datee + "' AND '" + date_b + "'" +
                //            " AND B.TTSCODE IN ('2','3','5')" +
                //            " " + type_data + "" +
                //            " AND B.DEPT BETWEEN '" + dept_b + "' AND '" + dept_e + "'" +
                //            " AND B.EMPCD BETWEEN '" + emp_b + "' AND '" + emp_e + "'" +
                //            " AND B.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +
                //            " AND A.BIRDT is not null" +
                //             " AND A.COUNT_MA=0" +
                //            " ORDER BY B.NOBR";
                //    DataTable rq_out = SqlConn.GetDataTable(sqlCmd10);

                //    foreach (DataRow row in rq_begin.Rows)
                //    {
                //        ds.Tables["rq_zz17"].ImportRow(row);
                //    }

                //    foreach (DataRow row1 in rq_in.Rows)
                //    {
                //        ds.Tables["rq_zz17"].ImportRow(row1);
                //    }

                //    foreach (DataRow row2 in rq_out.Rows)
                //    {
                //        ds.Tables["rq_zz17"].ImportRow(row2);
                //    }

                //    if (ds.Tables["rq_zz17"].Rows.Count < 1)
                //    {
                //        MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                //        this.Close();
                //        return;
                //    }

                //    foreach (DataRow row3 in ds.Tables["rq_zz17"].Rows)
                //    {
                //        decimal str_rel = Convert.ToDecimal(row3["age"].ToString());
                //        if (str_rel > str_grp1_1 && str_rel <= str_grp1_2)
                //            row3["grp"] = str_grp1_1 + "-" + str_grp1_2;
                //        else if (str_rel > str_grp2_1 && str_rel <= str_grp2_2)
                //            row3["grp"] = str_grp2_1 + "-" + str_grp2_2;
                //        else if (str_rel > str_grp3_1 && str_rel <= str_grp3_2)
                //            row3["grp"] = str_grp3_1 + "-" + str_grp3_2;
                //        else if (str_rel > str_grp4_1 && str_rel <= str_grp4_2)
                //            row3["grp"] = str_grp4_1 + "-" + str_grp4_2;
                //        else if (str_rel > str_grp5_1 && str_rel <= str_grp5_2)
                //            row3["grp"] = str_grp5_1 + "-" + str_grp5_2;
                //        else if (str_rel > str_grp6_1 && str_rel <= str_grp6_2)
                //            row3["grp"] = str_grp6_1 + "-" + str_grp6_2;
                //        else if (str_rel > str_grp7_1 && str_rel <= str_grp7_2)
                //            row3["grp"] = str_grp7_1 + "-" + str_grp7_2;
                //        else if (str_rel > str_grp8_1 && str_rel <= str_grp8_2)
                //            row3["grp"] = str_grp8_1 + "-" + str_grp8_2;
                //        else if (str_rel > str_grp9_1 && str_rel <= str_grp9_2)
                //            row3["grp"] = str_grp9_1 + "-" + str_grp9_2;
                //        else if (str_rel > str_grp10_1 && str_rel <= str_grp10_2)
                //            row3["grp"] = str_grp10_1 + "-" + str_grp10_2;
                        
                //    }

                //}               

                if (exportexcel)
                {
                    Export(rq_zz16s1, rq_base,rq_depttree);
                    rq_zz16s1 = null; rq_depttree = null;
                    rq_base = null;
                    this.Close();
                }
                else
                {
                    rq_zz16s1 = null; rq_depttree = null;
                    rq_base = null;              
                    RptViewer.Visible = true;
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "EmpReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "EmpReport", "*.rdlc");

                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz17.rdlc";

                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Fildt", str_field) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("empdata_rq_zz17td", ds.Tables["rq_zz17td"]));
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("empdata_matrixtitle", ds.Tables["matrixtitle"]));
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

        void Export(DataTable DT, DataTable DT1,DataTable DT2)
        {
            DataTable ExporDt = new DataTable();
            if (report_type == "0")
            {
                ExporDt.Columns.Add("報表分析群組", typeof(string));
                ExporDt.Columns.Add("部門代碼", typeof(string));
                ExporDt.Columns.Add("部門名稱", typeof(string));
            }
            else if (report_type == "1")
            {
                ExporDt.Columns.Add("職稱代碼", typeof(string));
                ExporDt.Columns.Add("職稱", typeof(string));
            }
            else 
            {
                ExporDt.Columns.Add("成本代碼", typeof(string));
                ExporDt.Columns.Add("成本名稱", typeof(string));
            }
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            ExporDt.Columns.Add("性別", typeof(string));
            ExporDt.Columns.Add("出生日期", typeof(DateTime));
            ExporDt.Columns.Add("年齡", typeof(decimal));
            if (report_type != "1")
            {
                ExporDt.Columns.Add("職稱代碼", typeof(string));
                ExporDt.Columns.Add("職稱", typeof(string));
            }
            ExporDt.Columns.Add("直間接", typeof(string));
            ExporDt.Columns.Add("輪班代碼", typeof(string));
            ExporDt.Columns.Add("輪班別", typeof(string));
            

            foreach (DataRow Row in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                if (report_type == "0")
                {
                    aRow["部門代碼"] = Row["item"].ToString();
                    aRow["部門名稱"] = Row["d_name"].ToString();
                }
                else if (report_type == "1")
                {
                    aRow["職稱代碼"] = Row["item"].ToString();
                    aRow["職稱"] = Row["d_name"].ToString();
                }
                else 
                {
                    aRow["成本代碼"] = Row["item"].ToString();
                    aRow["成本名稱"] = Row["d_name"].ToString();
                }
                aRow["員工編號"] = Row["nobr"].ToString();
                aRow["員工姓名"] = Row["name_c"].ToString();
                aRow["英文姓名"] = Row["name_e"].ToString();
                aRow["性別"] = Row["sex"].ToString();
                aRow["出生日期"] = DateTime.Parse(Row["birdt"].ToString());
                aRow["年齡"] = decimal.Parse(Row["rel_wk_yrs"].ToString());
                DataRow row1 = DT1.Rows.Find(Row["nobr"].ToString());
                if (row1 != null)
                {
                    if (report_type == "0")
                    {
                        DataRow row6a = DT2.Rows.Find(row1["dept_tree"].ToString());
                        aRow["報表分析群組"] = "";
                        if (row6a != null)
                            aRow["報表分析群組"] = row6a["d_no_disp"].ToString().Trim() + " " + row6a["d_name"].ToString();
                    }
                    if (report_type != "1")
                    {
                        aRow["職稱代碼"] = row1["job"].ToString();
                        aRow["職稱"] = row1["job_name"].ToString();
                    }
                    aRow["直間接"] = row1["di"].ToString();
                    aRow["輪班代碼"] = row1["rotet"].ToString();
                    aRow["輪班別"] = row1["rotetname"].ToString();
                }
                ExporDt.Rows.Add(aRow);
            }

            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
