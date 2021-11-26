/* ======================================================================================================
 * 功能名稱：部門人力統計表
 * 功能代號：ZZ1E
 * 功能路徑：報表列印 > 人事 > 部門人力統計表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\EmpForm\ZZ1E_Report.cs
 * 功能用途：
 *  
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/03/11    Daniel Chih    Ver 1.0.01     1. 增加條件欄位：【年齡】、【年資】並篩選掉不在區間內的資料
 * 2021/04/20    Daniel Chih    Ver 1.0.02     1. 篩選條件判斷員別、年齡與年資
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/04/20
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
    public partial class ZZ1E_Report : JBControls.JBForm
    {        
        empdata ds = new empdata();
        DataTable rq_zz1es2 = new DataTable();
        string date_b, date_e
            , dept_b, dept_e
            , sex_b, sex_e
            , emp_b, emp_e
            , work_b, work_e
            , comp_b, comp_e
            , job_b, job_e
            , report_type
            , username
            , data_report
            , rotet_b, rotet_e
            , comp_name;
        bool exportexcel;
        decimal seniority_b, seniority_e
            , age_b, age_e;

        public ZZ1E_Report(string dateb, string datee
            , string deptb, string depte
            , string sexb, string sexe
            , string empb, string empe
            , string workb, string worke
            , string compb, string compe
            , string jobb, string jobe
            , string reporttype
            , bool _exportexcel
            , string _username
            , string datareport
            , string rotetb, string rotete
            , string ageb, string agee
            , string seniorityb, string senioritye
            , string compname)
        {
            InitializeComponent();
            date_b = dateb; date_e = datee; dept_b = deptb; dept_e = depte; sex_b = sexb;
            sex_e = sexe; work_b = workb; work_e = worke; comp_b = compb; comp_e = compe;
            job_b = jobb; job_e = jobe; report_type = reporttype;
            exportexcel = _exportexcel; username = _username; data_report = datareport;
            emp_b = empb; emp_e = empe; rotet_b = rotetb; rotet_e = rotete;
            //年資區間
            seniority_b = decimal.Parse(seniorityb); seniority_e = decimal.Parse(senioritye);
            //年齡區間
            age_b = decimal.Parse(ageb); age_e = decimal.Parse(agee);
            comp_name = compname;
        }

        private void ZZ1E_Report_Load(object sender, EventArgs e)
        {
            try
            {                
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                DataTable rq_depttree = SqlConn.GetDataTable("select d_no,d_no_disp,d_name from dept");
                rq_depttree.PrimaryKey = new DataColumn[] { rq_depttree.Columns["d_no"] };
                string sqlCmd = "";
                if (report_type == "0" || report_type == "3" || report_type == "4")
                {
                    if (report_type == "4")
                    {
                        sqlCmd = "select b.nobr,a.name_c,a.name_e,c.d_no_disp as dept,c.d_name,f.job_disp as jobl,f.job_name";
                        sqlCmd += ",b.di,a.count_ma,k.rotet_disp as rotet,a.sex,e.dept_tree";
                        sqlCmd += " , DBO.GETTOTALYEARS(A.NOBR, '" + date_e + "') AS WK_YRS1";
                        sqlCmd += " , DATEDIFF(DAY, A.BIRDT, GETDATE()) / 365.24 AS AGE ";

                        sqlCmd += " from base a INNER JOIN basetts b ON a.nobr=b.nobr ";
                        sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);

                        sqlCmd += " left outer join depts c on  b.depts=c.d_no";
                        sqlCmd += " left outer join jobl d on b.jobl=d.jobl";
                        sqlCmd += " left outer join dept e on  b.dept=e.d_no";
                        sqlCmd += " left outer join job f on b.job=f.job";
                        sqlCmd += " left outer join rotet k on b.rotet=k.rotet";

                        sqlCmd += " where 1 = 1";
                        sqlCmd += string.Format(@" and e.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                    }
                    else
                    {
                        sqlCmd = "select b.nobr,a.name_c,a.name_e,c.d_no_disp as dept,c.d_name,d.jobl_disp as jobl,d.job_name as jobl_name";
                        sqlCmd += ",b.di,a.count_ma,k.rotet_disp as rotet,a.sex,f.job_disp as job,f.job_name,c.dept_tree";
                        sqlCmd += " , DBO.GETTOTALYEARS(A.NOBR, '" + date_e + "') AS WK_YRS1";
                        sqlCmd += " , DATEDIFF(DAY, A.BIRDT, GETDATE()) / 365.24 AS AGE ";

                        sqlCmd += " from base a INNER JOIN basetts b ON a.nobr=b.nobr ";
                        sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);

                        sqlCmd += " left outer join jobl d on b.jobl=d.jobl";
                        sqlCmd += " left outer join dept c on  b.dept=c.d_no";
                        sqlCmd += " left outer join job f on b.job=f.job";
                        sqlCmd += " left outer join rotet k on b.rotet=k.rotet";

                        sqlCmd += " where 1 = 1 ";
                        sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                    }
                   
                    sqlCmd += string.Format(@" and a.sex between '{0}' and '{1}'", sex_b, sex_e);
                    sqlCmd += string.Format(@" and b.comp between '{0}' and '{1}'", comp_b, comp_e);
                    sqlCmd += string.Format(@" and f.job_disp between '{0}' and '{1}'", job_b, job_e);
                    sqlCmd += string.Format(@" and k.rotet_disp between '{0}' and '{1}'", rotet_b, rotet_e);
                    sqlCmd += string.Format(@" and b.workcd between '{0}' and '{1}'", work_b, work_e);
                    sqlCmd += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);
                    sqlCmd += data_report;
                    sqlCmd += " and b.ttscode in ('1','4','6')";
                    if (report_type=="4")
                        sqlCmd += " order by c.d_no_disp,f.job_disp";
                    else
                        sqlCmd += " order by c.d_no_disp,d.jobl_disp";
                    
                    DataTable rq_zz1e = SqlConn.GetDataTable(sqlCmd);

                    //移除不符合年齡與年資區間的資料 - Added By Daniel Chih - 2021/03/11
                    foreach (DataRow Row in rq_zz1e.Rows)
                    {
                        decimal _age = decimal.Parse(Row["age"].ToString());
                        //decimal _wkyrs1 = decimal.Parse(Row["wk_yrs1"].ToString()) / Convert.ToDecimal(365.24);
                        decimal _wkyrs1 = decimal.Parse(Row["wk_yrs1"].ToString());
                        if (_age < age_b || _age > age_e || _wkyrs1 < seniority_b || _wkyrs1 > seniority_e)
                        {
                            Row.Delete();
                        }
                    }
                    rq_zz1e.AcceptChanges();


                    if (rq_zz1e.Rows.Count < 1)
                    {
                        MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                        this.Close();
                        return;
                    }
                    if (report_type == "0" || report_type == "4")
                    {
                        ds.Tables["rq_zz1e"].PrimaryKey = new DataColumn[] { ds.Tables["rq_zz1e"].Columns["dept"], ds.Tables["rq_zz1e"].Columns["jobl"] };
                        foreach (DataRow Row in rq_zz1e.Rows)
                        {
                            object[] _value = new object[2];
                            _value[0] = Row["dept"].ToString();
                            _value[1] = Row["jobl"].ToString();
                            DataRow row = ds.Tables["rq_zz1e"].Rows.Find(_value);
                            if (row != null)
                            {
                                if (bool.Parse(Row["count_ma"].ToString()))
                                    row["p_f"] = int.Parse(row["p_f"].ToString()) + 1;
                                else
                                {
                                    if (Row["di"].ToString().Trim() == "D") row["p_d"] = int.Parse(row["p_d"].ToString()) + 1;
                                    if (Row["di"].ToString().Trim() == "I") row["p_i"] = int.Parse(row["p_i"].ToString()) + 1;
                                    if (Row["di"].ToString().Trim() == "S") row["p_s"] = int.Parse(row["p_s"].ToString()) + 1;
                                }
                               
                            }
                            else
                            {
                                DataRow row1 = rq_depttree.Rows.Find(Row["dept_tree"].ToString());
                                DataRow aRow = ds.Tables["rq_zz1e"].NewRow();
                                aRow["dept_tree"] = (row1 != null) ? row1["d_no_disp"].ToString().Trim() + " " + row1["d_name"].ToString() : "";
                                aRow["dept"] = Row["dept"].ToString();
                                aRow["d_name"] = Row["d_name"].ToString();
                                aRow["jobl"] = Row["jobl"].ToString();
                                if (report_type == "0")
                                    aRow["job_name"] = Row["jobl_name"].ToString();
                                else
                                    aRow["job_name"] = Row["job_name"].ToString();
                                if (bool.Parse(Row["count_ma"].ToString()))
                                {
                                    aRow["p_f"] = 1;
                                    aRow["p_i"] = 0;
                                    aRow["p_d"] = 0;
                                    aRow["p_s"] = 0;
                                }
                                else
                                {
                                    aRow["p_f"] = 0;
                                    if (Row["di"].ToString().Trim() == "D")
                                        aRow["p_d"] = 1;
                                    else
                                        aRow["p_d"] = 0;
                                    if (Row["di"].ToString().Trim() == "I")
                                        aRow["p_i"] = 1;
                                    else
                                        aRow["p_i"] = 0;

                                    if (Row["di"].ToString().Trim() == "S")
                                        aRow["p_s"] = 1;
                                    else
                                        aRow["p_s"] = 0;
                                }                                
                                ds.Tables["rq_zz1e"].Rows.Add(aRow);
                            }
                        }
                    }
                    else
                    {
                        ds.Tables["rq_zz1e3"].PrimaryKey = new DataColumn[] { ds.Tables["rq_zz1e3"].Columns["dept"], ds.Tables["rq_zz1e3"].Columns["jobl"] };
                        foreach (DataRow Row in rq_zz1e.Rows)
                        {
                            object[] _value = new object[2];
                            _value[0] = Row["dept"].ToString();
                            _value[1] = Row["job"].ToString();
                            DataRow row = ds.Tables["rq_zz1e3"].Rows.Find(_value);
                            if (row != null)
                            {
                                if (Row["di"].ToString().Trim() == "D")
                                {
                                    if (Row["sex"].ToString().Trim() == "F") row["d_f"] = int.Parse(row["d_f"].ToString()) + 1;
                                    if (Row["sex"].ToString().Trim() == "M") row["d_m"] = int.Parse(row["d_m"].ToString()) + 1;
                                }
                                if (Row["di"].ToString().Trim() == "I")
                                {
                                    if (Row["sex"].ToString().Trim() == "F") row["i_f"] = int.Parse(row["i_f"].ToString()) + 1;
                                    if (Row["sex"].ToString().Trim() == "M") row["i_m"] = int.Parse(row["i_m"].ToString()) + 1;
                                }
                                if (Row["di"].ToString().Trim() == "S")
                                {
                                    if (Row["sex"].ToString().Trim() == "F") row["s_f"] = int.Parse(row["s_f"].ToString()) + 1;
                                    if (Row["sex"].ToString().Trim() == "M") row["s_m"] = int.Parse(row["s_m"].ToString()) + 1;
                                }
                                row["tol"] = int.Parse(row["tol"].ToString()) + 1;
                            }
                            else
                            {
                                DataRow aRow = ds.Tables["rq_zz1e3"].NewRow();
                                aRow["dept"] = Row["dept"].ToString();
                                aRow["d_name"] = Row["d_name"].ToString();
                                aRow["jobl"] = Row["job"].ToString();
                                aRow["job_name"] = Row["job_name"].ToString();
                                if (Row["di"].ToString().Trim() == "D")
                                {
                                    if (Row["sex"].ToString().Trim() == "F")
                                        aRow["d_f"] = 1;
                                    else
                                        aRow["d_f"] =0;

                                    if (Row["sex"].ToString().Trim() == "M")
                                        aRow["d_m"] = 1;
                                    else
                                        aRow["d_m"] = 0;
                                }
                                else
                                {
                                    aRow["d_f"] = 0;
                                    aRow["d_m"] = 0;
                                }
                                if (Row["di"].ToString().Trim() == "I")
                                {
                                    if (Row["sex"].ToString().Trim() == "F")
                                        aRow["i_f"] = 1;
                                    else
                                        aRow["i_f"] = 0;

                                    if (Row["sex"].ToString().Trim() == "M")
                                        aRow["i_m"] = 1;
                                    else
                                        aRow["i_m"] = 0;
                                }
                                else
                                {
                                    aRow["i_f"] = 0;
                                    aRow["i_m"] = 0;
                                }

                                if (Row["di"].ToString().Trim() == "S")
                                {
                                    if (Row["sex"].ToString().Trim() == "F")
                                        aRow["s_f"] = 1;
                                    else
                                        aRow["s_f"] = 0;

                                    if (Row["sex"].ToString().Trim() == "M")
                                        aRow["s_m"] = 1;
                                    else
                                        aRow["s_m"] = 0;
                                }
                                else
                                {
                                    aRow["s_f"] = 0;
                                    aRow["s_m"] = 0;
                                }
                                aRow["tol"] = 1;                               
                                ds.Tables["rq_zz1e3"].Rows.Add(aRow);
                            }
                        }
                    }
                }
                else if (report_type == "1")
                {                   
                    ds.Tables["rq_zz1e1"].PrimaryKey = new DataColumn[] { ds.Tables["rq_zz1e1"].Columns["dept"] };
                    int _b = DateTime.Parse(date_b).Month;
                    int _e = DateTime.Parse(date_e).Month;
                   
                    DataRow aRow = ds.Tables["rq_zz1e1t"].NewRow();
                    int j = 1;
                    for (int i = _b; i <= _e; i++)
                    {
                        string _bdate = Convert.ToString(DateTime.Parse(date_b).Year) + "/" + Convert.ToString(DateTime.Parse(date_b).Month).PadLeft(2, '0') + "/01";
                        string _edate = Convert.ToString(DateTime.Parse(date_e).Year) + "/" + Convert.ToString(DateTime.Parse(date_e).Month).PadLeft(2, '0') + "/01";
                        string _bdate1 = DateTime.Parse(_bdate).AddMonths(j).AddDays(-1).ToString("yyyy/MM/dd");                       
                        string _edate1 = DateTime.Parse(_edate).AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd");
                        
                        if (Convert.ToDecimal(DateTime.Parse(_bdate1).ToString("yyyyMMdd")) <= Convert.ToDecimal(DateTime.Parse(_edate1).ToString("yyyyMMdd")))
                        {
                            string sqlCmd1 = "select c.d_no_disp as dept,c.dept_tree,c.d_name,b.di,count(b.nobr) as perno";
                            //sqlCmd1 += " , DBO.GETTOTALYEARS(A.NOBR, '" + date_e + "') AS WK_YRS1";
                            //sqlCmd1 += " , DATEDIFF(DAY, A.BIRDT, GETDATE()) / 365.24 AS AGE ";
                            sqlCmd1 += " from base a,basetts b ";
                            sqlCmd1 += " left outer join dept c on b.dept=c.d_no ";
                            sqlCmd1 += " left outer join rotet k on b.rotet=k.rotet";
                            sqlCmd1 += " left outer join job f on b.job=f.job";
                            sqlCmd1 += " where a.nobr=b.nobr ";
                            sqlCmd1 += string.Format(@" and '{0}' between b.adate and b.ddate", _bdate1);
                            sqlCmd1 += string.Format(@" and a.sex between '{0}' and '{1}'", sex_b, sex_e);
                            sqlCmd1 += string.Format(@" and (DATEDIFF(DAY, A.BIRDT, GETDATE()) / 365.24) between '{0}' and '{1}'", age_b, age_e);
                            sqlCmd1 += string.Format(@" and (DBO.GETTOTALYEARS(A.NOBR, '" + date_e + "')) between '{0}' and '{1}'", seniority_b, seniority_e);
                            sqlCmd1 += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                            sqlCmd1 += string.Format(@" and b.comp between '{0}' and '{1}'", comp_b, comp_e);
                            sqlCmd1 += string.Format(@" and f.job_disp between '{0}' and '{1}'", job_b, job_e);
                            sqlCmd1 += string.Format(@" and k.rotet_disp between '{0}' and '{1}'", rotet_b, rotet_e);
                            sqlCmd1 += string.Format(@" and b.workcd between '{0}' and '{1}'", work_b, work_e);
                            sqlCmd1 += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);
                            sqlCmd1 += data_report;
                            sqlCmd1 += " and b.ttscode in ('1','4','6')";
                            sqlCmd1 += " group by c.d_no_disp,c.dept_tree,c.d_name,b.di order by c.d_no_disp,di";
                            DataTable rq_zz1e = SqlConn.GetDataTable(sqlCmd1);


                            ////移除不符合年齡與年資區間的資料 - Added By Daniel Chih - 2021/04/20
                            //foreach (DataRow Row in rq_zz1e.Rows)
                            //{
                            //    decimal _age = decimal.Parse(Row["age"].ToString());
                            //    //decimal _wkyrs1 = decimal.Parse(Row["wk_yrs1"].ToString()) / Convert.ToDecimal(365.24);
                            //    decimal _wkyrs1 = decimal.Parse(Row["wk_yrs1"].ToString());
                            //    if (_age < age_b || _age > age_e || _wkyrs1 < seniority_b || _wkyrs1 > seniority_e)
                            //    {
                            //        Row.Delete();
                            //    }
                            //}
                            //rq_zz1e.AcceptChanges();


                            foreach (DataRow Row in rq_zz1e.Rows)
                            {
                                DataRow row4 = rq_depttree.Rows.Find(Row["dept_tree"].ToString());
                                if (Row["di"].ToString().Trim() == "D")
                                {
                                    Row["di"] = "直接";
                                    aRow["Fld" + j] = _bdate1 + "直接";
                                    DataRow row = ds.Tables["rq_zz1e1"].Rows.Find(Row["dept"].ToString());
                                    if (row != null)
                                        row["Fld" + j] = int.Parse(Row["perno"].ToString());
                                    else
                                    {
                                        DataRow aRow1 = ds.Tables["rq_zz1e1"].NewRow();
                                        aRow1["dept_tree"] = (row4 != null) ? row4["d_no_disp"].ToString().Trim() + " " + row4["d_name"].ToString() : "";
                                        aRow1["dept"] = Row["dept"].ToString();
                                        aRow1["d_name"] = Row["d_name"].ToString();
                                        aRow1["Fld" + j] = int.Parse(Row["perno"].ToString());
                                        ds.Tables["rq_zz1e1"].Rows.Add(aRow1);
                                    }
                                }
                                else if (Row["di"].ToString().Trim() == "I")
                                {
                                    Row["di"] = "間接";
                                    aRow["Fli" + j] = _bdate1 + "間接";
                                    DataRow row = ds.Tables["rq_zz1e1"].Rows.Find(Row["dept"].ToString());
                                    if (row != null)
                                        row["Fli" + j] = int.Parse(Row["perno"].ToString());
                                    else
                                    {
                                        DataRow aRow1 = ds.Tables["rq_zz1e1"].NewRow();
                                        aRow1["dept_tree"] = (row4 != null) ? row4["d_no_disp"].ToString().Trim() + " " + row4["d_name"].ToString() : "";
                                        aRow1["dept"] = Row["dept"].ToString();
                                        aRow1["d_name"] = Row["d_name"].ToString();
                                        aRow1["Fli" + j] = int.Parse(Row["perno"].ToString());
                                        ds.Tables["rq_zz1e1"].Rows.Add(aRow1);
                                    }
                                }
                                
                            }
                            j++;
                        }
                        _bdate1 = DateTime.Parse(_bdate1).AddMonths(j+1).ToString("yyyy/MM/dd");                       
                    }
                    ds.Tables["rq_zz1e1t"].Rows.Add(aRow);

                    //DataTable rq_test = new DataTable();
                    //rq_test.Merge(ds.Tables["rq_zz1e1t"]);
                    //JBHR.Reports.ReportClass.Export(rq_test, this.Name);

                    if (ds.Tables["rq_zz1e1"].Rows.Count < 1)
                    {
                        MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                        this.Close();
                        return;
                    }
                    
                }
                else if (report_type == "2")
                {
                    ds.Tables["rq_zz1e2"].PrimaryKey = new DataColumn[] { ds.Tables["rq_zz1e2"].Columns["dept"], ds.Tables["rq_zz1e2"].Columns["di"] };
                    int _b = DateTime.Parse(date_b).Month;
                    int _e = DateTime.Parse(date_e).Month;                    
                    string _bdate = Convert.ToString(DateTime.Parse(date_b).Year) + "/" + Convert.ToString(DateTime.Parse(date_b).Month).PadLeft(2, '0') + "/01";
                    string _edate = Convert.ToString(DateTime.Parse(date_e).Year) + "/" + Convert.ToString(DateTime.Parse(date_e).Month).PadLeft(2, '0') + "/01";
                    string _bdate1 = DateTime.Parse(_bdate).AddDays(-1).ToString("yyyy/MM/dd");
                    string _edate1 = DateTime.Parse(_edate).AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd");
                    DataTable rq_dept = new DataTable();
                    rq_dept.Columns.Add("dept", typeof(string));
                    rq_dept.Columns.Add("di", typeof(string));
                    rq_dept.PrimaryKey = new DataColumn[] { rq_dept.Columns["dept"], rq_dept.Columns["di"] };

                    for (int i = _b; i <= _e; i++)
                    {
                        string _m = Convert.ToString(DateTime.Parse(_bdate1).Month).PadLeft(2, '0');
                        if (Convert.ToDecimal(DateTime.Parse(_bdate1).ToString("yyyyMMdd")) <= Convert.ToDecimal(DateTime.Parse(_edate1).ToString("yyyyMMdd")))
                        {
                            string sqlCmd2 = "select c.d_no_disp as dept,c.d_name,b.di,count(b.nobr) as perno," + _m + " as tdate";
                            sqlCmd2 += " from base a INNER JOIN basetts b ON a.nobr=b.nobr ";
                            sqlCmd2 += " left outer join dept c on b.dept=c.d_no ";
                            sqlCmd2 += " left outer join rotet k on b.rotet=k.rotet";
                            sqlCmd2 += " where 1 = 1 ";
                            sqlCmd2 += string.Format(@" and '{0}' between b.adate and b.ddate", _bdate1);
                            sqlCmd2 += string.Format(@" and a.sex between '{0}' and '{1}'", sex_b, sex_e);
                            sqlCmd2 += string.Format(@" and (DATEDIFF(DAY, A.BIRDT, GETDATE()) / 365.24) between '{0}' and '{1}'", age_b, age_e);
                            sqlCmd2 += string.Format(@" and (DBO.GETTOTALYEARS(A.NOBR, '" + date_e + "')) between '{0}' and '{1}'", seniority_b, seniority_e);
                            sqlCmd2 += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                            sqlCmd2 += string.Format(@" and b.comp between '{0}' and '{1}'", comp_b, comp_e);
                            sqlCmd2 += string.Format(@" and b.job between '{0}' and '{1}'", job_b, job_e);
                            sqlCmd2 += string.Format(@" and k.rotet_disp between '{0}' and '{1}'", rotet_b, rotet_e);
                            sqlCmd2 += string.Format(@" and b.workcd between '{0}' and '{1}'", work_b, work_e);
                            sqlCmd2 += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);
                            sqlCmd2 += data_report;
                            sqlCmd2 += " and b.ttscode in ('1','4','6')";
                            sqlCmd2 += " group by c.d_no_disp,b.di,c.d_name order by c.d_no_disp";
                            DataTable rq_zz1e = SqlConn.GetDataTable(sqlCmd2);
                            foreach (DataRow Row in rq_zz1e.Rows)
                            {
                                string str_di = "";
                                if (Row["di"].ToString().Trim() == "D")
                                    str_di = "直接";
                                else if (Row["di"].ToString().Trim() == "I")
                                    str_di = "間接";

                                object[] _value = new object[2];
                                _value[0] = Row["dept"].ToString();
                                _value[1] = str_di;
                                DataRow row = ds.Tables["rq_zz1e2"].Rows.Find(_value);
                                if (row != null)
                                    row["Fld" + i] = int.Parse(Row["perno"].ToString());
                                else
                                {
                                    DataRow aRow1 = ds.Tables["rq_zz1e2"].NewRow();
                                    aRow1["dept"] = Row["dept"].ToString();
                                    aRow1["d_name"] = Row["d_name"].ToString();
                                    aRow1["di"] = str_di;
                                    aRow1["Fld" + i] = (Row.IsNull("perno")) ? 0 : int.Parse(Row["perno"].ToString());
                                    ds.Tables["rq_zz1e2"].Rows.Add(aRow1);
                                }

                                DataRow row1 = rq_dept.Rows.Find(_value);
                                if (row1 == null)
                                {
                                    DataRow aRow = rq_dept.NewRow();
                                    aRow["dept"] = Row["dept"].ToString();
                                    aRow["di"] = str_di;
                                    rq_dept.Rows.Add(aRow);
                                }
                            }
                            rq_zz1e.Clear();
                        }
                        _bdate1 = DateTime.Parse(_bdate1).AddMonths(1).ToString("yyyy/MM/dd");                       
                    }                   

                    foreach (DataRow Row in rq_dept.Rows)
                    {
                        object[] _value = new object[2];
                        _value[0] = Row["dept"].ToString();
                        _value[1] = Row["di"].ToString();
                        DataRow row = ds.Tables["rq_zz1e2"].Rows.Find(_value);
                       
                        if (row!=null)
                        {
                            for (int i = 1; i <= 11; i++)
                            {
                                int str1 = 0;
                                int str2 = 0;
                                if (row.IsNull("Fld" + (i + 1)))
                                    str2 = 0;
                                else
                                    str2 = int.Parse(row["Fld" + (i + 1)].ToString());

                                if (row.IsNull("Fld" + i))
                                {
                                    row["Fld" + i] = 0;
                                    str1 = 0;
                                }
                                else
                                    str1 = int.Parse(row["Fld" + i].ToString());
                                if (i!=_e)
                                    row["Fld" + i] = str2 - str1;                                
                            }
                        }                        
                    }
                    rq_dept = null;                    

                    if (ds.Tables["rq_zz1e2"].Rows.Count < 1)
                    {
                        MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                        this.Close();
                        return;
                    }

                }

                if (exportexcel)
                {
                    RptViewer.Visible = false;
                    if (report_type == "0" || report_type == "4")
                        Export(ds.Tables["rq_zz1e"]);
                    else if (report_type == "1")
                        Export1(ds.Tables["rq_zz1e1"], ds.Tables["rq_zz1e1t"]);
                    else if (report_type == "2")
                        Export(ds.Tables["rq_zz1e2"]);
                    else if (report_type == "3")
                        Export(ds.Tables["rq_zz1e3"]);
                    this.Close();
                }
                else
                {
                    RptViewer.Visible = true;
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "EmpReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "EmpReport", "*.rdlc");
                    
                    if (report_type == "0")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz1E.rdlc";
                    if (report_type == "1")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz1E1.rdlc";
                    if (report_type == "2")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz1E2.rdlc";
                    if (report_type == "3")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz1E3.rdlc";
                    if (report_type == "4")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz1E4.rdlc";
                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    if (report_type == "0" || report_type == "4")
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("empdata_rq_zz1e", ds.Tables["rq_zz1e"]));
                    else if (report_type == "1")
                    {
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("empdata_rq_zz1e1", ds.Tables["rq_zz1e1"]));
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("empdata_rq_zz1e1t", ds.Tables["rq_zz1e1t"]));
                    }
                    else if (report_type == "2")
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("empdata_rq_zz1e2", ds.Tables["rq_zz1e2"]));
                    else if (report_type == "3")
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("empdata_rq_zz1e3", ds.Tables["rq_zz1e3"]));

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
            if (report_type == "0" || report_type == "4")
            {
                if (report_type == "4")
                {
                    ExporDt.Columns.Add("成本部門代碼", typeof(string));
                    ExporDt.Columns.Add("成本部門名稱", typeof(string));
                    ExporDt.Columns.Add("職稱代碼", typeof(string));
                    ExporDt.Columns.Add("職稱名稱", typeof(string));
                }
                else
                {
                    ExporDt.Columns.Add("報表分析群組", typeof(string));
                    ExporDt.Columns.Add("部門代碼", typeof(string));
                    ExporDt.Columns.Add("部門名稱", typeof(string));
                }
                if (report_type != "4")
                {
                    ExporDt.Columns.Add("職等代碼", typeof(string));
                    ExporDt.Columns.Add("職等名稱", typeof(string));
                }
                ExporDt.Columns.Add("人數(A+B+C)", typeof(int));
                //ExporDt.Columns.Add("研發(A)", typeof(int));
                ExporDt.Columns.Add("間接(A)", typeof(int));
                ExporDt.Columns.Add("直接(B)", typeof(int));
                ExporDt.Columns.Add("外勞(C)", typeof(int));

                foreach (DataRow Row in DT.Rows)
                {
                    DataRow aRow = ExporDt.NewRow();
                    if (report_type == "4")
                    {
                        aRow["成本部門代碼"] = Row["dept"].ToString();
                        aRow["成本部門名稱"] = Row["d_name"].ToString();
                        aRow["職稱代碼"] = Row["jobl"].ToString();
                        aRow["職稱名稱"] = Row["job_name"].ToString();
                    }
                    else
                    {
                        aRow["報表分析群組"] = Row["dept_tree"].ToString();
                        aRow["部門代碼"] = Row["dept"].ToString();
                        aRow["部門名稱"] = Row["d_name"].ToString();
                    }
                    if (report_type != "4")
                    {
                        aRow["職等代碼"] = Row["jobl"].ToString();
                        aRow["職等名稱"] = Row["job_name"].ToString();
                    }
                    aRow["人數(A+B+C)"] = int.Parse(Row["p_i"].ToString()) + int.Parse(Row["p_d"].ToString()) + int.Parse(Row["p_s"].ToString()) + int.Parse(Row["p_f"].ToString());
                    //aRow["研發(A)"] = int.Parse(Row["p_s"].ToString());
                    aRow["間接(A)"] = int.Parse(Row["p_i"].ToString());
                    aRow["直接(B)"] = int.Parse(Row["p_d"].ToString());
                    aRow["外勞(C)"] = int.Parse(Row["p_f"].ToString());
                    ExporDt.Rows.Add(aRow);
                }
            }
            else if (report_type == "2")
            {
                ExporDt.Columns.Add("部門代碼", typeof(string));
                ExporDt.Columns.Add("部門名稱", typeof(string));
                for (int i=1;i <=12;i++)
                {
                    ExporDt.Columns.Add(i + "月", typeof(int));
                }
               
                foreach (DataRow Row in DT.Rows)
                {
                    DataRow aRow = ExporDt.NewRow();
                    aRow["部門代碼"] = Row["dept"].ToString();
                    aRow["部門名稱"] = Row["d_name"].ToString();
                    for (int i = 1; i <= 12; i++)
                    {
                        if (!Row.IsNull("Fld" + i.ToString()))
                            aRow[i + "月"] = int.Parse(Row["Fld" + i].ToString());
                        else
                            aRow[i + "月"] = 0;
                    }
                    ExporDt.Rows.Add(aRow);
                }
            }
            else if (report_type == "3")
            {
                ExporDt.Columns.Add("部門代碼", typeof(string));
                ExporDt.Columns.Add("部門名稱", typeof(string));
                ExporDt.Columns.Add("職稱代碼", typeof(string));
                ExporDt.Columns.Add("職稱", typeof(string));
                ExporDt.Columns.Add("總人數", typeof(int));
                ExporDt.Columns.Add("直接男生", typeof(int));
                ExporDt.Columns.Add("直接女生", typeof(int));
                ExporDt.Columns.Add("間接男生", typeof(int));
                ExporDt.Columns.Add("間接女生", typeof(int));                
                foreach (DataRow Row in DT.Rows)
                {
                    DataRow aRow = ExporDt.NewRow();
                    aRow["部門代碼"] = Row["dept"].ToString();
                    aRow["部門名稱"] = Row["d_name"].ToString();
                    aRow["職稱代碼"] = Row["jobl"].ToString();
                    aRow["職稱"] = Row["job_name"].ToString();
                    aRow["總人數"] = int.Parse(Row["tol"].ToString());
                    aRow["直接男生"] = int.Parse(Row["d_m"].ToString());
                    aRow["直接女生"] = int.Parse(Row["d_f"].ToString());
                    aRow["間接男生"] = int.Parse(Row["i_m"].ToString());
                    aRow["間接女生"] = int.Parse(Row["i_f"].ToString());                   
                    ExporDt.Rows.Add(aRow);
                }
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }

        void Export1(DataTable DT, DataTable DT1)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("報表分析群組", typeof(string));
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));           
            for (int i = 0; i < DT1.Columns.Count; i++)
            {
                string adfda = DT1.Rows[0][i].ToString().Trim();
                if (DT1.Rows[0][i].ToString().Trim() != "")
                     ExporDt.Columns.Add(DT1.Rows[0][i].ToString().Trim(), typeof(int));
                //else
                //    break;
            }
            ExporDt.Columns.Add("合計", typeof(int));
            foreach (DataRow Row in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["報表分析群組"] = Row["dept_tree"].ToString();
                aRow["部門代碼"] = Row["dept"].ToString();
                aRow["部門名稱"] = Row["d_name"].ToString();
                aRow["合計"] = 0;
                for (int i = 0; i < DT1.Columns.Count; i++)
                {
                    if (DT1.Rows[0]["Fld" + (i + 1)].ToString().Trim() != "" || DT1.Rows[0]["Fli" + (i + 1)].ToString().Trim() != "")
                    {
                        if (DT1.Rows[0]["Fld" + (i + 1)].ToString().Trim() != "")
                        {
                            aRow[DT1.Rows[0]["Fld" + (i + 1)].ToString().Trim()] = Row.IsNull("Fld" + (i + 1)) ? 0 : int.Parse(Row["Fld" + (i + 1)].ToString());
                            if (!Row.IsNull("Fld" + (i + 1))) aRow["合計"] = int.Parse(aRow["合計"].ToString()) + int.Parse(Row["Fld" + (i + 1)].ToString());
                        }
                        if (DT1.Rows[0]["Fli" + (i + 1)].ToString().Trim() != "")
                        {
                            aRow[DT1.Rows[0]["Fli" + (i + 1)].ToString().Trim()] = Row.IsNull("Fli" + (i + 1)) ? 0 : int.Parse(Row["Fli" + (i + 1)].ToString());
                            if (!Row.IsNull("Fli" + (i + 1))) aRow["合計"] = int.Parse(aRow["合計"].ToString()) + int.Parse(Row["Fli" + (i + 1)].ToString());
                        }                        
                    }
                    else
                        break;
                    //if (DT1.Rows[0][i].ToString().Trim() != "")
                    //{
                    //    if (DT1.Rows[0][i].ToString().Substring(10,2)=="直接")
                    //        aRow[DT1.Rows[0][i].ToString().Trim()] = Row.IsNull("Fld" + (i + 1)) ? 0 : int.Parse(Row["Fld" + (i + 1)].ToString());
                    //    if (DT1.Rows[0][i].ToString().Substring(10, 2) == "間接")
                    //        aRow[DT1.Rows[0][i].ToString().Trim()] = Row.IsNull("Fli" + (i + 1)) ? 0 : int.Parse(Row["Fli" + (i + 1)].ToString());
                    //}
                    //else
                    //    break;
                }
                ExporDt.Rows.Add(aRow);
            }

            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
