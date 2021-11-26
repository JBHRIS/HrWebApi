/* ======================================================================================================
 * 功能名稱：薪資傳票
 * 功能代號：ZZ4P
 * 功能路徑：報表列印 > 薪資 > 薪資傳票
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ4P.cs
 * 功能用途：
 *  
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/04/14    Daniel Chih    Ver 1.0.01     1. 修正SQL語法中錯誤的查詢語句
 * 2021/04/19    Daniel Chih    Ver 1.0.02     1. 增加成本別的欄位內容
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/04/19
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
    public partial class ZZ4P_Report : JBControls.JBForm
    {
        SalDataSet ds = new SalDataSet();
        string nobr_b, nobr_e, dept_b, dept_e, depts_b, depts_e, date_e, seq, yymm, typedata, reporttype, note, workadr, depttype, mmb, comp_name;
        string username, CompId,emp_b,emp_e,comp_b, comp_e;
        bool exportexcel, mangsuper;
        int allcash = 0;
        public ZZ4P_Report(string nobrb, string nobre,string compb, string compe, string deptb, string depte, string deptsb, string deptse,string empb,string empe, string datee, string seqb, string yy, string mm, string _typedata, string _reporttype, string _note, string _workadr, string _depttype, string _username, bool _exportexcel, string compname, string _CompId)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; seq = seqb; yymm =yy+mm ; depts_b = deptsb;
            depts_e = deptse; date_e = datee; seq = seqb; typedata = _typedata; reporttype = _reporttype;
            note = _note; workadr = _workadr; depttype = _depttype; exportexcel = _exportexcel;
            mmb = mm; username = _username; comp_name = compname; CompId = _CompId; emp_b = empb; emp_e = empe;
            comp_b = compb; comp_e = compe;
        }

        private void ZZ4P_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
               string sqlCmd = "select a.nobr,a.name_c,a.name_e,b.di,b.depts as deptscost,b.empcd,e.empdescr";
                if (depttype == "1")
                    sqlCmd += ",c.d_no_disp as dept,c.d_name,'' as d_ename,c.i_code,c.d_code,c.subs";
                else
                    sqlCmd += ",c.d_no_disp as dept,c.d_name,c.d_ename,'' as i_code,'' as d_code,'' as subs";
                sqlCmd += " from base a,basetts b";
                if (depttype=="1")
                    sqlCmd += " left outer join depts c on b.dept=c.d_no";
                else
                    sqlCmd += " left outer join dept c on b.dept=c.d_no";
                sqlCmd += " left outer join comp d on b.comp=d.comp";
                sqlCmd += " left outer join empcd e on b.empcd=e.empcd";
                sqlCmd += " where a.nobr=b.nobr";
                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);
                if (depttype == "1")
                    sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'",depts_b ,depts_e );               
                else
                    sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);               
                sqlCmd += typedata;
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                string sqlCmd1 = "select a.nobr,a.yymm,a.seq,a.cash,a.account_no,a.saladr,a.comp,d.compname,d.account";                
                sqlCmd1 += "  from wage a";
                sqlCmd1 += " left outer join comp d on a.comp=d.comp";
                //sqlCmd1 += " left outer join datagroup e on a.saladr=e.datagroup";
                sqlCmd1 += string.Format(@" where a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd1 += string.Format(@" and a.comp between '{0}' and '{1}'", comp_b, comp_e);
                sqlCmd1 += string.Format(@" and a.yymm = '{0}' and seq ='{1}'", yymm, seq);
                sqlCmd1 +=workadr;
                DataTable rq_wage = SqlConn.GetDataTable(sqlCmd1);
                DataColumn[] _key = new DataColumn[3];
                _key[0] = rq_wage.Columns["nobr"];
                _key[1] = rq_wage.Columns["yymm"];
                _key[2] = rq_wage.Columns["seq"];
                rq_wage.PrimaryKey = _key;

                string sqlCmd2 = "select nobr,yymm,seq,sal_code,amt from waged";
                sqlCmd2 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd2 += string.Format(@" and yymm = '{0}' and seq ='{1}'", yymm, seq);               
                sqlCmd2 += " and amt<>10 order by nobr,sal_code";
                DataTable rq_waged = SqlConn.GetDataTable(sqlCmd2);
                rq_waged.Columns.Add("saladr", typeof(string));
                rq_waged.Columns.Add("comp", typeof(string));
                rq_waged.Columns.Add("accname_o", typeof(string));
                rq_waged.Columns.Add("compname", typeof(string));
                rq_waged.Columns.Add("account", typeof(string));
                rq_waged.Columns.Add("deptscost", typeof(string));
                rq_waged.Columns.Add("dept", typeof(string));
                rq_waged.Columns.Add("depts", typeof(string));
                rq_waged.Columns.Add("d_name", typeof(string));
                rq_waged.Columns.Add("d_ename", typeof(string));
                rq_waged.Columns.Add("name_c", typeof(string));
                rq_waged.Columns.Add("name_e", typeof(string));
                rq_waged.Columns.Add("di", typeof(string));
                rq_waged.Columns.Add("sal_name", typeof(string));
                rq_waged.Columns.Add("flag", typeof(string));
                rq_waged.Columns.Add("acc_tr", typeof(string));
                rq_waged.Columns.Add("cash", typeof(bool));
                rq_waged.Columns.Add("type", typeof(string));
                rq_waged.Columns.Add("sal_attr", typeof(string));
                rq_waged.Columns.Add("acccd_disp", typeof(string));
                rq_waged.Columns.Add("acccd", typeof(string));
                rq_waged.Columns.Add("accname", typeof(string));
                rq_waged.Columns.Add("account_no", typeof(string));               
                rq_waged.Columns.Add("accode", typeof(string));
                rq_waged.Columns.Add("accode_c", typeof(string));
                rq_waged.Columns.Add("accode_d", typeof(string));
                rq_waged.Columns.Add("o_amt", typeof(decimal));
                rq_waged.Columns.Add("di_code", typeof(string));
                rq_waged.Columns.Add("dbcr", typeof(string));   //1借方,2貸方               
                rq_waged.Columns.Add("disp_costname", typeof(bool)); //成本名稱不顯示
                rq_waged.Columns.Add("meno", typeof(string));   //摘要
                rq_waged.Columns.Add("subs", typeof(string));
                rq_waged.Columns.Add("sal_code_disp", typeof(string));

                //薪資代碼
                string sqlCmd3 = "select a.sal_code,a.sal_code_disp,a.sal_name,a.sal_attr,b.flag,b.type,a.acccd,c.acccr,c.accdr,c.acc_tr,c.accname,c.acccd_disp";
                sqlCmd3 += " from salcode a,salattr b,acccd c";
                sqlCmd3 += " where a.sal_attr=b.salattr and a.acccd=c.acccd";               
                DataTable rq_salcode = SqlConn.GetDataTable(sqlCmd3);
                rq_salcode.PrimaryKey = new DataColumn[] { rq_salcode.Columns["sal_code"] };                

                //成本別
                string sqlCmd3a = "select a.d_no,b.costtypename,a.acccd,c.acccd_disp,c.acccr,c.accdr,c.acc_tr,a.code_d,a.code_c ";
                sqlCmd3a += " from accsal a,costtype b,acccd c ";
                sqlCmd3a += " where a.d_no=b.costtypecode and a.acccd=c.acccd";
                DataTable rq_accsal = SqlConn.GetDataTable(sqlCmd3a);
                rq_accsal.PrimaryKey = new DataColumn[] { rq_accsal.Columns["d_no"], rq_accsal.Columns["acccd"] };

                //個人分攤
                string sqlCmd4 = "select  a.nobr,a.depts as deptscost,b.d_no,b.d_no_disp as depts,b.d_name,b.subs,b.i_code,b.d_code,rate";
                sqlCmd4 += " from cost a";
                sqlCmd4 += " left outer join depts b on a.depts=b.d_no";
                sqlCmd4 += string.Format(@" where '{0}' between a.cadate and a.cddate", date_e);
                sqlCmd4 += string.Format(@" and a.nobr between  '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd4 += " order by a.nobr,a.depts";
                DataTable rq_cost = SqlConn.GetDataTable(sqlCmd4);

                //成本部門
                DataTable rq_depts = SqlConn.GetDataTable("select a.d_no,a.d_no_disp,a.i_code, b.costtypename as i_name ,a.d_code, c.costtypename as d_name from depts a left join dbo.costtype b on a.i_code = b.costtypecode left join dbo.costtype c on a.d_code = c.costtypecode");
                rq_depts.PrimaryKey = new DataColumn[] { rq_depts.Columns["d_no"] };

                //成本別代碼
                DataTable rq_costtype = SqlConn.GetDataTable("select costtypecode,costtypename from costtype order by costtypecode ");
                rq_costtype.PrimaryKey = new DataColumn[] { rq_costtype.Columns["costtypecode"] };

                JBHR.Reports.SalForm.ZZ4PClass.Get_Waged(rq_waged, rq_wage, rq_base, rq_salcode, rq_accsal, comp_name);
                if (rq_waged.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                //公司別總傳票
                DataTable rq_compacc = new DataTable();
                rq_compacc.Columns.Add("comp", typeof(string));
                rq_compacc.Columns.Add("accode_d", typeof(string)); //借方
                rq_compacc.Columns.Add("accode_c", typeof(string)); //貸方
                rq_compacc.Columns.Add("accname", typeof(string));
                rq_compacc.PrimaryKey = new DataColumn[] { rq_compacc.Columns["comp"], rq_compacc.Columns["accode_d"], rq_compacc.Columns["accode_c"] };

                //費用分攤
                DataTable rq_costamt = new DataTable();                
                rq_costamt.Columns.Add("comp", typeof(string));
                rq_costamt.Columns.Add("compname", typeof(string));
                rq_costamt.Columns.Add("nobr", typeof(string));
                rq_costamt.Columns.Add("name_c", typeof(string));
                rq_costamt.Columns.Add("di", typeof(string));
                rq_costamt.Columns.Add("depts", typeof(string));
                rq_costamt.Columns.Add("ds_name", typeof(string));
                //rq_costamt.Columns.Add("acccd", typeof(string));
                rq_costamt.Columns.Add("accode", typeof(string));
                rq_costamt.Columns.Add("accname", typeof(string));
                rq_costamt.Columns.Add("dbcr", typeof(string)); //1借方,2貸方
                rq_costamt.Columns.Add("accode_d", typeof(string)); //借方
                rq_costamt.Columns.Add("accode_c", typeof(string)); //貸方
                rq_costamt.Columns.Add("sal_code", typeof(string));
                rq_costamt.Columns.Add("sal_name", typeof(string));
                rq_costamt.Columns.Add("costtype", typeof(string));
                rq_costamt.Columns.Add("costname", typeof(string));
                rq_costamt.Columns.Add("disp_costname", typeof(bool));  //成本名稱不顯示
                rq_costamt.Columns.Add("rate", typeof(decimal));
                rq_costamt.Columns.Add("amt", typeof(decimal));
                rq_costamt.Columns.Add("o_amt", typeof(decimal));
                //rq_costamt.Columns.Add("entity1", typeof(string));
                //rq_costamt.Columns.Add("entity2", typeof(string));
                //rq_costamt.Columns.Add("LegalPerson", typeof(string));
                //rq_costamt.Columns.Add("Currency", typeof(string));
                rq_costamt.Columns.Add("flag", typeof(string));
                rq_costamt.Columns.Add("subs", typeof(string));
                rq_costamt.Columns.Add("meno", typeof(string));
                rq_costamt.Columns.Add("empcd", typeof(string));
                rq_costamt.Columns.Add("sal_code_disp", typeof(string));
                JBHR.Reports.SalForm.ZZ4PClass.Get_CostAmt(rq_costamt, rq_waged, rq_cost, rq_costtype, rq_accsal, rq_depts,rq_base, seq);
                
                ////匯出Excel傳票分攤明細資料
                //if (exportexcel2)
                //{
                //    JBHR.Reports.SalForm.ZZ4PClass.ExcelCostAmt(rq_costamt, rq_base);
                //    this.Close();
                //    return;
                //}

                //借方傳票
                DataTable rq_dbcr = new DataTable();
                rq_dbcr.Columns.Add("type", typeof(string));    //1.薪資,2.公司負擔,3.年獎預估
                rq_dbcr.Columns.Add("comp", typeof(string));
                rq_dbcr.Columns.Add("compname", typeof(string));
                rq_dbcr.Columns.Add("depts", typeof(string));
                rq_dbcr.Columns.Add("ds_name", typeof(string));
                rq_dbcr.Columns.Add("di", typeof(string));
                rq_dbcr.Columns.Add("accode", typeof(string));
                rq_dbcr.Columns.Add("accname", typeof(string));
                rq_dbcr.Columns.Add("meno", typeof(string));
                rq_dbcr.Columns.Add("dbcr", typeof(string)); //1借方,2貸方
                rq_dbcr.Columns.Add("amt", typeof(decimal));
                //rq_dbcr.Columns.Add("supplier", typeof(string));
                //rq_dbcr.Columns.Add("entity1", typeof(string));
                //rq_dbcr.Columns.Add("entity2", typeof(string));
                //rq_dbcr.Columns.Add("LegalPerson", typeof(string));
                //rq_dbcr.Columns.Add("Currency", typeof(string));                

                 DataTable rq_expcost = new DataTable();
                rq_expcost = rq_costamt.Clone();

                //公司別
                DataTable rq_compgrp = new DataTable();
                rq_compgrp.Columns.Add("comp",typeof(string));                
                rq_compgrp.PrimaryKey=new DataColumn[] {rq_compgrp.Columns["comp"]};

                //薪資總額傳票
                DataTable rq_sumamt = new DataTable();
                rq_sumamt = rq_dbcr.Clone();

                
                if (reporttype == "1")
                    JBHR.Reports.SalForm.ZZ4PClass.Get_Dbcr(rq_dbcr, rq_sumamt, rq_costamt, rq_compacc, rq_expcost,  yymm.Substring(0, 4), yymm.Substring(4, 2), seq);
                else
                    JBHR.Reports.SalForm.ZZ4PClass.Get_Dbcr1(rq_dbcr, rq_sumamt, rq_compgrp, rq_costamt, rq_compacc, rq_expcost, yymm.Substring(0, 4), yymm.Substring(4, 2), seq);

                 if (rq_sumamt.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                //產生傳票資料
                JBHR.Reports.SalForm.ZZ4PClass.Get_ZZ4p(ds.Tables["zz4p"], rq_dbcr, rq_sumamt);

                
                rq_base = null; rq_sumamt = null; rq_expcost = null; rq_compgrp = null;
                rq_dbcr = null; rq_salcode = null; rq_costamt = null; rq_wage = null;
                rq_costtype = null; rq_waged = null; rq_depts = null; rq_accsal = null;
                rq_cost = null;
                if (ds.Tables["zz4p"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                if (exportexcel)
                {
                    JBHR.Reports.SalForm.ZZ4PClass.ExPort(ds.Tables["zz4p"],this.Name,reporttype);
                    this.Close();
                }
                else
                {
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "SalReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "SalReport", "*.rdlc");
                    if (reporttype == "2")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4p1.rdlc";
                    else 
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4p.rdlc";
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYMM", yymm) });                   
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("UserName", username) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Note", note) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4p", ds.Tables["zz4p"]));
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
