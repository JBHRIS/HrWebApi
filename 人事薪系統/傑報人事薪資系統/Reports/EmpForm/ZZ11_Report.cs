/* ======================================================================================================
 * 功能名稱：人事資料
 * 功能代號：ZZ11
 * 功能路徑：報表列印 > 人事 >　人事資料
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\EmpForm\ZZ11_Report.cs
 * 功能用途：
 *  
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/01/20    Daniel Chih    Ver 1.0.01     1. 修改異動種類：期間在職的語法內容
 * 2021/02/08    Daniel Chih    Ver 1.0.02     1. 修正撈不出【轉帳銀行】資料的問題
 * 2021/05/06    Daniel Chih    Ver 1.0.03     1. 修改【期間在職】資料篩選語法內容
 * 2021/07/16    Daniel Chih    Ver 1.0.04     1. 修改期間在職判斷條件，移除顯示停薪留職
 * 2021/07/20    Daniel Chih    Ver 1.0.05     1. 增加期間在職條件控制項【包含已離職人員】預設勾選
 * 2021/08/04    Daniel Chih    Ver 1.0.06     1. 修正停復日期的欄位取值錯誤問題
 * 2021/09/06    Daniel Chih    Ver 1.0.07     1. 【員工名冊】增加【現職年資】欄位
 * 2021/09/14    Daniel Chih    Ver 1.0.08     1. 【員工名冊】的【現職年資】Excel欄位增加空值的判斷
 * 2021/11/03    Daniel Chih    Ver 1.0.09     1. 修改【員工名冊】和【基本報表(NEW)】Excel增加【職等】欄位
 * 2021/11/09    Daniel Chih    Ver 1.0.10     1. 修改期間在職的資料撈取條件語法
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/11/09
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JBModule.Data.Linq;
using Microsoft.Reporting.WinForms;

namespace JBHR.Reports.EmpForm
{
    public partial class ZZ11_Report : JBControls.JBForm
    {
        //ZZ12 zz12 = new ZZ12();
        //// 宣告一個公用的物件參考。
        //public object objForm;
        empdata ds = new empdata();
        string date_b, date_e, nobr_b, nobr_e, dept_b, dept_e, depts_b, depts_e, empcd_b, empcd_e, work_b, work_e, comp_b, comp_e;
        string jobl_b, jobl_e, ttstype, report_type, date_t, report_name, data_report, username, comp_name;
        bool exportexcel, include_leave;
        decimal seniority_b, seniority_e, age_b, age_e;
        DataTable rq_zz11s3 = new DataTable();

        public ZZ11_Report(string dateb, string datee, string nobrb, string nobre, string deptb, string depte, string deptsb, string deptse, string joblb, string joble, string empcdb, string empcde, string workb, string worke, string compb, string compe, string _ttstype, string reporttype, string datet, string reportname, string datareport, bool _exportexcel, bool _include_leave, string ageb, string agee, string seniorityb, string senioritye, string _username, string compname)
        {
            InitializeComponent();
            //日期區間
            date_b = dateb; date_e = datee;
            //員工編號區間
            nobr_b = nobrb; nobr_e = nobre;
            //編制部門區間
            dept_b = deptb; dept_e = depte;
            //成本部門區間
            depts_b = deptsb; depts_e = deptse;
            //員別區間
            empcd_b = empcdb; empcd_e = empcde;
            //工作地區間
            work_b = workb; work_e = worke;
            //公司區間
            comp_b = compb; comp_e = compe;
            //異動種類
            ttstype = _ttstype;
            //報表種類
            report_type = reporttype;
            //當前日期
            date_t = datet;
            //報表種類名稱
            report_name = reportname;

            data_report = datareport;
            //是否匯出 Excel
            exportexcel = _exportexcel;
            //期間在職是否包含已離職人員
            include_leave = _include_leave;
            //年資區間
            seniority_b = decimal.Parse(seniorityb); seniority_e = decimal.Parse(senioritye);
            //年齡區間
            age_b = decimal.Parse(ageb); age_e = decimal.Parse(agee);
            //使用者名稱
            username = _username;
            //職等區間
            jobl_b = joblb; jobl_e = joble;
            //公司名稱
            comp_name = compname;
        }

        private void ZZ11_Report_Load(object sender, EventArgs e)
        {
            try
            {
                rq_zz11s3 = ds.Tables["rq_zz11s3"].Clone();
                rq_zz11s3.TableName = "rq_zz11s3";

                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                //string sqlCmd21 = "";

                DataTable rq_stdtt = new DataTable();
                rq_stdtt.Columns.Add("nobr", typeof(string));
                rq_stdtt.Columns.Add("days", typeof(int));
                rq_stdtt.PrimaryKey = new DataColumn[] { rq_stdtt.Columns["nobr"] };

                #region 折疊內容
                //string sqlCmd32 = "SELECT A.NOBR,B.JOBL_DISP AS JOBL,MIN(A.ADATE) AS ADATE" +
                //       " FROM BASETTS A" +
                //       " LEFT OUTER JOIN JOBL B ON A.JOBL=B.JOBL" +
                //       " WHERE A.NOBR BETWEEN '" + nobr_b + "' AND '" + nobr_e + "'" +
                //       " GROUP BY A.NOBR,B.JOBL_DISP" +
                //       " ORDER BY ADATE";
                //DataTable rq_nobrjobl = SqlConn.GetDataTable(sqlCmd32);
                //rq_nobrjobl.PrimaryKey = new DataColumn[] { rq_nobrjobl.Columns["nobr"], rq_nobrjobl.Columns["jobl"] };
                #endregion

                //以下內容為更新寫法 Modified By Daniel Chih 2020/12/22

                /// <summary>
                /// 統一宣告 sqlCmdSelect 的共用語法內容
                /// </summary>
                //備註：將 SELECT 另外寫在根據條件呼叫該字串的地方，可判斷是否加入 DISTINCT 等內容
                string sqlCmdSelect = " A.NOBR, A.NAME_C, A.NAME_E, A.BIRDT, A.SEX, A.IDNO, A.GSM, A.TEL1, A.POSTCODE1, A.ADDR1" +
                    ", A.ADDR2, A.ACCOUNT_NO, A.BANKNO, A.POSTCODE1, B.INDT, B.OUDT, B.STOUDT, B.DEPT AS D_NO, B.JOB, B.DEPTS, B.SALTP, B.STDT, B.STINDT" +
                    ", F.JOBL_DISP AS JOBL, F.JOB_NAME AS JOBL_NAME, B.DI, B.ROTET, B.CALOT, B.EMPCD, B.MANG, B.CARD, B.WORKCD, A.TEL2, B.COMP, B.CINDT, '' AS DESCR" +
                    ", B.JOBS, B.TTSCODE, DBO.GETTOTALYEARS(A.NOBR,'" + date_e + "') AS WK_YRS1" +
                    ", DATEDIFF(DAY,A.BIRDT,GETDATE())/365.24 AS AGE, A.MATNO, B.TAX_DATE, B.TAX_EDATE" +
                    ", DATEDIFF(DAY,STDT,STINDT) AS PSTDT_DAYS, A.ACCOUNT_MA, A.ACCOUNT_NA, B.SALADR, C.DEPT_TREE" +
                    ", B.RETCHOO, B.RETRATE, B.RETDATE, B.DEPTM, A.BASECD, B.OilSubsidy, B.JOBO, B.INSG_TYPE" +
                    ", A.EMAIL, A.TAXNO, A.CONT_MAN, A.CONT_TEL, A.CONT_GSM, A.COUNTRY";

                /// <summary>
                /// 統一宣告 sqlCmdFrom 的共用語法內容
                /// </summary>
                string sqlCmdFrom = " FROM BASE A INNER JOIN BASETTS B ON A.NOBR = B.NOBR" +
                    " LEFT OUTER JOIN DEPT C ON B.DEPT = C.D_NO" +
                    " LEFT OUTER JOIN DEPTS D ON B.DEPTS = D.D_NO" +
                    " LEFT OUTER JOIN JOBL F ON B.JOBL = F.JOBL";

                /// <summary>
                /// 統一宣告 sqlCmdWhere 的共用語法內容
                /// </summary>
                string sqlCmdWhere = " WHERE A.NOBR BETWEEN '" + nobr_b + "' AND '" + nobr_e + "'" +
                    " AND C.d_no_disp BETWEEN '" + dept_b + "' AND '" + dept_e + "'" +
                    " AND D.d_no_disp BETWEEN '" + depts_b + "' AND '" + depts_e + "'" +
                    " AND B.EMPCD BETWEEN '" + empcd_b + "' AND '" + empcd_e + "'" +
                    " AND B.WORKCD BETWEEN '" + work_b + "' AND '" + work_e + "'" +
                    " AND B.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +
                    " AND F.JOBL_DISP BETWEEN '" + jobl_b + "' AND '" + jobl_e + "'" +
                    " " + data_report + " ";

                /// <summary>
                /// 統一宣告 sqlCmdOrderBy 的共用語法內容
                /// </summary>
                string sqlCmdOrderBy = " ORDER BY B.DEPT,A.NOBR";

                #region 根據異動種類不同分別以不同條件撈不同資料

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
                    string sqlCmdWhereSup = " AND '" + date_b + "' BETWEEN B.ADATE AND B.DDATE" +
                        " AND B.TTSCODE IN('1','4','6') ";

                    //組合字串成 SQL 語法
                    string sqlCmd = " SELECT ";
                    sqlCmd += sqlCmdSelect;
                    sqlCmd += sqlCmdSelectSup;
                    sqlCmd += sqlCmdFrom;
                    sqlCmd += sqlCmdFromSup;
                    sqlCmd += sqlCmdWhere;
                    sqlCmd += sqlCmdWhereSup;
                    sqlCmd += sqlCmdOrderBy;


                    //清空語法補充部分的字串內容
                    sqlCmdSelectSup = "";
                    sqlCmdFromSup = "";
                    sqlCmdWhereSup = "";

                    rq_zz11s3 = SqlConn.GetDataTable(sqlCmd);

                    //清空 sqlCmd 字串內容
                    sqlCmd = "";
                }

                /// <summary>
                /// 異動種類：新進
                /// </summary>
                else if (ttstype == "1")
                {
                    //設定 SELECT 語法的補充部分
                    string sqlCmdSelectSup = "";
                    //設定 From 語法的補充部分
                    string sqlCmdFromSup = "";
                    //設定 WHERE 語法的補充部分
                    string sqlCmdWhereSup = " AND B.INDT BETWEEN '" + date_b + "' AND '" + date_e + "'" +
                        " AND B.TTSCODE IN('1') ";
                    //Todo: 確認TTSCODE 1,4會不會重複 - Daniel - 20210719
                    //更新：有，會有重複資料


                    //組合字串成 SQL 語法
                    string sqlCmd = " SELECT " + sqlCmdSelect + sqlCmdSelectSup + sqlCmdFrom + sqlCmdFromSup + sqlCmdWhere + sqlCmdWhereSup + sqlCmdOrderBy;

                    //清空語法補充部分的字串內容
                    sqlCmdSelectSup = "";
                    sqlCmdFromSup = "";
                    sqlCmdWhereSup = "";

                    rq_zz11s3 = SqlConn.GetDataTable(sqlCmd);

                    //清空 sqlCmd 字串內容
                    sqlCmd = "";


                    string sqlCmda = "select nobr,oudt from basetts ";
                    sqlCmda += string.Format(@" where '{0}' between adate and ddate", date_e);
                    sqlCmda += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                    sqlCmda += string.Format(@" and oudt between '{0}' and '{1}'", date_b, date_e);
                    DataTable rq_outnobr = SqlConn.GetDataTable(sqlCmda);
                    rq_outnobr.PrimaryKey = new DataColumn[] { rq_outnobr.Columns["nobr"] };
                    foreach (DataRow Row in rq_zz11s3.Rows)
                    {
                        DataRow row = rq_outnobr.Rows.Find(Row["nobr"].ToString());
                        if (row != null)
                            Row["oudt"] = DateTime.Parse(row["oudt"].ToString());
                    }
                }

                /// <summary>
                /// 異動種類：離職
                /// </summary>
                else if (ttstype == "2")
                {
                    //設定 SELECT 語法的補充部分
                    string sqlCmdSelectSup = ", H.OUTNAME, B.OUTCD";
                    //設定 FROM 語法的補充部分
                    string sqlCmdFromSup = " LEFT OUTER JOIN OUTCD H ON B.OUTCD=H.OUTCD";
                    //設定 WHERE 語法的補充部分
                    string sqlCmdWhereSup = " AND B.ADATE BETWEEN DATEADD(day,1,'" + date_b + "' ) AND DATEADD(DAY,1,'" + date_e + "')" +
                        " AND B.TTSCODE IN('2','5') ";
                    //Todo: 確認TTSCODE 2,5會不會重複 - Daniel - 20210719

                    //組合字串成 SQL 語法
                    string sqlCmd = " SELECT " + sqlCmdSelect + sqlCmdSelectSup + sqlCmdFrom + sqlCmdFromSup + sqlCmdWhere + sqlCmdWhereSup + sqlCmdOrderBy;

                    //清空語法補充部分的字串內容
                    sqlCmdSelectSup = "";
                    sqlCmdFromSup = "";
                    sqlCmdWhereSup = "";

                    rq_zz11s3 = SqlConn.GetDataTable(sqlCmd);

                    //清空 sqlCmd 字串內容
                    sqlCmd = "";
                }

                /// <summary>
                /// 異動種類：全部
                /// </summary>
                else if (ttstype == "3")
                {
                    //設定 SELECT 語法的補充部分
                    string sqlCmdSelectSup = "";
                    //設定 From 語法的補充部分
                    string sqlCmdFromSup = "";
                    //設定 WHERE 語法的補充部分
                    string sqlCmdWhereSup = " AND '" + date_e + "' BETWEEN B.ADATE AND B.DDATE";

                    //組合字串成 SQL 語法
                    string sqlCmd = " SELECT " + sqlCmdSelect + sqlCmdSelectSup + sqlCmdFrom + sqlCmdFromSup + sqlCmdWhere + sqlCmdWhereSup + sqlCmdOrderBy;

                    //清空語法補充部分的字串內容
                    sqlCmdSelectSup = "";
                    sqlCmdFromSup = "";
                    sqlCmdWhereSup = "";

                    rq_zz11s3 = SqlConn.GetDataTable(sqlCmd);

                    //清空 sqlCmd 字串內容
                    sqlCmd = "";
                }

                /// <summary>
                /// 異動種類：新進不含離職
                /// </summary>
                else if (ttstype == "4")
                {
                    //設定 SELECT 語法的補充部分
                    string sqlCmdSelectSup = "";
                    //設定 From 語法的補充部分
                    string sqlCmdFromSup = "";
                    //設定 WHERE 語法的補充部分
                    string sqlCmdWhereSup = " AND B.ADATE BETWEEN '" + date_b + "' AND '" + date_e + "'" +
                        " AND B.TTSCODE IN ('1','4')" +
                        " AND A.NOBR NOT IN" +
                        " (SELECT NOBR FROM BASETTS WHERE '" + DateTime.Now.Date + "' BETWEEN ADATE AND DDATE" +
                        " AND TTSCODE IN('2','3','5') GROUP BY NOBR)";

                    //組合字串成 SQL 語法
                    string sqlCmd = " SELECT " + sqlCmdSelect + sqlCmdSelectSup + sqlCmdFrom + sqlCmdFromSup + sqlCmdWhere + sqlCmdWhereSup + sqlCmdOrderBy;

                    //清空語法補充部分的字串內容
                    sqlCmdSelectSup = "";
                    sqlCmdFromSup = "";
                    sqlCmdWhereSup = "";

                    rq_zz11s3 = SqlConn.GetDataTable(sqlCmd);

                    //清空 sqlCmd 字串內容
                    sqlCmd = "";
                }

                /// <summary>
                /// 異動種類：留職停薪
                /// </summary>
                else if (ttstype == "5")
                {
                    //Todo: 為什麼信封不一樣 要另外判斷 - Daniel - 20210719
                    if (report_type == "信封")
                    {
                        //設定 SELECT 語法的補充部分
                        string sqlCmdSelectSup = "";
                        //設定 From 語法的補充部分
                        string sqlCmdFromSup = "";
                        //設定 WHERE 語法的補充部分
                        string sqlCmdWhereSup = " AND '" + date_e + "'  BETWEEN B.ADATE AND B.DDATE" +
                            " AND B.TTSCODE IN('3')";

                        //組合字串成 SQL 語法
                        string sqlCmd = " SELECT " + sqlCmdSelect + sqlCmdSelectSup + sqlCmdFrom + sqlCmdFromSup + sqlCmdWhere + sqlCmdWhereSup + sqlCmdOrderBy;

                        //清空語法補充部分的字串內容
                        sqlCmdSelectSup = "";
                        sqlCmdFromSup = "";
                        sqlCmdWhereSup = "";

                        rq_zz11s3 = SqlConn.GetDataTable(sqlCmd);

                        //清空 sqlCmd 字串內容
                        sqlCmd = "";
                    }
                    else
                    {
                        //設定 SELECT 語法的補充部分
                        string sqlCmdSelectSup = "";
                        //設定 From 語法的補充部分
                        string sqlCmdFromSup = "";
                        //設定 WHERE 語法的補充部分
                        string sqlCmdWhereSup = " AND B.ADATE BETWEEN '" + date_b + "' AND '" + date_e + "'" +
                            " AND B.TTSCODE in ('3','4','5')";
                        //Todo: 確認抓取的範圍會不會有漏撈（EX：6不抓嗎？） - Daniel - 20210719

                        //組合字串成 SQL 語法
                        string sqlCmd = " SELECT DISTINCT " + sqlCmdSelect + sqlCmdSelectSup + sqlCmdFrom + sqlCmdFromSup + sqlCmdWhere + sqlCmdWhereSup + sqlCmdOrderBy;

                        //清空語法補充部分的字串內容
                        sqlCmdSelectSup = "";
                        sqlCmdFromSup = "";
                        sqlCmdWhereSup = "";

                        rq_zz11s3 = SqlConn.GetDataTable(sqlCmd);

                        //清空 sqlCmd 字串內容
                        sqlCmd = "";

                        rq_zz11s3.Columns.Add("stindt", typeof(DateTime));
                        rq_zz11s3.Columns.Add("pstdt_days", typeof(int));

                        string sqlCmda = "select nobr,stdt,stindt,datediff(day,stdt,stindt) as days from basetts ";
                        sqlCmda += string.Format(@" where stindt between '{0}' and '{1}'", date_b, DateTime.Parse(date_e).AddDays(1).ToString("yyyy/MM/dd"));
                        sqlCmda += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                        sqlCmda += " and ttscode='4'";
                        DataTable rq_stdt = SqlConn.GetDataTable(sqlCmda);
                        rq_stdt.PrimaryKey = new DataColumn[] { rq_stdt.Columns["nobr"], rq_stdt.Columns["stdt"] };
                        string nobrstdt1 = "";
                        foreach (DataRow Row in rq_zz11s3.Rows)
                        {
                            object[] _vavle = new object[2];
                            _vavle[0] = Row["nobr"].ToString();
                            _vavle[1] = DateTime.Parse(Row["stdt"].ToString());
                            string nobrstdt = Row["nobr"].ToString().Trim() + DateTime.Parse(Row["stdt"].ToString()).ToString("yyyyMMdd");
                            if (nobrstdt != nobrstdt1)
                            {
                                DataRow row = rq_stdt.Rows.Find(_vavle);
                                if (row != null)
                                {
                                    Row["stindt"] = DateTime.Parse(row["stindt"].ToString());
                                    Row["pstdt_days"] = int.Parse(row["days"].ToString());
                                }
                                nobrstdt1 = Row["nobr"].ToString().Trim() + DateTime.Parse(Row["stdt"].ToString()).ToString("yyyyMMdd");
                            }
                            else
                                Row.Delete();
                        }
                        rq_zz11s3.AcceptChanges();

                        sqlCmda = "";
                    }
                }

                /// <summary>
                /// 異動種類：期間在職
                /// </summary>
                else if (ttstype == "6")
                {
                    //設定 SELECT 語法的補充部分
                    string sqlCmdSelectSup = "";
                    //設定 From 語法的補充部分
                    string sqlCmdFromSup = "";
                    //設定 WHERE 語法的補充部分
                    string sqlCmdWhereSup = " AND '" + date_e + "' BETWEEN B.ADATE AND B.DDATE ";
                    sqlCmdWhereSup += " AND EXISTS(SELECT 1 FROM BASETTS WHERE BASETTS.NOBR = A.NOBR AND BASETTS.TTSCODE IN ('1','4','6') ";
                    sqlCmdWhereSup += " AND BASETTS.ADATE <= '" + date_e + "' ";
                    sqlCmdWhereSup += " AND BASETTS.DDATE >= '" + date_b + "') ";

                    if (!include_leave)
                    {
                        sqlCmdWhereSup += " AND B.TTSCODE IN ('1','4','6') ";
                    }
                    //Todo【已完成】：檢查此邏輯是否有其必要，會否有問題  ↑ 這段 - Daniel - 20210719

                    //組合字串成 SQL 語法
                    string sqlCmd = " SELECT " + sqlCmdSelect + sqlCmdSelectSup + sqlCmdFrom + sqlCmdFromSup + sqlCmdWhere + sqlCmdWhereSup + sqlCmdOrderBy;

                    //清空語法補充部分的字串內容
                    sqlCmdSelectSup = "";
                    sqlCmdFromSup = "";
                    sqlCmdWhereSup = "";

                    rq_zz11s3 = SqlConn.GetDataTable(sqlCmd);

                    //清空 sqlCmd 字串內容
                    sqlCmd = "";


                    foreach (DataRow Row in rq_zz11s3.Rows)
                    {
                        Int32 _indt = Convert.ToInt32(DateTime.Parse(Row["indt"].ToString()).ToString("yyyyMMdd"));
                        Int32 _oudt = (Row.IsNull("oudt")) ? 0 : Convert.ToInt32(DateTime.Parse(Row["oudt"].ToString()).ToString("yyyyMMdd"));
                        Int32 _datee = Convert.ToInt32(DateTime.Parse(date_e).ToString("yyyyMMdd"));
                        Int32 _dateb = Convert.ToInt32(DateTime.Parse(date_b).ToString("yyyyMMdd"));
                        if (_indt > _datee)
                            Row.Delete();
                        else if (_oudt <= _dateb && Row["ttscode"].ToString().Trim() == "2")
                            Row.Delete();
                    }
                    rq_zz11s3.AcceptChanges();
                }

                #endregion

                #region 舊寫法

                #region 異動種類：在職
                //if (ttstype == "0")
                //{
                //    string sqlCmd = "SELECT A.NOBR,A.NAME_C,A.NAME_E,A.BIRDT,A.SEX,A.IDNO,A.GSM,A.TEL1,A.POSTCODE1,A.ADDR1," +
                //            "A.ADDR2,A.ACCOUNT_NO,A.POSTCODE1,B.INDT,B.OUDT,B.STOUDT,B.DEPT AS D_NO,B.JOB,B.DEPTS,B.SALTP,B.STDT,B.STINDT," +
                //            "F.JOBL_DISP AS JOBL,F.JOB_NAME AS JOBL_NAME,B.DI,B.ROTET,B.CALOT,B.EMPCD,B.MANG,B.CARD,B.WORKCD,A.TEL2,B.COMP,B.CINDT,'' AS DESCR" +
                //            //"DATEDIFF(DAY,B.INDT,'" + date_e + "') AS WK_YRS1,"+
                //            ",B.JOBS,B.TTSCODE,DBO.GETTOTALYEARS(A.NOBR,'" + date_e + "') AS WK_YRS1," +
                //            "DATEDIFF(DAY,A.BIRDT,GETDATE())/365.24 AS AGE,A.MATNO,B.TAX_DATE,B.TAX_EDATE," +
                //            "DATEDIFF(DAY,STDT,STINDT) AS PSTDT_DAYS,A.ACCOUNT_MA,A.ACCOUNT_NA,B.SALADR,C.DEPT_TREE" +
                //            ",B.RETCHOO,B.RETRATE,B.RETDATE,B.DEPTM,A.BASECD,B.OilSubsidy,B.JOBO,B.INSG_TYPE" +
                //            ",A.EMAIL,A.TAXNO,A.CONT_MAN,A.CONT_TEL,A.CONT_GSM,A.COUNTRY" +
                //            " FROM BASE A INNER JOIN BASETTS B ON A.NOBR=B.NOBR" +
                //            " LEFT OUTER JOIN DEPT C ON B.DEPT=C.D_NO" +
                //            " LEFT OUTER JOIN JOBL F ON B.JOBL=F.JOBL" +                            
                //            " WHERE '" + date_b + "' BETWEEN B.ADATE AND B.DDATE" +
                //            " AND A.NOBR BETWEEN '" + nobr_b + "' AND '" + nobr_e + "'" +
                //            " AND C.d_no_disp BETWEEN '" + dept_b + "' AND '" + dept_e + "'" +
                //            " AND B.EMPCD BETWEEN '" + empcd_b + "' AND '" + empcd_e + "'" +
                //            " AND B.WORKCD BETWEEN '" + work_b + "' AND '" + work_e + "'" +
                //            " AND B.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +
                //            " AND F.JOBL_DISP BETWEEN '" + jobl_b + "' AND '" + jobl_e + "'" +  
                //            " AND B.TTSCODE IN('1','4','6') " +                           
                //            " " + data_report + " " +
                //            " ORDER BY B.DEPT,A.NOBR";
                //    rq_zz11s3 = SqlConn.GetDataTable(sqlCmd);

                //    sqlCmd = "";
                //}
                #endregion

                #region 異動種類：新進
                //else if (ttstype == "1")
                //{
                //    string sqlCmd = "SELECT A.NOBR,A.NAME_C,A.NAME_E,A.BIRDT,A.SEX,A.IDNO,A.GSM,A.TEL1,A.POSTCODE1,A.ADDR1,A.TEL2," +
                //        "A.ADDR2,A.ACCOUNT_NO,A.BANKNO,B.INDT,B.OUDT,B.STOUDT,B.DEPT AS D_NO,B.JOB,B.DEPTS,B.SALTP,B.STDT,B.STINDT," +
                //        "F.JOBL_DISP AS JOBL,F.JOB_NAME AS JOBL_NAME,B.DI,B.ROTET,B.CALOT,B.EMPCD,B.MANG,B.CARD,B.WORKCD,'' AS DESCR," +
                //        //"DATEDIFF(DAY,B.INDT,'" + date_e + "') AS WK_YRS1,"+
                //        "B.COMP,B.CINDT,B.JOBS,B.TTSCODE,DBO.GETTOTALYEARS(A.NOBR,'" + date_e + "') AS WK_YRS1," +
                //        "DATEDIFF(DAY,A.BIRDT,GETDATE())/365.24 AS AGE,A.MATNO,B.TAX_DATE,B.TAX_EDATE," +
                //        "DATEDIFF(DAY,STDT,STINDT) AS PSTDT_DAYS,A.ACCOUNT_MA,A.ACCOUNT_NA,C.DEPT_TREE" +
                //        ",B.RETCHOO,B.RETRATE,B.RETDATE,B.SALADR,B.DEPTM,A.BASECD,B.OilSubsidy,B.JOBO,B.INSG_TYPE" +
                //        ",A.EMAIL,A.TAXNO,A.CONT_MAN,A.CONT_TEL,A.CONT_GSM,A.COUNTRY" +
                //        " FROM BASE A,BASETTS B " +
                //        " LEFT OUTER JOIN DEPT C ON B.DEPT=C.D_NO" +
                //        " LEFT OUTER JOIN JOBL F ON B.JOBL=F.JOBL" +                        
                //        " WHERE A.NOBR=B.NOBR" +
                //        " AND B.INDT BETWEEN '" + date_b + "' AND '" + date_e + "'" +
                //        " AND A.NOBR BETWEEN '" + nobr_b + "' AND '" + nobr_e + "'" +
                //        " AND B.EMPCD BETWEEN '" + empcd_b + "' AND '" + empcd_e + "'" +
                //        //" AND '" + date_e + "' BETWEEN B.ADATE AND B.DDATE " + data_report + "" +
                //        " AND C.d_no_disp BETWEEN '" + dept_b + "' AND '" + dept_e + "'" +
                //        " AND B.WORKCD BETWEEN '" + work_b + "' AND '" + work_e + "'" +
                //        " AND B.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +
                //        " AND F.JOBL_DISP BETWEEN '" + jobl_b + "' AND '" + jobl_e + "'" +  
                //        " AND B.TTSCODE IN('1','4') " +                       
                //         " " + data_report + " " +
                //        " ORDER BY B.DEPT,A.NOBR";
                //    rq_zz11s3 = SqlConn.GetDataTable(sqlCmd);


                //    string sqlCmda = "select nobr,oudt from basetts ";
                //    sqlCmda += string.Format(@" where '{0}' between adate and ddate", date_e);
                //    sqlCmda += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                //    sqlCmda += string.Format(@" and oudt between '{0}' and '{1}'", date_b, date_e);
                //    DataTable rq_outnobr = SqlConn.GetDataTable(sqlCmda);
                //    rq_outnobr.PrimaryKey = new DataColumn[] { rq_outnobr.Columns["nobr"] };
                //    foreach (DataRow Row in rq_zz11s3.Rows)
                //    {
                //        DataRow row = rq_outnobr.Rows.Find(Row["nobr"].ToString());
                //        if (row != null)
                //            Row["oudt"] = DateTime.Parse(row["oudt"].ToString());
                //    }

                //    sqlCmd = "";
                //    sqlCmda = "";
                //}
                #endregion

                #region 異動種類：離職
                //else if (ttstype == "2")
                //{
                //    string sqlCmd = "SELECT A.NOBR,A.NAME_C,A.NAME_E,A.BIRDT,A.SEX,A.IDNO,A.GSM,A.TEL1,A.POSTCODE1,A.ADDR1," +
                //        "A.ADDR2,A.ACCOUNT_NO,A.BANKNO,B.INDT,B.OUDT,B.STOUDT,B.DEPT AS D_NO,B.JOB,B.DEPTS,B.SALTP,B.STDT,B.STINDT," +
                //        "F.JOBL_DISP AS JOBL,F.JOB_NAME AS JOBL_NAME,B.DI,B.ROTET,B.CALOT,B.EMPCD,B.MANG,B.CARD,B.WORKCD,B.OUTCD," +
                //        //"DATEDIFF(DAY,B.INDT,'" + date_e + "') AS WK_YRS1,"+
                //        "H.OUTNAME,A.TEL2,B.COMP,B.CINDT,B.JOBS,B.TTSCODE,DBO.GETTOTALYEARS(A.NOBR,'" + date_e + "') AS WK_YRS1," +
                //        "DATEDIFF(DAY,A.BIRDT,GETDATE())/365.24 AS AGE,A.MATNO,B.TAX_DATE,B.TAX_EDATE," +
                //        "DATEDIFF(DAY,STDT,STINDT) AS PSTDT_DAYS,A.ACCOUNT_MA,A.ACCOUNT_NA,C.DEPT_TREE" +
                //        ",B.RETCHOO,B.RETRATE,B.RETDATE,B.SALADR,B.DEPTM,A.BASECD,B.OilSubsidy,B.JOBO,B.INSG_TYPE" +
                //        ",A.EMAIL,A.TAXNO,A.CONT_MAN,A.CONT_TEL,A.CONT_GSM,A.COUNTRY" +
                //        " FROM BASE A,BASETTS B" +
                //        " LEFT OUTER JOIN DEPT C ON B.DEPT=C.D_NO" +
                //        " LEFT OUTER JOIN JOBL F ON B.JOBL=F.JOBL" +
                //        " LEFT OUTER JOIN OUTCD H ON B.OUTCD=H.OUTCD" +                       
                //        " WHERE A.NOBR=B.NOBR" +
                //        " AND B.ADATE BETWEEN DATEADD(day,1,'" + date_b + "' ) AND DATEADD(DAY,1,'" + date_e + "')" +
                //        " AND A.NOBR BETWEEN '" + nobr_b + "' AND '" + nobr_e + "'" +
                //        " AND C.d_no_disp BETWEEN '" + dept_b + "' AND '" + dept_e + "'" +
                //        " AND B.EMPCD BETWEEN '" + empcd_b + "' AND '" + empcd_e + "' " + data_report + "" +
                //        " AND B.WORKCD BETWEEN '" + work_b + "' AND '" + work_e + "'" +
                //        " AND B.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +
                //        " AND F.JOBL_DISP BETWEEN '" + jobl_b + "' AND '" + jobl_e + "'" +  
                //        " AND B.TTSCODE IN ('2','5')" +
                //         " " + data_report + " " +
                //        " ORDER BY B.DEPT,A.NOBR";
                //    rq_zz11s3 = SqlConn.GetDataTable(sqlCmd);

                //    sqlCmd = "";
                //}
                #endregion

                #region 異動種類：全部
                //else if (ttstype == "3")
                //{
                //    string sqlCmd = "SELECT A.NOBR,A.NAME_C,A.NAME_E,A.BIRDT,A.SEX,A.IDNO,A.GSM,A.TEL1,A.POSTCODE1,A.ADDR1,A.TEL2," +
                //        "A.ADDR2,A.ACCOUNT_NO,A.BANKNO,B.INDT,B.OUDT,B.STOUDT,B.DEPT AS D_NO,B.JOB,B.DEPTS,B.SALTP,B.STDT,B.STINDT," +
                //        "F.JOBL_DISP AS JOBL,F.JOB_NAME AS JOBL_NAME,B.DI,B.ROTET,B.CALOT,B.EMPCD,B.MANG,B.CARD,B.WORKCD,'' AS DESCR," +
                //        //"DATEDIFF(DAY,B.INDT,'" + date_e + "') AS WK_YRS1,"+
                //        "B.COMP,B.CINDT,B.JOBS,B.TTSCODE,DBO.GETTOTALYEARS(A.NOBR,'" + date_e + "') AS WK_YRS1," +
                //        "DATEDIFF(DAY,A.BIRDT,GETDATE())/365.24 AS AGE,A.MATNO,B.TAX_DATE,B.TAX_EDATE," +
                //        "DATEDIFF(DAY,STDT,STINDT) AS PSTDT_DAYS,A.ACCOUNT_MA,A.ACCOUNT_NA,C.DEPT_TREE " +
                //        ",B.RETCHOO,B.RETRATE,B.RETDATE,B.SALADR,B.DEPTM,A.BASECD,B.OilSubsidy,B.JOBO,B.INSG_TYPE" +
                //        ",A.EMAIL,A.TAXNO,A.CONT_MAN,A.CONT_TEL,A.CONT_GSM,A.COUNTRY" +
                //        " FROM BASE A,BASETTS B " +
                //        " LEFT OUTER JOIN DEPT C ON B.DEPT=C.D_NO" +
                //        " LEFT OUTER JOIN JOBL F ON B.JOBL=F.JOBL" +                        
                //        " WHERE A.NOBR=B.NOBR" +
                //        " AND '" + date_e + "' BETWEEN B.ADATE AND B.DDATE" +
                //        " AND A.NOBR BETWEEN '" + nobr_b + "' AND '" + nobr_e + "'" +
                //        " AND B.EMPCD BETWEEN '" + empcd_b + "' AND '" + empcd_e + "'" +
                //        " AND C.d_no_disp BETWEEN '" + dept_b + "' AND '" + dept_e + "'" +
                //        " AND B.WORKCD BETWEEN '" + work_b + "' AND '" + work_e + "'" +
                //        " AND B.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +
                //        " AND F.JOBL_DISP BETWEEN '" + jobl_b + "' AND '" + jobl_e + "'" +  
                //         " " + data_report + " " +
                //        " ORDER BY B.DEPT,A.NOBR";
                //    rq_zz11s3 = SqlConn.GetDataTable(sqlCmd);

                //    sqlCmd = "";
                //}
                #endregion

                #region 異動種類：新進不含離職
                //         else if (ttstype == "4")
                //         {
                //             string sqlCmd = "SELECT A.NOBR,A.NAME_C,A.NAME_E,A.BIRDT,A.SEX,A.IDNO,A.GSM,A.TEL1,A.POSTCODE1,A.ADDR1," +
                //                 "A.ADDR2,A.ACCOUNT_NO,A.BANKNO,B.INDT,B.OUDT,B.STOUDT,B.DEPT AS D_NO,B.JOB,B.DEPTS,B.SALTP,B.STDT,B.STINDT," +
                //                 "F.JOBL_DISP AS JOBL,F.JOB_NAME AS JOBL_NAME,B.DI,B.ROTET,B.CALOT,B.EMPCD,B.MANG,B.CARD,B.WORKCD,A.TEL2,B.COMP" +
                //                 //"DATEDIFF(DAY,B.INDT,'" + date_e + "') AS WK_YRS1,"+
                //                 ",B.CINDT,B.JOBS,B.TTSCODE,DBO.GETTOTALYEARS(A.NOBR,'" + date_e + "') AS WK_YRS1," +
                //                 "DATEDIFF(DAY,A.BIRDT,GETDATE())/365.24 AS AGE,A.MATNO,B.TAX_DATE,B.TAX_EDATE," +
                //                 "DATEDIFF(DAY,STDT,STINDT) AS PSTDT_DAYS,A.ACCOUNT_MA,A.ACCOUNT_NA,C.DEPT_TREE " +
                //                 ",B.RETCHOO,B.RETRATE,B.RETDATE,B.SALADR,B.DEPTM,A.BASECD,B.OilSubsidy,B.JOBO,B.INSG_TYPE" +
                //                 ",A.EMAIL,A.TAXNO,A.CONT_MAN,A.CONT_TEL,A.CONT_GSM,A.COUNTRY" +
                //                 " FROM BASE A,BASETTS B" +
                //                 " LEFT OUTER JOIN DEPT C ON B.DEPT=C.D_NO" +
                //                 " LEFT OUTER JOIN JOBL F ON B.JOBL=F.JOBL" +                        
                //                 " WHERE A.NOBR=B.NOBR" +
                //                 " AND B.ADATE BETWEEN '" + date_b + "' AND '" + date_e + "'" +
                //                 " AND A.NOBR BETWEEN '" + nobr_b + "' AND '" + nobr_e + "'" +
                //                 " AND B.EMPCD BETWEEN '" + empcd_b + "' AND '" + empcd_e + "' " + data_report + "" +
                //                 " AND C.d_no_disp BETWEEN '" + dept_b + "' AND '" + dept_e + "'" +
                //                 " AND B.WORKCD BETWEEN '" + work_b + "' AND '" + work_e + "'" +
                //                 " AND B.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +
                //                 " AND F.JOBL_DISP BETWEEN '" + jobl_b + "' AND '" + jobl_e + "'" +  
                //                 " AND B.TTSCODE IN ('1','4')" +
                //                 " AND A.NOBR NOT IN"+
                //  " (SELECT NOBR FROM BASETTS WHERE '"+DateTime.Now.Date+"' BETWEEN ADATE AND DDATE"+
                //" AND TTSCODE IN('2','3','5') GROUP BY NOBR)"+
                //                  " " + data_report + " " +
                //                 " ORDER BY B.DEPT,A.NOBR";
                //             rq_zz11s3 = SqlConn.GetDataTable(sqlCmd);

                //             sqlCmd = "";
                //         }
                #endregion

                #region 異動種類：留職停薪
                //else if (ttstype == "5")
                //{
                //    if (report_type == "信封")
                //    {
                //        string sqlCmd = "SELECT A.NOBR,A.NAME_C,A.NAME_E,A.BIRDT,A.SEX,A.IDNO,A.GSM,A.TEL1,A.POSTCODE1,A.ADDR1," +
                //            "A.ADDR2,A.ACCOUNT_NO,A.BANKNO,B.INDT,B.OUDT,B.STOUDT,B.DEPT AS D_NO,B.JOB,B.DEPTS,B.SALTP,B.STDT,B.STINDT," +
                //            "F.JOBL_DISP AS JOBL,F.JOB_NAME AS JOBL_NAME,B.DI,B.ROTET,B.CALOT,B.EMPCD,B.MANG,B.CARD,B.WORKCD,A.TEL2,B.COMP," +
                //            //"DATEDIFF(DAY,B.INDT,'" + date_e + "') AS WK_YRS1,"+
                //            "B.CINDT,B.JOBS,B.TTSCODE,DBO.GETTOTALYEARS(A.NOBR,'" + date_e + "') AS WK_YRS1," +
                //            "DATEDIFF(DAY,A.BIRDT,GETDATE())/365.24 AS AGE,A.MATNO,B.TAX_DATE,B.TAX_EDATE," +
                //            "DATEDIFF(DAY,STDT,STINDT) AS PSTDT_DAYS,A.ACCOUNT_MA,A.ACCOUNT_NA,C.DEPT_TREE " +
                //            ",B.RETCHOO,B.RETRATE,B.RETDATE,B.SALADR,B.DEPTM,A.BASECD,B.OilSubsidy,B.JOBO,B.INSG_TYPE" +
                //            ",A.EMAIL,A.TAXNO,A.CONT_MAN,A.CONT_TEL,A.CONT_GSM,A.COUNTRY" +
                //            " FROM BASE A,BASETTS B" +
                //            " LEFT OUTER JOIN DEPT C ON B.DEPT=C.D_NO" +
                //            " LEFT OUTER JOIN JOBL F ON B.JOBL=F.JOBL" +                            
                //            " WHERE A.NOBR=B.NOBR" +
                //            " AND  '" + date_e + "'  BETWEEN B.ADATE AND B.DDATE" +
                //            " AND A.NOBR BETWEEN '" + nobr_b + "' AND '" + nobr_e + "'" +
                //            " AND C.d_no_disp BETWEEN '" + dept_b + "' AND '" + dept_e + "'" +
                //            " AND B.EMPCD BETWEEN '" + empcd_b + "' AND '" + empcd_e + "' " + data_report + "" +
                //            " AND B.TTSCODE IN('3')" +
                //            " AND B.WORKCD BETWEEN '" + work_b + "' AND '" + work_e + "'" +
                //            " AND B.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +
                //            " AND F.JOBL_DISP BETWEEN '" + jobl_b + "' AND '" + jobl_e + "'" +  
                //             " " + data_report + " " +
                //            " ORDER BY B.DEPT,A.NOBR";
                //        rq_zz11s3 = SqlConn.GetDataTable(sqlCmd);

                //        sqlCmd = "";
                //    }
                //    else
                //    {
                //        string sqlCmd = "SELECT Distinct A.NOBR,A.NAME_C,A.NAME_E,A.BIRDT,A.SEX,A.IDNO,A.GSM,A.TEL1,A.POSTCODE1,A.ADDR1," +
                //            "A.ADDR2,A.ACCOUNT_NO,A.BANKNO,B.INDT,B.OUDT,B.STOUDT,B.DEPT AS D_NO,B.JOB,B.DEPTS,B.SALTP,B.STDT," +
                //            "F.JOBL_DISP AS JOBL,F.JOB_NAME AS JOBL_NAME,B.DI,B.ROTET,B.CALOT,B.EMPCD,B.MANG,B.CARD,B.WORKCD,A.TEL2,B.COMP," +
                //            //"DATEDIFF(DAY,B.INDT,'" + date_e + "') AS WK_YRS1,"+
                //            "B.CINDT,B.JOBS,B.TTSCODE,DBO.GETTOTALYEARS(A.NOBR,'" + date_e + "') AS WK_YRS1," +
                //            "DATEDIFF(DAY,A.BIRDT,GETDATE())/365.24 AS AGE,A.MATNO,B.TAX_DATE,B.TAX_EDATE," +
                //            "A.ACCOUNT_MA,A.ACCOUNT_NA,C.DEPT_TREE " +
                //            ",B.RETCHOO,B.RETRATE,B.RETDATE,B.SALADR,B.DEPTM,A.BASECD,B.OilSubsidy,B.JOBO,B.INSG_TYPE" +
                //            ",A.EMAIL,A.TAXNO,A.CONT_MAN,A.CONT_TEL,A.CONT_GSM,A.COUNTRY" +
                //            " FROM BASE A,BASETTS B" +
                //            " LEFT OUTER JOIN DEPT C ON B.DEPT=C.D_NO" +
                //            " LEFT OUTER JOIN JOBL F ON B.JOBL=F.JOBL" +                            
                //            " WHERE A.NOBR=B.NOBR" +
                //            " AND B.ADATE BETWEEN '" + date_b + "' AND '" + date_e + "'" +
                //            " AND A.NOBR BETWEEN '" + nobr_b + "' AND '" + nobr_e + "'" +
                //            " AND C.d_no_disp BETWEEN '" + dept_b + "' AND '" + dept_e + "'" +
                //            " AND B.EMPCD BETWEEN '" + empcd_b + "' AND '" + empcd_e + "' " + data_report + "" +
                //            " AND B.TTSCODE in ('3','4','5')" +
                //            " AND B.WORKCD BETWEEN '" + work_b + "' AND '" + work_e + "'" +
                //            " AND B.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +
                //            " AND F.JOBL_DISP BETWEEN '" + jobl_b + "' AND '" + jobl_e + "'" +  
                //             " " + data_report + " " +
                //            " ORDER BY B.DEPT,A.NOBR";
                //        rq_zz11s3 = SqlConn.GetDataTable(sqlCmd);

                //        rq_zz11s3.Columns.Add("stindt", typeof(DateTime));
                //        rq_zz11s3.Columns.Add("pstdt_days", typeof(int));

                //        string sqlCmda = "select nobr,stdt,stindt,datediff(day,stdt,stindt) as days from basetts ";
                //        sqlCmda += string.Format(@" where stindt between '{0}' and '{1}'", date_b, DateTime.Parse(date_e).AddDays(1).ToString("yyyy/MM/dd"));
                //        sqlCmda += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);                        
                //        sqlCmda += " and ttscode='4'";
                //        DataTable rq_stdt = SqlConn.GetDataTable(sqlCmda);
                //        rq_stdt.PrimaryKey = new DataColumn[] { rq_stdt.Columns["nobr"], rq_stdt.Columns["stdt"] };
                //        string nobrstdt1 = "";
                //        foreach (DataRow Row in rq_zz11s3.Rows)
                //        {
                //            object[] _vavle = new object[2];
                //            _vavle[0] = Row["nobr"].ToString();
                //            _vavle[1] = DateTime.Parse(Row["stdt"].ToString());
                //            string nobrstdt = Row["nobr"].ToString().Trim() + DateTime.Parse(Row["stdt"].ToString()).ToString("yyyyMMdd");
                //            if (nobrstdt != nobrstdt1)
                //            {
                //                DataRow row = rq_stdt.Rows.Find(_vavle);
                //                if (row != null)
                //                {
                //                    Row["stindt"] = DateTime.Parse(row["stindt"].ToString());
                //                    Row["pstdt_days"] = int.Parse(row["days"].ToString());
                //                }
                //                nobrstdt1 = Row["nobr"].ToString().Trim() + DateTime.Parse(Row["stdt"].ToString()).ToString("yyyyMMdd");
                //            }
                //            else
                //                Row.Delete();                           
                //        }
                //        rq_zz11s3.AcceptChanges();

                //        sqlCmd = "";
                //        sqlCmda = "";
                //    }
                //}
                #endregion

                #region 異動種類：期間在職
                //else if (ttstype == "6")
                //{
                //    string sqlCmd = "SELECT A.NOBR,A.NAME_C,A.NAME_E,A.BIRDT,A.SEX,A.IDNO,A.GSM,A.TEL1,A.POSTCODE1,A.ADDR1,A.TEL2," +
                //        "A.ADDR2,A.ACCOUNT_NO,A.BANKNO,B.INDT,B.OUDT,B.STOUDT,B.DEPT AS D_NO,B.JOB,B.DEPTS,B.SALTP,B.STDT,B.STINDT," +
                //        "F.JOBL_DISP AS JOBL,F.JOB_NAME AS JOBL_NAME,B.DI,B.ROTET,B.CALOT,B.EMPCD,B.MANG,B.CARD,B.WORKCD,'' AS DESCR," +
                //        //"DATEDIFF(DAY,B.INDT,'" + date_e + "') AS WK_YRS1,"+
                //        "B.COMP,B.CINDT,B.JOBS,B.TTSCODE,DBO.GETTOTALYEARS(A.NOBR,'" + date_e + "') AS WK_YRS1," +
                //        "DATEDIFF(DAY,A.BIRDT,GETDATE())/365.24 AS AGE,A.MATNO,B.TAX_DATE,B.TAX_EDATE," +
                //        "DATEDIFF(DAY,STDT,STINDT) AS PSTDT_DAY,A.ACCOUNT_MA,A.ACCOUNT_NA,C.DEPT_TREE " +
                //        ",B.RETCHOO,B.RETRATE,B.RETDATE,B.SALADR,B.DEPTM,A.BASECD,B.OilSubsidy,B.JOBO,B.INSG_TYPE" +
                //        ",A.EMAIL,A.TAXNO,A.CONT_MAN,A.CONT_TEL,A.CONT_GSM,A.COUNTRY" +
                //        " FROM BASE A,BASETTS B " +
                //        " LEFT OUTER JOIN DEPT C ON B.DEPT=C.D_NO" +
                //        " LEFT OUTER JOIN JOBL F ON B.JOBL=F.JOBL" +                        
                //        " WHERE A.NOBR=B.NOBR" +
                //        " AND '" + date_e + "' BETWEEN B.ADATE AND B.DDATE" +
                //        " AND A.NOBR BETWEEN '" + nobr_b + "' AND '" + nobr_e + "'" +
                //        " AND B.EMPCD BETWEEN '" + empcd_b + "' AND '" + empcd_e + "'" +
                //        " AND C.d_no_disp BETWEEN '" + dept_b + "' AND '" + dept_e + "'" +
                //        " AND B.WORKCD BETWEEN '" + work_b + "' AND '" + work_e + "'" +
                //        " AND B.COMP BETWEEN '" + comp_b + "' AND '" + comp_e + "'" +
                //        " AND F.JOBL_DISP BETWEEN '" + jobl_b + "' AND '" + jobl_e + "'" +  
                //         " " + data_report + " " +
                //        " ORDER BY B.DEPT,A.NOBR";
                //    rq_zz11s3 = SqlConn.GetDataTable(sqlCmd);

                //    sqlCmd = "";
                //}

                //if (ttstype == "6")
                //{
                //    foreach (DataRow Row in rq_zz11s3.Rows)
                //    { 
                //        Int32 _indt = Convert.ToInt32(DateTime.Parse(Row["indt"].ToString()).ToString("yyyyMMdd"));
                //        Int32 _oudt = (Row.IsNull("oudt")) ? 0 : Convert.ToInt32(DateTime.Parse(Row["oudt"].ToString()).ToString("yyyyMMdd"));
                //        Int32 _datee = Convert.ToInt32(DateTime.Parse(date_e).ToString("yyyyMMdd"));
                //        Int32 _dateb = Convert.ToInt32(DateTime.Parse(date_b).ToString("yyyyMMdd"));
                //        if (_indt > _dateb)
                //            Row.Delete();
                //        else if (_oudt <= _dateb && Row["ttscode"].ToString().Trim() == "2")
                //            Row.Delete();
                //    }
                //    rq_zz11s3.AcceptChanges();
                //}
                #endregion

                #endregion

                foreach (DataRow Row in rq_zz11s3.Rows)
                {
                    decimal _age = decimal.Parse(Row["age"].ToString());
                    //decimal _wkyrs1 = decimal.Parse(Row["wk_yrs1"].ToString()) / Convert.ToDecimal(365.24);
                    decimal _wkyrs1 = decimal.Parse((string.IsNullOrEmpty(Row["wk_yrs1"].ToString()) ? "0" : Row["wk_yrs1"].ToString()));
                    if (_age >= age_b && _age <= age_e)
                        if (_wkyrs1 >= seniority_b && _wkyrs1 <= seniority_e)
                            ds.Tables["rq_zz11s3"].ImportRow(Row);
                }
                if (ds.Tables["rq_zz11s3"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                //string sqlCmd11 = "select jobl,jobl_disp,job_name from jobl";
                //DataTable rq_jobl = SqlConn.GetDataTable(sqlCmd11);
                //rq_jobl.PrimaryKey = new DataColumn[] { rq_jobl.Columns["jobl"] };
                DataTable DT_OUDT = new DataTable();
                if (ttstype == "3")
                {
                    var dbHR = new HrDBDataContext();

                    var oudt_table = (from a in dbHR.BASETTS
                                      where 1 == 1
                                      &&
                                      !(a.OUDT == null)
                                      &&
                                      ((new string[] { "2", "5" }).Contains(a.TTSCODE))
                                      &&
                                      !(a.OUDT == DateTime.Parse("9999/12/31"))
                                      select new
                                      {
                                          NOBR = a.NOBR,
                                          OUDT = a.OUDT,
                                      }).ToList();
                    DT_OUDT = oudt_table.CopyToDataTable();
                    DT_OUDT.PrimaryKey = new DataColumn[] { DT_OUDT.Columns["NOBR"] };
                }


                string sqlCmd1 = "select a.d_no,a.d_no_disp,a.d_name,a.d_ename,b.nobr,b.name_c from dept a left outer join base b on a.nobr = b.nobr";
                DataTable rq_dept = SqlConn.GetDataTable(sqlCmd1);
                rq_dept.PrimaryKey = new DataColumn[] { rq_dept.Columns["d_no"] };

                string sqlCmd2 = "select d_no as depts,d_no_disp,d_name from depts";
                DataTable rq_depts = SqlConn.GetDataTable(sqlCmd2);
                rq_depts.PrimaryKey = new DataColumn[] { rq_depts.Columns["depts"] };

                string sqlCmd3 = "select job,job_disp,job_name from job";
                DataTable rq_job = SqlConn.GetDataTable(sqlCmd3);
                rq_job.PrimaryKey = new DataColumn[] { rq_job.Columns["job"] };

                DataTable rq_workcd = SqlConn.GetDataTable("select work_code,work_addr from workcd ");
                rq_workcd.PrimaryKey = new DataColumn[] { rq_workcd.Columns["work_code"] };

                DataTable rq_jobs = SqlConn.GetDataTable("select jobs,jobs_disp,job_name from jobs ");
                rq_jobs.PrimaryKey = new DataColumn[] { rq_jobs.Columns["jobs"] };

                DataTable rq_rotet = SqlConn.GetDataTable("select rotet,rotet_disp,rotetname from rotet ");
                rq_rotet.PrimaryKey = new DataColumn[] { rq_rotet.Columns["rotet"] };

                //薪別代碼
                DataTable rq_saltycd = SqlConn.GetDataTable("select saltycd,saltyname from saltycd");
                rq_saltycd.PrimaryKey = new DataColumn[] { rq_saltycd.Columns["saltycd"] };

                //簽核部門
                DataTable rq_depta = SqlConn.GetDataTable("select a.d_no,a.d_no_disp,a.d_name,b.nobr,b.name_c from depta a left outer join base b on a.nobr=b.nobr");
                rq_depta.PrimaryKey = new DataColumn[] { rq_depta.Columns["d_no"] };

                //直間接
                DataTable rq_di = SqlConn.GetDataTable("select code,name from mtcode where category='DI'");
                rq_di.PrimaryKey = new DataColumn[] { rq_di.Columns["code"] };

                //身分別
                DataTable rq_basecd = SqlConn.GetDataTable("select basecd,basecdname from basecd");
                rq_basecd.PrimaryKey = new DataColumn[] { rq_basecd.Columns["basecd"] };

                //員別
                DataTable rq_empcd = SqlConn.GetDataTable("select empcd,empdescr from empcd");
                rq_empcd.PrimaryKey = new DataColumn[] { rq_empcd.Columns["empcd"] };

                //職級
                DataTable rq_jobo = SqlConn.GetDataTable("select jobo,job_name from jobo");
                rq_jobo.PrimaryKey = new DataColumn[] { rq_jobo.Columns["jobo"] };

                //成本
                DataTable rq_costtype = SqlConn.GetDataTable("select costtypecode,costtypename from CostType");
                rq_costtype.PrimaryKey = new DataColumn[] { rq_costtype.Columns["costtypecode"] };

                //隸屬獎金
                DataTable rq_BonusGroup = SqlConn.GetDataTable("select code,groupname from BonusGroup");
                rq_BonusGroup.PrimaryKey = new DataColumn[] { rq_BonusGroup.Columns["code"] };

                //銀行
                DataTable rq_bankcode = SqlConn.GetDataTable("select code,bankname from bankcode");
                rq_bankcode.PrimaryKey = new DataColumn[] { rq_bankcode.Columns["code"] };

                //教育程度
                string Cmdschl = "select distinct d.nobr,b.name from schl d,educode b where d.educcode = b.code ";
                Cmdschl += " and d.nobr+d.educcode+convert(char(50),d.auto)";
                Cmdschl += "in (select max(a.nobr+a.educcode+convert(char(50),a.auto)) ";
                Cmdschl += string.Format(@" from schl a where a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                Cmdschl += " group by a.nobr)";
                DataTable rq_schl = SqlConn.GetDataTable(Cmdschl);
                rq_schl.PrimaryKey = new DataColumn[] { rq_schl.Columns["nobr"] };


                //現職年資
                string Cmdtenure = " SELECT NOBR, DEPT, JOB, DATEDIFF(DAY, ADATE, DDATE) + 1 AS DAYDIFF, DATEDIFF(DAY, ADATE, DBO.Today()) + 1 AS TODAYDIFF, DDATE ";
                Cmdtenure += string.Format(@" FROM BASETTS WHERE NOBR BETWEEN '{0}' AND '{1}' AND TTSCODE IN ('1', '4', '6') ", nobr_b, nobr_e);

                DataTable rq_tenure = SqlConn.GetDataTable(Cmdtenure);
                DataTable rq_tenure_sum = rq_tenure.Clone();
                rq_tenure_sum.Columns.Add("CHECK_NOW", typeof(bool));
                rq_tenure_sum.Columns.Add("TOTAL_DAYS", typeof(decimal));
                rq_tenure_sum.Columns.Remove("DDATE");
                rq_tenure_sum.Columns.Remove("DAYDIFF");
                rq_tenure_sum.Columns.Remove("TODAYDIFF");
                rq_tenure_sum.PrimaryKey = new DataColumn[] { rq_tenure_sum.Columns["NOBR"], rq_tenure_sum.Columns["DEPT"], rq_tenure_sum.Columns["JOB"] };
                foreach (DataRow tenure_row in rq_tenure.Rows)
                {
                    object[] value = new object[3];
                    value[0] = tenure_row["NOBR"].ToString();
                    value[1] = tenure_row["DEPT"].ToString();
                    value[2] = tenure_row["JOB"].ToString();

                    DataRow sum_row = rq_tenure_sum.Rows.Find(value);

                    if (sum_row != null)
                    {
                        if (tenure_row["DDATE"].ToString() == DateTime.Parse("9999/12/31").ToString())
                        {
                            sum_row["CHECK_NOW"] = true;
                            sum_row["TOTAL_DAYS"] = decimal.Parse(sum_row["TOTAL_DAYS"].ToString()) + decimal.Parse(tenure_row["TODAYDIFF"].ToString());
                        }
                        else
                        {
                            sum_row["TOTAL_DAYS"] = decimal.Parse(sum_row["TOTAL_DAYS"].ToString()) + decimal.Parse(tenure_row["DAYDIFF"].ToString());
                        }
                    }
                    else
                    {
                        DataRow aRow = rq_tenure_sum.NewRow();
                        aRow["NOBR"] = tenure_row["NOBR"].ToString();
                        aRow["DEPT"] = tenure_row["DEPT"].ToString();
                        aRow["JOB"] = tenure_row["JOB"].ToString();
                        if (tenure_row["DDATE"].ToString() == DateTime.Parse("9999/12/31").ToString())
                        {
                            aRow["CHECK_NOW"] = true;
                            aRow["TOTAL_DAYS"] = decimal.Parse(tenure_row["TODAYDIFF"].ToString());
                        }
                        else
                        {
                            aRow["CHECK_NOW"] = false;
                            aRow["TOTAL_DAYS"] = decimal.Parse(tenure_row["DAYDIFF"].ToString());
                        }

                        rq_tenure_sum.Rows.Add(aRow);
                    }
                }

                rq_tenure_sum.AcceptChanges();

                foreach (DataRow sum_row in rq_tenure_sum.Rows)
                {
                    if (sum_row["CHECK_NOW"].ToString() == "False")
                    {
                        sum_row.Delete();
                    }
                }


                rq_tenure_sum.AcceptChanges();




                //國籍
                DataTable rq_countcd = SqlConn.GetDataTable("select code,descr from countcd order by code");
                rq_countcd.PrimaryKey = new DataColumn[] { rq_countcd.Columns["code"] };

                for (int i = 0; i < ds.Tables["rq_zz11s3"].Rows.Count; i++)
                {
                    //DataRow row6 = rq_stdtt.Rows.Find(ds.Tables["rq_zz11s3"].Rows[i]["nobr"].ToString());
                    //if (row6 != null)
                    //    ds.Tables["rq_zz11s3"].Rows[i]["wk_yrs1"] = decimal.Parse(ds.Tables["rq_zz11s3"].Rows[i]["wk_yrs1"].ToString()) - int.Parse(row6["days"].ToString()) + 1;
                    //ds.Tables["rq_zz11s3"].Rows[i]["wk_yrs"] = decimal.Round(decimal.Parse(ds.Tables["rq_zz11s3"].Rows[i]["wk_yrs1"].ToString()) / Convert.ToDecimal(365.24), 2);
                    ds.Tables["rq_zz11s3"].Rows[i]["wk_yrs"] = decimal.Parse((string.IsNullOrEmpty(ds.Tables["rq_zz11s3"].Rows[i]["wk_yrs1"].ToString()) ? "0" : ds.Tables["rq_zz11s3"].Rows[i]["wk_yrs1"].ToString()));

                    DataRow row_dept = rq_dept.Rows.Find(ds.Tables["rq_zz11s3"].Rows[i]["d_no"].ToString());
                    DataRow row_depts = rq_depts.Rows.Find(ds.Tables["rq_zz11s3"].Rows[i]["depts"].ToString());
                    DataRow row_job = rq_job.Rows.Find(ds.Tables["rq_zz11s3"].Rows[i]["job"].ToString());
                    //DataRow row_jobl = rq_jobl.Rows.Find(ds.Tables["rq_zz11s3"].Rows[i]["jobl"].ToString());
                    DataRow row_workcd = rq_workcd.Rows.Find(ds.Tables["rq_zz11s3"].Rows[i]["workcd"].ToString());
                    DataRow row_jobs = rq_jobs.Rows.Find(ds.Tables["rq_zz11s3"].Rows[i]["jobs"].ToString());
                    DataRow row_rotet = rq_rotet.Rows.Find(ds.Tables["rq_zz11s3"].Rows[i]["rotet"].ToString());
                    DataRow row_dept_tree = rq_dept.Rows.Find(ds.Tables["rq_zz11s3"].Rows[i]["dept_tree"].ToString());
                    DataRow row_depta = rq_depta.Rows.Find(ds.Tables["rq_zz11s3"].Rows[i]["deptm"].ToString());
                    DataRow row_di = rq_di.Rows.Find(ds.Tables["rq_zz11s3"].Rows[i]["di"].ToString());
                    DataRow row_saltycd = rq_saltycd.Rows.Find(ds.Tables["rq_zz11s3"].Rows[i]["saltp"].ToString());
                    DataRow row_basecd = rq_basecd.Rows.Find(ds.Tables["rq_zz11s3"].Rows[i]["basecd"].ToString());
                    DataRow row_empcd = rq_empcd.Rows.Find(ds.Tables["rq_zz11s3"].Rows[i]["empcd"].ToString());
                    DataRow row_jobo = rq_jobo.Rows.Find(ds.Tables["rq_zz11s3"].Rows[i]["jobo"].ToString());
                    DataRow row_costtype = rq_costtype.Rows.Find(ds.Tables["rq_zz11s3"].Rows[i]["OilSubsidy"].ToString());
                    DataRow row_BonusGroup = rq_BonusGroup.Rows.Find(ds.Tables["rq_zz11s3"].Rows[i]["insg_type"].ToString());
                    DataRow row_bankcode = rq_bankcode.Rows.Find(ds.Tables["rq_zz11s3"].Rows[i]["bankno"].ToString());
                    DataRow row_schl = rq_schl.Rows.Find(ds.Tables["rq_zz11s3"].Rows[i]["nobr"].ToString());
                    DataRow row_countcd = rq_countcd.Rows.Find(ds.Tables["rq_zz11s3"].Rows[i]["country"].ToString());
                    

                    object[] value = new object[3];
                    value[0] = ds.Tables["rq_zz11s3"].Rows[i]["nobr"].ToString();
                    value[1] = ds.Tables["rq_zz11s3"].Rows[i]["d_no"].ToString();
                    value[2] = ds.Tables["rq_zz11s3"].Rows[i]["job"].ToString();

                    //現職年資
                    DataRow row_tenure = rq_tenure_sum.Rows.Find(value);

                    if (row_dept != null)
                    {
                        ds.Tables["rq_zz11s3"].Rows[i]["d_no"] = row_dept["d_no_disp"].ToString();
                        ds.Tables["rq_zz11s3"].Rows[i]["d_name"] = row_dept["d_name"].ToString();
                        ds.Tables["rq_zz11s3"].Rows[i]["d_ename"] = row_dept["d_ename"].ToString();
                        ds.Tables["rq_zz11s3"].Rows[i]["d_mang"] = row_dept["nobr"].ToString();
                        ds.Tables["rq_zz11s3"].Rows[i]["d_mangname"] = row_dept["name_c"].ToString();
                    }

                    if (row_depts != null)
                    {
                        ds.Tables["rq_zz11s3"].Rows[i]["depts"] = row_depts["d_no_disp"].ToString();
                        ds.Tables["rq_zz11s3"].Rows[i]["d_name2"] = row_depts["d_name"].ToString();
                        ds.Tables["rq_zz11s3"].Rows[i]["ds_name"] = row_depts["d_name"].ToString();
                    }

                    if (row_job != null)
                    {
                        ds.Tables["rq_zz11s3"].Rows[i]["job"] = row_job["job_disp"].ToString();
                        ds.Tables["rq_zz11s3"].Rows[i]["job_name"] = row_job["job_name"].ToString();
                    }

                    //if (row4 != null)
                    //    ds.Tables["rq_zz11s3"].Rows[i]["jobl_name"] = row4["job_name"].ToString();

                    if (row_workcd != null)
                    {
                        ds.Tables["rq_zz11s3"].Rows[i]["work_addr"] = row_workcd["work_addr"].ToString();
                    }

                    if (row_jobs != null)
                    {
                        ds.Tables["rq_zz11s3"].Rows[i]["jobs"] = row_jobs["jobs_disp"].ToString();
                        ds.Tables["rq_zz11s3"].Rows[i]["jobs_name"] = row_jobs["job_name"].ToString();
                    }

                    if (row_rotet != null)
                    {
                        ds.Tables["rq_zz11s3"].Rows[i]["rotet"] = row_rotet["rotet_disp"].ToString();
                        ds.Tables["rq_zz11s3"].Rows[i]["rotetname"] = row_rotet["rotetname"].ToString();
                    }

                    object[] _value = new object[2];
                    _value[0] = ds.Tables["rq_zz11s3"].Rows[i]["nobr"].ToString();
                    _value[1] = ds.Tables["rq_zz11s3"].Rows[i]["jobl"].ToString();
                    //DataRow row7 = rq_nobrjobl.Rows.Find(_value);
                    //if (row7 != null)
                    //{
                    //    ds.Tables["rq_zz11s3"].Rows[i]["jobldays"] = decimal.Round((((TimeSpan)(DateTime.Parse(date_t) - DateTime.Parse(row7["adate"].ToString()))).Days + 1) / Convert.ToDecimal(365.24), 2);
                    //}
                    ds.Tables["rq_zz11s3"].Rows[i]["dept_tree"] = "";
                    if (row_dept_tree != null)
                    {
                        ds.Tables["rq_zz11s3"].Rows[i]["dept_tree"] = row_dept_tree["d_no_disp"].ToString().Trim() + " " + row_dept_tree["d_name"].ToString();
                    }

                    if (row_depta != null)
                    {
                        ds.Tables["rq_zz11s3"].Rows[i]["deptm"] = row_depta["d_no_disp"].ToString();
                        ds.Tables["rq_zz11s3"].Rows[i]["dm_name"] = row_depta["d_name"].ToString();
                        ds.Tables["rq_zz11s3"].Rows[i]["dm_mang"] = row_depta["nobr"].ToString();
                        ds.Tables["rq_zz11s3"].Rows[i]["dm_mangname"] = row_depta["name_c"].ToString();
                    }

                    if (row_di != null)
                    {
                        ds.Tables["rq_zz11s3"].Rows[i]["di"] = row_di["name"].ToString();
                    }

                    if (row_saltycd != null)
                    {
                        ds.Tables["rq_zz11s3"].Rows[i]["saltyname"] = row_saltycd["saltyname"].ToString();
                    }

                    if (row_basecd != null)
                    {
                        ds.Tables["rq_zz11s3"].Rows[i]["basecdname"] = row_basecd["basecdname"].ToString();
                    }

                    if (row_empcd != null)
                    {
                        ds.Tables["rq_zz11s3"].Rows[i]["empdescr"] = row_empcd["empdescr"].ToString();
                    }

                    if (row_jobo != null)
                    {
                        ds.Tables["rq_zz11s3"].Rows[i]["jobo_name"] = row_jobo["job_name"].ToString();
                    }

                    if (row_costtype != null)
                    {
                        ds.Tables["rq_zz11s3"].Rows[i]["costtypename"] = row_costtype["costtypename"].ToString();
                    }

                    if (row_BonusGroup != null)
                    {
                        ds.Tables["rq_zz11s3"].Rows[i]["groupname"] = row_BonusGroup["groupname"].ToString();
                    }

                    //將轉帳銀行資料塞進資料表
                    if (row_bankcode != null)
                    {
                        ds.Tables["rq_zz11s3"].Rows[i]["bankno"] = row_bankcode["bankname"].ToString();
                    }

                    if (row_schl != null)
                    {
                        ds.Tables["rq_zz11s3"].Rows[i]["eduname"] = row_schl["name"].ToString();
                    }

                    if (row_countcd != null)
                    {
                        ds.Tables["rq_zz11s3"].Rows[i]["country"] = row_countcd["descr"].ToString();
                    }


                    if (row_tenure != null)
                    {
                        ds.Tables["rq_zz11s3"].Rows[i]["tenure"] = decimal.Parse(Math.Round(double.Parse(row_tenure["TOTAL_DAYS"].ToString()) / 365, 2).ToString());
                    }
                    if (ttstype == "3")
                    {
                        DataRow row_oudt = DT_OUDT.Rows.Find(ds.Tables["rq_zz11s3"].Rows[i]["nobr"].ToString());
                        if (row_oudt != null)
                        {
                            ds.Tables["rq_zz11s3"].Rows[i]["oudt"] = DateTime.Parse(row_oudt["oudt"].ToString());
                        }
                    }
                    //if (report_type == "留職停薪明細")
                    //{
                    //    string sqlCmd40 = "select nobr,stindt,datediff(day,stdt,stindt) as pstdt_days from basetts";
                    //    sqlCmd40 += string.Format(@" where nobr='{0}' ", ds.Tables["rq_zz11s3"].Rows[i]["nobr"].ToString());
                    //    sqlCmd40 += string.Format(@" and stdt='{0}'", DateTime.Parse(ds.Tables["rq_zz11s3"].Rows[i]["stdt"].ToString()).ToString("yyyy/MM/dd"));
                    //    sqlCmd40 += " and ttscode='4'";
                    //    DataTable rq_stnobr = SqlConn.GetDataTable(sqlCmd40);
                    //    if (rq_stnobr.Rows.Count > 0)
                    //    {
                    //        ds.Tables["rq_zz11s3"].Rows[i]["pstdt_days"] = decimal.Parse(rq_stnobr.Rows[0]["pstdt_days"].ToString());
                    //        ds.Tables["rq_zz11s3"].Rows[i]["stindt"] = DateTime.Parse(rq_stnobr.Rows[0]["stindt"].ToString()).ToString("yyyy/MM/dd");
                    //    }
                    //    rq_stnobr = null;
                    //}
                }

                rq_zz11s3 = null; rq_job = null; rq_dept = null; rq_rotet = null; rq_depts = null; rq_workcd = null; rq_jobs = null;
                rq_depta = null; rq_empcd = null; rq_saltycd = null; rq_di = null; rq_jobo = null; rq_costtype = null; rq_BonusGroup = null;
                rq_basecd = null; rq_schl = null; rq_bankcode = null; rq_countcd = null;
                if (exportexcel)
                {
                    RptViewer.Visible = false;
                    Export(ds.Tables["rq_zz11s3"]);
                    this.Close();
                }
                else
                {

                    RptViewer.Visible = true;
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "EmpReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "EmpReport", "*.rdlc");
                    if (report_type == "基本報表1")
                    {
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz11.rdlc";
                    }

                    else if (report_type == "基本報表(NEW)")
                    {
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz112.rdlc";
                    }

                    else if (report_type == "基本報表-保險用")
                    {
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz113.rdlc";
                    }

                    else if (report_type == "基本報表-通訊用")
                    {
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz114.rdlc";
                    }

                    else if (report_type == "員工名冊")
                    {
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz115.rdlc";
                    }

                    else if (report_type == "員工名冊(年齡年資)")
                    {
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz115a.rdlc";
                    }

                    else if (report_type == "v新進一覽表")
                    {
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz116a.rdlc";
                    }

                    else if (report_type == "v離職一覽表")
                    {
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz117.rdlc";
                    }

                    else if (report_type == "v留職停薪明細")
                    {
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz118.rdlc";
                    }

                    //else if (report_type == "9")
                    //    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz11c.rdlc";
                    //else if (report_type == "10")
                    //    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz11d.rdlc";
                    else if (report_type == "標籤")
                    {
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz119.rdlc";
                    }

                    else if (report_type == "信封")
                    {
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz11a.rdlc";
                    }

                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("UserName", username) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("empdata_rq_zz11s3", ds.Tables["rq_zz11s3"]));
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
            if (report_type != "v新進一覽表" && report_type != "v離職一覽表" && report_type != "v留職停薪明細")
            {
                if (report_type != "基本報表(NEW)")
                    ExporDt.Columns.Add("公司", typeof(string));
                ExporDt.Columns.Add("部門代碼", typeof(string));
                ExporDt.Columns.Add("部門名稱", typeof(string));
                ExporDt.Columns.Add("員工編號", typeof(string));
                ExporDt.Columns.Add("員工姓名", typeof(string));
            }
            switch (report_type)
            {
                case "基本報表1":
                    ExporDt.Columns.Add("到職日期", typeof(DateTime));
                    ExporDt.Columns.Add("身分證號", typeof(string));
                    ExporDt.Columns.Add("通訊地址", typeof(string));
                    ExporDt.Columns.Add("戶籍地址", typeof(string));

                    foreach (DataRow Row in DT.Rows)
                    {
                        DataRow aRow = ExporDt.NewRow();
                        aRow["公司"] = Row["comp"].ToString();
                        aRow["部門代碼"] = Row["d_no"].ToString();
                        aRow["部門名稱"] = Row["d_name"].ToString();
                        aRow["員工編號"] = Row["nobr"].ToString();
                        aRow["員工姓名"] = Row["name_c"].ToString();
                        //aRow["英文姓名"] = Row["name_e"].ToString();
                        aRow["到職日期"] = DateTime.Parse(Row["indt"].ToString());
                        aRow["身分證號"] = Row["idno"].ToString();
                        aRow["通訊地址"] = Row["addr1"].ToString();
                        aRow["戶籍地址"] = Row["addr2"].ToString();
                        ExporDt.Rows.Add(aRow);
                    }
                    break;
                case "基本報表(NEW)":
                    //ExporDt.Columns.Add("進集團日", typeof(DateTime));
                    ExporDt.Columns.Add("英文姓名", typeof(string));
                    ExporDt.Columns.Add("身分證號", typeof(string));
                    ExporDt.Columns.Add("護照號碼", typeof(string));
                    ExporDt.Columns.Add("居留證號", typeof(string));
                    ExporDt.Columns.Add("出生日期", typeof(string));
                    ExporDt.Columns.Add("到職日期", typeof(DateTime));
                    ExporDt.Columns.Add("離職日期", typeof(DateTime));
                    ExporDt.Columns.Add("直間接", typeof(string));
                    ExporDt.Columns.Add("性別", typeof(string));
                    ExporDt.Columns.Add("身分別", typeof(string));
                    ExporDt.Columns.Add("薪別", typeof(string));
                    ExporDt.Columns.Add("成本代碼", typeof(string));
                    ExporDt.Columns.Add("成本部門", typeof(string));
                    ExporDt.Columns.Add("成本", typeof(string));
                    ExporDt.Columns.Add("職稱", typeof(string));
                    ExporDt.Columns.Add("職等", typeof(string));
                    //ExporDt.Columns.Add("職級", typeof(string));
                    ExporDt.Columns.Add("隸屬獎金", typeof(string));
                    //ExporDt.Columns.Add("職類", typeof(string));
                    //ExporDt.Columns.Add("輪班", typeof(string));
                    ExporDt.Columns.Add("班別", typeof(string));
                    //ExporDt.Columns.Add("加班", typeof(string));
                    ExporDt.Columns.Add("員別", typeof(string));
                    ExporDt.Columns.Add("編制主管工號", typeof(string));
                    ExporDt.Columns.Add("編制主管姓名", typeof(string));
                    ExporDt.Columns.Add("主管", typeof(string));
                    ExporDt.Columns.Add("刷卡", typeof(string));
                    ExporDt.Columns.Add("簽核代碼", typeof(string));
                    ExporDt.Columns.Add("簽核部門", typeof(string));
                    ExporDt.Columns.Add("簽核部門主管工號", typeof(string));
                    ExporDt.Columns.Add("簽核部門主管姓名", typeof(string));
                    ExporDt.Columns.Add("年資", typeof(string));
                    ExporDt.Columns.Add("年資1", typeof(decimal));
                    ExporDt.Columns.Add("年齡", typeof(decimal));
                    ExporDt.Columns.Add("教育程度", typeof(string));
                    ExporDt.Columns.Add("轉帳銀行", typeof(string));
                    ExporDt.Columns.Add("轉帳帳號", typeof(string));
                    ExporDt.Columns.Add("留職日期", typeof(DateTime));
                    ExporDt.Columns.Add("復職日期", typeof(DateTime));
                    ExporDt.Columns.Add("居留起日", typeof(DateTime));
                    ExporDt.Columns.Add("居留迄日", typeof(DateTime));
                    ExporDt.Columns.Add("工作地", typeof(string));
                    ExporDt.Columns.Add("電子郵件", typeof(string));
                    ExporDt.Columns.Add("行動電話", typeof(string));
                    ExporDt.Columns.Add("通訊電話", typeof(string));
                    ExporDt.Columns.Add("戶籍電話", typeof(string));
                    ExporDt.Columns.Add("通訊地址", typeof(string));
                    ExporDt.Columns.Add("戶籍地址", typeof(string));
                    ExporDt.Columns.Add("聯絡人1", typeof(string));
                    ExporDt.Columns.Add("聯絡電話1", typeof(string));
                    ExporDt.Columns.Add("聯絡人行動1", typeof(string));
                    ExporDt.Columns.Add("國籍", typeof(string));
                    foreach (DataRow Row in DT.Rows)
                    {
                        DataRow aRow = ExporDt.NewRow();
                        aRow["部門代碼"] = Row["d_no"].ToString();
                        aRow["部門名稱"] = Row["d_name"].ToString();
                        aRow["員工編號"] = Row["nobr"].ToString();
                        aRow["員工姓名"] = Row["name_c"].ToString();
                        aRow["英文姓名"] = Row["name_e"].ToString();
                        aRow["身分證號"] = Row["idno"].ToString();
                        aRow["護照號碼"] = Row["taxno"].ToString();
                        aRow["居留證號"] = Row["matno"].ToString();
                        aRow["出生日期"] = DateTime.Parse(Row["birdt"].ToString());
                        aRow["職等"] = Row["jobl_name"].ToString();
                        //aRow["職級"] = Row["jobo_name"].ToString();
                        aRow["隸屬獎金"] = (Row.IsNull("groupname")) ? "" : Row["groupname"].ToString();
                        aRow["職稱"] = Row["job_name"].ToString();
                        //aRow["職類"] = Row["jobs_name"].ToString();
                        //aRow["進集團日"] = DateTime.Parse(Row["cindt"].ToString());
                        aRow["到職日期"] = DateTime.Parse(Row["indt"].ToString());
                        if (!Row.IsNull("oudt")) aRow["離職日期"] = DateTime.Parse(Row["oudt"].ToString());
                        if (!Row.IsNull("stdt")) aRow["留職日期"] = DateTime.Parse(Row["stdt"].ToString());
                        if (!Row.IsNull("stindt")) aRow["復職日期"] = DateTime.Parse(Row["stindt"].ToString());
                        if (!Row.IsNull("tax_date")) aRow["居留起日"] = Row["tax_date"].ToString();
                        if (!Row.IsNull("tax_edate")) aRow["居留迄日"] = Row["tax_edate"].ToString();
                        aRow["直間接"] = Row["di"].ToString();
                        aRow["性別"] = Row["sex"].ToString();
                        aRow["身分別"] = (Row.IsNull("basecdname")) ? "" : Row["basecdname"].ToString();
                        aRow["薪別"] = (Row.IsNull("saltyname")) ? "" : Row["saltyname"].ToString();
                        aRow["成本代碼"] = (Row.IsNull("depts")) ? "" : Row["depts"].ToString();
                        aRow["成本部門"] = (Row.IsNull("ds_name")) ? "" : Row["ds_name"].ToString();
                        aRow["成本"] = (Row.IsNull("costtypename")) ? "" : Row["costtypename"].ToString();
                        //aRow["輪班"] = Row["rotet"].ToString();
                        aRow["班別"] = Row["rotetname"].ToString();
                        //aRow["加班"] = Row["calot"].ToString();
                        aRow["員別"] = Row["empdescr"].ToString();
                        aRow["編制主管工號"] = (Row.IsNull("d_mang")) ? "" : Row["d_mang"].ToString();
                        aRow["編制主管姓名"] = (Row.IsNull("d_mangname")) ? "" : Row["d_mangname"].ToString();
                        aRow["主管"] = (bool.Parse(Row["mang"].ToString())) ? "是" : "";
                        aRow["刷卡"] = Row["card"].ToString();
                        aRow["簽核代碼"] = Row["deptm"].ToString();
                        aRow["簽核部門"] = Row["dm_name"].ToString();
                        aRow["簽核部門主管工號"] = (Row.IsNull("dm_mang")) ? "" : Row["dm_mang"].ToString();
                        aRow["簽核部門主管姓名"] = (Row.IsNull("dm_mangname")) ? "" : Row["dm_mangname"].ToString();
                        aRow["年資"] = decimal.Round(decimal.Parse(Row["wk_yrs"].ToString()), 2).ToYearMonthString();
                        aRow["年資1"] = decimal.Round(decimal.Parse(Row["wk_yrs"].ToString()), 2);
                        aRow["年齡"] = decimal.Round(decimal.Parse(Row["age"].ToString()), 2);
                        aRow["教育程度"] = (Row.IsNull("eduname")) ? "" : Row["eduname"].ToString();
                        aRow["轉帳銀行"] = Row["bankno"].ToString();
                        aRow["轉帳帳號"] = Row["account_no"].ToString();
                        aRow["工作地"] = Row["work_addr"].ToString();
                        aRow["電子郵件"] = Row["email"].ToString();
                        aRow["行動電話"] = Row["gsm"].ToString();
                        aRow["通訊電話"] = Row["tel1"].ToString();
                        aRow["戶籍電話"] = Row["tel2"].ToString();
                        aRow["通訊地址"] = Row["addr1"].ToString();
                        aRow["戶籍地址"] = Row["addr2"].ToString();
                        aRow["聯絡人1"] = Row["cont_man"].ToString();
                        aRow["聯絡電話1"] = Row["cont_tel"].ToString();
                        aRow["聯絡人行動1"] = Row["cont_gsm"].ToString();
                        aRow["國籍"] = Row["country"].ToString();
                        ExporDt.Rows.Add(aRow);
                    }
                    break;
                case "基本報表-保險用":
                    ExporDt.Columns.Add("出生日期", typeof(DateTime));
                    ExporDt.Columns.Add("身分證號", typeof(string));
                    ExporDt.Columns.Add("到職日期", typeof(DateTime));
                    ExporDt.Columns.Add("職稱代碼", typeof(string));
                    ExporDt.Columns.Add("職稱", typeof(string));
                    ExporDt.Columns.Add("性別", typeof(string));
                    ExporDt.Columns.Add("直接間", typeof(string));
                    ExporDt.Columns.Add("轉帳行號", typeof(string));
                    ExporDt.Columns.Add("轉帳帳號", typeof(string));
                    ExporDt.Columns.Add("外勞帳號", typeof(string));
                    ExporDt.Columns.Add("居留證號", typeof(string));
                    ExporDt.Columns.Add("居留起日", typeof(DateTime));
                    ExporDt.Columns.Add("居留迄日", typeof(DateTime));
                    foreach (DataRow Row in DT.Rows)
                    {
                        DataRow aRow = ExporDt.NewRow();
                        aRow["公司"] = Row["comp"].ToString();
                        aRow["部門代碼"] = Row["d_no"].ToString();
                        aRow["部門名稱"] = Row["d_name"].ToString();
                        aRow["員工編號"] = Row["nobr"].ToString();
                        aRow["員工姓名"] = Row["name_c"].ToString();
                        aRow["出生日期"] = DateTime.Parse(Row["birdt"].ToString());
                        aRow["身分證號"] = Row["idno"].ToString();
                        aRow["到職日期"] = DateTime.Parse(Row["indt"].ToString());
                        aRow["職稱代碼"] = Row["job"].ToString();
                        aRow["職稱"] = Row["job_name"].ToString();
                        aRow["性別"] = (Row["sex"].ToString().Trim() == "F") ? "女" : "男";
                        aRow["直接間"] = Row["di"].ToString();
                        aRow["轉帳行號"] = Row["bankno"].ToString();
                        aRow["轉帳帳號"] = Row["account_no"].ToString();
                        aRow["外勞帳號"] = Row["account_ma"].ToString();
                        aRow["居留證號"] = Row["matno"].ToString();
                        if (!Row.IsNull("tax_date")) aRow["居留起日"] = Row["tax_date"].ToString();
                        if (!Row.IsNull("tax_edate")) aRow["居留迄日"] = Row["tax_edate"].ToString();
                        ExporDt.Rows.Add(aRow);
                    }
                    break;
                case "基本報表-通訊用":
                    ExporDt.Columns.Add("進集團日", typeof(DateTime));
                    ExporDt.Columns.Add("到職日期", typeof(DateTime));
                    ExporDt.Columns.Add("行動電話", typeof(string));
                    ExporDt.Columns.Add("通訊電話", typeof(string));
                    ExporDt.Columns.Add("通訊地址", typeof(string));
                    foreach (DataRow Row in DT.Rows)
                    {
                        DataRow aRow = ExporDt.NewRow();
                        aRow["公司"] = Row["comp"].ToString();
                        aRow["部門代碼"] = Row["d_no"].ToString();
                        aRow["部門名稱"] = Row["d_name"].ToString();
                        aRow["員工編號"] = Row["nobr"].ToString();
                        aRow["員工姓名"] = Row["name_c"].ToString();
                        aRow["進集團日"] = DateTime.Parse(Row["cindt"].ToString());
                        aRow["到職日期"] = DateTime.Parse(Row["indt"].ToString());
                        aRow["行動電話"] = Row["gsm"].ToString();
                        aRow["通訊電話"] = Row["tel1"].ToString();
                        aRow["通訊地址"] = Row["addr1"].ToString();
                        ExporDt.Rows.Add(aRow);
                    }
                    break;
                case "員工名冊":
                    ExporDt.Columns.Add("成本代碼", typeof(string));
                    ExporDt.Columns.Add("成本名稱", typeof(string));
                    ExporDt.Columns.Add("職稱", typeof(string));
                    ExporDt.Columns.Add("職等", typeof(string));
                    ExporDt.Columns.Add("性別", typeof(string));
                    ExporDt.Columns.Add("進集團日", typeof(DateTime));
                    ExporDt.Columns.Add("年資", typeof(decimal));
                    ExporDt.Columns.Add("年齡", typeof(decimal));
                    ExporDt.Columns.Add("現職年資", typeof(decimal));
                    foreach (DataRow Row in DT.Rows)
                    {
                        DataRow aRow = ExporDt.NewRow();
                        aRow["公司"] = Row["comp"].ToString();
                        aRow["部門代碼"] = Row["d_no"].ToString();
                        aRow["部門名稱"] = Row["d_name"].ToString();
                        aRow["員工編號"] = Row["nobr"].ToString();
                        aRow["員工姓名"] = Row["name_c"].ToString();
                        aRow["成本代碼"] = Row["depts"].ToString();
                        aRow["成本名稱"] = Row["d_name2"].ToString();
                        aRow["職稱"] = Row["job_name"].ToString();
                        aRow["職等"] = Row["jobl_name"].ToString();
                        aRow["進集團日"] = DateTime.Parse(Row["cindt"].ToString());
                        aRow["性別"] = (Row["sex"].ToString().Trim() == "F") ? "女" : "男";
                        aRow["年資"] = decimal.Round(decimal.Parse(Row["wk_yrs"].ToString()), 2);
                        aRow["年齡"] = decimal.Round(decimal.Parse(Row["age"].ToString()), 2);
                        if (!string.IsNullOrEmpty(Row["tenure"].ToString()))
                        {
                            aRow["現職年資"] = decimal.Round(decimal.Parse(Row["tenure"].ToString()), 2);
                        }
                        ExporDt.Rows.Add(aRow);
                    }
                    break;
                case "員工名冊(年齡年資)":
                    ExporDt.Columns.Add("職稱", typeof(string));
                    ExporDt.Columns.Add("職等", typeof(string));
                    ExporDt.Columns.Add("性別", typeof(string));
                    ExporDt.Columns.Add("進集團日", typeof(DateTime));
                    ExporDt.Columns.Add("到職", typeof(DateTime));
                    ExporDt.Columns.Add("年資", typeof(decimal));
                    foreach (DataRow Row in DT.Rows)
                    {
                        DataRow aRow = ExporDt.NewRow();
                        aRow["公司"] = Row["comp"].ToString();
                        aRow["部門代碼"] = Row["d_no"].ToString();
                        aRow["部門名稱"] = Row["d_name"].ToString();
                        aRow["員工編號"] = Row["nobr"].ToString();
                        aRow["員工姓名"] = Row["name_c"].ToString();
                        aRow["職稱"] = Row["job_name"].ToString();
                        aRow["職等"] = Row["jobl_name"].ToString();
                        aRow["進集團日"] = DateTime.Parse(Row["cindt"].ToString());
                        aRow["性別"] = (Row["sex"].ToString().Trim() == "F") ? "女" : "男";
                        aRow["年資"] = decimal.Parse(Row["wk_yrs"].ToString());
                        aRow["年齡"] = decimal.Parse(Row["age"].ToString());
                        ExporDt.Rows.Add(aRow);
                    }
                    break;
                case "v新進一覽表":
                    ExporDt.Columns.Add("員工編號", typeof(string));
                    ExporDt.Columns.Add("員工姓名", typeof(string));
                    ExporDt.Columns.Add("報表分析群組", typeof(string));
                    ExporDt.Columns.Add("部門代碼", typeof(string));
                    ExporDt.Columns.Add("部門名稱", typeof(string));
                    ExporDt.Columns.Add("輪班別代碼", typeof(string));
                    ExporDt.Columns.Add("輪班別", typeof(string));
                    ExporDt.Columns.Add("直間接", typeof(string));
                    ExporDt.Columns.Add("職稱代碼", typeof(string));
                    ExporDt.Columns.Add("職稱", typeof(string));
                    ExporDt.Columns.Add("到職日期", typeof(DateTime));
                    ExporDt.Columns.Add("離職日期", typeof(DateTime));
                    ExporDt.Columns.Add("性別", typeof(string));
                    ExporDt.Columns.Add("出生日期", typeof(DateTime));
                    ExporDt.Columns.Add("年齡", typeof(decimal));
                    foreach (DataRow Row in DT.Rows)
                    {
                        DataRow aRow = ExporDt.NewRow();
                        aRow["員工編號"] = Row["nobr"].ToString();
                        aRow["員工姓名"] = Row["name_c"].ToString();
                        aRow["報表分析群組"] = Row["dept_tree"].ToString();
                        aRow["部門代碼"] = Row["d_no"].ToString();
                        aRow["部門名稱"] = Row["d_name"].ToString();
                        aRow["輪班別代碼"] = Row["rotet"].ToString();
                        aRow["輪班別"] = Row["rotetname"].ToString();
                        aRow["直間接"] = Row["di"].ToString();
                        aRow["職稱代碼"] = Row["job"].ToString();
                        aRow["職稱"] = Row["job_name"].ToString();
                        aRow["到職日期"] = DateTime.Parse(Row["cindt"].ToString());
                        if (!Row.IsNull("oudt")) aRow["離職日期"] = DateTime.Parse(Row["oudt"].ToString());
                        aRow["性別"] = (Row["sex"].ToString().Trim() == "F") ? "女" : "男";
                        //aRow["身分證號"] = Row["idno"].ToString();
                        aRow["出生日期"] = DateTime.Parse(Row["birdt"].ToString());
                        aRow["年齡"] = (((TimeSpan)(DateTime.Now - DateTime.Parse(Row["birdt"].ToString()))).Days) / 365.24;
                        aRow["年齡"] = decimal.Round(decimal.Parse(aRow["年齡"].ToString()), 2);
                        ExporDt.Rows.Add(aRow);
                    }
                    break;
                case "v離職一覽表":
                    ExporDt.Columns.Add("員工編號", typeof(string));
                    ExporDt.Columns.Add("員工姓名", typeof(string));
                    ExporDt.Columns.Add("報表分析群組", typeof(string));
                    ExporDt.Columns.Add("部門代碼", typeof(string));
                    ExporDt.Columns.Add("部門名稱", typeof(string));
                    ExporDt.Columns.Add("職稱代碼", typeof(string));
                    ExporDt.Columns.Add("職稱", typeof(string));
                    ExporDt.Columns.Add("輪班別代碼", typeof(string));
                    ExporDt.Columns.Add("輪班別", typeof(string));
                    ExporDt.Columns.Add("直間接", typeof(string));
                    ExporDt.Columns.Add("進集團日", typeof(DateTime));
                    ExporDt.Columns.Add("到職日期", typeof(DateTime));
                    ExporDt.Columns.Add("離職日期", typeof(DateTime));
                    ExporDt.Columns.Add("留停日期", typeof(DateTime));
                    ExporDt.Columns.Add("停離日期", typeof(DateTime));

                    //增加停復日期 - Added By Daniel Chih - 2021/07/19
                    ExporDt.Columns.Add("停復日期", typeof(DateTime));

                    ExporDt.Columns.Add("年齡", typeof(decimal));
                    ExporDt.Columns.Add("年資", typeof(decimal));
                    ExporDt.Columns.Add("性別", typeof(string));
                    ExporDt.Columns.Add("離職原因", typeof(string));
                    foreach (DataRow Row in DT.Rows)
                    {
                        DataRow aRow = ExporDt.NewRow();
                        aRow["員工編號"] = Row["nobr"].ToString();
                        aRow["員工姓名"] = Row["name_c"].ToString();
                        aRow["報表分析群組"] = Row["dept_tree"].ToString();
                        aRow["部門代碼"] = Row["d_no"].ToString();
                        aRow["部門名稱"] = Row["d_name"].ToString();
                        aRow["職稱代碼"] = Row["job"].ToString();
                        aRow["職稱"] = Row["job_name"].ToString();
                        aRow["輪班別代碼"] = Row["rotet"].ToString();
                        aRow["輪班別"] = Row["rotetname"].ToString();
                        aRow["直間接"] = Row["di"].ToString();
                        aRow["進集團日"] = DateTime.Parse(Row["cindt"].ToString());
                        aRow["到職日期"] = DateTime.Parse(Row["indt"].ToString());
                        if (!Row.IsNull("oudt")) aRow["離職日期"] = DateTime.Parse(Row["oudt"].ToString());
                        if (!Row.IsNull("stdt")) aRow["留停日期"] = DateTime.Parse(Row["stdt"].ToString());
                        if (!Row.IsNull("stoudt")) aRow["停離日期"] = DateTime.Parse(Row["stoudt"].ToString());

                        //增加停復日期 - Added By Daniel Chih - 2021/07/19
                        if (!Row.IsNull("stindt")) aRow["停復日期"] = DateTime.Parse(Row["stindt"].ToString());

                        aRow["性別"] = (Row["sex"].ToString().Trim() == "F") ? "女" : "男";
                        aRow["年齡"] = (((TimeSpan)(DateTime.Now - DateTime.Parse(Row["birdt"].ToString()))).Days) / 365.24;
                        aRow["年齡"] = decimal.Round(decimal.Parse(aRow["年齡"].ToString()), 2);
                        aRow["年資"] = decimal.Round(decimal.Parse(Row["wk_yrs"].ToString()), 2);
                        aRow["離職原因"] = Row["outname"].ToString();
                        ExporDt.Rows.Add(aRow);
                    }
                    break;
                case "v留職停薪明細":
                    ExporDt.Columns.Add("員工編號", typeof(string));
                    ExporDt.Columns.Add("員工姓名", typeof(string));
                    ExporDt.Columns.Add("報表分析群組", typeof(string));
                    ExporDt.Columns.Add("部門代碼", typeof(string));
                    ExporDt.Columns.Add("部門名稱", typeof(string));
                    ExporDt.Columns.Add("職稱代碼", typeof(string));
                    ExporDt.Columns.Add("職稱", typeof(string));
                    ExporDt.Columns.Add("輪班別代碼", typeof(string));
                    ExporDt.Columns.Add("輪班別", typeof(string));
                    ExporDt.Columns.Add("直間接", typeof(string));
                    ExporDt.Columns.Add("留停日期", typeof(DateTime));
                    ExporDt.Columns.Add("復職日期", typeof(DateTime));
                    ExporDt.Columns.Add("留離日期", typeof(DateTime));
                    ExporDt.Columns.Add("留停天數", typeof(decimal));
                    foreach (DataRow Row in DT.Rows)
                    {
                        DataRow aRow = ExporDt.NewRow();
                        aRow["員工編號"] = Row["nobr"].ToString();
                        aRow["員工姓名"] = Row["name_c"].ToString();
                        aRow["報表分析群組"] = Row["dept_tree"].ToString();
                        aRow["部門代碼"] = Row["d_no"].ToString();
                        aRow["部門名稱"] = Row["d_name"].ToString();
                        aRow["職稱代碼"] = Row["job"].ToString();
                        aRow["職稱"] = Row["job_name"].ToString();
                        aRow["輪班別代碼"] = Row["rotet"].ToString();
                        aRow["輪班別"] = Row["rotetname"].ToString();
                        aRow["直間接"] = Row["di"].ToString();
                        if (!Row.IsNull("stdt")) aRow["留停日期"] = DateTime.Parse(Row["stdt"].ToString());
                        if (!Row.IsNull("stindt")) aRow["復職日期"] = DateTime.Parse(Row["stindt"].ToString());
                        if (!Row.IsNull("stoudt")) aRow["留離日期"] = DateTime.Parse(Row["stoudt"].ToString());
                        if (!Row.IsNull("pstdt_days")) aRow["留停天數"] = decimal.Round(decimal.Parse(Row["pstdt_days"].ToString()), 2);
                        ExporDt.Rows.Add(aRow);
                    }
                    break;
                default:
                    break;
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);

        }
    }
}
