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
    public partial class ZZ4M_Report : JBControls.JBForm
    {
        SalDataSet ds = new SalDataSet();
        string nobr_b, nobr_e, dept_b, dept_e, date_b, date_e, seq_b, seq_e, yymm_b, yymm_e, comp_b, comp_e, emp_b, emp_e, workadr, sal_yy, sal_mm, comp_name, CompID;
        string datet_b, datet_e;
        bool exportexcel;
        public ZZ4M_Report(string nobrb, string nobre, string deptb, string depte, string dateb, string datee, string datetb, string datete, string _yyb, string _yye, string _mmb, string _mme, string _seqb, string seqe, string compb, string compe, string empb, string empe, string _workadr, string compname, bool _exportexcel, string _CompID)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; emp_b = empb; emp_e = empe;
            workadr = _workadr; exportexcel = _exportexcel; date_b = dateb; yymm_b = _yyb + _mmb;
            yymm_e = _yye + _mme; datet_b = datetb; datet_e = datete;
            seq_b = _seqb; sal_yy = _yyb; sal_mm = _mmb; date_e = datee; comp_name = compname;
            comp_b = compb; comp_e = compe; seq_e = seqe; CompID = _CompID;
        }

        private void ZZ4M_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select a.nobr,a.name_c,a.name_e,b.indt,a.count_ma,b.tax_date,b.tax_edate,b.indt,c.inscomp";
                sqlCmd += " from base a,basetts b";
                sqlCmd += " left outer join comp c on b.comp=c.comp";
                sqlCmd += " left outer join dept d on b.dept=d.d_no";
                sqlCmd += " where a.nobr=b.nobr";
                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and d.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);
                sqlCmd += string.Format(@" and b.comp between '{0}' and '{1}'", comp_b, comp_e);                
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                //薪資主檔
                string sqlCmd1 = "select nobr,yymm,seq,adate,taxrate,format from wage";
                sqlCmd1 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd1 += string.Format(@" and yymm between  '{0}' and '{1}'", yymm_b, yymm_e);
                sqlCmd1 += string.Format(@" and seq between '{0}' and '{1}'", seq_b, seq_e);
                sqlCmd1 += string.Format(@" and adate between '{0}' and '{1}'", datet_b, datet_e);
                sqlCmd1 += workadr;
                DataTable rq_wage = SqlConn.GetDataTable(sqlCmd1);
                DataColumn[] _key = new DataColumn[3];
                _key[0] = rq_wage.Columns["nobr"];
                _key[1] = rq_wage.Columns["yymm"];
                _key[2] = rq_wage.Columns["seq"];
                rq_wage.PrimaryKey = _key;

                DataTable rq_usys9 = SqlConn.GetDataTable("select taxsalcode,taxtype,fixtaxrate,entryday,fortaxrate01,fortaxrate02,fortaxrate03 from u_sys9 where comp='" + CompID + "'");
                string taxtype = string.Empty;
                string taxsalcode = string.Empty;
                int entryday = 0;
                decimal fortaxrate01 = 0; decimal fortaxrate02 = 0; decimal fortaxrate03 = 0; decimal fixtaxrate = 0;
                if (rq_usys9.Rows.Count > 0)
                {
                    taxtype = rq_usys9.Rows[0]["taxtype"].ToString();
                    taxsalcode = rq_usys9.Rows[0]["taxsalcode"].ToString();
                    entryday = Convert.ToInt32(decimal.Parse(rq_usys9.Rows[0]["entryday"].ToString()));
                    fortaxrate01 = decimal.Parse(rq_usys9.Rows[0]["fortaxrate01"].ToString());
                    fortaxrate02 = decimal.Parse(rq_usys9.Rows[0]["fortaxrate02"].ToString());
                    fortaxrate03 = decimal.Parse(rq_usys9.Rows[0]["fortaxrate03"].ToString());
                    fixtaxrate = decimal.Parse(rq_usys9.Rows[0]["fixtaxrate"].ToString());
                }

                //薪資明細檔
                string sqlCmd2 = "select nobr,yymm,seq,sal_code,amt from waged";
                sqlCmd2 += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd2 += string.Format(@" and yymm between  '{0}' and '{1}'", yymm_b, yymm_e);
                sqlCmd2 += string.Format(@" and seq between '{0}' and '{1}'", seq_b, seq_e);               
                sqlCmd2 += " and amt<>10 order by nobr,sal_code";
                DataTable rq_waged = SqlConn.GetDataTable(sqlCmd2);
                rq_waged.Columns.Add("flag", typeof(string));
                rq_waged.Columns.Add("p_183", typeof(string));
                rq_waged.Columns.Add("taxrate", typeof(decimal));
                rq_waged.Columns.Add("count_ma", typeof(bool));
                rq_waged.Columns.Add("format", typeof(string));
                rq_waged.Columns.Add("inscomp", typeof(string));

                string sqlCmd3 = "select a.sal_code,b.flag from salcode a,salattr b";
                sqlCmd3 += " where a.sal_attr=b.salattr";
                sqlCmd3 +=string.Format(@" and(a.sal_attr <='F' or a.sal_code ='{0}')",taxsalcode);
                DataTable rq_salcode = SqlConn.GetDataTable(sqlCmd3);
                rq_salcode.PrimaryKey = new DataColumn[] { rq_salcode.Columns["sal_code"] };
                
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
                        Row["inscomp"] = row["inscomp"].ToString();
                        Row["format"] = row1["format"].ToString();
                        Row["count_ma"] = bool.Parse(row["count_ma"].ToString());
                        Row["taxrate"] = decimal.Parse(row1["taxrate"].ToString());
                        if (row2 != null)
                            Row["flag"] = row2["flag"].ToString();
                        if (Row["flag"].ToString().Trim() == "-" && taxsalcode.Trim() != Row["sal_code"].ToString().Trim())
                            Row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString())) * (-1);
                        else
                            Row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));
                        DateTime _taxdate = (row.IsNull("tax_date")) ? DateTime.Parse("1900/01/01") : DateTime.Parse(row["tax_date"].ToString());
                        DateTime _taxdate2 = Convert.ToDateTime(Convert.ToString(_taxdate.Year) + "/07/02");
                        DateTime _taxedate = (row.IsNull("tax_edate")) ? DateTime.Parse("1900/01/01") : DateTime.Parse(row["tax_edate"].ToString());
                        DateTime _taxedate2 = Convert.ToDateTime(Convert.ToString(_taxedate.Year) + "/07/02");
                        DateTime _adate = DateTime.Parse(row1["adate"].ToString());
                        Row["p_183"] = "0";
                        if (bool.Parse(row["count_ma"].ToString()))
                        {
                            //if (_taxdate.Year == _adate.Year)
                            //{
                            //    if (Convert.ToDecimal(_taxdate.ToString("yyyyMMdd")) > Convert.ToDecimal(_taxdate2.ToString("yyyyMMdd")))
                            //        Row["p_183"] = "0";
                            //    else
                            //        Row["p_183"] = "1";
                            //}
                            //else if (_taxedate.Year == _adate.Year)
                            //{
                            //    if (Convert.ToDecimal(_taxedate.ToString("yyyyMMdd")) < Convert.ToDecimal(_taxedate2.ToString("yyyyMMdd")))
                            //        Row["p_183"] = "0";
                            //    else
                            //        Row["p_183"] = "1";
                            //}
                            //else
                            //    Row["p_183"] = "1";
                            if (_taxdate.Year == _adate.Year)
                            {
                                if (Convert.ToDecimal(_taxdate.ToString("yyyyMMdd")) > Convert.ToDecimal(_taxdate2.ToString("yyyyMMdd")))
                                    Row["p_183"] = "0";
                                else
                                    Row["p_183"] = "1";
                            }
                            else if (_taxedate.Year == _adate.Year)
                            {
                                if (Convert.ToDecimal(_taxedate.ToString("yyyyMMdd")) < Convert.ToDecimal(_taxedate2.ToString("yyyyMMdd")))
                                    Row["p_183"] = "0";
                                else
                                    Row["p_183"] = "1";
                            }
                            else
                                Row["p_183"] = "1";
                        }
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
                
                DataTable rq_wageda = new DataTable();
                rq_wageda.Columns.Add("nobr", typeof(string));
                rq_wageda.Columns.Add("taxrate", typeof(decimal));
                rq_wageda.Columns.Add("count_ma", typeof(bool));
                rq_wageda.Columns.Add("amt", typeof(int));
                rq_wageda.Columns.Add("p_183", typeof(string));
                rq_wageda.Columns.Add("inscomp", typeof(string));
                rq_wageda.Columns.Add("yymm", typeof(string));
                DataColumn[] _key4 = new DataColumn[5];
                _key4[0] = rq_wageda.Columns["nobr"];
                _key4[1] = rq_wageda.Columns["taxrate"];
                _key4[2] = rq_wageda.Columns["count_ma"];
                _key4[3] = rq_wageda.Columns["inscomp"];
                _key4[4] = rq_wageda.Columns["yymm"];
                rq_wageda.PrimaryKey = _key4;
                DataTable rq_wagedb = new DataTable();
                rq_wagedb = rq_wageda.Clone();
                rq_wagedb.TableName = "rq_wagedb";

                DataTable rq_zz4da = new DataTable();
                rq_zz4da.Columns.Add("nobr", typeof(string));
                rq_zz4da.Columns.Add("yymm", typeof(string));
                rq_zz4da.Columns.Add("count_ma", typeof(bool));
                rq_zz4da.Columns.Add("amt", typeof(int));
                rq_zz4da.PrimaryKey = new DataColumn[] { rq_zz4da.Columns["nobr"], rq_zz4da.Columns["yymm"] };
                foreach (DataRow Row in rq_waged.Rows)
                {
                    if (Row["sal_code"].ToString().Trim() != taxsalcode.Trim())
                    {
                        object[] _value = new object[5];
                        _value[0] = Row["nobr"].ToString();
                        _value[1] = decimal.Parse(Row["taxrate"].ToString());
                        _value[2] = bool.Parse(Row["count_ma"].ToString());
                        _value[3] = Row["inscomp"].ToString();
                        _value[4] = Row["yymm"].ToString();
                        DataRow row = rq_wageda.Rows.Find(_value);
                        if (row != null)
                        {
                            row["amt"] = int.Parse(row["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                        }
                        else
                        {
                            DataRow aRow = rq_wageda.NewRow();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["taxrate"] = decimal.Parse(Row["taxrate"].ToString());
                            aRow["count_ma"] = bool.Parse(Row["count_ma"].ToString());
                            aRow["amt"] = int.Parse(Row["amt"].ToString());
                            aRow["p_183"] = Row["p_183"].ToString();
                            aRow["amt"] = int.Parse(Row["amt"].ToString());
                            aRow["inscomp"] = Row["inscomp"].ToString();
                            aRow["yymm"] = Row["yymm"].ToString();
                            rq_wageda.Rows.Add(aRow);
                        }
                    }
                    else
                    {
                        object[] _value1 = new object[2];
                        _value1[0] = Row["nobr"].ToString();
                        _value1[1] = Row["yymm"].ToString();
                        DataRow row1 = rq_zz4da.Rows.Find(_value1);
                        if (row1 != null)
                        {
                            row1["amt"] = int.Parse(row1["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                        }
                        else
                        {
                            DataRow aRow1 = rq_zz4da.NewRow();
                            aRow1["nobr"] = Row["nobr"].ToString();
                            aRow1["yymm"] = Row["yymm"].ToString();
                            aRow1["count_ma"] = bool.Parse(Row["count_ma"].ToString());
                            aRow1["amt"] = int.Parse(Row["amt"].ToString());
                            rq_zz4da.Rows.Add(aRow1);
                        }
                    }
                }
                
                foreach (DataRow Row in rq_wageda.Rows)
                {
                    object[] _value1 = new object[2];
                    _value1[0] = Row["nobr"].ToString();
                    _value1[1] = Row["yymm"].ToString();

                    DataRow row = rq_zz4da.Rows.Find(_value1);
                    if (row != null)
                    {
                        if (taxtype.Trim()=="1" && decimal.Parse(Row["taxrate"].ToString())==1 && int.Parse(row["amt"].ToString())>0)
                            Row["taxrate"] = 0;
                    }
                    else
                    {
                        Row["taxrate"] = 0;
                    }
                    
                }

                foreach (DataRow Row in rq_waged.Rows)
                {
                    object[] _value1 = new object[2];
                    _value1[0] = Row["nobr"].ToString();
                    _value1[1] = Row["yymm"].ToString();
                    DataRow row = rq_zz4da.Rows.Find(_value1);
                    if (row != null)
                    {
                        if (taxtype.Trim() == "1" && decimal.Parse(Row["taxrate"].ToString()) == 1 && int.Parse(row["amt"].ToString()) > 0)
                            Row["taxrate"] = 0;
                    }
                    else
                    {
                        Row["taxrate"] = 0;
                    }
                    if (taxsalcode.Trim() != Row["sal_code"].ToString().Trim())
                        Row["amt"] = 0;
                    object[] _value = new object[5];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = decimal.Parse(Row["taxrate"].ToString());
                    _value[2] = bool.Parse(Row["count_ma"].ToString());
                    _value[3] = Row["inscomp"].ToString();
                    _value[4] = Row["yymm"].ToString();
                    DataRow row1 = rq_wagedb.Rows.Find(_value);
                    if (row1 != null)
                    {
                        row1["amt"] = int.Parse(row1["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                    }
                    else
                    {
                        DataRow aRow = rq_wagedb.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["taxrate"] = decimal.Parse(Row["taxrate"].ToString());
                        aRow["count_ma"] = bool.Parse(Row["count_ma"].ToString());
                        aRow["inscomp"] = Row["inscomp"].ToString();
                        aRow["amt"] = int.Parse(Row["amt"].ToString());
                        aRow["p_183"] = Row["p_183"].ToString();
                        aRow["yymm"] = Row["yymm"].ToString();
                        aRow["amt"] = int.Parse(Row["amt"].ToString());
                        rq_wagedb.Rows.Add(aRow);
                    }
                }

                DataTable rq_zz4db = new DataTable();
                rq_zz4db.Columns.Add("nobr", typeof(string));
                rq_zz4db.Columns.Add("inscomp", typeof(string));
                rq_zz4db.Columns.Add("taxrate", typeof(decimal));
                rq_zz4db.Columns.Add("count_ma", typeof(bool));
                rq_zz4db.Columns.Add("tolamt", typeof(int));
                rq_zz4db.Columns.Add("p_183", typeof(string));
                rq_zz4db.Columns.Add("yymm", typeof(string));

                DataColumn [] _key1 = new DataColumn[5];
                _key1[0] = rq_zz4db.Columns["nobr"];
                _key1[1] = rq_zz4db.Columns["count_ma"];
                _key1[2] = rq_zz4db.Columns["p_183"];
                _key1[3] = rq_zz4db.Columns["inscomp"];
                _key1[4] = rq_zz4db.Columns["yymm"];
                rq_zz4db.PrimaryKey = _key1;
                foreach (DataRow Row in rq_wageda.Rows)
                {
                    object[] _value = new object[5];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = bool.Parse(Row["count_ma"].ToString());
                    _value[2] = Row["p_183"].ToString();
                    _value[3] = Row["inscomp"].ToString();
                    _value[4] = Row["yymm"].ToString();
                    DataRow row = rq_zz4db.Rows.Find(_value);
                    if (row != null)
                        row["tolamt"] = int.Parse(row["tolamt"].ToString()) + int.Parse(Row["amt"].ToString());
                    else
                    {
                        DataRow aRow = rq_zz4db.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["count_ma"] = bool.Parse(Row["count_ma"].ToString());
                        aRow["p_183"] = Row["p_183"].ToString();
                        aRow["taxrate"] = decimal.Parse(Row["taxrate"].ToString());
                        aRow["tolamt"] = int.Parse(Row["amt"].ToString());
                        aRow["inscomp"] = Row["inscomp"].ToString();
                        aRow["yymm"] = Row["yymm"].ToString();
                        rq_zz4db.Rows.Add(aRow);
                    }
                }
                
                DataTable rq_zz4dc = new DataTable();
                rq_zz4dc.Columns.Add("taxrate", typeof(decimal));
                rq_zz4dc.Columns.Add("count_ma", typeof(bool));
                rq_zz4dc.Columns.Add("p_183", typeof(string));
                rq_zz4dc.Columns.Add("p_no", typeof(int));
                rq_zz4dc.Columns.Add("taxamt", typeof(int));
                rq_zz4dc.Columns.Add("inscomp", typeof(string));
                rq_zz4dc.Columns.Add("yymm", typeof(string));
                DataColumn[] _key5 = new DataColumn[5];
                _key5[0] = rq_zz4dc.Columns["taxrate"];
                _key5[1] = rq_zz4dc.Columns["count_ma"];
                _key5[2] = rq_zz4dc.Columns["p_183"];
                _key5[3] = rq_zz4dc.Columns["inscomp"];
                _key5[4] = rq_zz4dc.Columns["yymm"];
                rq_zz4dc.PrimaryKey = _key5;
                foreach (DataRow Row in rq_wagedb.Rows)
                {
                    object[] _value = new object[5];
                    _value[0] = decimal.Parse(Row["taxrate"].ToString());
                    _value[1] = bool.Parse(Row["count_ma"].ToString());
                    _value[2] = Row["p_183"].ToString();
                    _value[3] = Row["inscomp"].ToString();
                    _value[4] = Row["yymm"].ToString();
                    DataRow row = rq_zz4dc.Rows.Find(_value);
                    if (row != null)
                    {
                        row["taxamt"] = int.Parse(row["taxamt"].ToString()) + int.Parse(Row["amt"].ToString());
                        row["p_no"] = int.Parse(row["p_no"].ToString()) + 1;
                    }
                    else
                    {
                        DataRow aRow = rq_zz4dc.NewRow();
                        aRow["taxrate"] = decimal.Parse(Row["taxrate"].ToString());
                        aRow["count_ma"] = bool.Parse(Row["count_ma"].ToString());
                        aRow["taxamt"] = int.Parse(Row["amt"].ToString());
                        aRow["p_183"] = Row["p_183"].ToString();
                        aRow["p_no"] = 1;
                        aRow["inscomp"] = Row["inscomp"].ToString();
                        aRow["yymm"] = Row["yymm"].ToString();
                        rq_zz4dc.Rows.Add(aRow);
                    }
                }
               
                //應稅總額
                
                DataColumn[] _key2 = new DataColumn[5];
                _key2[0] = ds.Tables["zz4m"].Columns["taxrate"];
                _key2[1] = ds.Tables["zz4m"].Columns["count_ma"];
                _key2[2] = ds.Tables["zz4m"].Columns["p_183"];
                _key2[3] = ds.Tables["zz4m"].Columns["inscomp"];
                _key2[4] = ds.Tables["zz4m"].Columns["yymm"];
                ds.Tables["zz4m"].PrimaryKey = _key2;
                DataRow[] ORow = rq_zz4db.Select("", "taxrate asc");
                foreach (DataRow Row in ORow)
                {
                    object[] _value = new object[5];
                    _value[0] = decimal.Parse(Row["taxrate"].ToString());
                    _value[1] = bool.Parse(Row["count_ma"].ToString());
                    _value[2] = Row["p_183"].ToString();
                    _value[3] = Row["inscomp"].ToString();
                    _value[4] = Row["yymm"].ToString();
                    DataRow row = ds.Tables["zz4m"].Rows.Find(_value);
                    DataRow row1 = rq_zz4dc.Rows.Find(_value);
                    if (row != null)
                        row["tol_amt"] = int.Parse(row["tol_amt"].ToString()) + int.Parse(Row["tolamt"].ToString());
                    else
                    {
                        DataRow aRow = ds.Tables["zz4m"].NewRow();
                        aRow["taxrate"] = decimal.Parse(Row["taxrate"].ToString());
                        aRow["count_ma"] = bool.Parse(Row["count_ma"].ToString());
                        aRow["tol_amt"] = int.Parse(Row["tolamt"].ToString());
                        aRow["tax_amt"] = (row1 != null) ? int.Parse(row1["taxamt"].ToString()) : 0;
                        aRow["p_no"] = (row1 != null) ? int.Parse(row1["p_no"].ToString()) : 0;
                        aRow["p_183"] = Row["p_183"].ToString();
                        aRow["inscomp"] = Row["inscomp"].ToString();
                        aRow["yymm"] = Row["yymm"].ToString();
                        if (taxtype.Trim() == "1")
                        {
                            if (decimal.Parse(Row["taxrate"].ToString()) == Convert.ToDecimal(0.13))
                            {
                                aRow["desc"] = "固定薪資按扣繳稅額表扣繳";
                                aRow["code"] = "A";
                            }
                            else if (decimal.Parse(Row["taxrate"].ToString()) == Convert.ToDecimal(0.21))
                            {
                                aRow["desc"] = "固定薪資按扣繳稅額表扣繳";
                                aRow["code"] = "A";
                            }
                            else if (decimal.Parse(Row["taxrate"].ToString()) == Convert.ToDecimal(0.3))
                            {
                                aRow["desc"] = "固定薪資按扣繳稅額表扣繳";
                                aRow["code"] = "A";
                            }
                            else if (decimal.Parse(Row["taxrate"].ToString()) == Convert.ToDecimal(0.06))
                            {
                                aRow["desc"] = "非固定薪資及兼職薪資一律按 6%扣繳";
                                aRow["code"] = "B";
                            }
                            else if (decimal.Parse(Row["taxrate"].ToString()) == Convert.ToDecimal(0.20))
                            {
                                aRow["desc"] = "給付非中華民國境內居住之個人薪資一律按 18%扣繳";
                                aRow["code"] = "C";
                            }
                            else if (decimal.Parse(Row["taxrate"].ToString()) == Convert.ToDecimal(0))
                            {
                                aRow["desc"] = "免扣繳人數";
                                aRow["code"] = "D";
                            }
                        }
                        else
                        {
                            //if (decimal.Parse(Row["taxrate"].ToString()) == Convert.ToDecimal(1))
                            //{
                            //    aRow["desc"] = "固定薪資按扣繳稅額表扣繳";
                            //    aRow["code"] = "C";
                            //}
                            //else if (decimal.Parse(Row["taxrate"].ToString()) == Convert.ToDecimal(0))
                            //{
                            //    aRow["desc"] = "免扣繳人數";
                            //    aRow["code"] = "A";
                            //}
                            //else if (decimal.Parse(Row["taxrate"].ToString()) == Convert.ToDecimal(0.06) && bool.Parse(Row["count_ma"].ToString()) && Row["p_183"].ToString() == "0")
                            //{
                            //    aRow["desc"] = "給付非中華民國境內居住之個人薪資 6%扣繳(未滿183天)";
                            //    aRow["code"] = "D";
                            //}
                            //else if (decimal.Parse(Row["taxrate"].ToString()) == Convert.ToDecimal(0.06))
                            //{
                            //    aRow["desc"] = (bool.Parse(Row["count_ma"].ToString())) ? "外籍" : "本籍";
                            //    aRow["code"] = "C";
                            //}                            
                            //else if (decimal.Parse(Row["taxrate"].ToString()) == Convert.ToDecimal(0.20) && bool.Parse(Row["count_ma"].ToString()) && Row["p_183"].ToString() == "0")
                            //{
                            //    aRow["desc"] = "給付非中華民國境內居住之個人薪資 18%扣繳";
                            //    aRow["code"] = "D";
                            //}
                            if (decimal.Parse(Row["taxrate"].ToString()) == Convert.ToDecimal(1))
                            {
                                aRow["desc"] = "固定薪資按扣繳稅額表扣繳";
                                aRow["code"] = "C";
                            }
                            else if (decimal.Parse(Row["taxrate"].ToString()) == Convert.ToDecimal(0))
                            {
                                aRow["desc"] = "免扣繳人數";
                                aRow["code"] = "A";
                            }
                            else if (decimal.Parse(Row["taxrate"].ToString()) == fixtaxrate && !bool.Parse(Row["count_ma"].ToString()))
                            {
                                aRow["desc"] = "本籍";
                                aRow["code"] = "C";
                            }
                            //else if (decimal.Parse(Row["taxrate"].ToString()) == Convert.ToDecimal(0.06) && bool.Parse(Row["count_ma"].ToString()) && Row["p_183"].ToString() == "0")
                            //Row["p_183"].ToString() == "1"超過183天
                            else if (decimal.Parse(Row["taxrate"].ToString()) == fortaxrate02 && bool.Parse(Row["count_ma"].ToString()) && Row["p_183"].ToString() == "1")
                            {
                                //aRow["desc"] = "給付非中華民國境內居住之個人薪資 " + Convert.ToString(fortaxrate01 * 100) + "%扣繳(未滿183天)";
                                aRow["desc"] = "給付中華民國境內居住之個人薪資 " + Convert.ToString(fortaxrate02 * 100) + "%扣繳";
                                aRow["code"] = "D";
                            }
                            else if (decimal.Parse(Row["taxrate"].ToString()) == fortaxrate03)
                            {
                                aRow["desc"] = (bool.Parse(Row["count_ma"].ToString())) ? "給付非中華民國境內居住之個人薪資 " + Convert.ToString(fortaxrate03 * 100) : "本籍";
                                aRow["code"] = "D";
                            }
                            else if (decimal.Parse(Row["taxrate"].ToString()) == fortaxrate01 && bool.Parse(Row["count_ma"].ToString()) && Row["p_183"].ToString() == "0")
                            {
                                aRow["desc"] = "給付非中華民國境內居住之個人薪資 " + Convert.ToString(fortaxrate01 * 100) + "%扣繳";
                                aRow["code"] = "D";
                            }
                        }
                        ds.Tables["zz4m"].Rows.Add(aRow);
                    }                   
                }
                
                rq_salcode = null; rq_usys9 = null; rq_wage = null;
                rq_waged = null; rq_wageda = null; rq_wagedb = null; rq_zz4da = null;
                rq_zz4db = null; rq_zz4dc = null;

                if (ds.Tables["zz4m"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                //二代健保費率
                DataTable rq_sys5 = SqlConn.GetDataTable("select suppleinslabrate from u_sys5 where comp='" + CompID + "'");
                decimal _supplerate = 0;
                if (rq_sys5.Rows.Count > 0)
                    _supplerate = decimal.Parse(rq_sys5.Rows[0]["suppleinslabrate"].ToString());

                //二代健保補充保費雇主負擔
                string sqlCmd5 = "select s_no,nobr,h_amt,out_date from inslab where nobr+fa_idno+convert(char,in_date,112) in";
                sqlCmd5 += " (select nobr+fa_idno+max(convert(char,in_date,112)) from inslab a,harcode b";
                sqlCmd5 += " where a.hrate_code=b.rate_code";
                sqlCmd5 += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd5 += string.Format(@" and in_date<='{0}'", date_b);
                sqlCmd5 += " and fa_idno='' and b.compcharge>0 group by nobr,fa_idno)";
                sqlCmd5 += string.Format(@" and '{0}' between in_date and out_date", date_b);
                sqlCmd5 += " order by nobr";
                DataTable rq_inslab = SqlConn.GetDataTable(sqlCmd5);
                rq_inslab.Columns.Add("indt", typeof(DateTime));
                bool firstcnt = bool.Parse("true"); int _hamt = 0;
                ds.Tables["zz4ma"].PrimaryKey = new DataColumn[] { ds.Tables["zz4ma"].Columns["s_no"] };
                DataTable rq_zz4ma = new DataTable();
                rq_zz4ma = ds.Tables["zz4ma"].Clone();
                foreach (DataRow Row in rq_inslab.Rows)
                {
                    DataRow row1 = rq_base.Rows.Find(Row["nobr"].ToString());
                    string _baseindt = ""; string _outdate = "";
                    if (row1 != null)
                    {
                        _baseindt = DateTime.Parse(row1["indt"].ToString()).ToString("yyyyMM");
                        Row["indt"] = DateTime.Parse(row1["indt"].ToString());

                        _outdate = DateTime.Parse(Row["out_date"].ToString()).ToString("yyyyMM");
                        if (_outdate != "999912" && _baseindt != _outdate)
                            Row["h_amt"] = 0;
                        else
                            Row["h_amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["h_amt"].ToString()));
                        _hamt += int.Parse(Row["h_amt"].ToString());
                        DataRow row = rq_zz4ma.Rows.Find(Row["s_no"].ToString());
                        if (row != null)
                        {
                            row["tol_hamt"] = int.Parse(row["tol_hamt"].ToString()) + int.Parse(Row["h_amt"].ToString());
                            //row["suppleamt"] = Math.Round((_tol_amt - int.Parse(row["tol_hamt"].ToString())) * _supplerate, MidpointRounding.AwayFromZero);                          
                        }
                        else
                        {
                            DataRow aRow = rq_zz4ma.NewRow();
                            aRow["s_no"] = Row["s_no"].ToString();
                            aRow["tol_amt"] = 0;
                            aRow["tol_hamt"] = int.Parse(Row["h_amt"].ToString());
                            //aRow["suppleamt"] = Math.Round((_tol_amt - int.Parse(aRow["tol_hamt"].ToString())) * _supplerate, MidpointRounding.AwayFromZero);
                            aRow["suppleamt"] = 0;
                            rq_zz4ma.Rows.Add(aRow);
                        }
                    }
                    
                }                

                foreach (DataRow Row in ds.Tables["zz4m"].Rows)
                {
                    DataRow row = rq_zz4ma.Rows.Find(Row["inscomp"].ToString());
                    if (row != null)
                    {
                        row["tol_amt"] = int.Parse(row["tol_amt"].ToString()) + int.Parse(Row["tol_amt"].ToString());
                        row["suppleamt"] = Math.Round((int.Parse(row["tol_amt"].ToString()) - int.Parse(row["tol_hamt"].ToString())) * _supplerate, MidpointRounding.AwayFromZero);
                        if (int.Parse(row["suppleamt"].ToString()) <= 0)
                            row["suppleamt"] = 0;                        
                    }
                    else
                    {
                        DataRow aRow = rq_zz4ma.NewRow();
                        aRow["s_no"] = Row["inscomp"].ToString();
                        aRow["tol_amt"] = int.Parse(Row["tol_amt"].ToString());
                        aRow["tol_hamt"] = 0;
                        aRow["suppleamt"] = Math.Round(int.Parse(Row["tol_amt"].ToString()) * _supplerate, MidpointRounding.AwayFromZero);
                        rq_zz4ma.Rows.Add(aRow);
                    }
                }

                foreach (DataRow Row in rq_zz4ma.Rows)
                {
                    int aa = int.Parse(Row["tol_hamt"].ToString());
                    if (int.Parse(Row["tol_amt"].ToString()) > 1)
                        ds.Tables["zz4ma"].ImportRow(Row);
                }

                rq_inslab = null; rq_sys5 = null; rq_base = null; rq_zz4ma = null;
                
                if (exportexcel)
                {
                    Export(ds.Tables["zz4m"]);
                    //if (reporttype=="0")
                    //    Export(ds.Tables["zz4m"]);
                    //else
                    //    Export(ds.Tables["zz4ma"]);
                    this.Close();
                }
                else
                {
                    string company = ""; string JBVersion = "";
                    if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                    {
                        JBVersion += System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
                    }
                    DataTable rq_sys = ReportClass.GetU_Sys();
                    //if (rq_sys.Rows.Count > 0)
                    //    company = rq_sys.Rows[0]["company"].ToString();
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "SalReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "SalReport", "*.rdlc");
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz4m.rdlc";                   
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("JBVersion", JBVersion) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYMMB", yymm_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYMME", yymm_e) }); 
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4m", ds.Tables["zz4m"]));
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4ma", ds.Tables["zz4ma"]));
                    
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
            ExporDt.Columns.Add("薪資年月", typeof(string));
            ExporDt.Columns.Add("稅率", typeof(decimal));
            ExporDt.Columns.Add("稅率扣繳說明", typeof(string));
            ExporDt.Columns.Add("國別", typeof(string));
            ExporDt.Columns.Add("人數", typeof(int));
            ExporDt.Columns.Add("給付所得總額", typeof(int));
            ExporDt.Columns.Add("應扣繳稅額", typeof(int));           
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["薪資年月"] = Row01["yymm"].ToString();
                aRow["稅率"] = decimal.Parse(Row01["taxrate"].ToString());
                aRow["稅率扣繳說明"] = Row01["desc"].ToString();
                aRow["國別"] = (bool.Parse(Row01["count_ma"].ToString())) ? "外籍" : "本籍";
                aRow["人數"] = int.Parse(Row01["p_no"].ToString());
                aRow["給付所得總額"] = int.Parse(Row01["tol_amt"].ToString());
                aRow["應扣繳稅額"] = int.Parse(Row01["tax_amt"].ToString());               
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
            ////JBModule.Data.CExcel.GenerateHtml("C:\\TEMP\\" + this.Name + ".xls", ExporDt, true);
            //JBModule.Data.CNPOI.RenderDataTableToExcel(ExporDt, "C:\\TEMP\\" + this.Name + ".xls");
            //System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }

        void Export1(DataTable DT)
        {
            DataTable ExporDt = new DataTable();

            ExporDt.Columns.Add("給付薪資所得總額", typeof(int));
            ExporDt.Columns.Add("健保投保總額", typeof(int));
            ExporDt.Columns.Add("雇主負擔補充保費", typeof(int));
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["給付薪資所得總額"] = int.Parse(Row01["tol_amt"].ToString());
                aRow["健保投保總額"] = int.Parse(Row01["tol_hamt"].ToString());
                aRow["雇主負擔補充保費"] = int.Parse(Row01["suppleamt"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
            //JBModule.Data.CNPOI.RenderDataTableToExcel(ExporDt, "C:\\TEMP\\" + this.Name + ".xls");
            //System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }
    }
}
