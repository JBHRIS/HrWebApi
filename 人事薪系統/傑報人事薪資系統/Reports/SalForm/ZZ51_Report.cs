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
    public partial class ZZ51_Report : JBControls.JBForm
    {
        SalDataSet ds = new SalDataSet();
        string nobr_b, nobr_e, dept_b, dept_e, year, ser_nob, ser_noe, type_data, ordertype, reporttype, username, comp_name, CompId;
        bool exportexcel;
        List<JBModule.Data.Linq.YRTAX> yrtaxlist;
        Dictionary<string, object> yrparameters;
        public ZZ51_Report(string nobrb, string nobre, string deptb, string depte, string _year, string sernob, string sernoe, string typedata, string _ordertype, string _reporttype, bool _exportexcel, string _username, string compname, string _CompId, List<JBModule.Data.Linq.YRTAX> YrtaxList, Dictionary<string, object> YrParameters)
        {
            InitializeComponent();
            nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; year = _year; ser_nob = sernob;
            ser_noe = sernoe; type_data = typedata; ordertype = _ordertype; reporttype = _reporttype;
            exportexcel = _exportexcel; username = _username; comp_name = compname; CompId = _CompId;
            yrtaxlist = YrtaxList; yrparameters = YrParameters;
        }

        private void ZZ51_Report_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable rq_yrtax = new DataTable();
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string date_b =year+ "/12/31";
                if (yrparameters == null)
                {
                    string sqlCmd = "select e.d_no_disp as dept,e.d_name,e.d_ename,c.*";
                    sqlCmd += "  from yrtax c,base a,basetts b";
                    sqlCmd += " left outer join dept e on b.dept=e.d_no";
                    sqlCmd += " where c.nobr=b.nobr and a.nobr=b.nobr ";
                    sqlCmd += string.Format(@" and c.year='{0}'", year);
                    sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_b);
                    sqlCmd += string.Format(@" and c.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                    sqlCmd += string.Format(@" and c.series between '{0}' and '{1}'", ser_nob, ser_noe);
                    sqlCmd += string.Format(@" and e.d_no_disp between '{0}' and '{1}'", dept_b, dept_e);
                    sqlCmd += type_data;
                    sqlCmd += ordertype;
                    rq_yrtax = SqlConn.GetDataTable(sqlCmd); 
                }
                else
                {
                    JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

                    var type_data2 = Convert.ToBoolean(yrparameters["type_data2"].ToString());
                    var type_data3 = Convert.ToBoolean(yrparameters["type_data3"].ToString());
                    var type_data4 = Convert.ToBoolean(yrparameters["type_data4"].ToString());

                    var type_tr2 = Convert.ToBoolean(yrparameters["type_tr2"].ToString());
                    var type_tr3 = Convert.ToBoolean(yrparameters["type_tr3"].ToString());

                    var order_type = Convert.ToInt32(yrparameters["order_type"].ToString());

                    var filterSQL = from b in db.BASE
                                    join bts in db.BASETTS on b.NOBR equals bts.NOBR
                                    join d in db.DEPT on bts.DEPT equals d.D_NO
                                    where bts.ADATE <= Convert.ToDateTime(date_b) && bts.DDATE >= Convert.ToDateTime(date_b)
                                    && b.NOBR.CompareTo(nobr_b) >= 0 && b.NOBR.CompareTo(nobr_e) <= 0
                                    && d.D_NO_DISP.CompareTo(dept_b) >= 0 && d.D_NO_DISP.CompareTo(dept_e) <= 0
                                    //&& db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(bts.SALADR)
                                    select new
                                    {
                                        Dept = d.D_NO_DISP,
                                        DeptName = d.D_NAME,
                                        DeptEName = d.D_ENAME,
                                        BASE = b,
                                        BASETTS = bts,
                                    };
                    var filterList = filterSQL.ToList();
                    var ResultList = (from y in yrtaxlist
                                      join f in filterList on y.NOBR equals f.BASE.NOBR
                                      where 1 == 1
                                      && (!type_data2 || f.BASETTS.DI == "I" && f.BASE.ACCOUNT_MA == "0")
                                      && (!type_data3 || f.BASETTS.DI == "D" && f.BASE.ACCOUNT_MA == "0")
                                      && (!type_data4 || f.BASE.COUNT_MA)
                                      && (!type_tr2 || !y.T_OK)
                                      && (!type_tr3 || y.T_OK)
                                      select new
                                      {
                                          f.Dept,
                                          f.DeptName,
                                          f.DeptEName,
                                          //Yrtax =  y,
                                          y.NOBR,
                                          y.ACC_NO,
                                          y.ADDR_2,
                                          y.BLANK_1,
                                          y.COMP,
                                          y.DATE,
                                          y.ERR_MARK,
                                          y.F0103,
                                          y.F0407,
                                          y.FORMAT,
                                          y.ID,
                                          y.ID1,
                                          y.IDCODE,
                                          y.KEY_DATE,
                                          y.KEY_MAN,
                                          y.MARK,
                                          y.NAME_C,
                                          y.POSTCODE2,
                                          y.REL_AMT,
                                          y.RET_AMT,
                                          y.SALADR,
                                          y.SERIES,
                                          y.TAX_AMT,
                                          y.TOT_AMT,
                                          y.T_OK,
                                          y.YEAR,
                                          y.YEAR_B,
                                          y.YEAR_E,
                                      }).ToList();

                    if (order_type == 0)
                        ResultList = ResultList.OrderBy(p => p.Dept).ThenBy(p => p.NOBR).ToList();// " ORDER BY E.D_NO_DISP,C.NOBR";
                    else if (order_type == 1)
                        ResultList = ResultList.OrderByDescending(p => p.ID).ToList();//" ORDER BY C.ID DESC";
                    else if (order_type == 2)
                        ResultList = ResultList.OrderBy(p => p.NOBR).ToList();//" ORDER BY C.NOBR";
                    else if (order_type == 3)
                        ResultList = ResultList.OrderBy(p => p.COMP).ThenBy(p => p.SERIES).ToList();//" ORDER BY C.COMP,C.SERIES";

                    rq_yrtax = ResultList.CopyToDataTable();
                }
                if (rq_yrtax.Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                foreach (DataRow Row in rq_yrtax.Rows)
                {
                    Row["nobr"] = Row["nobr"].ToString().Trim();
                    //decimal tot_amt = Math.Round(JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["tot_amt"].ToString())), MidpointRounding.AwayFromZero);
                    //decimal rel_amt = Math.Round(JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["rel_amt"].ToString())), MidpointRounding.AwayFromZero);
                    //decimal tax_amt = Math.Round(JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["tax_amt"].ToString())), MidpointRounding.AwayFromZero);
                    //decimal ret_amt = Math.Round(JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["ret_amt"].ToString())), MidpointRounding.AwayFromZero);

                    Row["tot_amt"] = Math.Round(JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["tot_amt"].ToString())), MidpointRounding.AwayFromZero);
                    Row["rel_amt"] = Math.Round(JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["rel_amt"].ToString())), MidpointRounding.AwayFromZero);
                    Row["tax_amt"] = Math.Round(JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["tax_amt"].ToString())), MidpointRounding.AwayFromZero);
                    Row["ret_amt"] = Math.Round(JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["ret_amt"].ToString())), MidpointRounding.AwayFromZero);
                    
                    //DataRow aRow = ds.Tables["zz51"].NewRow();
                    //aRow["nobr"] = Row["nobr"].ToString();
                    //aRow["id"] = Row["id"].ToString();
                    //aRow["id1"] = Row["id1"].ToString();
                    //ds.Tables["zz51"].Rows.Add(aRow);
                    ds.Tables["zz51"].ImportRow(Row);
                }
                rq_yrtax = null;
                if (exportexcel)
                {
                    Export(ds.Tables["zz51"]);
                    this.Close();
                }
                else
                {                   
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "InsReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "SalReport", "*.rdlc");                    
                    if (reporttype == "0")
                    {
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz51.rdlc";
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Year", year) });
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("UserName", username) });
                    }
                    else
                    {
                        RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz511.rdlc";
                        DataTable rq_sys1 = SqlConn.GetDataTable("select company,compaddr,compman from u_sys1 where comp='" + CompId + "'");
                        string companya = ""; string compaddr = ""; string compman = "";
                        if (rq_sys1.Rows.Count > 0)
                        {
                            companya = rq_sys1.Rows[0]["company"].ToString();
                            compaddr = rq_sys1.Rows[0]["compaddr"].ToString();
                            compman = rq_sys1.Rows[0]["compman"].ToString();
                        }
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Year", year) });
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", companya) });
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Compaddr", compaddr) });
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Compman", compman) });
                    }
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz51", ds.Tables["zz51"]));
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
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("英文部門名稱", typeof(string));
            ExporDt.Columns.Add("流水編號", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("身分證號", typeof(string));
            ExporDt.Columns.Add("格式", typeof(string));
            ExporDt.Columns.Add("給付總額", typeof(int));
            ExporDt.Columns.Add("扣繳稅額", typeof(int));
            ExporDt.Columns.Add("實付總額", typeof(int));
            ExporDt.Columns.Add("退休金", typeof(int));
            ExporDt.Columns.Add("戶籍地址", typeof(string));
            ExporDt.Columns.Add("所得代號", typeof(string));
            ExporDt.Columns.Add("機關", typeof(string));
            ExporDt.Columns.Add("媒體", typeof(string));
            ExporDt.Columns.Add("統編", typeof(string));
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row01["dept"].ToString();
                aRow["部門名稱"] = Row01["d_name"].ToString();
                aRow["英文部門名稱"] = Row01["d_ename"].ToString();
                aRow["流水編號"] = Row01["series"].ToString();
                aRow["員工編號"] = Row01["nobr"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();
                aRow["身分證號"] = Row01["id"].ToString();
                aRow["格式"] = Row01["format"].ToString();
                aRow["給付總額"] = int.Parse(Row01["tot_amt"].ToString());
                aRow["扣繳稅額"] = int.Parse(Row01["tax_amt"].ToString());
                aRow["實付總額"] = int.Parse(Row01["rel_amt"].ToString());
                aRow["退休金"] = int.Parse(Row01["ret_amt"].ToString());
                aRow["戶籍地址"] = Row01["addr_2"].ToString();
                aRow["所得代號"] = Row01["acc_no"].ToString();
                aRow["機關"] = Row01["f0103"].ToString();
                aRow["媒體"] = Row01["f0407"].ToString();
                aRow["統編"] = Row01["id1"].ToString() + " " + Row01["mark"].ToString() + " " + Row01["idcode"].ToString() + " " + Row01["err_mark"].ToString();
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
