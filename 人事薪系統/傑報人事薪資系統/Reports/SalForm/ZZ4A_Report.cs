/* ======================================================================================================
 * 功能名稱：薪資總表
 * 功能代號：ZZ4A
 * 功能路徑：報表列印 > 薪資 > 薪資總表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ4A_Report.cs
 * 功能用途：
 *  用於產出薪資總表
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/01/13    Daniel Chih    Ver 1.0.01     1. 新增條件欄位：公司
 * 2021/09/10    Daniel Chih    Ver 1.0.02     1. 增加合併期別欄位
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/09/10
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

namespace JBHR.Reports.SalForm
{
    public partial class ZZ4A_Report : JBControls.JBForm
    {
        SalDataSet ds = new SalDataSet();
        string type_data, dept_type, nobr_b, nobr_e, dept_b, dept_e, depts_b, depts_e, comp_b, comp_e, year, month, seq, date_b ;
        string username, workadr, note, yymm, reporttype, repo_name, adate, emp_b, emp_e, comp_name, work_b, work_e, seqmerge;
        bool exportexcel;
        JBModule.Data.ApplicationConfigSettings AppConfig = new JBModule.Data.ApplicationConfigSettings("ZZ4A", MainForm.COMPANY);
        public ZZ4A_Report(string typedata, string depttype, string nobrb, string nobre, string deptb, string depte, string deptsb, string deptse
            , string compb, string compe, string empb, string empe,string workb,string worke, string _year, string _month, string _seq, string _seqmerge
            , string dateb, string _username, string _workadr, string _note, string _reporttype, string reponame, bool _exportexcel, string compname)
        {
            InitializeComponent();
            type_data = typedata; nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; depts_b = deptsb;
            depts_e = deptse; comp_b = compb; comp_e = compe; year = _year; month = _month; seq = _seq; seqmerge = _seqmerge; date_b = dateb;
            username = _username; workadr = _workadr; exportexcel = _exportexcel; 
            note = _note; dept_type = depttype; yymm = year + month; reporttype = _reporttype; repo_name = reponame;
            emp_b = empb; emp_e = empe; comp_name = compname; work_b = workb; work_e = worke;
        }

        private void ZZ4A_Report_Load(object sender, EventArgs e)
        {            
            try 
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select b.nobr,a.name_c,a.name_e,b.di,b.comp,e.compname,b.adate,a.count_ma,e.account";
                sqlCmd += (dept_type == "1" || reporttype == "2" || reporttype == "3") 
                    ? ",c.d_no_disp as dept,c.d_name" 
                    : ",c.d_no_disp as dept,c.d_name";

                sqlCmd += " from base a inner join basetts b on a.nobr=b.nobr ";

                //增加【公司】下拉式選單控制項條件 - Added By Daniel Chih - 2021/01/13
                sqlCmd += string.Format(@" and b.comp between '{0}' and '{1}'", comp_b, comp_e);

                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_b);
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);

                sqlCmd += (dept_type == "1" || reporttype == "2" || reporttype == "3") 
                    ? " left outer join depts c on b.depts=c.d_no" 
                    : " left outer join dept c on b.dept =c.d_no";

                sqlCmd += " left outer join comp e on b.comp=e.comp";

                sqlCmd += " where 1 = 1 ";

                sqlCmd += (dept_type == "1" || reporttype == "2" || reporttype == "3") 
                    ? string.Format(@" and c.d_no_disp between '{0}' and '{1}'", depts_b, depts_e) 
                    : string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);

                sqlCmd += type_data;
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };
                

                string sqlCmd1 = "select nobr,cash,adate from wage";
                sqlCmd1 += string.Format(@" where nobr between '{0}' and '{1}' ", nobr_b, nobr_e);
                sqlCmd1 += string.Format(@" and yymm='{0}' and seq='{1}'", yymm, seq);
                sqlCmd1 += string.Format(@" and saladr between '{0}' and '{1}'", work_b, work_e);
                sqlCmd1 += workadr;
                DataTable rq_wage = SqlConn.GetDataTable(sqlCmd1);
                rq_wage.PrimaryKey = new DataColumn[] { rq_wage.Columns["nobr"] };
                if (rq_wage.Rows.Count > 0)
                    adate = DateTime.Parse(rq_wage.Rows[0]["adate"].ToString()).ToString("yyyy/MM/dd");

                string sqlCmd2 = "select nobr,yymm,seq,sal_code,amt from waged";
                sqlCmd2 += string.Format(@" where nobr between '{0}' and '{1}' ", nobr_b, nobr_e);
                sqlCmd2 += string.Format(@" and yymm='{0}' and seq='{1}'", yymm, seq);
                sqlCmd2 += "  and sal_code<> '' and amt<>10";
                sqlCmd2 += " order by nobr";
                DataTable rq_waged = SqlConn.GetDataTable(sqlCmd2);


                if (!string.IsNullOrEmpty(seqmerge)) //第2期及其他期別薪資合併
                {
                    string CmdWagea = "select nobr,yymm,'2' as seq,account_no,wk_days,cash,note,adate,date_b,date_e,c.code_disp as bankno,";
                    CmdWagea += "b.saladr,b.comp,b.taxrate,b.att_dateb,b.att_datee,e.Lanaguage";
                    CmdWagea += " from ViewEmployeeLanaguage e,wage b ";
                    CmdWagea += " left outer join bankcode c on b.bankno=c.code_disp";
                    CmdWagea += " where b.nobr=e.EmployeeId";
                    CmdWagea += string.Format(@" and b.yymm='{0}' and b.seq='{1}'", yymm, seqmerge);
                    CmdWagea += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                    //CmdWagea += string.Format(@" and b.saladr between '{0}' and '{1}'", saladr_b, saladr_e);
                    CmdWagea += workadr;
                    DataTable rq_wagea = SqlConn.GetDataTable(CmdWagea);
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
                    DataTable rq_wageda = SqlConn.GetDataTable(CmdWageda);
                    rq_waged.Merge(rq_wageda);
                    rq_wageda.Clear();
                }

                rq_waged.Columns.Add("adate", typeof(DateTime));
                rq_waged.Columns.Add("name_c", typeof(string));
                rq_waged.Columns.Add("name_e", typeof(string));
                rq_waged.Columns.Add("dept", typeof(string));
                rq_waged.Columns.Add("d_name", typeof(string));
                rq_waged.Columns.Add("comp", typeof(string));
                rq_waged.Columns.Add("compname", typeof(string));
                rq_waged.Columns.Add("di", typeof(string));
                rq_waged.Columns.Add("cash", typeof(string));
                rq_waged.Columns.Add("sal_name", typeof(string));
                rq_waged.Columns.Add("flag", typeof(string));
                rq_waged.Columns.Add("acc_tr", typeof(string));
                rq_waged.Columns.Add("salattr", typeof(string));
                rq_waged.Columns.Add("acccd", typeof(string));
                rq_waged.Columns.Add("count_ma", typeof(bool));
                rq_waged.Columns.Add("account", typeof(string));
                rq_waged.Columns.Add("pno", typeof(decimal));
                rq_waged.Columns.Add("rate", typeof(decimal));
                string sqlCmd3 = "select a.sal_code,a.sal_code_disp,c.accname as sal_name,b.flag,b.salattr,c.acc_tr,a.acccd,c.acccd_disp";
                sqlCmd3 += " from salcode a inner join salattr b on a.sal_attr = b.salattr ";
                sqlCmd3 += " inner join acccd c on a.acccd = c.acccd ";
                sqlCmd3 += " where 1 = 1";
                DataTable rq_salcode = SqlConn.GetDataTable(sqlCmd3);
                rq_salcode.PrimaryKey = new DataColumn[] { rq_salcode.Columns["sal_code"] };

                //產生橫向表頭
                DataTable rq_zz4at = new DataTable();
                rq_zz4at.Columns.Add("salattr", typeof(string));
                rq_zz4at.Columns.Add("sal_name", typeof(string));
                switch (reporttype)
                {
                    case "0":
                    case "1":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                        foreach (DataRow Row in rq_waged.Rows)
                        {
                            DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                            DataRow row1 = rq_wage.Rows.Find(Row["nobr"].ToString());
                            DataRow row2 = rq_salcode.Rows.Find(Row["sal_code"].ToString());
                            if (row != null && row1 != null)
                            {
                                Row["cash"] = bool.Parse(row1["cash"].ToString());
                                Row["adate"] = DateTime.Parse(row1["adate"].ToString());
                                Row["name_c"] = row["name_c"].ToString();
                                Row["name_e"] = row["name_e"].ToString();
                                Row["di"] = row["di"].ToString();
                                Row["dept"] = row["dept"].ToString();
                                Row["d_name"] = row["d_name"].ToString();
                                Row["comp"] = row["comp"].ToString().Trim();
                                Row["compname"] = row["compname"].ToString();
                                Row["count_ma"] = bool.Parse(row["count_ma"].ToString());
                                Row["account"] = row["account"].ToString();
                                if (row2 != null)
                                {
                                    Row["sal_code"] = row2["sal_code_disp"].ToString();
                                    Row["sal_name"] = row2["sal_name"].ToString().Trim();
                                    Row["flag"] = row2["flag"].ToString();
                                    Row["acc_tr"] = row2["acc_tr"].ToString();
                                    Row["salattr"] = row2["salattr"].ToString();
                                    Row["acccd"] = row2["acccd_disp"].ToString();
                                }
                                if (Row["flag"].ToString().Trim() == "-")
                                    Row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString())) * (-1);
                                else
                                    Row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));
                            }
                            else
                                Row.Delete();
                        }
                        rq_waged.AcceptChanges();
                        
                        if (rq_waged.Rows.Count < 1)
                        {
                            MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                            this.Close();
                            return;
                        }                        
                        
                        JBHR.Reports.SalForm.ZZ4AClass.GetZz4at(ds.Tables["zz4ata"], rq_zz4at, rq_waged);
                        foreach (DataRow Row in rq_zz4at.Rows)
                        {
                            string aaat = Row["salattr"].ToString();
                            aaat = Row["sal_name"].ToString();
                        }
                        
                        //求得薪資總額
                        DataTable rq_wageds1 = new DataTable();
                        rq_wageds1.Columns.Add("nobr", typeof(string));
                        rq_wageds1.Columns.Add("dept", typeof(string));
                        rq_wageds1.Columns.Add("amt", typeof(int));
                        JBHR.Reports.SalForm.ZZ4AClass.GetWageds1(rq_wageds1, rq_waged);

                        //求得應扣總額
                        //20140828金額改為顯示正數
                        DataTable rq_wageds2 = new DataTable();
                        rq_wageds2.Columns.Add("nobr", typeof(string));
                        rq_wageds2.Columns.Add("dept", typeof(string));
                        rq_wageds2.Columns.Add("amt", typeof(int));
                        JBHR.Reports.SalForm.ZZ4AClass.GetWageds2(rq_wageds2, rq_waged);                       
                        
                        //求得應發總額
                        DataTable rq_wageds3 = new DataTable();
                        rq_wageds3.Columns.Add("nobr", typeof(string));
                        rq_wageds3.Columns.Add("dept", typeof(string));
                        rq_wageds3.Columns.Add("amt", typeof(int));
                        JBHR.Reports.SalForm.ZZ4AClass.GetWageds3(rq_wageds3, rq_waged);

                        //求得其他總計
                        DataTable rq_wageds4 = new DataTable();
                        rq_wageds4.Columns.Add("nobr", typeof(string));
                        rq_wageds4.Columns.Add("dept", typeof(string));
                        rq_wageds4.Columns.Add("amt", typeof(int));
                        JBHR.Reports.SalForm.ZZ4AClass.GetWageds4(rq_wageds4, rq_waged);

                        //求得合計金額
                        DataTable rq_wagedsz = new DataTable();
                        rq_wagedsz.Columns.Add("nobr", typeof(string));
                        rq_wagedsz.Columns.Add("dept", typeof(string));
                        rq_wagedsz.Columns.Add("amt", typeof(int));
                        JBHR.Reports.SalForm.ZZ4AClass.GetWagedsz(rq_wagedsz, rq_waged);

                        DataTable rq_wage7 = new DataTable();
                        rq_wage7.Columns.Add("comp", typeof(string));
                        rq_wage7.Columns.Add("amt1", typeof(int));
                        rq_wage7.Columns.Add("tax", typeof(int));
                        rq_wage7.Columns.Add("amt2", typeof(int));
                        rq_wage7.Columns.Add("no1", typeof(int));
                        rq_wage7.Columns.Add("no2", typeof(int));
                        //所得加總
                        if (reporttype == "0" || reporttype == "5" || reporttype == "6" || reporttype == "7")
                        {
                            //應稅薪資
                            DataTable rq_wagebt = new DataTable();
                            rq_wagebt.Columns.Add("comp", typeof(string));
                            rq_wagebt.Columns.Add("nobr", typeof(string));
                            rq_wagebt.Columns.Add("amt", typeof(int));
                            JBHR.Reports.SalForm.ZZ4AClass.GetWagebt(rq_wagebt, rq_waged);

                            //代扣稅額
                            DataTable rq_wagetax = new DataTable();
                            rq_wagetax.Columns.Add("comp", typeof(string));
                            rq_wagetax.Columns.Add("nobr", typeof(string));
                            rq_wagetax.Columns.Add("amt", typeof(int));
                            JBHR.Reports.SalForm.ZZ4AClass.GetWagetax(rq_wagetax, rq_waged);

                            rq_wage7.PrimaryKey = new DataColumn[] { rq_wage7.Columns["comp"] };
                            DataTable rq_wage7p = new DataTable();
                            rq_wage7p = rq_wage7.Clone();
                            rq_wage7p.TableName = "rq_wage7p";
                            JBHR.Reports.SalForm.ZZ4AClass.GetWage7(rq_wage7, rq_wagetax, rq_wagebt);
                            JBHR.Reports.SalForm.ZZ4AClass.GeTax7(rq_wagetax, rq_wage7);
                            JBHR.Reports.SalForm.ZZ4AClass.GeNoWage7(rq_wagebt, rq_wagetax, rq_wage7);
                            rq_wagebt = null;
                            rq_wagetax = null;
                            if (reporttype == "5")
                                JBHR.Reports.SalForm.ZZ4AClass.GeWage7p(rq_wage7p, rq_wage7);
                            else
                                JBHR.Reports.SalForm.ZZ4AClass.GeWage7p1(rq_wage7p, rq_wage7);

                        }

                        //公司負擔金額
                        string sqlExplab = "select nobr,insur_type,comp,fundamt from explab ";
                        sqlExplab += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                        sqlExplab += string.Format(@" and yymm ='{0}' and fa_idno=''", yymm);
                        DataTable rq_explab1 = SqlConn.GetDataTable(sqlExplab);
                        DataTable rq_explab = new DataTable();
                        rq_explab.Columns.Add("nobr", typeof(string));
                        rq_explab.Columns.Add("h_amt", typeof(int));
                        rq_explab.Columns.Add("l_amt", typeof(int));
                        rq_explab.Columns.Add("r_amt", typeof(int));
                        rq_explab.PrimaryKey = new DataColumn[] { rq_explab.Columns["nobr"] };
                        JBHR.Reports.ZZ42Class.Get_Eplab(rq_explab, rq_explab1);

                        JBHR.Reports.SalForm.ZZ4AClass.Get_ZZ4atd5(ds.Tables["zz4atd"], rq_waged, rq_wageds1, rq_wageds2, rq_wageds3, rq_wageds4, rq_wagedsz, rq_zz4at, rq_explab, reporttype);
                        
                        if (reporttype == "0" || reporttype == "5")
                        {
                            JBHR.Reports.SalForm.ZZ4AClass.Get_ZZ4atd1(ds.Tables["zz4atd"], ds.Tables["zz4atd1"], rq_zz4at, rq_wage7, reporttype);
                            if (ds.Tables["zz4atd1"].Rows.Count < 1)
                            {
                                MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                                this.Close();
                                return;
                            } 
                        }
                        else if (reporttype == "1" || reporttype == "4")
                        {
                            JBHR.Reports.SalForm.ZZ4AClass.Get_ZZ4atd2(ds.Tables["zz4atd"], ds.Tables["zz4atd2"], rq_zz4at, reporttype);
                            if (ds.Tables["zz4atd2"].Rows.Count < 1)
                            {
                                MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                                this.Close();
                                return;
                            }
                        }
                        else if (reporttype == "6" || reporttype == "7")
                        {
                            JBHR.Reports.SalForm.ZZ4AClass.Get_ZZ4atd3(ds.Tables["zz4atd"], ds.Tables["zz4atd1"], ds.Tables["zz4atd3"], rq_zz4at, rq_wage7);
                            if (ds.Tables["zz4atd3"].Rows.Count < 1)
                            {
                                MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                                this.Close();
                                return;
                            }
                        }
                        rq_wage7 = null; rq_wageds1 = null; rq_wageds2 = null; rq_wageds3 = null;rq_wageds4 = null; rq_wagedsz = null;
                        rq_zz4at = null;rq_explab=null;rq_explab1=null;
                        break;
                    default:
                        string sqlCmd4 = "select a.nobr,b.d_no_disp as depts,b.d_name,a.rate as rate from cost a";
                        sqlCmd4 += " left outer join depts b on a.depts=b.d_no";
                        sqlCmd4 += string.Format(@" where a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                        sqlCmd4 += string.Format(@" and '{0}' between a.cadate and a.cddate", date_b);
                        sqlCmd4 += " order by a.nobr,b.d_no_disp";
                        DataTable rq_cost = SqlConn.GetDataTable(sqlCmd4);
                        rq_cost.Columns.Add("amt", typeof(int));
                        string str_nobr1 = "";
                        foreach (DataRow Row in rq_waged.Rows)
                        {
                            DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                            DataRow row1 = rq_wage.Rows.Find(Row["nobr"].ToString());
                            DataRow row2 = rq_salcode.Rows.Find(Row["sal_code"].ToString());
                            if (row != null && row1 != null)
                            {
                                Row["cash"] = bool.Parse(row1["cash"].ToString());
                                Row["adate"] = DateTime.Parse(row1["adate"].ToString());
                                Row["name_c"] = row["name_c"].ToString();
                                Row["name_e"] = row["name_e"].ToString();
                                Row["di"] = row["di"].ToString();
                                Row["dept"] = row["dept"].ToString();
                                Row["d_name"] = row["d_name"].ToString();
                                Row["comp"] = row["comp"].ToString().Trim();
                                Row["compname"] = row["compname"].ToString();
                                Row["count_ma"] = bool.Parse(row["count_ma"].ToString());
                                Row["account"] = row["account"].ToString();
                                if (row2 != null)
                                {
                                    Row["sal_name"] = row2["sal_name"].ToString();
                                    Row["flag"] = row2["flag"].ToString();
                                    Row["acc_tr"] = row2["acc_tr"].ToString();
                                    Row["salattr"] = row2["salattr"].ToString();
                                    Row["acccd"] = row2["acccd_disp"].ToString();
                                    Row["sal_code"] = row2["sal_code_disp"].ToString();
                                }
                                if (Row["flag"].ToString().Trim() == "-")
                                    Row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString())) * (-1);
                                else
                                    Row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));
                                string str_nobr=Row["nobr"].ToString();
                                if (str_nobr!=str_nobr1)
                                    Row["pno"] = 1;
                                else
                                    Row["pno"] = 0;
                                str_nobr1 = Row["nobr"].ToString();
                                //if (Row["sal_code"].ToString().Trim() == "A01" || Row["sal_code"].ToString().Trim() == "A02")
                                //    Row["pno"] = 1;
                                //else
                                //    Row["pno"] = 0;
                            }
                            else
                                Row.Delete();
                        }
                        rq_waged.AcceptChanges();
                        if (rq_waged.Rows.Count < 1)
                        {
                            MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                            this.Close();
                            return;
                        }
                       
                        //DataTable rq_wagedb = new DataTable();
                        //rq_wagedb = rq_waged.Clone();
                        //rq_wagedb.TableName = "rq_wagedb";
                        //rq_wagedb.Columns.Add("rowcnt", typeof(int));
                        //JBHR.Reports.SalForm.ZZ4AClass.GeWagedb(rq_cost, rq_waged, rq_wagedb);
                        
                        //DataTable rq_wagedc = new DataTable();
                        //rq_wagedc.Columns.Add("nobr", typeof(string));
                        //rq_wagedc.Columns.Add("sal_code", typeof(string));
                        //rq_wagedc.Columns.Add("amt", typeof(int));

                        //rq_wagedc.PrimaryKey = new DataColumn[] { rq_wagedc.Columns["nobr"], rq_wagedc.Columns["sal_code"] };
                        //JBHR.Reports.SalForm.ZZ4AClass.GeWagedc(rq_wagedb, rq_wagedc);
                        

                        //if (reporttype == "2")
                        //    JBHR.Reports.SalForm.ZZ4AClass.GetWaged1(rq_waged, rq_wagedb, rq_wagedc);
                        //else
                        //    JBHR.Reports.SalForm.ZZ4AClass.GetWaged1(rq_waged, rq_wagedb, rq_wagedc);//GetWaged2
                        //JBHR.Reports.ReportClass.Export(rq_waged, this.Name);

                        DataTable rq_waged1 = new DataTable();
                        rq_waged1.Merge(rq_waged);
                        rq_waged.Clear();
                        JBHR.Reports.SalForm.ZZ4AClass.GeWagedN(rq_cost, rq_waged1, rq_waged);
                        rq_waged1 = null;
                        JBHR.Reports.SalForm.ZZ4AClass.GetZz4at(ds.Tables["zz4ata"], rq_zz4at, rq_waged);

                        //求得薪資總額
                        DataTable rq_wageds1a = new DataTable();
                        rq_wageds1a.Columns.Add("nobr", typeof(string));
                        rq_wageds1a.Columns.Add("dept", typeof(string));
                        rq_wageds1a.Columns.Add("amt", typeof(int));
                        JBHR.Reports.SalForm.ZZ4AClass.GetWageds1a(rq_wageds1a, rq_waged);
                        
                        //求得應扣總額
                        DataTable rq_wageds2a = new DataTable();
                        rq_wageds2a.Columns.Add("nobr", typeof(string));
                        rq_wageds2a.Columns.Add("dept", typeof(string));
                        rq_wageds2a.Columns.Add("amt", typeof(int));
                        JBHR.Reports.SalForm.ZZ4AClass.GetWageds2a(rq_wageds2a, rq_waged);

                        //求得應發總額
                        DataTable rq_wageds3a = new DataTable();
                        rq_wageds3a.Columns.Add("nobr", typeof(string));
                        rq_wageds3a.Columns.Add("dept", typeof(string));
                        rq_wageds3a.Columns.Add("amt", typeof(int));
                        JBHR.Reports.SalForm.ZZ4AClass.GetWageds3a(rq_wageds3a, rq_waged);

                        //求得其他總計
                        DataTable rq_wageds4a = new DataTable();
                        rq_wageds4a.Columns.Add("nobr", typeof(string));
                        rq_wageds4a.Columns.Add("dept", typeof(string));
                        rq_wageds4a.Columns.Add("amt", typeof(int));
                        JBHR.Reports.SalForm.ZZ4AClass.GetWageds4a(rq_wageds4a, rq_waged);

                        //求得合計金額
                        DataTable rq_wagedsza = new DataTable();
                        rq_wagedsza.Columns.Add("nobr", typeof(string));
                        rq_wagedsza.Columns.Add("dept", typeof(string));
                        rq_wagedsza.Columns.Add("amt", typeof(int));
                        JBHR.Reports.SalForm.ZZ4AClass.GetWagedsza(rq_wagedsza, rq_waged);
                        JBHR.Reports.SalForm.ZZ4AClass.Get_ZZ4atd(ds.Tables["zz4atd"], rq_waged, rq_wageds1a, rq_wageds2a, rq_wageds3a, rq_wageds4a, rq_wagedsza, rq_zz4at);
                       
                        if (reporttype == "2" || reporttype == "3")
                            JBHR.Reports.SalForm.ZZ4AClass.Get_ZZ4atd4(ds.Tables["zz4atd"], ds.Tables["zz4atd4"], rq_zz4at, reporttype);
                        rq_wageds1 = null;
                        rq_wageds2 = null;
                        rq_wageds3 = null;
                        rq_wageds4 = null;
                        rq_wagedsz = null;
                        rq_zz4at = null;
                        if (ds.Tables["zz4atd"].Rows.Count < 1)
                        {
                            MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                            this.Close();
                            return;
                        }
                        break;
                }
                rq_base = null;
                rq_salcode = null;
                rq_wage = null;
                rq_waged = null;
                rq_zz4at = null;

                if (exportexcel)
                {
                    if (reporttype == "0" || reporttype == "5")
                        JBHR.Reports.SalForm.ZZ4AClass.ExPort1(ds.Tables["zz4atd1"], ds.Tables["zz4ata"],this.Name,reporttype);
                    else if (reporttype == "1" || reporttype=="4")
                        JBHR.Reports.SalForm.ZZ4AClass.ExPort2(ds.Tables["zz4atd2"], ds.Tables["zz4ata"], this.Name,reporttype);
                    else if (reporttype == "6" || reporttype == "7")
                        JBHR.Reports.SalForm.ZZ4AClass.ExPort3(ds.Tables["zz4atd1"], ds.Tables["zz4ata"], this.Name, reporttype);
                    else if (reporttype == "2" || reporttype=="3")
                        JBHR.Reports.SalForm.ZZ4AClass.ExPort4(ds.Tables["zz4atd4"], ds.Tables["zz4ata"], this.Name, reporttype);
                    this.Close();
                }
                else
                {                   
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "SalReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "SalReport", "*.rdlc");
                    switch (reporttype)
                    {
                        case "0":
                            RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4a.rdlc";
                            RptViewer.LocalReport.DataSources.Clear();
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YY", year) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("MM", month) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DeptTyep", dept_type) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("RepoName", repo_name) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Note", note) });
                            RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4atd1", ds.Tables["zz4atd1"]));
                            RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4ata", ds.Tables["zz4ata"]));
                            break;
                        case "1":
                            RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4a1.rdlc";
                            RptViewer.LocalReport.DataSources.Clear();
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YY", year) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("MM", month) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DeptTyep", dept_type) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Note", note) });
                            RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4atd2", ds.Tables["zz4atd2"]));
                            RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4ata", ds.Tables["zz4ata"]));
                            break;
                        case "2":
                        case "3":
                            var DeptDspNewLine = AppConfig.GetConfig("DeptDspNewLine").GetString() == "False" ? false : true;

                            if (reporttype=="2" && DeptDspNewLine)
                                RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4a2.rdlc";
                            else if (reporttype == "2" && !DeptDspNewLine)
                                RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4a2a.rdlc";
                            else
                                RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4a3.rdlc";
                            RptViewer.LocalReport.DataSources.Clear();
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YY", year) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("MM", month) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Note", note) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("RepoName", repo_name) });
                            RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4atd4", ds.Tables["zz4atd4"]));
                            RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4ata", ds.Tables["zz4ata"]));
                            break;
                        case "4":
                            RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4a5.rdlc";
                            RptViewer.LocalReport.DataSources.Clear();
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YY", year) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("MM", month) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DeptTyep", dept_type) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Note", note) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("RepoName", repo_name) });
                            RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4atd2", ds.Tables["zz4atd2"]));
                            RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4ata", ds.Tables["zz4ata"]));
                            break;
                        case "5":
                            RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4a6.rdlc";
                            RptViewer.LocalReport.DataSources.Clear();
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YY", year) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("MM", month) });                            
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Note", note) });                            
                            RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4atd1", ds.Tables["zz4atd1"]));
                            RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4ata", ds.Tables["zz4ata"]));
                            break;
                        case "6":
                        case "7":
                            if (reporttype=="6")
                                RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4a7.rdlc";
                            else
                                RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4a8.rdlc";
                            RptViewer.LocalReport.DataSources.Clear();
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YY", year) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("MM", month) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Note", note) });
                            RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Adate", adate) });
                            RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4atd1", ds.Tables["zz4atd1"]));
                            RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4atd3", ds.Tables["zz4atd3"]));
                            RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4ata", ds.Tables["zz4ata"]));
                            break;
                        default:
                            break;

                    }
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
    }
}
