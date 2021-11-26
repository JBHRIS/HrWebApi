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
    public partial class ZZ4AA_Report : JBControls.JBForm
    {
        SalDataSet ds = new SalDataSet();
        string nobr_b, nobr_e, dept_b, dept_e, yymm, seq, date_b, type_data, username, lcstr2, lcstr3, year, month, report_type;
        bool exportexcel;
        public ZZ4AA_Report(string nobrb, string nobre, string deptb, string depte, string yy, string mm, string _seq, string dateb, string typedata, string _username, bool _exportexcel, string reporttype)
        {
            nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; yymm = yy + mm; seq = _seq;
            date_b = dateb; type_data = typedata; username = _username; exportexcel = _exportexcel;
            year = yy; month = mm; report_type = reporttype;
            InitializeComponent();
        }

        private void ZZ4AA_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                if (type_data == "1")
                {
                    lcstr2 = "";
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
                    lcstr2 = " AND (B.DI='D' OR A.COUNT_MA=1) ";
                    //repo = "直接+外勞";
                    lcstr3 = " AND (G.DI='D' OR F.COUNT_MA=1) AND G.DEPT BETWEEN '" + dept_b + "' AND '" + dept_e + "' ";
                }

                string sqlCmd = "select b.nobr,a.name_c,a.idno,a.sex,a.count_ma,a.bbcall,b.di,b.adate,b.indt,b.oudt,b.holi_code,";
                sqlCmd += "b.rotet,b.comp,a.taxno,a.account_ma,b.ttscode,b.workcd,b.empcd,b.depts,b.dept,c.d_name,a.email,";
                sqlCmd += "b.noret,d.job_disp as job,d.job_name,h.jobl_disp as jobl,h.job_name as jobl_name,i.compname,i.compid, b.saladr,b.tax_date,b.tax_edate,";
                sqlCmd += "a.matno,i.account,a.bankno,a.name_e,a.password,b.retchoo,a.taxcnt";
                sqlCmd += " from base a,dept c,basetts b";
                sqlCmd += " left outer join job d on b.job=d.job";
                sqlCmd += " left outer join jobl h on b.jobl=h.jobl";
                sqlCmd += " left outer join comp i on b.comp=i.comp";
                sqlCmd += " where a.nobr=b.nobr and b.dept=c.d_no";
                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_b);              
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and b.dept between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd += lcstr2;
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };


                //薪資相關代碼
                string CmdSalcode = "select a.sal_code,a.sal_name,a.sal_ename,b.salattr,b.flag,b.type,b.tax,a.notfreq,a.retire,a.forbank,a.forcash,";
                CmdSalcode += "a.acccd,c.accname ";
                CmdSalcode += " from salcode a,salattr b,acccd c where a.sal_attr=b.salattr and a.acccd=c.acccd";
                DataTable rq_salcode = SqlConn.GetDataTable(CmdSalcode);
                rq_salcode.PrimaryKey = new DataColumn[] { rq_salcode.Columns["sal_code"] };

                //薪資主檔
                string CmdWage = "select nobr,account_no,wk_days,cash,note,adate,date_b,date_e,bankno,saladr,comp,taxrate ";
                CmdWage += string.Format(@" from wage where yymm='{0}' and seq='{1}'", yymm, seq);
                CmdWage += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                DataTable rq_wage = SqlConn.GetDataTable(CmdWage);
                rq_wage.PrimaryKey = new DataColumn[] { rq_wage.Columns["nobr"] };

                string taxsalcode = ""; string retsalcode2 = "";
                DataTable rq_usys4 = SqlConn.GetDataTable("select retirerate,retsalcode,nretirerate,retirerate1,lsalcode from u_sys4");
                DataTable rq_usys9 = SqlConn.GetDataTable("select * from u_sys9");
                if (rq_usys9 != null) taxsalcode = rq_usys9.Rows[0]["taxsalcode"].ToString().Trim();
                if (rq_usys4.Rows.Count > 0) retsalcode2 = rq_usys4.Rows[0]["retsalcode"].ToString().Trim();

                string SqlDepts = "select d_no,d_name from depts";
                DataTable rq_depts = SqlConn.GetDataTable(SqlDepts);
                rq_depts.PrimaryKey = new DataColumn[] { rq_depts.Columns["d_no"] };

                //薪資明細資料
                string CmdWaged = "select nobr,yymm,seq,sal_code,amt from waged where ";
                CmdWaged += string.Format(@" yymm ='{0}' and seq='{1}'", yymm, seq);
                CmdWaged += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                CmdWaged += " and sal_code <> '' and amt <> 10 order by nobr";
                DataTable rq_waged = SqlConn.GetDataTable(CmdWaged);
                rq_waged.Columns.Add("name_c", typeof(string));
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
                rq_waged.Columns.Add("retchoo", typeof(string));
                rq_waged.Columns.Add("taxrate", typeof(decimal));                
                ds.Tables.Add("rq_waged");
                //string str_pass = "";
                foreach (DataRow Row in rq_waged.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    DataRow row1 = rq_wage.Rows.Find(Row["nobr"].ToString());
                    DataRow row2 = rq_salcode.Rows.Find(Row["sal_code"].ToString());
                    if (row == null || row1 == null)
                        Row.Delete();
                    else
                    {
                        if (row != null)
                        {
                            Row["name_c"] = row["name_c"].ToString();
                            Row["retchoo"] = row["retchoo"].ToString();                            
                        }
                        if (row1 != null)
                        {
                            Row["account_no"] = row1["account_no"].ToString();
                            Row["wk_days"] = decimal.Parse(row1["wk_days"].ToString());
                            Row["cash"] = bool.Parse(row1["cash"].ToString());
                            Row["note"] = row1["note"].ToString();
                            Row["adate"] = DateTime.Parse(row1["adate"].ToString());
                            Row["date_b"] = DateTime.Parse(row1["date_b"].ToString());
                            Row["date_e"] = DateTime.Parse(row1["date_e"].ToString());
                            Row["bankno"] = row1["bankno"].ToString();
                            Row["saladr"] = row1["saladr"].ToString();
                            Row["comp"] = row1["comp"].ToString();
                            Row["taxrate"] = decimal.Parse(row1["taxrate"].ToString());
                        }
                        if (row2 != null)
                        {
                            Row["sal_name"] = row2["sal_name"].ToString();
                            Row["sal_ename"] = row2["sal_ename"].ToString();
                            Row["salattr"] = row2["salattr"].ToString();
                            Row["flag"] = row2["flag"].ToString().Trim();
                            Row["type"] = row2["type"].ToString();
                            Row["tax"] = bool.Parse(row2["tax"].ToString());
                            Row["retire"] = bool.Parse(row2["retire"].ToString());
                            Row["forbank"] = bool.Parse(row2["forbank"].ToString());
                            Row["forcash"] = bool.Parse(row2["forcash"].ToString());
                            Row["acccd"] = row2["acccd"].ToString();
                            Row["accname"] = row2["accname"].ToString();
                            Row["notfreq"] = bool.Parse(row2["notfreq"].ToString());
                        }

                        if (Row["flag"].ToString() == "-")
                            Row["amt"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row["amt"].ToString())) * (-1);
                        else
                            Row["amt"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row["amt"].ToString()));

                        if (Row["type"].ToString().Trim() == "4")
                            Row.Delete();
                        if (Row["sal_code"].ToString() == taxsalcode)
                        {
                            Row["sal_code"] = taxsalcode.Substring(1, taxsalcode.Length - 1);
                            Row["salattr"] = "F";
                        }
                        if (Row["sal_code"].ToString().Trim()=="G01" || Row["sal_code"].ToString().Trim()=="H03")
                            Row["salattr"] = "O";
                        if (Row["sal_code"].ToString().Trim() == "H01")
                        {
                            Row["sal_code"] = "G0000";
                            Row["salattr"] = "O";
                        }

                    }
                }
                rq_waged.AcceptChanges();
                //JBModule.Data.CNPOI.RenderDataTableToExcel(rq_waged, "C:\\TEMP\\" + this.Name + ".xls");
                //System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
                ds.Tables["rq_waged"].Merge(rq_waged);
                taxsalcode=taxsalcode.Substring(1, taxsalcode.Length - 1);
                if (ds.Tables["rq_waged"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                
                //							應稅所得加總
                ds.Tables.Add("wageds1");
                ds.Tables["wageds1"].Columns.Add("nobr", typeof(string));
                ds.Tables["wageds1"].Columns.Add("tot1", typeof(decimal));
                ds.Tables["wageds1"].PrimaryKey = new DataColumn[] { ds.Tables["wageds1"].Columns["nobr"] };
                JBHR.Reports.ZZ42Class.Get_zz4aawageds1(ds.Tables["wageds1"], ds.Tables["rq_waged"], rq_base);
                //					應稅扣款加總
                ds.Tables.Add("wageds2");
                ds.Tables["wageds2"].Columns.Add("nobr", typeof(string));
                ds.Tables["wageds2"].Columns.Add("tot2", typeof(decimal));
                ds.Tables["wageds2"].PrimaryKey = new DataColumn[] { ds.Tables["wageds2"].Columns["nobr"] };
                JBHR.Reports.ZZ42Class.Get_zz4aawageds2(ds.Tables["wageds2"], ds.Tables["rq_waged"], rq_base);

                ds.Tables.Add("wageds3");
                ds.Tables["wageds3"].Columns.Add("nobr", typeof(string));
                ds.Tables["wageds3"].Columns.Add("tot2", typeof(decimal));
                ds.Tables["wageds3"].PrimaryKey = new DataColumn[] { ds.Tables["wageds3"].Columns["nobr"] };
                JBHR.Reports.ZZ42Class.Get_zz4aawageds3(ds.Tables["wageds3"], ds.Tables["rq_waged"], rq_base, taxsalcode);

                ds.Tables.Add("wageds4");
                ds.Tables["wageds4"].Columns.Add("nobr", typeof(string));
                ds.Tables["wageds4"].Columns.Add("tot2", typeof(decimal));
                ds.Tables["wageds4"].PrimaryKey = new DataColumn[] { ds.Tables["wageds4"].Columns["nobr"] };
                JBHR.Reports.ZZ42Class.Get_zz4aawageds4(ds.Tables["wageds4"], ds.Tables["rq_waged"], rq_base, taxsalcode);

                ds.Tables.Add("wagedsz");
                ds.Tables["wagedsz"].Columns.Add("nobr", typeof(string));
                ds.Tables["wagedsz"].Columns.Add("totz", typeof(decimal));
                ds.Tables["wagedsz"].PrimaryKey = new DataColumn[] { ds.Tables["wagedsz"].Columns["nobr"] };
                JBHR.Reports.ZZ42Class.Get_wagedsz(ds.Tables["wagedsz"], ds.Tables["rq_waged"], rq_base);

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

                DataRow cRow0 = zz421.NewRow();
                cRow0["code1"] = "0000";
                cRow0["salattr"] = "BZ";
                cRow0["sal_name"] = "應稅所得加總";
                zz421.Rows.Add(cRow0);

                DataRow cRow01 = zz421.NewRow();
                cRow01["code1"] = "0000";
                cRow01["salattr"] = "DZ";
                cRow01["sal_name"] = "應稅扣款加總";
                zz421.Rows.Add(cRow01);

                DataRow cRow = zz421.NewRow();
                cRow["code1"] = "0000";
                cRow["salattr"] = "FZ";
                cRow["sal_name"] = "代扣稅額加總";
                zz421.Rows.Add(cRow);

                DataRow cRow1 = zz421.NewRow();
                cRow1["code1"] = "0000";
                cRow1["salattr"] = "NZ";
                cRow1["sal_name"] = "最後所得扣款金額加總";
                zz421.Rows.Add(cRow1);

                DataRow cRow2 = zz421.NewRow();
                cRow2["code1"] = "0000";
                cRow2["salattr"] = "OZ";               
                cRow2["sal_name"] = "實發金額";               
                zz421.Rows.Add(cRow2);
                ds.Tables.Add("zz42");
                ds.Tables["zz42"].Columns.Add("nobr", typeof(string));
                ds.Tables["zz42"].Columns.Add("ttrcode", typeof(string));
                ds.Tables["zz42"].Columns.Add("amt", typeof(decimal));
                JBHR.Reports.ZZ42Class.Get_zz42a(ds.Tables["zz42"], ds.Tables["rq_waged"]);

                ds.EnforceConstraints = false;
                JBHR.Reports.ZZ42Class.Get_zz422a(zz422, ds.Tables["rq_waged"]);
                JBHR.Reports.ZZ42Class.Get_zz423a(zz423, ds.Tables["rq_waged"]);
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

                JBHR.Reports.ZZ42Class.Get_zz4aaadd(ds.Tables["zz42"], ds.Tables["wageds1"], ds.Tables["wageds2"], ds.Tables["wageds3"], ds.Tables["wageds4"], ds.Tables["wagedsz"]);
                JBHR.Reports.ZZ42Class.Get_zz42t(ds.Tables["zz42ta"], ds.Tables["zz42tb"], zz42gt, ds.Tables["zz42"], rq_base, "");
                
                ds.Tables.Remove("zz42");
                ds.Tables["zz4aatd"].PrimaryKey = new DataColumn[] { ds.Tables["zz4aatd"].Columns["dept"], ds.Tables["zz4aatd"].Columns["nobr"] };

                DataTable rq_abs = JBHR.Reports.ZZ42Class.Get_Abs2(nobr_b, nobr_e, yymm);
                rq_abs.PrimaryKey=new DataColumn[] {rq_abs.Columns["nobr"]};

                string sqlOt = "select nobr,dbo.HoliOtTypeAmt(yymm,nobr,'假日加班') as otamt1,dbo.OtTypeAmt(yymm,nobr,'1') as otamt2,";
                sqlOt += " dbo.OtTypeAmt(yymm,nobr,'2') as otamt3,dbo.HoliOtTypeAmt(yymm,nobr,'春節1.5倍加班') as otamt4,";
                sqlOt += " dbo.HoliOtTypeAmt(yymm,nobr,'國定假日加班') as otamt5,dbo.HoliOtTypeAmt(yymm,nobr,'春節2.5倍加班') as otamt6,";
                sqlOt += "dbo.OtTypeAmt(yymm,nobr,'0') as otamt7,";
                sqlOt += "dbo.HoliOtTypeHours(yymm,nobr,'假日加班') as othrs1,dbo.HoliOtTypeHours(yymm,nobr,'國定假日加班') as othrs2,";
                sqlOt += "dbo.HoliOtTypeHours(yymm,nobr,'春節1.5倍加班')  as othrs3,dbo.HoliOtTypeHours(yymm,nobr,'春節2.5倍加班') as othrs4,";
                sqlOt += "dbo.OtTypeHours(yymm,nobr,'1') as othrs5,dbo.OtTypeHours(yymm,nobr,'2') as othrs6,";
                sqlOt += "dbo.OtRestHrs(yymm,nobr) as otrest";
                sqlOt += string.Format(@" from ot where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlOt += string.Format(@" and yymm='{0}'  group by nobr,yymm", yymm);
                DataTable rq_ot = SqlConn.GetDataTable(sqlOt);
                rq_ot.PrimaryKey = new DataColumn[] { rq_ot.Columns["nobr"] };
               
                //健保眷口數
                string _hbdate = year + "/" + month + "/01";
                string _hedate = DateTime.Parse(_hbdate).AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd");
                string sqlinslab = "select nobr,count(nobr) as cnt from inslab ";
                sqlinslab += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlinslab += string.Format(@" and out_date>'{0}' and in_date<'{1}'", _hbdate, _hedate);
                sqlinslab += "  and fa_idno<>'' group by nobr";
                DataTable rq_inslab = SqlConn.GetDataTable(sqlinslab);
                rq_inslab.PrimaryKey = new DataColumn[] { rq_inslab.Columns["nobr"] };
                JBHR.Reports.ZZ42Class.Get_zz42td2A(ds.Tables["zz4aatd"], ds.Tables["zz42tb"], ds.Tables["rq_waged"], ds.Tables["wageds1"], ds.Tables["wageds2"], ds.Tables["wagedsz"], rq_base, rq_depts,rq_inslab, "1", year, month);
                ds.Tables.Remove("wageds1");
                ds.Tables.Remove("wageds2");
                ds.Tables.Remove("wagedsz");
                rq_base = null; rq_depts = null; rq_salcode = null;
                rq_usys4 = null; rq_usys9 = null; rq_wage = null; rq_waged = null; 
                if (exportexcel)
                {
                    Export(ds.Tables["zz4aatd"], ds.Tables["zz42ta"],rq_ot,rq_abs);                   
                    this.Close();
                }
                else
                {
                    string company = "";
                    DataTable rq_sys = ReportClass.GetU_Sys();
                    if (rq_sys.Rows.Count > 0)
                        company = rq_sys.Rows[0]["company"].ToString();
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "SalReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "SalReport", "*.rdlc");
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz412.rdlc";

                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", company) });                   
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz41", ds.Tables["zz41"]));
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_Abssumd1", ds.Tables["abssumd1"]));
                    RptViewer.SetDisplayMode(DisplayMode.PrintLayout);
                    RptViewer.ZoomMode = ZoomMode.FullPage;
                    //RptViewer.ZoomPercent = JBHR.Reports.ReportClass.GetReportPercent();
                }

                //JBModule.Data.CNPOI.RenderDataTableToExcel(ds.Tables["zz4aatd"], "C:\\TEMP\\" + this.Name + ".xls");
                //System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Resources.All.ExceptionStr1 + "\n" + Ex.Message + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }


        void Export(DataTable DT_42td, DataTable DT_42ta, DataTable DT_Ot, DataTable DT_Abs)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            if (report_type == "0")
            {
                ExporDt.Columns.Add("員工編號", typeof(string));
                ExporDt.Columns.Add("員工姓名", typeof(string));
                ExporDt.Columns.Add("扶養人數", typeof(int));
                ExporDt.Columns.Add("健保眷口人數", typeof(int));
            }
            else
            {
                ExporDt.Columns.Add("發薪人數", typeof(int));
            }
            ExporDt.Columns.Add("假日加班費-1", typeof(int));
            ExporDt.Columns.Add("平日加班費-1", typeof(int));            
            ExporDt.Columns.Add("平日加班費-2", typeof(int));
            ExporDt.Columns.Add("平日加班費", typeof(int));
            ExporDt.Columns.Add("春節加班1.5", typeof(int));
            ExporDt.Columns.Add("國定假日加班費", typeof(int));
            ExporDt.Columns.Add("春節加班2.5", typeof(int));
            ExporDt.Columns.Add("假日加班總時數(1.5)", typeof(decimal));
            ExporDt.Columns.Add("國定假日加班總時數(1.5)", typeof(decimal));
            ExporDt.Columns.Add("春節假日加班總時數(1.5)", typeof(decimal));
            ExporDt.Columns.Add("春節假日加班總時數(2.5)", typeof(decimal));
            ExporDt.Columns.Add("平日加班總時數(1.33)", typeof(decimal));
            ExporDt.Columns.Add("平日加班總時數(1.66)", typeof(decimal));
            ExporDt.Columns.Add("病假時數", typeof(decimal));
            ExporDt.Columns.Add("事假時數", typeof(decimal));
            ExporDt.Columns.Add("補休時數", typeof(decimal));
            //ExporDt.Columns.Add("稅率", typeof(decimal));
            //ExporDt.Columns.Add("居留起始", typeof(string));
            //ExporDt.Columns.Add("居留到期", typeof(string));
            //ExporDt.Columns.Add("滿183天", typeof(string));
            //ExporDt.Columns.Add("郵件", typeof(string));
            //ExporDt.Columns.Add("備註", typeof(string));
            for (int i = 0; i < DT_42ta.Columns.Count; i++)
            {
                if (DT_42ta.Rows[0]["Fld" + (i + 1)].ToString().Trim() != "")
                {
                    ExporDt.Columns.Add(DT_42ta.Rows[0][i].ToString().Trim(), typeof(int));
                }
                else
                    break;
            }
            foreach (DataRow Row01 in DT_42td.Rows)
            {
                DataRow row = DT_Ot.Rows.Find(Row01["nobr"].ToString());
                DataRow row1 = DT_Abs.Rows.Find(Row01["nobr"].ToString());
                string AAD = Row01["nobr"].ToString();
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row01["dept"].ToString();
                aRow["部門名稱"] = Row01["d_name"].ToString();
                if (report_type == "0")
                {
                    aRow["員工編號"] = Row01["nobr"].ToString();
                    aRow["員工姓名"] = Row01["name_c"].ToString();
                    if (!Row01.IsNull("taxcnt")) aRow["扶養人數"] = int.Parse(Row01["taxcnt"].ToString());
                    if (!Row01.IsNull("helcnt")) aRow["健保眷口人數"] = int.Parse(Row01["helcnt"].ToString());
                }

                if (row != null)
                {
                    aRow["假日加班費-1"] = (row.IsNull("otamt1")) ? 0 : decimal.Round(decimal.Parse(row["otamt1"].ToString()), 0);
                    aRow["平日加班費-1"] = (row.IsNull("otamt2")) ? 0 : decimal.Round(decimal.Parse(row["otamt2"].ToString()), 0);
                    aRow["平日加班費-2"] = (row.IsNull("otamt3")) ? 0 : decimal.Round(decimal.Parse(row["otamt3"].ToString()), 0);
                    aRow["平日加班費"] = (row.IsNull("otamt3")) ? 0 : decimal.Round(decimal.Parse(row["otamt7"].ToString()), 0);
                    aRow["春節加班1.5"] = (row.IsNull("otamt4")) ? 0 : decimal.Round(decimal.Parse(row["otamt4"].ToString()), 0);
                    aRow["國定假日加班費"] = (row.IsNull("otamt5")) ? 0 : decimal.Round(decimal.Parse(row["otamt5"].ToString()), 0);
                    aRow["春節加班2.5"] = (row.IsNull("otamt6")) ? 0 : decimal.Round(decimal.Parse(row["otamt6"].ToString()), 0);
                    aRow["假日加班總時數(1.5)"] = (row.IsNull("othrs1")) ? 0 : decimal.Parse(row["othrs1"].ToString());
                    aRow["國定假日加班總時數(1.5)"] = (row.IsNull("othrs2")) ? 0 : decimal.Parse(row["othrs2"].ToString());
                    aRow["春節假日加班總時數(1.5)"] = (row.IsNull("othrs3")) ? 0 : decimal.Parse(row["othrs3"].ToString());
                    aRow["春節假日加班總時數(2.5)"] = (row.IsNull("othrs4")) ? 0 : decimal.Parse(row["othrs4"].ToString());
                    aRow["平日加班總時數(1.33)"] = (row.IsNull("othrs5")) ? 0 : decimal.Parse(row["othrs5"].ToString());
                    aRow["平日加班總時數(1.66)"] = (row.IsNull("othrs6")) ? 0 : decimal.Parse(row["othrs6"].ToString());
                    aRow["補休時數"] = (row.IsNull("otrest")) ? 0 : decimal.Parse(row["otrest"].ToString());
                }

                if (row1 != null)
                {
                    if (row1["h_name"].ToString().Trim() == "病假")
                        aRow["病假時數"] = decimal.Parse(row1["tol_hours"].ToString());
                    if (row1["h_name"].ToString().Trim() == "事假")
                        aRow["事假時數"] = decimal.Parse(row1["tol_hours"].ToString());
                }
               
                //aRow["稅率"] = decimal.Parse(Row01["taxrate"].ToString());
                //if (!Row01.IsNull("tax_date")) aRow["居留起始"] = DateTime.Parse(Row01["tax_date"].ToString());
                //if (!Row01.IsNull("tax_edate")) aRow["居留到期"] = DateTime.Parse(Row01["tax_edate"].ToString());
                //aRow["滿183天"] = Row01["stay183"].ToString();
                //aRow["郵件"] = Row01["email"].ToString();
                //aRow["備註"] = Row01["note"].ToString();
                for (int i = 0; i < DT_42ta.Columns.Count; i++)
                {
                    if (DT_42ta.Rows[0]["Fld" + (i + 1)].ToString() != "")
                    {
                        aRow[DT_42ta.Rows[0][i].ToString().Trim()] = int.Parse(Row01["Fld" + (i + 1)].ToString());
                    }
                    else
                        break;
                }
                ExporDt.Rows.Add(aRow);
            }

             if (report_type == "0")
             {
                 //JBModule.Data.CExcel.GenerateHtml("C:\\TEMP\\ZZ42_Report.xls", ExporDt, true);
                 JBModule.Data.CNPOI.RenderDataTableToExcel(ExporDt, "C:\\TEMP\\" + this.Name + ".xls");
                 System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
             }
             else
             {               
                 DataTable ExporDt1 = new DataTable();
                 ExporDt1 = ExporDt.Clone();
                 ExporDt.TableName = "ExporDt1";
                 ExporDt1.PrimaryKey = new DataColumn[] { ExporDt1.Columns["部門代碼"] };
                 foreach (DataRow Row in ExporDt.Rows)
                 {
                     DataRow row = ExporDt1.Rows.Find(Row["部門代碼"].ToString());
                     if (row != null)
                     {
                         if (!Row.IsNull("假日加班費-1")) row["假日加班費-1"] = int.Parse(row["假日加班費-1"].ToString()) + int.Parse(Row["假日加班費-1"].ToString());
                         if (!Row.IsNull("平日加班費-1"))row["平日加班費-1"] = int.Parse(row["平日加班費-1"].ToString()) + int.Parse(Row["平日加班費-1"].ToString());
                         if (!Row.IsNull("平日加班費-2")) row["平日加班費-2"] = int.Parse(row["平日加班費-2"].ToString()) + int.Parse(Row["平日加班費-2"].ToString());
                         if (!Row.IsNull("平日加班費")) row["平日加班費"] = int.Parse(row["平日加班費"].ToString()) + int.Parse(Row["平日加班費"].ToString());
                         if (!Row.IsNull("春節加班1.5")) row["春節加班1.5"] = int.Parse(row["春節加班1.5"].ToString()) + int.Parse(Row["春節加班1.5"].ToString());
                         if (!Row.IsNull("國定假日加班費")) row["國定假日加班費"] = int.Parse(row["國定假日加班費"].ToString()) + int.Parse(Row["國定假日加班費"].ToString());
                         if (!Row.IsNull("春節加班2.5")) row["春節加班2.5"] = int.Parse(row["春節加班2.5"].ToString()) + int.Parse(Row["春節加班2.5"].ToString());
                         if (!Row.IsNull("假日加班總時數(1.5)")) row["假日加班總時數(1.5)"] = decimal.Parse(row["假日加班總時數(1.5)"].ToString()) + decimal.Parse(Row["假日加班總時數(1.5)"].ToString());
                         if (!Row.IsNull("國定假日加班總時數(1.5)")) row["國定假日加班總時數(1.5)"] = decimal.Parse(row["國定假日加班總時數(1.5)"].ToString()) + decimal.Parse(Row["國定假日加班總時數(1.5)"].ToString());
                         if (!Row.IsNull("春節假日加班總時數(1.5)")) row["春節假日加班總時數(1.5)"] = decimal.Parse(row["春節假日加班總時數(1.5)"].ToString()) + decimal.Parse(Row["春節假日加班總時數(1.5)"].ToString());
                         if (!Row.IsNull("春節假日加班總時數(2.5)"))row["春節假日加班總時數(2.5)"] = decimal.Parse(row["春節假日加班總時數(2.5)"].ToString()) + decimal.Parse(Row["春節假日加班總時數(2.5)"].ToString());
                         if (!Row.IsNull("平日加班總時數(1.33)")) row["平日加班總時數(1.33)"] = decimal.Parse(row["平日加班總時數(1.33)"].ToString()) + decimal.Parse(Row["平日加班總時數(1.33)"].ToString());
                         if (!Row.IsNull("平日加班總時數(1.66)")) row["平日加班總時數(1.66)"] = decimal.Parse(row["平日加班總時數(1.66)"].ToString()) + decimal.Parse(Row["平日加班總時數(1.66)"].ToString());
                         if (!Row.IsNull("病假時數")) row["病假時數"] = decimal.Parse(row["病假時數"].ToString()) + decimal.Parse(Row["病假時數"].ToString());
                         if (!Row.IsNull("事假時數")) row["事假時數"] = decimal.Parse(row["事假時數"].ToString()) + decimal.Parse(Row["事假時數"].ToString());
                         if (!Row.IsNull("補休時數")) row["補休時數"] = decimal.Parse(row["補休時數"].ToString()) + decimal.Parse(Row["補休時數"].ToString());
                         row["發薪人數"] = int.Parse(row["發薪人數"].ToString()) + 1;
                         for (int i = 0; i < DT_42ta.Columns.Count; i++)
                         {
                             if (DT_42ta.Rows[0]["Fld" + (i + 1)].ToString() != "")
                             {
                                 row[DT_42ta.Rows[0][i].ToString().Trim()] =int.Parse(row[DT_42ta.Rows[0][i].ToString().Trim()].ToString()) + int.Parse(Row[DT_42ta.Rows[0][i].ToString().Trim()].ToString());                                 
                             } 
                             else
                                 break;
                         }
                     }
                     else
                     {
                         DataRow aRow = ExporDt1.NewRow();
                         aRow["部門代碼"] = Row["部門代碼"].ToString();
                         aRow["部門名稱"] = Row["部門名稱"].ToString();
                         aRow["假日加班費-1"] = (Row.IsNull("假日加班費-1")) ? 0 : int.Parse(Row["假日加班費-1"].ToString());
                         aRow["平日加班費-1"] = (Row.IsNull("平日加班費-1")) ? 0 : int.Parse(Row["平日加班費-1"].ToString());
                         aRow["平日加班費-2"] = (Row.IsNull("平日加班費-2")) ? 0 : int.Parse(Row["平日加班費-2"].ToString());
                         aRow["平日加班費"] = (Row.IsNull("平日加班費")) ? 0 : int.Parse(Row["平日加班費"].ToString());
                         aRow["春節加班1.5"] = (Row.IsNull("春節加班1.5")) ? 0 : int.Parse(Row["春節加班1.5"].ToString());
                         aRow["國定假日加班費"] = (Row.IsNull("國定假日加班費")) ? 0 : int.Parse(Row["國定假日加班費"].ToString());
                         aRow["春節加班2.5"] = (Row.IsNull("春節加班2.5")) ? 0 : int.Parse(Row["春節加班2.5"].ToString());
                         aRow["假日加班總時數(1.5)"] = (Row.IsNull("假日加班總時數(1.5)")) ? 0 : decimal.Parse(Row["假日加班總時數(1.5)"].ToString());
                         aRow["國定假日加班總時數(1.5)"] = (Row.IsNull("國定假日加班總時數(1.5)")) ? 0 : decimal.Parse(Row["國定假日加班總時數(1.5)"].ToString());
                         aRow["春節假日加班總時數(1.5)"] = (Row.IsNull("春節假日加班總時數(1.5)")) ? 0 : decimal.Parse(Row["春節假日加班總時數(1.5)"].ToString());
                         aRow["春節假日加班總時數(2.5)"] = (Row.IsNull("春節假日加班總時數(2.5)")) ? 0 : decimal.Parse(Row["春節假日加班總時數(2.5)"].ToString());
                         aRow["平日加班總時數(1.33)"] = (Row.IsNull("平日加班總時數(1.33)")) ? 0 : decimal.Parse(Row["平日加班總時數(1.33)"].ToString());
                         aRow["平日加班總時數(1.66)"] = (Row.IsNull("平日加班總時數(1.66)")) ? 0 : decimal.Parse(Row["平日加班總時數(1.66)"].ToString());
                         aRow["病假時數"] =(Row.IsNull("病假時數")) ?0: decimal.Parse(Row["病假時數"].ToString());
                         aRow["事假時數"] = (Row.IsNull("事假時數")) ? 0 : decimal.Parse(Row["事假時數"].ToString());
                         aRow["補休時數"] = (Row.IsNull("補休時數")) ? 0 : decimal.Parse(Row["補休時數"].ToString());
                         for (int i = 0; i < DT_42ta.Columns.Count; i++)
                         {
                             if (DT_42ta.Rows[0]["Fld" + (i + 1)].ToString() != "")
                             {
                                 aRow[DT_42ta.Rows[0][i].ToString().Trim()] = int.Parse(Row[DT_42ta.Rows[0][i].ToString().Trim()].ToString());
                             }
                             else
                                 break;
                         }
                         aRow["發薪人數"] = 1;
                         ExporDt1.Rows.Add(aRow);
                     }
                 }
                 JBModule.Data.CNPOI.RenderDataTableToExcel(ExporDt1, "C:\\TEMP\\" + this.Name + ".xls");
                 System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
             }
           
            
        }
    }
}
