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
    public partial class ZZ45_Report : JBControls.JBForm
    {
        SalDataSet ds = new SalDataSet();
        string type_data, nobr_b, nobr_e, dept_b, dept_e, yymm_b, yymm_e, date_b, date_e, comp_b, comp_e, emp_b, emp_e, date_t, comp_name, userid, CompId;
        string da_op, workadr, reporttype;
        bool exportexcel;
        public ZZ45_Report(string typedata, string nobrb, string nobre, string deptb, string depte, string yymmb, string yymme, string dateb, string datee, string compb, string compe, string empb, string empe, string datet, string daop, string _workadr, string _reporttype, bool _exportexcel,string _userid,string _compid, string compname)
        {
            InitializeComponent();
            type_data = typedata; nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte;
            comp_b = compb; comp_e = compe; date_b = dateb; date_e = datee; da_op = daop;
            exportexcel = _exportexcel; date_t = datet; workadr = _workadr; emp_b = empb; emp_e = empe;
            yymm_b = yymmb; yymm_e = yymme; reporttype = _reporttype; comp_name = compname;
            userid = _userid; CompId = _compid;
        }

        private void ZZ45_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL Sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlUsys3 = "select otfoodsalcode from u_sys3 where comp='" + CompId + "'";
                DataTable rq_usys3 = Sql.GetDataTable(sqlUsys3);
                string otfoodsalcode = (rq_usys3.Rows.Count > 0) ? rq_usys3.Rows[0]["otfoodsalcode"].ToString().Trim() : "";
                SalClassesDataContext SCD = new SalClassesDataContext();
                //var u_datagroup = from a in SCD.U_DATAGROUP
                //                  where a.USER_ID.CompareTo(userid) == 0
                //                  && a.READRULE && a.COMPANY.CompareTo(CompId) == 0
                //                  select a.DATAGROUP;

                var basetts = from a in SCD.BASE
                              join b in SCD.BASETTS on a.NOBR equals b.NOBR
                              join c in SCD.DEPT on b.DEPT equals c.D_NO
                              where DateTime.Parse(date_t) >= b.ADATE && DateTime.Parse(date_t) <= b.DDATE && b.NOBR.CompareTo(nobr_b) >= 0
                          && b.NOBR.CompareTo(nobr_e) <= 0 
                          && b.EMPCD.CompareTo(emp_b) >= 0 && b.EMPCD.CompareTo(emp_e) <= 0 
                          && c.D_NO_DISP.CompareTo(dept_b)>=0 && c.D_NO_DISP.CompareTo(dept_e)<=0
                           //&& SCD.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                           && SCD.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                              //&& u_datagroup.Contains(b.SALADR)
                              select new { b.NOBR, a.NAME_C,a.NAME_E,c.D_NO_DISP,DEPT=c.D_NO_DISP, c.D_NAME,c.D_ENAME, b.DI, a.COUNT_MA, b.SALADR };
                if (type_data == "2")
                    basetts = from e1 in basetts where e1.DI == "I" && e1.COUNT_MA == false select e1;
                else if (type_data == "3")
                    basetts = from e2 in basetts where e2.DI == "D" && e2.COUNT_MA == false select e2;
                else if (type_data == "4")
                    basetts = from e3 in basetts where e3.COUNT_MA == true select e3;

                var salabs = from a in SCD.SALABS
                             join b in SCD.ABS on a.NOBR equals b.NOBR
                             join c in SCD.SALCODE on a.SAL_CODE equals c.SAL_CODE
                             join d in SCD.HCODE on a.H_CODE equals d.H_CODE
                             join c1 in SCD.SALCODE on a.MLSSALCODE equals c1.SAL_CODE                           
                             where a.NOBR.CompareTo(nobr_b) >= 0 && a.NOBR.CompareTo(nobr_e) <= 0
                             && a.ADATE == b.BDATE && a.BTIME == b.BTIME
                             //&& a.ADATE >= f.ADATE && a.ADATE <= f.DDATE
                             //&& a.SAL_CODE == f.SAL_CODE
                              //&& a.MLSSALCODE != otfoodsalcode
                             && a.H_CODE == b.H_CODE
                             //&& a.MLSSALCODE == c.SAL_CODE
                             select new { a.NOBR, a.SALSEQ, a.SAL_CODE, c.SAL_NAME, b.BDATE, b.BTIME, b.ETIME, a.AMT, a.YYMM, a.ADATE, a.H_CODE, d.H_NAME, a.MLSSALCODE, mlssname = c1.SAL_NAME, b.TOL_HOURS };
                if (da_op == "1")
                {
                    salabs = from f1 in salabs where f1.YYMM.CompareTo(yymm_b) >= 0 && f1.YYMM.CompareTo(yymm_e) <= 0 select f1;
                    date_b = JBHR.Reports.ReportClass.GetSalBDate(yymm_b.Substring(0, 4), yymm_b.Substring(4, 2));
                    date_e = JBHR.Reports.ReportClass.GetSalEDate(yymm_e.Substring(0, 4), yymm_e.Substring(4, 2));
                }
                else
                {
                    salabs = from f2 in salabs where f2.ADATE >= DateTime.Parse(date_b) && f2.ADATE <= DateTime.Parse(date_e) select f2;
                    yymm_b = Convert.ToString(DateTime.Parse(date_b).Year) + Convert.ToString(DateTime.Parse(date_b).Month);
                    yymm_e = Convert.ToString(DateTime.Parse(date_e).Year) + Convert.ToString(DateTime.Parse(date_e).Month);
                }

                var salbasd = from t1 in SCD.SALBASD
                              where t1.NOBR.CompareTo(nobr_b) >= 0 && t1.NOBR.CompareTo(nobr_e) <= 0
                              && DateTime.Parse(date_e)>= t1.ADATE && DateTime.Parse(date_e) <=t1.DDATE
                              select new { t1.NOBR, t1.ADATE, t1.DDATE, t1.SAL_CODE, t1.AMT };
                DataTable rq_salbasd = salbasd.CopyToDataTable();               
                             

                var salbasd1 = from t1 in SCD.SALBASD1
                              where t1.NOBR.CompareTo(nobr_b) >= 0 && t1.NOBR.CompareTo(nobr_e) <= 0
                              && t1.YYMM.CompareTo(yymm_b) >= 0 && t1.YYMM.CompareTo(yymm_e)<=0
                              orderby t1.YYMM ascending,t1.SEQ ascending
                              select new {t1.YYMM, t1.NOBR, t1.SAL_CODE, t1.AMT};
                DataTable rq_salbasd1 = salbasd1.CopyToDataTable();               


                var rq_salabs = from a in salabs.ToList()
                                select new
                                {
                                    a.NOBR,
                                    a.BDATE,
                                    a.BTIME,
                                    a.ETIME,
                                    a.ADATE,
                                    a.SALSEQ,
                                    a.SAL_CODE,
                                    a.SAL_NAME,
                                    a.YYMM,
                                    a.H_CODE,
                                    a.H_NAME,
                                    a.MLSSALCODE,
                                    a.mlssname,
                                    a.TOL_HOURS,
                                    amt = JBModule.Data.CDecryp.Number(Convert.ToDecimal(a.AMT)),
                                    //amta = JBModule.Data.CDecryp.Number(Convert.ToDecimal(a.amta))
                                };

                var rq_zz45 = from a in rq_salabs
                              join b in basetts on a.NOBR.Trim() equals b.NOBR.Trim() 
                              orderby b.D_NO_DISP ascending,a.NOBR ascending,a.SALSEQ ascending
                              select new { a.NOBR, a.SALSEQ, b.NAME_C,b.NAME_E, a.BDATE,dept=b.D_NO_DISP, b.D_NAME,b.D_ENAME, a.BTIME, a.ETIME, a.H_CODE, a.H_NAME, a.SAL_CODE, a.SAL_NAME, a.amt, a.MLSSALCODE,amta=0, a.mlssname, a.TOL_HOURS,a.YYMM };
                var dt1 = rq_zz45.CopyToDataTable();
                foreach (DataRow Row in dt1.Rows)
                {
                    string bdate=DateTime.Parse(Row["bdate"].ToString()).ToString("yyyy/MM/dd");
                    if (decimal.Parse(Row["amta"].ToString()) == 0)
                    {
                        DataRow[] row = rq_salbasd.Select("nobr='" + Row["nobr"].ToString() + "' and sal_code='" + Row["SAL_CODE"].ToString() + "' and  adate<= '" + bdate + "' and ddate >='" + bdate + "' ");
                        if (row.Length > 0)
                            Row["amta"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(row[0]["amt"].ToString()));
                    }
                    if (decimal.Parse(Row["amta"].ToString()) == 0)
                    {
                        DataRow[] row1 = rq_salbasd1.Select("nobr='" + Row["nobr"].ToString() + "' and sal_code='" + Row["SAL_CODE"].ToString() + "' and yymm='" + Row["yymm"].ToString() + "'");
                        if (row1.Length > 0)
                            Row["amta"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(row1[0]["amt"].ToString()));
                    }
                   
                    ds.Tables["zz45"].ImportRow(Row);
                }

                rq_salabs = null; rq_salbasd = null; rq_salbasd1 = null; rq_usys3 = null; rq_zz45 = null;
                if (ds.Tables["zz45"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }

                if (reporttype == "1")
                {
                    //var gp = from itm in rq_zz45  group itm by new { itm.DEPT,itm.D_NAME } into gp1 orderby gp1.Key.DEPT ascending select new { gp1.Key.DEPT,gp1.Key.D_NAME, amt = gp1.Sum(p => p.amt) };
                    //var dt2 = gp.CopyToDataTable();
                    ds.Tables["zz451"].PrimaryKey = new DataColumn[] { ds.Tables["zz451"].Columns["dept"] };
                    foreach (DataRow Row in ds.Tables["zz45"].Rows)
                    {
                        DataRow row = ds.Tables["zz451"].Rows.Find(Row["dept"].ToString());
                        if (row != null)
                            row["amt"] = int.Parse(row["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                        else
                        {
                            DataRow aRow = ds.Tables["zz451"].NewRow();
                            aRow["dept"] = Row["dept"].ToString();
                            aRow["d_name"] = Row["d_name"].ToString();
                            aRow["d_ename"] = Row["d_ename"].ToString();
                            aRow["amt"] = int.Parse(Row["amt"].ToString());
                            ds.Tables["zz451"].Rows.Add(aRow);
                        }
                        
                    }
                    if (ds.Tables["zz451"].Rows.Count < 1)
                    {
                        MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                        this.Close();
                        return;
                    }                   
                }
                if (exportexcel)
                {
                    if (reporttype=="0")
                        Export(ds.Tables["zz45"]);
                    else
                        Export1(ds.Tables["zz451"]);
                    this.Close();
                }
                else
                {
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "SalReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "SalReport", "*.rdlc");
                    if (reporttype == "0")
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz45.rdlc";
                    else
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz451.rdlc";
                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    if (reporttype=="0")
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz45", ds.Tables["zz45"]));
                    else
                        RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz451", ds.Tables["zz451"]));
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
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            ExporDt.Columns.Add("請假日期", typeof(DateTime));
            ExporDt.Columns.Add("假別", typeof(string));
            ExporDt.Columns.Add("請起", typeof(string));
            ExporDt.Columns.Add("請迄", typeof(string));
            ExporDt.Columns.Add("請假時數", typeof(decimal));
            ExporDt.Columns.Add("薪資名稱", typeof(string));
            ExporDt.Columns.Add("扣款金額", typeof(int));
            ExporDt.Columns.Add("扣款薪資名稱", typeof(string));
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["員工編號"] = Row01["nobr"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();
                aRow["英文姓名"] = Row01["name_e"].ToString();
                aRow["請假日期"] = DateTime.Parse(Row01["bdate"].ToString());
                aRow["假別"] = Row01["h_name"].ToString();
                aRow["請起"] = Row01["btime"].ToString();
                aRow["請迄"] = Row01["etime"].ToString();
                aRow["請假時數"] = decimal.Parse(Row01["tol_hours"].ToString());
                aRow["薪資名稱"] = Row01["sal_name"].ToString();
                aRow["扣款金額"] = int.Parse(Row01["amt"].ToString());
                aRow["扣款薪資名稱"] = Row01["mlssname"].ToString();
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }

        void Export1(DataTable DT)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("英文部門名稱", typeof(string));
            ExporDt.Columns.Add("扣款金額", typeof(int));            
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row01["dept"].ToString();
                aRow["部門名稱"] = Row01["d_name"].ToString();
                aRow["英文部門名稱"] = Row01["d_ename"].ToString();
                aRow["扣款金額"] = int.Parse(Row01["amt"].ToString());               
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
