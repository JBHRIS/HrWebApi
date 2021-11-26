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
    public partial class ZZ2ZA_Report : JBControls.JBForm
    {
        attenddata ds = new attenddata();
        string nobr_b, nobr_e, depts_b, depts_e, date_b, date_e, yymm_b, yymm_e, comp_b, comp_e, indt, type_data, note1, order, date_type, username, comp_name;
        bool exportexcel;
        public ZZ2ZA_Report(string nobrb, string nobre, string deptsb, string deptse, string dateb, string datee, string yymmb, string yymme, string compb, string compe, string _indt, string typedata, string _note1, string _order, bool _exportexcel, string datetype, string _username, string compname)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; depts_b = deptsb; depts_e = deptse; date_b = dateb;
            date_e = datee; indt = _indt; yymm_b = yymmb; yymm_e = yymme; comp_b = compb;
            comp_e = compe; type_data = typedata; note1 = _note1; order = _order;
            exportexcel = _exportexcel; date_type = datetype; username = _username;
            comp_name = compname;
        }

        private void ZZ2ZA_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");               
                //加班
                string sqlBase = "select b.nobr,a.name_c,a.name_e,c.d_no_disp as depts,c.d_name,e.jobl_disp as jobl,e.job_name as jobl_name";
                sqlBase += " from base a,basetts b";
                sqlBase += " left outer join depts c on b.depts=c.d_no";
                sqlBase += " left outer join jobl e on  b.jobl=e.jobl";
                sqlBase += " where a.nobr=b.nobr and b.depts=c.d_no";
                sqlBase += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
                sqlBase += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlBase += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", depts_b, depts_e);
                sqlBase += string.Format(@" and b.comp between '{0}' and '{1}'", comp_b, comp_e);
                sqlBase += type_data;
                DataTable rq_base = SqlConn.GetDataTable(sqlBase);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                string sqlOt = "select a.nobr,a.bdate,a.btime,a.etime,a.ot_hrs,a.rest_hrs,a.rest_hrs,a.ot_car";
                sqlOt += " from ot a";
                if (date_type == "1") sqlOt += string.Format(@" where a.yymm between '{0}' and '{1}'", yymm_b, yymm_e);
                if (date_type == "2") sqlOt += string.Format(@" where a.bdate between '{0}' and '{1}'", date_b, date_e);
                sqlOt += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlOt += " order by a.nobr,a.bdate";
                DataTable rq_ot = SqlConn.GetDataTable(sqlOt);
                rq_ot.Columns.Add("name_c", typeof(string));
                rq_ot.Columns.Add("name_e", typeof(string));
                rq_ot.Columns.Add("depts", typeof(string));
                rq_ot.Columns.Add("d_name", typeof(string));
                rq_ot.Columns.Add("jobl", typeof(string));
                rq_ot.Columns.Add("jobl_name", typeof(string));
                foreach (DataRow Row in rq_ot.Rows)
                {
                    string bdate = DateTime.Parse(Row["bdate"].ToString()).ToString("yyyyMMdd");
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        Row["name_c"] = row["name_c"].ToString();
                        Row["name_e"] = row["name_e"].ToString();
                        Row["depts"] = row["depts"].ToString();
                        Row["d_name"] = row["d_name"].ToString();
                        //Row["d_ename"] = row["d_ename"].ToString();
                        Row["jobl"] = row["jobl"].ToString();
                        Row["jobl_name"] = row["jobl_name"].ToString();
                    }
                    else
                        Row.Delete();
                }
                rq_ot.AcceptChanges();

                string sqlAbs = "select a.nobr, a.bdate, a.h_code, a.h_name, a.tol_hours, a.unit from absbasetts a inner join abs b on a.nobr = b.nobr ";
                sqlAbs += " and a.bdate = b.bdate ";
                sqlAbs += " and a.edate = b.edate ";
                sqlAbs += " and a.btime = b.btime ";
                sqlAbs += " and a.etime = b.etime ";
                sqlAbs += " and a.h_code = b.h_code ";
                sqlAbs += " and a.tol_hours = b.tol_hours ";
                sqlAbs += " where 1=1 ";
                if (date_type == "1") sqlAbs += string.Format(@" and b.yymm between '{0}' and '{1}'", yymm_b, yymm_e);
                if (date_type == "2") sqlAbs += string.Format(@" and a.bdate between '{0}' and '{1}'", date_b, date_e);
                sqlAbs += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlAbs += " and a.year_rest not in ('1','3') order by a.nobr,a.bdate";
                DataTable rq_abs = SqlConn.GetDataTable(sqlAbs);
                rq_abs.Columns.Add("name_c", typeof(string));
                rq_abs.Columns.Add("name_e", typeof(string));
                rq_abs.Columns.Add("depts", typeof(string));
                rq_abs.Columns.Add("d_name", typeof(string));
                rq_abs.Columns.Add("jobl", typeof(string));
                rq_abs.Columns.Add("jobl_name", typeof(string));
                foreach (DataRow Row in rq_abs.Rows)
                {
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        Row["name_c"] = row["name_c"].ToString();
                        Row["name_e"] = row["name_e"].ToString();
                        Row["depts"] = row["depts"].ToString();
                        Row["d_name"] = row["d_name"].ToString();
                        Row["jobl"] = row["jobl"].ToString();
                        Row["jobl_name"] = row["jobl_name"].ToString();
                    }
                    else
                        Row.Delete();
                }
                rq_abs.AcceptChanges();

                DataTable rq_attend1 = new DataTable();
                rq_attend1 = ds.Tables["zz2za"].Clone();
                rq_attend1.TableName = "rq_attend1";
                string str_nobr1 = ""; string str_bdate1 = ""; int _abscount = 1;
                foreach (DataRow Row in rq_abs.Rows)
                {
                    string str_nobr = Row["nobr"].ToString();
                    string str_badate = DateTime.Parse(Row["bdate"].ToString()).ToString("yyyy/MM/dd");
                    if (str_nobr==str_nobr1 && str_badate==str_bdate1)
                        _abscount=_abscount+1;
                    else
                        _abscount=1;
                    string sqlAttend = "select a.nobr,a.adate,b.rote_disp as rote,rotename,datename(dw,a.adate) as dw ";
                    sqlAttend += " from attend a,rote b where a.rote=b.rote";
                    sqlAttend += string.Format(@" and nobr='{0}'  and adate='{1}'", str_nobr, str_badate);                   
                    DataTable rq_attend = SqlConn.GetDataTable(sqlAttend);
                    if (rq_attend.Rows.Count>0)
                    {
                        DataRow aRow = rq_attend1.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["name_c"] = Row["name_c"].ToString();
                        aRow["name_e"] = Row["name_e"].ToString();
                        aRow["depts"] = Row["depts"].ToString();
                        aRow["d_name"] = Row["d_name"].ToString();
                        aRow["unit"] = Row["unit"].ToString();
                        aRow["jobl"] = Row["jobl"].ToString();
                        aRow["jobl_name"] = Row["jobl_name"].ToString();
                        aRow["rote"] = rq_attend.Rows[0]["rote"].ToString();
                        aRow["rotename"] = rq_attend.Rows[0]["rotename"].ToString();
                        aRow["adate"] = DateTime.Parse(rq_attend.Rows[0]["adate"].ToString());
                        aRow["dw"] = rq_attend.Rows[0]["dw"].ToString().Substring(2, 1);
                        aRow["h_name"] = Row["h_name"].ToString();
                        aRow["tol_hours"] = decimal.Parse(Row["tol_hours"].ToString());
                        aRow["ot_btime"] = "";
                        aRow["abscount"] = _abscount;
                        rq_attend1.Rows.Add(aRow);
                    }
                    rq_attend.Clear();
                    str_nobr1 = Row["nobr"].ToString();
                    str_bdate1 = DateTime.Parse(Row["bdate"].ToString()).ToString("yyyy/MM/dd");
                }

                DataColumn[] _key1 = new DataColumn[4];
                _key1[0] = rq_attend1.Columns["nobr"];
                _key1[1] = rq_attend1.Columns["adate"];
                _key1[2] = rq_attend1.Columns["abscount"];
                _key1[3] = rq_attend1.Columns["ot_btime"];
                rq_attend1.PrimaryKey = _key1;
                foreach (DataRow Row in rq_ot.Rows)
                {
                    string str_nobr = Row["nobr"].ToString();
                    string str_badate = DateTime.Parse(Row["bdate"].ToString()).ToString("yyyy/MM/dd");
                    if (str_nobr == str_nobr1 && str_badate == str_bdate1)
                        _abscount = _abscount + 1;
                    else
                        _abscount = 1;
                    object[] _value1 = new object[4];
                    _value1[0]=Row["nobr"].ToString();
                    _value1[1]=DateTime.Parse(Row["bdate"].ToString()).ToString("yyyy/MM/dd");
                    _value1[2] = _abscount;
                    _value1[3] = Row["btime"].ToString();
                    DataRow row = rq_attend1.Rows.Find(_value1);
                    if (row!=null)
                    {
                        row["ot_btime"] = Row["btime"].ToString();
                        row["ot_etime"] = Row["etime"].ToString();
                        row["ot_hrs"] = decimal.Parse(Row["ot_hrs"].ToString());
                        row["rest_hrs"] = decimal.Parse(Row["rest_hrs"].ToString());
                        row["ot_car"] = decimal.Round(decimal.Parse(Row["ot_car"].ToString()), 0);
                    }
                    else
                    {
                        string sqlAttend = "select a.nobr,a.adate,b.rote_disp as rote,b.rotename,datename(dw,a.adate) as dw from attend a";
                        sqlAttend += " left outer join rote b on a.rote=b.rote";
                        sqlAttend += string.Format(@" where a.nobr='{0}'  and a.adate='{1}'", str_nobr, str_badate);
                        DataTable rq_attenda = SqlConn.GetDataTable(sqlAttend);
                        if (rq_attenda.Rows.Count >0)
                        {
                            DataRow aRow = rq_attend1.NewRow();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["name_c"] = Row["name_c"].ToString();
                            aRow["name_e"] = Row["name_e"].ToString();
                            aRow["depts"] = Row["depts"].ToString();
                            aRow["d_name"] = Row["d_name"].ToString();
                            aRow["jobl"] = Row["jobl"].ToString();
                            aRow["jobl_name"] = Row["jobl_name"].ToString();
                            aRow["rote"] = rq_attenda.Rows[0]["rote"].ToString();
                            aRow["rotename"] = rq_attenda.Rows[0]["rotename"].ToString();
                            aRow["adate"] = DateTime.Parse(rq_attenda.Rows[0]["adate"].ToString());
                            aRow["dw"] = rq_attenda.Rows[0]["dw"].ToString().Substring(2, 1);
                            aRow["tol_hours"] = 0;
                            aRow["ot_btime"] = Row["btime"].ToString();
                            aRow["ot_etime"] = Row["etime"].ToString();
                            aRow["ot_hrs"] = decimal.Parse(Row["ot_hrs"].ToString());
                            aRow["rest_hrs"] = decimal.Parse(Row["rest_hrs"].ToString());
                            aRow["ot_car"] = decimal.Round(decimal.Parse(Row["ot_car"].ToString()), 0);
                            aRow["abscount"] = _abscount;
                            rq_attend1.Rows.Add(aRow);
                        }
                        rq_attenda.Clear();
                    }
                    str_nobr1 = Row["nobr"].ToString();
                    str_bdate1 = DateTime.Parse(Row["bdate"].ToString()).ToString("yyyy/MM/dd");
                }

                //刷卡資料
                //string sql_Attcard = "select nobr,adate,tt1,tt2 from attcard";
                //sql_Attcard += string.Format(@" where adate between '{0}' and '{1}'", date_b, date_e);
                //sql_Attcard += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                //DataTable rq_attcard = SqlConn.GetDataTable(sql_Attcard);
                //rq_attcard.PrimaryKey = new DataColumn[] { rq_attcard.Columns["nobr"], rq_attcard.Columns["adate"] };
                string sql_Attcard = "select nobr,adate,min(t1) as t1,min(tt1) as tt1 from attcard";
                sql_Attcard += string.Format(@" where adate between '{0}' and '{1}'", date_b, date_e);
                sql_Attcard += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);                
                sql_Attcard += " group by nobr,adate order by adate";
                DataTable rq_attcard = SqlConn.GetDataTable(sql_Attcard);
                rq_attcard.Columns.Add("t2", typeof(string));
                rq_attcard.Columns.Add("tt2", typeof(string));
                rq_attcard.PrimaryKey = new DataColumn[] { rq_attcard.Columns["nobr"], rq_attcard.Columns["adate"] };

                string sql_Attcard1 = "select nobr,adate,max(t2) as t2,max(tt2) as tt2 from attcard";
                sql_Attcard1 += string.Format(@" where adate between '{0}' and '{1}'", date_b, date_e);
                sql_Attcard1 += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sql_Attcard1 += " group by nobr,adate order by adate";
                DataTable rq_attcard1 = SqlConn.GetDataTable(sql_Attcard1);
                rq_attcard1.PrimaryKey = new DataColumn[] { rq_attcard1.Columns["nobr"], rq_attcard1.Columns["adate"] };
                foreach (DataRow Row in rq_attcard.Rows)
                {
                    object[] _value = new object[2];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = DateTime.Parse(Row["adate"].ToString());
                    DataRow row = rq_attcard1.Rows.Find(_value);
                    if (row != null)
                    {
                        Row["t2"] = row["t2"].ToString();
                        Row["tt2"] = row["tt2"].ToString();
                    }
                    else
                    {
                        Row["t2"] = "";
                        Row["tt2"] = "";
                    }
                }

                DataRow[] rowo = rq_attend1.Select("", "depts,jobl asc");
                foreach (DataRow Row in rowo)
                {
                    object[] _value = new object[2];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = DateTime.Parse(Row["adate"].ToString());
                    DataRow row1 = rq_attcard.Rows.Find(_value);
                    if (row1 != null)
                    {
                        Row["tt1"] = row1["tt1"].ToString();
                        Row["tt2"] = row1["tt2"].ToString();
                    }
                    ds.Tables["zz2za"].ImportRow(Row);
                }
                rq_abs = null; rq_attend1 = null; rq_base = null; rq_ot = null; rq_attcard = null;
                if (ds.Tables["zz2za"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                if (exportexcel)
                {                   
                    Export(ds.Tables["zz2za"]);
                    this.Close();
                }
                else
                {                   
                    RptViewer.Reset();
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "AttReport", "*.rdlc");
                    if (order == "1")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz2za.rdlc";
                    else
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz2za1.rdlc";
                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("UserName", username) });
                    if (order == "1")
                    {
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", yymm_b) });
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", yymm_e) });
                    }
                    else
                    {
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Memo", note1) });
                    }
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_zz2za", ds.Tables["zz2za"]));
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
            ExporDt.Columns.Add("職等代碼", typeof(string));
            ExporDt.Columns.Add("職等", typeof(string));
            ExporDt.Columns.Add("成本部門代碼", typeof(string));
            ExporDt.Columns.Add("成本部門名稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            ExporDt.Columns.Add("出勤日期", typeof(DateTime));
            ExporDt.Columns.Add("星期", typeof(string));
            ExporDt.Columns.Add("假別", typeof(string));
            ExporDt.Columns.Add("班別代碼", typeof(string));
            ExporDt.Columns.Add("班別", typeof(string));
            ExporDt.Columns.Add("上班時間", typeof(string));
            ExporDt.Columns.Add("下班時間", typeof(string));
            ExporDt.Columns.Add("請假時數", typeof(decimal));
            ExporDt.Columns.Add("單位", typeof(string));
            ExporDt.Columns.Add("加起時間", typeof(string));
            ExporDt.Columns.Add("加迄時間", typeof(string));
            ExporDt.Columns.Add("補休時數", typeof(decimal));
            ExporDt.Columns.Add("加班時數", typeof(decimal));
            //ExporDt.Columns.Add("誤餐次數", typeof(int));
            foreach (DataRow Row in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["職等代碼"] = Row["jobl"].ToString();
                aRow["職等"] = Row["jobl_name"].ToString();
                aRow["成本部門代碼"] = Row["depts"].ToString();
                aRow["成本部門名稱"] = Row["d_name"].ToString();
                aRow["員工編號"] = Row["nobr"].ToString();
                aRow["員工姓名"] = Row["name_c"].ToString();
                aRow["英文姓名"] = Row["name_e"].ToString();
                aRow["出勤日期"] = DateTime.Parse(Row["adate"].ToString());
                aRow["星期"] = Row["dw"].ToString();
                aRow["假別"] = Row["h_name"].ToString();
                aRow["班別代碼"] = Row["rote"].ToString();
                aRow["班別"] = Row["rotename"].ToString();
                aRow["上班時間"] = Row["tt1"].ToString();
                aRow["下班時間"] = Row["tt2"].ToString();
                aRow["請假時數"] = decimal.Parse(Row["tol_hours"].ToString());
                aRow["單位"] = Row["unit"].ToString();
                aRow["加起時間"] = Row["ot_btime"].ToString();
                aRow["加迄時間"] = Row["ot_etime"].ToString();
                aRow["補休時數"] = Row["rest_hrs"].ToString().Trim() == "" ? 0 : decimal.Parse(Row["rest_hrs"].ToString());
                aRow["加班時數"] = Row["ot_hrs"].ToString().Trim() == "" ? 0 : decimal.Parse(Row["ot_hrs"].ToString());
                //aRow["誤餐次數"] = Row["ot_car"].ToString().Trim() == "" ? 0 : int.Parse(Row["ot_car"].ToString()); ;
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
