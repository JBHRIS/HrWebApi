/* ======================================================================================================
 * 功能名稱：發放薪資報表
 * 功能代號：ZZ42
 * 功能路徑：報表列印 > 薪資 > 發放薪資報表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ42_Report.cs
 * 功能用途：
 *  用於產出發放薪資報表
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/10/20    Daniel Chih    Ver 1.0.01     1. 修正健保對帳單眷屬人數的語法
 * 
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/10/20
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

namespace JBHR.Reports.InsForm
{
    public partial class ZZ3A_Report : JBControls.JBForm
    {
        InsDataSet ds = new InsDataSet();
        string nobr_b, nobr_e, dept_b, dept_e, date_b, date_e, sno_b, sno_e, reporttype, type_data, comp_name, CompId;
        bool exportexcel;
        public ZZ3A_Report(string nobrb, string nobre, string deptb, string depte, string dateb, string datee, string snob, string snoe, string _reporttype, string typedata, bool _exportexcel, string compname, string _CompId)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; date_b = dateb; date_e = datee;
            sno_b = snob; sno_e = snoe; reporttype = _reporttype; CompId = _CompId;
            exportexcel = _exportexcel; type_data = typedata; comp_name = compname;
        }

        private void ZZ3A_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select b.nobr,a.name_c,a.name_e,a.idno,b.indt,c.d_no_disp as dept from base a,basetts b";
                sqlCmd += " left outer join dept c on b.dept=c.d_no";
                sqlCmd += " where a.nobr=b.nobr";
                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd += type_data;
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };
                string sqlCmd1 = "select a.* from inslab a ";
                sqlCmd1 += " left outer join inscomp b on a.s_no=b.s_no";
                sqlCmd1 += string.Format(@" where a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);

                if (reporttype == "0")
                {
                    sqlCmd1 += string.Format(@" and '{0}' between a.in_date and a.out_date", date_e);
                    sqlCmd1 += string.Format(@" and b.s_no_disp between '{0}' and '{1}'", sno_b, sno_e);
                    sqlCmd1 += string.Format(@" and a.in_date <'{0}'", date_b);
                    sqlCmd1 += string.Format(@" and a.out_date <> '{0}'", date_e);
                    sqlCmd1 += " and a.fa_idno=''";
                }
                else if (reporttype == "1")
                {
                    sqlCmd1 += string.Format(@" and (a.in_date between '{0}' and '{1}'", date_b, date_e);
                    sqlCmd1 += string.Format(@" or a.out_date between '{0}' and '{1}' )", date_b, date_e);
                    sqlCmd1 += string.Format(@" and b.s_no_disp between '{0}' and '{1}'", sno_b, sno_e);
                    sqlCmd1 += " and a.fa_idno=''";
                }
                else
                {
                    sqlCmd1 += string.Format(@" and (a.in_date between '{0}' and '{1}'", date_b, date_e);
                    sqlCmd1 += string.Format(@" or a.out_date between '{0}' and '{1}' )", date_b, date_e);
                    sqlCmd1 += string.Format(@" and b.s_no_disp between '{0}' and '{1}'", sno_b, sno_e);
                }
                DataTable rq_inslab = SqlConn.GetDataTable(sqlCmd1);

                if (reporttype != "2")
                {
                    rq_inslab.Columns.Add("name_c", typeof(string));
                    rq_inslab.Columns.Add("name_e", typeof(string));
                    rq_inslab.Columns.Add("idno", typeof(string));
                    rq_inslab.Columns.Add("insday", typeof(int));
                    rq_inslab.Columns.Add("perexp", typeof(int));
                    rq_inslab.Columns.Add("jobexp", typeof(int));
                    rq_inslab.Columns.Add("fundexp", typeof(int));
                    rq_inslab.Columns.Add("norexp", typeof(int));
                    rq_inslab.Columns.Add("compexp", typeof(int));
                    rq_inslab.Columns.Add("losexp", typeof(int));
                    rq_inslab.Columns.Add("lrate_name", typeof(string));
                    DataTable rq_family = SqlConn.GetDataTable("select nobr,fa_idno,fa_name,fa_birdt from family");
                    rq_family.PrimaryKey = new DataColumn[] { rq_family.Columns["nobr"], rq_family.Columns["fa_idno"] };
                    DataTable rq_larcode = SqlConn.GetDataTable("select * from larcode");
                    rq_larcode.PrimaryKey = new DataColumn[] { rq_larcode.Columns["rate_code"] };
                    foreach (DataRow Row in rq_inslab.Rows)
                    {
                        Row["insday"] = 30;
                        decimal str_normal = 0;
                        decimal str_losjob = 0;
                        decimal str_self = 0;
                        decimal str_partial = 0;
                        decimal str_compcharge = 0;
                        decimal str_jobaccrate = 0;
                        decimal str_lamt = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["l_amt"].ToString()));

                        DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                        if (row != null)
                        {
                            DataRow row1 = rq_larcode.Rows.Find(Row["lrate_code"].ToString());
                            DateTime outdate = DateTime.Parse(Row["out_date"].ToString());
                            DateTime indate = DateTime.Parse(Row["in_date"].ToString());
                            DateTime _dateb = DateTime.Parse(date_b);
                            DateTime _datee = DateTime.Parse(date_e);
                            int aa = int.Parse(outdate.ToString("yyyyMMdd"));
                            int bb = int.Parse(_dateb.ToString("yyyyMMdd"));
                            int cc = int.Parse(indate.ToString("yyyyMMdd"));
                            int dd = int.Parse(_datee.ToString("yyyyMMdd"));
                            if (Convert.ToInt32(outdate.ToString("yyyyMMdd")) >= Convert.ToInt32(_dateb.ToString("yyyyMMdd")) && Convert.ToInt32(outdate.ToString("yyyyMMdd")) <= Convert.ToInt32(_datee.ToString("yyyyMMdd")) && !(Convert.ToInt32(indate.ToString("yyyyMMdd")) >= Convert.ToInt32(_dateb.ToString("yyyyMMdd")) && Convert.ToInt32(indate.ToString("yyyyMMdd")) <= Convert.ToInt32(_datee.ToString("yyyyMMdd"))))
                                Row["insday"] = outdate.Day;
                            if (Convert.ToInt32(outdate.ToString("yyyyMMdd")) >= Convert.ToInt32(_dateb.ToString("yyyyMMdd")) && Convert.ToInt32(outdate.ToString("yyyyMMdd")) <= Convert.ToInt32(_datee.ToString("yyyyMMdd")) && (Convert.ToInt32(indate.ToString("yyyyMMdd")) >= Convert.ToInt32(_dateb.ToString("yyyyMMdd")) && Convert.ToInt32(indate.ToString("yyyyMMdd")) <= Convert.ToInt32(_datee.ToString("yyyyMMdd"))))
                                Row["insday"] = ((TimeSpan)(outdate - indate)).Days + 1;
                            if (!(Convert.ToInt32(outdate.ToString("yyyyMMdd")) >= Convert.ToInt32(_dateb.ToString("yyyyMMdd")) && Convert.ToInt32(outdate.ToString("yyyyMMdd")) <= Convert.ToInt32(_datee.ToString("yyyyMMdd"))) && Convert.ToInt32(indate.ToString("yyyyMMdd")) >= Convert.ToInt32(_dateb.ToString("yyyyMMdd")) && Convert.ToInt32(indate.ToString("yyyyMMdd")) <= Convert.ToInt32(_datee.ToString("yyyyMMdd")))
                                Row["insday"] = ((TimeSpan)(_datee - indate)).Days + 1;
                            if (!(Convert.ToInt32(outdate.ToString("yyyyMMdd")) >= Convert.ToInt32(_dateb.ToString("yyyyMMdd")) && Convert.ToInt32(outdate.ToString("yyyyMMdd")) <= Convert.ToInt32(_datee.ToString("yyyyMMdd"))) && Convert.ToInt32(indate.ToString("yyyyMMdd")) >= Convert.ToInt32(_dateb.ToString("yyyyMMdd")) && Convert.ToInt32(indate.ToString("yyyyMMdd")) <= Convert.ToInt32(_datee.ToString("yyyyMMdd")))
                                Row["insday"] = 30 - indate.Day + 1;
                            if (Convert.ToInt32(indate.ToString("yyyyMMdd")) <= Convert.ToInt32(_dateb.ToString("yyyyMMdd")) && Convert.ToInt32(outdate.ToString("yyyyMMdd")) == Convert.ToInt32(_datee.ToString("yyyyMMdd")))
                                Row["insday"] =30;
                            if (int.Parse(Row["insday"].ToString()) > 30)
                                Row["insday"] = 30;
                            //if (Convert.ToInt32(outdate.ToString("yyyyMMdd")) != Convert.ToInt32(_datee.ToString("yyyyMMdd")) && Convert.ToInt32(outdate.ToString("yyyyMMdd")) >= Convert.ToInt32(_dateb.ToString("yyyyMMdd")) && Convert.ToInt32(outdate.ToString("yyyyMMdd")) <= Convert.ToInt32(_datee.ToString("yyyyMMdd")))
                            //    Row["insday"] = 0;
                            decimal str_insday = decimal.Parse(Row["insday"].ToString());
                            Row["name_c"] = row["name_c"].ToString();
                            Row["name_e"] = row["name_e"].ToString();
                            Row["idno"] = row["idno"].ToString();
                            Row["l_amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["l_amt"].ToString()));
                            Row["h_amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["h_amt"].ToString()));
                            Row["r_amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["r_amt"].ToString()));
                            if (row1 != null)
                            {
                                str_normal = decimal.Parse(row1["normalrate"].ToString());
                                str_losjob = decimal.Parse(row1["losjobrate"].ToString());
                                str_self = decimal.Parse(row1["selfcharge"].ToString());
                                str_partial = decimal.Parse(row1["partial"].ToString());
                                str_compcharge = decimal.Parse(row1["compcharge"].ToString());
                                str_jobaccrate = decimal.Parse(row1["jobaccrate"].ToString());
                                Row["perexp"] = Math.Round(str_lamt * str_normal * str_self * str_partial * str_insday / 30, MidpointRounding.AwayFromZero) + Math.Round(str_lamt * str_losjob * str_self * str_partial * str_insday / 30, MidpointRounding.AwayFromZero);
                                Row["norexp"] = Math.Round(str_lamt * str_normal * str_insday * str_compcharge / 30, MidpointRounding.AwayFromZero);
                                Row["losexp"] = Math.Round(str_lamt * str_losjob * str_insday * str_compcharge / 30, MidpointRounding.AwayFromZero);
                                Row["jobexp"] = Math.Round(str_lamt * str_insday * str_jobaccrate / 30, MidpointRounding.AwayFromZero);
                                Row["fundexp"] = (str_insday >= 28) ? Math.Round(str_lamt * Convert.ToDecimal(0.00025), MidpointRounding.AwayFromZero) : Math.Round(Math.Round(str_lamt * Convert.ToDecimal(0.00025), MidpointRounding.AwayFromZero) * str_insday / 30, MidpointRounding.AwayFromZero);
                                //Row["compexp"] = int.Parse(Row["norexp"].ToString()) + int.Parse(Row["losexp"].ToString()) + int.Parse(Row["jobexp"].ToString());
                                Row["compexp"] = Math.Round(str_lamt * (str_normal + str_losjob) * str_compcharge * str_insday / 30, MidpointRounding.AwayFromZero) + Math.Round(str_lamt * str_insday * str_jobaccrate / 30, MidpointRounding.AwayFromZero) + int.Parse(Row["fundexp"].ToString());
                                Row["lrate_name"] = row1["rate_name"].ToString();
                            }

                        }
                        else
                            Row.Delete();
                    }
                    rq_family = null; rq_larcode = null;
                }
                else
                {
                    rq_inslab.Columns.Add("dept", typeof(string));
                    rq_inslab.Columns.Add("hrate_name", typeof(string));
                    rq_inslab.Columns.Add("h_exp", typeof(int));
                    rq_inslab.Columns.Add("h_exp1", typeof(int));
                    rq_inslab.Columns.Add("zero", typeof(bool));
                    DataTable rq_harcode = SqlConn.GetDataTable("select * from harcode");
                    rq_harcode.PrimaryKey = new DataColumn[] { rq_harcode.Columns["rate_code"] };
                    DataTable rq_sys5 = SqlConn.GetDataTable("select compersoncnt,heacomprate from u_sys5 where comp='" + CompId + "'");
                    decimal compersoncnt = (rq_sys5.Rows.Count > 0) ? decimal.Parse(rq_sys5.Rows[0]["compersoncnt"].ToString()) : 0;
                    decimal heacomprate = (rq_sys5.Rows.Count > 0) ? decimal.Parse(rq_sys5.Rows[0]["heacomprate"].ToString()) : 0;
                    string str_nobr1 = ""; int _i = 0;
                    foreach (DataRow Row in rq_inslab.Rows)
                    {
                        Row["h_amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["h_amt"].ToString())); ;
                        decimal str_hcompcharge = 0;
                        decimal str_hpartial = 0;
                        decimal str_selfcharge = 0;
                        decimal str_hamt = decimal.Round(decimal.Parse(Row["h_amt"].ToString()), 0);
                        decimal _nopaytop = 0;
                        
                        DataRow row1 = rq_harcode.Rows.Find(Row["hrate_code"].ToString());
                        DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                        if (row != null)
                        {
                            Row["dept"] = row["dept"].ToString();
                            Int32 _outdate = Convert.ToInt32(DateTime.Parse(Row["out_date"].ToString()).ToString("yyyyMMdd"));
                            Int32 _datee1 = Convert.ToInt32(DateTime.Parse(date_e).AddDays(-1).ToString("yyyyMMdd"));
                            Int32 _dateb1 = Convert.ToInt32(DateTime.Parse(date_b).ToString("yyyyMMdd"));
                            Int32 _indate = Convert.ToInt32(DateTime.Parse(Row["in_date"].ToString()).ToString("yyyyMMdd"));
                            Int32 _indt = Convert.ToInt32(DateTime.Parse(row["indt"].ToString()).ToString("yyyyMMdd"));
                            if (_indate < _dateb1 && _outdate < _datee1)
                                Row.Delete();
                            else if (_outdate >= _dateb1 && _outdate <= _datee1 && _indt != _indate && _indate >= _dateb1 && _indate <= _datee1)
                                Row.Delete();
                            //刪除當月進當月初可是是調整者中途退保人士,但不等於當用進出者
                            else if (row1 != null)
                            {                                
                                str_hcompcharge = decimal.Parse(row1["compcharge"].ToString());
                                str_hpartial = decimal.Parse(row1["partial"].ToString());
                                str_selfcharge = decimal.Parse(row1["selfcharge"].ToString());
                                Row["hrate_name"] = row1["rate_name"].ToString();                                
                                _nopaytop = decimal.Parse(row1["nopaytop"].ToString());                                
                                Row["h_exp1"] = (Row["fa_idno"].ToString().Trim() == "") ? Math.Round(str_hamt * str_hcompcharge * compersoncnt * heacomprate, MidpointRounding.AwayFromZero) : 0;                                
                                //Row["h_exp"] = (int)(Math.Round(str_hamt * str_selfcharge * heacomprate, MidpointRounding.AwayFromZero) * str_hpartial);
                                //99/4/1健保費率調漲
                                decimal str_effrate = 0;
                                string sqlCmdb = "select amt,eff_rate from insurlv where";
                                sqlCmdb += string.Format(@" '{0}' between  eff_dateh and lff_dateh", DateTime.Parse(Row["in_date"].ToString()).ToString("yyyy/MM/dd"));
                                sqlCmdb += string.Format(@" and amt={0}", decimal.Parse(Row["h_amt"].ToString()));
                                DataTable rq_insurlv = SqlConn.GetDataTable(sqlCmdb);
                                if (rq_insurlv.Rows.Count > 0) str_effrate = decimal.Parse(rq_insurlv.Rows[0]["eff_rate"].ToString());
                                rq_insurlv.Clear();
                                Row["h_exp"] = (int)(Math.Round(str_hamt * str_selfcharge * str_effrate, MidpointRounding.AwayFromZero) * str_hpartial);
                                //&&有輔助上限且自負額小於輔助上限
                                if (int.Parse(Row["h_exp"].ToString()) < _nopaytop && _nopaytop != 0) Row["h_exp"] = 0;
                                //&&有輔助上限且自負額大於輔助上限
                                if (int.Parse(Row["h_exp"].ToString()) > _nopaytop && _nopaytop != 0) Row["h_exp"] = int.Parse(Row["h_exp"].ToString()) - _nopaytop;

                                Row["zero"] = bool.Parse("false");
                                string str_nobr = Row["nobr"].ToString();
                                if (Row["fa_idno"].ToString().Trim() != "")
                                {
                                    if (str_nobr == str_nobr1)
                                        _i++;
                                    else
                                        _i = 0;
                                }
                                else
                                    _i = 0;
                                if (_i > 3)
                                {
                                    Row["zero"] = bool.Parse("true");
                                    Row["hrate_code"] = "ZZ";
                                    Row["hrate_name"] = "第四口人費用免計";
                                }
                                str_nobr1 = Row["nobr"].ToString();
                            }
                        }
                        else
                            Row.Delete();
                    }
                    
                    rq_harcode = null; rq_sys5 = null;
                }
                rq_inslab.AcceptChanges();
                if (rq_inslab.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                //JBModule.Data.CNPOI.RenderDataTableToExcel(rq_inslab, "C:\\TEMP\\" + this.Name + "a.xls");
                //System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + "a.xls");
                if (reporttype == "0")
                {
                    DataColumn[] _key = new DataColumn[3];
                    _key[0] = ds.Tables["zz3a"].Columns["s_no"];
                    _key[1] = ds.Tables["zz3a"].Columns["l_amt"];
                    _key[2] = ds.Tables["zz3a"].Columns["lrate_code"];
                    ds.Tables["zz3a"].PrimaryKey = _key;
                    DataRow[] SRow = rq_inslab.Select("", "s_no,l_amt,lrate_code asc");
                    foreach (DataRow Row in SRow)
                    {
                        object[] _value = new object[3];
                        _value[0] = Row["s_no"].ToString().Trim() ;
                        _value[1] = decimal.Round(decimal.Parse(Row["l_amt"].ToString()), 0);
                        _value[2] = Row["lrate_code"].ToString();
                        DataRow row = ds.Tables["zz3a"].Rows.Find(_value);
                        if (row != null)
                        {                            
                            row["norexp"] = int.Parse(row["norexp"].ToString()) + int.Parse(Row["norexp"].ToString());
                            row["losexp"] = int.Parse(row["losexp"].ToString()) + int.Parse(Row["losexp"].ToString());
                            row["jobexp"] = int.Parse(row["jobexp"].ToString()) + int.Parse(Row["jobexp"].ToString());
                            row["fundexp"] = int.Parse(row["fundexp"].ToString()) + int.Parse(Row["fundexp"].ToString());                           
                            row["p_no"] = int.Parse(row["p_no"].ToString()) + 1;
                        }
                        else
                        {
                            DataRow aRow = ds.Tables["zz3a"].NewRow();
                            aRow["s_no"] = Row["s_no"].ToString().Trim();
                            aRow["l_amt"] = decimal.Round(decimal.Parse(Row["l_amt"].ToString()), 0);
                            aRow["lrate_code"] = Row["lrate_code"].ToString();
                            aRow["lrate_name"] = Row["lrate_name"].ToString();
                            aRow["perexp"] = (Row.IsNull("perexp")) ? 0 : int.Parse(Row["perexp"].ToString());
                            aRow["norexp"] = (Row.IsNull("norexp")) ? 0 : int.Parse(Row["norexp"].ToString());
                            aRow["losexp"] = (Row.IsNull("losexp")) ? 0 : int.Parse(Row["losexp"].ToString());
                            aRow["jobexp"] = (Row.IsNull("jobexp")) ? 0 : int.Parse(Row["jobexp"].ToString());
                            aRow["fundexp"] = (Row.IsNull("fundexp")) ? 0 : int.Parse(Row["fundexp"].ToString());
                            aRow["compexp"] = (Row.IsNull("compexp")) ? 0 : int.Parse(Row["compexp"].ToString());
                            aRow["p_no"] = 1;
                            ds.Tables["zz3a"].Rows.Add(aRow);
                        }
                    }
                }
                else if (reporttype == "1")
                {
                    DataRow[] SRow1 = rq_inslab.Select("", "s_no,idno asc");
                    foreach (DataRow Row in SRow1)
                    {
                       DataRow aRow = ds.Tables["zz3a1"].NewRow();
                       aRow["idno"] = Row["idno"].ToString();
                        aRow["s_no"] = Row["s_no"].ToString().Trim();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["name_c"] = Row["name_c"].ToString();
                        aRow["name_e"] = Row["name_e"].ToString();
                        aRow["in_date"] = DateTime.Parse(Row["in_date"].ToString());
                        aRow["out_date"] = DateTime.Parse(Row["out_date"].ToString());
                        aRow["l_amt"] = decimal.Round(decimal.Parse(Row["l_amt"].ToString()), 0);
                        aRow["lrate_code"] = Row["lrate_code"].ToString();
                        aRow["lrate_name"] = Row["lrate_name"].ToString();
                        aRow["perexp"] = int.Parse(Row["perexp"].ToString());
                        aRow["norexp"] = int.Parse(Row["norexp"].ToString());
                        aRow["losexp"] = int.Parse(Row["losexp"].ToString());
                        aRow["jobexp"] = int.Parse(Row["jobexp"].ToString());
                        aRow["fundexp"] = int.Parse(Row["fundexp"].ToString());
                        aRow["compexp"] = int.Parse(Row["compexp"].ToString());
                        aRow["insday"] = int.Parse(Row["insday"].ToString());
                        if (Row["code"].ToString().Trim() == "1")
                            aRow["code"] = "加保";
                        else
                            aRow["code"] = "退保";
                        ds.Tables["zz3a1"].Rows.Add(aRow);
                    }
                }
                else if (reporttype == "2")
                {
                    DataColumn[] _key1 = new DataColumn[3];
                    _key1[0] = ds.Tables["zz3a2"].Columns["s_no"];
                    _key1[1] = ds.Tables["zz3a2"].Columns["h_amt"];
                    _key1[2] = ds.Tables["zz3a2"].Columns["hrate_code"];
                    ds.Tables["zz3a2"].PrimaryKey = _key1;
                    DataRow[] SRow2 = rq_inslab.Select("", "s_no,h_amt,hrate_code asc");
                    
                    foreach (DataRow Row in SRow2)
                    {
                        if (bool.Parse(Row["zero"].ToString())) Row["h_exp"] = 0;
                        object[] _value1 = new object[3];
                        _value1[0] = Row["s_no"].ToString().Trim();
                        _value1[1] = decimal.Round(decimal.Parse(Row["h_amt"].ToString()), 0);
                        _value1[2] = Row["hrate_code"].ToString();
                        DataRow row = ds.Tables["zz3a2"].Rows.Find(_value1);
                        if (row != null)
                        {
                            row["h_exp"] = int.Parse(row["h_exp"].ToString()) + int.Parse(Row["h_exp"].ToString());
                            row["h_exp1"] = int.Parse(row["h_exp1"].ToString()) + int.Parse(Row["h_exp1"].ToString());
                            if (Row["fa_idno"].ToString().Trim() == "")
                                row["p_no"] = int.Parse(row["p_no"].ToString()) + 1;
                            else
                                row["f_no"] = int.Parse(row["f_no"].ToString()) + 1;
                            if (bool.Parse(Row["zero"].ToString())) row["ep_no"] = int.Parse(row["ep_no"].ToString()) + 1;
                        }
                        else
                        {
                            DataRow aRow = ds.Tables["zz3a2"].NewRow();
                            aRow["s_no"] = Row["s_no"].ToString();
                            aRow["h_amt"] = decimal.Round(decimal.Parse(Row["h_amt"].ToString()), 0);
                            aRow["h_exp"] = int.Parse(Row["h_exp"].ToString());
                            aRow["h_exp1"] = int.Parse(Row["h_exp1"].ToString());
                            aRow["p_no"] = (Row["fa_idno"].ToString().Trim()=="") ? 1 : 0;
                            aRow["f_no"] = (Row["fa_idno"].ToString().Trim()=="") ? 0 : 1;
                            aRow["ep_no"] = (bool.Parse(Row["zero"].ToString())) ? 1 : 0;
                            aRow["hrate_code"] = Row["hrate_code"].ToString();
                            aRow["hrate_name"] = Row["hrate_name"].ToString();
                            ds.Tables["zz3a2"].Rows.Add(aRow);
                        }
                    }
                }

                
                rq_inslab = null; rq_base = null;
                if (exportexcel)
                {
                    if (reporttype == "0")
                        Export1(ds.Tables["zz3a"]);
                    else if (reporttype == "1")
                        Export2(ds.Tables["zz3a1"]);
                    else if (reporttype == "2")
                        Export3(ds.Tables["zz3a2"]);
                    this.Close();
                }
                else
                {                   
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "InsReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "InsReport", "*.rdlc");
                    if (reporttype == "0")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz3a.rdlc";
                    else if (reporttype == "1")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz3a1.rdlc";
                    else if (reporttype == "2")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz3a2.rdlc";
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                    if (reporttype == "0" )
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("InsDataSet_zz3a", ds.Tables["zz3a"]));
                    else if (reporttype == "1" )
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("InsDataSet_zz3a1", ds.Tables["zz3a1"]));
                    else if (reporttype == "2")
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("InsDataSet_zz3a2", ds.Tables["zz3a2"]));                    
                    RptViewer.SetDisplayMode(DisplayMode.PrintLayout);
                    RptViewer.ZoomMode = ZoomMode.FullPage;
                    RptViewer.ZoomPercent = 100;
                } 
            }
            catch (Exception Ex)
            {
                JBModule.Message.TextLog.WriteLog(Ex);
                MessageBox.Show(Resources.All.ExceptionStr1 + "\n" + Ex.Message + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            } 
        }

        void Export1(DataTable DT)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("投保金額", typeof(int));
            ExporDt.Columns.Add("個人分擔", typeof(int));
            ExporDt.Columns.Add("公司分擔", typeof(int));
            ExporDt.Columns.Add("人數", typeof(int));
            ExporDt.Columns.Add("投保總額", typeof(int));
            ExporDt.Columns.Add("身分別", typeof(string));
            ExporDt.Columns.Add("個人總額", typeof(int));            
            ExporDt.Columns.Add("公司總額", typeof(int));
            ExporDt.Columns.Add("普通事故", typeof(int));
            ExporDt.Columns.Add("就業保險", typeof(int));
            ExporDt.Columns.Add("勞保職災", typeof(int));
            ExporDt.Columns.Add("墊償基金", typeof(int));
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["投保金額"] = int.Parse(Row01["l_amt"].ToString());
                aRow["個人分擔"] = int.Parse(Row01["perexp"].ToString());
                aRow["公司分擔"] = int.Parse(Row01["compexp"].ToString());
                aRow["人數"] = int.Parse(Row01["p_no"].ToString());
                aRow["投保總額"] = int.Parse(Row01["l_amt"].ToString()) * int.Parse(Row01["p_no"].ToString()); 
                aRow["身分別"] = Row01["lrate_name"].ToString();
                aRow["個人總額"] = int.Parse(Row01["perexp"].ToString()) * int.Parse(Row01["p_no"].ToString());
                aRow["公司總額"] = int.Parse(Row01["compexp"].ToString()) * int.Parse(Row01["p_no"].ToString());
                aRow["普通事故"] = int.Parse(Row01["norexp"].ToString());
                aRow["就業保險"] = int.Parse(Row01["losexp"].ToString());
                aRow["勞保職災"] = int.Parse(Row01["jobexp"].ToString());
                aRow["墊償基金"] = int.Parse(Row01["fundexp"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }

        void Export2(DataTable DT)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("身分證號", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            ExporDt.Columns.Add("投保金額", typeof(int));
            ExporDt.Columns.Add("身分別", typeof(string));
            ExporDt.Columns.Add("個人負擔", typeof(int));
            ExporDt.Columns.Add("公司負擔", typeof(int));
            ExporDt.Columns.Add("異動", typeof(string));
            ExporDt.Columns.Add("加保日期", typeof(DateTime));
            ExporDt.Columns.Add("退保日期", typeof(DateTime));
            ExporDt.Columns.Add("天數", typeof(int));
            ExporDt.Columns.Add("普通事故", typeof(int));
            ExporDt.Columns.Add("就業保險", typeof(int));
            ExporDt.Columns.Add("勞保職災", typeof(int));
            ExporDt.Columns.Add("墊償基金", typeof(int));
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["身分證號"] = Row01["idno"].ToString();
                aRow["員工編號"] = Row01["nobr"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();
                aRow["英文姓名"] = Row01["name_e"].ToString();
                aRow["投保金額"] = int.Parse(Row01["l_amt"].ToString());
                aRow["身分別"] = Row01["lrate_name"].ToString();
                aRow["個人負擔"] = int.Parse(Row01["perexp"].ToString());
                aRow["公司負擔"] = int.Parse(Row01["compexp"].ToString());
                aRow["異動"] = Row01["code"].ToString();
                aRow["加保日期"] = DateTime.Parse(Row01["in_date"].ToString());
                aRow["退保日期"] = DateTime.Parse(Row01["out_date"].ToString());
                aRow["天數"] = int.Parse(Row01["insday"].ToString());
                aRow["普通事故"] = int.Parse(Row01["norexp"].ToString());
                aRow["就業保險"] = int.Parse(Row01["losexp"].ToString());
                aRow["勞保職災"] = int.Parse(Row01["jobexp"].ToString());
                aRow["墊償基金"] = int.Parse(Row01["fundexp"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }

        void Export3(DataTable DT)
        {
            DataTable ExporDt = new DataTable();           
            ExporDt.Columns.Add("投保金額", typeof(int));            
            ExporDt.Columns.Add("本人", typeof(int));
            ExporDt.Columns.Add("眷屬", typeof(int));           
            ExporDt.Columns.Add("免計眷屬", typeof(int));
            ExporDt.Columns.Add("個人負擔", typeof(int));
            ExporDt.Columns.Add("公司負擔", typeof(int));
            ExporDt.Columns.Add("身分別", typeof(string));
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();               
                aRow["投保金額"] = int.Parse(Row01["h_amt"].ToString());
                aRow["本人"] = int.Parse(Row01["p_no"].ToString());
                aRow["眷屬"] = int.Parse(Row01["f_no"].ToString());
                aRow["免計眷屬"] = int.Parse(Row01["ep_no"].ToString());                
                aRow["個人負擔"] = int.Parse(Row01["h_exp"].ToString());
                aRow["公司負擔"] = int.Parse(Row01["h_exp1"].ToString());
                aRow["身分別"] = Row01["hrate_name"].ToString();
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
