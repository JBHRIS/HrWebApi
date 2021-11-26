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
    public partial class ZZ22_Report : JBControls.JBForm
    {      
        attenddata ds = new attenddata();
        DataTable rq_attend = new DataTable();
        DataTable rq_attcard = new DataTable("rq_attcard");
        string nobr_b, nobr_e, emp_b, emp_e, dept_b, dept_e, depts_b, depts_e, work_b, work_e, comp_b, comp_e, yymm_b, yymm_e, date_b, date_e, username, comp_name;
        string indt, reporttype, date_type, type_data, noen, saladr_b, saladr_e, CompId;
        bool exportexcel, labcheck;

        public ZZ22_Report(string nobrb, string nobre, string empb, string empe, string deptb, string depte, string deptsb, string deptse, string workb, string worke, string compb, string compe, string yymmb, string yymme, string dateb, string datee, string saladrb, string saladre, string _indt, string report_type, string typedata, string datetype, string _noen, bool _labcheck, bool _exportexcel, string _username, string compname, string _CompId)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; emp_b = empb; emp_e = empe; dept_b = deptb; dept_e = depte;
            depts_b = deptsb; depts_e = deptse; work_b = workb;
            work_e = worke; comp_b = compb; comp_e = compe; yymm_b = yymmb; yymm_e = yymme;
            date_b = dateb; date_e = datee; indt = _indt; reporttype = report_type;
            type_data = typedata; date_type = datetype; exportexcel = _exportexcel; noen = _noen;
            labcheck = _labcheck; username = _username; saladr_b = saladrb; saladr_e = saladre;
            comp_name = compname; CompId = _CompId;
        }

        private void ZZ22_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                DataTable rq_sys3 = SqlConn.GetDataTable("select malemaxhrs,femalemaxhrs from u_sys3 where comp='" + CompId + "'");
                decimal malemaxhrs = 0; decimal femalemaxhrs = 0;
                if (rq_sys3.Rows.Count > 0)
                {
                    malemaxhrs = decimal.Parse(rq_sys3.Rows[0]["malemaxhrs"].ToString());
                    femalemaxhrs = decimal.Parse(rq_sys3.Rows[0]["femalemaxhrs"].ToString());
                }
                string CmdBase = "select b.nobr,a.name_c,a.name_e,c.d_no_disp as dept,c.d_name,c.d_ename,d.d_no_disp as depts,d.d_name as ds_name,sex ";
                CmdBase += " from base a,basetts b ";
                CmdBase += " left outer join dept c on b.dept=c.d_no";
                CmdBase += " left outer join depts d on b.depts=d.d_no";
                CmdBase += string.Format(@" where '{0}' between b.adate and b.ddate ", indt);
                CmdBase += " and a.nobr=b.nobr";
                CmdBase += string.Format(@" and a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                CmdBase += string.Format(@" and c.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                CmdBase += string.Format(@" and d.d_no_disp between '{0}' and '{1}'", depts_b, depts_e);
                CmdBase += string.Format(@" and b.empcd between '{0}' and '{1}'", emp_b, emp_e);
                CmdBase += string.Format(@" and b.workcd between '{0}' and '{1}'", work_b, work_e);
                CmdBase += string.Format(@" and b.comp between '{0}' and '{1}'", comp_b, comp_e);
                CmdBase += string.Format(@" and b.saladr between '{0}' and '{1}'", saladr_b, saladr_e);
                CmdBase += type_data;
                CmdBase += " order by b.nobr";
                DataTable rq_base = SqlConn.GetDataTable(CmdBase);
                rq_base.Columns.Add("otmaxhrs",typeof(decimal));
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };
                foreach (DataRow Row in rq_base.Rows)
                {
                    //if (Row["sex"].ToString().Trim() == "M")
                    //    Row["otmaxhrs"] = malemaxhrs;
                    //else if (Row["sex"].ToString().Trim() == "F")
                    //    Row["otmaxhrs"] = femalemaxhrs;
                    Row["otmaxhrs"] = femalemaxhrs;
                }
                rq_sys3 = null;

                string str_depts = "select d_no,d_no_disp,d_name from depts";
                DataTable rq_depts = SqlConn.GetDataTable(str_depts);
                rq_depts.PrimaryKey = new DataColumn[] { rq_depts.Columns["d_no"] };

                string CmdOt = "select a.*,0000 as cnt,convert(bit,1) as err,'' as ttime,b.otrname,";
                CmdOt += "datename(dw,a.bdate) as dw,c.rote_disp from ot a ";
                CmdOt += " left outer join otrcd b on a.otrcd=b.otrcd";
                CmdOt += " left outer join rote c on a.ot_rote=c.rote";
                CmdOt += string.Format(@" where a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                if (date_type == "1") CmdOt += string.Format(@" and a.yymm between '{0}' and '{1}'", yymm_b, yymm_e);
                if (date_type == "2") CmdOt += string.Format(@" and a.bdate between '{0}' and '{1}'", date_b, date_e);
                if(reporttype=="4")   CmdOt += noen;
                DataTable rq_ot = SqlConn.GetDataTable(CmdOt);

                foreach (DataRow Row in rq_ot.Rows)
                {
                    Row["salary"] = 0;
                    Row["tot_exp"] = 0;
                    Row["not_exp"] = 0;
                    Row["rest_exp"] = 0;
                    if (labcheck)
                    {
                        DataRow row1 = rq_base.Rows.Find(Row["nobr"].ToString());
                        if (row1 != null)
                        {
                            if ((decimal.Parse(Row["fst_hours"].ToString()) + decimal.Parse(Row["ot_hrs"].ToString())) > decimal.Parse(row1["otmaxhrs"].ToString()))
                                Row.Delete();
                        }
                        else
                            Row.Delete();
                    }
                }
                rq_ot.AcceptChanges();

                if (reporttype == "4")
                {
                    rq_attcard.Columns.Add("nobr", typeof(string));
                    rq_attcard.Columns.Add("bdate", typeof(DateTime));
                    rq_attcard.Columns.Add("ttime", typeof(string));

                    foreach (DataRow row1 in rq_ot.Rows)
                    {
                        string str1 = row1["nobr"].ToString();
                        string str2 = Convert.ToDateTime(row1["bdate"].ToString()).ToShortDateString();
                        string CmdAcard = "select * from attcard where ";
                        CmdAcard += string.Format(@" nobr ='{0}' and adate= '{1}'", str1, str2);
                        CmdAcard += " order by t1";
                        DataTable rq_acard = SqlConn.GetDataTable(CmdAcard);
                        string ttime = "";
                        bool err = true;                       
                        foreach (DataRow row2 in rq_acard.Rows)
                        {
                            string str_t1 = (row2["t1"].ToString().Trim()=="") ? "0" : row2["t1"].ToString();
                            string str_t2 = (row2["t2"].ToString().Trim()=="") ? "0" : row2["t2"].ToString();
                            //DataRow[] row3 = rq_ot.Select("btime>='" + str_t1 + "' and etime <='" + str_t2 + "'");
                            ttime = ttime + row2["t1"].ToString() + "-" + row2["t2"].ToString();
                            if (Convert.ToBoolean(row1["err"].ToString()))
                            {
                                if (decimal.Parse( row1["btime"].ToString()) >=decimal.Parse(str_t1) || decimal.Parse(row1["etime"].ToString()) <=decimal.Parse(str_t2))
                                    err = false;
                                else
                                    err = true;
                            }
                            else
                                err = false;
                        }                        
                        row1["err"] = err;
                        DataRow aRow = rq_attcard.NewRow();
                        aRow["nobr"] = str1;
                        aRow["bdate"] = Convert.ToDateTime(str2);
                        aRow["ttime"] = ttime;
                        rq_attcard.Rows.Add(aRow);
                        rq_acard = null;
                    }
                }

                 
                
                int _i = 0;
                foreach (DataRow row4 in rq_ot.Rows)
                {
                    string str1 = row4["nobr"].ToString();
                    string str_bdate = Convert.ToDateTime(row4["bdate"].ToString()).ToShortDateString();
                    DataRow row5 = rq_base.Rows.Find(str1);
                    DataRow row6 = rq_depts.Rows.Find(row4["ot_dept"].ToString());
                    if (row5 != null)
                    {
                        DataRow aRow = ds.Tables["zz22"].NewRow();
                        aRow["nobr"] = str1;
                        aRow["name_c"] = row5["name_c"].ToString();
                        aRow["name_e"] = row5["name_e"].ToString();
                        aRow["dept"] = row5["dept"].ToString();
                        aRow["depts"] = row5["depts"].ToString();
                        aRow["ds_name"] = row5["ds_name"].ToString();                       
                        aRow["ttime"] = row4["ttime"].ToString();
                        aRow["bdate"] = Convert.ToDateTime(row4["bdate"].ToString());
                        aRow["dw"] = row4["dw"].ToString().Substring(2, 1);
                        aRow["btime"] = row4["btime"].ToString();
                        aRow["etime"] = row4["etime"].ToString();
                        aRow["tot_hours"] = Convert.ToDecimal(row4["tot_hours"].ToString());
                        aRow["ot_hrs"] = Convert.ToDecimal(row4["ot_hrs"].ToString());
                        aRow["rest_hrs"] = Convert.ToDecimal(row4["rest_hrs"].ToString());
                        aRow["yymm"] = row4["yymm"].ToString();
                        aRow["ot_rote"] = row4["rote_disp"].ToString();
                        //aRow["ot_car"] = decimal.Round(decimal.Parse(row4["ot_car"].ToString()), 0);
                        aRow["ot_car"] = decimal.Round(decimal.Parse(row4["ot_food1"].ToString()), 0);
                        aRow["not_w_133"] = Convert.ToDecimal(row4["not_w_133"].ToString());
                        aRow["not_w_167"] = Convert.ToDecimal(row4["not_w_167"].ToString());
                        aRow["not_w_200"] = Convert.ToDecimal(row4["not_w_200"].ToString());
                        aRow["not_h_133"] = Convert.ToDecimal(row4["not_h_133"].ToString());
                        aRow["not_h_167"] = Convert.ToDecimal(row4["not_h_167"].ToString());
                        aRow["not_h_200"] = Convert.ToDecimal(row4["not_h_200"].ToString());
                        aRow["tot_w_133"] = Convert.ToDecimal(row4["tot_w_133"].ToString());
                        aRow["tot_w_167"] = Convert.ToDecimal(row4["tot_w_167"].ToString());
                        aRow["tot_w_200"] = Convert.ToDecimal(row4["tot_w_200"].ToString());
                        aRow["tot_h_200"] = Convert.ToDecimal(row4["tot_h_200"].ToString());
                        aRow["not_exp"] = Convert.ToDecimal(row4["not_exp"].ToString());
                        aRow["tot_exp"] = Convert.ToDecimal(row4["tot_exp"].ToString());
                        aRow["rest_exp"] = Convert.ToDecimal(row4["rest_exp"].ToString());
                        aRow["fst_hours"] = Convert.ToDecimal(row4["fst_hours"].ToString());
                        //aRow["NOT_W_133"] = Convert.ToDecimal(row4["NOT_W_133"].ToString());
                        aRow["TOT_W_133"] = Convert.ToDecimal(row4["TOT_W_133"].ToString());
                        aRow["NOT_W_100"] = Convert.ToDecimal(row4["NOT_W_100"].ToString());
                        aRow["TOT_W_100"] = Convert.ToDecimal(row4["TOT_W_100"].ToString());
                        aRow["d_name"] = row5["d_name"].ToString();
                        aRow["d_ename"] = row5["d_ename"].ToString();
                        aRow["otrname"] = row4["otrname"].ToString();
                        if (row6 != null)
                        {
                            aRow["ot_dept"] = row6["d_no_disp"].ToString();
                            aRow["otdname"] = row6["d_name"].ToString();
                        }
                        if (reporttype == "4")
                            aRow["ttime"] = rq_attcard.Rows[_i]["ttime"].ToString();
                        ds.Tables["zz22"].Rows.Add(aRow);
                    }
                    _i++;
                }

                if (ds.Tables["zz22"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                
                rq_attcard = null;
                rq_attend = null;
                rq_base = null;
                rq_ot = null;
                rq_depts = null;

                if (exportexcel)
                {
                    Export(ds.Tables["zz22"]);
                    this.Close();
                }
                else
                {                              
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "AttReport");                   
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "AttReport", "*.rdlc");
                    
                    if (reporttype == "0")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz22.rdlc";
                    else if (reporttype == "1")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz221.rdlc";
                    else if (reporttype == "2")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz222.rdlc";
                    else if (reporttype == "3")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz223.rdlc";
                    else if (reporttype == "4")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz224.rdlc";
                    else if (reporttype == "5")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz225.rdlc";
                    RptViewer.LocalReport.DataSources.Clear();
                    if (reporttype != "5") RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                    if (reporttype != "5")
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_zz22", ds.Tables["zz22"]));
                    else
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_zz221", ds.Tables["zz221"]));
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

        void Export(DataTable DT)
        {
            DataTable ExporDt = new DataTable();
            DataRow[] DTrow;
            switch (reporttype)
            {
                case "0":
                    ExporDt.Columns.Add("部門代碼", typeof(string));
                    ExporDt.Columns.Add("部門名稱", typeof(string));
                    ExporDt.Columns.Add("部門英文名稱", typeof(string));
                    ExporDt.Columns.Add("員工編號", typeof(string));
                    ExporDt.Columns.Add("員工姓名", typeof(string));
                    ExporDt.Columns.Add("英文姓名", typeof(string));
                    ExporDt.Columns.Add("日期", typeof(DateTime));
                    ExporDt.Columns.Add("星期", typeof(string));
                    ExporDt.Columns.Add("起時間", typeof(string));
                    ExporDt.Columns.Add("迄時間", typeof(string));
                    ExporDt.Columns.Add("加班時數", typeof(decimal));
                    ExporDt.Columns.Add("補休時數", typeof(decimal));
                    ExporDt.Columns.Add("誤餐費", typeof(int));
                    ExporDt.Columns.Add("年月", typeof(string));
                    DTrow = DT.Select("", "dept,nobr,bdate asc");
                    foreach (DataRow Row in DTrow)
                    {
                        DataRow aRow = ExporDt.NewRow();
                        aRow["部門代碼"] = Row["dept"].ToString();
                        aRow["部門名稱"] = Row["d_name"].ToString();
                        aRow["部門英文名稱"] = Row["d_ename"].ToString();
                        aRow["員工編號"] = Row["nobr"].ToString();
                        aRow["員工姓名"] = Row["name_c"].ToString();
                        aRow["英文姓名"] = Row["name_e"].ToString();
                        aRow["日期"] = DateTime.Parse(Row["bdate"].ToString());
                        //string _Wk = DateTime.Parse(Row["bdate"].ToString()).DayOfWeek.ToString();
                        //if (DateTime.Parse(Row["bdate"].ToString()).DayOfWeek == DayOfWeek.Sunday)
                        //    _Wk = "日";
                        //else if (DateTime.Parse(Row["bdate"].ToString()).DayOfWeek == DayOfWeek.Monday)
                        //    _Wk = "一";
                        //else if (DateTime.Parse(Row["bdate"].ToString()).DayOfWeek == DayOfWeek.Tuesday)
                        //    _Wk = "二";
                        //else if (DateTime.Parse(Row["bdate"].ToString()).DayOfWeek == DayOfWeek.Wednesday)
                        //    _Wk = "三";
                        //else if (DateTime.Parse(Row["bdate"].ToString()).DayOfWeek == DayOfWeek.Thursday)
                        //    _Wk = "四";
                        //else if (DateTime.Parse(Row["bdate"].ToString()).DayOfWeek == DayOfWeek.Friday)
                        //    _Wk = "五";
                        //else if (DateTime.Parse(Row["bdate"].ToString()).DayOfWeek == DayOfWeek.Saturday)
                        //    _Wk = "六";
                        aRow["星期"] = Row["dw"].ToString();
                        aRow["起時間"] = Row["btime"].ToString();
                        aRow["迄時間"] = Row["etime"].ToString();
                        aRow["加班時數"] = decimal.Parse(Row["ot_hrs"].ToString());
                        aRow["補休時數"] = decimal.Parse(Row["rest_hrs"].ToString());
                        aRow["誤餐費"] = int.Parse(Row["ot_car"].ToString());
                        aRow["年月"] = Row["yymm"].ToString();
                        ExporDt.Rows.Add(aRow);
                    }
                    break;
                case "1":
                    DTrow = DT.Select("", "dept,nobr asc");
                    ExporDt.Columns.Add("部門代碼", typeof(string));
                    ExporDt.Columns.Add("部門名稱", typeof(string));
                    ExporDt.Columns.Add("部門英文名稱", typeof(string));
                    ExporDt.Columns.Add("員工編號", typeof(string));
                    ExporDt.Columns.Add("員工姓名", typeof(string));
                    ExporDt.Columns.Add("英文姓名", typeof(string));
                    ExporDt.Columns.Add("加班時數", typeof(decimal));
                    ExporDt.Columns.Add("補休時數", typeof(decimal));
                    ExporDt.Columns.Add("誤餐費", typeof(int));
                    ExporDt.Columns.Add("年月", typeof(string));
                    DataColumn[] _key = new DataColumn[3];
                    _key[0] = ExporDt.Columns["部門代碼"];
                    _key[1] = ExporDt.Columns["員工編號"];
                    _key[2] = ExporDt.Columns["年月"];
                    ExporDt.PrimaryKey = _key;
                    foreach (DataRow Row1 in DTrow)
                    {
                        object[] _value = new object[3];
                        _value[0] = Row1["dept"].ToString();
                        _value[1] = Row1["nobr"].ToString();
                        _value[2] = Row1["yymm"].ToString();
                        DataRow row = ExporDt.Rows.Find(_value);
                        if (row != null)
                        {
                            row["加班時數"] = decimal.Parse(row["加班時數"].ToString()) + decimal.Parse(Row1["ot_hrs"].ToString());
                            row["補休時數"] = decimal.Parse(row["補休時數"].ToString()) + decimal.Parse(Row1["rest_hrs"].ToString());
                            row["誤餐費"] = int.Parse(row["誤餐費"].ToString()) + int.Parse(Row1["ot_car"].ToString());
                        }
                        else
                        {
                            DataRow aRow = ExporDt.NewRow();
                            aRow["部門代碼"] = Row1["dept"].ToString();
                            aRow["部門名稱"] = Row1["d_name"].ToString();
                            aRow["部門英文名稱"] = Row1["d_ename"].ToString();
                            aRow["員工編號"] = Row1["nobr"].ToString();
                            aRow["員工姓名"] = Row1["name_c"].ToString();
                            aRow["英文姓名"] = Row1["name_e"].ToString();
                            aRow["加班時數"] = decimal.Parse(Row1["ot_hrs"].ToString());
                            aRow["補休時數"] = decimal.Parse(Row1["rest_hrs"].ToString());
                            aRow["誤餐費"] = int.Parse(Row1["ot_car"].ToString());
                            aRow["年月"] = Row1["yymm"].ToString();
                            ExporDt.Rows.Add(aRow);
                        }
                    }
                    break;
                case "2":
                    DTrow = DT.Select("", "dept,nobr asc");
                    ExporDt.Columns.Add("員工編號", typeof(string));
                    ExporDt.Columns.Add("員工姓名", typeof(string));
                    ExporDt.Columns.Add("英文姓名", typeof(string));
                    ExporDt.Columns.Add("出勤日期", typeof(DateTime));
                    ExporDt.Columns.Add("星期", typeof(string));
                    ExporDt.Columns.Add("加起時間", typeof(string));
                    ExporDt.Columns.Add("加迄時間", typeof(string));
                    ExporDt.Columns.Add("加班班別", typeof(string));
                    ExporDt.Columns.Add("期初時數", typeof(decimal));
                    ExporDt.Columns.Add("加班時數", typeof(decimal));
                    ExporDt.Columns.Add("免稅一段", typeof(decimal));
                    ExporDt.Columns.Add("免稅二段", typeof(decimal));
                    ExporDt.Columns.Add("免稅三段", typeof(decimal));
                    ExporDt.Columns.Add("免稅假一", typeof(decimal));
                    ExporDt.Columns.Add("免稅假二", typeof(decimal));
                    ExporDt.Columns.Add("免稅假三", typeof(decimal));
                    ExporDt.Columns.Add("應稅一段", typeof(decimal));
                    ExporDt.Columns.Add("應稅二段", typeof(decimal));
                    ExporDt.Columns.Add("應稅三段", typeof(decimal));
                    ExporDt.Columns.Add("補休時數", typeof(decimal));
                    foreach (DataRow Row1 in DTrow)
                    {
                        DataRow aRow = ExporDt.NewRow();
                        aRow["員工編號"] = Row1["nobr"].ToString();
                        aRow["員工姓名"] = Row1["name_c"].ToString();
                        aRow["英文姓名"] = Row1["name_e"].ToString();
                        aRow["出勤日期"] = DateTime.Parse(Row1["bdate"].ToString());
                        aRow["星期"] = Row1["dw"].ToString();
                        aRow["加起時間"] = Row1["btime"].ToString();
                        aRow["加迄時間"] = Row1["etime"].ToString();
                        aRow["加班班別"] = Row1["ot_rote"].ToString();
                        aRow["期初時數"] = decimal.Parse(Row1["fst_hours"].ToString());
                        aRow["加班時數"] = decimal.Parse(Row1["ot_hrs"].ToString());
                        aRow["免稅一段"] = decimal.Parse(Row1["not_w_133"].ToString());
                        aRow["免稅二段"] = decimal.Parse(Row1["not_w_167"].ToString());
                        aRow["免稅三段"] = decimal.Parse(Row1["not_w_200"].ToString());
                        aRow["免稅假一"] = decimal.Parse(Row1["not_h_133"].ToString());
                        aRow["免稅假二"] = decimal.Parse(Row1["not_h_167"].ToString());
                        aRow["免稅假三"] = decimal.Parse(Row1["not_h_200"].ToString());
                        aRow["應稅一段"] = decimal.Parse(Row1["tot_w_133"].ToString());
                        aRow["應稅二段"] = decimal.Parse(Row1["tot_w_167"].ToString());
                        aRow["應稅三段"] = decimal.Parse(Row1["tot_w_200"].ToString());
                        aRow["補休時數"] = decimal.Parse(Row1["rest_hrs"].ToString());
                        ExporDt.Rows.Add(aRow);
                    }
                    break;
                case "3":
                    DTrow = DT.Select("", "dept,nobr asc");
                    ExporDt.Columns.Add("部門代碼", typeof(string));
                    ExporDt.Columns.Add("部門名稱", typeof(string));
                    ExporDt.Columns.Add("部門英文名稱", typeof(string));
                    ExporDt.Columns.Add("員工編號", typeof(string));
                    ExporDt.Columns.Add("員工姓名", typeof(string));
                    ExporDt.Columns.Add("英文姓名", typeof(string));
                    ExporDt.Columns.Add("加班時數", typeof(decimal));
                    ExporDt.Columns.Add("免稅一段", typeof(decimal));
                    ExporDt.Columns.Add("免稅二段", typeof(decimal));
                    ExporDt.Columns.Add("免稅三段", typeof(decimal));
                    ExporDt.Columns.Add("免稅假一", typeof(decimal));
                    ExporDt.Columns.Add("免稅假二", typeof(decimal));
                    ExporDt.Columns.Add("免稅假三", typeof(decimal));
                    ExporDt.Columns.Add("應稅一段", typeof(decimal));
                    ExporDt.Columns.Add("應稅二段", typeof(decimal));
                    ExporDt.Columns.Add("應稅三段", typeof(decimal));
                    ExporDt.Columns.Add("補休時數", typeof(decimal));
                    DataColumn[] _key1 = new DataColumn[2];
                    _key1[0] = ExporDt.Columns["部門代碼"];
                    _key1[1] = ExporDt.Columns["員工編號"];
                    ExporDt.PrimaryKey = _key1;
                    foreach (DataRow Row1 in DTrow)
                    {
                        object[] _value1 = new object[2];
                        _value1[0] = Row1["dept"].ToString();
                        _value1[1] = Row1["nobr"].ToString();
                        DataRow row = ExporDt.Rows.Find(_value1);
                        if (row != null)
                        {
                            row["加班時數"] = decimal.Parse(row["加班時數"].ToString()) + decimal.Parse(Row1["ot_hrs"].ToString());
                            row["免稅一段"] = decimal.Parse(row["免稅一段"].ToString()) + decimal.Parse(Row1["not_w_133"].ToString());
                            row["免稅二段"] = decimal.Parse(row["免稅二段"].ToString()) + decimal.Parse(Row1["not_w_167"].ToString());
                            row["免稅三段"] = decimal.Parse(row["免稅三段"].ToString()) + decimal.Parse(Row1["not_w_200"].ToString());
                            row["免稅假一"] = decimal.Parse(row["免稅假一"].ToString()) + decimal.Parse(Row1["not_h_133"].ToString());
                            row["免稅假二"] = decimal.Parse(row["免稅假二"].ToString()) + decimal.Parse(Row1["not_h_167"].ToString());
                            row["免稅假三"] = decimal.Parse(row["免稅假三"].ToString()) + decimal.Parse(Row1["not_h_200"].ToString());
                            row["應稅一段"] = decimal.Parse(row["應稅一段"].ToString()) + decimal.Parse(Row1["tot_w_133"].ToString());
                            row["應稅二段"] = decimal.Parse(row["應稅二段"].ToString()) + decimal.Parse(Row1["tot_w_167"].ToString());
                            row["應稅三段"] = decimal.Parse(row["應稅三段"].ToString()) + decimal.Parse(Row1["tot_w_200"].ToString());
                            row["補休時數"] = decimal.Parse(row["補休時數"].ToString()) + decimal.Parse(Row1["rest_hrs"].ToString());
                        }
                        else
                        {
                            DataRow aRow = ExporDt.NewRow();
                            aRow["部門代碼"] = Row1["dept"].ToString();
                            aRow["部門名稱"] = Row1["d_name"].ToString();
                            aRow["部門英文名稱"] = Row1["d_ename"].ToString();
                            aRow["員工編號"] = Row1["nobr"].ToString();
                            aRow["員工姓名"] = Row1["name_c"].ToString();
                            aRow["英文姓名"] = Row1["name_e"].ToString();
                            aRow["加班時數"] = decimal.Parse(Row1["ot_hrs"].ToString());
                            aRow["免稅一段"] = decimal.Parse(Row1["not_w_133"].ToString());
                            aRow["免稅二段"] = decimal.Parse(Row1["not_w_167"].ToString());
                            aRow["免稅三段"] = decimal.Parse(Row1["not_w_200"].ToString());
                            aRow["免稅假一"] = decimal.Parse(Row1["not_h_133"].ToString());
                            aRow["免稅假二"] = decimal.Parse(Row1["not_h_167"].ToString());
                            aRow["免稅假三"] = decimal.Parse(Row1["not_h_200"].ToString());
                            aRow["應稅一段"] = decimal.Parse(Row1["tot_w_133"].ToString());
                            aRow["應稅二段"] = decimal.Parse(Row1["tot_w_167"].ToString());
                            aRow["應稅三段"] = decimal.Parse(Row1["tot_w_200"].ToString());
                            aRow["補休時數"] = decimal.Parse(Row1["rest_hrs"].ToString());
                            ExporDt.Rows.Add(aRow);
                        }
                    }
                    break;
                case "4":
                    ExporDt.Columns.Add("部門代碼", typeof(string));
                    ExporDt.Columns.Add("部門名稱", typeof(string));
                    ExporDt.Columns.Add("部門英文名稱", typeof(string));
                    ExporDt.Columns.Add("員工編號", typeof(string));
                    ExporDt.Columns.Add("員工姓名", typeof(string));
                    ExporDt.Columns.Add("英文姓名", typeof(string));
                    ExporDt.Columns.Add("日期", typeof(DateTime));
                    ExporDt.Columns.Add("星期", typeof(string));
                    ExporDt.Columns.Add("起時間", typeof(string));
                    ExporDt.Columns.Add("迄時間", typeof(string));
                    ExporDt.Columns.Add("加班時數", typeof(decimal));
                    ExporDt.Columns.Add("補休時數", typeof(decimal));
                    ExporDt.Columns.Add("刷卡時間", typeof(string));
                    ExporDt.Columns.Add("CallIn津貼", typeof(int));
                    ExporDt.Columns.Add("年月", typeof(string));
                    DTrow = DT.Select("", "nobr asc");
                    foreach (DataRow Row in DTrow)
                    {
                        DataRow aRow = ExporDt.NewRow();
                        aRow["部門代碼"] = Row["ot_dept"].ToString();
                        aRow["部門名稱"] = Row["d_name"].ToString();
                        aRow["部門英文名稱"] = Row["d_ename"].ToString();
                        aRow["員工編號"] = Row["nobr"].ToString();
                        aRow["員工姓名"] = Row["name_c"].ToString();
                        aRow["英文姓名"] = Row["name_e"].ToString();
                        aRow["日期"] = DateTime.Parse(Row["bdate"].ToString());
                        //string _Wk = DateTime.Parse(Row["bdate"].ToString()).DayOfWeek.ToString();
                        //if (DateTime.Parse(Row["bdate"].ToString()).DayOfWeek == DayOfWeek.Sunday)
                        //    _Wk = "日";
                        //else if (DateTime.Parse(Row["bdate"].ToString()).DayOfWeek == DayOfWeek.Monday)
                        //    _Wk = "一";
                        //else if (DateTime.Parse(Row["bdate"].ToString()).DayOfWeek == DayOfWeek.Tuesday)
                        //    _Wk = "二";
                        //else if (DateTime.Parse(Row["bdate"].ToString()).DayOfWeek == DayOfWeek.Wednesday)
                        //    _Wk = "三";
                        //else if (DateTime.Parse(Row["bdate"].ToString()).DayOfWeek == DayOfWeek.Thursday)
                        //    _Wk = "四";
                        //else if (DateTime.Parse(Row["bdate"].ToString()).DayOfWeek == DayOfWeek.Friday)
                        //    _Wk = "五";
                        //else if (DateTime.Parse(Row["bdate"].ToString()).DayOfWeek == DayOfWeek.Saturday)
                        //    _Wk = "六";
                        aRow["星期"] = Row["dw"].ToString();
                        aRow["起時間"] = Row["btime"].ToString();
                        aRow["迄時間"] = Row["etime"].ToString();
                        aRow["加班時數"] = decimal.Parse(Row["ot_hrs"].ToString());
                        aRow["補休時數"] = decimal.Parse(Row["rest_hrs"].ToString());
                        aRow["刷卡時間"] = Row["ttime"].ToString();
                        aRow["CallIn津貼"] = int.Parse(Row["ot_car"].ToString());
                        aRow["年月"] = Row["yymm"].ToString();
                        ExporDt.Rows.Add(aRow);
                    }
                    break;
                default:
                    break;
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }

        
    }
}


