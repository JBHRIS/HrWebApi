/* ======================================================================================================
 * 功能名稱：屆退人員明細表
 * 功能代號：ZZ4K
 * 功能路徑：報表列印 > 薪資 > 屆退人員明細表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ4K_Report.cs
 * 功能用途：
 *  
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/02/04    Daniel Chih    Ver 1.0.01     1. 移除 Sal_Code 的舊制判斷
 * 2021/02/08    Daniel Chih    Ver 1.0.02     1. 重新加入 Sal_Code 的舊制判斷
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/02/08
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
    public partial class ZZ4K_Report : JBControls.JBForm
    {
        SalDataSet ds = new SalDataSet();
        string nobr_b, nobr_e, dept_b, dept_e, date_b, yyb, mmb, seq_b, yymm_b, yye, mme, seq_e, yymm_e;
        string typedata, workadr, counttype, comp_name, CompId,emp_b,emp_e;
        decimal inyear, reyear;
        bool exportexcel;
        public ZZ4K_Report(string nobrb, string nobre, string deptb, string depte,string empb,string empe, string dateb, string _yyb, string _mmb, string _seqb, string _yye, string _mme, string _seqe, string _typedata, string _workadr, string _counttype, decimal _inyear, decimal _reyear, bool _exportexcel, string compname, string _CompId)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; typedata = _typedata;
            workadr = _workadr; inyear = _inyear; reyear = _reyear; exportexcel = _exportexcel; date_b = dateb;
            yymm_b = _yyb + _mmb; seq_b = _seqb; yymm_e = _yye + _mme; seq_e = _seqe; counttype = _counttype;
            comp_name = compname; CompId = _CompId; emp_b = empb; emp_e = empe;
        }

        private void ZZ4K_Report_Load(object sender, EventArgs e)
        {
            try
            {
                int str_year = DateTime.Parse(date_b).Year + 1;
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select a.nobr,a.name_c,a.name_e,c.d_no_disp as dept,c.d_name,c.d_ename,b.di,b.indt,b.stdt,b.stindt,a.birdt,b.retchoo";
                sqlCmd += string.Format(@",dbo.GETTOTALYEARS1(a.nobr,'{0}') as wk_yrsall", date_b);
                //sqlCmd += string.Format(@",dbo.GETTOTALYEARS1(a.nobr,'{0}') as wk_yrs1", "2005/7/1");
                sqlCmd += ",case when b.retchoo='2' then  dbo.GETTOTALYEARS(a.nobr,b.retdate)";
                sqlCmd += string.Format(@" else dbo.GETTOTALYEARS(a.nobr,'{0}') end as wk_yrs", date_b);
                sqlCmd += ",case when b.retchoo='2' then dbo.GETTOTALYEARS(a.nobr,b.retdate)";
                sqlCmd += string.Format(@" else dbo.GETTOTALYEARS(a.nobr,'{0}') end as wk_yrs1", "2005/7/1");
                sqlCmd += string.Format(@",dbo.GETTOTALYEARS(a.nobr,'{0}') as ckwk_yrs", date_b);
                sqlCmd += " from base a,basetts b,dept c";
                sqlCmd += " where a.nobr=b.nobr and b.dept=c.d_no";
                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_b);
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);
                if (typedata == "1")
                {
                    //sqlCmd += string.Format(@" and {0}-year(a.birdt) >={1}", str_year, reyear);
                    //sqlCmd += string.Format(@" and {0}-year(b.indt) >={1}", str_year, inyear);
                    sqlCmd += string.Format(@" and datediff(day,a.birdt,'{0}')/365.24  >={1}", date_b, reyear);
                    sqlCmd += string.Format(@" and dbo.GETTOTALYEARS1(a.nobr,'{0}')  >={1}", date_b, inyear);
                }
                else if (typedata == "2")
                {
                    //sqlCmd += string.Format(@" and {0}-year(a.birdt) >={1}", str_year, reyear);
                    sqlCmd += string.Format(@" and datediff(day,a.birdt,'{0}')/365.24  >={1}", date_b, reyear);
                }
                else
                {
                    //sqlCmd += string.Format(@" and {0}-year(b.indt) >={1}", str_year, inyear);
                    sqlCmd += string.Format(@" and dbo.GETTOTALYEARS1(a.nobr,'{0}')  >={1}", date_b, inyear);
                }
                sqlCmd += " and b.ttscode in ('1','4','6') and b.retchoo <>'0'";               
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                string sqlCmd1 = "select nobr,yymm,seq from wage";
                sqlCmd1 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd1 += string.Format(@" and yymm between '{0}' and '{1}'", yymm_b, yymm_e);
                sqlCmd1 += string.Format(@" and seq between '{0}' and '{1}'", seq_b, seq_e);
                sqlCmd1 += workadr;
                DataTable rq_wage = SqlConn.GetDataTable(sqlCmd1);
                DataColumn[] _key = new DataColumn[3];
                _key[0] = rq_wage.Columns["nobr"];
                _key[1] = rq_wage.Columns["yymm"];
                _key[2] = rq_wage.Columns["seq"];
                rq_wage.PrimaryKey = _key;

                DataTable rq_sys4 = SqlConn.GetDataTable("select retsalcode from u_sys4 where comp='" + CompId + "'");
                string retsalcode = (rq_sys4.Rows.Count > 0) ? rq_sys4.Rows[0]["retsalcode"].ToString() : "";
                string sqlCmd2 = "select nobr,yymm,seq,sal_code,amt from waged";
                sqlCmd2 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd2 += string.Format(@" and yymm between '{0}' and '{1}'", yymm_b, yymm_e);
                sqlCmd2 += string.Format(@" and seq between '{0}' and '{1}'", seq_b, seq_e);
                //sqlCmd2 += " and sal_code not in ('D02','D04','D06')";
                sqlCmd2 += string.Format(@" and sal_code <> '{0}'", retsalcode);
                sqlCmd2 += " order by nobr,yymm";
                DataTable rq_waged = SqlConn.GetDataTable(sqlCmd2);
                rq_waged.Columns.Add("flag", typeof(string));
                DataTable rq_wageda = new DataTable();
                rq_wageda.Columns.Add("nobr", typeof(string));
                rq_wageda.Columns.Add("name_c", typeof(string));
                rq_wageda.Columns.Add("name_e", typeof(string));
                rq_wageda.Columns.Add("dept", typeof(string));
                rq_wageda.Columns.Add("d_name", typeof(string));
                rq_wageda.Columns.Add("d_ename", typeof(string));
                rq_wageda.Columns.Add("retchoo", typeof(string));
                rq_wageda.Columns.Add("yymm", typeof(string));
                rq_wageda.Columns.Add("amt", typeof(int));
                rq_wageda.Columns.Add("y_year", typeof(decimal));
                rq_wageda.Columns.Add("i_year", typeof(decimal));
                rq_wageda.Columns.Add("i_base", typeof(decimal));
                rq_wageda.Columns.Add("mondays", typeof(decimal));
                rq_wageda.Columns.Add("allmon", typeof(bool));
                rq_wageda.Columns.Add("wk_yrs", typeof(decimal));
                rq_wageda.PrimaryKey = new DataColumn[] { rq_wageda.Columns["nobr"],rq_wageda.Columns["yymm"] };                

                string sqlCmd3 = "select a.sal_code,b.flag from salcode a,salattr b";
                sqlCmd3 += string.Format(@" where a.sal_attr=b.salattr and a.sal_code <> '{0}'", retsalcode);
                //sqlCmd3 += " and a.sal_code not in ('D02','D04','D06') and  a.sal_attr <='L'";

                ////移除舊制的判斷 - Modified By Daniel Chih - 2020/02/04
                //sqlCmd3 += " and a.sal_attr <='L'";

                //重新加入舊制的判斷 - Modified By Daniel Chih - 2020/02/08
                sqlCmd3 += " and a.oldretire='1' and  a.sal_attr <='L'";

                DataTable rq_salcode = SqlConn.GetDataTable(sqlCmd3);
                rq_salcode.PrimaryKey = new DataColumn[] { rq_salcode.Columns["sal_code"] };

                ////基本薪
                //string sqlCmd5 = "select * from salbasd ";
                //sqlCmd5 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                //sqlCmd5 += string.Format(@" and '{0}' between adate and ddate", date_b);
                //sqlCmd5 += " and (sal_code ='A01' or sal_code='G01')";
                //DataTable rq_sala = SqlConn.GetDataTable(sqlCmd5);
                DataTable rq_sal = new DataTable();
                rq_sal.Columns.Add("nobr", typeof(string));
                rq_sal.Columns.Add("amt", typeof(string));
                rq_sal.PrimaryKey = new DataColumn[] { rq_sal.Columns["nobr"] };

                //foreach (DataRow Row in rq_sala.Rows)
                //{
                //    DataRow row = rq_sal.Rows.Find(Row["nobr"].ToString());
                //    DataRow row1 = rq_base.Rows.Find(Row["nobr"].ToString());
                //    if (row1 != null)
                //    {
                //        if (row != null)
                //        {
                //            row["amt"] = int.Parse(row["amt"].ToString()) + JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));
                //        }
                //        else
                //        {
                //            DataRow aRow = rq_sal.NewRow();
                //            aRow["nobr"] = Row["nobr"].ToString();
                //            aRow["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));
                //            rq_sal.Rows.Add(aRow);
                //        }
                //    }
                //}

                ////計算停薪留職
                //string sqlCmd4 = "select nobr,sum(datediff(day,stdt,stindt)) as day from basetts";
                //sqlCmd4 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                //sqlCmd4 += string.Format(@" and dept between '{0}' and '{1}'", dept_b, dept_e);
                //sqlCmd4 += " and stdt is not null and stindt is not null and ttscode='4'";
                //sqlCmd4 += " group by nobr";
                //DataTable rq_day = SqlConn.GetDataTable(sqlCmd4);
                //rq_day.PrimaryKey = new DataColumn[] { rq_day.Columns["nobr"] };

                DataTable rq_yymm = new DataTable();
                rq_yymm.Columns.Add("yymm");
                rq_yymm.PrimaryKey = new DataColumn[] { rq_yymm.Columns["yymm"] };
                int _n = 0;
                foreach (DataRow Row in rq_waged.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    object[] _value = new object[3];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = Row["yymm"].ToString();
                    _value[2] = Row["seq"].ToString();
                    DataRow row1 = rq_wage.Rows.Find(_value);
                    DataRow row2 = rq_salcode.Rows.Find(Row["sal_code"].ToString());
                    if (row != null && row1 != null && row2!=null)
                    {
                        string _indt = "";                        
                        //DataRow row3 = rq_day.Rows.Find(Row["nobr"].ToString());                        
                        if (row2 != null)
                            Row["flag"] = row2["flag"].ToString();
                        //if (row3 != null)
                        //    _indt = DateTime.Parse(row["indt"].ToString()).AddDays(int.Parse(row3["day"].ToString())).ToString("yyyy/MM/dd");
                        //else
                        //    _indt = DateTime.Parse(row["indt"].ToString()).ToString("yyyy/MM/dd");
                       
                        if (Row["flag"].ToString().Trim() == "-")
                            Row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString())) * (-1);
                        else
                            Row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));
                        //decimal _inyear = decimal.Round((((TimeSpan)(DateTime.Parse(date_b) - DateTime.Parse(_indt))).Days) / Convert.ToDecimal(365.24), 2);
                        if (row.IsNull("wk_yrs"))
                            row["wk_yrs"] = 0;
                        else if (decimal.Parse(row["wk_yrs"].ToString()) < 0)
                            row["wk_yrs"] = 0;

                        if (row.IsNull("wk_yrsall"))
                            row["wk_yrsall"] = 0;
                        else if (decimal.Parse(row["wk_yrsall"].ToString()) < 0)
                            row["wk_yrsall"] = 0;
                        decimal _inyear = decimal.Parse(row["wk_yrs"].ToString());
                        decimal _ckwkyrs = decimal.Parse(row["ckwk_yrs"].ToString());
                        if (typedata != "2")
                        {
                            if (_ckwkyrs >= inyear) //(_inyear >= inyear)
                            {
                                object[] _value1 = new object[2];
                                _value1[0] = Row["nobr"].ToString();
                                _value1[1] = Row["yymm"].ToString();
                                DataRow row4 = rq_wageda.Rows.Find(_value1);
                                if (row4 != null)
                                    row4["amt"] = int.Parse(row4["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                                else
                                {
                                    DataRow aRow = rq_wageda.NewRow();
                                    aRow["nobr"] = Row["nobr"].ToString();
                                    aRow["name_c"] = row["name_c"].ToString();
                                    aRow["name_e"] = row["name_e"].ToString();
                                    aRow["dept"] = row["dept"].ToString();
                                    aRow["d_name"] = row["d_name"].ToString();
                                    aRow["d_ename"] = row["d_ename"].ToString();
                                    decimal _yyear = ((TimeSpan)(DateTime.Parse(date_b) - DateTime.Parse(row["birdt"].ToString()))).Days;
                                    //decimal _iyear = ((TimeSpan)((DateTime.Parse(date_b) - DateTime.Parse(_indt)))).Days;
                                    aRow["y_year"] = decimal.Round(_yyear / Convert.ToDecimal(365.24), 2);
                                    //aRow["i_year"] = decimal.Round(_iyear / Convert.ToDecimal(365.24), 2);
                                    //if (row["retchoo"].ToString().Trim() == "1")
                                    //{
                                    //    aRow["i_year"] = decimal.Parse(row["wk_yrs"].ToString());
                                    //    aRow["retchoo"] = "舊制";
                                    //}
                                    //else
                                    //{
                                    //    aRow["i_year"] = (row.IsNull("wk_yrs1")) ? 0 : decimal.Parse(row["wk_yrs1"].ToString());
                                    //     aRow["retchoo"] = "新制";
                                    //}
                                    aRow["wk_yrs"] = (row.IsNull("wk_yrsall")) ? 0 : decimal.Parse(row["wk_yrsall"].ToString());
                                    aRow["i_year"] = decimal.Parse(row["wk_yrs"].ToString());
                                    if (decimal.Parse(aRow["i_year"].ToString()) <= 15)
                                        aRow["i_base"] = (decimal.Ceiling(decimal.Parse(aRow["i_year"].ToString()) / Convert.ToDecimal(0.5)) / 2) * 2;
                                    else
                                        aRow["i_base"] = ((decimal.Ceiling((decimal.Parse(aRow["i_year"].ToString()) - 15) / Convert.ToDecimal(0.5)) / 2) * 1) + 30;
                                    if (decimal.Parse(aRow["i_base"].ToString()) > 45) aRow["i_base"] = 45;
                                    aRow["yymm"] = Row["yymm"].ToString();
                                    aRow["amt"] = int.Parse(Row["amt"].ToString());
                                    rq_wageda.Rows.Add(aRow);
                                }
                            }
                        }
                        else
                        {
                            object[] _value1 = new object[2];
                            _value1[0] = Row["nobr"].ToString();
                            _value1[1] = Row["yymm"].ToString();
                            DataRow row4 = rq_wageda.Rows.Find(_value1);
                            if (row4 != null)
                                row4["amt"] = int.Parse(row4["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                            else
                            {
                                DataRow aRow = rq_wageda.NewRow();
                                aRow["nobr"] = Row["nobr"].ToString();
                                aRow["name_c"] = row["name_c"].ToString();
                                aRow["name_e"] = row["name_e"].ToString();
                                aRow["dept"] = row["dept"].ToString();
                                aRow["d_name"] = row["d_name"].ToString();
                                aRow["d_ename"] = row["d_ename"].ToString();
                                decimal _yyear = ((TimeSpan)(DateTime.Parse(date_b) - DateTime.Parse(row["birdt"].ToString()))).Days;
                                //decimal _iyear = ((TimeSpan)((DateTime.Parse(date_b) - DateTime.Parse(_indt)))).Days;
                                aRow["y_year"] = decimal.Round(_yyear / Convert.ToDecimal(365.24), 2);
                                //aRow["i_year"] = decimal.Round(_iyear / Convert.ToDecimal(365.24), 2);
                                if(row["retchoo"].ToString().Trim() == "1") 
                                {
                                    aRow["i_year"] = decimal.Parse(row["wk_yrs"].ToString());
                                    aRow["retchoo"] = "舊制";
                                }
                                {
                                    aRow["i_year"] = (row.IsNull("wk_yrs1")) ? 0 : decimal.Parse(row["wk_yrs1"].ToString());
                                    aRow["retchoo"] = "新制";
                                }
                                if (decimal.Parse(aRow["i_year"].ToString()) <= 15)
                                    aRow["i_base"] = (decimal.Ceiling(decimal.Parse(aRow["i_year"].ToString()) / Convert.ToDecimal(0.5)) / 2) * 2;
                                else
                                    aRow["i_base"] = ((decimal.Ceiling((decimal.Parse(aRow["i_year"].ToString()) - 15) / Convert.ToDecimal(0.5)) / 2) * 1) + 30;
                                if (decimal.Parse(aRow["i_base"].ToString()) > 45) aRow["i_base"] = 45;
                                aRow["yymm"] = Row["yymm"].ToString();
                                aRow["amt"] = int.Parse(Row["amt"].ToString());
                                rq_wageda.Rows.Add(aRow);
                            }
                        }
                        
                        DataRow row5 = rq_yymm.Rows.Find(Row["yymm"].ToString());
                        if (row5 == null)
                        {
                            _n++;
                            if (_n < 7)
                            {
                                DataRow aRow1 = rq_yymm.NewRow();
                                aRow1["yymm"] = Row["yymm"].ToString();
                                rq_yymm.Rows.Add(aRow1);                                
                            }
                        }
                    }                   
                }
                rq_base = null;                
                rq_salcode = null;
                rq_sys4 = null;
                rq_wage = null;
                rq_waged = null;
                if (rq_wageda.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                ds.Tables["zz4k"].PrimaryKey = new DataColumn[] { ds.Tables["zz4k"].Columns["nobr"] };
                DataRow[] SRow = rq_wageda.Select("i_base>0", "dept,nobr asc");
                foreach(DataRow Row in SRow)
                {
                    DataRow row = ds.Tables["zz4k"].Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        for (int i = 0; i < rq_yymm.Rows.Count; i++)
                        {
                            if (Row["yymm"].ToString() == rq_yymm.Rows[i]["yymm"].ToString())
                            {
                                row["times"] = int.Parse(row["times"].ToString()) + 1;
                                row["yymm" + (i + 1)] = Row["yymm"].ToString();
                                row["amt" + (i + 1)] = int.Parse(Row["amt"].ToString());
                                row["sumamt"] = int.Parse(row["sumamt"].ToString()) + int.Parse(Row["amt"].ToString());
                                //row["avgamt"] = Math.Round(decimal.Parse(row["sumamt"].ToString()) / 6, MidpointRounding.AwayFromZero);
                                row["avgamt"] = decimal.Parse(row["sumamt"].ToString()) / int.Parse(row["times"].ToString());
                                row["retamt"] = Math.Round(decimal.Parse(row["avgamt"].ToString()) * decimal.Parse(row["i_base"].ToString()), MidpointRounding.AwayFromZero);
                            }
                        }                       
                        
                    }
                    else
                    {
                        DataRow aRow = ds.Tables["zz4k"].NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["name_c"] = Row["name_c"].ToString();
                        aRow["name_e"] = Row["name_e"].ToString();
                        aRow["dept"] = Row["dept"].ToString();
                        aRow["d_name"] = Row["d_name"].ToString();
                        aRow["d_ename"] = Row["d_ename"].ToString();
                        aRow["y_year"] = decimal.Parse(Row["y_year"].ToString());
                        aRow["i_year"] = decimal.Parse(Row["i_year"].ToString());
                        aRow["i_base"] = decimal.Parse(Row["i_base"].ToString());
                        for (int i = 0; i < rq_yymm.Rows.Count; i++)
                        {
                            if (Row["yymm"].ToString() == rq_yymm.Rows[i]["yymm"].ToString())
                            {
                                aRow["yymm" + (i + 1)] = Row["yymm"].ToString();
                                aRow["amt" + (i + 1)] = int.Parse(Row["amt"].ToString());
                            }
                        }
                        aRow["sumamt"] = int.Parse(Row["amt"].ToString());
                        //aRow["avgamt"] = Math.Round(decimal.Parse(aRow["sumamt"].ToString()) / 6, MidpointRounding.AwayFromZero);
                        aRow["avgamt"] = decimal.Parse(aRow["sumamt"].ToString());
                        aRow["times"] = 1;
                        aRow["retamt"] = Math.Round(decimal.Parse(aRow["avgamt"].ToString()) * decimal.Parse(aRow["i_base"].ToString()), MidpointRounding.AwayFromZero);
                        DataRow row2 = rq_sal.Rows.Find(Row["nobr"].ToString());
                        //aRow["yamt"] = (row2 != null) ? (int.Parse(row2["amt"].ToString()) * 14) / 12 : 0;
                        aRow["retchoo"] = Row["retchoo"].ToString();
                        ds.Tables["zz4k"].Rows.Add(aRow);
                    }
                }
                //foreach (DataRow Row in ds.Tables["zz4k"].Rows)
                //{
                //    decimal _yamt = Math.Round(decimal.Parse(Row["yamt"].ToString()) * decimal.Parse(Row["i_base"].ToString()), MidpointRounding.AwayFromZero);
                //    if (_yamt > decimal.Parse(Row["retamt"].ToString()))
                //        Row["retamt"] = Convert.ToInt32(_yamt);
                //}
                
                DataRow aRow5 = ds.Tables["zz4kt"].NewRow();
                for (int i = 0; i < rq_yymm.Rows.Count;i++ )
                {
                    aRow5["yymm" + (i + 1)] = rq_yymm.Rows[i]["yymm"].ToString();
                }
                ds.Tables["zz4kt"].Rows.Add(aRow5);               
                rq_wageda = null;
                rq_yymm = null;

                if (ds.Tables["zz4k"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                if (exportexcel)
                {
                    Export(ds.Tables["zz4k"],ds.Tables["zz4kt"]);
                    this.Close();
                }
                else
                {                   
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "SalReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "SalReport", "*.rdlc");
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4k.rdlc";

                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4k", ds.Tables["zz4k"]));
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4kt", ds.Tables["zz4kt"]));
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

        void Export(DataTable DT,DataTable DT1)
        {
            DataTable ExporDt = new DataTable();
           
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            ExporDt.Columns.Add("預計退休日期", typeof(DateTime));
            ExporDt.Columns.Add("年齡", typeof(decimal));
            ExporDt.Columns.Add("舊制年資", typeof(decimal));
            ExporDt.Columns.Add("退休", typeof(string));
            for (int i = 0; i < DT1.Columns.Count;i++ )
            {
                if (DT1.Rows[0][i].ToString().Trim() != "")
                {
                    ExporDt.Columns.Add("計算年月" + (i + 1), typeof(string));
                    ExporDt.Columns.Add("薪資年月" + (i + 1), typeof(int));
                }
                else
                    break;
            }
            ExporDt.Columns.Add("平均薪資", typeof(decimal));            
            ExporDt.Columns.Add("期數", typeof(decimal));
            ExporDt.Columns.Add("退休金", typeof(int));  
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();               
                aRow["員工編號"] = Row01["nobr"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();
                aRow["英文姓名"] = Row01["name_e"].ToString();
                aRow["預計退休日期"] = DateTime.Parse(date_b);
                aRow["年齡"] = decimal.Parse(Row01["y_year"].ToString());
                aRow["舊制年資"] = decimal.Parse(Row01["i_year"].ToString());
                aRow["退休"] = Row01["retchoo"].ToString();
                for (int i = 0; i < DT1.Columns.Count; i++)
                {
                    if (DT1.Rows[0][i].ToString().Trim() != "")
                    {
                        aRow["計算年月" + (i + 1)] = (Row01.IsNull("yymm" + (i + 1))) ? "" : Row01["yymm" + (i + 1)].ToString();
                        aRow["薪資年月" + (i + 1)] = (Row01.IsNull("amt" + (i + 1))) ? 0 : int.Parse(Row01["amt" + (i + 1)].ToString());
                    }
                    else
                        break;
                }
                aRow["平均薪資"] = decimal.Parse(Row01["avgamt"].ToString());               
                aRow["期數"] = decimal.Parse(Row01["i_base"].ToString());
                aRow["退休金"] = int.Parse(Row01["retamt"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
