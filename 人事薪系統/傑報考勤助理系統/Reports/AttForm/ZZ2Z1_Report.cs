using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace JBHR.Reports.AttForm
{
    public partial class ZZ2Z1_Report : JBControls.JBForm
    {
        attenddata ds = new attenddata();
        string nobr_b, nobr_e, dept_b, dept_e, depts_b, depts_e, jobl_b, jobl_e, date_b, date_e, yymm_b, yymm_e, comp_name;
        string emp_b, emp_e, comp_b, comp_e, work_b, work_e, data_report, report_type, CompId;
        string responsibility_b, responsibility_e;
        bool exportexcel;
        public ZZ2Z1_Report(string nobrb, string nobre, string deptb, string depte, string deptsb, string deptse, string joblb, string joble, string dateb, string datee, string yymmb, string yymme, string empb, string empe, string compb, string compe, string workb, string worke, string responsibilityb, string responsibilitye, string datareport, bool _exportexcel, string compname, string _CompId)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; depts_b = deptsb;
            depts_e = deptse; jobl_b = joblb; jobl_e = joble; date_b = dateb; date_e = datee;
            yymm_b = yymmb; yymm_e = yymme; emp_b = empb; emp_e = empe; comp_b = compb;
            comp_e = compe; work_b = workb; work_e = worke; data_report = datareport;
            exportexcel = _exportexcel; comp_name = compname; CompId = _CompId;
            responsibility_b = responsibilityb; responsibility_e = responsibilitye;
        }

        private void ZZ2Z1_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlBase = "select b.nobr,a.name_c,a.name_e,c.d_no_disp as dept,c.d_name,c.d_ename";
                sqlBase += ",b.comp,f.rotet_disp as rotet,f.rotetname,e.jobl_disp as jobl,e.job_name as jobl_name";
                sqlBase += ",b.fulatt,b.indt,g.job_disp as job,g.job_name";
                sqlBase += " from base a,basetts b";
                sqlBase += " left outer join dept c on b.dept=c.d_no";
                sqlBase += " left outer join depts d on b.depts=d.d_no";
                sqlBase += " left outer join jobl e on  b.jobl=e.jobl";
                sqlBase += " left outer join rotet f on  b.rotet=f.rotet";
                sqlBase += " left outer join job g on b.job=g.job";
                sqlBase += " where a.nobr=b.nobr ";
                sqlBase += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                sqlBase += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlBase += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                sqlBase += string.Format(@" and d.d_no_disp between '{0}' and '{1}'", depts_b, depts_e);
                sqlBase += string.Format(@" and b.comp between '{0}' and '{1}'", comp_b, comp_e);
                sqlBase += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);
                sqlBase += string.Format(@" and e.jobl_disp between '{0}' and '{1}'", jobl_b, jobl_e);
                sqlBase += string.Format(@" and b.workcd between '{0}' and '{1}'", work_b, work_e);
                //sqlBase += string.Format(@" and b.carcd between '{0}' and '{1}'", responsibility_b, responsibility_e);
                sqlBase += data_report;
                DataTable rq_base = SqlConn.GetDataTable(sqlBase);               
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                string sqlJobl = "select jobl,job_name from jobl";
                DataTable rq_job1 = SqlConn.GetDataTable(sqlJobl);
                rq_job1.PrimaryKey = new DataColumn[] { rq_job1.Columns["jobl"] };
                //foreach (DataRow Row in rq_base.Rows)
                //{
                //    DataRow row = rq_job1.Rows.Find(Row["jobl"].ToString());
                //    if (row != null)
                //        Row["job_name"] = row["job_name"].ToString();
                //}

                string sqlAttend = "select a.nobr,sum(b.wk_hrs) as wk_hrs from attend a,rote b";
                sqlAttend += " where a.rote=b.rote";
                sqlAttend += string.Format(@" and a.adate between '{0}' and '{1}'", date_b, date_e);
                sqlAttend += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlAttend += " group by a.nobr";
                DataTable rq_attend1 = SqlConn.GetDataTable(sqlAttend);
                rq_attend1.PrimaryKey = new DataColumn[] { rq_attend1.Columns["nobr"] };

                string sqlAttend1 = "select nobr,adate,late_mins,e_mins,forget,abs from attend";
                sqlAttend1 += string.Format(@" where adate between '{0}' and '{1}'", date_b, date_e);
                sqlAttend1 += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                DataTable rq_attend = SqlConn.GetDataTable(sqlAttend1);

                //每日出勤工時
                string CmdAttRote = "select a.nobr,a.adate,c.wk_hrs from attend a,basetts b ,rote c";
                CmdAttRote += " where a.nobr=b.nobr and a.rote=c.rote";
                CmdAttRote += string.Format(@" and '{0}' between b.adate and b.ddate ", date_e);
                CmdAttRote += data_report;
                CmdAttRote += string.Format(@" and a.adate between '{0}' and '{1}'", date_b, date_e);
                DataTable rq_rote = SqlConn.GetDataTable(CmdAttRote);
                rq_rote.PrimaryKey = new DataColumn[] { rq_rote.Columns["nobr"], rq_rote.Columns["adate"] };

                //計算遲到.早退
                DataTable rq_attf = new DataTable();
                rq_attf.Columns.Add("nobr", typeof(string));
                rq_attf.Columns.Add("late_mins", typeof(decimal));
                rq_attf.Columns.Add("late_no", typeof(int));
                rq_attf.Columns.Add("e_mins", typeof(decimal));
                rq_attf.Columns.Add("e_no", typeof(int));
                rq_attf.Columns.Add("forget", typeof(int));
                rq_attf.Columns.Add("abs", typeof(int));
                rq_attf.PrimaryKey = new DataColumn[] { rq_attf.Columns["nobr"] };
                DataColumn[] _key = new DataColumn[3];
                _key[0] = ds.Tables["zz2z1"].Columns["comp"];
                _key[1] = ds.Tables["zz2z1"].Columns["nobr"];
                _key[2] = ds.Tables["zz2z1"].Columns["dept"];
                ds.Tables["zz2z1"].PrimaryKey = _key;
                
                foreach (DataRow Row in rq_attend.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        DataRow row1 = rq_attf.Rows.Find(Row["nobr"].ToString());
                        if (row1 != null)
                        {
                            row1["late_mins"] = decimal.Parse(row1["late_mins"].ToString()) + decimal.Parse(Row["late_mins"].ToString());
                            row1["e_mins"] = decimal.Parse(row1["e_mins"].ToString()) + decimal.Parse(Row["e_mins"].ToString());
                            row1["forget"] = int.Parse(row1["forget"].ToString()) + decimal.Round(decimal.Parse(Row["forget"].ToString()), 0);
                            if (bool.Parse(Row["abs"].ToString()))
                                row1["abs"] = int.Parse(row1["abs"].ToString()) + 1;
                            if (decimal.Parse(Row["late_mins"].ToString()) > 0)
                                row1["late_no"] = int.Parse(row1["late_no"].ToString()) + 1;
                            if (decimal.Parse(Row["e_mins"].ToString()) > 0)
                                row1["e_no"] = int.Parse(row1["e_no"].ToString()) + 1;
                        }
                        else
                        {
                            DataRow aRow = rq_attf.NewRow();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["late_mins"] = decimal.Parse(Row["late_mins"].ToString());
                            aRow["late_no"] = decimal.Parse(Row["late_mins"].ToString()) > 0 ? 1 : 0;
                            aRow["e_mins"] = decimal.Parse(Row["e_mins"].ToString());
                            aRow["e_no"] = decimal.Parse(Row["e_mins"].ToString()) > 0 ? 1 : 0;
                            aRow["forget"] = decimal.Round(decimal.Parse(Row["forget"].ToString()), 0);
                            aRow["abs"] = bool.Parse(Row["abs"].ToString()) ? 1 : 0;
                            rq_attf.Rows.Add(aRow);
                        }

                        object[] _value = new object[3];
                        _value[0] = row["comp"].ToString();
                        _value[1] = Row["nobr"].ToString();
                        _value[2] = row["dept"].ToString();
                        DataRow row2 = ds.Tables["zz2z1"].Rows.Find(_value);
                        if (row2 == null)
                        {
                            DataRow aRow1 = ds.Tables["zz2z1"].NewRow();
                            aRow1["nobr"] = Row["nobr"].ToString();
                            aRow1["name_c"] = row["name_c"].ToString();
                            aRow1["name_e"] = row["name_e"].ToString();
                            aRow1["dept"] = row["dept"].ToString();
                            aRow1["d_name"] = row["d_name"].ToString();
                            aRow1["d_ename"] = row["d_ename"].ToString();
                            aRow1["job_name"] = row["job_name"].ToString();
                            aRow1["jobl_name"] = row["jobl_name"].ToString();
                            aRow1["comp"] = row["comp"].ToString();
                            aRow1["indt"] = DateTime.Parse(row["indt"].ToString());
                            aRow1["rotetname"] = row["rotetname"].ToString();
                            ds.Tables["zz2z1"].Rows.Add(aRow1);
                        }
                    }
                }

                string sqlAbs = "select a.nobr,a.bdate,a.tol_hours,b.h_code_disp as h_code,b.h_name,b.unit,b.year_rest";
                sqlAbs += " from abs a,hcode b where a.h_code=b.h_code";
                sqlAbs += string.Format(@" and a.yymm between '{0}' and '{1}'", yymm_b, yymm_e);
                sqlAbs += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                //sqlAbs += " and b.year_rest not in ('1','3','5')";
                //判斷and mang <> 1不是系統才會顯示
                sqlAbs += "  and b.flag='-' and b.mang <> 1";
                DataTable rq_abs1 = SqlConn.GetDataTable(sqlAbs);

                //string sqlRote = "select rote,rote_disp,wk_hrs from rote";
                //DataTable rq_rote = SqlConn.GetDataTable(sqlRote);
                //rq_rote.PrimaryKey = new DataColumn[] { rq_rote.Columns["rote"] };

                DataTable rq_abs = new DataTable();
                rq_abs.Columns.Add("nobr", typeof(string));
                rq_abs.Columns.Add("h_code", typeof(string));
                rq_abs.Columns.Add("tol_hours", typeof(decimal));
                rq_abs.PrimaryKey = new DataColumn[] { rq_abs.Columns["nobr"], rq_abs.Columns["h_code"] };

                DataTable rq_hcode = new DataTable();
                rq_hcode.Columns.Add("h_code", typeof(string));
                rq_hcode.Columns.Add("h_name", typeof(string));
                rq_hcode.PrimaryKey = new DataColumn[] { rq_hcode.Columns["h_code"] };

                foreach (DataRow Row in rq_abs1.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        Object[] _value2 = new object[2];
                        _value2[0] = Row["nobr"].ToString();
                        _value2[1] = Row["bdate"].ToString();
                        DataRow row1 = rq_rote.Rows.Find(_value2);
                        //DataRow row1 = rq_rote.Rows.Find(row["rotet"].ToString());
                        if (row1 != null)
                        {
                            if (Row["unit"].ToString().Trim() == "天")
                                Row["tol_hours"] = decimal.Parse(Row["tol_hours"].ToString()) * decimal.Parse(row1["wk_hrs"].ToString());
                            object[] _value = new object[2];
                            _value[0] = Row["nobr"].ToString();
                            _value[1] = Row["h_code"].ToString();
                            DataRow row2 = rq_abs.Rows.Find(_value);
                            if (row2 != null)
                                row2["tol_hours"] = decimal.Parse(row2["tol_hours"].ToString()) + decimal.Parse(Row["tol_hours"].ToString());
                            else
                            {
                                DataRow aRow = rq_abs.NewRow();
                                aRow["nobr"] = Row["nobr"].ToString();
                                aRow["h_code"] = Row["h_code"].ToString();
                                aRow["tol_hours"] = decimal.Parse(Row["tol_hours"].ToString());
                                rq_abs.Rows.Add(aRow);
                            }

                            DataRow row3 = rq_hcode.Rows.Find(Row["h_code"].ToString());
                            if (row3 == null)
                            {
                                DataRow aRow1 = rq_hcode.NewRow();
                                aRow1["h_code"] = Row["h_code"].ToString();
                                aRow1["h_name"] = Row["h_name"].ToString();
                                rq_hcode.Rows.Add(aRow1);
                            }
                        }
                        else
                            Row.Delete();

                    }
                    else
                        Row.Delete();
                }

                //產生請假表頭
                DataRow[] rowt = rq_hcode.Select("", "h_code asc");
                DataRow aRowt = ds.Tables["zz2z1_t"].NewRow();
                for (int i = 0; i < rowt.Length; i++)
                {
                    aRowt["Fld" + (i + 1)] = rowt[i]["h_name"].ToString();
                }
                ds.Tables["zz2z1_t"].Rows.Add(aRowt);

                string sqlOt = "select a.nobr,sum(a.ot_hrs) as ot_hrs,sum(a.rest_hrs) as rest_hrs,sum(a.ot_car) as ot_car";
                sqlOt += ",sum(a.not_w_133) as not_w_133,sum(a.tot_w_133) as tot_w_133,sum(a.not_h_133) as not_h_133";
                sqlOt += ",sum(a.not_w_167) as not_w_167,sum(a.tot_w_167) as tot_w_167,sum(a.not_h_167) as not_h_167";
                sqlOt += ",sum(a.not_w_200) as not_w_200,sum(a.tot_w_200) as tot_w_200,sum(a.not_h_200) as not_h_200";
                sqlOt += ",sum(a.tot_h_200) as tot_h_200";
                sqlOt += string.Format(@" from ot a where a.yymm between '{0}' and '{1}'", yymm_b, yymm_e);
                sqlOt += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);               
                sqlOt += " group by a.nobr";
                DataTable rq_ot = SqlConn.GetDataTable(sqlOt);
                rq_ot.PrimaryKey = new DataColumn[] { rq_ot.Columns["nobr"] };

                //全勤獎金計算begin
                //出勤資料
                string sqlAttend2 = "select nobr,late_mins,forget";
                sqlAttend2 += string.Format(@" from attend where adate between '{0}' and '{1}'", date_b, date_e);
                sqlAttend2 += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlAttend2 += " and (late_mins >0 or forget >0)";
                DataTable rq_attend2 = SqlConn.GetDataTable(sqlAttend2);
                foreach (DataRow Row in rq_attend2.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        if (bool.Parse(row["fulatt"].ToString()))
                            Row.Delete();
                    }
                    else
                        Row.Delete();
                }
                rq_attend2.AcceptChanges();
                int bb = rq_attend2.Rows.Count;

                //請假資料
                string sqlAbs1 = "select a.nobr,a.bdate,b.h_code_disp as h_code,b.h_name,a.tol_hours,b.att from abs a,hcode b";
                sqlAbs1 += " where a.h_code=b.h_code";
                sqlAbs1 += string.Format(@" and a.yymm='{0}'", yymm_b);
                sqlAbs1 += string.Format(@" and a.bdate between '{0}' and '{1}'", date_b, date_e);
                sqlAbs1 += " and b.att=1 order by a.nobr,a.bdate";
                DataTable rq_abs2 = SqlConn.GetDataTable(sqlAbs1);
                foreach (DataRow Row in rq_abs2.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        if (bool.Parse(row["fulatt"].ToString()))
                            Row.Delete();
                    }
                    else
                        Row.Delete();
                }
                rq_abs2.AcceptChanges();
                int AA = rq_abs2.Rows.Count;

                //6 職等以下(含)且有刷卡者才有全勤獎金
                //string sqlAttend3 = "select b.nobr,1200 as amt from basetts b";
                //sqlAttend3 += string.Format(@" where '{0}' between b.adate and b.ddate", date_e);
                //sqlAttend3 += " and b.card='Y' and b.jobl between '01' and '06'";
                //sqlAttend3 += " and b.nobr in (select distinct nobr from attend where";
                //sqlAttend3 += string.Format(@" adate between '{0}' and '{1}'", date_b, date_e);
                //sqlAttend3 += string.Format(@" and nobr between '{0}' and '{1}' )", nobr_b, nobr_e);
                //sqlAttend3 += " and b.fulatt=0";
                //sqlAttend3 += string.Format(@" and b.dept between '{0}' and '{1}'", dept_b, dept_e);
                //sqlAttend3 += string.Format(@" and b.depts between '{0}' and '{1}'", depts_b, depts_e);
                //sqlAttend3 += string.Format(@" and b.comp between '{0}' and '{1}'", comp_b, comp_e);
                //sqlAttend3 += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);
                //sqlAttend3 += string.Format(@" and b.workcd between '{0}' and '{1}'", jobl_b, jobl_e);
                DataTable rq_sys2 = SqlConn.GetDataTable("select attawardsalcode,attmonamt from u_sys2 where comp='" + CompId + "'");
                decimal attmonamt = 0; string attawardsalcode = "";
                if (rq_sys2.Rows.Count > 0)
                {
                    attawardsalcode = rq_sys2.Rows[0]["attawardsalcode"].ToString();
                    attmonamt = decimal.Parse(rq_sys2.Rows[0]["attmonamt"].ToString());
                }
                string sqlAttend3 = "select nobr,amt from salbasd";
                sqlAttend3 += string.Format(@" where '{0}' between adate and ddate", date_e);
                sqlAttend3 += string.Format(@" and sal_code='{0}'", attawardsalcode);
                sqlAttend3 += string.Format(@" and nobr between '{0}' and '{1}' ", nobr_b, nobr_e);
                DataTable rq_attend3 = SqlConn.GetDataTable(sqlAttend3);
                rq_attend3.PrimaryKey = new DataColumn[] { rq_attend3.Columns["nobr"] };

                DataTable rq_amt = new DataTable();
                rq_amt.Columns.Add("nobr", typeof(string));
                rq_amt.Columns.Add("amt", typeof(int));
                foreach (DataRow Row in rq_attend3.Rows)
                {
                    Row["amt"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row["amt"].ToString()));
                    DataRow[] row = rq_abs2.Select("nobr='" + Row["nobr"].ToString() + "' and att=1");
                    decimal _tolhours = 0;
                    for (int i = 0; i < row.Length; i++)
                    {
                        _tolhours += decimal.Parse(row[i]["tol_hours"].ToString());
                    }
                    if (_tolhours == 8 )
                        Row["amt"] = int.Parse(Row["amt"].ToString()) / 2;
                    else if (_tolhours > 8)
                        Row["amt"] = 0;
                    DataRow row1 = rq_attf.Rows.Find(Row["nobr"].ToString());
                    if (row1 != null)
                    {
                        if (int.Parse(row1["late_no"].ToString()) ==5)
                            Row["amt"] = (int.Parse(Row["amt"].ToString()) != 0) ? int.Parse(Row["amt"].ToString()) / 2 : 0;
                        else if (int.Parse(row1["late_no"].ToString()) > 5)
                            Row["amt"] = 0;
                    }
                    DataRow aRow = rq_amt.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["amt"] = Row["amt"].ToString();
                    rq_amt.Rows.Add(aRow);
                }

                //全勤獎金計算end


                foreach (DataRow Row in ds.Tables["zz2z1"].Rows)
                {
                    string str_nobr = Row["nobr"].ToString();
                    DataRow row = rq_attf.Rows.Find(str_nobr);
                    DataRow row1 = rq_attend1.Rows.Find(str_nobr);
                    DataRow row2 = rq_ot.Rows.Find(str_nobr);
                    DataRow row3 = rq_attend3.Rows.Find(str_nobr);
                    if (row != null)
                    {
                        Row["late_mins"] = decimal.Parse(row["late_mins"].ToString());
                        Row["late_no"] = int.Parse(row["late_no"].ToString());
                        Row["e_mins"] = decimal.Parse(row["e_mins"].ToString());
                        Row["e_no"] = int.Parse(row["e_no"].ToString());
                        Row["forget"] = int.Parse(row["forget"].ToString());
                    }
                    if (row1 != null)
                        Row["wk_hrs"] = decimal.Parse(row1["wk_hrs"].ToString());
                    if (row2 != null)
                    {
                        Row["ot133"] = decimal.Parse(row2["not_w_133"].ToString()) + decimal.Parse(row2["tot_w_133"].ToString());
                        Row["ot167"] = decimal.Parse(row2["not_w_167"].ToString()) + decimal.Parse(row2["tot_w_167"].ToString());
                        Row["ot200"] = decimal.Parse(row2["not_w_200"].ToString()) + decimal.Parse(row2["tot_w_200"].ToString());
                        Row["oth200"] = decimal.Parse(row2["not_h_200"].ToString()) + decimal.Parse(row2["tot_h_200"].ToString());
                        Row["oth200"] = decimal.Parse(Row["oth200"].ToString()) + decimal.Parse(row2["not_h_167"].ToString()) + decimal.Parse(row2["not_h_133"].ToString());
                        Row["ot_hrs"] = decimal.Parse(row2["ot_hrs"].ToString());
                        Row["rest_hrs"] = decimal.Parse(row2["rest_hrs"].ToString());
                    }
                    else
                        Row["ot_hrs"] = 0;
                    if (row3 != null)
                    {
                        Row["att_amt"] = int.Parse(row3["amt"].ToString());
                    }

                    decimal _tolhours = 0;
                    object[] _value = new object[2];
                    _value[0] = str_nobr;
                    for (int i = 0; i < rowt.Length; i++)
                    {
                        _value[1] = rowt[i]["h_code"].ToString();
                        DataRow row4 = rq_abs.Rows.Find(_value);
                        if (row4 != null)
                        {
                            Row["Fld" + (i + 1)] = decimal.Round(decimal.Parse(row4["tol_hours"].ToString()), 2);
                            _tolhours = _tolhours + decimal.Round(decimal.Parse(row4["tol_hours"].ToString()), 2);
                        }
                    }
                    Row["abs_hrs"] = _tolhours;
                    decimal aad = decimal.Parse(Row["wk_hrs"].ToString());
                    decimal dfad = decimal.Parse(Row["ot_hrs"].ToString());
                    if (report_type == "1")
                        Row["wkhrsf"] = decimal.Parse(Row["wk_hrs"].ToString()) - _tolhours + decimal.Parse(Row["ot_hrs"].ToString());
                    else
                        Row["wkhrsf"] = (Row.IsNull("rest_hrs")) ? decimal.Parse(Row["wk_hrs"].ToString()) - _tolhours + decimal.Parse(Row["ot_hrs"].ToString()) : decimal.Parse(Row["wk_hrs"].ToString()) - _tolhours + decimal.Parse(Row["ot_hrs"].ToString()) + decimal.Parse(Row["rest_hrs"].ToString());
                }

                rq_abs = null;
                rq_abs1 = null;
                rq_abs2 = null;
                rq_amt = null;
                rq_attend = null;
                rq_attend1 = null;
                rq_attend2 = null;
                rq_attend3 = null;
                rq_attf = null;
                rq_base = null;
                rq_hcode = null;
                rq_job1 = null;
                rq_ot = null;
                rq_rote = null;
                if (ds.Tables["zz2z1"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                if (exportexcel)
                {                    
                    Export(ds.Tables["zz2z1"], ds.Tables["zz2z1_t"]);
                    this.Close();
                }
                else
                {                    
                    RptViewer.Reset();
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "AttReport", "*.rdlc");
                    if (report_type=="1")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz2z1.rdlc";
                    else
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz2z10.rdlc";
                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_zz2z1", ds.Tables["zz2z1"]));
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_zz2z1_t", ds.Tables["zz2z1_t"]));
                    RptViewer.SetDisplayMode(DisplayMode.PrintLayout);
                    RptViewer.ZoomMode = ZoomMode.Percent;
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
        void Export(DataTable DT, DataTable DT1)
        {
            
            DataTable ExporDt = new DataTable();
            if (report_type == "1")
            {
                ExporDt.Columns.Add("公司別", typeof(string));
                ExporDt.Columns.Add("職等", typeof(string));
            }
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));           
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            if (report_type == "1")
            {
                ExporDt.Columns.Add("英文姓名", typeof(string));
            }
            else
            {
                ExporDt.Columns.Add("職稱", typeof(string));
                ExporDt.Columns.Add("班別", typeof(string));
                ExporDt.Columns.Add("到職日", typeof(DateTime));
            }
            ExporDt.Columns.Add("工作時數", typeof(Decimal));
            ExporDt.Columns.Add("遲到分鐘", typeof(decimal));
            ExporDt.Columns.Add("遲到次數", typeof(int));
            ExporDt.Columns.Add("早退分鐘", typeof(decimal));
            ExporDt.Columns.Add("早退次數", typeof(int));
            ExporDt.Columns.Add("忘刷次數", typeof(int));
            if (report_type == "1")
            {
                ExporDt.Columns.Add("全勤獎金", typeof(int));
            }            
            ExporDt.Columns.Add("一段時數", typeof(decimal));
            ExporDt.Columns.Add("二段時數", typeof(decimal));
            ExporDt.Columns.Add("三段時數", typeof(decimal));
            ExporDt.Columns.Add("假日時數", typeof(decimal));
            ExporDt.Columns.Add("總加班時數", typeof(decimal));
            ExporDt.Columns.Add("補休得時數", typeof(decimal));
            if (report_type == "7")
            {
                ExporDt.Columns.Add("總工時", typeof(decimal));
            }
            ExporDt.Columns.Add("請假時數", typeof(decimal));
            ExporDt.Columns.Add("實際工時", typeof(decimal));
            for (int i = 0; i < DT1.Columns.Count; i++)
            {
                if (DT1.Rows[0][i].ToString().Trim() != "")
                    ExporDt.Columns.Add(DT1.Rows[0][i].ToString().Trim(), typeof(decimal));
                else
                    break;
            }

            foreach (DataRow Row in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                if (report_type == "1")
                {
                    aRow["公司別"] = Row["comp"].ToString();
                    aRow["職等"] = Row["jobl_name"].ToString();
                }
                aRow["部門代碼"] = Row["dept"].ToString();
                aRow["部門名稱"] = Row["d_name"].ToString();                
                aRow["員工編號"] = Row["nobr"].ToString();
                aRow["員工姓名"] = Row["name_c"].ToString();
                if (report_type == "1")
                {
                    aRow["英文姓名"] = Row["name_e"].ToString();
                }
                else
                {
                    aRow["職稱"] = Row["job_name"].ToString();
                    aRow["班別"] = Row["rotetname"].ToString();
                    aRow["到職日"] = DateTime.Parse(Row["indt"].ToString());
                }
                aRow["工作時數"] = (Row.IsNull("wk_hrs")) ? 0 : decimal.Parse(Row["wk_hrs"].ToString());
                aRow["遲到分鐘"] = (Row.IsNull("late_mins")) ? 0 : decimal.Parse(Row["late_mins"].ToString());
                aRow["遲到次數"] = (Row.IsNull("late_no")) ? 0 : int.Parse(Row["late_no"].ToString());
                aRow["早退分鐘"] = (Row.IsNull("e_mins")) ? 0 : decimal.Parse(Row["e_mins"].ToString());
                aRow["早退次數"] = (Row.IsNull("e_no")) ? 0 : int.Parse(Row["e_no"].ToString());
                aRow["忘刷次數"] = (Row.IsNull("forget")) ? 0 : int.Parse(Row["forget"].ToString());
                if (report_type == "1")
                {
                    aRow["全勤獎金"] = (Row.IsNull("att_amt")) ? 0 : int.Parse(Row["att_amt"].ToString());
                }
                aRow["一段時數"] = (Row.IsNull("ot133")) ? 0 : decimal.Parse(Row["ot133"].ToString());
                aRow["二段時數"] = (Row.IsNull("ot167")) ? 0 : decimal.Parse(Row["ot167"].ToString());
                aRow["三段時數"] = (Row.IsNull("ot200")) ? 0 : decimal.Parse(Row["ot200"].ToString());
                aRow["假日時數"] = (Row.IsNull("oth200")) ? 0 : decimal.Parse(Row["oth200"].ToString());
                aRow["總加班時數"] = (Row.IsNull("ot_hrs")) ? 0 : decimal.Parse(Row["ot_hrs"].ToString());
                aRow["補休得時數"] = (Row.IsNull("rest_hrs")) ? 0 : decimal.Parse(Row["rest_hrs"].ToString());
                aRow["請假時數"] = (Row.IsNull("abs_hrs")) ? 0 : decimal.Parse(Row["abs_hrs"].ToString());
                if (report_type == "7")
                {
                    aRow["總工時"] = decimal.Parse(aRow["工作時數"].ToString()) + decimal.Parse(aRow["總加班時數"].ToString()) + decimal.Parse(aRow["補休得時數"].ToString());
                }
                aRow["實際工時"] = (Row.IsNull("wkhrsf")) ? 0 : decimal.Parse(Row["wkhrsf"].ToString());
                for (int i = 0; i < DT1.Columns.Count; i++)
                {
                    if (DT1.Rows[0][i].ToString().Trim() != "")
                        aRow[DT1.Rows[0][i].ToString().Trim()] = (Row.IsNull("Fld" + (i + 1))) ? 0 : decimal.Parse(Row["Fld" + (i + 1)].ToString());
                    else
                        break;
                }
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
