using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Reports.AttForm
{
    public partial class ZZ2Z_Report6 : JBControls.JBForm
    {
        attenddata ds = new attenddata();
        string nobr_b, nobr_e, dept_b, dept_e, depts_b, depts_e, jobl_b, jobl_e, date_b, date_e, yymm_b, yymm_e, comp_name;
        string emp_b, emp_e, comp_b, comp_e, work_b, work_e, data_report, report_type, CompId;
        string responsibility_b, responsibility_e;
        bool exportexcel;
        public ZZ2Z_Report6(string nobrb, string nobre, string deptb, string depte, string deptsb, string deptse, string joblb, string joble, string dateb, string datee, string yymmb, string yymme, string empb, string empe, string compb, string compe, string workb, string worke, string responsibilityb, string responsibilitye, string datareport, string reporttype, bool _exportexcel, string compname, string _CompId)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; depts_b = deptsb;
            depts_e = deptse; jobl_b = joblb; jobl_e = joble; date_b = dateb; date_e = datee;
            yymm_b = yymmb; yymm_e = yymme; emp_b = empb; emp_e = empe; comp_b = compb;
            comp_e = compe; work_b = workb; work_e = worke; data_report = datareport;
            exportexcel = _exportexcel; comp_name = compname; CompId = _CompId;
            responsibility_b = responsibilityb; responsibility_e = responsibilitye;
            report_type = reporttype;
        }

        private void ZZ2Z_Report6_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlBase = "select b.nobr,a.name_c,a.name_e,c.d_no_disp as dept,c.d_name,c.d_ename";
                sqlBase += ",b.comp,f.rotet_disp as rotet,f.rotetname,e.jobl_disp as jobl,e.job_name as jobl_name";
                sqlBase += ",b.fulatt,b.indt,g.job_disp as job,g.job_name,d.d_no_disp as depts,d.d_name as ds_name";
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

                string sqlAttend = "select a.nobr,month(a.adate) as mon,sum(a.rel_hrs) as rel_hrs,sum(b.wk_hrs) as wk_hrs";
                sqlAttend += " from attend a,rote b";
                sqlAttend += " where a.rote=b.rote";
                sqlAttend += string.Format(@" and a.adate between '{0}' and '{1}'", date_b, date_e);
                sqlAttend += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlAttend += " group by a.nobr,month(a.adate) order by a.nobr";
                DataTable rq_attend = SqlConn.GetDataTable(sqlAttend);
                rq_attend.Columns.Add("name_c", typeof(string));
                rq_attend.Columns.Add("dept", typeof(string));
                rq_attend.Columns.Add("d_name", typeof(string));
                rq_attend.Columns.Add("depts", typeof(string));
                rq_attend.Columns.Add("ds_name", typeof(string));
                foreach (DataRow Row in rq_attend.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        Row["name_c"] = row["name_c"].ToString();
                        Row["dept"] = row["dept"].ToString();
                        Row["d_name"] = row["d_name"].ToString();
                        Row["depts"] = row["depts"].ToString();
                        Row["ds_name"] = row["ds_name"].ToString();
                    }
                    else
                        Row.Delete();
                }
                rq_attend.AcceptChanges();

                //出勤月份
                string sqlAttmon = "select month(adate) as mon from attend";
                sqlAttmon += string.Format(@" where adate between '{0}' and '{1}'", date_b, date_e);
                sqlAttmon += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlAttmon += " group by month(adate) order by mon";
                DataTable rq_attmon = SqlConn.GetDataTable(sqlAttmon);

                //請假資料
                //string sqlAbs = "select a.nobr,month(a.bdate) as mon,sum(a.tol_hours) as tol_hours from abs a,hcode b";
                //sqlAbs += " where a.h_code=b.h_code";
                //sqlAbs += string.Format(@" and a.bdate between '{0}' and '{1}'", date_b, date_e);
                //sqlAbs += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                //sqlAbs += " and b.flag='-' and b.h_code_disp not like '%W%'";
                //sqlAbs += " group by a.nobr,month(a.bdate) order by a.nobr";
                //DataTable rq_abs = SqlConn.GetDataTable(sqlAbs);
                string sqlAttend1 = "select a.nobr,a.adate,b.wk_hrs";
                sqlAttend1 += " from attend a,rote b";
                sqlAttend1 += " where a.rote=b.rote";
                sqlAttend1 += string.Format(@" and a.adate between '{0}' and '{1}'", date_b, date_e);
                sqlAttend1 += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                DataTable rq_attend1 = SqlConn.GetDataTable(sqlAttend1);
                rq_attend1.PrimaryKey = new DataColumn[] { rq_attend1.Columns["nobr"], rq_attend1.Columns["adate"] };

                string sqlAbs = "select a.nobr,a.bdate,a.tol_hours,b.unit from abs a,hcode b";
                sqlAbs += " where a.h_code=b.h_code";
                sqlAbs += string.Format(@" and a.bdate between '{0}' and '{1}'", date_b, date_e);
                sqlAbs += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlAbs += " and b.flag='-' and b.h_code_disp not like '%W%'";
                sqlAbs += " order by a.nobr";
                DataTable rq_abs1 = SqlConn.GetDataTable(sqlAbs);

                DataTable rq_abs = new DataTable();
                rq_abs.Columns.Add("nobr", typeof(string));
                rq_abs.Columns.Add("mon", typeof(string));
                rq_abs.Columns.Add("tol_hours", typeof(decimal));                
                rq_abs.PrimaryKey = new DataColumn[] { rq_abs.Columns["nobr"], rq_abs.Columns["mon"] };

                foreach (DataRow Row in rq_abs1.Rows)
                {
                    if (Row["unit"].ToString().Trim() == "天")
                    {
                        object[] _value = new object[2];
                        _value[0] = Row["nobr"].ToString();
                        _value[1] = DateTime.Parse(Row["bdate"].ToString());
                        DataRow row = rq_attend1.Rows.Find(_value);
                        if (row != null)
                        {
                            Row["tol_hours"] = decimal.Parse(Row["tol_hours"].ToString()) * decimal.Parse(row["wk_hrs"].ToString());
                        }
                    }
                    string _mon = DateTime.Parse(Row["bdate"].ToString()).Month.ToString();
                    object[] _value1 = new object[2];
                    _value1[0] = Row["nobr"].ToString();
                    _value1[1] = _mon;
                    DataRow row1 = rq_abs.Rows.Find(_value1);
                    if (row1 != null)
                        row1["tol_hours"] = decimal.Round(decimal.Parse(row1["tol_hours"].ToString()) + decimal.Parse(Row["tol_hours"].ToString()), 2);
                    else
                    {
                        DataRow aRow = rq_abs.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["mon"] = _mon;
                        aRow["tol_hours"] = decimal.Parse(Row["tol_hours"].ToString());
                        rq_abs.Rows.Add(aRow);
                    }
                }

                string sqlOt = "select a.nobr,month(a.bdate) as mon,sum(a.ot_hrs) as ot_hrs,sum(a.rest_hrs) as rest_hrs ";
                sqlOt += " from ot a ";
                //sqlOt += string.Format(@"where a.yymm between '{0}' and '{1}'", yymm_b, yymm_e);
                sqlOt += string.Format(@" where a.bdate between '{0}' and '{1}'", date_b, date_e);
                sqlOt += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlOt += " group by a.nobr,month(a.bdate) order by a.nobr";
                DataTable rq_ot = SqlConn.GetDataTable(sqlOt);
                rq_ot.PrimaryKey = new DataColumn[] { rq_ot.Columns["nobr"], rq_ot.Columns["mon"] };

                DataTable zz2z26 = new DataTable();
                zz2z26.Columns.Add("員工編號", typeof(string));
                zz2z26.Columns.Add("員工姓名", typeof(string));
                zz2z26.Columns.Add("成本部門", typeof(string));
                zz2z26.Columns.Add("編制部門", typeof(string));
                for (int i = 0; i < rq_attmon.Rows.Count; i++)
                {
                    zz2z26.Columns.Add(rq_attmon.Rows[i]["mon"].ToString() + "月應出勤工時", typeof(decimal));
                    zz2z26.Columns.Add(rq_attmon.Rows[i]["mon"].ToString() + "月實際工時", typeof(decimal));
                    zz2z26.Columns.Add(rq_attmon.Rows[i]["mon"].ToString() + "月超時", typeof(decimal));
                    zz2z26.Columns.Add(rq_attmon.Rows[i]["mon"].ToString() + "月加班時數", typeof(decimal));
                    zz2z26.Columns.Add(rq_attmon.Rows[i]["mon"].ToString() + "月請假時數", typeof(decimal));
                }
                zz2z26.Columns.Add("總計應出勤工時", typeof(decimal));
                zz2z26.Columns.Add("總計實際工時", typeof(decimal));
                zz2z26.Columns.Add("總計超時", typeof(decimal));
                zz2z26.Columns.Add("總計加班時數", typeof(decimal));
                zz2z26.Columns.Add("總計請假時數", typeof(decimal));
                zz2z26.PrimaryKey = new DataColumn[] { zz2z26.Columns["員工編號"] };

                DataRow[] SRow = rq_attend.Select("", "depts,dept,nobr asc");
                foreach (DataRow Row in SRow)
                {
                    object[] _value = new object[2];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = Row["mon"].ToString();
                    DataRow row = zz2z26.Rows.Find(Row["nobr"].ToString());
                    DataRow row1 = rq_ot.Rows.Find(_value);
                    DataRow row2 = rq_abs.Rows.Find(_value);

                    if (row != null)
                    {
                        row[Row["mon"].ToString() + "月應出勤工時"] = decimal.Parse(Row["wk_hrs"].ToString());
                        row[Row["mon"].ToString() + "月實際工時"] = decimal.Parse(Row["rel_hrs"].ToString());
                        row[Row["mon"].ToString() + "月超時"] = decimal.Parse(Row["rel_hrs"].ToString()) - decimal.Parse(Row["wk_hrs"].ToString());
                        row[Row["mon"].ToString() + "月加班時數"] = (row1 == null) ? 0 : decimal.Parse(row1["ot_hrs"].ToString());
                        row[Row["mon"].ToString() + "月請假時數"] = (row2 == null) ? 0 : decimal.Parse(row2["tol_hours"].ToString());
                        row["總計應出勤工時"] = decimal.Parse(row["總計應出勤工時"].ToString()) + decimal.Parse(Row["wk_hrs"].ToString());
                        row["總計實際工時"] = decimal.Parse(row["總計實際工時"].ToString()) + decimal.Parse(Row["rel_hrs"].ToString());
                        row["總計超時"] = decimal.Parse(row["總計超時"].ToString()) + (decimal.Parse(Row["rel_hrs"].ToString()) - decimal.Parse(Row["wk_hrs"].ToString()));
                        if (row1 != null)
                            row["總計加班時數"] = decimal.Parse(row["總計加班時數"].ToString()) + decimal.Parse(row1["ot_hrs"].ToString());
                        if (row2 != null)
                            row["總計請假時數"] = decimal.Parse(row["總計請假時數"].ToString()) + decimal.Parse(row2["tol_hours"].ToString());
                    }
                    else
                    {
                        DataRow aRow = zz2z26.NewRow();
                        aRow["員工編號"] = Row["nobr"].ToString();
                        aRow["員工姓名"] = Row["name_c"].ToString();
                        aRow["成本部門"] = Row["ds_name"].ToString();
                        aRow["編制部門"] = Row["d_name"].ToString();
                        aRow[Row["mon"].ToString() + "月應出勤工時"] = decimal.Parse(Row["wk_hrs"].ToString());
                        aRow[Row["mon"].ToString() + "月實際工時"] = decimal.Parse(Row["rel_hrs"].ToString());
                        aRow[Row["mon"].ToString() + "月超時"] = decimal.Parse(Row["rel_hrs"].ToString()) - decimal.Parse(Row["wk_hrs"].ToString());
                        aRow[Row["mon"].ToString() + "月加班時數"] = (row1 == null) ? 0 : decimal.Parse(row1["ot_hrs"].ToString());
                        aRow[Row["mon"].ToString() + "月請假時數"] = (row2 == null) ? 0 : decimal.Parse(row2["tol_hours"].ToString());
                        aRow["總計應出勤工時"] = decimal.Parse(Row["wk_hrs"].ToString());
                        aRow["總計實際工時"] = decimal.Parse(Row["rel_hrs"].ToString());
                        aRow["總計超時"] = decimal.Parse(Row["rel_hrs"].ToString()) - decimal.Parse(Row["wk_hrs"].ToString());
                        aRow["總計加班時數"] = (row1 == null) ? 0 : decimal.Parse(row1["ot_hrs"].ToString());
                        aRow["總計請假時數"] = (row2 == null) ? 0 : decimal.Parse(row2["tol_hours"].ToString());
                        zz2z26.Rows.Add(aRow);
                    }
                }
               

                if (zz2z26.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                if (report_type == "11")
                    JBHR.Reports.ReportClass.Export(zz2z26, this.Name);
                else
                {
                    DataTable zz2z261 = new DataTable();
                    zz2z261.Columns.Add("成本部門", typeof(string));
                    zz2z261.Columns.Add("編制部門", typeof(string));
                    zz2z261.Columns.Add("人數", typeof(int));
                    for (int i = 0; i < rq_attmon.Rows.Count; i++)
                    {
                        zz2z261.Columns.Add(rq_attmon.Rows[i]["mon"].ToString() + "月應出勤工時", typeof(decimal));
                        zz2z261.Columns.Add(rq_attmon.Rows[i]["mon"].ToString() + "月實際工時", typeof(decimal));
                        zz2z261.Columns.Add(rq_attmon.Rows[i]["mon"].ToString() + "月超時", typeof(decimal));
                        zz2z261.Columns.Add(rq_attmon.Rows[i]["mon"].ToString() + "月加班時數", typeof(decimal));
                        zz2z261.Columns.Add(rq_attmon.Rows[i]["mon"].ToString() + "月請假時數", typeof(decimal));
                    }
                    zz2z261.Columns.Add("總計應出勤工時", typeof(decimal));
                    zz2z261.Columns.Add("總計實際工時", typeof(decimal));
                    zz2z261.Columns.Add("總計超時", typeof(decimal));
                    zz2z261.Columns.Add("總計加班時數", typeof(decimal));
                    zz2z261.Columns.Add("總計請假時數", typeof(decimal));
                    zz2z261.PrimaryKey = new DataColumn[] { zz2z261.Columns["成本部門"], zz2z261.Columns["編制部門"] };
                    foreach (DataRow Row in zz2z26.Rows)
                    {
                        object[] _value = new object[2];
                        _value[0] = Row["成本部門"].ToString();
                        _value[1] = Row["編制部門"].ToString();
                        DataRow row1 = zz2z261.Rows.Find(_value);
                        if (row1 != null)
                        {
                            row1["人數"] = int.Parse(row1["人數"].ToString()) + 1;
                            for (int i = 0; i < rq_attmon.Rows.Count; i++)
                            {
                                if (!Row.IsNull(rq_attmon.Rows[i]["mon"].ToString() + "月應出勤工時"))
                                    row1[rq_attmon.Rows[i]["mon"].ToString() + "月應出勤工時"] = decimal.Parse(row1[rq_attmon.Rows[i]["mon"].ToString() + "月應出勤工時"].ToString()) + decimal.Parse(Row[rq_attmon.Rows[i]["mon"].ToString() + "月應出勤工時"].ToString());
                                if (!Row.IsNull(rq_attmon.Rows[i]["mon"].ToString() + "月實際工時"))
                                    row1[rq_attmon.Rows[i]["mon"].ToString() + "月實際工時"] = decimal.Parse(row1[rq_attmon.Rows[i]["mon"].ToString() + "月實際工時"].ToString()) + decimal.Parse(Row[rq_attmon.Rows[i]["mon"].ToString() + "月實際工時"].ToString());
                                if (!Row.IsNull(rq_attmon.Rows[i]["mon"].ToString() + "月超時"))
                                    row1[rq_attmon.Rows[i]["mon"].ToString() + "月超時"] = decimal.Parse(row1[rq_attmon.Rows[i]["mon"].ToString() + "月超時"].ToString()) + decimal.Parse(Row[rq_attmon.Rows[i]["mon"].ToString() + "月超時"].ToString());
                                if (!Row.IsNull(rq_attmon.Rows[i]["mon"].ToString() + "月加班時數"))
                                    row1[rq_attmon.Rows[i]["mon"].ToString() + "月加班時數"] = decimal.Parse(row1[rq_attmon.Rows[i]["mon"].ToString() + "月加班時數"].ToString()) + decimal.Parse(Row[rq_attmon.Rows[i]["mon"].ToString() + "月加班時數"].ToString());
                                if (!Row.IsNull(rq_attmon.Rows[i]["mon"].ToString() + "月請假時數"))
                                    row1[rq_attmon.Rows[i]["mon"].ToString() + "月請假時數"] = decimal.Parse(row1[rq_attmon.Rows[i]["mon"].ToString() + "月請假時數"].ToString()) + decimal.Parse(Row[rq_attmon.Rows[i]["mon"].ToString() + "月請假時數"].ToString());
                            }
                            row1["總計應出勤工時"] = decimal.Parse(row1["總計應出勤工時"].ToString()) + decimal.Parse(Row["總計應出勤工時"].ToString());
                            row1["總計實際工時"] = decimal.Parse(row1["總計實際工時"].ToString()) + decimal.Parse(Row["總計實際工時"].ToString());
                            row1["總計超時"] = decimal.Parse(row1["總計超時"].ToString()) + decimal.Parse(Row["總計超時"].ToString());
                            row1["總計加班時數"] = decimal.Parse(row1["總計加班時數"].ToString()) + decimal.Parse(Row["總計加班時數"].ToString());
                            row1["總計請假時數"] = decimal.Parse(row1["總計請假時數"].ToString()) + decimal.Parse(Row["總計請假時數"].ToString());
                        }
                        else
                        {
                            DataRow aRow = zz2z261.NewRow();
                            aRow["成本部門"] = Row["成本部門"].ToString();
                            aRow["編制部門"] = Row["編制部門"].ToString();
                            aRow["人數"] = 1;
                            for (int i = 0; i < rq_attmon.Rows.Count; i++)
                            {
                                aRow[rq_attmon.Rows[i]["mon"].ToString() + "月應出勤工時"] = 0;
                                aRow[rq_attmon.Rows[i]["mon"].ToString() + "月實際工時"] = 0;
                                aRow[rq_attmon.Rows[i]["mon"].ToString() + "月超時"] = 0;
                                aRow[rq_attmon.Rows[i]["mon"].ToString() + "月加班時數"] = 0;
                                aRow[rq_attmon.Rows[i]["mon"].ToString() + "月請假時數"] = 0;
                                if (!Row.IsNull(rq_attmon.Rows[i]["mon"].ToString() + "月應出勤工時"))
                                    aRow[rq_attmon.Rows[i]["mon"].ToString() + "月應出勤工時"] = decimal.Parse(Row[rq_attmon.Rows[i]["mon" ].ToString()+ "月應出勤工時"].ToString());
                                if (!Row.IsNull(rq_attmon.Rows[i]["mon"].ToString() + "月實際工時"))
                                    aRow[rq_attmon.Rows[i]["mon"].ToString() + "月實際工時"] = decimal.Parse(Row[rq_attmon.Rows[i]["mon"].ToString() + "月實際工時"].ToString());
                                if (!Row.IsNull(rq_attmon.Rows[i]["mon"].ToString() + "月超時"))
                                    aRow[rq_attmon.Rows[i]["mon"].ToString() + "月超時"] = decimal.Parse(Row[rq_attmon.Rows[i]["mon"].ToString() + "月超時"].ToString());
                                if (!Row.IsNull(rq_attmon.Rows[i]["mon"].ToString() + "月加班時數"))
                                    aRow[rq_attmon.Rows[i]["mon"].ToString() + "月加班時數"] = decimal.Parse(Row[rq_attmon.Rows[i]["mon"].ToString() + "月加班時數"].ToString());
                                if (!Row.IsNull(rq_attmon.Rows[i]["mon"].ToString() + "月請假時數"))
                                    aRow[rq_attmon.Rows[i]["mon"].ToString() + "月請假時數"] = decimal.Parse(Row[rq_attmon.Rows[i]["mon"].ToString() + "月請假時數"].ToString());
                            }
                            aRow["總計應出勤工時"] = decimal.Parse(Row["總計應出勤工時"].ToString());
                            aRow["總計實際工時"] = decimal.Parse(Row["總計實際工時"].ToString());
                            aRow["總計超時"] = decimal.Parse(Row["總計超時"].ToString());
                            aRow["總計加班時數"] = decimal.Parse(Row["總計加班時數"].ToString());
                            aRow["總計請假時數"] = decimal.Parse(Row["總計請假時數"].ToString());
                            zz2z261.Rows.Add(aRow);
                        }
                    }
                    zz2z26 = null;
                    JBHR.Reports.ReportClass.Export(zz2z261, this.Name);
                    
                }
                this.Close();
                rq_abs = null; rq_attend = null; rq_attmon = null; rq_base = null; rq_ot = null; rq_abs1 = null; rq_attend1 = null;
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
