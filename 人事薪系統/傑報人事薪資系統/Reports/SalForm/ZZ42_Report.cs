/* ======================================================================================================
 * 【功能名稱】：發放薪資
 * 【功能代號】：ZZ42
 * 【功能路徑】：報表列印 > 薪資 > 發放薪資
 * 【檔案路徑】：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ42_Report.cs
 * 【功能用途】：
 *  用於產出發放薪資各類報表
 */
/* 【版本記錄】：
 * ======================================================================================================
 *    日期           人員               版本              單號                          說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/01/13    Daniel Chih        Ver 1.0.01                                      1. 新增條件欄位：公司
 * 2021/02/05    Daniel Chih        Ver 1.0.02                                      1. 增加薪資單列印時判斷 loginUser 和當前使用頁面的公司類型
 * 2021/04/27    Daniel Chih        Ver 1.0.03                                      1. 增加僅【清展】可用的轉帳明細表
 * 2021/05/03    Daniel Chih        Ver 1.0.04                                      1. 補充外文薪資單對於 MTLNG 沒有資料時的判斷
 * 2021/05/10    Daniel Chih        Ver 1.0.05                                      1. 修正country資料沒有帶入的問題
 * 2021/05/10    Daniel Chih        Ver 1.0.06                                      1. 修改成本部門Primary Key同時讀d_no和d_no_disp
 * 2021/06/10    Daniel Chih        Ver 1.0.07                                      1. Re：修正country資料沒有帶入的問題
 * 2021/06/18    Daniel Chih        Ver 1.0.08                                      1. 合併期別後相同薪資代碼的資金合併項目
 * 2021/06/18    Daniel Chih        Ver 1.0.09                                      1. 增加選項：大張大字
 * 2021/07/07    Daniel Chih        Ver 1.0.10                                      1. 修改特休代碼與補休代碼的參考來源
 * 2021/07/15    Daniel Chih        Ver 1.0.11                                      1. 增加薪資彙總表：大張大字
 * 2021/07/30    Daniel Chih        Ver 1.0.12                                      1. 修正外籍薪資單譯文Code順序錯亂的問題，更新外籍薪資單多語係寫法穩定性
 * 2021/08/13    Daniel Chih        Ver 1.0.13                                      1. 修正清展轉賬明細表參數來源到原始來源
 * 2021/09/22    Daniel Chih        Ver 1.0.14                                      1. 清展轉賬明細表：備註欄位帶畫面上的備註欄位
 * 2021/09/24    Daniel Chih        Ver 1.0.15                                      1. 先增加日翔用的薪資轉帳Excel
 * 2021/11/10    Daniel Chih        Ver 1.0.16                                      1. 修改【臨時人數】撈取規則，代碼讀自Appconfig，報表結果增加【公司名稱】欄位
 * 2022/03/16    Daniel Chih        Ver 1.0.17    ITCT-F01-220118-酷碼-20220316     1. 增加薪資單寄送的預約寄送欄位
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2022/03/16
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlTypes;
using Microsoft.Reporting.WinForms;

namespace JBHR.Reports.SalForm
{
    public partial class ZZ42_Report : JBControls.JBForm
    {
        JBModule.Data.ApplicationConfigSettings Acg = null;
        SalDataSet ds = new SalDataSet();
        string nobr_b, nobr_e, comp_b, comp_e, dept_b, dept_e, depts_b, depts_e, saladr_b, saladr_e, attdate_b, attdate_e, date_b, date_t, reporttype, year, month, seq;
        string type_data, note, note1, note3, yymm, yymm_b, loginuser, loginpwd, username, workadr, workadr1, emp_b, emp_e;
        bool exportexcel, pa, pa1, pa2, pa3, order1, order2, order3, no_upwage, no_name, prn_noemail, prn_paa, tran_count, salary_pa1, displns, Salary_Transfer_Mode;
        bool infor = bool.Parse("false"), no_deptcount, no_comp, sumdi, print_pdf, noout, noret, sendsalary, labchedk, nodispot, DetailsA3, A3_BigCharacter;
        string lcstr2, lcstr3, repo, comp_name, CompId, seqmerge, note_en, report_type_item;
        string retsalcode2 = "";
        string ErrorMessage = "";
        string AnnualLeave_Type, CompensatoryLeave_Type, Temporary_Empcd;
        string DataName = JBHR.Reports.ReportClass.GetDataName();
        DateTime SendDate;
        public ZZ42_Report(string _temporary_empcd, bool SalaryTransferMode, string AnnualLeaveType, string CompensatoryLeaveType, string nobrb, string nobre, string compb, string compe, string deptb, string depte, string deptsb, string deptse, string salardb, string salarde, string empb, string empe, string attdateb, string attdatee, string dateb, string datet, string _reporttype, string str_report_type_item, string _year, string _month, string _seq, string typedata, string _note, string _note1, string _note3, string noteen, string _loginuser, string _loginpwd, string _username, bool _exportexcel, bool _pa, bool _pa1, bool _pa2, bool _pa3, bool _order1, bool _order2, bool _order3, bool noupwage, bool noname, bool prnnoemail, bool prnpaa, bool trancount, bool salarypa1, bool nodeptcount, bool nocomp, string _workadr, string _workadr1, string reponame, bool _sumdi, string compname, string _CompId, bool printpdf, bool _noout, bool _noret, bool _sendsalary, string _seqmerge, bool _labchedk, bool _nodispot, bool _A3_BigCharacter, DateTime _SendDate)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; saladr_b = salardb; saladr_e = salarde;
            attdate_b = attdateb; attdate_e = attdatee; date_b = dateb; date_t = datet; reporttype = _reporttype;
            year = _year; month = _month; seq = _seq; type_data = typedata; note = _note; note1 = _note1;
            note3 = _note3; order1 = _order1; order2 = _order2; order3 = _order3; no_upwage = noupwage;
            no_name = noname; prn_noemail = prnnoemail; prn_paa = prnpaa; tran_count = trancount;
            salary_pa1 = salarypa1; exportexcel = _exportexcel; pa = _pa; ; pa1 = _pa1; ; pa2 = _pa2; ; pa3 = _pa3;
            loginuser = _loginuser; loginpwd = _loginpwd; yymm = year + month; username = _username;
            workadr = _workadr; workadr1 = _workadr1; no_deptcount = nodeptcount; no_comp = nocomp;
            yymm_b = yymm; repo = reponame; sumdi = _sumdi; comp_name = compname; CompId = _CompId;
            emp_b = empb; emp_e = empe; print_pdf = printpdf; noout = _noout; noret = _noret; report_type_item = str_report_type_item;
            sendsalary = _sendsalary; labchedk = _labchedk; seqmerge = _seqmerge; note_en = noteen;
            nodispot = _nodispot; comp_b = compb; comp_e = compe; depts_b = deptsb; depts_e = deptse;
            AnnualLeave_Type = AnnualLeaveType; CompensatoryLeave_Type = CompensatoryLeaveType; A3_BigCharacter = _A3_BigCharacter;
            Salary_Transfer_Mode = SalaryTransferMode; Temporary_Empcd = _temporary_empcd; SendDate = _SendDate;
        }

        private void ZZ42_Report_Load(object sender, EventArgs e)
        {
            try
            {
                if (type_data == "1")
                {
                    //lcstr2 = workadr;
                    //repo = "";
                    lcstr3 = " AND G.DEPT BETWEEN '" + dept_b + "' AND '" + dept_e + "' ";
                }
                if (type_data == "2")
                {
                    lcstr2 = " AND B.DI='I'  AND A.COUNT_MA=0 ";
                    //repo = "間接";
                    lcstr3 = " AND G.DI='I'  AND F.COUNT_MA=0 AND G.DEPT BETWEEN '" + dept_b + "' AND '" + dept_e + "' ";
                }
                if (type_data == "3")
                {
                    lcstr2 = " AND B.DI='D'  AND A.COUNT_MA=0 ";
                    //repo = "直接";
                    lcstr3 = " AND G.DI='D'  AND F.COUNT_MA=0 AND G.DEPT BETWEEN '" + dept_b + "' AND '" + dept_e + "' ";
                }
                if (type_data == "4")
                {
                    lcstr2 = " AND A.COUNT_MA=1 ";
                    //repo = "外勞";
                    lcstr3 = " AND F.COUNT_MA=1 AND G.DEPT BETWEEN '" + dept_b + "' AND '" + dept_e + "' ";
                }
                if (type_data == "5")
                {
                    //lcstr2 = " AND (B.DI='D' OR A.COUNT_MA=1) ";
                    lcstr2 = " AND A.COUNT_MA=0 ";
                    //repo = "直接+外勞";
                    //lcstr3 = " AND (G.DI='D' OR F.COUNT_MA=1) AND G.DEPT BETWEEN '" + dept_b + "' AND '" + dept_e + "' ";
                    lcstr3 = " AND F.COUNT_MA=0 AND G.DEPT BETWEEN '" + dept_b + "' AND '" + dept_e + "' ";
                }
                if ((reporttype == "3" || reporttype == "4") && report_type_item != "【清展】轉帳明細表")
                {
                    DateTime yymmdate = DateTime.Now;
                    yymmdate = DateTime.Parse(year + "/" + month + "/01").AddMonths(-1);
                    yymm_b = Convert.ToString(yymmdate.Year) + Convert.ToString(yymmdate.Month).PadLeft(2, '0');
                }
                if (reporttype == "21" && report_type_item != "【清展】轉帳明細表")
                    lcstr2 += " and (a.email <> ''  or a.email is not null)";
                if (noout)
                    lcstr2 += " and b.ttscode in ('1','4','6')";
                JBModule.Data.CSQL Sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");

                //人事基本資料
                DataTable rq_base = JBHR.Reports.ZZ42Class.Get_base2(lcstr2, date_b, dept_b, dept_e, depts_b, depts_e, comp_b, comp_e, saladr_b, saladr_e, nobr_b, nobr_e, emp_b, emp_e, report_type_item);
                ErrorMessage = "\n" + "人事異動資料重疊名單:";

                ErrorMessage += JBHR.Reports.ReportClass.GetRepeatEmpID(rq_base);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };
                ErrorMessage = "";


                //薪資相關代碼
                string CmdSalcode = "select a.sal_code,a.sal_code_disp,a.sal_name,a.sal_ename,a.sal_name_vn,b.salattr,b.flag,b.type,b.tax,a.notfreq,";
                CmdSalcode += "a.retire,a.forbank,a.forcash,a.acccd,c.accname ";
                CmdSalcode += " from salcode a,salattr b,acccd c where a.sal_attr=b.salattr and a.acccd=c.acccd";
                DataTable rq_salcode = Sql.GetDataTable(CmdSalcode);
                rq_salcode.PrimaryKey = new DataColumn[] { rq_salcode.Columns["sal_code"] };

                //判斷薪資鎖檔才可產生薪資轉帳磁片
                if (reporttype == "7" && report_type_item != "【清展】轉帳明細表")
                {
                    string Cmdlock = "select yymm,seq from lock_wage  where ";
                    Cmdlock += string.Format(@" yymm='{0}' and seq='{1}'", yymm, seq);
                    Cmdlock += workadr;
                    DataTable rq_lockwage = Sql.GetDataTable(Cmdlock);
                    if (rq_lockwage.Rows.Count < 1)
                    {
                        MessageBox.Show(Resources.Reports.WageNoLock, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                        this.Close();
                        return;
                    }
                }

                //多國語系薪資名稱
                DataTable rq_sallang = Sql.GetDataTable("select code,language,display_name from mtlng where category='SALCODE' order by language,code");
                rq_sallang.PrimaryKey = new DataColumn[] { rq_sallang.Columns["code"], rq_sallang.Columns["language"] };

                //多國語系公司名稱
                DataTable rq_complang = Sql.GetDataTable("select code,language,display_name from mtlng where category='COMP' order by language,code");
                rq_complang.PrimaryKey = new DataColumn[] { rq_complang.Columns["code"], rq_complang.Columns["language"] };

                //多國語系
                DataTable rq_font = Sql.GetDataTable("select lng,font from lng order by lng");
                rq_font.PrimaryKey = new DataColumn[] { rq_font.Columns["lng"] };

                //薪資主檔
                string CmdWage = "select b.nobr,yymm,seq,b.account_no,b.wk_days,b.cash,b.note,b.adate,b.date_b,b.date_e,c.code_disp as bankno,";
                CmdWage += "b.saladr,b.comp,b.taxrate,b.att_dateb,b.att_datee,e.Lanaguage";
                CmdWage += " from ViewEmployeeLanaguage e inner join wage b on b.nobr=e.EmployeeId ";
                CmdWage += " left outer join bankcode c on b.bankno=c.code";
                CmdWage += " where 1 = 1";
                CmdWage += string.Format(@" and b.yymm='{0}' and b.seq='{1}'", yymm, seq);
                CmdWage += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                CmdWage += string.Format(@" and b.saladr between '{0}' and '{1}'", saladr_b, saladr_e);
                CmdWage += workadr1;
                DataTable rq_wage = Sql.GetDataTable(CmdWage);
                rq_wage.PrimaryKey = new DataColumn[] { rq_wage.Columns["nobr"] };

                //薪資明細資料
                string CmdWaged = "select nobr,yymm,seq,sal_code,amt from waged where ";
                CmdWaged += string.Format(@" yymm ='{0}' and seq='{1}'", yymm, seq);
                CmdWaged += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                CmdWaged += " and sal_code <> '' and amt <> 10 order by nobr";
                DataTable rq_waged = Sql.GetDataTable(CmdWaged);
                if (!string.IsNullOrEmpty(seqmerge)) //第2期及其他期別薪資合併
                {
                    string CmdWagea = "select nobr,yymm,'2' as seq,account_no,wk_days,cash,note,adate,date_b,date_e,c.code_disp as bankno,";
                    CmdWagea += "b.saladr,b.comp,b.taxrate,b.att_dateb,b.att_datee,e.Lanaguage";
                    CmdWagea += " from ViewEmployeeLanaguage e,wage b ";
                    CmdWagea += " left outer join bankcode c on b.bankno=c.code_disp";
                    CmdWagea += " where b.nobr=e.EmployeeId";
                    CmdWagea += string.Format(@" and b.yymm='{0}' and b.seq='{1}'", yymm, seqmerge);
                    CmdWagea += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                    CmdWagea += string.Format(@" and b.saladr between '{0}' and '{1}'", saladr_b, saladr_e);
                    CmdWagea += workadr1;
                    DataTable rq_wagea = Sql.GetDataTable(CmdWagea);
                    foreach (DataRow Row in rq_wagea.Rows)
                    {
                        DataRow row1 = rq_wage.Rows.Find(Row["nobr"].ToString());
                        if (row1 == null)
                        {
                            rq_wage.ImportRow(Row);
                        }
                    }
                    rq_wagea.Clear();

                    string CmdWageda = "select nobr,yymm,'2' as seq,sal_code,amt from waged where ";
                    CmdWageda += string.Format(@" yymm ='{0}' and seq='{1}'", yymm, seqmerge);
                    CmdWageda += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                    CmdWageda += " and sal_code <> '' and amt <> 10 order by nobr";
                    DataTable rq_wageda = Sql.GetDataTable(CmdWageda);
                    rq_waged.Merge(rq_wageda);
                    rq_wageda.Clear();
                }
                rq_waged.Columns.Add("dept", typeof(string));
                rq_waged.Columns.Add("name_c", typeof(string));
                rq_waged.Columns.Add("name_e", typeof(string));
                rq_waged.Columns.Add("sal_name", typeof(string));
                rq_waged.Columns.Add("salattr", typeof(string));
                rq_waged.Columns.Add("flag", typeof(string));
                rq_waged.Columns.Add("type", typeof(string));
                rq_waged.Columns.Add("tax", typeof(bool));
                rq_waged.Columns.Add("retire", typeof(bool));
                rq_waged.Columns.Add("forbank", typeof(bool));
                rq_waged.Columns.Add("forcash", typeof(bool));
                rq_waged.Columns.Add("account_no", typeof(string));
                rq_waged.Columns.Add("bankno", typeof(string));
                rq_waged.Columns.Add("wk_days", typeof(decimal));
                rq_waged.Columns.Add("cash", typeof(bool));
                rq_waged.Columns.Add("note", typeof(string));
                rq_waged.Columns.Add("adate", typeof(DateTime));
                rq_waged.Columns.Add("aadate", typeof(DateTime));
                rq_waged.Columns.Add("date_b", typeof(DateTime));
                rq_waged.Columns.Add("date_e", typeof(DateTime));
                rq_waged.Columns.Add("acccd", typeof(string));
                rq_waged.Columns.Add("accname", typeof(string));
                rq_waged.Columns.Add("saladr", typeof(string));
                rq_waged.Columns.Add("comp", typeof(string));
                rq_waged.Columns.Add("notfreq", typeof(bool));
                rq_waged.Columns.Add("sal_ename", typeof(string));
                rq_waged.Columns.Add("attdate_b", typeof(DateTime));
                rq_waged.Columns.Add("attdate_e", typeof(DateTime));
                rq_waged.Columns.Add("count_ma", typeof(bool));
                rq_waged.Columns.Add("account_ma", typeof(string));
                rq_waged.Columns.Add("country", typeof(string));
                rq_waged.Columns.Add("font", typeof(string));
                //rq_waged.Columns.Add("job_name", typeof(string));
                //rq_waged.Columns.Add("jobl_name", typeof(string));
                //rq_waged.Columns.Add("jobo_name", typeof(string));
                rq_waged.Columns.Add("taxrate", typeof(decimal));
                rq_waged.Columns.Add("PaySlipComp", typeof(string));
                ds.Tables.Add("rq_waged");
                //string str_pass = "";
                foreach (DataRow Row_Waged in rq_waged.Rows)
                {
                    DataRow row_base = rq_base.Rows.Find(Row_Waged["nobr"].ToString());
                    DataRow row_wage = rq_wage.Rows.Find(Row_Waged["nobr"].ToString());
                    DataRow row_salcode = rq_salcode.Rows.Find(Row_Waged["sal_code"].ToString());
                    if (row_base == null || row_wage == null)
                        Row_Waged.Delete();
                    else
                    {
                        if (row_base != null)
                        {

                            Row_Waged["dept"] = row_base["dept"].ToString();
                            Row_Waged["name_c"] = row_base["name_c"].ToString();
                            Row_Waged["name_e"] = row_base["name_e"].ToString();
                            Row_Waged["count_ma"] = bool.Parse(row_base["count_ma"].ToString());
                            Row_Waged["account_ma"] = row_base["account_ma"].ToString();

                        }

                        if (row_wage != null)
                        {
                            DataRow row4 = rq_font.Rows.Find(row_wage["Lanaguage"].ToString());
                            Row_Waged["country"] = row_wage["Lanaguage"].ToString();
                            Row_Waged["font"] = (row4 == null) ? "Arial" : row4["font"].ToString();
                            Row_Waged["wk_days"] = decimal.Parse(row_wage["wk_days"].ToString());
                            Row_Waged["cash"] = bool.Parse(row_wage["cash"].ToString());
                            Row_Waged["note"] = row_wage["note"].ToString();
                            Row_Waged["adate"] = DateTime.Parse(row_wage["adate"].ToString());
                            Row_Waged["date_b"] = DateTime.Parse(row_wage["date_b"].ToString());
                            Row_Waged["date_e"] = DateTime.Parse(row_wage["date_e"].ToString());
                            Row_Waged["saladr"] = row_wage["saladr"].ToString();
                            Row_Waged["comp"] = row_wage["comp"].ToString();
                            Row_Waged["taxrate"] = decimal.Parse(row_wage["taxrate"].ToString());
                            Row_Waged["attdate_b"] = (row_wage.IsNull("att_dateb")) ? DateTime.Parse(attdate_b) : DateTime.Parse(row_wage["att_dateb"].ToString());
                            Row_Waged["attdate_e"] = (row_wage.IsNull("att_datee")) ? DateTime.Parse(attdate_e) : DateTime.Parse(row_wage["att_datee"].ToString());
                            object[] _vaule6 = new object[2];
                            _vaule6[0] = Row_Waged["comp"].ToString();
                            //直接讀wage的Language
                            _vaule6[1] = row_wage["Lanaguage"].ToString();
                            DataRow row6 = rq_complang.Rows.Find(_vaule6);
                            Row_Waged["PaySlipComp"] = (row6 != null) ? row6["display_name"].ToString() : "";
                        }

                        if (row_salcode != null)
                        {
                            object[] _value3 = new object[2];
                            _value3[0] = Row_Waged["sal_code"].ToString();
                            //直接讀wage的Language
                            _value3[1] = row_wage["Lanaguage"].ToString();
                            DataRow row3 = rq_sallang.Rows.Find(_value3);
                            Row_Waged["sal_code"] = row_salcode["sal_code_disp"].ToString();
                            Row_Waged["sal_name"] = row_salcode["sal_name"].ToString();
                            Row_Waged["sal_ename"] = (row3 != null) ? row_salcode["sal_name"].ToString() + "" + row3["display_name"].ToString().Trim() :
                                string.IsNullOrEmpty(row_salcode["sal_ename"].ToString()) ? row_salcode["sal_name"].ToString() : row_salcode["sal_name"].ToString() + "" + row_salcode["sal_ename"].ToString();
                            Row_Waged["salattr"] = row_salcode["salattr"].ToString();
                            Row_Waged["flag"] = row_salcode["flag"].ToString().Trim();
                            Row_Waged["type"] = row_salcode["type"].ToString();
                            Row_Waged["tax"] = bool.Parse(row_salcode["tax"].ToString());
                            Row_Waged["retire"] = bool.Parse(row_salcode["retire"].ToString());
                            Row_Waged["forbank"] = bool.Parse(row_salcode["forbank"].ToString());
                            Row_Waged["forcash"] = bool.Parse(row_salcode["forcash"].ToString());
                            Row_Waged["acccd"] = row_salcode["acccd"].ToString();
                            Row_Waged["accname"] = row_salcode["accname"].ToString();
                            Row_Waged["notfreq"] = bool.Parse(row_salcode["notfreq"].ToString());
                        }
                        else
                        {
                            string ErrorSalcode = "無" + Row_Waged["sal_code"].ToString() + "薪資代碼或與會計科目未關聯";
                            MessageBox.Show(ErrorSalcode, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                            JBModule.Message.TextLog.WriteLog(ErrorSalcode);
                            this.Close();
                            return;
                        }

                        if (row_salcode["salattr"].ToString().Trim() == "R" && report_type_item == "【清展】轉帳明細表")
                        {
                            Row_Waged["account_no"] = row_base["account_ma"].ToString();
                            Row_Waged["bankno"] = (row_base.IsNull("bankno")) ? "" : row_base["bankno"].ToString();
                        }
                        else
                        {
                            Row_Waged["account_no"] = row_wage["account_no"].ToString();
                            Row_Waged["bankno"] = (row_wage.IsNull("bankno")) ? "" : row_wage["bankno"].ToString();
                        }

                        if (Row_Waged["flag"].ToString() == "-")
                            Row_Waged["amt"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row_Waged["amt"].ToString())) * (-1);
                        else
                            Row_Waged["amt"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row_Waged["amt"].ToString()));

                        int value = 0;
                        if (!int.TryParse(Row_Waged["amt"].ToString(), out value))
                        {
                            string ErrorAmt = Row_Waged["nobr"].ToString() + " " + Row_Waged["name_c"].ToString() + " " + Row_Waged["sal_name"].ToString() + " " + Row_Waged["amt"].ToString() + " 金額有小數點";
                            MessageBox.Show(ErrorAmt, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                            JBModule.Message.TextLog.WriteLog(ErrorAmt);
                            this.Close();
                            return;
                        }

                        //原程式
                        if (reporttype != "5" && reporttype != "6" && reporttype != "7") //5.轉帳明細 6.現金表 7.轉帳磁片
                        {
                            //if (Row_Waged["type"].ToString().Trim() == "4")
                            //    Row_Waged.Delete();

                            // 2014/01/08R01外勞定存要顯示R02不顯示
                            if (Row_Waged["sal_code"].ToString().Trim() == "R02")
                                Row_Waged.Delete();
                        }
                        else if (reporttype == "6" && tran_count && report_type_item != "【清展】轉帳明細表") //外勞代扣銀行存款
                        {
                            if (Row_Waged["sal_code"].ToString().Trim() == "R01" && bool.Parse(row_base["count_ma"].ToString()))
                                Row_Waged.Delete();
                        }
                    }
                }
                rq_waged.AcceptChanges();

                DataTable rq_waged_temp = new DataTable();
                rq_waged_temp = rq_waged.Clone();
                rq_waged_temp.PrimaryKey = new DataColumn[] { rq_waged_temp.Columns["nobr"], rq_waged_temp.Columns["seq"], rq_waged_temp.Columns["sal_code"] };
                foreach (DataRow Row_waged in rq_waged.Rows)
                {
                    object[] value = new object[3];
                    value[0] = Row_waged["nobr"].ToString().Trim();
                    value[1] = Row_waged["seq"].ToString().Trim();
                    value[2] = Row_waged["sal_code"].ToString().Trim();

                    DataRow row_temp = rq_waged_temp.Rows.Find(value);
                    if (row_temp != null)
                        row_temp["amt"] = int.Parse(row_temp["amt"].ToString()) + decimal.Round(decimal.Parse(Row_waged["amt"].ToString()), 0);
                    else
                    {
                        DataRow aRow_temp = rq_waged_temp.NewRow();
                        aRow_temp["nobr"] = Row_waged["nobr"].ToString();
                        aRow_temp["yymm"] = Row_waged["yymm"].ToString();
                        aRow_temp["seq"] = Row_waged["seq"].ToString();
                        aRow_temp["sal_code"] = Row_waged["sal_code"].ToString();

                        aRow_temp["amt"] = decimal.Round(decimal.Parse(Row_waged["amt"].ToString()), 0);

                        aRow_temp["dept"] = Row_waged["dept"].ToString();
                        aRow_temp["name_c"] = Row_waged["name_c"].ToString();
                        aRow_temp["name_e"] = Row_waged["name_e"].ToString();
                        aRow_temp["sal_name"] = Row_waged["sal_name"].ToString();
                        aRow_temp["salattr"] = Row_waged["salattr"].ToString();

                        aRow_temp["flag"] = Row_waged["flag"].ToString();
                        aRow_temp["type"] = Row_waged["type"].ToString();
                        aRow_temp["tax"] = bool.Parse(Row_waged["tax"].ToString());
                        aRow_temp["retire"] = bool.Parse(Row_waged["retire"].ToString());
                        aRow_temp["forbank"] = bool.Parse(Row_waged["forbank"].ToString());
                        aRow_temp["forcash"] = bool.Parse(Row_waged["retire"].ToString());
                        aRow_temp["account_no"] = Row_waged["account_no"].ToString();
                        aRow_temp["bankno"] = Row_waged["bankno"].ToString();

                        aRow_temp["wk_days"] = decimal.Round(decimal.Parse(Row_waged["wk_days"].ToString()), 0);
                        aRow_temp["cash"] = bool.Parse(Row_waged["cash"].ToString());
                        aRow_temp["note"] = Row_waged["note"].ToString();

                        aRow_temp["adate"] = DateTime.Parse(Row_waged["adate"].ToString());
                        if (!Row_waged.IsNull("date_b")) aRow_temp["date_b"] = DateTime.Parse(Row_waged["date_b"].ToString());
                        if (!Row_waged.IsNull("date_e")) aRow_temp["date_e"] = DateTime.Parse(Row_waged["date_e"].ToString());
                        aRow_temp["acccd"] = Row_waged["acccd"].ToString();
                        aRow_temp["accname"] = Row_waged["accname"].ToString();
                        aRow_temp["saladr"] = Row_waged["saladr"].ToString();

                        aRow_temp["comp"] = Row_waged["comp"].ToString();
                        aRow_temp["notfreq"] = bool.Parse(Row_waged["notfreq"].ToString());
                        aRow_temp["sal_ename"] = Row_waged["sal_ename"].ToString();
                        if (!Row_waged.IsNull("attdate_b")) aRow_temp["attdate_b"] = DateTime.Parse(Row_waged["attdate_b"].ToString());
                        if (!Row_waged.IsNull("attdate_e")) aRow_temp["attdate_e"] = DateTime.Parse(Row_waged["attdate_e"].ToString());

                        aRow_temp["count_ma"] = bool.Parse(Row_waged["count_ma"].ToString());
                        aRow_temp["account_ma"] = Row_waged["account_ma"].ToString();
                        aRow_temp["country"] = Row_waged["country"].ToString();
                        aRow_temp["font"] = Row_waged["font"].ToString();
                        aRow_temp["taxrate"] = decimal.Parse(Row_waged["taxrate"].ToString());
                        aRow_temp["PaySlipComp"] = Row_waged["PaySlipComp"].ToString();

                        rq_waged_temp.Rows.Add(aRow_temp);
                    }
                }
                if (rq_waged_temp.Rows.Count < 1)
                {
                    MessageBox.Show(new Form() { TopMost = true, TopLevel = true }, Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                rq_waged.Clear();
                rq_waged.Merge(rq_waged_temp);


                ds.Tables["rq_waged"].Merge(rq_waged);

                if ((reporttype == "3" || reporttype == "4") && report_type_item != "【清展】轉帳明細表")
                {
                    //薪資主檔
                    string CmdWage1 = "select nobr";
                    CmdWage1 += string.Format(@" from wage b where yymm='{0}' and seq='{1}'", yymm_b, seq);
                    CmdWage1 += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                    CmdWage1 += workadr1;
                    DataTable rq_wage1 = Sql.GetDataTable(CmdWage1);
                    rq_wage1.PrimaryKey = new DataColumn[] { rq_wage1.Columns["nobr"] };

                    string CmdWaged1 = "select nobr,yymm,seq,sal_code,amt from waged where ";
                    CmdWaged1 += string.Format(@" yymm ='{0}' and seq='{1}'", yymm_b, seq);
                    CmdWaged1 += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                    CmdWaged1 += " and sal_code <> '' and amt <> 10";
                    DataTable rq_waged1 = Sql.GetDataTable(CmdWaged1);
                    rq_waged1.Columns.Add("sal_name", typeof(string));
                    rq_waged1.Columns.Add("salattr", typeof(string));
                    rq_waged1.Columns.Add("flag", typeof(string));
                    rq_waged1.Columns.Add("type", typeof(string));
                    foreach (DataRow RowW in rq_waged1.Rows)
                    {
                        DataRow row = rq_base.Rows.Find(RowW["nobr"].ToString());
                        DataRow row1 = rq_wage1.Rows.Find(RowW["nobr"].ToString());
                        DataRow row2 = rq_salcode.Rows.Find(RowW["sal_code"].ToString());
                        if (row == null || row1 == null)
                            RowW.Delete();
                        else if (row2 != null)
                        {
                            RowW["sal_name"] = row2["sal_name"].ToString();
                            RowW["salattr"] = row2["salattr"].ToString();
                            RowW["flag"] = row2["flag"].ToString();
                            RowW["type"] = row2["type"].ToString();
                            if (RowW["flag"].ToString() == "-")
                                RowW["amt"] = JBModule.Data.CDecryp.Number(decimal.Parse(RowW["amt"].ToString())) * (-1);
                            else
                                RowW["amt"] = JBModule.Data.CDecryp.Number(decimal.Parse(RowW["amt"].ToString()));
                            //if (RowW["type"].ToString().Trim() == "4")
                            //    RowW.Delete();

                            // 2014/01/08R01外勞定存要顯示R02不顯示
                            if (RowW["sal_code"].ToString().Trim() == "R02")
                                RowW.Delete();
                        }

                    }
                    rq_waged1.AcceptChanges();
                    ds.Tables.Add("rq_waged1");
                    ds.Tables["rq_waged1"].Merge(rq_waged1);
                    rq_waged1 = null;
                    rq_wage1 = null;
                }
                rq_waged = null;


                if (ds.Tables["rq_waged"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                //所得稅的薪資代碼
                string sqlUsys9 = "select * from u_sys9 where comp='" + CompId + "'";
                DataTable rq_usys9 = Sql.GetDataTable(sqlUsys9);
                string taxsalcode = "";
                if (rq_usys9 != null)
                {
                    taxsalcode = rq_usys9.Rows[0]["taxsalcode"].ToString();
                    DataRow row1 = rq_salcode.Rows.Find(taxsalcode);
                    if (row1 != null)
                        taxsalcode = row1["sal_code_disp"].ToString().Trim();
                }

                DataTable rq_sys3 = Sql.GetDataTable("select notaxsalcode,totaxsalcode from u_sys3 where comp='" + CompId + "'");

                string sqlUsys4 = "select retirerate,retsalcode,nretirerate,retirerate1,lsalcode from u_sys4 where comp='" + CompId + "'";
                DataTable rq_usys4 = Sql.GetDataTable(sqlUsys4);

                string SqlDepts = string.Format("select d_no,d_no_disp,d_name from depts where dbo.getcodefilter(N'DEPTS',D_NO,'{0}','{1}',{2})=1", MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN ? 1 : 0);
                DataTable rq_depts = Sql.GetDataTable(SqlDepts);
                rq_depts.PrimaryKey = new DataColumn[] { rq_depts.Columns["d_no"], rq_depts.Columns["d_no_disp"] };

                DataTable rq_comp = Sql.GetDataTable("select comp,compname from comp");
                rq_comp.PrimaryKey = new DataColumn[] { rq_comp.Columns["comp"] };

                DataTable rq_sys1 = Sql.GetDataTable("select * from u_sys1 where comp='" + CompId + "'");

                DataTable rq_sys10 = Sql.GetDataTable("select * from u_sys10 where comp='" + CompId + "'");
                if (reporttype == "21" && report_type_item != "【清展】轉帳明細表")
                {
                    if (rq_sys10.Rows.Count < 1)
                    {
                        MessageBox.Show("無SMTPServer位址", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                        this.Close();
                        return;
                    }
                }

                if (report_type_item == "【清展】轉帳明細表")
                {
                    if (infor)
                    {
                        JBHR.Reports.ZZ42Class.Get_Report6A(ds.Tables["zz42td"], ds.Tables["rq_waged"], rq_base);
                    }
                    else
                    {
                        if (rq_usys4.Rows.Count > 0)
                        {
                            DataRow row1 = rq_salcode.Rows.Find(rq_usys4.Rows[0]["retsalcode"].ToString());
                            if (row1 != null)
                                retsalcode2 = row1["sal_code_disp"].ToString().Trim();
                        }
                        //							求得應稅合計金額
                        ds.Tables.Add("wageds1");
                        ds.Tables["wageds1"].Columns.Add("nobr", typeof(string));
                        ds.Tables["wageds1"].Columns.Add("tot1", typeof(decimal));
                        ds.Tables["wageds1"].PrimaryKey = new DataColumn[] { ds.Tables["wageds1"].Columns["nobr"] };
                        JBHR.Reports.ZZ42Class.Get_wageds1(ds.Tables["wageds1"], ds.Tables["rq_waged"], rq_base);
                        //					求得應發合計金額
                        ds.Tables.Add("wageds2");
                        ds.Tables["wageds2"].Columns.Add("nobr", typeof(string));
                        ds.Tables["wageds2"].Columns.Add("tot2", typeof(decimal));
                        ds.Tables["wageds2"].PrimaryKey = new DataColumn[] { ds.Tables["wageds2"].Columns["nobr"] };
                        JBHR.Reports.ZZ42Class.Get_wageds2(ds.Tables["wageds2"], ds.Tables["rq_waged"], rq_base, retsalcode2);

                        ds.Tables.Add("wagedsz");
                        ds.Tables["wagedsz"].Columns.Add("nobr", typeof(string));
                        ds.Tables["wagedsz"].Columns.Add("totz", typeof(decimal));
                        ds.Tables["wagedsz"].PrimaryKey = new DataColumn[] { ds.Tables["wagedsz"].Columns["nobr"] };
                        JBHR.Reports.ZZ42Class.Get_wagedsz(ds.Tables["wagedsz"], ds.Tables["rq_waged"], rq_base);
                    }
                    foreach (DataRow Row in ds.Tables["rq_waged"].Rows)
                    {
                        if (Row["flag"].ToString().Trim() == "-")
                            Row["amt"] = decimal.Parse(Row["amt"].ToString()) * -1;
                    }
                    DataTable zz422 = new DataTable();
                    zz422.Columns.Add("code1", typeof(string));
                    zz422.Columns.Add("salattr", typeof(string));
                    zz422.Columns.Add("sal_name", typeof(string));
                    DataColumn[] _key422 = new DataColumn[3];
                    _key422[0] = zz422.Columns["code1"];
                    _key422[1] = zz422.Columns["salattr"];
                    _key422[2] = zz422.Columns["sal_name"];
                    zz422.PrimaryKey = _key422;
                    DataRow aRowc1 = zz422.NewRow();
                    aRowc1["code1"] = "0001";
                    aRowc1["salattr"] = "F";
                    aRowc1["sal_name"] = "3";
                    zz422.Rows.Add(aRowc1);

                    DataRow aRowc2 = zz422.NewRow();
                    aRowc2["code1"] = "0001";
                    aRowc2["salattr"] = "L";
                    aRowc2["sal_name"] = "3";
                    zz422.Rows.Add(aRowc2);

                    DataRow aRowc3 = zz422.NewRow();
                    aRowc3["code1"] = "0001";
                    aRowc3["salattr"] = "O";
                    aRowc3["sal_name"] = "3";
                    zz422.Rows.Add(aRowc3);

                    DataTable zz423 = new DataTable();
                    zz423.Columns.Add("code1", typeof(string));
                    zz423.Columns.Add("salattr", typeof(string));
                    zz423.Columns.Add("sal_name", typeof(string));
                    DataColumn[] _key423 = new DataColumn[3];
                    _key423[0] = zz423.Columns["code1"];
                    _key423[1] = zz423.Columns["salattr"];
                    _key423[2] = zz423.Columns["sal_name"];
                    zz423.PrimaryKey = _key423;

                    DataRow bRow = zz423.NewRow();
                    bRow["code1"] = "0002";
                    bRow["salattr"] = "F";
                    bRow["sal_name"] = "合計";
                    zz423.Rows.Add(bRow);

                    DataRow bRow1 = zz423.NewRow();
                    bRow1["code1"] = "0002";
                    bRow1["salattr"] = "L";
                    bRow1["sal_name"] = "合計";
                    zz423.Rows.Add(bRow1);

                    DataRow bRow2 = zz423.NewRow();
                    bRow2["code1"] = "0002";
                    bRow2["salattr"] = "O";
                    bRow2["sal_name"] = "合計";
                    zz423.Rows.Add(bRow2);

                    DataTable zz421 = new DataTable();
                    zz421.Columns.Add("code1", typeof(string));
                    zz421.Columns.Add("salattr", typeof(string));
                    zz421.Columns.Add("sal_name", typeof(string));
                    DataRow cRow = zz421.NewRow();
                    cRow["code1"] = "0000";
                    cRow["salattr"] = "F";
                    //if ((reporttype == "1" || reporttype == "2" || reporttype == "3" || reporttype == "4") && salary_pa1)
                    //    cRow["sal_name"] = "Dutiable Salary"; //英文版
                    //else
                    cRow["sal_name"] = "應稅薪資";
                    zz421.Rows.Add(cRow);

                    DataRow cRow1 = zz421.NewRow();
                    cRow1["code1"] = "0000";
                    cRow1["salattr"] = "L";
                    //if ((reporttype == "1" || reporttype == "2" || reporttype == "3" || reporttype == "4") && salary_pa1)
                    //    cRow1["sal_name"] = "應發薪資"; //英文版
                    //else
                    cRow1["sal_name"] = "應發薪資";
                    zz421.Rows.Add(cRow1);

                    DataRow cRow2 = zz421.NewRow();
                    cRow2["code1"] = "0000";
                    cRow2["salattr"] = "O";
                    cRow2["sal_name"] = "實發金額";

                    //if ((reporttype == "1" || reporttype == "2" || reporttype == "3" || reporttype == "4" || reporttype == "9" || reporttype == "18") && salary_pa1)
                    //    cRow2["sal_name"] = "Total Net Payable"; //英文版
                    //else
                    cRow2["sal_name"] = "實發金額";
                    zz421.Rows.Add(cRow2);
                    ds.Tables.Add("zz42");
                    ds.Tables["zz42"].Columns.Add("nobr", typeof(string));
                    ds.Tables["zz42"].Columns.Add("ttrcode", typeof(string));
                    ds.Tables["zz42"].Columns.Add("amt", typeof(decimal));
                    JBHR.Reports.ZZ42Class.Get_zz42a(ds.Tables["zz42"], ds.Tables["rq_waged"]);

                    //							增加RPTTITLE的值如應發應扣得屬性
                    ds.EnforceConstraints = false;
                    JBHR.Reports.ZZ42Class.Get_zz422a(zz422, ds.Tables["rq_waged"]);
                    JBHR.Reports.ZZ42Class.Get_zz423a(zz423, ds.Tables["rq_waged"]);
                    //if (((reporttype == "1") || (reporttype == "2") || (reporttype == "3") || (reporttype == "4")) && salary_pa1)
                    //    JBHR.Reports.ZZ42Class.Get_zz421_c(zz421, ds.Tables["rq_waged"]);
                    //else
                    JBHR.Reports.ZZ42Class.Get_zz421_b(zz421, ds.Tables["rq_waged"]);

                    zz422 = null;
                    zz423 = null;
                    //								產生抬頭
                    DataTable zz4211 = new DataTable();
                    zz4211.Columns.Add("code1", typeof(string));
                    zz4211.Columns.Add("salattr", typeof(string));
                    zz4211.Columns.Add("sal_name", typeof(string));
                    JBHR.Reports.ZZ42Class.Get_zz4211(zz4211, zz421);
                    zz421 = null;

                    DataTable zz42gt = new DataTable();
                    zz42gt.Columns.Add("ttrcode", typeof(string));
                    zz42gt.Columns.Add("sal_name", typeof(string));
                    zz42gt.PrimaryKey = new DataColumn[] { zz42gt.Columns["ttrcode"] };
                    JBHR.Reports.ZZ42Class.Get_zz42gt(zz42gt, zz4211);

                    JBHR.Reports.ZZ42Class.Get_zz42add(ds.Tables["zz42"], ds.Tables["wageds1"], ds.Tables["wageds2"], ds.Tables["wagedsz"]);
                    JBHR.Reports.ZZ42Class.Get_zz42t(ds.Tables["zz42ta"], ds.Tables["zz42tb"], zz42gt, ds.Tables["zz42"], rq_base, report_type_item);

                    ds.Tables.Remove("zz42");

                    string _order = "0";
                    //資料排序,O=公司+部門+員工編號,1=不分公司,2=員工編號,3=部門+職等,4=職等
                    if (no_comp)
                        _order = "1";
                    else if (order1)
                        _order = "2";
                    else if (order2)
                        _order = "3";
                    else if (order3)
                        _order = "4";

                    //公司負擔金額
                    string sqlExplab = "select nobr,insur_type,comp from explab ";
                    sqlExplab += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                    sqlExplab += string.Format(@" and sal_yymm ='{0}' and fa_idno=''", yymm);
                    DataTable rq_explab1 = Sql.GetDataTable(sqlExplab);
                    DataTable rq_explab = new DataTable();
                    rq_explab.Columns.Add("nobr", typeof(string));
                    rq_explab.Columns.Add("h_amt", typeof(int));
                    rq_explab.Columns.Add("l_amt", typeof(int));
                    rq_explab.Columns.Add("r_amt", typeof(int));
                    rq_explab.PrimaryKey = new DataColumn[] { rq_explab.Columns["nobr"] };
                    JBHR.Reports.ZZ42Class.Get_Eplab(rq_explab, rq_explab1);
                    ds.Tables["zz42td"].PrimaryKey = new DataColumn[] { ds.Tables["zz42td"].Columns["dept"], ds.Tables["zz42td"].Columns["nobr"] };
                    JBHR.Reports.ZZ42Class.Get_zz42td2(ds.Tables["zz42td"], ds.Tables["zz42tb"], ds.Tables["rq_waged"], ds.Tables["wageds1"], ds.Tables["wageds2"], ds.Tables["wagedsz"], rq_base, rq_explab, rq_depts, reporttype, year, month, _order, report_type_item);
                    int addfd = ds.Tables["zz42td"].Rows.Count;

                    ds.Tables.Remove("wageds1");
                    ds.Tables.Remove("wageds2");
                    ds.Tables.Remove("wagedsz");
                }

                else
                {

                    switch (reporttype)
                    {
                        case "8":
                            DataTable rq_zz4218 = new DataTable();
                            rq_zz4218.Columns.Add("nobr", typeof(string));
                            rq_zz4218.Columns.Add("depts", typeof(string));
                            rq_zz4218.Columns.Add("d_name", typeof(string));
                            rq_zz4218.Columns.Add("di", typeof(string));
                            rq_zz4218.PrimaryKey = new DataColumn[] { rq_zz4218.Columns["nobr"] };
                            foreach (DataRow Row in ds.Tables["rq_waged"].Rows)
                            {
                                DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                                if (row != null)
                                {
                                    DataRow row1 = rq_zz4218.Rows.Find(Row["nobr"].ToString());
                                    if (row1 == null)
                                    {
                                        //DataRow row2 = rq_depts.Rows.Find(row["depts"].ToString());
                                        DataRow aRow = rq_zz4218.NewRow();
                                        aRow["nobr"] = Row["nobr"].ToString();
                                        aRow["depts"] = row["depts"].ToString();
                                        //if (row2 != null)
                                        //    aRow["d_name"] = row2["d_name"].ToString();
                                        aRow["d_name"] = row["ds_name"].ToString();
                                        aRow["di"] = row["di"].ToString();
                                        rq_zz4218.Rows.Add(aRow);

                                    }
                                }
                            }
                            ds.Tables["zz4218"].PrimaryKey = new DataColumn[] { ds.Tables["zz4218"].Columns["depts"] };
                            DataRow[] row_zz4218 = rq_zz4218.Select("", "depts asc");
                            foreach (DataRow Row in row_zz4218)
                            {
                                DataRow row = ds.Tables["zz4218"].Rows.Find(Row["depts"].ToString());
                                if (row != null)
                                {
                                    if (Row["di"].ToString().Trim() == "I") row["di"] = int.Parse(row["di"].ToString()) + 1;
                                    if (Row["di"].ToString().Trim() == "D") row["dd"] = int.Parse(row["dd"].ToString()) + 1;
                                    if (Row["di"].ToString().Trim() == "S") row["ds"] = int.Parse(row["ds"].ToString()) + 1;
                                    row["all"] = int.Parse(row["di"].ToString()) + int.Parse(row["dd"].ToString()) + int.Parse(row["ds"].ToString());
                                }
                                else
                                {
                                    DataRow aRow = ds.Tables["zz4218"].NewRow();
                                    aRow["depts"] = Row["depts"].ToString();
                                    aRow["d_name"] = Row["d_name"].ToString();
                                    aRow["di"] = (Row["di"].ToString().Trim() == "I") ? 1 : 0;
                                    aRow["dd"] = (Row["di"].ToString().Trim() == "D") ? 1 : 0;
                                    aRow["ds"] = (Row["di"].ToString().Trim() == "S") ? 1 : 0;
                                    aRow["all"] = int.Parse(aRow["di"].ToString()) + int.Parse(aRow["dd"].ToString()) + int.Parse(aRow["ds"].ToString());
                                    ds.Tables["zz4218"].Rows.Add(aRow);
                                }
                            }
                            //DataTable zz42 = new DataTable();
                            //zz42.Columns.Add("nobr", typeof(string));
                            //zz42.Columns.Add("acccd", typeof(string));
                            //zz42.Columns.Add("amt", typeof(decimal));
                            //zz42.PrimaryKey = new DataColumn[] { zz42.Columns["nobr"], zz42.Columns["acccd"] };
                            //JBHR.Reports.ZZ42Class.Get_Report8A(zz42, ds.Tables["rq_waged"]);
                            //if (zz42.Rows.Count < 1)
                            //{
                            //    ds.Tables.Add("zz42t");
                            //    ds.Tables["zz42t"].Columns.Add("nobr", typeof(string));
                            //}

                            //DataTable zz421 = new DataTable();
                            //zz421.Columns.Add("code1", typeof(string));
                            //zz421.Columns.Add("acccd", typeof(string));
                            //zz421.Columns.Add("sal_name", typeof(string));
                            //zz421.PrimaryKey = new DataColumn[] { zz421.Columns["acccd"] };
                            //JBHR.Reports.ZZ42Class.Get_Report8B(zz421, ds.Tables["rq_waged"]);

                            //DataTable zz4211 = new DataTable();
                            //zz4211.Columns.Add("code1", typeof(string));
                            //zz4211.Columns.Add("acccd", typeof(string));
                            //zz4211.Columns.Add("sal_name", typeof(string));
                            //zz4211.PrimaryKey = new DataColumn[] { zz4211.Columns["acccd"] };
                            //JBHR.Reports.ZZ42Class.Get_Report8C(zz4211, zz421);
                            ////ds.Tables.Remove("zz421");
                            //if (zz4211.Rows.Count < 1)
                            //{
                            //    ds.Tables.Add("zz42t1");
                            //    ds.Tables["zz42t1"].Columns.Add("nobr", typeof(string));
                            //}
                            //JBHR.Reports.ZZ42Class.Get_Report8D(ds.Tables["zz42ta"], ds.Tables["zz42tb"], zz4211, zz42, rq_base);
                            //zz4211 = null;
                            //zz42 = null;
                            //ds.Tables["zz42td"].PrimaryKey = new DataColumn[] { ds.Tables["zz42td"].Columns["dept"], ds.Tables["zz42td"].Columns["nobr"] };
                            //JBHR.Reports.ZZ42Class.Get_Report8E(ds.Tables["zz42td"], ds.Tables["zz42tb"], rq_base);
                            //JBModule.Data.CExcel.GenerateHtml("C:\\TEMP\\ZZ42_Report.xls", ds.Tables["zz4218"], true);
                            //System.Diagnostics.Process.Start("C:\\TEMP\\ZZ42_Report.xls");
                            break;
                        case "11"://職業災害保險薪資列表
                            DataTable rq_zz421b = new DataTable();
                            rq_zz421b.Columns.Add("nobr", typeof(string));
                            rq_zz421b.Columns.Add("amt", typeof(int));
                            rq_zz421b.PrimaryKey = new DataColumn[] { rq_zz421b.Columns["nobr"] };
                            DataRow[] zz421b_row = ds.Tables["rq_waged"].Select("salattr <='L'");
                            foreach (DataRow Row in zz421b_row)
                            {
                                DataRow row1 = rq_base.Rows.Find(Row["nobr"].ToString());
                                if (row1 != null)
                                {
                                    DataRow row = rq_zz421b.Rows.Find(Row["nobr"].ToString());
                                    if (row != null)
                                        row["amt"] = int.Parse(row["amt"].ToString()) + decimal.Round(decimal.Parse(Row["amt"].ToString()), 0);
                                    else
                                    {
                                        DataRow aRow = rq_zz421b.NewRow();
                                        aRow["nobr"] = Row["nobr"].ToString();
                                        aRow["amt"] = decimal.Round(decimal.Parse(Row["amt"].ToString()), 0);
                                        rq_zz421b.Rows.Add(aRow);
                                    }
                                }
                            }
                            if (rq_zz421b.Rows.Count < 1)
                            {
                                MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                                this.Close();
                                return;
                            }
                            DataRow aRow0 = ds.Tables["zz421b"].NewRow();
                            aRow0["a"] = 0;
                            aRow0["a_cnt"] = 0;
                            aRow0["b"] = 0;
                            aRow0["b_cnt"] = 0;
                            aRow0["c"] = 0;
                            aRow0["c_cnt"] = 0;
                            aRow0["d"] = 0;
                            aRow0["d_cnt"] = 0;
                            aRow0["e"] = 0;
                            aRow0["e_cnt"] = 0;
                            aRow0["f"] = 0;
                            aRow0["f_cnt"] = 0;
                            aRow0["g"] = 0;
                            aRow0["g_cnt"] = 0;
                            aRow0["h"] = 0;
                            aRow0["h_cnt"] = 0;
                            aRow0["i"] = 0;
                            aRow0["i_cnt"] = 0;
                            ds.Tables["zz421b"].Rows.Add(aRow0);
                            foreach (DataRow Row in rq_zz421b.Rows)
                            {
                                if (int.Parse(Row["amt"].ToString()) <= 43900)
                                {
                                    ds.Tables["zz421b"].Rows[0]["a"] = int.Parse(ds.Tables["zz421b"].Rows[0]["a"].ToString()) + int.Parse(Row["amt"].ToString());
                                    ds.Tables["zz421b"].Rows[0]["a_cnt"] = int.Parse(ds.Tables["zz421b"].Rows[0]["a_cnt"].ToString()) + 1;
                                }
                                if (int.Parse(Row["amt"].ToString()) >= 43901 && int.Parse(Row["amt"].ToString()) <= 100000)
                                {
                                    ds.Tables["zz421b"].Rows[0]["b"] = int.Parse(ds.Tables["zz421b"].Rows[0]["b"].ToString()) + int.Parse(Row["amt"].ToString());
                                    ds.Tables["zz421b"].Rows[0]["b_cnt"] = int.Parse(ds.Tables["zz421b"].Rows[0]["b_cnt"].ToString()) + 1;
                                }

                                if (int.Parse(Row["amt"].ToString()) >= 100001 && int.Parse(Row["amt"].ToString()) <= 110000)
                                {
                                    ds.Tables["zz421b"].Rows[0]["c"] = int.Parse(ds.Tables["zz421b"].Rows[0]["c"].ToString()) + int.Parse(Row["amt"].ToString());
                                    ds.Tables["zz421b"].Rows[0]["c_cnt"] = int.Parse(ds.Tables["zz421b"].Rows[0]["c_cnt"].ToString()) + 1;
                                }
                                if (int.Parse(Row["amt"].ToString()) >= 110001 && int.Parse(Row["amt"].ToString()) <= 140000)
                                {
                                    ds.Tables["zz421b"].Rows[0]["d"] = int.Parse(ds.Tables["zz421b"].Rows[0]["d"].ToString()) + int.Parse(Row["amt"].ToString());
                                    ds.Tables["zz421b"].Rows[0]["d_cnt"] = int.Parse(ds.Tables["zz421b"].Rows[0]["d_cnt"].ToString()) + 1;
                                }
                                if (int.Parse(Row["amt"].ToString()) >= 140001 && int.Parse(Row["amt"].ToString()) <= 170000)
                                {
                                    ds.Tables["zz421b"].Rows[0]["e"] = int.Parse(ds.Tables["zz421b"].Rows[0]["e"].ToString()) + int.Parse(Row["amt"].ToString());
                                    ds.Tables["zz421b"].Rows[0]["e_cnt"] = int.Parse(ds.Tables["zz421b"].Rows[0]["e_cnt"].ToString()) + 1;
                                }
                                if (int.Parse(Row["amt"].ToString()) >= 170001 && int.Parse(Row["amt"].ToString()) <= 230000)
                                {
                                    ds.Tables["zz421b"].Rows[0]["f"] = int.Parse(ds.Tables["zz421b"].Rows[0]["f"].ToString()) + int.Parse(Row["amt"].ToString());
                                    ds.Tables["zz421b"].Rows[0]["f_cnt"] = int.Parse(ds.Tables["zz421b"].Rows[0]["f_cnt"].ToString()) + 1;
                                }
                                if (int.Parse(Row["amt"].ToString()) >= 230001 && int.Parse(Row["amt"].ToString()) <= 500000)
                                {
                                    ds.Tables["zz421b"].Rows[0]["g"] = int.Parse(ds.Tables["zz421b"].Rows[0]["g"].ToString()) + int.Parse(Row["amt"].ToString());
                                    ds.Tables["zz421b"].Rows[0]["g_cnt"] = int.Parse(ds.Tables["zz421b"].Rows[0]["g_cnt"].ToString()) + 1;
                                }
                                if (int.Parse(Row["amt"].ToString()) >= 500001 && int.Parse(Row["amt"].ToString()) <= 1000000)
                                {
                                    ds.Tables["zz421b"].Rows[0]["h"] = int.Parse(ds.Tables["zz421b"].Rows[0]["h"].ToString()) + int.Parse(Row["amt"].ToString());
                                    ds.Tables["zz421b"].Rows[0]["h_cnt"] = int.Parse(ds.Tables["zz421b"].Rows[0]["h_cnt"].ToString()) + 1;
                                }
                                if (int.Parse(Row["amt"].ToString()) > 1000000)
                                {
                                    ds.Tables["zz421b"].Rows[0]["i"] = int.Parse(ds.Tables["zz421b"].Rows[0]["i"].ToString()) + int.Parse(Row["amt"].ToString());
                                    ds.Tables["zz421b"].Rows[0]["i_cnt"] = int.Parse(ds.Tables["zz421b"].Rows[0]["i_cnt"].ToString()) + 1;
                                }
                            }
                            rq_zz421b = null;
                            break;
                        case "12"://退休金提撥表
                            decimal retirerate = 0; decimal retirerate1 = 0;
                            if (rq_usys4.Rows.Count > 0) retirerate = Convert.ToDecimal(rq_usys4.Rows[0]["retirerate"].ToString());//間接提撥
                            if (rq_usys4.Rows.Count > 0) retirerate1 = Convert.ToDecimal(rq_usys4.Rows[0]["retirerate1"].ToString());//直接提撥
                            DataTable rq_zz421c = new DataTable();
                            rq_zz421c.Columns.Add("depts", typeof(string));
                            rq_zz421c.Columns.Add("d_name", typeof(string));
                            rq_zz421c.Columns.Add("nobr", typeof(string));
                            rq_zz421c.Columns.Add("di", typeof(string));
                            rq_zz421c.Columns.Add("amt", typeof(int));
                            rq_zz421c.PrimaryKey = new DataColumn[] { rq_zz421c.Columns["depts"], rq_zz421c.Columns["nobr"] };
                            foreach (DataRow Row in ds.Tables["rq_waged"].Rows)
                            {
                                DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                                if (row != null && bool.Parse(Row["retire"].ToString()))
                                {
                                    if (!bool.Parse(row["noret"].ToString()))
                                    {
                                        object[] _value = new object[2];
                                        _value[0] = row["depts"].ToString();
                                        _value[1] = Row["nobr"].ToString();
                                        DataRow row1 = rq_zz421c.Rows.Find(_value);
                                        if (row1 != null)
                                            row1["amt"] = int.Parse(row1["amt"].ToString()) + decimal.Round(decimal.Parse(Row["amt"].ToString()));
                                        else
                                        {
                                            DataRow aRow = rq_zz421c.NewRow();
                                            aRow["depts"] = row["depts"].ToString();
                                            object[] d_no_value = new object[2];
                                            d_no_value[0] = row["depts_d_no"].ToString();
                                            d_no_value[1] = row["depts"].ToString();
                                            DataRow row2 = rq_depts.Rows.Find(d_no_value);

                                            if (row2 != null)
                                                aRow["d_name"] = row2["d_name"].ToString();
                                            aRow["amt"] = decimal.Round(decimal.Parse(Row["amt"].ToString()));
                                            aRow["di"] = row["di"].ToString();
                                            aRow["nobr"] = Row["nobr"].ToString();
                                            rq_zz421c.Rows.Add(aRow);
                                        }
                                    }
                                }
                            }

                            ds.Tables["zz421c"].PrimaryKey = new DataColumn[] { ds.Tables["zz421c"].Columns["depts"] };
                            DataRow[] Orow = rq_zz421c.Select("", "depts asc");
                            foreach (DataRow Row in Orow)
                            {
                                DataRow row = ds.Tables["zz421c"].Rows.Find(Row["depts"].ToString());
                                if (row != null)
                                {
                                    row["amt"] = int.Parse(row["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                                    if (Row["di"].ToString().Trim() == "I") row["retiretamt"] = int.Parse(row["retiretamt"].ToString()) + Math.Round(retirerate * decimal.Parse(Row["amt"].ToString()), MidpointRounding.AwayFromZero);
                                    if (Row["di"].ToString().Trim() == "D") row["retiretamt"] = int.Parse(row["retiretamt"].ToString()) + Math.Round(retirerate1 * decimal.Parse(Row["amt"].ToString()), MidpointRounding.AwayFromZero);
                                }
                                else
                                {
                                    DataRow aRow1 = ds.Tables["zz421c"].NewRow();
                                    aRow1["depts"] = Row["depts"].ToString();
                                    aRow1["d_name"] = Row["d_name"].ToString();
                                    aRow1["amt"] = int.Parse(Row["amt"].ToString());
                                    if (Row["di"].ToString().Trim() == "I")
                                        aRow1["retiretamt"] = Math.Round(retirerate * decimal.Parse(Row["amt"].ToString()), MidpointRounding.AwayFromZero);
                                    else if (Row["di"].ToString().Trim() == "D")
                                        aRow1["retiretamt"] = Math.Round(retirerate1 * decimal.Parse(Row["amt"].ToString()), MidpointRounding.AwayFromZero);
                                    else
                                        aRow1["retiretamt"] = 0;
                                    ds.Tables["zz421c"].Rows.Add(aRow1);
                                }
                            }
                            rq_zz421c = null;
                            break;
                        case "13"://薪資快報
                            string _retsalcode = string.Empty; string nottaxsalcode = string.Empty; string tottaxsalcode = string.Empty;
                            if (rq_usys4.Rows.Count > 0)
                            {
                                DataRow row1 = rq_salcode.Rows.Find(rq_usys4.Rows[0]["retsalcode"].ToString());
                                if (row1 != null)
                                    _retsalcode = row1["sal_code_disp"].ToString();
                            }
                            if (rq_sys3.Rows.Count > 0)
                            {
                                DataRow row1 = rq_salcode.Rows.Find(rq_sys3.Rows[0]["notaxsalcode"].ToString());
                                if (row1 != null)
                                    nottaxsalcode = row1["sal_code_disp"].ToString();
                                DataRow row2 = rq_salcode.Rows.Find(rq_sys3.Rows[0]["totaxsalcode"].ToString());
                                if (row2 != null)
                                    tottaxsalcode = row2["sal_code_disp"].ToString();
                            }
                            ds.Tables["zz421d"].PrimaryKey = new DataColumn[] { ds.Tables["zz421d"].Columns["comp"], ds.Tables["zz421d"].Columns["item"] };
                            JBHR.Reports.ZZ42Class.Get_Report17(Temporary_Empcd, ds.Tables["zz421d"], ds.Tables["rq_waged"], rq_base, date_b, year, month, nobr_b, nobr_e, yymm, lcstr2, CompId, _retsalcode, nottaxsalcode, tottaxsalcode);
                            if (ds.Tables["zz421d"].Rows.Count < 1)
                            {
                                MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                                this.Close();
                                return;
                            }
                            break;
                        case "15"://應免稅報表
                            DataTable rq_notaxamt1 = new DataTable();
                            rq_notaxamt1.Columns.Add("nobr", typeof(string));
                            rq_notaxamt1.Columns.Add("amt", typeof(decimal));
                            rq_notaxamt1.PrimaryKey = new DataColumn[] { rq_notaxamt1.Columns["nobr"] };
                            ds.Tables["zz421f"].PrimaryKey = new DataColumn[] { ds.Tables["zz421f"].Columns["dept"], ds.Tables["zz421f"].Columns["nobr"] };
                            foreach (DataRow Row in ds.Tables["rq_waged"].Rows)
                            {
                                DataRow row0 = rq_base.Rows.Find(Row["nobr"].ToString());
                                if (row0 != null)
                                {
                                    object[] _value = new object[2];
                                    _value[0] = row0["dept"].ToString();
                                    _value[1] = Row["nobr"].ToString();
                                    DataRow row = ds.Tables["zz421f"].Rows.Find(_value);
                                    if (bool.Parse(Row["tax"].ToString()))
                                    {
                                        if (row != null)
                                        {
                                            row["amt"] = decimal.Round(decimal.Parse(row["amt"].ToString()) + decimal.Parse(Row["amt"].ToString()), 0);
                                            row["tolamt"] = decimal.Round(decimal.Parse(row["tolamt"].ToString()) + decimal.Parse(Row["amt"].ToString()), 0);
                                        }
                                        else
                                        {
                                            DataRow aRow = ds.Tables["zz421f"].NewRow();
                                            aRow["dept"] = row0["dept"].ToString();
                                            aRow["d_name"] = row0["d_name"].ToString();
                                            aRow["nobr"] = Row["nobr"].ToString();
                                            aRow["name_c"] = row0["name_c"].ToString();
                                            aRow["amt"] = decimal.Round(decimal.Parse(Row["amt"].ToString()), 0);
                                            aRow["taxamt"] = 0;
                                            aRow["tolamt"] = decimal.Round(decimal.Parse(Row["amt"].ToString()), 0);
                                            aRow["amt1"] = 0;
                                            aRow["notaxamt"] = 0;
                                            ds.Tables["zz421f"].Rows.Add(aRow);
                                        }
                                    }

                                    DataRow row1 = rq_notaxamt1.Rows.Find(Row["nobr"].ToString());
                                    if (Row["sal_code"].ToString().Trim() == taxsalcode)
                                    {
                                        if (row1 != null)
                                            row1["amt"] = decimal.Round(decimal.Parse(row1["amt"].ToString()) + (decimal.Parse(Row["amt"].ToString()) * (-1)), 0);
                                        else
                                        {
                                            DataRow aRow1 = rq_notaxamt1.NewRow();
                                            aRow1["nobr"] = Row["nobr"].ToString();
                                            aRow1["amt"] = decimal.Round(decimal.Parse(Row["amt"].ToString()) * (-1), 0);
                                            rq_notaxamt1.Rows.Add(aRow1);
                                        }
                                    }
                                }
                            }
                            foreach (DataRow Row in ds.Tables["zz421f"].Rows)
                            {
                                string str_nobr = Row["nobr"].ToString();
                                DataRow row = rq_notaxamt1.Rows.Find(Row["nobr"].ToString());
                                if (row != null)
                                {
                                    Row["taxamt"] = decimal.Round(decimal.Parse(row["amt"].ToString()));
                                    Row["notaxamt"] = 0;
                                    //Row["notaxcnt"] = 0;
                                    Row["taxcnt"] = 1;
                                }
                                else
                                {
                                    Row["amt1"] = decimal.Round(decimal.Parse(Row["amt"].ToString()));
                                    Row["amt"] = 0;
                                    Row["notaxcnt"] = 0;

                                }
                            }
                            rq_notaxamt1 = null;
                            if (ds.Tables["zz421f"].Rows.Count < 1)
                            {
                                MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                                this.Close();
                                return;
                            }
                            break;
                        case "16"://代扣清單
                        case "19"://代扣彙總公司別
                            string welsalcode = ""; string eatsalcode = ""; string lsalcode = ""; string retsalcode = "";
                            string hsalcode = ""; string groupsalcd = "";
                            string sqlUsys2 = "select welsalcode,eatsalcode from u_sys2 where comp='" + CompId + "'";
                            DataTable rq_usys2 = Sql.GetDataTable(sqlUsys2);
                            if (rq_usys2.Rows.Count > 0)
                            {
                                DataRow row1 = rq_salcode.Rows.Find(rq_usys2.Rows[0]["welsalcode"].ToString());
                                if (row1 != null)
                                    welsalcode = row1["sal_code_disp"].ToString();

                                DataRow row2 = rq_salcode.Rows.Find(rq_usys2.Rows[0]["eatsalcode"].ToString());
                                if (row2 != null)
                                    eatsalcode = row2["sal_code_disp"].ToString();
                            }

                            if (rq_usys4.Rows.Count > 0)
                            {
                                DataRow row1 = rq_salcode.Rows.Find(rq_usys4.Rows[0]["lsalcode"].ToString());
                                if (row1 != null)
                                    lsalcode = row1["sal_code_disp"].ToString();
                                DataRow row2 = rq_salcode.Rows.Find(rq_usys4.Rows[0]["retsalcode"].ToString());
                                if (row2 != null)
                                    retsalcode = row2["sal_code_disp"].ToString();
                            }
                            string sqlUsys5 = "select hsalcode from u_sys5 where comp='" + CompId + "'";
                            DataTable rq_usys5 = Sql.GetDataTable(sqlUsys5);
                            if (rq_usys5.Rows.Count > 0)
                            {
                                DataRow row1 = rq_salcode.Rows.Find(rq_usys5.Rows[0]["hsalcode"].ToString());
                                if (row1 != null)
                                    hsalcode = row1["sal_code_disp"].ToString();
                            }
                            string sqlUsys6 = "select groupsalcd from u_sys6 where comp='" + CompId + "'";
                            DataTable rq_usys6 = Sql.GetDataTable(sqlUsys6);
                            if (rq_usys6.Rows.Count > 0)
                            {
                                DataRow row1 = rq_salcode.Rows.Find(rq_usys6.Rows[0]["groupsalcd"].ToString());
                                if (row1 != null)
                                    groupsalcd = row1["sal_code_disp"].ToString();
                            }
                            if (reporttype == "16")
                            {
                                DataColumn[] _key0 = new DataColumn[3];
                                _key0[0] = ds.Tables["zz421g"].Columns["comp"];
                                _key0[1] = ds.Tables["zz421g"].Columns["dept"];
                                _key0[2] = ds.Tables["zz421g"].Columns["nobr"];
                                ds.Tables["zz421g"].PrimaryKey = _key0;
                            }
                            else
                            {
                                ds.Tables["zz421ga"].PrimaryKey = new DataColumn[] { ds.Tables["zz421ga"].Columns["comp"] };
                            }
                            DataTable rq_zz421gb = new DataTable();
                            rq_zz421gb.Columns.Add("comp", typeof(string));
                            rq_zz421gb.Columns.Add("nobr", typeof(string));
                            rq_zz421gb.Columns.Add("cnt", typeof(int));
                            rq_zz421gb.PrimaryKey = new DataColumn[] { rq_zz421gb.Columns["comp"], rq_zz421gb.Columns["nobr"] };

                            foreach (DataRow Row in ds.Tables["rq_waged"].Rows)
                            {
                                string salcode = Row["sal_code"].ToString().Trim();
                                DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                                if (reporttype == "16")
                                {
                                    if (row != null)
                                    {
                                        object[] _vlaue = new object[3];
                                        _vlaue[0] = row["comp"].ToString();
                                        _vlaue[1] = row["dept"].ToString();
                                        _vlaue[2] = Row["nobr"].ToString();
                                        DataRow row1 = ds.Tables["zz421g"].Rows.Find(_vlaue);
                                        if (row1 != null)
                                        {
                                            if (lsalcode == salcode)
                                                row1["lab_amt"] = int.Parse(row1["lab_amt"].ToString()) + decimal.Round(decimal.Parse(Row["amt"].ToString()) * (-1), 0);
                                            else if (hsalcode == salcode)
                                                row1["hel_amt"] = int.Parse(row1["hel_amt"].ToString()) + decimal.Round(decimal.Parse(Row["amt"].ToString()) * (-1), 0);
                                            else if (groupsalcd == salcode)
                                                row1["grp_amt"] = int.Parse(row1["grp_amt"].ToString()) + decimal.Round(decimal.Parse(Row["amt"].ToString()) * (-1), 0);
                                            else if (retsalcode == salcode)
                                                row1["ret_amt"] = int.Parse(row1["ret_amt"].ToString()) + decimal.Round(decimal.Parse(Row["amt"].ToString()) * (-1), 0);
                                            else if (eatsalcode == salcode)
                                                row1["eat_amt"] = int.Parse(row1["eat_amt"].ToString()) + decimal.Round(decimal.Parse(Row["amt"].ToString()) * (-1), 0);
                                            else if (welsalcode == salcode)
                                                row1["wel_amt"] = int.Parse(row1["wel_amt"].ToString()) + decimal.Round(decimal.Parse(Row["amt"].ToString()) * (-1), 0);
                                            row1["tol_amt"] = int.Parse(row1["lab_amt"].ToString()) + int.Parse(row1["hel_amt"].ToString()) + int.Parse(row1["grp_amt"].ToString()) + int.Parse(row1["ret_amt"].ToString()) + int.Parse(row1["eat_amt"].ToString()) + int.Parse(row1["wel_amt"].ToString());
                                        }
                                        else
                                        {
                                            DataRow aRow = ds.Tables["zz421g"].NewRow();
                                            aRow["comp"] = row["comp"].ToString();
                                            aRow["dept"] = row["dept"].ToString();
                                            aRow["d_name"] = row["d_name"].ToString();
                                            aRow["nobr"] = Row["nobr"].ToString();
                                            aRow["name_c"] = row["name_c"].ToString();
                                            aRow["jobl_name"] = row["jobl_name"].ToString();
                                            aRow["lab_amt"] = (lsalcode == salcode) ? decimal.Round(decimal.Parse(Row["amt"].ToString()) * (-1), 0) : 0;
                                            aRow["hel_amt"] = (hsalcode == salcode) ? decimal.Round(decimal.Parse(Row["amt"].ToString()) * (-1), 0) : 0;
                                            aRow["grp_amt"] = (groupsalcd == salcode) ? decimal.Round(decimal.Parse(Row["amt"].ToString()) * (-1), 0) : 0;
                                            aRow["ret_amt"] = (retsalcode == salcode) ? decimal.Round(decimal.Parse(Row["amt"].ToString()) * (-1), 0) : 0;
                                            aRow["eat_amt"] = (eatsalcode == salcode) ? decimal.Round(decimal.Parse(Row["amt"].ToString()) * (-1), 0) : 0;
                                            aRow["wel_amt"] = (welsalcode == salcode) ? decimal.Round(decimal.Parse(Row["amt"].ToString()) * (-1), 0) : 0;
                                            aRow["tol_amt"] = int.Parse(aRow["lab_amt"].ToString()) + int.Parse(aRow["hel_amt"].ToString()) + int.Parse(aRow["grp_amt"].ToString()) + int.Parse(aRow["ret_amt"].ToString()) + int.Parse(aRow["eat_amt"].ToString()) + int.Parse(aRow["wel_amt"].ToString());
                                            ds.Tables["zz421g"].Rows.Add(aRow);
                                        }
                                    }
                                }
                                else
                                {
                                    if (row != null)
                                    {
                                        DataRow row2 = ds.Tables["zz421ga"].Rows.Find(row["comp"].ToString());
                                        if (row2 != null)
                                        {
                                            if (lsalcode == salcode)
                                                row2["lab_amt"] = int.Parse(row2["lab_amt"].ToString()) + decimal.Round(decimal.Parse(Row["amt"].ToString()) * (-1), 0);
                                            else if (hsalcode == salcode)
                                                row2["hel_amt"] = int.Parse(row2["hel_amt"].ToString()) + decimal.Round(decimal.Parse(Row["amt"].ToString()) * (-1), 0);
                                            else if (groupsalcd == salcode)
                                                row2["grp_amt"] = int.Parse(row2["grp_amt"].ToString()) + decimal.Round(decimal.Parse(Row["amt"].ToString()) * (-1), 0);
                                            else if (retsalcode == salcode)
                                                row2["ret_amt"] = int.Parse(row2["ret_amt"].ToString()) + decimal.Round(decimal.Parse(Row["amt"].ToString()) * (-1), 0);
                                            else if (eatsalcode == salcode)
                                                row2["eat_amt"] = int.Parse(row2["eat_amt"].ToString()) + decimal.Round(decimal.Parse(Row["amt"].ToString()) * (-1), 0);
                                            else if (welsalcode == salcode)
                                                row2["wel_amt"] = int.Parse(row2["wel_amt"].ToString()) + decimal.Round(decimal.Parse(Row["amt"].ToString()) * (-1), 0);
                                            row2["tol_amt"] = int.Parse(row2["lab_amt"].ToString()) + int.Parse(row2["hel_amt"].ToString()) + int.Parse(row2["grp_amt"].ToString()) + int.Parse(row2["ret_amt"].ToString()) + int.Parse(row2["eat_amt"].ToString()) + int.Parse(row2["wel_amt"].ToString());
                                        }
                                        else
                                        {
                                            DataRow aRow1 = ds.Tables["zz421ga"].NewRow();
                                            aRow1["comp"] = row["comp"].ToString();
                                            aRow1["compname"] = row["compname"].ToString();
                                            aRow1["cnt"] = 0;
                                            aRow1["lab_amt"] = (lsalcode == salcode) ? decimal.Round(decimal.Parse(Row["amt"].ToString()) * (-1), 0) : 0;
                                            aRow1["hel_amt"] = (hsalcode == salcode) ? decimal.Round(decimal.Parse(Row["amt"].ToString()) * (-1), 0) : 0;
                                            aRow1["grp_amt"] = (groupsalcd == salcode) ? decimal.Round(decimal.Parse(Row["amt"].ToString()) * (-1), 0) : 0;
                                            aRow1["ret_amt"] = (retsalcode == salcode) ? decimal.Round(decimal.Parse(Row["amt"].ToString()) * (-1), 0) : 0;
                                            aRow1["eat_amt"] = (eatsalcode == salcode) ? decimal.Round(decimal.Parse(Row["amt"].ToString()) * (-1), 0) : 0;
                                            aRow1["wel_amt"] = (welsalcode == salcode) ? decimal.Round(decimal.Parse(Row["amt"].ToString()) * (-1), 0) : 0;
                                            aRow1["tol_amt"] = int.Parse(aRow1["lab_amt"].ToString()) + int.Parse(aRow1["hel_amt"].ToString()) + int.Parse(aRow1["grp_amt"].ToString()) + int.Parse(aRow1["ret_amt"].ToString()) + int.Parse(aRow1["eat_amt"].ToString()) + int.Parse(aRow1["wel_amt"].ToString());
                                            ds.Tables["zz421ga"].Rows.Add(aRow1);
                                        }

                                        object[] _value1 = new object[2];
                                        _value1[0] = row["comp"].ToString();
                                        _value1[1] = Row["nobr"].ToString();
                                        DataRow row3 = rq_zz421gb.Rows.Find(_value1);
                                        if (row3 == null)
                                        {
                                            DataRow aRow2 = rq_zz421gb.NewRow();
                                            aRow2["comp"] = row["comp"].ToString();
                                            aRow2["nobr"] = Row["nobr"].ToString();
                                            rq_zz421gb.Rows.Add(aRow2);
                                        }
                                    }
                                }
                            }
                            if (reporttype == "19")
                            {
                                if (ds.Tables["zz421ga"].Rows.Count < 1)
                                {
                                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                                    this.Close();
                                    return;
                                }
                                foreach (DataRow Row in ds.Tables["zz421ga"].Rows)
                                {
                                    DataRow[] row = rq_zz421gb.Select("comp='" + Row["comp"].ToString() + "'");
                                    if (row.Length > 0)
                                        Row["cnt"] = row.Length;
                                }
                            }
                            else
                            {
                                if (ds.Tables["zz421g"].Rows.Count < 1)
                                {
                                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                                    this.Close();
                                    return;
                                }
                            }
                            rq_zz421gb = null;
                            rq_usys2 = null;
                            rq_usys4 = null;
                            rq_usys5 = null;
                            rq_usys6 = null;

                            break;
                        case "17":  //所得稅代扣報表                      
                            DataTable rq_notaxamt = new DataTable();
                            rq_notaxamt.Columns.Add("nobr", typeof(string));
                            rq_notaxamt.Columns.Add("count_ma", typeof(bool));
                            rq_notaxamt.Columns.Add("amt", typeof(decimal));
                            rq_notaxamt.PrimaryKey = new DataColumn[] { rq_notaxamt.Columns["nobr"] };
                            ds.Tables["zz421h"].PrimaryKey = new DataColumn[] { ds.Tables["zz421h"].Columns["nobr"] };
                            foreach (DataRow Row in ds.Tables["rq_waged"].Rows)
                            {
                                DataRow row0 = rq_base.Rows.Find(Row["nobr"].ToString());
                                if (row0 != null)
                                {
                                    DataRow row = ds.Tables["zz421h"].Rows.Find(Row["nobr"].ToString());
                                    if (bool.Parse(Row["tax"].ToString()))
                                    {
                                        if (row != null)
                                        {
                                            row["amt"] = decimal.Round(decimal.Parse(row["amt"].ToString()) + decimal.Parse(Row["amt"].ToString()), 0);
                                            row["tolamt"] = decimal.Round(decimal.Parse(row["tolamt"].ToString()) + decimal.Parse(Row["amt"].ToString()), 0);
                                        }
                                        else
                                        {
                                            DataRow aRow = ds.Tables["zz421h"].NewRow();
                                            aRow["nobr"] = Row["nobr"].ToString();
                                            aRow["count_ma"] = bool.Parse(row0["count_ma"].ToString());
                                            aRow["amt"] = decimal.Round(decimal.Parse(Row["amt"].ToString()), 0);
                                            aRow["taxamt"] = 0;
                                            aRow["tolamt"] = decimal.Round(decimal.Parse(Row["amt"].ToString()), 0);
                                            aRow["amt1"] = 0;
                                            aRow["notaxamt"] = 0;
                                            ds.Tables["zz421h"].Rows.Add(aRow);
                                        }
                                    }

                                    DataRow row1 = rq_notaxamt.Rows.Find(Row["nobr"].ToString());
                                    if (Row["sal_code"].ToString().Trim() == taxsalcode)
                                    {
                                        if (row1 != null)
                                            row1["amt"] = decimal.Round(decimal.Parse(row1["amt"].ToString()) + (decimal.Parse(Row["amt"].ToString()) * (-1)), 0);
                                        else
                                        {
                                            DataRow aRow1 = rq_notaxamt.NewRow();
                                            aRow1["nobr"] = Row["nobr"].ToString();
                                            aRow1["count_ma"] = bool.Parse(row0["count_ma"].ToString());
                                            aRow1["amt"] = decimal.Round(decimal.Parse(Row["amt"].ToString()) * (-1), 0);
                                            rq_notaxamt.Rows.Add(aRow1);
                                        }
                                    }
                                }
                            }
                            if (ds.Tables["zz421h"].Rows.Count < 1)
                            {
                                MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                                this.Close();
                                return;
                            }
                            foreach (DataRow Row in ds.Tables["zz421h"].Rows)
                            {
                                string str_nobr = Row["nobr"].ToString();
                                DataRow row = rq_notaxamt.Rows.Find(Row["nobr"].ToString());
                                if (row != null)
                                {
                                    Row["taxamt"] = decimal.Round(decimal.Parse(row["amt"].ToString()));
                                    Row["notaxamt"] = 0;
                                }
                                else
                                {
                                    Row["amt1"] = decimal.Round(decimal.Parse(Row["amt"].ToString()));
                                    Row["amt"] = 0;
                                }
                            }
                            rq_notaxamt = null;
                            break;
                        case "9":
                        case "18":
                        case "20":
                            break;
                        default:
                            //						挑外勞特定的薪資項目轉帳及領現
                            if (infor && ((reporttype == "5") || (reporttype == "6") || (reporttype == "7") || (reporttype == "10") || (reporttype == "20")))
                            {
                                if (reporttype == "6")
                                {
                                    ds.Tables["zz42td"].PrimaryKey = new DataColumn[] { ds.Tables["zz42td"].Columns["comp"], ds.Tables["zz42td"].Columns["dept"] };
                                    JBHR.Reports.ZZ42Class.Get_Report6A(ds.Tables["zz42td"], ds.Tables["rq_waged"], rq_base);
                                }
                                else
                                {
                                    JBHR.Reports.ZZ42Class.Get_Report6A(ds.Tables["zz42td"], ds.Tables["rq_waged"], rq_base);

                                }
                            }
                            else
                            {

                                if (rq_usys4.Rows.Count > 0)
                                {
                                    DataRow row1 = rq_salcode.Rows.Find(rq_usys4.Rows[0]["retsalcode"].ToString());
                                    if (row1 != null)
                                        retsalcode2 = row1["sal_code_disp"].ToString().Trim();
                                }
                                //							求得應稅合計金額
                                ds.Tables.Add("wageds1");
                                ds.Tables["wageds1"].Columns.Add("nobr", typeof(string));
                                ds.Tables["wageds1"].Columns.Add("tot1", typeof(decimal));
                                ds.Tables["wageds1"].PrimaryKey = new DataColumn[] { ds.Tables["wageds1"].Columns["nobr"] };
                                JBHR.Reports.ZZ42Class.Get_wageds1(ds.Tables["wageds1"], ds.Tables["rq_waged"], rq_base);
                                //					求得應發合計金額
                                ds.Tables.Add("wageds2");
                                ds.Tables["wageds2"].Columns.Add("nobr", typeof(string));
                                ds.Tables["wageds2"].Columns.Add("tot2", typeof(decimal));
                                ds.Tables["wageds2"].PrimaryKey = new DataColumn[] { ds.Tables["wageds2"].Columns["nobr"] };
                                JBHR.Reports.ZZ42Class.Get_wageds2(ds.Tables["wageds2"], ds.Tables["rq_waged"], rq_base, retsalcode2);

                                ds.Tables.Add("wagedsz");
                                ds.Tables["wagedsz"].Columns.Add("nobr", typeof(string));
                                ds.Tables["wagedsz"].Columns.Add("totz", typeof(decimal));
                                ds.Tables["wagedsz"].PrimaryKey = new DataColumn[] { ds.Tables["wagedsz"].Columns["nobr"] };
                                JBHR.Reports.ZZ42Class.Get_wagedsz(ds.Tables["wagedsz"], ds.Tables["rq_waged"], rq_base);
                            }
                            foreach (DataRow Row in ds.Tables["rq_waged"].Rows)
                            {
                                if (Row["flag"].ToString().Trim() == "-")
                                    Row["amt"] = decimal.Parse(Row["amt"].ToString()) * -1;
                            }
                            DataTable zz422 = new DataTable();
                            zz422.Columns.Add("code1", typeof(string));
                            zz422.Columns.Add("salattr", typeof(string));
                            zz422.Columns.Add("sal_name", typeof(string));
                            DataColumn[] _key422 = new DataColumn[3];
                            _key422[0] = zz422.Columns["code1"];
                            _key422[1] = zz422.Columns["salattr"];
                            _key422[2] = zz422.Columns["sal_name"];
                            zz422.PrimaryKey = _key422;
                            DataRow aRowc1 = zz422.NewRow();
                            aRowc1["code1"] = "0001";
                            aRowc1["salattr"] = "F";
                            aRowc1["sal_name"] = "3";
                            zz422.Rows.Add(aRowc1);

                            DataRow aRowc2 = zz422.NewRow();
                            aRowc2["code1"] = "0001";
                            aRowc2["salattr"] = "L";
                            aRowc2["sal_name"] = "3";
                            zz422.Rows.Add(aRowc2);

                            DataRow aRowc3 = zz422.NewRow();
                            aRowc3["code1"] = "0001";
                            aRowc3["salattr"] = "O";
                            aRowc3["sal_name"] = "3";
                            zz422.Rows.Add(aRowc3);

                            DataTable zz423 = new DataTable();
                            zz423.Columns.Add("code1", typeof(string));
                            zz423.Columns.Add("salattr", typeof(string));
                            zz423.Columns.Add("sal_name", typeof(string));
                            DataColumn[] _key423 = new DataColumn[3];
                            _key423[0] = zz423.Columns["code1"];
                            _key423[1] = zz423.Columns["salattr"];
                            _key423[2] = zz423.Columns["sal_name"];
                            zz423.PrimaryKey = _key423;

                            DataRow bRow = zz423.NewRow();
                            bRow["code1"] = "0002";
                            bRow["salattr"] = "F";
                            bRow["sal_name"] = "合計";
                            zz423.Rows.Add(bRow);

                            DataRow bRow1 = zz423.NewRow();
                            bRow1["code1"] = "0002";
                            bRow1["salattr"] = "L";
                            bRow1["sal_name"] = "合計";
                            zz423.Rows.Add(bRow1);

                            DataRow bRow2 = zz423.NewRow();
                            bRow2["code1"] = "0002";
                            bRow2["salattr"] = "O";
                            bRow2["sal_name"] = "合計";
                            zz423.Rows.Add(bRow2);

                            DataTable zz421 = new DataTable();
                            zz421.Columns.Add("code1", typeof(string));
                            zz421.Columns.Add("salattr", typeof(string));
                            zz421.Columns.Add("sal_name", typeof(string));
                            DataRow cRow = zz421.NewRow();
                            cRow["code1"] = "0000";
                            cRow["salattr"] = "F";
                            if ((reporttype == "1" || reporttype == "2" || reporttype == "3" || reporttype == "4") && salary_pa1)
                                cRow["sal_name"] = "Dutiable Salary"; //英文版
                            else
                                cRow["sal_name"] = "應稅薪資";
                            zz421.Rows.Add(cRow);

                            DataRow cRow1 = zz421.NewRow();
                            cRow1["code1"] = "0000";
                            cRow1["salattr"] = "L";
                            if ((reporttype == "1" || reporttype == "2" || reporttype == "3" || reporttype == "4") && salary_pa1)
                                cRow1["sal_name"] = "應發薪資"; //英文版
                            else
                                cRow1["sal_name"] = "應發薪資";
                            zz421.Rows.Add(cRow1);

                            DataRow cRow2 = zz421.NewRow();
                            cRow2["code1"] = "0000";
                            cRow2["salattr"] = "O";
                            cRow2["sal_name"] = "實發金額";

                            if ((reporttype == "1" || reporttype == "2" || reporttype == "3" || reporttype == "4" || reporttype == "9" || reporttype == "18") && salary_pa1)
                                cRow2["sal_name"] = "Total Net Payable"; //英文版
                            else
                                cRow2["sal_name"] = "實發金額";
                            zz421.Rows.Add(cRow2);
                            ds.Tables.Add("zz42");
                            ds.Tables["zz42"].Columns.Add("nobr", typeof(string));
                            ds.Tables["zz42"].Columns.Add("ttrcode", typeof(string));
                            ds.Tables["zz42"].Columns.Add("amt", typeof(decimal));
                            JBHR.Reports.ZZ42Class.Get_zz42a(ds.Tables["zz42"], ds.Tables["rq_waged"]);

                            if ((reporttype == "9" || reporttype == "18"))
                            {
                                //							增加RPTTITLE的值如應發應扣得屬性
                                JBHR.Reports.ZZ42Class.Get_zz422(zz422, ds.Tables["rq_waged"]);

                                //							增加RPTTITLE的值如應發應扣得屬性
                                JBHR.Reports.ZZ42Class.Get_zz423(zz423, ds.Tables["rq_waged"]);

                                if (salary_pa1)
                                    JBHR.Reports.ZZ42Class.Get_zz421(zz421, ds.Tables["rq_waged"]);//英文版
                                else
                                    JBHR.Reports.ZZ42Class.Get_zz421_a(zz421, ds.Tables["rq_waged"]);
                            }
                            else
                            {    //							增加RPTTITLE的值如應發應扣得屬性
                                ds.EnforceConstraints = false;
                                JBHR.Reports.ZZ42Class.Get_zz422a(zz422, ds.Tables["rq_waged"]);
                                JBHR.Reports.ZZ42Class.Get_zz423a(zz423, ds.Tables["rq_waged"]);
                                if (((reporttype == "1") || (reporttype == "2") || (reporttype == "3") || (reporttype == "4")) && salary_pa1)
                                    JBHR.Reports.ZZ42Class.Get_zz421_c(zz421, ds.Tables["rq_waged"]);
                                else
                                    JBHR.Reports.ZZ42Class.Get_zz421_b(zz421, ds.Tables["rq_waged"]);
                            }
                            if (reporttype == "9" || reporttype == "18")
                                JBHR.Reports.ZZ42Class.Get_appzz421(zz421, zz422, zz423);
                            zz422 = null;
                            zz423 = null;
                            //								產生抬頭
                            DataTable zz4211 = new DataTable();
                            zz4211.Columns.Add("code1", typeof(string));
                            zz4211.Columns.Add("salattr", typeof(string));
                            zz4211.Columns.Add("sal_name", typeof(string));
                            JBHR.Reports.ZZ42Class.Get_zz4211(zz4211, zz421);
                            zz421 = null;

                            DataTable zz42gt = new DataTable();
                            zz42gt.Columns.Add("ttrcode", typeof(string));
                            zz42gt.Columns.Add("sal_name", typeof(string));
                            zz42gt.PrimaryKey = new DataColumn[] { zz42gt.Columns["ttrcode"] };
                            JBHR.Reports.ZZ42Class.Get_zz42gt(zz42gt, zz4211);

                            JBHR.Reports.ZZ42Class.Get_zz42add(ds.Tables["zz42"], ds.Tables["wageds1"], ds.Tables["wageds2"], ds.Tables["wagedsz"]);
                            JBHR.Reports.ZZ42Class.Get_zz42t(ds.Tables["zz42ta"], ds.Tables["zz42tb"], zz42gt, ds.Tables["zz42"], rq_base, report_type_item);

                            ds.Tables.Remove("zz42");

                            string _order = "0";
                            //資料排序,O=公司+部門+員工編號,1=不分公司,2=員工編號,3=部門+職等,4=職等
                            if (no_comp)
                                _order = "1";
                            else if (order1)
                                _order = "2";
                            else if (order2)
                                _order = "3";
                            else if (order3)
                                _order = "4";

                            //公司負擔金額
                            string sqlExplab = "select nobr,insur_type,comp from explab ";
                            sqlExplab += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                            sqlExplab += string.Format(@" and sal_yymm ='{0}' and fa_idno=''", yymm);
                            DataTable rq_explab1 = Sql.GetDataTable(sqlExplab);
                            DataTable rq_explab = new DataTable();
                            rq_explab.Columns.Add("nobr", typeof(string));
                            rq_explab.Columns.Add("h_amt", typeof(int));
                            rq_explab.Columns.Add("l_amt", typeof(int));
                            rq_explab.Columns.Add("r_amt", typeof(int));
                            rq_explab.PrimaryKey = new DataColumn[] { rq_explab.Columns["nobr"] };
                            JBHR.Reports.ZZ42Class.Get_Eplab(rq_explab, rq_explab1);
                            ds.Tables["zz42td"].PrimaryKey = new DataColumn[] { ds.Tables["zz42td"].Columns["dept"], ds.Tables["zz42td"].Columns["nobr"] };
                            JBHR.Reports.ZZ42Class.Get_zz42td2(ds.Tables["zz42td"], ds.Tables["zz42tb"], ds.Tables["rq_waged"], ds.Tables["wageds1"], ds.Tables["wageds2"], ds.Tables["wagedsz"], rq_base, rq_explab, rq_depts, reporttype, year, month, _order, report_type_item);
                            int addfd = ds.Tables["zz42td"].Rows.Count;
                            if (reporttype == "3" || reporttype == "4")
                            {
                                DataColumn[] _key42td1;
                                if (sumdi)
                                {
                                    _key42td1 = new DataColumn[2];
                                    _key42td1[0] = ds.Tables["zz42td1"].Columns["dept"];
                                    _key42td1[1] = ds.Tables["zz42td1"].Columns["di"];
                                }
                                else
                                {
                                    _key42td1 = new DataColumn[1];
                                    _key42td1[0] = ds.Tables["zz42td1"].Columns["dept"];
                                }
                                ds.Tables["zz42td1"].PrimaryKey = _key42td1;
                                JBHR.Reports.ZZ42Class.Get_zz42td3(ds.Tables["zz42td1"], ds.Tables["zz42td"], ds.Tables["zz42ta"], sumdi);

                                if (!no_upwage)
                                {
                                    //							求得應稅合計金額
                                    ds.Tables.Add("wagedup1");
                                    ds.Tables["wagedup1"].Columns.Add("nobr", typeof(string));
                                    ds.Tables["wagedup1"].Columns.Add("tot1", typeof(decimal));
                                    ds.Tables["wagedup1"].PrimaryKey = new DataColumn[] { ds.Tables["wagedup1"].Columns["nobr"] };
                                    JBHR.Reports.ZZ42Class.Get_wagedup1(ds.Tables["wagedup1"], ds.Tables["rq_waged1"], rq_base);
                                    //					求得應發合計金額
                                    ds.Tables.Add("wagedup2");
                                    ds.Tables["wagedup2"].Columns.Add("nobr", typeof(string));
                                    ds.Tables["wagedup2"].Columns.Add("tot2", typeof(decimal));
                                    ds.Tables["wagedup2"].PrimaryKey = new DataColumn[] { ds.Tables["wagedup2"].Columns["nobr"] };
                                    JBHR.Reports.ZZ42Class.Get_wagedup2(ds.Tables["wagedup2"], ds.Tables["rq_waged1"], rq_base, retsalcode2);

                                    ds.Tables.Add("wagedupz");
                                    ds.Tables["wagedupz"].Columns.Add("nobr", typeof(string));
                                    ds.Tables["wagedupz"].Columns.Add("totz", typeof(decimal));
                                    ds.Tables["wagedupz"].PrimaryKey = new DataColumn[] { ds.Tables["wagedupz"].Columns["nobr"] };
                                    JBHR.Reports.ZZ42Class.Get_wagedupz(ds.Tables["wagedupz"], ds.Tables["rq_waged1"], rq_base);
                                    ds.Tables["zz42tdcu"].PrimaryKey = new DataColumn[] { ds.Tables["zz42tdcu"].Columns["yymm"] };
                                    ds.Tables["zz42tdup"].PrimaryKey = new DataColumn[] { ds.Tables["zz42tdup"].Columns["yymm"] };
                                    JBHR.Reports.ZZ42Class.Get_zz42td4(ds.Tables["zz42tdcu"], ds.Tables["zz42tdup"], ds.Tables["rq_waged1"], ds.Tables["zz42ta"], ds.Tables["zz42td"], ds.Tables["wagedup1"], ds.Tables["wagedup2"], ds.Tables["wagedupz"], yymm_b, yymm);
                                    ds.Tables.Remove("wagedup1");
                                    ds.Tables.Remove("wagedup2");
                                    ds.Tables.Remove("wagedupz");
                                }
                            }
                            ds.Tables.Remove("wageds1");
                            ds.Tables.Remove("wageds2");
                            ds.Tables.Remove("wagedsz");
                            break;
                    }
                }


                if (report_type_item == "【清展】轉帳明細表")
                {
                    DataTable rq_bank = Sql.GetDataTable("select code_disp as code,bankname from BankCode");
                    rq_bank.PrimaryKey = new DataColumn[] { rq_bank.Columns["code"] };
                    JBHR.Reports.ZZ42Class.Get_zz4215(ds.Tables["zz4215_HISS"], ds.Tables["zz42ta"], ds.Tables["zz42td"], rq_bank, date_t, report_type_item, note1);
                    DataTable rq_test = new DataTable();

                    if (tran_count)
                    {
                        DataRow[] zz4215_row = ds.Tables["rq_waged"].Select("(sal_code='R01' or sal_code='R02')  and adate='" + date_t + "' and cash=0 and count_ma=1");

                        foreach (DataRow Row in zz4215_row)
                        {
                            DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                            DataRow row1 = rq_comp.Rows.Find(Row["comp"].ToString());
                            if (row != null)
                            {
                                if (row["account_ma"].ToString().Trim() != "")
                                {
                                    if (row.IsNull("bank_code")) row["bank_code"] = string.Empty;
                                    DataRow aRow = ds.Tables["zz4215_HISS"].NewRow();
                                    aRow["type"] = "外勞定存";
                                    aRow["comp"] = Row["comp"].ToString();
                                    aRow["compname"] = (row1 != null) ? row1["compname"].ToString() : "";
                                    aRow["nobr"] = Row["nobr"].ToString();
                                    aRow["name_c"] = Row["name_c"].ToString();
                                    aRow["tt"] = decimal.Parse(Row["amt"].ToString());
                                    aRow["account_no"] = Row["account_no"].ToString();
                                    aRow["idno"] = row["idno"].ToString();
                                    if (bool.Parse(row["count_ma"].ToString()))
                                    {
                                        //Row["bankno"] = row["bank_code"].ToString(); //外籍儲蓄款銀行
                                        aRow["idno"] = row["matno"].ToString();
                                        aRow["account_no"] = Row["account_ma"].ToString();
                                    }
                                    DataRow row2 = rq_bank.Rows.Find(Row["bankno"].ToString());
                                    //string bankname = (Row["bankno"].ToString().Trim() == "") ? "" : Row["bankno"].ToString().Trim().Substring(0, 3);
                                    //if (bankname == "822")
                                    //    aRow["bankname"] = "中國信託";
                                    //else if (bankname == "008")
                                    //    aRow["bankname"] = "華南";
                                    //else
                                    //    aRow["bankname"] = "";
                                    aRow["bankname"] = (row2 != null) ? row2["bankname"].ToString() : "";


                                    ds.Tables["zz4215_HISS"].Rows.Add(aRow);
                                }
                            }
                        }
                    }

                    if (no_name)
                    {
                        foreach (DataRow Row in ds.Tables["zz4215_HISS"].Rows)
                        {
                            Row["nobr"] = "";
                            Row["name_c"] = "";
                            Row["idno"] = "";

                        }
                    }

                    if (ds.Tables["zz4215_HISS"].Rows.Count < 1)
                    {
                        MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                        this.Close();
                        return;
                    }
                }
                else
                {
                    switch (reporttype)
                    {
                        case "5":
                            DataTable rq_bank = Sql.GetDataTable("select code,bankname from BankCode");
                            rq_bank.PrimaryKey = new DataColumn[] { rq_bank.Columns["code"] };
                            JBHR.Reports.ZZ42Class.Get_zz4215(ds.Tables["zz4215"], ds.Tables["zz42ta"], ds.Tables["zz42td"], rq_bank, date_t, report_type_item, "");
                            DataTable rq_test = new DataTable();

                            if (tran_count)
                            {
                                DataRow[] zz4215_row = ds.Tables["rq_waged"].Select("(sal_code='R01' or sal_code='R02')  and adate='" + date_t + "' and cash=0 and count_ma=1");

                                foreach (DataRow Row in zz4215_row)
                                {
                                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                                    DataRow row1 = rq_comp.Rows.Find(Row["comp"].ToString());
                                    if (row != null)
                                    {
                                        if (row["account_ma"].ToString().Trim() != "")
                                        {
                                            if (row.IsNull("bank_code")) row["bank_code"] = string.Empty;
                                            DataRow aRow = ds.Tables["zz4215"].NewRow();
                                            aRow["type"] = "外勞定存";
                                            aRow["comp"] = Row["comp"].ToString();
                                            aRow["compname"] = (row1 != null) ? row1["compname"].ToString() : "";
                                            aRow["nobr"] = Row["nobr"].ToString();
                                            aRow["name_c"] = Row["name_c"].ToString();
                                            aRow["tt"] = decimal.Parse(Row["amt"].ToString());
                                            aRow["account_no"] = Row["account_no"].ToString();
                                            aRow["idno"] = row["idno"].ToString();
                                            if (bool.Parse(row["count_ma"].ToString()))
                                            {
                                                //Row["bankno"] = row["bank_code"].ToString(); //外籍儲蓄款銀行
                                                aRow["idno"] = row["matno"].ToString();
                                                aRow["account_no"] = Row["account_ma"].ToString();
                                            }
                                            DataRow row2 = rq_bank.Rows.Find(Row["bankno"].ToString());
                                            //string bankname = (Row["bankno"].ToString().Trim() == "") ? "" : Row["bankno"].ToString().Trim().Substring(0, 3);
                                            //if (bankname == "822")
                                            //    aRow["bankname"] = "中國信託";
                                            //else if (bankname == "008")
                                            //    aRow["bankname"] = "華南";
                                            //else
                                            //    aRow["bankname"] = "";
                                            aRow["bankname"] = (row2 != null) ? row2["bankname"].ToString() : "";


                                            ds.Tables["zz4215"].Rows.Add(aRow);
                                        }
                                    }
                                }
                            }

                            if (no_name)
                            {
                                foreach (DataRow Row in ds.Tables["zz4215"].Rows)
                                {
                                    Row["nobr"] = "";
                                    Row["name_c"] = "";
                                    Row["idno"] = "";

                                }
                            }

                            if (ds.Tables["zz4215"].Rows.Count < 1)
                            {
                                MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                                this.Close();
                                return;
                            }
                            break;
                        case "6":
                            JBHR.Reports.ZZ42Class.Get_zz4216(ds.Tables["zz4216"], ds.Tables["zz42ta"], ds.Tables["zz42td"], ds.Tables["rq_waged"], rq_base, date_t);
                            if (ds.Tables["zz4216"].Rows.Count < 1)
                            {
                                MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                                this.Close();
                                return;
                            }
                            break;
                        case "7":
                            Acg = new JBModule.Data.ApplicationConfigSettings("ZZ42", MainForm.COMPANY);

                            string compid = "";
                            if (rq_sys1.Rows.Count > 0)
                            {
                                compid = rq_sys1.Rows[0]["compid"].ToString();
                            }

                            if (DataName == "ABLECOMHR")
                            {

                                DataTable rq_latecnt = JBHR.Reports.ZZ42Class.Get_LateMins(nobr_b, nobr_e, attdate_b, attdate_e);
                                rq_latecnt.PrimaryKey = new DataColumn[] { rq_latecnt.Columns["nobr"] };
                                JBHR.Reports.SalForm.CathayBK.Get_Report7ABLECOMHR(ds.Tables["zz42ta"], ds.Tables["zz42td"], rq_base, ds.Tables["rq_waged"], rq_latecnt, date_t, tran_count, Acg.GetConfig("Bank013").Value, seq);
                            }
                            else if (DataName == "JTFLEXHR")
                            {

                                DataTable rq_latecnt = JBHR.Reports.ZZ42Class.Get_LateMins(nobr_b, nobr_e, attdate_b, attdate_e);
                                rq_latecnt.PrimaryKey = new DataColumn[] { rq_latecnt.Columns["nobr"] };
                                JBHR.Reports.SalForm.CathayBK.Get_Report7_JTFLEXHR(ds.Tables["zz42ta"], ds.Tables["zz42td"], rq_base, ds.Tables["rq_waged"], rq_latecnt, date_t, tran_count, Acg.GetConfig("Bank052").Value, seq);
                            }
                            else
                            {
                                if (Salary_Transfer_Mode)
                                {
                                    //薪資主檔
                                    string Cmd_Salary_Transfer_Bank = "SELECT COMP_ID, COMP_NO, COMP_NAME, COMPANY_BANK_AC, COMPANY_BANK_NO, COMPANY_BANK_NAME, COMPANY_BANK_ID, ";
                                    Cmd_Salary_Transfer_Bank += " COMPANY_BANK_USER, COMPANY_BRANCH_CODE, COMPANY_BANK_LENGTH, COMP_HAS_HEADER, COMP_HAS_FOOTER, COMP_DATE_TYPE ";
                                    Cmd_Salary_Transfer_Bank += string.Format(@" FROM SalaryTransferBank WHERE COMP_ID = '{0}' ", compid);
                                    DataTable rq_Salary_Transfer_Bank = Sql.GetDataTable(Cmd_Salary_Transfer_Bank);
                                    rq_Salary_Transfer_Bank.PrimaryKey = new DataColumn[] { rq_Salary_Transfer_Bank.Columns["COMP_ID"], rq_Salary_Transfer_Bank.Columns["COMPANY_BANK_NO"] };


                                    //修改後呼叫位置
                                    JBHR.Reports.SalForm.BankSalTransfer.Get_Salary_Transfer_Report(ds.Tables["zz42ta"], ds.Tables["zz42td"], rq_base, ds.Tables["rq_waged"], date_t, tran_count, rq_Salary_Transfer_Bank);

                                }
                                else
                                {
                                    //原呼叫位置
                                    JBHR.Reports.SalForm.BankSalTransfer.Get_Report7(ds.Tables["zz42ta"], ds.Tables["zz42td"], rq_base, ds.Tables["rq_waged"], date_t, tran_count);

                                }
                            }

                            //JBHR.Reports.ZZ42Class.Get_Report7(ds.Tables["zz42ta"], ds.Tables["zz42td"], rq_base, ds.Tables["rq_waged"], date_t, tran_count);
                            break;
                        case "9":
                        case "18":
                        case "20"://薪資袋MAIL通知
                            Acg = new JBModule.Data.ApplicationConfigSettings("ZZ42", MainForm.COMPANY);
                            displns = (Acg.GetConfig("SalaryIns").Value == "1") ? true : false;
                            if (rq_usys4.Rows.Count > 0)
                            {
                                DataRow row1 = rq_salcode.Rows.Find(rq_usys4.Rows[0]["retsalcode"].ToString());
                                if (row1 != null)
                                    retsalcode2 = row1["sal_code_disp"].ToString().Trim();
                            }

                            //多國語系薪資單內容
                            DataTable rq_PaySlip = Sql.GetDataTable("select code,language,description,disp from mtdict where category='ZZ42' order by language,code");
                            rq_PaySlip.PrimaryKey = new DataColumn[] { rq_PaySlip.Columns["code"], rq_PaySlip.Columns["language"] };

                            DataTable rq_ota = JBHR.Reports.ZZ42Class.Get_Ota(nobr_b, nobr_e, yymm, labchedk);
                            DataTable rq_ot = new DataTable();
                            //2012/01/02修改只顯示平日及假日
                            rq_ot.Columns.Add("nobr", typeof(string));
                            rq_ot.Columns.Add("rate", typeof(decimal));
                            rq_ot.Columns.Add("othrs", typeof(decimal));
                            rq_ot.Columns.Add("unit", typeof(string));
                            //rq_ot.Columns.Add("ot_100", typeof(decimal));
                            //rq_ot.Columns.Add("ot_133", typeof(decimal));
                            //rq_ot.Columns.Add("ot_150", typeof(decimal));
                            //rq_ot.Columns.Add("ot_167", typeof(decimal));
                            //rq_ot.Columns.Add("ot_200", typeof(decimal));
                            //rq_ot.Columns.Add("ot_200_h", typeof(decimal));
                            //rq_ot.Columns.Add("ot_250_h", typeof(decimal));
                            //rq_ot.Columns.Add("weekhrs", typeof(decimal));
                            //rq_ot.Columns.Add("holihrs", typeof(decimal));
                            rq_ot.PrimaryKey = new DataColumn[] { rq_ot.Columns["nobr"], rq_ot.Columns["rate"] };
                            JBHR.Reports.ZZ42Class.Get_Ot(rq_ot, rq_ota, rq_PaySlip);

                            //DataTable rq_ot1 = JBHR.Reports.ZZ42Class.Get_Ot1(nobr_b, nobr_e, yymm);
                            //rq_ot1.PrimaryKey = new DataColumn[] { rq_ot1.Columns["nobr"] };

                            //DataTable rq_ot2 = JBHR.Reports.ZZ42Class.Get_Ot2(nobr_b, nobr_e, yymm);

                            ////累計應稅所得及累計所得稅
                            //DataTable rq_ytax = new DataTable();
                            //rq_ytax.Columns.Add("nobr", typeof(string));
                            //rq_ytax.Columns.Add("amt", typeof(int));
                            //rq_ytax.PrimaryKey = new DataColumn[] { rq_ytax.Columns["nobr"] };

                            //DataTable rq_ysalary = new DataTable();
                            //rq_ysalary.Columns.Add("nobr", typeof(string));
                            //rq_ysalary.Columns.Add("amt", typeof(string));
                            //rq_ysalary.PrimaryKey = new DataColumn[] { rq_ysalary.Columns["nobr"] };

                            ////累計自提退休金
                            //DataTable rq_yret = new DataTable();
                            //rq_yret.Columns.Add("nobr", typeof(string));
                            //rq_yret.Columns.Add("amt", typeof(int));
                            //rq_yret.PrimaryKey = new DataColumn[] { rq_yret.Columns["nobr"] };

                            //DataTable rq_allwage = JBHR.Reports.ZZ42Class.Get_AllWage(nobr_b, nobr_e, yymm_b.Substring(0, 4),yymm_b);
                            //rq_allwage.PrimaryKey = new DataColumn[] { rq_allwage.Columns["nobr"], rq_allwage.Columns["yymm"], rq_allwage.Columns["seq"] };
                            //DataTable rq_allwaged = JBHR.Reports.ZZ42Class.Get_AllWaged(nobr_b, nobr_e, yymm_b.Substring(0, 4),yymm_b);
                            //rq_allwaged.Columns.Add("salattr", typeof(string));
                            //rq_allwaged.Columns.Add("flag", typeof(string));
                            //JBHR.Reports.ZZ42Class.Get_AllWaged1(rq_ysalary, rq_ytax, rq_yret, rq_allwaged, rq_allwage, rq_salcode, rq_base,taxsalcode,retsalcode2);

                            //累計公司提撥退休金
                            //DataTable rq_yexplab = JBHR.Reports.ZZ42Class.Get_AllRet(nobr_b, nobr_e, yymm_b.Substring(0, 4),yymm_b);
                            //DataTable rq_yretcomp = new DataTable();
                            //rq_yretcomp.Columns.Add("nobr", typeof(string));
                            //rq_yretcomp.Columns.Add("comp", typeof(int));
                            //rq_yretcomp.PrimaryKey = new DataColumn[] { rq_yretcomp.Columns["nobr"] };
                            //JBHR.Reports.ZZ42Class.Get_AllRetComp(rq_yretcomp, rq_yexplab);                        

                            //加入勞退投保金額
                            //string date_e = DateTime.Now.ToString("yyyy/MM/dd");
                            //date_b異動截止日
                            string retdateb = JBHR.Reports.ReportClass.GetSalBDate(yymm_b.Substring(0, 4), yymm_b.Substring(4, 2));
                            string retdatee = JBHR.Reports.ReportClass.GetSalEDate(yymm_b.Substring(0, 4), yymm_b.Substring(4, 2));
                            DataTable rq_reta = JBHR.Reports.ZZ42Class.Get_Reta(nobr_b, nobr_e, retdateb, retdatee, workadr);
                            rq_reta.PrimaryKey = new DataColumn[] { rq_reta.Columns["nobr"] };
                            rq_reta.Columns.Add("fa_cnt", typeof(int));

                            ////計算在保眷屬人數
                            //DataTable rq_retcnt = JBHR.Reports.ZZ42Class.Get_RetCountFamailyCnt(nobr_b, nobr_e, DateTime.Parse(date_b).AddDays(1).AddMonths(-1).ToString("yyyy/MM/dd"), date_b, workadr);
                            //rq_retcnt.PrimaryKey = new DataColumn[] { rq_retcnt.Columns["nobr"] };                       

                            foreach (DataRow Row in rq_reta.Rows)
                            {
                                Row["r_amt"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row["r_amt"].ToString()));
                                Row["h_amt"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row["h_amt"].ToString()));
                                Row["l_amt"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row["l_amt"].ToString()));
                                //DataRow row = rq_retcnt.Rows.Find(Row["nobr"].ToString());
                                //if (row != null) Row["fa_cnt"] = int.Parse(row["cnt"].ToString());
                            }
                            //            JBModule.Data.CNPOI.RenderDataTableToExcel(rq_reta, "C:\\TEMP\\" + this.Name + ".xls");
                            //System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
                            //rq_retcnt = null;

                            //勞退公司負擔
                            DataTable rq_ret = JBHR.Reports.ZZ42Class.Get_Ret(nobr_b, nobr_e, date_b, yymm, workadr1);
                            rq_ret.PrimaryKey = new DataColumn[] { rq_ret.Columns["nobr"] };
                            foreach (DataRow Row in rq_ret.Rows)
                            {
                                Row["comp"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row["comp"].ToString()));
                            }

                            //勞退自提
                            DataTable rq_ret1 = new DataTable();
                            rq_ret1.Columns.Add("nobr", typeof(string));
                            rq_ret1.Columns.Add("amt", typeof(int));
                            rq_ret1.PrimaryKey = new DataColumn[] { rq_ret1.Columns["nobr"] };
                            string retsalcode = "";
                            if (rq_usys4 != null)
                            {
                                DataRow row1 = rq_salcode.Rows.Find(rq_usys4.Rows[0]["retsalcode"].ToString());
                                if (row1 != null)
                                {
                                    retsalcode = row1["sal_code_disp"].ToString().Trim();
                                }
                            }
                            decimal nretirerate = (rq_usys4 != null) ? decimal.Parse(rq_usys4.Rows[0]["nretirerate"].ToString()) : 0;
                            JBHR.Reports.ZZ42Class.Get_Ret1(rq_ret1, ds.Tables["rq_waged"], retsalcode);

                            string _edate = "";
                            if (year.Substring(0, 1) == "0")//(year.Substring(0, 2) == "00")
                                _edate = DateTime.Parse(Convert.ToString(int.Parse(year) + 1911) + "/" + month + "/01").AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd");
                            else
                                _edate = DateTime.Parse(year + "/" + month + "/01").AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd");
                            DataTable rq_rett = JBHR.Reports.ZZ42Class.Get_Rett(nobr_b, nobr_e, _edate, yymm, workadr1);
                            rq_rett.PrimaryKey = new DataColumn[] { rq_rett.Columns["nobr"] };
                            //薪資基本資料
                            //DataTable rq_salbasd = JBHR.Reports.ZZ42Class.Get_Salbasd(nobr_b, nobr_e, _edate, yymm, seq, workadr);
                            //DataTable rq_salbasd1 = new DataTable();
                            //rq_salbasd1.Columns.Add("nobr", typeof(string));
                            //rq_salbasd1.Columns.Add("amt", typeof(int));
                            //rq_salbasd1.PrimaryKey = new DataColumn[] { rq_salbasd1.Columns["nobr"] };
                            //JBHR.Reports.ZZ42Class.Get_Salbasd1(rq_salbasd1, rq_salbasd);

                            //扣項合計
                            //DataTable rq_sala = new DataTable();
                            //rq_sala.Columns.Add("nobr", typeof(string));
                            //rq_sala.Columns.Add("amt", typeof(int));
                            //rq_sala.PrimaryKey = new DataColumn[] { rq_sala.Columns["nobr"] };
                            //JBHR.Reports.ZZ42Class.Get_Sala(rq_sala, ds.Tables["rq_waged"]);

                            //請假資料
                            DataTable rq_attend = JBHR.Reports.ZZ42Class.Get_Attend(nobr_b, nobr_e, attdate_b, attdate_e);
                            DataTable rq_attbase = JBHR.Reports.ZZ42Class.Get_AttBase(nobr_b, nobr_e, attdate_e, workadr);
                            rq_attbase.PrimaryKey = new DataColumn[] { rq_attbase.Columns["nobr"] };
                            DataTable rq_att = new DataTable();
                            rq_att.Columns.Add("nobr", typeof(string));
                            rq_att.Columns.Add("h_code", typeof(string));
                            rq_att.Columns.Add("tot_hrs", typeof(int));
                            rq_att.PrimaryKey = new DataColumn[] { rq_att.Columns["nobr"] };
                            DataTable rq_att1 = new DataTable();
                            rq_att1 = rq_att.Clone();
                            rq_att1.TableName = "rq_att1";

                            //判斷遲到早退次數
                            //JBHR.Reports.ZZ42Class.Get_NAtt(rq_att, rq_att1, rq_attend, rq_attbase);
                            DataTable rq_abs1 = new DataTable();
                            if (salary_pa1)
                                rq_abs1 = JBHR.Reports.ZZ42Class.Get_Abs1(nobr_b, nobr_e, yymm, rq_PaySlip);
                            else
                                rq_abs1 = JBHR.Reports.ZZ42Class.Get_Abs2(nobr_b, nobr_e, yymm);

                            DataTable rq_abs = new DataTable();
                            rq_abs = rq_abs1.Clone();
                            rq_abs.TableName = "rq_abs";
                            JBHR.Reports.ZZ42Class.Get_Abs(rq_abs, rq_abs1, rq_base, prn_noemail);

                            //特休及補休剩餘時數
                            attdate_b = year + "/01/01";
                            DataTable rq_abs3 = JBHR.Reports.ZZ42Class.Get_Abs3(AnnualLeave_Type, CompensatoryLeave_Type, nobr_b, nobr_e, attdate_e, rq_wage, CompId, loginuser);
                            rq_abs3.PrimaryKey = new DataColumn[] { rq_abs3.Columns["nobr"] };

                            ds.Tables["zz4219"].PrimaryKey = new DataColumn[] { ds.Tables["zz4219"].Columns["nobr"] };
                            JBHR.Reports.ZZ42Class.Get_zz4219(ds.Tables["zz4219"], ds.Tables["rq_waged"], rq_base, rq_abs, rq_abs3, rq_att, rq_att1, rq_ret, rq_reta, rq_ret1, rq_rett, rq_ot, rq_PaySlip, nretirerate, salary_pa1, retsalcode2, prn_noemail);
                            //DataTable rq_test1 = new DataTable();
                            //rq_test1.Merge(ds.Tables["zz4219"]);
                            //JBHR.Reports.ReportClass.Export(rq_test1, this.Name);
                            //JBModule.Data.CNPOI.RenderDataTableToExcel(ds.Tables["zz4219"], "C:\\TEMP\\ZZ42_Report.xls");
                            //System.Diagnostics.Process.Start("C:\\TEMP\\ZZ42_Report.xls");
                            if (ds.Tables["zz4219"].Rows.Count < 1)
                            {
                                MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                                this.Close();
                                return;
                            }
                            if (sendsalary)
                            {
                                DataTable rqparameter = Sql.GetDataTable("select code,value from Parameter where code in ('JbMail.sys_mail','JbMail.TestAccount','JbMail.Sender')");
                                string _rptpath1 = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "SalReport", "*.rdlc");
                                JBHR.Reports.SalForm.MailSalary.Get_SendSalary1(ds.Tables["zz4219"], year, month, _rptpath1, note, date_t, comp_name, reporttype, note3, note_en, rqparameter, salary_pa1, nodispot, displns, SendDate);
                                JBModule.Data.ApplicationConfigSettings AppConfig = new JBModule.Data.ApplicationConfigSettings("ZZ42", MainForm.COMPANY);
                                string SendMailBWSW = AppConfig.GetConfig("SendMailBWSW").GetString("N");
                                if (SendMailBWSW != "Y")
                                    MessageBox.Show("薪資單發送完畢", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                                this.Close();
                                return;
                            }
                            break;
                        case "10":
                            JBHR.Reports.ZZ42Class.Get_zz4215t(ds.Tables["zz4215t"], ds.Tables["zz42ta"], ds.Tables["zz42td"]);
                            if (ds.Tables["zz4215t"].Rows.Count < 1)
                            {
                                MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                                this.Close();
                                return;
                            }
                            break;
                        case "14":
                            ds.Tables["zz421e"].PrimaryKey = new DataColumn[] { ds.Tables["zz421e"].Columns["job"] };
                            JBHR.Reports.ZZ42Class.Get_zz421e(ds.Tables["zz421e"], ds.Tables["rq_waged"], rq_base, rq_sys3);
                            if (ds.Tables["zz421e"].Rows.Count < 1)
                            {
                                MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                                this.Close();
                                return;
                            }
                            break;
                        default:
                            break;
                    }
                }
                rq_salcode = null;

                if (exportexcel)
                {
                    if (report_type_item == "【清展】轉帳明細表")
                    {
                        JBHR.Reports.ZZ42Class.ExPort_HISS(ds.Tables["zz4215_HISS"], this.Name, date_t, rq_base);
                    }
                    else
                    {
                        switch (reporttype)
                        {
                            case "1":
                            case "2":
                                //JBModule.Data.CNPOI.SaveDataSetToExcel(Rds, "C:\\TEMP\\" + this.Name + ".xls", true);
                                JBHR.Reports.ZZ42Class.ExPort1(ds.Tables["zz42td"], ds.Tables["zz42ta"], this.Name);
                                break;
                            case "3":
                            case "4":
                                JBHR.Reports.ZZ42Class.ExPort3(ds.Tables["zz42td1"], ds.Tables["zz42ta"], this.Name, sumdi);
                                break;
                            case "5":
                                JBHR.Reports.ZZ42Class.ExPort5(ds.Tables["zz4215"], this.Name, date_t);
                                break;
                            case "6":
                                JBHR.Reports.ZZ42Class.ExPort6(ds.Tables["zz4216"], this.Name);
                                break;
                            case "8":
                                JBHR.Reports.ZZ42Class.ExPort8(ds.Tables["zz4218"], this.Name);
                                break;
                            case "10":
                                JBHR.Reports.ZZ42Class.ExPort10(ds.Tables["zz4215t"], ds.Tables["zz42ta"], this.Name);
                                break;
                            case "11":
                                JBHR.Reports.ZZ42Class.ExPort11(ds.Tables["zz421b"], this.Name);
                                break;
                            case "12":
                                JBHR.Reports.ZZ42Class.ExPort12(ds.Tables["zz421c"], this.Name);
                                break;
                            case "13":
                                JBHR.Reports.ZZ42Class.ExPort13(ds.Tables["zz421d"], this.Name);
                                break;
                            case "14":
                                JBHR.Reports.ZZ42Class.ExPort14(ds.Tables["zz421e"], this.Name);
                                break;
                            case "15":
                                JBHR.Reports.ZZ42Class.ExPort15(ds.Tables["zz421f"], this.Name);
                                break;
                            case "16":
                                JBHR.Reports.ZZ42Class.ExPort16(ds.Tables["zz421g"], this.Name);
                                break;
                            case "17":
                                JBHR.Reports.ZZ42Class.ExPort17(ds.Tables["zz421h"], this.Name);
                                break;
                            case "19":
                                JBHR.Reports.ZZ42Class.ExPort19(ds.Tables["zz421ga"], this.Name);
                                break;
                            default:
                                break;
                        }
                    }
                    this.Close();
                }
                else
                {
                    //列印報表                   
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "SalReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "SalReport", "*.rdlc");
                    Acg = new JBModule.Data.ApplicationConfigSettings("ZZ42", MainForm.COMPANY);
                    DetailsA3 = (Acg.GetConfig("SalaryDetailsA3").Value == "1") ? true : false;
                    if (report_type_item == "【清展】轉帳明細表")
                    {
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4215_HISS.rdlc";
                        RptViewer.LocalReport.DataSources.Clear();
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateT", date_t) });
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YY", year) });
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("MM", month) });
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Repo", repo) });
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Note", note) });
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4215", ds.Tables["zz4215_HISS"]));
                    }
                    else
                    {
                        switch (reporttype)
                        {
                            case "1":
                            case "2":
                                if (no_deptcount)//部門不列印小計
                                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4211up.rdlc";
                                else
                                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4211u.rdlc";

                                if (pa)//小字
                                {
                                    if (no_deptcount)//部門不列印小計
                                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4211ap.rdlc";
                                    else
                                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4211a.rdlc";
                                }
                                if (pa2)//直式
                                {
                                    if (no_deptcount)//部門不列印小計
                                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4211cp.rdlc";
                                    else
                                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4211c.rdlc";
                                }
                                if (pa3)//大張小字
                                    if (no_deptcount)//部門不列印小計
                                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4211dp.rdlc";
                                    else
                                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4211d.rdlc";

                                if (pa1)//大張
                                {
                                    if (no_deptcount)//部門不列印小計
                                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4211bp.rdlc";
                                    else
                                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4211b.rdlc";
                                }

                                if (A3_BigCharacter)    //大張大字
                                {
                                    if (no_deptcount)   //部門不列印小計
                                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4211_no_subtotal.rdlc";
                                    else
                                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4211_subtotal.rdlc";
                                }

                                if (DetailsA3)
                                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4211r.rdlc";
                                //if (reporttype == "1")
                                //    repo = "薪資明細表--編制";
                                //else
                                //    repo = "薪資明細表--成本";
                                RptViewer.LocalReport.DataSources.Clear();
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("UserName", username) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YY", year) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("MM", month) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Repo", repo) });
                                if (pa1 || A3_BigCharacter)
                                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("NOTE1", note) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("NOTE", note3) });
                                RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz42td", ds.Tables["zz42td"]));
                                RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz42ta", ds.Tables["zz42ta"]));
                                break;
                            case "3":
                            case "4":
                                if (sumdi)
                                {
                                    if (no_upwage)
                                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4211t.rdlc";
                                    else if (pa3)
                                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4211ta.rdlc";
                                    else if (pa2)//直式
                                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4211dtp.rdlc";
                                    else if (A3_BigCharacter)    //大張大字
                                    {
                                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4211t_subtotal.rdlc";
                                    }
                                    else
                                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4211dt.rdlc";
                                }
                                else
                                {
                                    if (no_upwage)
                                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4211t1.rdlc";
                                    else if (pa3)
                                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4211ta1.rdlc";
                                    else if (pa2)//直式
                                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4211dtp1.rdlc";
                                    else if (A3_BigCharacter)    //大張大字
                                    {
                                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4211t_subtotal.rdlc";
                                    }
                                    else
                                    {
                                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4211dt1.rdlc";
                                    }
                                }
                                if (DetailsA3)
                                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4211tr.rdlc";
                                RptViewer.LocalReport.DataSources.Clear();
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("UserName", username) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YY", year) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("MM", month) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Repo", repo) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("NOTE", note3) });
                                RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz42td1", ds.Tables["zz42td1"]));
                                RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz42ta", ds.Tables["zz42ta"]));
                                RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz42tdup", ds.Tables["zz42tdup"]));
                                RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz42tdcu", ds.Tables["zz42tdcu"]));
                                break;
                            case "5":
                                RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4215.rdlc";
                                RptViewer.LocalReport.DataSources.Clear();
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateT", date_t) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YY", year) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("MM", month) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Repo", repo) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Note", note) });
                                RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4215", ds.Tables["zz4215"]));
                                break;
                            case "6":
                                RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4216.rdlc";
                                RptViewer.LocalReport.DataSources.Clear();
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YY", year) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("MM", month) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Repo", repo) });
                                RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4216", ds.Tables["zz4216"]));
                                break;
                            case "8":
                                RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4218.rdlc";
                                RptViewer.LocalReport.DataSources.Clear();
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YY", year) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("MM", month) });
                                RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4218", ds.Tables["zz4218"]));
                                break;
                            case "9":
                                if (salary_pa1)
                                {
                                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4219c.rdlc";
                                    RptViewer.LocalReport.DataSources.Clear();
                                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Note_EN", note_en) });

                                }
                                else
                                {
                                    if (print_pdf)
                                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4219pdf.rdlc";
                                    else
                                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4219.rdlc";
                                    RptViewer.LocalReport.DataSources.Clear();
                                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Note", note) });
                                }
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Datet", date_t) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YY", year) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("MM", month) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("NoDispOt", nodispot.ToString()) });
                                if (!salary_pa1) RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DispLns", displns.ToString()) });
                                RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4219", ds.Tables["zz4219"]));
                                if (print_pdf)
                                {
                                    Warning[] warnings;
                                    string[] streamids;
                                    string mimeType;
                                    string encoding;
                                    string extension;

                                    byte[] bytes = RptViewer.LocalReport.Render(
                                       "Pdf", null, out mimeType, out encoding, out extension,
                                       out streamids, out warnings);

                                    //FileStream fs = new FileStream(@"c:\temp\output.xls", FileMode.Create);
                                    FileStream fs = new FileStream(@"c:\temp\" + this.Name + ".pdf", FileMode.Create);
                                    System.Diagnostics.Process.Start(JBControls.ControlConfig.GetExportPath() + this.Name + ".pdf");
                                    fs.Write(bytes, 0, bytes.Length);
                                    fs.Close();
                                }

                                break;
                            case "10":
                                RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4215t.rdlc";
                                if (pa2)//直式
                                {
                                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4215tp.rdlc";
                                }
                                if (prn_paa)//A4橫式
                                {
                                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4215ta.rdlc";
                                }
                                if (DetailsA3)
                                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4215tr.rdlc";
                                RptViewer.LocalReport.DataSources.Clear();
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("UserName", username) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YY", year) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("MM", month) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Repo", repo) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("NOTE", note3) });
                                RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4215t", ds.Tables["zz4215t"]));
                                RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz42ta", ds.Tables["zz42ta"]));
                                break;
                            case "18":
                                if (salary_pa1)
                                {
                                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4219ac.rdlc";
                                    RptViewer.LocalReport.DataSources.Clear();
                                }
                                else
                                {
                                    if (print_pdf)
                                    {
                                        if (noret)
                                            RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4219a1pdf.rdlc";
                                        else
                                            RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4219apdf.rdlc";
                                    }
                                    else
                                    {
                                        if (noret)
                                            RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4219a1.rdlc";
                                        else
                                            RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4219a.rdlc";
                                    }
                                    RptViewer.LocalReport.DataSources.Clear();
                                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Note", note) });
                                }
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("ReportName", note3) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Datet", date_t) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YY", year) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("MM", month) });
                                RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4219", ds.Tables["zz4219"]));
                                if (print_pdf)
                                {
                                    Warning[] warnings;
                                    string[] streamids;
                                    string mimeType;
                                    string encoding;
                                    string extension;

                                    byte[] bytes = RptViewer.LocalReport.Render(
                                       "Pdf", null, out mimeType, out encoding, out extension,
                                       out streamids, out warnings);

                                    //FileStream fs = new FileStream(@"c:\temp\output.xls", FileMode.Create);
                                    FileStream fs = new FileStream(@"c:\temp\" + this.Name + ".pdf", FileMode.Create);
                                    System.Diagnostics.Process.Start(JBControls.ControlConfig.GetExportPath() + this.Name + ".pdf");
                                    fs.Write(bytes, 0, bytes.Length);
                                    fs.Close();
                                }
                                break;
                            case "11":
                                RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz421b.rdlc";
                                RptViewer.LocalReport.DataSources.Clear();
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("UserName", username) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YY", year) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("MM", month) });
                                RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz421b", ds.Tables["zz421b"]));
                                break;
                            case "12":
                                RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz421c.rdlc";
                                RptViewer.LocalReport.DataSources.Clear();
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YY", year) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("MM", month) });
                                RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz421c", ds.Tables["zz421c"]));
                                break;
                            case "13":
                                RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz421d.rdlc";
                                RptViewer.LocalReport.DataSources.Clear();
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YY", year) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("MM", month) });
                                RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz421d", ds.Tables["zz421d"]));
                                break;
                            case "14":
                                RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz421e.rdlc";
                                RptViewer.LocalReport.DataSources.Clear();
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YY", year) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("MM", month) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Repo", repo) });
                                RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz421e", ds.Tables["zz421e"]));
                                break;
                            case "15":
                                RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz421f.rdlc";
                                RptViewer.LocalReport.DataSources.Clear();
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("UserName", username) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYmm", yymm) });
                                RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz421f", ds.Tables["zz421f"]));
                                break;
                            case "16":
                                RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz421g.rdlc";
                                RptViewer.LocalReport.DataSources.Clear();
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("UserName", username) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYmm", yymm) });
                                RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz421g", ds.Tables["zz421g"]));
                                break;
                            case "17":
                                RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz421h.rdlc";
                                RptViewer.LocalReport.DataSources.Clear();
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("UserName", username) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYmm", yymm) });
                                RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz421h", ds.Tables["zz421h"]));
                                break;
                            case "19":
                                RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz421g1.rdlc";
                                RptViewer.LocalReport.DataSources.Clear();
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("UserName", username) });
                                RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYmm", yymm) });
                                RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz421ga", ds.Tables["zz421ga"]));
                                break;
                            default:
                                this.Close();
                                break;
                        }
                    }

                    if (reporttype != "7")
                    {
                        RptViewer.SetDisplayMode(DisplayMode.PrintLayout);
                        RptViewer.ZoomMode = ZoomMode.FullPage;
                        //RptViewer.ZoomPercent = JBHR.Reports.ReportClass.GetReportPercent();
                    }
                    if ((reporttype == "9" || reporttype == "18") && print_pdf && report_type_item != "【清展】轉帳明細表")
                        this.Close();
                }
                rq_base = null;
                rq_depts = null;
                rq_salcode = null;
                rq_usys4 = null;
                rq_usys9 = null;
                rq_wage = null;
                rq_comp = null; rq_sys10 = null;
                ds.Tables.Remove("rq_waged");
                //JBModule.Data.CExcel.GenerateHtml("C:\\TEMP\\" + this.Name + ".xls", ds.Tables["zz421h"], true);
                //System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
            }
            catch (Exception Ex)
            {
                JBModule.Message.TextLog.WriteLog(Ex);
                MessageBox.Show(Resources.All.ExceptionStr1 + "\n" + Ex.Message + ErrorMessage + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }
    }
}
