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
    public partial class ZZ13_Report : JBControls.JBForm
    {
        string date_b, date_e, dept_b, dept_e, emp_b, emp_e, comp_b, comp_e, report_type, date_t, data_report, comp_name;
        string grp1_1, grp1_2, grp2_1, grp2_2, grp3_1, grp3_2, grp4_1, grp4_2, grp5_1, grp5_2, grp6_1, grp6_2, grp7_1, grp7_2, grp8_1, grp8_2;
        bool exportexcel;
        empdata ds = new empdata();
        public ZZ13_Report(string dateb, string datee, string deptb, string depte, string empb, string empe, string compb, string compe, string reporttype, string compname, string datet, string grp11, string grp12, string grp21, string grp22, string grp31, string grp32, string grp41, string grp42, string grp51, string grp52, string grp61, string grp62, string grp71, string grp72, string grp81, string grp82, string datareport, bool _exportexcel)
        {
            InitializeComponent();
            date_b = dateb; date_e = datee; dept_b = deptb; dept_e = depte; emp_b = empb;
            emp_e = empe; comp_b = compb; comp_e = compe;
            report_type = reporttype; date_t = datet; grp1_1 = grp11; grp1_2 = grp12; grp2_1 = grp21; grp2_2 = grp22;
            grp3_1 = grp31; grp3_2 = grp32; grp4_1 = grp41; grp4_2 = grp42; grp5_1 = grp51; grp5_2 = grp52; grp6_1 = grp61;
            grp6_2 = grp62; grp7_1 = grp71; grp7_2 = grp72; grp8_1 = grp81; grp8_2 = grp82;
            exportexcel = _exportexcel; data_report = datareport; comp_name = compname;
        }

        private void ZZ13_Report_Load(object sender, EventArgs e)
        {         
            try
            {               
                DataTable rq_zz13s1 = new DataTable();              
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                DataTable rq_subj = SqlConn.GetDataTable("select subcode,subdesc from subcode");
                rq_subj.PrimaryKey = new DataColumn[] { rq_subj.Columns["subcode"] };
                string sqlCmd0 ="";
                if (report_type == "0")
                {
                    sqlCmd0 = "select c.nobr,f.name_c,f.name_e,b.d_no_disp as dept,b.d_name,f.sex,c.di,g.d_no_disp as depts,g.d_name as ds_name,";
                    sqlCmd0 += "h.job_disp as job,h.job_name,c.indt,i.rotet_disp as rotet,i.rotetname,b.dept_tree";
                    sqlCmd0 += " from base f, basetts c";
                    sqlCmd0 += " left outer join dept b on c.dept=b.d_no";
                    sqlCmd0 += " left outer join depts g on c.depts=g.d_no";
                    sqlCmd0 += " left outer join job h on c.job=h.job";
                    sqlCmd0 += " left outer join rotet i on c.rotet=i.rotet";
                    sqlCmd0 += " where c.nobr=f.nobr ";
                    sqlCmd0 += string.Format(@" and '{0}' between c.adate and c.ddate", date_b);
                    sqlCmd0 += string.Format(@" and b.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                }
                else
                {
                    sqlCmd0 = "select c.nobr,f.name_c,f.name_e,c.job as dept,b.job_name as d_name,f.sex,c.di,b.job_disp as job,b.job_name";
                    sqlCmd0 += ",c.depts,g.d_name as ds_name,c.indt,i.rotet_disp as rotet,i.rotetname,e.dept_tree";
                    sqlCmd0 += " from base f, basetts c";
                    sqlCmd0 += " left outer join job b on c.job=b.job";
                    sqlCmd0 += " left outer join depts g on c.depts=g.d_no";
                    sqlCmd0 += " left outer join dept e on c.dept=e.d_no";
                    sqlCmd0 += " left outer join rotet i on c.rotet=i.rotet";
                    sqlCmd0 += " where c.nobr=f.nobr ";
                    sqlCmd0 += string.Format(@" and '{0}' between c.adate and c.ddate", date_b);
                    sqlCmd0 += string.Format(@" and e.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                }              
                sqlCmd0 += string.Format(@" and c.comp between '{0}' and '{1}'", comp_b, comp_e);
                sqlCmd0 += string.Format(@" and c.empcd between '{0}' and '{1}'", emp_b, emp_e);
                sqlCmd0 += data_report;
                if (report_type=="0")
                    sqlCmd0 += " and c.ttscode in ('1','4','6') order by b.d_no_disp";
                else
                    sqlCmd0 += " and c.ttscode in ('1','4','6') order by b.job_disp";
                DataTable rq_base = new DataTable();
                rq_base = SqlConn.GetDataTable(sqlCmd0);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };
                DataTable rq_depttree = SqlConn.GetDataTable("select d_no,d_no_disp,d_name,dept_tree from dept");
                rq_depttree.PrimaryKey = new DataColumn[] { rq_depttree.Columns["d_no"] };
                date_e = date_b;
                if (report_type == "0")
                {                  
                    string sqlCmd = "SELECT A.NOBR,A.EDUCCODE,B.SORT AS SEQ,'A'+A.EDUCCODE+B.NAME AS EDUDESC" +
                        ",F.d_no_disp AS DEPT,F.D_NAME,D.JOB_DISP AS JOB,D.JOB_NAME" +
                        ",A.SCHL,A.SUBJ,A.SUBJ_DETAIL" +
                        " FROM SCHL A,EDUCODE B,BASE E,BASETTS C " +
                        " LEFT OUTER JOIN JOB D ON C.JOB=D.JOB" +
                        " LEFT OUTER JOIN DEPT F ON C.DEPT=F.D_NO" +
                        " WHERE A.EDUCCODE=B.CODE AND A.NOBR=C.NOBR AND " +
                        "'" + date_e + "' BETWEEN C.ADATE AND C.DDATE AND C.EMPCD BETWEEN " +
                        " '" + emp_b + "' AND '" + emp_e + "' AND C.TTSCODE IN ('1', '4', '6') " +
                        " AND C.NOBR=E.NOBR" +
                        " AND F.d_no_disp BETWEEN '" + dept_b + "' AND '" + dept_e + "'" +                       
                        " AND C.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +                        
                        ""+ data_report+""+
                        "  AND A.NOBR+A.EDUCCODE+CONVERT(CHAR(50),A.AUTO) IN " +
                        "(SELECT MAX(NOBR+A.EDUCCODE+CONVERT(CHAR(50),A.AUTO)) FROM SCHL A GROUP BY A.NOBR) ";
                    rq_zz13s1 = SqlConn.GetDataTable(sqlCmd);
                    rq_zz13s1.PrimaryKey = new DataColumn[] { rq_zz13s1.Columns["nobr"] };
                    if (rq_zz13s1.Rows.Count < 1)
                    {
                        MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                        this.Close();
                        return;
                    }
                }
                else if (report_type == "1")
                {
                    string sqlCmd1 = "SELECT A.NOBR,A.EDUCCODE,B.SORT AS SEQ,'A'+A.EDUCCODE+B.NAME AS EDUDESC" +
                        ",D.JOB_DISP AS DEPT,D.JOB_NAME AS D_NAME" +
                        ",A.SCHL,A.SUBJ,A.SUBJ_DETAIL" +
                        " FROM SCHL A,EDUCODE B,BASE E,BASETTS C " +
                        " LEFT OUTER JOIN JOB D ON C.JOB=D.JOB" +
                        " LEFT OUTER JOIN DEPT F ON C.DEPT=F.D_NO" +
                        " WHERE A.EDUCCODE=B.CODE AND A.NOBR=C.NOBR AND " +
                        " '" + date_e + "' BETWEEN C.ADATE AND C.DDATE AND C.EMPCD BETWEEN " +
                        " '" + emp_b + "' AND '" + emp_e + "' AND C.TTSCODE IN ('1', '4', '6')" +
                        " AND C.NOBR=E.NOBR" +
                        " AND F.d_no_disp BETWEEN '" + dept_b + "' AND '" + dept_e + "'" +                       
                        " AND C.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +                      
                        "" + data_report + "" +
                        "  AND A.NOBR+A.EDUCCODE+CONVERT(CHAR(50),A.AUTO) IN " +
                        " (SELECT MAX(NOBR+A.EDUCCODE+CONVERT(CHAR(50),A.AUTO)) FROM SCHL A GROUP BY A.NOBR) ";
                    rq_zz13s1 = SqlConn.GetDataTable(sqlCmd1);                   
                    rq_zz13s1.PrimaryKey = new DataColumn[] { rq_zz13s1.Columns["nobr"] };
                    if (rq_zz13s1.Rows.Count < 1)
                    {
                        MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                        this.Close();
                        return;
                    }
                }
                else if (report_type == "2")
                {
                    string sqlCmd2 = "SELECT B.NOBR,F.d_no_disp AS DEPT,G.JOB_DISP AS JOB,C.INDT,C.WK_YRS," +
                        "DATEDIFF(DAY,C.INDT,'" + date_e + "') AS REL_WK_YRS,C.DI,B.SEX," +
                        "E.EDUCCODE,D.SORT AS SEQ,'A'+E.EDUCCODE+D.NAME AS EDUDESC,SPACE(10) AS GRP" +
                         ",E.SCHL,E.SUBJ,E.SUBJ_DETAIL" +
                        " FROM BASE B,SCHL E,EDUCODE D,BASETTS C " +                       
                        " LEFT OUTER JOIN DEPT F ON C.DEPT=F.D_NO" +
                        " LEFT OUTER JOIN JOB G ON C.JOB=G.JOB"+
                        " WHERE '" + date_e + "' BETWEEN C.ADATE AND C.DDATE " +
                        " AND C.EMPCD BETWEEN '" + emp_b + "' AND '" + emp_e + "' " +
                        " AND C.TTSCODE IN ('1','4','6') AND C.NOBR=B.NOBR AND C.NOBR=E.NOBR " +
                        " AND C.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +
                        " AND F.d_no_disp BETWEEN '" + dept_b + "' AND '" + dept_e + "'" + 
                        " AND E.EDUCCODE=D.CODE AND E.NOBR+E.EDUCCODE+CONVERT(CHAR(50),E.AUTO) IN " +
                        " (SELECT MAX(C.NOBR+C.EDUCCODE+CONVERT(CHAR(50),C.AUTO)) FROM SCHL C " +
                        " GROUP BY C.NOBR)" +
                        "" + data_report + "";
                    rq_zz13s1 = SqlConn.GetDataTable(sqlCmd2);
                    rq_zz13s1.PrimaryKey = new DataColumn[] { rq_zz13s1.Columns["nobr"] };
                    if (rq_zz13s1.Rows.Count < 1)
                    {
                        MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                        this.Close();
                        return;
                    }

                    string sqlCmd6 = "SELECT B.NOBR,SUM(DATEDIFF(DAY,B.STDT,B.STINDT)) AS DAYS " +
                       " FROM BASE A,BASETTS B" +
                       " LEFT OUTER JOIN DEPT F ON B.DEPT=F.D_NO" +
                       " WHERE A.NOBR=B.NOBR" +
                       " AND B.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +
                       " AND F.d_no_disp BETWEEN '" + dept_b + "' AND '" + dept_e + "'" +
                       " AND B.EMPCD BETWEEN '" + emp_b + "' AND '" + emp_e + "' " +
                       " AND B.ADATE < '" + date_t + "'" +
                       " AND B.STDT is not null AND B.STINDT is not null " +
                       " AND TTSCODE ='4'" +
                       " GROUP BY B.NOBR";
                    DataTable rq_basetts = SqlConn.GetDataTable(sqlCmd6);
                    rq_basetts.PrimaryKey = new DataColumn[] { rq_basetts.Columns["nobr"] };
                    
                    foreach (DataRow row in rq_zz13s1.Rows)
                    {                       
                        DataRow row6 = rq_basetts.Rows.Find(row["nobr"].ToString());
                        if (row6 != null)
                        {
                            row["rel_wk_yrs"] = decimal.Parse(row["rel_wk_yrs"].ToString()) - int.Parse(row6["days"].ToString());
                           
                        }
                        row["rel_wk_yrs"] = decimal.Round(decimal.Parse(row["rel_wk_yrs"].ToString()) / Convert.ToDecimal(365.24), 2);
                        decimal str_rel = decimal.Round(decimal.Parse(row["rel_wk_yrs"].ToString()), 2);
                        //row["rel_wk_yrs"] = str_rel;
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

                        if (str_rel >= str_grp1_1)
                            if (str_rel < str_grp1_2)
                                row["grp"] = row["di"].ToString() + " " + row["sex"].ToString() + " " + "G1" + " " + grp1_1 + "-" + grp1_2;
                            else if (str_rel >= str_grp2_1)
                                if (str_rel < str_grp2_2)
                                    row["grp"] = row["di"].ToString() + " " + row["sex"].ToString() + " " + "G2" + " " + grp2_1 + "-" + grp2_2;
                                else if (str_rel >= str_grp3_1)
                                    if (str_rel < str_grp3_2)
                                        row["grp"] = row["di"].ToString() + " " + row["sex"].ToString() + " " + "G3" + " " + grp3_1 + "-" + grp3_2;
                                    else if (str_rel >= str_grp4_1)
                                        if (str_rel < str_grp4_2)
                                            row["grp"] = row["di"].ToString() + " " + row["sex"].ToString() + " " + "G4" + " " + grp4_1 + "-" + grp4_2;
                                        else if (str_rel >= str_grp5_1)
                                            if (str_rel < str_grp5_2)
                                                row["grp"] = row["di"].ToString() + " " + row["sex"].ToString() + " " + "G5" + " " + grp5_1 + "-" + grp5_2;
                                            else if (str_rel >= str_grp6_1)
                                                if (str_rel < str_grp6_2)
                                                    row["grp"] = row["di"].ToString() + " " + row["sex"].ToString() + " " + "G6" + " " + grp6_1 + "-" + grp6_2;
                                                else if (str_rel >= str_grp7_1)
                                                    if (str_rel < str_grp7_2)
                                                        row["grp"] = row["di"].ToString() + " " + row["sex"].ToString() + " " + "G7" + " " + grp7_1 + "-" + grp7_2;
                                                    else if (str_rel >= str_grp8_1)
                                                        if (str_rel < str_grp8_2)
                                                            row["grp"] = row["di"].ToString() + " " + row["sex"].ToString() + " " + "G8" + " " + grp8_1 + "-" + grp8_2;
                    }
                    rq_basetts = null; 

                    DataTable rq_edu = new DataTable();
                    rq_edu.Columns.Add("edudesc", typeof(string));
                    rq_edu.PrimaryKey = new DataColumn[] { rq_edu.Columns["edudesc"] };

                    

                    DataRow[] ORow = rq_zz13s1.Select("", "educcode asc");
                    foreach (DataRow Row in ORow)
                    {
                        DataRow row = rq_edu.Rows.Find(Row["edudesc"].ToString());
                        if (row == null)
                        {
                            DataRow aRow = rq_edu.NewRow();
                            aRow["edudesc"] = Row["edudesc"].ToString();
                            rq_edu.Rows.Add(aRow);
                        }
                    }
                    
                    DataRow aRow1 = rq_edu.NewRow();
                    aRow1["edudesc"] = "合計";
                    rq_edu.Rows.Add(aRow1);

                    DataRow aRow2 = ds.Tables["matrixtitle"].NewRow();
                    for (int i = 0; i < rq_edu.Rows.Count; i++)
                    {
                        aRow2["Fld" + (i + 1)] = rq_edu.Rows[i]["edudesc"].ToString();
                    }
                    ds.Tables["matrixtitle"].Rows.Add(aRow2);


                    ds.Tables["rq_zz13td"].PrimaryKey = new DataColumn[] { ds.Tables["rq_zz13td"].Columns["dept"] };
                    DataRow[] ORow1 = rq_zz13s1.Select("", "grp asc");
                    foreach (DataRow Row in ORow1)
                    {
                        int _count = 0;
                        DataRow row = ds.Tables["rq_zz13td"].Rows.Find(Row["grp"].ToString());
                        if (row != null)
                        {
                            for (int i = 0; i < rq_edu.Rows.Count; i++)
                            {
                                if (rq_edu.Rows[i]["edudesc"].ToString().Trim() != "")
                                {
                                    if (rq_edu.Rows[i]["edudesc"].ToString().Trim() == Row["edudesc"].ToString().Trim())
                                    {
                                        row["Fld" + (i + 1)] = int.Parse(row["Fld" + (i + 1)].ToString()) + 1;
                                        row["Fld" + rq_edu.Rows.Count] = int.Parse(row["Fld" + rq_edu.Rows.Count].ToString()) + 1;
                                    }
                                }
                                else
                                    break;
                            }
                        }
                        else
                        {                            
                            DataRow aRow = ds.Tables["rq_zz13td"].NewRow();
                            aRow["dept"] = Row["grp"].ToString();
                            aRow["d_name"] = Row["grp"].ToString();
                            for (int i = 0; i < rq_edu.Rows.Count; i++)
                            {
                                if (rq_edu.Rows[i]["edudesc"].ToString().Trim() != "")
                                {
                                    aRow["Fld" + (i + 1)] = 0;
                                    if (rq_edu.Rows[i]["edudesc"].ToString().Trim() == Row["edudesc"].ToString().Trim())
                                    {
                                        aRow["Fld" + (i + 1)] = 1;
                                        _count += 1;
                                    }
                                }
                                else
                                    break;
                            }
                            aRow["Fld" + rq_edu.Rows.Count] = _count;
                            ds.Tables["rq_zz13td"].Rows.Add(aRow);
                        }
                    }                   
                    rq_edu = null;
                    //JBHR.Reports.ReportClass.Export(rq_zz13s1, this.Name);
                }

                if (report_type == "0" || report_type == "1")
                {
                    //未輸入名單
                    DataTable rq_notkeyin = new DataTable();
                    rq_notkeyin.Columns.Add("dept", typeof(string));
                    rq_notkeyin.Columns.Add("d_name", typeof(string));
                    rq_notkeyin.Columns.Add("cnt", typeof(int));
                    rq_notkeyin.PrimaryKey = new DataColumn[] { rq_notkeyin.Columns["dept"] };
                    ds.Tables["rq_zz13td"].PrimaryKey = new DataColumn[] { ds.Tables["rq_zz13td"].Columns["dept"] };
                    foreach (DataRow Row in rq_base.Rows)
                    {
                        DataRow row6a = rq_depttree.Rows.Find(Row["dept_tree"].ToString());
                        Row["dept_tree"] = "";
                        if (row6a != null)
                            Row["dept_tree"] = row6a["d_no_disp"].ToString().Trim() + " " + row6a["d_name"].ToString();
                        DataRow row = rq_zz13s1.Rows.Find(Row["nobr"].ToString());
                        if (row == null)
                        {
                            DataRow row1 = rq_notkeyin.Rows.Find(Row["dept"].ToString());
                            if (row1 != null)
                                row1["cnt"] = int.Parse(row1["cnt"].ToString()) + 1;
                            else
                            {
                                DataRow aRow = rq_notkeyin.NewRow();
                                aRow["dept"] = Row["dept"].ToString();
                                aRow["d_name"] = Row["d_name"].ToString();
                                aRow["cnt"] = 1;
                                rq_notkeyin.Rows.Add(aRow);
                            }
                        }
                    }

                    DataTable rq_edu = new DataTable();
                    rq_edu.Columns.Add("edudesc", typeof(string));
                    rq_edu.PrimaryKey = new DataColumn[] { rq_edu.Columns["edudesc"] };

                    DataRow[] ORow = rq_zz13s1.Select("", "educcode asc");
                    foreach (DataRow Row in ORow)
                    {
                        DataRow row = rq_edu.Rows.Find(Row["edudesc"].ToString());
                        if (row == null)
                        {
                            DataRow aRow = rq_edu.NewRow();
                            aRow["edudesc"] = Row["edudesc"].ToString();
                            rq_edu.Rows.Add(aRow);
                        }
                    }


                    if (rq_notkeyin.Rows.Count > 0)
                    {
                        DataRow aRow = rq_edu.NewRow();
                        aRow["edudesc"] = "未輸入";
                        rq_edu.Rows.Add(aRow);

                        DataRow aRow1 = rq_edu.NewRow();
                        aRow1["edudesc"] = "合計";
                        rq_edu.Rows.Add(aRow1);

                        foreach (DataRow Row in rq_notkeyin.Rows)
                        {
                            int _count1 = 0;
                            DataRow row = ds.Tables["rq_zz13td"].Rows.Find(Row["dept"].ToString());
                            if (row != null)
                            {
                                for (int i = 0; i < rq_edu.Rows.Count; i++)
                                {
                                    if (rq_edu.Rows[i]["edudesc"].ToString().Trim() != "")
                                    {
                                        if (rq_edu.Rows[i]["edudesc"].ToString().Trim() == "未輸入")
                                        {
                                            row["Fld" + (i + 1)] = int.Parse(row["Fld" + (i + 1)].ToString()) + 1;
                                            row["Fld" + rq_edu.Rows.Count] = int.Parse(row["Fld" + rq_edu.Rows.Count].ToString()) + 1;
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                DataRow aRow3 = ds.Tables["rq_zz13td"].NewRow();
                                aRow3["dept"] = Row["dept"].ToString();
                                aRow3["d_name"] = Row["d_name"].ToString();
                                for (int i = 0; i < rq_edu.Rows.Count; i++)
                                {
                                    if (rq_edu.Rows[i]["edudesc"].ToString().Trim() != "")
                                    {
                                        aRow3["Fld" + (i + 1)] = 0;
                                        if (rq_edu.Rows[i]["edudesc"].ToString().Trim() == "未輸入")
                                        {
                                            aRow3["Fld" + (i + 1)] = int.Parse(Row["cnt"].ToString());
                                            _count1 += int.Parse(Row["cnt"].ToString());
                                        }
                                    }
                                    else
                                        break;
                                }
                                aRow3["Fld" + rq_edu.Rows.Count] = _count1;
                                ds.Tables["rq_zz13td"].Rows.Add(aRow3);
                            }
                        }
                    }
                    else
                    {
                        DataRow aRow1a = rq_edu.NewRow();
                        aRow1a["edudesc"] = "合計";
                        rq_edu.Rows.Add(aRow1a);
                    }


                    DataRow aRow2 = ds.Tables["matrixtitle"].NewRow();
                    for (int i = 0; i < rq_edu.Rows.Count; i++)
                    {
                        aRow2["Fld" + (i + 1)] = rq_edu.Rows[i]["edudesc"].ToString();
                    }
                    ds.Tables["matrixtitle"].Rows.Add(aRow2);

                    DataRow[] ORow1 = rq_zz13s1.Select("", "dept asc");
                    foreach (DataRow Row in ORow1)
                    {
                        int _count = 0;
                        DataRow row = ds.Tables["rq_zz13td"].Rows.Find(Row["dept"].ToString());
                        if (row != null)
                        {
                            for (int i = 0; i < rq_edu.Rows.Count; i++)
                            {
                                if (rq_edu.Rows[i]["edudesc"].ToString().Trim() != "")
                                {
                                    if (rq_edu.Rows[i]["edudesc"].ToString().Trim() == Row["edudesc"].ToString().Trim())
                                    {
                                        row["Fld" + (i + 1)] = int.Parse(row["Fld" + (i + 1)].ToString()) + 1;
                                        row["Fld" + rq_edu.Rows.Count] = int.Parse(row["Fld" + rq_edu.Rows.Count].ToString()) + 1;
                                    }
                                }
                                else
                                    break;
                            }
                        }
                        else
                        {
                            DataRow aRow = ds.Tables["rq_zz13td"].NewRow();
                            aRow["dept"] = Row["dept"].ToString();
                            aRow["d_name"] = Row["d_name"].ToString();
                            for (int i = 0; i < rq_edu.Rows.Count; i++)
                            {
                                if (rq_edu.Rows[i]["edudesc"].ToString().Trim() != "")
                                {
                                    aRow["Fld" + (i + 1)] = 0;
                                    if (rq_edu.Rows[i]["edudesc"].ToString().Trim() == Row["edudesc"].ToString().Trim())
                                    {
                                        aRow["Fld" + (i + 1)] = 1;
                                        _count += 1;
                                    }
                                }
                                else
                                    break;
                            }
                            aRow["Fld" + rq_edu.Rows.Count] = _count;
                            ds.Tables["rq_zz13td"].Rows.Add(aRow);
                        }
                    }
                    rq_edu = null;
                    rq_notkeyin = null;
                }
                else
                {
                    foreach (DataRow Row in rq_base.Rows)
                    {
                        DataRow row6a = rq_depttree.Rows.Find(Row["dept_tree"].ToString());
                        Row["dept_tree"] = "";
                        if (row6a != null)
                            Row["dept_tree"] = row6a["d_no_disp"].ToString().Trim() + " " + row6a["d_name"].ToString();
                    }
                }
               
                if (ds.Tables["rq_zz13td"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                rq_depttree = null;

                if (exportexcel)
                {
                    Export(rq_zz13s1, rq_base, rq_subj);
                    rq_base = null; rq_zz13s1 = null; rq_subj = null;
                    this.Close();
                }
                else
                {
                    rq_base = null; rq_zz13s1 = null; rq_subj = null;
                    RptViewer.Visible = true;
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "EmpReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "EmpReport", "*.rdlc");

                    if (report_type == "0")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz13.rdlc";
                    else if (report_type == "1")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz131.rdlc";
                    else if (report_type == "2")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz132.rdlc";

                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("empdata_rq_zz13td", ds.Tables["rq_zz13td"]));
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
            ExporDt.Columns.Add("報表分析群組", typeof(string));
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));     
            ExporDt.Columns.Add("職稱代碼", typeof(string));
            ExporDt.Columns.Add("職稱名稱", typeof(string));
            ExporDt.Columns.Add("性別", typeof(string));
            ExporDt.Columns.Add("到職日期", typeof(DateTime));
            ExporDt.Columns.Add("直間接", typeof(string));
            ExporDt.Columns.Add("教育程度代碼", typeof(string));
            ExporDt.Columns.Add("教育程度", typeof(string));
            ExporDt.Columns.Add("學校", typeof(string));
            ExporDt.Columns.Add("科系代碼", typeof(string));
            ExporDt.Columns.Add("科系名稱", typeof(string));
            ExporDt.Columns.Add("輪班別代碼", typeof(string));
            ExporDt.Columns.Add("輪班別", typeof(string));
            foreach (DataRow Row in DT.Rows)
            {

                DataRow row2 = DT2.Rows.Find(Row["subj"].ToString());
                if (row2 != null)
                    Row["SUBJ_DETAIL"] = row2["subdesc"].ToString();

                DataRow row = DT1.Rows.Find(Row["nobr"].ToString());
                if (row != null)
                {
                    DataRow aRow = ExporDt.NewRow();
                    aRow["員工編號"] = Row["nobr"].ToString();
                    aRow["報表分析群組"] = row["dept_tree"].ToString();
                    aRow["部門代碼"] = row["dept"].ToString();
                    aRow["部門名稱"] = row["d_name"].ToString();                    
                    aRow["員工姓名"] = row["name_c"].ToString();                    
                    aRow["性別"] = row["sex"].ToString();
                    aRow["到職日期"] = DateTime.Parse(row["indt"].ToString());
                    aRow["直間接"] = row["di"].ToString();
                    aRow["職稱代碼"] = row["job"].ToString();
                    aRow["職稱名稱"] = row["job_name"].ToString();
                    aRow["輪班別代碼"] = row["rotet"].ToString();
                    aRow["輪班別"] = row["rotetname"].ToString();
                    aRow["學校"] = Row["schl"].ToString();
                    aRow["教育程度代碼"] = Row["educcode"].ToString();
                    aRow["教育程度"] = Row["edudesc"].ToString().Substring(2, Row["edudesc"].ToString().Length - 2);
                    aRow["科系代碼"] = Row["subj"].ToString();
                    aRow["科系名稱"] = Row["subj_detail"].ToString();
                    ExporDt.Rows.Add(aRow);
                }                
                
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
