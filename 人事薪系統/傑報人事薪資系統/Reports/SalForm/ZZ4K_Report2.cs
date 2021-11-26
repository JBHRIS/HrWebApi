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
    public partial class ZZ4K_Report2 : JBControls.JBForm
    {
        SalDataSet ds = new SalDataSet();
        string nobr_b, nobr_e, dept_b, dept_e, date_b, yyb, mmb, seq_b, yymm_b, yye, mme, seq_e, yymm_e;
        string typedata, workadr, counttype, comp_name, CompId, emp_b, emp_e;
        decimal inyear, reyear;
        bool exportexcel;
        public ZZ4K_Report2(string nobrb, string nobre, string deptb, string depte, string empb, string empe, string dateb, string _yyb, string _mmb, string _seqb, string _yye, string _mme, string _seqe, string _typedata, string _workadr, string _counttype, decimal _inyear, decimal _reyear, bool _exportexcel, string compname, string _CompId)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; typedata = _typedata;
            workadr = _workadr; inyear = _inyear; reyear = _reyear; exportexcel = _exportexcel; date_b = dateb;
            yymm_b = _yyb + _mmb; seq_b = _seqb; yymm_e = _yye + _mme; seq_e = _seqe; counttype = _counttype;
            comp_name = compname; CompId = _CompId; emp_b = empb; emp_e = empe;
        }

        private void ZZ4K_Report2_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select a.nobr,a.name_c,c.d_no_disp as dept,c.d_name,b.di,b.indt,b.stdt,b.stindt,a.birdt";
                sqlCmd += ",b.retchoo,b.retdate from base a,basetts b,dept c";
                sqlCmd += " where a.nobr=b.nobr and b.dept=c.d_no";
                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_b);
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);
                sqlCmd += " and b.ttscode in ('1','4','6')";               
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                string sqlCmd1 = "select nobr,yymm,seq,wk_days,date_b,date_e from wage";
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
                //sqlCmd2 += " and sal_code not in ('B10','B13','B14','B09','D04')";
                sqlCmd2 += string.Format(@" and sal_code <> '{0}'", retsalcode);
                sqlCmd2 += " order by yymm";
                DataTable rq_waged = SqlConn.GetDataTable(sqlCmd2);
                rq_waged.Columns.Add("flag", typeof(string));               

                string sqlCmd3 = "select a.sal_code,b.flag from salcode a,salattr b";
                sqlCmd3 += string.Format(@" where a.sal_attr=b.salattr and a.sal_code <> '{0}'", retsalcode);
                //sqlCmd3 += " and a.sal_code not in ('B10','B13','B14','B09','D04') and  a.sal_attr <='L'";
                sqlCmd3 += " and  a.sal_attr <='L'";
                DataTable rq_salcode = SqlConn.GetDataTable(sqlCmd3);
                rq_salcode.PrimaryKey = new DataColumn[] { rq_salcode.Columns["sal_code"] };

                //計算停薪留職
                string sqlCmd4 = "select nobr,datediff(day,stdt,stindt)-1 as day,stdt,stindt from basetts";
                sqlCmd4 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd4 += string.Format(@" and dept between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd4 += " and stdt is not null and stindt is not null and ttscode='4'";
                DataTable rq_day = SqlConn.GetDataTable(sqlCmd4);
                DataTable rq_stdtp = new DataTable();
                rq_stdtp.Columns.Add("nobr", typeof(string));
                rq_stdtp.Columns.Add("stindt", typeof(DateTime));
                rq_stdtp.Columns.Add("up_day", typeof(string));
                rq_stdtp.Columns.Add("day", typeof(int));
                rq_stdtp.PrimaryKey = new DataColumn[] { rq_stdtp.Columns["nobr"] };
                foreach (DataRow Row in rq_day.Rows)
                {
                    DataRow row = rq_stdtp.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                        row["day"] = int.Parse(row["day"].ToString()) + int.Parse(Row["day"].ToString());
                    else
                    {
                        DataRow aRow = rq_stdtp.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["stindt"] = DateTime.Parse(Row["stindt"].ToString());
                        aRow["day"] = int.Parse(Row["day"].ToString());
                        int _stindt = Convert.ToInt32(DateTime.Parse(Row["stindt"].ToString()).ToString("yyyyMMdd"));
                        int _stdt= Convert.ToInt32(DateTime.Parse(Row["stdt"].ToString()).ToString("yyyyMMdd"));
                        if (_stdt > 20050701 && _stindt > 20050701)
                            aRow["up_day"] = "*";
                        else
                            aRow["up_day"] = "";
                        rq_stdtp.Rows.Add(aRow);
                    }
                }

                //加回病假+無薪假
                string sqlCmd5 = "select a.nobr,a.yymm,'2' as seq,a.sal_code,a.amt from salabs a,hcode b";
                sqlCmd5 += " where a.h_code=b.h_code";
                sqlCmd5 += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd5 += string.Format(@" and a.yymm between '{0}' and '{1}'", yymm_b, yymm_e);
                sqlCmd5 += " and b.h_code_disp in ('C','U','U1','V','P')";
                DataTable rq_salabs = SqlConn.GetDataTable(sqlCmd5);
                foreach (DataRow Row in rq_salabs.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    object[] _value = new object[3];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = Row["yymm"].ToString();
                    _value[2] = "2";
                    DataRow row1 = rq_wage.Rows.Find(_value);
                    if (row != null && row1 != null)
                    {
                        rq_waged.ImportRow(Row);
                    }
                }

                DataTable rq_wageda = new DataTable();
                rq_wageda.Columns.Add("nobr", typeof(string));
                rq_wageda.Columns.Add("name_c", typeof(string));
                rq_wageda.Columns.Add("indt", typeof(DateTime));
                rq_wageda.Columns.Add("retdate", typeof(DateTime));
                rq_wageda.Columns.Add("retchoo", typeof(string));
                rq_wageda.Columns.Add("dept", typeof(string));
                rq_wageda.Columns.Add("d_name", typeof(string));
                rq_wageda.Columns.Add("yymm", typeof(string));
                rq_wageda.Columns.Add("amt", typeof(int));
                rq_wageda.Columns.Add("y_year", typeof(decimal));
                rq_wageda.Columns.Add("i_year", typeof(decimal));                
                rq_wageda.Columns.Add("i_base", typeof(decimal));
                rq_wageda.Columns.Add("st_dayo", typeof(int));
                rq_wageda.Columns.Add("st_dayn", typeof(int));
                rq_wageda.Columns.Add("lday", typeof(int));
                rq_wageda.Columns.Add("up_day", typeof(string));
                rq_wageda.Columns.Add("date_b", typeof(DateTime));
                rq_wageda.Columns.Add("date_e", typeof(DateTime));
                rq_wageda.Columns.Add("wk_days", typeof(int));                
                rq_wageda.PrimaryKey = new DataColumn[] { rq_wageda.Columns["nobr"], rq_wageda.Columns["yymm"] };
                
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
                    if (row != null && row1 != null && row2 != null)
                    {
                        string _indt = ""; string _upday = ""; int _stdayo = 0; string _retdate = ""; int _stdayn = 0;
                        int _days = 0;
                        DataRow row3 = rq_stdtp.Rows.Find(Row["nobr"].ToString());
                        if (row2 != null)
                            Row["flag"] = row2["flag"].ToString();
                        if (row3 != null)
                        {
                            _indt = DateTime.Parse(row["indt"].ToString()).AddDays(int.Parse(row3["day"].ToString())).ToString("yyyy/MM/dd");
                            _retdate = DateTime.Parse(row["retdate"].ToString()).AddDays(int.Parse(row3["day"].ToString())).ToString("yyyy/MM/dd");
                            _upday = row3["up_day"].ToString();
                            if (row3["up_day"].ToString().Trim() != "" && (DateTime.Parse(row["retdate"].ToString()).ToString("yyyyMMdd") != DateTime.Parse(row["stindt"].ToString()).ToString("yyyyMMdd")))
                                _stdayn = int.Parse(row3["day"].ToString());
                            if (row3["up_day"].ToString().Trim() == "")
                                _stdayo = int.Parse(row3["day"].ToString());
                            _days = int.Parse(row3["day"].ToString());
                        }
                        else
                        {
                            _indt = DateTime.Parse(row["indt"].ToString()).ToString("yyyy/MM/dd");
                            _retdate = (row.IsNull("retdate")) ? "1900/01/01" : DateTime.Parse(row["retdate"].ToString()).ToString("yyyy/MM/dd");
                        }

                        if (Row["flag"].ToString().Trim() == "-")
                            Row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString())) * (-1);
                        else
                            Row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));
                        int adat = int.Parse(Row["amt"].ToString());
                        //decimal _inyear = decimal.Round((((TimeSpan)(DateTime.Parse(date_b) - DateTime.Parse(_indt))).Days) / Convert.ToDecimal(365.24), 2);
                        //if (_inyear >= inyear)
                        //{
                            
                        //}
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
                            aRow["dept"] = row["dept"].ToString();
                            aRow["d_name"] = row["d_name"].ToString();
                            aRow["indt"] = DateTime.Parse(_indt);
                            aRow["retdate"] = _retdate;
                            aRow["retchoo"] = row["retchoo"].ToString();
                            aRow["up_day"] = _upday;
                            aRow["st_dayo"] = _stdayo;
                            aRow["st_dayn"] = _stdayn;
                            aRow["lday"] = _days;
                            aRow["date_b"] = DateTime.Parse(row1["date_b"].ToString());
                            aRow["date_e"] = DateTime.Parse(row1["date_e"].ToString());
                            aRow["wk_days"] = decimal.Round(decimal.Parse(row1["wk_days"].ToString()), 0);
                            decimal _yyear = ((TimeSpan)(DateTime.Parse(date_b) - DateTime.Parse(row["birdt"].ToString()))).Days;
                            decimal _iyear = ((TimeSpan)((DateTime.Parse(date_b) - DateTime.Parse(_indt)))).Days;
                            aRow["y_year"] = decimal.Round(_yyear / Convert.ToDecimal(365.24), 2);
                            aRow["i_year"] = decimal.Round(_iyear / Convert.ToDecimal(365.24), 2);
                            if (decimal.Parse(aRow["i_year"].ToString()) <= 15)
                                aRow["i_base"] = (decimal.Ceiling(decimal.Parse(aRow["i_year"].ToString()) / Convert.ToDecimal(0.5)) / 2) * 2;
                            else
                                aRow["i_base"] = ((decimal.Ceiling((decimal.Parse(aRow["i_year"].ToString()) - 15) / Convert.ToDecimal(0.5)) / 2) * 1) + 30;
                            aRow["yymm"] = Row["yymm"].ToString();
                            aRow["amt"] = int.Parse(Row["amt"].ToString());
                            rq_wageda.Rows.Add(aRow);
                        }

                        DataRow row5 = rq_yymm.Rows.Find(Row["yymm"].ToString());
                        if (row5 == null)
                        {
                            DataRow aRow1 = rq_yymm.NewRow();
                            aRow1["yymm"] = Row["yymm"].ToString();
                            rq_yymm.Rows.Add(aRow1);
                            //_n++;
                            //if (_n < 7)
                            //{
                                
                            //}
                        }
                    }
                }
                DataRow aRow5 = ds.Tables["zz4kt"].NewRow();
                for (int i = 0; i < rq_yymm.Rows.Count; i++)
                {
                    aRow5["yymm" + (i + 1)] = rq_yymm.Rows[i]["yymm"].ToString();
                }
                ds.Tables["zz4kt"].Rows.Add(aRow5);
               
                if (rq_wageda.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                
                ds.Tables["zz4k1"].PrimaryKey = new DataColumn[] { ds.Tables["zz4k1"].Columns["nobr"] };
                DataRow[] SRow = rq_wageda.Select("", "dept,nobr asc");
                foreach (DataRow Row in SRow)
                {
                    DataRow row = ds.Tables["zz4k1"].Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        if (int.Parse(row["p_month"].ToString()) < 6)
                        {
                            for (int i = 0; i < rq_yymm.Rows.Count; i++)
                            {
                                if (row["yymm" + (i + 1)].ToString().Trim()=="")//(Row["yymm"].ToString() == rq_yymm.Rows[i]["yymm"].ToString())
                                {
                                    row["p_month"] = int.Parse(row["p_month"].ToString()) + 1;
                                    row["yymm" + (i + 1)] = Row["yymm"].ToString();
                                    row["amt" + (i + 1)] = int.Parse(Row["amt"].ToString());
                                    row["pno" + (i + 1)] = int.Parse(Row["amt"].ToString());
                                    row["wk_days" + (i + 1)] = int.Parse(Row["wk_days"].ToString());
                                    row["days" + (i + 1)] = ((TimeSpan)(DateTime.Parse(Row["date_e"].ToString()) - DateTime.Parse(Row["date_b"].ToString()))).Days + 1;
                                    if (int.Parse(row["wk_days" + (i + 1)].ToString()) != int.Parse(row["days" + (i + 1)].ToString()))
                                        row["amt" + (i + 1)] = (int.Parse(Row["wk_days"].ToString()) == 0) ? 0 : decimal.Round(decimal.Parse(Row["amt"].ToString()) / decimal.Parse(Row["wk_days"].ToString()) * 30, 2);
                                    row["sumamt"] = int.Parse(row["sumamt"].ToString()) + int.Parse(row["amt" + (i + 1)].ToString());
                                    row["avgamt"] = decimal.Parse(row["sumamt"].ToString()) / int.Parse(row["p_month"].ToString());
                                    row["retamt"] = Math.Round(decimal.Parse(row["avgamt"].ToString()) * decimal.Parse(row["i_base"].ToString()), MidpointRounding.AwayFromZero);
                                    row["peramt"] = (decimal.Parse(row["p_month"].ToString()) > 0) ? Math.Round((decimal.Parse(row["avgamt"].ToString()) / 30) * int.Parse(row["perday"].ToString()), MidpointRounding.AwayFromZero) : 0;
                                    break;
                                }
                            }
                        }

                    }
                    else
                    {
                        DataRow aRow = ds.Tables["zz4k1"].NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["name_c"] = Row["name_c"].ToString();
                        aRow["dept"] = Row["dept"].ToString();
                        aRow["d_name"] = Row["d_name"].ToString();
                        aRow["y_year"] = decimal.Parse(Row["y_year"].ToString());
                        aRow["i_year"] = decimal.Parse(Row["i_year"].ToString());
                        aRow["i_base"] = decimal.Parse(Row["i_base"].ToString());
                        aRow["retchoo"] = Row["retchoo"].ToString();
                        aRow["indt"] = DateTime.Parse(Row["indt"].ToString());
                        aRow["retdate"] = DateTime.Parse(Row["retdate"].ToString());
                        aRow["p_month"] = 1;
                        aRow["yymm1"] = Row["yymm"].ToString();
                        aRow["amt1"] = int.Parse(Row["amt"].ToString());
                        aRow["pno1"] = int.Parse(Row["amt"].ToString());
                        aRow["wk_days1"] = int.Parse(Row["wk_days"].ToString());
                        aRow["days1"] = ((TimeSpan)(DateTime.Parse(Row["date_e"].ToString()) - DateTime.Parse(Row["date_b"].ToString()))).Days + 1;
                        if (int.Parse(aRow["wk_days1"].ToString()) != int.Parse(aRow["days1"].ToString()))
                            aRow["amt1"] = (int.Parse(Row["wk_days"].ToString()) == 0) ? 0 : decimal.Round(decimal.Parse(Row["amt"].ToString()) / decimal.Parse(Row["wk_days"].ToString()) * 30, 2);
                        aRow["sumamt"] = decimal.Parse(aRow["amt1"].ToString());
                        aRow["avgamt"] = int.Parse(aRow["amt1"].ToString());  
                        //for (int i = 0; i < rq_yymm.Rows.Count; i++)
                        //{
                        //    if (Row["yymm"].ToString() == rq_yymm.Rows[i]["yymm"].ToString())
                        //    {
                        //        aRow["p_month"] = 1;
                        //        aRow["yymm" + (i + 1)] = Row["yymm"].ToString();
                        //        aRow["amt" + (i + 1)] = int.Parse(Row["amt"].ToString());
                        //        aRow["pno"+(i + 1)]=int.Parse(Row["amt"].ToString());
                        //        aRow["wk_days" + (i + 1)] = int.Parse(Row["wk_days"].ToString());
                        //        aRow["days" + (i + 1)] = ((TimeSpan)(DateTime.Parse(Row["date_e"].ToString()) - DateTime.Parse(Row["date_b"].ToString()))).Days + 1;
                        //        if (int.Parse(aRow["wk_days" + (i + 1)].ToString()) != int.Parse(aRow["days" + (i + 1)].ToString()))
                        //            aRow["amt" + (i + 1)] = (int.Parse(Row["wk_days"].ToString()) == 0) ? 0 : decimal.Round(decimal.Parse(Row["amt"].ToString()) / decimal.Parse(Row["wk_days"].ToString()) * 30, 2);
                        //        aRow["sumamt"] = int.Parse(aRow["amt" + (i + 1)].ToString());
                        //        aRow["avgamt"] = int.Parse(aRow["amt" + (i + 1)].ToString());   
                        //    }
                        //}
                                             
                        aRow["n_year"] = 0;
                        aRow["i_year"] = 0;
                        aRow["o_year"] = 0;
                        aRow["o_month"] = 0;
                        aRow["old"] = 0;
                        aRow["new"] = 0;
                        DateTime _retdate=DateTime.Parse(Row["retdate"].ToString());
                        DateTime _indt=DateTime.Parse(Row["indt"].ToString());
                        //計算新制
                        if (Row["retchoo"].ToString().Trim() == "2")
                        {
                            if (int.Parse(DateTime.Parse(Row["indt"].ToString()).ToString("yyyyMMdd")) < 20050701)
                            {
                                aRow["i_year"] = decimal.Round((((TimeSpan)((_retdate - _indt))).Days - 3) / Convert.ToDecimal(365.24), 2);
                                if (_retdate.Month > _indt.Month)
                                {
                                    aRow["o_year"] = _retdate.Year - _indt.Year;
                                    if (_retdate.Day - _indt.Day < 0)
                                        aRow["o_month"] = _retdate.Month - _indt.Month;
                                    else
                                        aRow["o_month"] = _retdate.Month - _indt.Month + 1;
                                }
                                else if (_retdate.Month < _indt.Month)
                                {
                                    aRow["o_year"] = _retdate.Year - _indt.Year - 1;
                                    if (_retdate.Day - _indt.Day < 0)
                                        aRow["o_month"] = 12 + _retdate.Month - _indt.Month;
                                    else
                                        aRow["o_month"] = 12 + _retdate.Month - _indt.Month + 1;
                                }
                                else if (_retdate.Month == _indt.Month)
                                {
                                    aRow["o_year"] = _retdate.Year - _indt.Year;
                                    if (_retdate.Day - _indt.Day < 0)
                                        aRow["o_month"] = 12 + _retdate.Month - _indt.Month;
                                    else
                                        aRow["o_month"] = 12 + _retdate.Month - _indt.Month + 1;
                                }
                            }                           

                            aRow["n_year"] = decimal.Round((((TimeSpan)(DateTime.Parse(date_b) - _retdate)).Days) / Convert.ToDecimal(365.24), 2);
                            aRow["old"] = decimal.Round((decimal.Parse(aRow["o_year"].ToString()) * 1) + (decimal.Parse(aRow["o_month"].ToString()) / 12 * 1), 2);
                            //aRow["new"] = decimal.Round(decimal.Parse(aRow["n_year"].ToString()) * Convert.ToDecimal(0.5), 2);
                            aRow["new"] = Math.Round(decimal.Parse(aRow["n_year"].ToString()) * Convert.ToDecimal(0.5), 2, MidpointRounding.AwayFromZero);
                            if (decimal.Parse(aRow["new"].ToString()) > 6M)
                                aRow["new"] = 6M;
                            aRow["i_base"] = decimal.Round(decimal.Parse(aRow["old"].ToString()) + decimal.Parse(aRow["new"].ToString()), 2);
                        }
                        else
                        {                            
                            aRow["i_year"] = decimal.Round((((TimeSpan)((DateTime.Parse(date_b) - _indt))).Days - 3) / Convert.ToDecimal(365.24), 2);
                            if (DateTime.Parse(date_b).Month > _indt.Month)
                            {
                                aRow["o_year"] = DateTime.Parse(date_b).Year - _indt.Year;
                                if (_retdate.Day - _indt.Day < 0)
                                    aRow["o_month"] = DateTime.Parse(date_b).Month - _indt.Month;
                                else
                                    aRow["o_month"] = DateTime.Parse(date_b).Month - _indt.Month + 1;
                            }
                            else if (DateTime.Parse(date_b).Month < _indt.Month)
                            {
                                aRow["o_year"] = DateTime.Parse(date_b).Year - _indt.Year - 1;
                                if (_retdate.Day - _indt.Day < 0)
                                {
                                    int dst = DateTime.Parse(date_b).Month;
                                    int dstt = _indt.Month;
                                    aRow["o_month"] = 12 + DateTime.Parse(date_b).Month - _indt.Month;
                                   
                                }
                                else
                                    aRow["o_month"] = 12 + DateTime.Parse(date_b).Month - _indt.Month + 1;
                            }
                            else if (DateTime.Parse(date_b).Month == _indt.Month)
                            {
                                aRow["o_year"] = DateTime.Parse(date_b).Year - _indt.Year;
                                if (DateTime.Parse(date_b).Day - _indt.Day < 0)
                                    aRow["o_month"] = 12 + DateTime.Parse(date_b).Month - _indt.Month;
                                else
                                    aRow["o_month"] = 12 + DateTime.Parse(date_b).Month - _indt.Month + 1;
                            }
                            aRow["old"] = decimal.Round((decimal.Parse(aRow["o_year"].ToString()) * 1) + ((decimal.Parse(aRow["o_month"].ToString()) / 12) * 1), 2);
                            aRow["new"] = 0;
                            aRow["i_base"] = decimal.Parse(aRow["old"].ToString());
                        }

                        decimal _ayear = decimal.Parse(aRow["i_year"].ToString()) + decimal.Parse(aRow["n_year"].ToString());
                        aRow["perday"] = 0;                       
                        if (_ayear >= 3)
                            aRow["perday"] = 30;
                        else if (_ayear >= 1 && _ayear < 3)
                            aRow["perday"] = 20;
                        else if (_ayear < 1 && Convert.ToDecimal(_indt.AddMonths(3).ToString("yyyyMMdd")) <= Convert.ToDecimal(DateTime.Parse(date_b).ToString("yyyyMMdd")))
                            aRow["perday"] = 10;
                        aRow["peramt"] = (int.Parse(aRow["p_month"].ToString()) > 0 && int.Parse(aRow["perday"].ToString()) > 0) ? Math.Round(((decimal.Parse(Row["amt"].ToString()) / 30) * (int.Parse(aRow["perday"].ToString()))), MidpointRounding.AwayFromZero) : 0;
                        aRow["retamt"] = Math.Round(decimal.Parse(aRow["avgamt"].ToString()) * decimal.Parse(aRow["i_base"].ToString()), MidpointRounding.AwayFromZero);
                        ds.Tables["zz4k1"].Rows.Add(aRow);
                    }
                }               
                //JBModule.Data.CNPOI.RenderDataTableToExcel(ds.Tables["zz4k1"], "C:\\TEMP\\" + this.Name + ".xls");
                //System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");

                rq_base = null;
                rq_day = null;
                rq_salcode = null;
                rq_sys4 = null;
                rq_wage = null;
                rq_waged = null;
                rq_stdtp = null;
                rq_salabs = null;
                rq_wageda = null;
                rq_yymm = null;
                if (exportexcel)
                {
                    Export(ds.Tables["zz4k1"], ds.Tables["zz4kt"]);
                    this.Close();
                }
                else
                {
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "SalReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "SalReport", "*.rdlc");
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4k1.rdlc";

                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4k1", ds.Tables["zz4k1"]));                    
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

        void Export(DataTable DT, DataTable DT1)
        {
            DataTable ExporDt = new DataTable();

            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("到職日期", typeof(DateTime));
            ExporDt.Columns.Add("舊制年資", typeof(decimal));
            ExporDt.Columns.Add("資遣日期", typeof(DateTime));
            ExporDt.Columns.Add("退休制度", typeof(string));
            ExporDt.Columns.Add("舊制基數", typeof(decimal));
            ExporDt.Columns.Add("留停天數", typeof(int));
            ExporDt.Columns.Add("加入新制日期", typeof(DateTime));
            ExporDt.Columns.Add("新制年資", typeof(decimal));
            ExporDt.Columns.Add("新制基數", typeof(decimal));
            ExporDt.Columns.Add("年資", typeof(decimal));
            ExporDt.Columns.Add("年齡", typeof(decimal));
            
            for (int i = 0; i < DT1.Columns.Count; i++)
            {
                if (DT1.Rows[0][i].ToString().Trim() != "")
                {
                    ExporDt.Columns.Add("計算年月" + (i + 1), typeof(string));
                    ExporDt.Columns.Add("月領薪資" + (i + 1), typeof(int));
                    ExporDt.Columns.Add("工作天數" + (i + 1), typeof(int));
                    ExporDt.Columns.Add("薪資" + (i + 1), typeof(int));
                }
                else
                    break;
            }
            ExporDt.Columns.Add("平均薪資", typeof(decimal));
            ExporDt.Columns.Add("基數", typeof(decimal));
            ExporDt.Columns.Add("資遣金", typeof(int));
            ExporDt.Columns.Add("天數", typeof(int));
            ExporDt.Columns.Add("預告工資", typeof(int));
            ExporDt.Columns.Add("金額合計", typeof(int));
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["員工編號"] = Row01["nobr"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();
                aRow["到職日期"] = DateTime.Parse(Row01["indt"].ToString());
                aRow["舊制年資"] = decimal.Parse(Row01["i_year"].ToString());
                aRow["資遣日期"] = DateTime.Parse(date_b);
                aRow["退休制度"] = (Row01["retchoo"].ToString().Trim() == "2") ? "新制" : "舊制";
                aRow["舊制基數"] = decimal.Parse(Row01["old"].ToString());
                aRow["留停天數"] = (Row01.IsNull("upday")) ? 0 : int.Parse(Row01["upday"].ToString());
                aRow["加入新制日期"] = (Row01["retchoo"].ToString().Trim() == "2") ? DateTime.Parse(Row01["retdate"].ToString()) : DateTime.Parse("1900/01/01");
                aRow["新制年資"] = decimal.Parse(Row01["n_year"].ToString());
                aRow["新制基數"] = decimal.Parse(Row01["new"].ToString());
                aRow["年資"] = decimal.Parse(Row01["i_year"].ToString()) + decimal.Parse(Row01["n_year"].ToString());
                aRow["年齡"] = decimal.Parse(Row01["y_year"].ToString());

                for (int i = 0; i < DT1.Columns.Count; i++)
                {
                    if (DT1.Rows[0][i].ToString().Trim() != "")
                    {
                        aRow["計算年月" + (i + 1)] = (Row01.IsNull("yymm" + (i + 1))) ? "" : Row01["yymm" + (i + 1)].ToString();
                        aRow["月領薪資" + (i + 1)] = (Row01.IsNull("amt" + (i + 1))) ? 0 : int.Parse(Row01["amt" + (i + 1)].ToString());
                        aRow["工作天數" + (i + 1)] = (Row01.IsNull("wk_days" + (i + 1))) ? 0 : int.Parse(Row01["wk_days" + (i + 1)].ToString());
                        aRow["薪資" + (i + 1)] = (Row01.IsNull("pno" + (i + 1))) ? 0 : int.Parse(Row01["pno" + (i + 1)].ToString());
                    }
                    else
                        break;
                }
                aRow["平均薪資"] = decimal.Parse(Row01["avgamt"].ToString());
                aRow["基數"] = decimal.Parse(Row01["i_base"].ToString());
                aRow["資遣金"] = int.Parse(Row01["retamt"].ToString());
                aRow["天數"] = int.Parse(Row01["perday"].ToString());
                aRow["預告工資"] = int.Parse(Row01["peramt"].ToString());
                aRow["金額合計"] = int.Parse(Row01["retamt"].ToString()) + int.Parse(Row01["peramt"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
