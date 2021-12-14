/* ======================================================================================================
 * 功能名稱：基本薪資
 * 功能代號：ZZ41
 * 功能路徑：報表列印 > 薪資 > 基本薪資
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ41_Report.cs
 * 功能用途：
 *  
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/01/20    Daniel Chih    Ver 1.0.01     1. 新增異動種類：期間在職
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/01/20
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Globalization;
using Microsoft.Reporting.WinForms;

namespace JBHR.Reports.SalForm
{
    public partial class ZZ41_Report : JBControls.JBForm
    {
        SalDataSet ds = new SalDataSet();
        string type_data, deptstr, deptstr1, deptstr2, ttstype, dept_type, emp_b, emp_e, comp_name, reporttype;
        DataTable rq_base = new DataTable();
        string nobr_b, nobr_e, job_b, job_e, dept_b, dept_e, depts_b, depts_e, jobl_b, jobl_e, rotet_b, rotet_e, comp_b, comp_e, date_b;
        string  date_e, saladr_b, saladr_e, date_t, order_type, d_ename;
        bool exportexcel,floating;
        string ErrorMessage = string.Empty;
        public ZZ41_Report(string nobrb, string nobre, string jobb, string jobe, string deptb, string depte, string deptsb, string deptse, string joblb, string joble, string rotetb, string rotete, string compb, string compe, string dateb, string datee, string saladrb, string saladre, string empb, string empe, string datet, string ordertype, bool _exportexcel, string typedata, string _deptstr, string _deptstr1, string _deptstr2, string _ttstype, string depttype, string report_type, bool _floating, string dename, string compname)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; job_b = jobb; job_e = jobe; jobl_b = joblb;
            jobl_e = joble; dept_b = deptb; dept_e = depte; depts_b = deptsb;
            depts_e = deptse; rotet_b = rotetb; rotet_e = rotete; comp_b = compb;
            comp_e = compe; date_b = dateb; date_e = datee; date_t = datet;
            saladr_b = saladrb; saladr_e = saladre; order_type = ordertype;
            type_data = typedata; deptstr = _deptstr; deptstr1 = _deptstr1; deptstr2 = _deptstr2;
            ttstype = _ttstype; dept_type = depttype; exportexcel = _exportexcel;
            floating = _floating; d_ename = dename; emp_b = empb;
            emp_e = empe; comp_name = compname; reporttype = report_type;
           
        }

        private void ZZ41_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");

                #region 舊寫法

                /// <summary>
                /// 異動種類：在職
                /// </summary>
                //if (ttstype == "0")
                //{
                //    string sqlCmd = "SELECT B.NOBR,A.NAME_C,A.NAME_E,A.BIRDT,F.JOB_DISP AS JOB,F.JOB_NAME,I.JOBL_DISP AS JOBL,I.JOB_NAME AS JOBL_NAME," +
                //        //"DATEDIFF(DAY,B.INDT,'" + date_t + "') AS WK_YRS5"+                       
                //        "B.INDT,C.D_NAME,C.D_NAME,B.COMP,DBO.GETTOTALYEARS(B.NOBR,'" + date_t + "') AS WK_YRS5" +
                //        ",B.EMPCD,B.OUDT,K.ROTET_DISP AS ROTET,A.ACCOUNT_NO,B.JOBO,J.JOB_NAME AS JOBO_NAME" +
                //        " " + d_ename + " " +
                //        " FROM BASE A " + deptstr + "BASETTS B" +
                //        " LEFT OUTER JOIN JOB F ON B.JOB=F.JOB" +
                //        " LEFT OUTER JOIN JOBL I ON B.JOBL=I.JOBL" +
                //        " LEFT OUTER JOIN ROTET K ON B.ROTET=K.ROTET" +
                //        " LEFT OUTER JOIN JOBO J ON B.JOBO=J.JOBO" +
                //        " WHERE A.NOBR=B.NOBR" +
                //        " AND " + deptstr2 + "=C.D_NO" +
                //        " " + type_data + "" +
                //        " AND '" + date_e + "' BETWEEN B.ADATE AND B.DDATE" +
                //        " AND A.NOBR BETWEEN '" + nobr_b + "' AND '" + nobr_e + "'" +
                //        " AND I.JOBL_DISP BETWEEN '" + jobl_b + "' AND '" + jobl_e + "'" +
                //        " AND B.EMPCD BETWEEN '" + emp_b + "' AND '" + emp_e + "'" +
                //        "  " + deptstr1 + " " +
                //        " AND F.JOB_DISP BETWEEN '" + job_b + "' AND '" + job_e + "'" +
                //        " AND B.SALADR  BETWEEN '" + saladr_b + "' AND '" + saladr_e + "'" +
                //        " AND K.ROTET_DISP BETWEEN '" + rotet_b + "' AND '" + rotet_e + "'" +
                //        " AND B.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +                       
                //        " AND TTSCODE IN('1','4','6')";
                //    rq_base = SqlConn.GetDataTable(sqlCmd);
                //}

                /// <summary>
                /// 異動種類：全部
                /// </summary>
                //if (ttstype == "1")
                //{
                //    string sqlCmd = "SELECT B.NOBR,A.NAME_C,A.NAME_E,A.BIRDT,F.JOB_DISP AS JOB,F.JOB_NAME,I.JOBL_DISP AS JOBL,I.JOB_NAME AS JOBL_NAME," +
                //        //"DATEDIFF(DAY,B.INDT,'" + date_t + "') AS WK_YRS5"+
                //        "B.INDT,C.D_NAME,B.COMP,DBO.GETTOTALYEARS(B.NOBR,'" + date_t + "') AS WK_YRS5" +
                //        ",B.EMPCD,B.OUDT,K.ROTET_DISP AS ROTET,A.ACCOUNT_NO,B.JOBO,J.JOB_NAME AS JOBO_NAME" +
                //        " " + d_ename + " " +
                //        " FROM BASE A " + deptstr + "BASETTS B" +
                //        " LEFT OUTER JOIN JOB F ON B.JOB=F.JOB" +
                //        " LEFT OUTER JOIN JOBL I ON B.JOBL=I.JOBL" +
                //        " LEFT OUTER JOIN ROTET K ON B.ROTET=K.ROTET" +
                //        " LEFT OUTER JOIN JOBO J ON B.JOBO=J.JOBO" +
                //        " WHERE A.NOBR=B.NOBR" +
                //        " AND " + deptstr2 + "=C.D_NO" +
                //        " " + type_data + "" +
                //        " AND '" + date_e + "' BETWEEN B.ADATE AND B.DDATE" +
                //        " AND A.NOBR BETWEEN '" + nobr_b + "' AND '" + nobr_e + "'" +
                //        " AND I.JOBL_DISP BETWEEN '" + jobl_b + "' AND '" + jobl_e + "'" +
                //        " AND B.EMPCD BETWEEN '" + emp_b + "' AND '" + emp_e + "'" +
                //        " AND F.JOB_DISP BETWEEN '" + job_b + "' AND '" + job_e + "'" +
                //        " AND B.SALADR  BETWEEN '" + saladr_b + "' AND '" + saladr_e + "'" +
                //        " AND K.ROTET_DISP BETWEEN '" + rotet_b + "' AND '" + rotet_e + "'" +
                //        " AND B.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +                        
                //        "  " + deptstr1 + " ";
                //    rq_base = SqlConn.GetDataTable(sqlCmd);
                //}

                /// <summary>
                /// 異動種類：新進
                /// </summary>
                //if (ttstype == "2")
                //{
                //    string sqlCmd = "SELECT B.NOBR,A.NAME_C,A.NAME_E,A.BIRDT,F.JOB_DISP AS JOB,F.JOB_NAME,I.JOBL_DISP AS JOBL,I.JOB_NAME AS JOBL_NAME," +
                //        //"DATEDIFF(DAY,B.INDT,'" + date_t + "') AS WK_YRS5"+
                //        "B.INDT,C.D_NAME,B.COMP,DBO.GETTOTALYEARS(B.NOBR,'" + date_t + "') AS WK_YRS5" +
                //        ",B.EMPCD,B.OUDT,K.ROTET_DISP AS ROTET,A.ACCOUNT_NO,B.JOBO,J.JOB_NAME AS JOBO_NAME" +
                //        " " + d_ename + " " +
                //        " FROM BASE A " + deptstr + "BASETTS B" +
                //        " LEFT OUTER JOIN JOB F ON B.JOB=F.JOB" +
                //        " LEFT OUTER JOIN JOBL I ON B.JOBL=I.JOBL" +
                //        " LEFT OUTER JOIN ROTET K ON B.ROTET=K.ROTET" +
                //        " LEFT OUTER JOIN JOBO J ON B.JOBO=J.JOBO" +
                //        " WHERE A.NOBR=B.NOBR" +
                //        " AND " + deptstr2 + "=C.D_NO" +
                //        " " + type_data + "" +
                //        " AND  B.INDT  BETWEEN '" + date_b + "' AND '" + date_e + "'" +
                //        " AND  '" + date_e + "'  BETWEEN B.ADATE AND B.DDATE " +
                //        " AND A.NOBR BETWEEN '" + nobr_b + "' AND '" + nobr_e + "'" +
                //        " AND I.JOBL_DISP BETWEEN '" + jobl_b + "' AND '" + jobl_e + "'" +
                //        " AND B.EMPCD BETWEEN '" + emp_b + "' AND '" + emp_e + "'" +
                //        " AND F.JOB_DISP BETWEEN '" + job_b + "' AND '" + job_e + "'" +
                //        " AND B.SALADR  BETWEEN '" + saladr_b + "' AND '" + saladr_e + "'" +
                //        " AND K.ROTET_DISP BETWEEN '" + rotet_b + "' AND '" + rotet_e + "'" +
                //        " AND B.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +                        
                //        "  " + deptstr1 + " ";
                //        //" AND TTSCODE ='1'";
                //    rq_base = SqlConn.GetDataTable(sqlCmd);
                //}
                
                /// <summary>
                /// 異動種類：離職
                /// </summary>
                //if (ttstype == "3")
                //{
                //    string sqlCmd = "SELECT B.NOBR,A.NAME_C,A.NAME_E,A.BIRDT,B.DEPT,B.DEPTS,F.JOB_DISP AS JOB,F.JOB_NAME,I.JOBL_DISP AS JOBL,I.JOB_NAME AS JOBL_NAME," +
                //        //"DATEDIFF(DAY,B.INDT,'" + date_t + "') AS WK_YRS5"+
                //        "B.INDT,C.D_NAME,B.COMP,DBO.GETTOTALYEARS(B.NOBR,'" + date_t + "') AS WK_YRS5" +
                //        ",B.EMPCD,B.OUDT,K.ROTET_DISP AS ROTET,A.ACCOUNT_NO,B.JOBO,J.JOB_NAME AS JOBO_NAME" +
                //        " " + d_ename + " " +
                //        " FROM BASE A " + deptstr + "BASETTS B" +
                //        " LEFT OUTER JOIN JOB F ON B.JOB=F.JOB" +
                //        " LEFT OUTER JOIN DEPTS G ON B.DEPTS=G.D_NO" +
                //        " LEFT OUTER JOIN JOBL I ON B.JOBL=I.JOBL" +
                //        " LEFT OUTER JOIN ROTET K ON B.ROTET=K.ROTET" +
                //        " LEFT OUTER JOIN JOBO J ON B.JOBO=J.JOBO" +
                //        " WHERE A.NOBR=B.NOBR" +
                //        " AND " + deptstr2 + "=C.D_NO" +
                //        " " + type_data + "" +
                //        " AND  B.OUDT  BETWEEN '" + date_b + "' AND '" + date_e + "'" +
                //        " AND A.NOBR BETWEEN '" + nobr_b + "' AND '" + nobr_e + "'" +
                //        " AND I.JOBL_DISP BETWEEN '" + jobl_b + "' AND '" + jobl_e + "'" +
                //        " AND B.EMPCD BETWEEN '" + emp_b + "' AND '" + emp_e + "'" +
                //        " AND F.JOB_DISP BETWEEN '" + job_b + "' AND '" + job_e + "'" +
                //        " AND B.SALADR  BETWEEN '" + saladr_b + "' AND '" + saladr_e + "'" +
                //        " AND K.ROTET_DISP BETWEEN '" + rotet_b + "' AND '" + rotet_e + "'" +
                //        " AND B.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +                       
                //        "  " + deptstr1 + " " +
                //        " AND TTSCODE ='2'";
                //    rq_base = SqlConn.GetDataTable(sqlCmd);
                //}

                #endregion

                /// <summary>
                /// 統一宣告 sqlCmdSelect 的共用語法內容
                /// </summary>
                //備註：將 SELECT 另外寫在根據條件呼叫該字串的地方，可判斷是否加入 DISTINCT 等內容
                string sqlCmdSelect = " B.NOBR, A.NAME_C, A.NAME_E, A.BIRDT, F.JOB_DISP AS JOB, F.JOB_NAME, I.JOBL_DISP AS JOBL, I.JOB_NAME AS JOBL_NAME, B.INDT";
                sqlCmdSelect += ", C.D_NAME, B.COMP, DBO.GETTOTALYEARS(B.NOBR, '" + date_t + "') AS WK_YRS5, B.EMPCD, B.OUDT, K.ROTET_DISP AS ROTET";
                sqlCmdSelect += ", B.RETCHOO, B.RETDATE, B.RETDATE1, A.ACCOUNT_NO, B.JOBO, J.JOB_NAME AS JOBO_NAME " + d_ename;

                /// <summary>
                /// 統一宣告 sqlCmdFrom 的共用語法內容
                /// </summary>
                string sqlCmdFrom = " FROM BASE A INNER JOIN BASETTS B ON A.NOBR = B.NOBR ";
                sqlCmdFrom += " INNER JOIN " + deptstr + " ON " + deptstr2 + " = C.D_NO ";
                sqlCmdFrom += " LEFT OUTER JOIN JOB F ON B.JOB = F.JOB ";
                sqlCmdFrom += " LEFT OUTER JOIN JOBL I ON B.JOBL = I.JOBL ";
                sqlCmdFrom += " LEFT OUTER JOIN ROTET K ON B.ROTET = K.ROTET ";
                sqlCmdFrom += " LEFT OUTER JOIN JOBO J ON B.JOBO = J.JOBO ";

                /// <summary>
                /// 統一宣告 sqlCmdWhere 的共用語法內容
                /// </summary>
                string sqlCmdWhere = " WHERE 1 = 1 " + type_data;
                sqlCmdWhere += " AND A.NOBR BETWEEN '" + nobr_b + "' AND '" + nobr_e + "' ";
                sqlCmdWhere += " AND I.JOBL_DISP BETWEEN '" + jobl_b + "' AND '" + jobl_e + "' ";
                sqlCmdWhere += " AND B.EMPCD BETWEEN '" + emp_b + "' AND '" + emp_e + "' " + deptstr1;
                sqlCmdWhere += " AND F.JOB_DISP BETWEEN '" + job_b + "' AND '" + job_e + "' ";
                sqlCmdWhere += " AND B.SALADR  BETWEEN '" + saladr_b + "' AND '" + saladr_e + "' ";
                sqlCmdWhere += " AND K.ROTET_DISP BETWEEN '" + rotet_b + "' AND '" + rotet_e + "' ";
                sqlCmdWhere += " AND B.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "' ";

                /// <summary>
                /// 異動種類：在職
                /// </summary>
                if (ttstype == "0")
                {
                    //設定 SELECT 語法的補充部分
                    string sqlCmdSelectSup = "";
                    //設定 From 語法的補充部分
                    string sqlCmdFromSup = "";
                    //設定 WHERE 語法的補充部分
                    string sqlCmdWhereSup = " AND '" + date_e + "' BETWEEN B.ADATE AND B.DDATE ";
                    sqlCmdWhereSup += " AND TTSCODE IN('1','4','6') ";

                    string sqlCmd = " SELECT " + sqlCmdSelect + sqlCmdSelectSup + sqlCmdFrom + sqlCmdFromSup + sqlCmdWhere + sqlCmdWhereSup;

                    //清空語法補充部分的字串內容
                    sqlCmdSelectSup = "";
                    sqlCmdFromSup = "";
                    sqlCmdWhereSup = "";

                    rq_base = SqlConn.GetDataTable(sqlCmd);
                }

                /// <summary>
                /// 異動種類：全部
                /// </summary>
                if (ttstype == "1")
                {
                    //設定 SELECT 語法的補充部分
                    string sqlCmdSelectSup = "";
                    //設定 From 語法的補充部分
                    string sqlCmdFromSup = "";
                    //設定 WHERE 語法的補充部分
                    string sqlCmdWhereSup = " AND '" + date_e + "' BETWEEN B.ADATE AND B.DDATE ";

                    string sqlCmd = " SELECT " + sqlCmdSelect + sqlCmdSelectSup + sqlCmdFrom + sqlCmdFromSup + sqlCmdWhere + sqlCmdWhereSup;

                    //清空語法補充部分的字串內容
                    sqlCmdSelectSup = "";
                    sqlCmdFromSup = "";
                    sqlCmdWhereSup = "";

                    rq_base = SqlConn.GetDataTable(sqlCmd);
                }

                /// <summary>
                /// 異動種類：新進
                /// </summary>
                if (ttstype == "2")
                {
                    //設定 SELECT 語法的補充部分
                    string sqlCmdSelectSup = "";
                    //設定 From 語法的補充部分
                    string sqlCmdFromSup = "";
                    //設定 WHERE 語法的補充部分
                    string sqlCmdWhereSup = " AND '" + date_e + "' BETWEEN B.ADATE AND B.DDATE ";
                    sqlCmdWhereSup += " AND B.INDT BETWEEN '" + date_b + "' AND '" + date_e + "' ";

                    string sqlCmd = " SELECT " + sqlCmdSelect + sqlCmdSelectSup + sqlCmdFrom + sqlCmdFromSup + sqlCmdWhere + sqlCmdWhereSup;

                    //清空語法補充部分的字串內容
                    sqlCmdSelectSup = "";
                    sqlCmdFromSup = "";
                    sqlCmdWhereSup = "";

                    rq_base = SqlConn.GetDataTable(sqlCmd);
                }

                /// <summary>
                /// 異動種類：離職
                /// </summary>
                if (ttstype == "3")
                {
                    //設定 SELECT 語法的補充部分
                    string sqlCmdSelectSup = ", B.DEPT, B.DEPTS";
                    //設定 From 語法的補充部分
                    string sqlCmdFromSup = " LEFT OUTER JOIN DEPTS G ON B.DEPTS = G.D_NO ";
                    //設定 WHERE 語法的補充部分
                    string sqlCmdWhereSup = " AND  B.OUDT  BETWEEN '" + date_b + "' AND '" + date_e + "' ";
                    sqlCmdWhereSup += " AND TTSCODE = '2' "; 

                    string sqlCmd = " SELECT " + sqlCmdSelect + sqlCmdSelectSup + sqlCmdFrom + sqlCmdFromSup + sqlCmdWhere + sqlCmdWhereSup;

                    //清空語法補充部分的字串內容
                    sqlCmdSelectSup = "";
                    sqlCmdFromSup = "";
                    sqlCmdWhereSup = "";

                    rq_base = SqlConn.GetDataTable(sqlCmd);
                }

                /// <summary>
                /// 異動種類：期間在職
                /// </summary>
                if (ttstype == "4")
                {
                    //設定 SELECT 語法的補充部分
                    string sqlCmdSelectSup = "";
                    //設定 From 語法的補充部分
                    string sqlCmdFromSup = "";
                    //設定 WHERE 語法的補充部分
                    string sqlCmdWhereSup = " AND '"+ date_e + "' BETWEEN B.ADATE AND B.DDATE ";
                    sqlCmdWhereSup += " AND INDT <= '" + date_e + "' ";
                    sqlCmdWhereSup += " AND NOT EXISTS(SELECT 1 FROM BASETTS BTS WHERE BTS.NOBR= B.NOBR AND TTSCODE ='2' AND OUDT < '" + date_b + "') ";

                    string sqlCmd = " SELECT " + sqlCmdSelect + sqlCmdSelectSup + sqlCmdFrom + sqlCmdFromSup + sqlCmdWhere + sqlCmdWhereSup;

                    //清空語法補充部分的字串內容
                    sqlCmdSelectSup = "";
                    sqlCmdFromSup = "";
                    sqlCmdWhereSup = "";

                    rq_base = SqlConn.GetDataTable(sqlCmd);
                }


                if (rq_base.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                ErrorMessage = "\n" + "人事異動資料重疊名單:";
                ErrorMessage += JBHR.Reports.ReportClass.GetRepeatEmpID(rq_base);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };                
                ErrorMessage = "";
                rq_base.Columns.Add("wk_yrs6", typeof(decimal));
               

                foreach (DataRow Row in rq_base.Rows)
                {
                    Row["wk_yrs6"] = (Row.IsNull("wk_yrs5")) ? 0 : decimal.Parse(Row["wk_yrs5"].ToString());
                }
                //rq_basetts = null;
                string sqlCmd1 = "SELECT A.*,B.SAL_NAME,B.SAL_ENAME,C.ATTR_NAME,B.SAL_CODE_DISP FROM SALBASD A,SALCODE B,SALATTR C" +
                    " WHERE A.SAL_CODE=B.SAL_CODE" +
                    " AND '"+date_e+"' BETWEEN A.ADATE AND A.DDATE"+
                    " AND A.NOBR BETWEEN '" + nobr_b + "' AND '" + nobr_e + "'" +
                    " AND B.SAL_ATTR=C.SALATTR" +
                    //" AND B.CAL_FREQ IN ('1','3')" +
                    //" AND B.SAL_ATTR IN ('A','G')" +
                    " AND A.AMT <> 10.00 ORDER BY A.NOBR,B.SAL_CODE_DISP";
                DataTable rq_salbasd = SqlConn.GetDataTable(sqlCmd1);
                DataTable rq_salbasd1 = new DataTable();               
                rq_salbasd1.Columns.Add("sal_code", typeof(string));
                rq_salbasd1.Columns.Add("sal_name", typeof(string));
                rq_salbasd1.PrimaryKey = new DataColumn[] { rq_salbasd1.Columns["sal_code"] };
                DataRow[] Orow = rq_salbasd.Select("", "sal_code");
                foreach (DataRow Row in Orow)
                {
                    Row["sal_code"] = Row["sal_code_disp"].ToString();
                    DataRow row1 = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row1 != null)
                    {
                        Row["amt"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row["amt"].ToString()));
                        DataRow row = rq_salbasd1.Rows.Find(Row["sal_code"].ToString());

                        if (row == null)
                        {
                            DataRow aRow = rq_salbasd1.NewRow();                           
                            aRow["sal_code"] = Row["sal_code"].ToString();
                            aRow["sal_name"] = Row["sal_name"].ToString().Trim();
                            rq_salbasd1.Rows.Add(aRow);
                        }
                    }
                    else
                        Row.Delete();
                }
                rq_salbasd.AcceptChanges();

                if (floating)
                {
                    string sqlCmd2 = "select a.*,b.sal_name,b.sal_ename,c.attr_name,c.flag";
                    sqlCmd2 += " from salbastd a,salcode b,salattr c";
                    sqlCmd2 += " where a.sal_code=b.sal_code and b.sal_attr=c.salattr";
                    sqlCmd2 += string.Format(@" and '{0}' between a.adate and a.ddate", date_e);
                    sqlCmd2 += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                    sqlCmd2 += " and a.amt <>10.00 order by a.sal_code";
                    DataTable rq_salbastd = SqlConn.GetDataTable(sqlCmd2);
                    foreach (DataRow Row in rq_salbastd.Rows)
                    {
                        if (Row["flag"].ToString().Trim() == "-")
                            Row["amt"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row["amt"].ToString())) * (-1);
                        else
                            Row["amt"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row["amt"].ToString()));
                        DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                        if (row != null)
                        {
                            DataRow row1 = rq_salbasd1.Rows.Find(Row["sal_code"].ToString());
                            if (row1 == null)
                            {
                                DataRow aRow = rq_salbasd1.NewRow();                                
                                aRow["sal_code"] = Row["sal_code"].ToString();
                                aRow["sal_name"] = Row["sal_name"].ToString().Trim();
                                rq_salbasd1.Rows.Add(aRow);
                            }
                            rq_salbasd.ImportRow(Row);
                        }
                    }
                }

                
                DataTable rq_zz41 = new DataTable();
                rq_zz41 = ds.Tables["zz41"].Clone();
                rq_zz41.TableName = "rq_zz41";
                CultureInfo MyCultureInfo = new CultureInfo("en-GB");
                double result;
                Hashtable ht = new Hashtable();
                DataTable zz41d = new DataTable("zz41d");
                zz41d.Columns.Add("nobr", typeof(string));
                for (int i = 0; i < rq_salbasd1.Rows.Count; i++)
                {

                    if (!Double.TryParse(rq_salbasd1.Rows[i][0].ToString(), System.Globalization.NumberStyles.Integer, MyCultureInfo, out result))
                    {
                        zz41d.Columns.Add(rq_salbasd1.Rows[i][0].ToString().Trim(), typeof(decimal));
                    }
                    else
                    {
                        zz41d.Columns.Add(rq_salbasd1.Rows[i][0].ToString().Trim(), typeof(decimal));
                    }
                    ht.Add("Fld" + (i + 1), rq_salbasd1.Rows[i][1].ToString());
                }


                DataColumn[] KEYS = new DataColumn[1];
                KEYS[0] = zz41d.Columns["nobr"];
                zz41d.PrimaryKey = KEYS;

                for (int i = 0; i < rq_salbasd.Rows.Count; i++)
                {
                    //DataRow [] dr = ds.Tables["zz41d"].Select("nobr = '"+ds.Tables["rq_salbasd"].Rows[i]["nobr"].ToString()+"'");
                    DataRow dr = zz41d.Rows.Find(rq_salbasd.Rows[i]["nobr"]);
                    if (dr == null)
                    {//new
                        DataRow newRow = zz41d.NewRow();
                        newRow["nobr"] = rq_salbasd.Rows[i]["nobr"].ToString();
                        //if(ds.Tables["rq_abs2"].Rows[i]["h_code"].ToString().IndexOf("W")>=0)
                        if (!Double.TryParse(rq_salbasd.Rows[i]["sal_code"].ToString(), System.Globalization.NumberStyles.Integer, MyCultureInfo, out result))
                        {
                            //newRow[rq_salbasd.Rows[i]["sal_code"].ToString()] = JBModule.Data.CDecryp.Number(decimal.Parse(rq_salbasd.Rows[i]["amt"].ToString()));
                            newRow[rq_salbasd.Rows[i]["sal_code"].ToString()] = decimal.Parse(rq_salbasd.Rows[i]["amt"].ToString());
                        }
                        else
                        {
                            //newRow[rq_salbasd.Rows[i]["sal_code"].ToString()] = JBModule.Data.CDecryp.Number(decimal.Parse(rq_salbasd.Rows[i]["amt"].ToString()));
                            newRow[rq_salbasd.Rows[i]["sal_code"].ToString()] = decimal.Parse(rq_salbasd.Rows[i]["amt"].ToString());
                        }
                        zz41d.Rows.Add(newRow);
                    }
                    else
                    {//update
                        DataRow newRow = dr;

                        if (!Double.TryParse(rq_salbasd.Rows[i]["sal_code"].ToString(), System.Globalization.NumberStyles.Integer, MyCultureInfo, out result))
                        {
                            //newRow[rq_salbasd.Rows[i]["sal_code"].ToString()] = JBModule.Data.CDecryp.Number(decimal.Parse(rq_salbasd.Rows[i]["amt"].ToString()));
                            newRow[rq_salbasd.Rows[i]["sal_code"].ToString()] = decimal.Parse(rq_salbasd.Rows[i]["amt"].ToString());
                        }
                        else
                        {
                            //newRow[rq_salbasd.Rows[i]["sal_code"].ToString()] = JBModule.Data.CDecryp.Number(decimal.Parse(rq_salbasd.Rows[i]["amt"].ToString()));
                            newRow[rq_salbasd.Rows[i]["sal_code"].ToString()] = decimal.Parse(rq_salbasd.Rows[i]["amt"].ToString());
                        }

                    }
                }
                rq_salbasd = null;
                DataRow newRow2 = ds.Tables["Abssumd1"].NewRow();
                for (int i = 0; i < ht.Count; i++)
                {
                    newRow2["Fld" + (i + 1)] = ht["Fld" + (i + 1)].ToString();
                }
                newRow2["Fld" + (ht.Count + 1)] = "合計";
                ds.Tables["Abssumd1"].Rows.Add(newRow2);


                for (int i = 0; i < zz41d.Rows.Count; i++)
                {
                    string str_nobr = zz41d.Rows[i]["nobr"].ToString();
                    DataRow row8 = rq_base.Rows.Find(str_nobr);
                    if (row8 != null)
                    {                       
                        DataRow newRow = rq_zz41.NewRow();
                        newRow["Nobr"] = row8["nobr"].ToString();
                        newRow["Name_c"] = row8["name_c"].ToString();
                        newRow["Name_e"] = row8["name_e"].ToString();                        
                        newRow["D_name"] = row8["d_name"].ToString();
                        newRow["D_ename"] = row8["d_ename"].ToString();
                        newRow["Job"] = row8["job"].ToString();
                        newRow["Jobl"] = row8["jobl"].ToString();
                        newRow["Jobl_name"] = row8["jobl_name"].ToString();
                        newRow["Jobo"] = row8["jobo"].ToString();
                        newRow["Jobo_name"] = row8["jobo_name"].ToString();
                        newRow["account_no"] = row8["account_no"].ToString();
                        newRow["retchoo"] = row8["retchoo"].ToString();
                        if (dept_type == "DEPT")
                            newRow["Dept"] = row8["dept"].ToString();
                        else
                            newRow["Dept"] = row8["depts"].ToString();
                        if (!row8.IsNull("oudt")) newRow["oudt"] = DateTime.Parse(row8["oudt"].ToString());

                        if (!string.IsNullOrEmpty(row8["retdate"].ToString()))
                        {
                            newRow["retdate"] = DateTime.Parse(row8["retdate"].ToString());
                        }
                        if (!string.IsNullOrEmpty(row8["retdate1"].ToString()))
                        {
                            newRow["retdate1"] = DateTime.Parse(row8["retdate1"].ToString());
                        }

                        newRow["Indt"] = DateTime.Parse(row8["indt"].ToString());
                        newRow["birdt"] = DateTime.Parse(row8["birdt"].ToString());  
                        //if (ttstype == "3")
                        //    newRow["Indt"] = DateTime.Parse(row8["oudt"].ToString());
                        //else
                                                 
                       
                        newRow["wk_yrs"] = decimal.Parse(row8["wk_yrs6"].ToString());
                        newRow["Job_name"] = row8["job_name"].ToString();                        
                        //newRow["depttype"] = dept_type;
                        newRow["comp"] = row8["comp"].ToString();
                        newRow["rotet"] = row8["rotet"].ToString();
                        newRow["Fld" + (ht.Count+1)] = 0;
                        for (int j = 1; j < zz41d.Columns.Count; j++)
                        {
                            //							newRow["Fld"+j] =ds.Tables["zz23d"].Rows[i][ds.Tables["zz23d"].Columns[j].ColumnName].ToString();
                            if (zz41d.Rows[i][zz41d.Columns[j].ColumnName].ToString().Length == 0)
                            {
                                newRow["Fld" + j] = 0;                                
                            }
                            else
                            {
                                newRow["Fld" + j] = decimal.Parse(zz41d.Rows[i][zz41d.Columns[j].ColumnName].ToString());
                                //str_sum = str_sum + decimal.Parse(zz41d.Rows[i][zz41d.Columns[j].ColumnName].ToString());
                                newRow["Fld" + (ht.Count + 1)] = decimal.Parse(newRow["Fld" + (ht.Count + 1)].ToString()) + decimal.Parse(zz41d.Rows[i][zz41d.Columns[j].ColumnName].ToString());
                            }
                        }

                        //newRow["Fld" + rq_salbasd1.Rows.Count] = str_sum;
                        rq_zz41.Rows.Add(newRow);
                    }
                }

                DataTable rq_schl=new DataTable();
                DataTable rq_works =new DataTable();
                if (reporttype == "1")
                {
                    //學歷
                    string sqlCmd3 = "select f.nobr,e.name,f.schl,f.subj,subj_detail,f.date_b,f.date_e";
                    sqlCmd3 += " from schl f,mtcode e,base a,basetts b";
                    sqlCmd3 += " where a.nobr=b.nobr and f.nobr=a.nobr and f.educcode=e.code ";
                    sqlCmd3 += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                    sqlCmd3 += string.Format(@" and f.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                    sqlCmd3 += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);
                    sqlCmd3 += string.Format(@" and b.saladr between '{0}' and '{1}'", saladr_b, saladr_e);
                    sqlCmd3 += string.Format(@" and b.comp between '{0}' and '{1}'", comp_b, comp_e);
                    sqlCmd3 += " and f.nobr+str(e.sort) in (select max(c.nobr+str(d.sort)) from schl c,mtcode d";
                    sqlCmd3 += " where c.educcode=d.code and d.category='educode'";
                    sqlCmd3 += " group by c.nobr)";
                    sqlCmd3 += type_data;
                    sqlCmd3 += " order by f.nobr,f.date_b desc";
                    DataTable rq_schl2 = SqlConn.GetDataTable(sqlCmd3);
                    rq_schl= rq_schl2.Clone();
                    string str_nobr1 = "";
                    foreach (DataRow Row in rq_schl2.Rows)
                    {
                        string str_nobr = Row["nobr"].ToString();
                        if (str_nobr != str_nobr1)
                            rq_schl.ImportRow(Row);
                        str_nobr1 = Row["nobr"].ToString();
                        
                    }
                    rq_schl2 = null;
                    rq_schl.PrimaryKey = new DataColumn[] { rq_schl.Columns["nobr"] };

                    //經歷
                    string sqlcmd4 = "select c.nobr,c.company,c.title,c.job";
                    sqlcmd4 += " from base a,basetts b,works c";
                    sqlcmd4 += " where a.nobr=b.nobr and a.nobr=c.nobr";
                    sqlcmd4 += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                    sqlcmd4 += string.Format(@" and c.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                    sqlcmd4 += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);
                    sqlcmd4 += string.Format(@" and b.saladr between '{0}' and '{1}'", saladr_b, saladr_e);
                    sqlcmd4 += string.Format(@" and b.comp between '{0}' and '{1}'", comp_b, comp_e);
                    sqlcmd4 += type_data;
                    sqlcmd4 += " order by c.nobr,c.bdate desc";
                    DataTable rq_works2 = SqlConn.GetDataTable(sqlcmd4);
                    rq_works.Columns.Add("nobr", typeof(string));
                    rq_works.Columns.Add("company1", typeof(string));
                    rq_works.Columns.Add("title1", typeof(string));
                    rq_works.Columns.Add("job1", typeof(string));
                    rq_works.Columns.Add("company2", typeof(string));
                    rq_works.Columns.Add("title2", typeof(string));
                    rq_works.Columns.Add("job2", typeof(string));
                    rq_works.Columns.Add("company3", typeof(string));
                    rq_works.Columns.Add("title3", typeof(string));
                    rq_works.Columns.Add("job3", typeof(string));
                    rq_works.PrimaryKey = new DataColumn[] { rq_works.Columns["nobr"] };
                    str_nobr1 = "";
                    int _times = 0;
                   
                    foreach (DataRow Row in rq_works2.Rows)
                    {
                        string str_nobr = Row["nobr"].ToString();
                        if (str_nobr == str_nobr1)
                            _times++;
                        else
                            _times = 1;
                        if (_times < 4)
                        {
                            DataRow row = rq_works.Rows.Find(Row["nobr"].ToString());
                            if (row != null)
                            {
                                row["company" + _times] = Row["company"].ToString();
                                row["title" + _times] = Row["title"].ToString();
                                row["job" + _times] = Row["job"].ToString();
                            }
                            else
                            {
                                DataRow aRow = rq_works.NewRow();
                                aRow["nobr"] = Row["nobr"].ToString();
                                aRow["company1"] = Row["company"].ToString();
                                aRow["title1"] = Row["title"].ToString();
                                aRow["job1"] = Row["job"].ToString();
                                rq_works.Rows.Add(aRow);
                            }
                        } 
                        
                        str_nobr1 = Row["nobr"].ToString();
                    }
                }

                DataRow[] row10 = null;                
                if (order_type=="1")
                    row10 = rq_zz41.Select("", "nobr asc");
                else if (order_type == "2")
                    row10 = rq_zz41.Select("", "comp,dept,jobl desc");
                else if (order_type == "3")
                    row10 = rq_zz41.Select("", "job,nobr asc");
                else if (order_type == "4")
                    row10 = rq_zz41.Select("", "name_c asc");
                else if (order_type == "5")
                    row10 = rq_zz41.Select("", "jobl,dept,nobr desc");
                if (reporttype == "0")
                {
                    foreach (DataRow Row in row10)
                    {
                        ds.Tables["zz41"].ImportRow(Row);
                    }
                }
                else
                {
                    foreach (DataRow Row in row10)
                    {
                        DataRow row = rq_schl.Rows.Find(Row["nobr"].ToString());
                        if (row != null)
                        {
                            Row["edudesc"] = row["name"].ToString();
                            Row["schl"] = row["schl"].ToString();
                            Row["subj"] = row["subj"].ToString();
                            Row["subj_detail"] = row["subj_detail"].ToString();
                            Row["date_b"] = row["date_b"].ToString();
                            Row["date_e"] = row["date_e"].ToString();
                        }
                        //DataRow[] row1 = rq_works.Select("nobr='" + Row["nobr"].ToString() + "'");
                        DataRow row1 = rq_works.Rows.Find(Row["nobr"].ToString());
                        if (row1 != null)
                        {
                            Row["company1" ] = row1["company1"].ToString();
                            Row["title1" ] = row1["title1"].ToString();
                            Row["jobw1"] = row1["job1"].ToString();
                            Row["company2"] = row1["company2"].ToString();
                            Row["title2"] = row1["title2"].ToString();
                            Row["jobw2"] = row1["job2"].ToString();
                            Row["company3"] = row1["company3"].ToString();
                            Row["title3"] = row1["title3"].ToString();
                            Row["jobw3"] = row1["job3"].ToString();
                        }
                        ds.Tables["zz41"].ImportRow(Row);
                        //if (row1.Length > 0)
                        //{
                        //    for (int i = 0; i < row1.Length; i++)
                        //    {
                        //        if (i > 0)
                        //        {
                        //            Row["edudesc"] = "";
                        //            Row["schl"] = "";
                        //            Row["subj"] = "";
                        //            Row["date_b"] = "";
                        //            Row["date_e"] = "";
                        //            for (int j = 0; j < zz41d.Columns.Count; j++)
                        //            {
                        //                if (zz41d.Columns[j].ToString().Trim() != "")
                        //                    Row["Fld" + (j + 1)] = 0;
                        //                else
                        //                    break;
                        //            }
                        //        }
                        //        Row["company" + (i + 1)] = row1[i]["company"].ToString();
                        //        Row["title" + (i + 1)] = row1[i]["title"].ToString();
                        //        Row["jobw" + (i + 1)] = row1[i]["job"].ToString();
                        //        ds.Tables["zz41"].ImportRow(Row);
                        //    }
                        //}
                        //else
                        //    ds.Tables["zz41"].ImportRow(Row);
                    }
                }
                rq_zz41 = null;
                rq_base = null;
                zz41d = null;
                rq_salbasd1 = null;        

                if (ds.Tables["zz41"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                
                if (exportexcel)
                {
                    Export(ds.Tables["zz41"], ds.Tables["abssumd1"]);
                    this.Close();                    
                }
                else
                {                    
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "SalReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "SalReport", "*.rdlc");
                    if (reporttype == "0")
                    {
                        if (order_type == "2")
                            RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz41.rdlc";
                        else
                            RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz412.rdlc";
                    }
                    else
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz413.rdlc";                    

                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("TtsType", ttstype) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz41", ds.Tables["zz41"]));
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_Abssumd1", ds.Tables["abssumd1"]));
                    RptViewer.SetDisplayMode(DisplayMode.PrintLayout);
                    RptViewer.ZoomMode = ZoomMode.FullPage;
                    //RptViewer.ZoomPercent = JBHR.Reports.ReportClass.GetReportPercent();
                }
                
            }
            catch (Exception Ex)
            {
                JBModule.Message.TextLog.WriteLog(Ex);
                MessageBox.Show(Resources.All.ExceptionStr1 + "\n" + Ex.Message +  ErrorMessage + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        void Export(DataTable DT, DataTable DT1)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            ExporDt.Columns.Add("部門代號", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));            
            ExporDt.Columns.Add("職稱代碼", typeof(string));
            ExporDt.Columns.Add("職稱", typeof(string));
            ExporDt.Columns.Add("職等", typeof(string));
            ExporDt.Columns.Add("職等名稱", typeof(string));
            ExporDt.Columns.Add("職級", typeof(string));
            ExporDt.Columns.Add("職級名稱", typeof(string));
            //if (order_type != "2") ExporDt.Columns.Add("班別", typeof(string));
            ExporDt.Columns.Add("退休制度", typeof(string));
            ExporDt.Columns.Add("加入新制日期", typeof(DateTime));
            ExporDt.Columns.Add("開始提撥日", typeof(DateTime));
            ExporDt.Columns.Add("到職日期", typeof(DateTime));
            ExporDt.Columns.Add("離職日期", typeof(DateTime));
            ExporDt.Columns.Add("年資", typeof(decimal));
            ExporDt.Columns.Add("出生日期", typeof(DateTime));
            ExporDt.Columns.Add("銀行帳號", typeof(string));
            if (reporttype == "1")
            {
                ExporDt.Columns.Add("教育程度", typeof(string));
                ExporDt.Columns.Add("學校名稱", typeof(string));
                ExporDt.Columns.Add("科系代碼", typeof(string));
                ExporDt.Columns.Add("科系名稱", typeof(string));
                ExporDt.Columns.Add("入學年月", typeof(string));
                ExporDt.Columns.Add("畢業年月", typeof(string));
                ExporDt.Columns.Add("經歷公司1", typeof(string));
                ExporDt.Columns.Add("經歷職稱1", typeof(string));
                ExporDt.Columns.Add("工作內容1", typeof(string));
                ExporDt.Columns.Add("經歷公司2", typeof(string));
                ExporDt.Columns.Add("經歷職稱2", typeof(string));
                ExporDt.Columns.Add("工作內容2", typeof(string));
                ExporDt.Columns.Add("經歷公司3", typeof(string));
                ExporDt.Columns.Add("經歷職稱3", typeof(string));
                ExporDt.Columns.Add("工作內容3", typeof(string));
            }
            for (int i = 0; i < DT1.Columns.Count; i++)
            {
                if (DT1.Rows[0][i].ToString().Trim() != "")
                    ExporDt.Columns.Add(DT1.Rows[0][i].ToString().Trim(), typeof(decimal));
                else
                    break;
            }

            //DataRow[] OrderRow = DT.Select("", "dept,nobr asc");
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["員工編號"] = Row01["nobr"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();
                aRow["英文姓名"] = Row01["name_e"].ToString();
                aRow["部門代號"] = Row01["dept"].ToString();
                aRow["部門名稱"] = Row01["d_name"].ToString();                
                //if (order_type != "2") aRow["班別"] = Row01["rotet"].ToString(); 
                aRow["職稱代碼"] = Row01["job"].ToString();
                aRow["職稱"] = Row01["job_name"].ToString();
                aRow["職等"] = Row01["jobl"].ToString();
                aRow["職等名稱"] = Row01["jobl_name"].ToString();
                aRow["職級"] = Row01["jobo"].ToString();
                aRow["職級名稱"] = Row01["jobo_name"].ToString();

                aRow["退休制度"] = Row01["retchoo"].ToString();

                if (!string.IsNullOrEmpty(Row01["retdate"].ToString()))
                {
                    aRow["加入新制日期"] = DateTime.Parse(Row01["retdate"].ToString()).ToString("yyyy/MM/dd");
                }
                //else
                //{
                //    aRow["加入新制日期"] = "";
                //}

                if (!string.IsNullOrEmpty(Row01["retdate1"].ToString()))
                {
                    aRow["開始提撥日"] = DateTime.Parse(Row01["retdate1"].ToString()).ToString("yyyy/MM/dd");
                }
                //else
                //{
                //    aRow["開始提撥日"] = "";
                //}

                aRow["到職日期"] = DateTime.Parse(Row01["indt"].ToString()).ToString("yyyy/MM/dd");
                if (!Row01.IsNull("oudt")) aRow["離職日期"] = DateTime.Parse(Row01["oudt"].ToString()).ToString("yyyy/MM/dd");
                aRow["年資"] = decimal.Parse(Row01["wk_yrs"].ToString());
                if (!Row01.IsNull("birdt")) aRow["出生日期"] = DateTime.Parse(Row01["birdt"].ToString()).ToString("yyyy/MM/dd");
                aRow["銀行帳號"] = Row01["account_no"].ToString();                
                if (reporttype == "1")
                {
                    aRow["教育程度"] = (Row01.IsNull("edudesc")) ? "" : Row01["edudesc"].ToString();
                    aRow["學校名稱"] = (Row01.IsNull("schl")) ? "" : Row01["schl"].ToString();
                    aRow["科系代碼"] = (Row01.IsNull("subj")) ? "" : Row01["subj"].ToString();
                    aRow["科系名稱"] = (Row01.IsNull("subj_detail")) ? "" : Row01["subj_detail"].ToString();
                    aRow["入學年月"] = (Row01.IsNull("date_b")) ? "" : Row01["date_b"].ToString();
                    aRow["畢業年月"] = (Row01.IsNull("date_e")) ? "" : Row01["date_e"].ToString();
                    aRow["經歷公司1"] = (Row01.IsNull("company1")) ? "" : Row01["company1"].ToString();
                    aRow["經歷職稱1"] = (Row01.IsNull("title1")) ? "" : Row01["title1"].ToString();
                    aRow["工作內容1"] = (Row01.IsNull("jobw1")) ? "" : Row01["jobw1"].ToString();
                    aRow["經歷公司2"] = (Row01.IsNull("company2")) ? "" : Row01["company2"].ToString();
                    aRow["經歷職稱2"] = (Row01.IsNull("title2")) ? "" : Row01["title2"].ToString();
                    aRow["工作內容2"] = (Row01.IsNull("jobw2")) ? "" : Row01["jobw2"].ToString();
                    aRow["經歷公司3"] = (Row01.IsNull("company3")) ? "" : Row01["company3"].ToString();
                    aRow["經歷職稱3"] = (Row01.IsNull("title3")) ? "" : Row01["title3"].ToString();
                    aRow["工作內容3"] = (Row01.IsNull("jobw3")) ? "" : Row01["jobw3"].ToString();
                }
                for (int i = 0; i < DT1.Columns.Count; i++)
                {
                    if (DT1.Rows[0][i].ToString().Trim() != "")
                        aRow[DT1.Rows[0][i].ToString().Trim()] = decimal.Parse(Row01["Fld" + (i+1)].ToString());
                    else
                        break;
                }
                ExporDt.Rows.Add(aRow);
            }

            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }

       
    }
}
