/* ======================================================================================================
 * 功能名稱：薪資總表
 * 功能代號：ZZ4A
 * 功能路徑：報表列印 > 薪資 > 薪資總表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ4A_Report2.cs
 * 功能用途：
 *  用於產出薪資總表（會計轉帳格式）
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
    public partial class ZZ4A_Report2 : JBControls.JBForm
    {
        SalDataSet ds = new SalDataSet();
        string type_data, dept_type, nobr_b, nobr_e, dept_b, dept_e, depts_b, depts_e, comp_b, comp_e, year, month, seq, date_b;
        string username, workadr, note, yymm, reporttype, repo_name, adate, emp_b, emp_e, comp_name, work_b, work_e, seqmerge;
        bool exportexcel;
        public ZZ4A_Report2(string typedata, string depttype, string nobrb, string nobre, string deptb, string depte, string deptsb, string deptse
            , string compb, string compe, string empb, string empe, string workb, string worke, string _year, string _month, string _seq, string _seqmerge
            , string dateb, string _username, string _workadr, string _note, string _reporttype, string reponame, bool _exportexcel, string compname)
        {
            InitializeComponent();
            type_data = typedata; nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; depts_b = deptsb;
            depts_e = deptse; comp_b = compb; comp_e = compe; year = _year; month = _month; seq = _seq; seqmerge = _seqmerge; date_b = dateb;
            username = _username; workadr = _workadr; exportexcel = _exportexcel;
            note = _note; dept_type = depttype; yymm = year + month; reporttype = _reporttype; repo_name = reponame;
            emp_b = empb; emp_e = empe; comp_name = compname; work_b = workb; work_e = worke;
        }

        private void ZZ4A_Report2_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select b.nobr,a.name_c,a.name_e,b.di,b.comp,e.compname,b.adate,a.count_ma,e.account ";
                sqlCmd += ",c.d_no_disp as dept,c.d_name,c.i_code,c.d_code ";
                sqlCmd += " from base a inner join basetts b on a.nobr = b.nobr ";
                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate ", date_b);

                //增加【公司】下拉式選單控制項條件 - Added By Daniel Chih - 2021/01/13
                sqlCmd += string.Format(@" and b.comp between '{0}' and '{1}'", comp_b, comp_e);

                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);

                sqlCmd += " left outer join depts c on b.depts=c.d_no" ;
                sqlCmd += " left outer join comp e on b.comp=e.comp";
                sqlCmd += " where 1=1 ";

                sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", depts_b, depts_e);

                sqlCmd += type_data;
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                //費用部門代碼
                DataTable rq_expdept = SqlConn.GetDataTable("select d_no,d_no_disp,d_name from exp_dept");
                rq_expdept.PrimaryKey = new DataColumn[] { rq_expdept.Columns["d_no"] };


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
                sqlCmd2 += " and sal_code!='R01' and sal_code<> ''";
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

                rq_waged.Columns.Add("dept", typeof(string));
                rq_waged.Columns.Add("d_name", typeof(string));               
                rq_waged.Columns.Add("di", typeof(string));                
                rq_waged.Columns.Add("flag", typeof(string));
                rq_waged.Columns.Add("acc_tr", typeof(string));
                rq_waged.Columns.Add("salattr", typeof(string));
                rq_waged.Columns.Add("acccd", typeof(string));
                rq_waged.Columns.Add("accname", typeof(string));
                rq_waged.Columns.Add("exp_name", typeof(string));
                rq_waged.Columns.Add("code_d", typeof(string));
                rq_waged.Columns.Add("code_c", typeof(string));
                rq_waged.Columns.Add("exp_dept", typeof(string));
                rq_waged.Columns.Add("accexp_dept", typeof(string));
                rq_waged.Columns.Add("acccd_disp", typeof(string));

                string sqlCmd3 = "select a.sal_code,a.sal_code_disp,c.accname,b.flag,b.salattr,c.acc_tr,c.acccd,c.acccd_disp ";
                sqlCmd3 += " from salcode a inner join salattr b on a.sal_attr = b.salattr ";
                sqlCmd3 += " inner join acccd c on a.acccd = c.acccd ";
                sqlCmd3 += " where 1 = 1 ";
                DataTable rq_salcode = SqlConn.GetDataTable(sqlCmd3);
                rq_salcode.PrimaryKey = new DataColumn[] { rq_salcode.Columns["sal_code"] };

                string sqlCmd4 = "select a.acccd,a.d_no,a.code_d,a.code_c,b.d_no_disp as accexp_dept,b.d_name";
                sqlCmd4 += " from accsal a inner join exp_dept b on a.d_no=b.d_no";
                sqlCmd4 += " where 1 = 1 ";
                DataTable rq_accsal = SqlConn.GetDataTable(sqlCmd4);
                rq_accsal.PrimaryKey = new DataColumn[] { rq_accsal.Columns["acccd"], rq_accsal.Columns["d_no"] };

                foreach (DataRow Row in rq_waged.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    DataRow row1 = rq_wage.Rows.Find(Row["nobr"].ToString());
                    DataRow row2 = rq_salcode.Rows.Find(Row["sal_code"].ToString());

                    if (row != null && row1 != null)
                    {
                        string code_cd = "";
                        if (row2 != null)
                        {
                            Row["sal_code"] = row2["sal_code_disp"].ToString();
                            Row["flag"] = row2["flag"].ToString();
                            Row["acc_tr"] = row2["acc_tr"].ToString();
                            Row["salattr"] = row2["salattr"].ToString();
                            Row["acccd"] = row2["acccd"].ToString();
                            Row["accname"] = row2["accname"].ToString();
                            Row["acccd_disp"] = row2["acccd_disp"].ToString();
                        }

                        DataRow row3 = rq_expdept.Rows.Find(row["i_code"].ToString());
                        DataRow row4 = rq_expdept.Rows.Find(row["d_code"].ToString());
                        string icode = ""; string icodename = "";
                        string dcode = ""; string dcodename = "";

                        if (row3 != null)
                        {
                            icode = row3["d_no_disp"].ToString();
                            icodename = row3["d_name"].ToString();
                        }
                        if (row4 != null)
                        {
                            dcode = row4["d_no_disp"].ToString();
                            dcodename = row4["d_name"].ToString();
                        }
                        Row["di"] = row["di"].ToString();
                        Row["dept"] = row["dept"].ToString();
                        Row["d_name"] = row["d_name"].ToString();
                        if (Row["di"].ToString().Trim() == "I")
                        {
                            Row["exp_dept"] = icode;
                            Row["exp_name"] = icodename;
                            code_cd = row["i_code"].ToString();
                        }
                        else if (Row["di"].ToString().Trim() == "D")
                        {
                            Row["exp_dept"] = dcode;
                            Row["exp_name"] = dcodename;
                            code_cd = row["i_code"].ToString();
                        }
                        object[] _value2 = new object[2];
                        _value2[0] = Row["acccd"].ToString();
                        _value2[1] = code_cd;
                        DataRow row5 = rq_accsal.Rows.Find(_value2);
                        if (row5 != null)
                        {
                            Row["acccd"] = Row["acccd_disp"].ToString();
                            Row["code_d"] = row5["code_d"].ToString();
                            Row["code_c"] = row5["code_c"].ToString();
                            if (Row["flag"].ToString().Trim() == "-")
                                Row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString())) * (-1);
                            else
                                Row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));
                        }
                        else
                            Row.Delete();
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

                DataColumn[] _key = new DataColumn[2];
                _key[0] = ds.Tables["zz4a9"].Columns["acccd"];
                _key[1] = ds.Tables["zz4a9"].Columns["exp_dept"];
                ds.Tables["zz4a9"].PrimaryKey = _key;
                DataRow[] SRow = rq_waged.Select("", "acccd,exp_dept asc");
                foreach (DataRow Row in SRow)
                {
                    object[] _value = new object[2];
                    _value[0] = Row["acccd"].ToString();
                    _value[1] = Row["exp_dept"].ToString();
                    DataRow row = ds.Tables["zz4a9"].Rows.Find(_value);
                    if (row != null)
                    {
                        row["amt"] = int.Parse(row["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                    }
                    else
                    {
                        DataRow aRow = ds.Tables["zz4a9"].NewRow();
                        aRow["acccd"] = Row["acccd"].ToString();
                        aRow["accname"] = Row["accname"].ToString();
                        aRow["type"] = (Row["flag"].ToString().Trim() == "-") ? "減項" : "加項";
                        aRow["amt"] = int.Parse(Row["amt"].ToString());
                        aRow["exp_dept"] = Row["exp_dept"].ToString();
                        aRow["exp_name"] = Row["exp_name"].ToString();
                        aRow["code_d"] = Row["code_d"].ToString();
                        aRow["code_c"] = Row["code_c"].ToString();
                        ds.Tables["zz4a9"].Rows.Add(aRow);
                    }
                }

                if (exportexcel)
                {
                    Export(ds.Tables["zz4a9"]);
                    this.Close();
                }
                else
                {
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "SalReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "SalReport", "*.rdlc");
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4a9.rdlc";
                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YY", year) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("MM", month) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("SEQ", seq) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4a9", ds.Tables["zz4a9"]));
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
            ExporDt.Columns.Add("項目", typeof(string));
            ExporDt.Columns.Add("項目類別", typeof(string));
            ExporDt.Columns.Add("費用歸屬", typeof(string));
            ExporDt.Columns.Add("金額", typeof(int));
            ExporDt.Columns.Add("借方科目", typeof(string));
            ExporDt.Columns.Add("貸方科目", typeof(string));           
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["項目"] = Row01["accname"].ToString();
                aRow["項目類別"] = Row01["type"].ToString();               
                aRow["費用歸屬"] = Row01["exp_name"].ToString();
                aRow["金額"] = int.Parse(Row01["amt"].ToString());
                aRow["借方科目"] = Row01["code_d"].ToString();
                aRow["貸方科目"] = Row01["code_c"].ToString();
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
