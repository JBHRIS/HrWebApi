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
    public partial class ZZ28_Report : JBControls.JBForm
    {
        attenddata ds = new attenddata();
        string comp_b, comp_e, yymm_b, yymm_e, otyymm_b, otyymm_e, m_b1, date_b, m_e1, date_e, otm_b1, otdate_b, otm_e1, otdate_e, username, type_data, comp_name, compid,userid;
        decimal y_b1, y_e1, oty_b1, oty_e1;
        bool exportexcel;
        public ZZ28_Report(string compb, string compe, string yymmb, string yymme, string otyymmb, string otyymme, bool _exportexcel, string typedata, string _username, string _userid, string compname, string _compid)
        {
            InitializeComponent();
            yymm_b = yymmb; yymm_e = yymme; otyymm_b = otyymmb; otyymm_e = otyymme;
            comp_b = compb; comp_e = compe; compid = _compid;
            exportexcel = _exportexcel; comp_name = compname;
            username = _username; type_data = typedata; userid = _userid;
        }   

        private void ZZ28_Report_Load(object sender, EventArgs e)
        {
            try
            {
                y_b1 = decimal.Parse(yymm_b.Substring(0, 4));
                m_b1 = yymm_b.Substring(4, 2);
                date_b = JBHR.Reports.ReportClass.GetAttBDate(Convert.ToString(y_b1), m_b1);
                y_e1 = decimal.Parse(yymm_e.Substring(0, 4)) ;
                m_e1 = yymm_e.Substring(4, 2);
                date_e = JBHR.Reports.ReportClass.GetAttEDate(Convert.ToString(y_e1), m_e1);

                oty_b1 = decimal.Parse(otyymm_b.Substring(0, 4)) ;
                otm_b1 = otyymm_b.Substring(4, 2);
                otdate_b = JBHR.Reports.ReportClass.GetAttBDate(Convert.ToString(oty_b1), otm_b1);
                oty_e1 = decimal.Parse(otyymm_e.Substring(0, 4)) ;
                otm_e1 = otyymm_e.Substring(4, 2);
                otdate_e = JBHR.Reports.ReportClass.GetAttEDate(Convert.ToString(oty_e1), otm_e1);

                DataTable rq_zz28 = new DataTable();
                rq_zz28 = ds.Tables["zz28"].Clone();
                rq_zz28.TableName = "rq_zz28";
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string company = "";
                DataTable rq_sys = ReportClass.GetU_Sys();
                if (rq_sys.Rows.Count > 0)
                    company = rq_sys.Rows[0]["company"].ToString();
                //DataTable rq_rote = SqlConn.GetDataTable("select rote,rote_disp,wk_hrs from rote");
                //rq_rote.PrimaryKey = new DataColumn[] { rq_rote.Columns["rote"] };
                int _adm = (Convert.ToBoolean(MainForm.ADMIN)) ? 1 : 0;
                string sqlCmd0 = "select d_no as dept,d_no_disp,d_name,d_ename,00000.00 as wk_hrs,00000.00 as wk_hrs1,00000.00 as wk_pr,";
                sqlCmd0 += "00000.00 as tol_hours,00000.00 as tol_hours1,00000.00 as tol_pr,00000.00 as ot_hrs,00000.00 as ot_hrs1";
                sqlCmd0 += ",00000.00 as ot_pr,00000.00 as res_hrs,00000.00 as res_hrs1,00000.00 as res_pr,00000.00 as tot_pr";
                sqlCmd0 += " from dept ";
                //sqlCmd0 += "  where exists (select source from code_filter where source='dept' and code=dept.d_no";
                //sqlCmd0 += string.Format(@" and exists (select comp from comp_code_group where comp='{0}' ", compid);
                //sqlCmd0 += " and codegroup=code_filter.codegroup))";
                sqlCmd0 += string.Format(@" where dbo.GetCodeFilter('DEPT',D_NO,'{0}','{1}',{2})=1 ", userid, compid, _adm);
                sqlCmd0 += string.Format(@" and ddate > '{0}' ", otdate_b);
                sqlCmd0 += " order by d_no_disp";
                rq_zz28 = SqlConn.GetDataTable(sqlCmd0);
                foreach (DataRow Row in rq_zz28.Rows)
                {
                    ds.Tables["zz28"].ImportRow(Row);
                }                
                rq_zz28 = null;

                //每日出勤工時
                string CmdAttRote = "select a.nobr,a.adate,c.wk_hrs from attend a,basetts b ,rote c";
                CmdAttRote += " where a.nobr=b.nobr and a.rote=c.rote";
                CmdAttRote += string.Format(@" and '{0}' between b.adate and b.ddate ", date_e);
                CmdAttRote += type_data;
                CmdAttRote += string.Format(@" and a.adate between '{0}' and '{1}'", date_b, date_e);
                DataTable rq_rote = SqlConn.GetDataTable(CmdAttRote);
                rq_rote.PrimaryKey = new DataColumn[] { rq_rote.Columns["nobr"], rq_rote.Columns["adate"] };

                //基準出勤工時
                string CmdAttend = "select dept,sum(wk_hrs) as wk_hrs from  attendbasetts ";
                CmdAttend += string.Format(@" where adate between '{0}' and '{1}'", date_b, date_e);
                CmdAttend += string.Format(@" and comp between '{0}' and '{1}'", comp_b, comp_e);
                CmdAttend += type_data;
                CmdAttend += " group by dept";
                DataTable rq_attend = SqlConn.GetDataTable(CmdAttend);
                rq_attend.PrimaryKey = new DataColumn[] { rq_attend.Columns["dept"] };
                decimal wkhrs = 0;
                foreach (DataRow Row in rq_attend.Rows)
                {
                    wkhrs = wkhrs + decimal.Parse(Row["wk_hrs"].ToString());
                }

                //基準請假時數
                string CmdAbs = "select dept,nobr,tol_hours,bdate,rotet,unit from absbasetts ";
                CmdAbs += string.Format(@" where bdate between '{0}' and '{1}'", date_b, date_e);
                CmdAbs += string.Format(@" and comp between '{0}' and '{1}'", comp_b, comp_e);
                CmdAbs += " and flag='-' and mang <> 1";
                CmdAbs += type_data;
                DataTable rq_absa = SqlConn.GetDataTable(CmdAbs);
                DataTable rq_abs = new DataTable();
                rq_abs.Columns.Add("dept", typeof(string));
                rq_abs.Columns.Add("tol_hours", typeof(string));
                rq_abs.PrimaryKey = new DataColumn[] { rq_abs.Columns["dept"] };
                decimal tolhrs = 0;

                foreach (DataRow Row in rq_absa.Rows)
                {
                    if (Row["unit"].ToString().Trim() == "天")
                    {
                        Object[] _value = new object[2];
                        _value[0] = Row["nobr"].ToString();
                        _value[1] = Row["bdate"].ToString();
                        DataRow row1 = rq_rote.Rows.Find(_value);
                        if (row1 != null)
                        {
                            Row["tol_hours"] = decimal.Round(decimal.Parse(Row["tol_hours"].ToString()) * decimal.Parse(row1["wk_hrs"].ToString()), 2);
                        }
                    }
                    DataRow row = rq_abs.Rows.Find(Row["dept"].ToString());
                    if (row != null)
                    {
                        row["tol_hours"] = decimal.Parse(row["tol_hours"].ToString()) + decimal.Parse(Row["tol_hours"].ToString());
                    }
                    else
                    {
                        DataRow aRow = rq_abs.NewRow();
                        aRow["dept"] = Row["dept"].ToString();
                        aRow["tol_hours"] = decimal.Parse(Row["tol_hours"].ToString());
                        rq_abs.Rows.Add(aRow);
                    }
                    tolhrs = tolhrs + decimal.Parse(Row["tol_hours"].ToString());
                }
                rq_absa = null;

                //基準加班時數
                string CmdOt = "select dept,sum(ot_hrs) as ot_hrs,sum(rest_hrs) as rest_hrs from otbasetts";
                CmdOt += string.Format(@" where bdate between '{0}' and '{1}'", date_b, date_e);
                CmdOt += string.Format(@" and comp between '{0}' and '{1}'", comp_b, comp_e);
                CmdOt += type_data;
                CmdOt += " group by dept";
                DataTable rq_ot = SqlConn.GetDataTable(CmdOt);
                rq_ot.PrimaryKey = new DataColumn[] { rq_ot.Columns["dept"] };
                decimal othrs = 0;
                decimal resthrs = 0;
                foreach (DataRow Row in rq_ot.Rows)
                {
                    othrs = othrs + decimal.Parse(Row["ot_hrs"].ToString());
                    resthrs = resthrs + decimal.Parse(Row["rest_hrs"].ToString());
                }

                //比較出勤工時
                CmdAttend = "select dept,sum(wk_hrs) as wk_hrs from  attendbasetts ";
                CmdAttend += string.Format(@" where adate between '{0}' and '{1}'", otdate_b, otdate_e);
                CmdAttend += string.Format(@" and comp between '{0}' and '{1}'", comp_b, comp_e);
                CmdAttend += type_data;
                CmdAttend += " group by dept";
                DataTable rq_attend1 = SqlConn.GetDataTable(CmdAttend);
                rq_attend1.PrimaryKey = new DataColumn[] { rq_attend1.Columns["dept"] };

                //比較請假時數
                CmdAbs = "select dept,nobr,tol_hours,bdate,unit,rotet from absbasetts ";
                CmdAbs += string.Format(@" where bdate between '{0}' and '{1}'", otdate_b, otdate_e);
                CmdAbs += string.Format(@" and comp between '{0}' and '{1}'", comp_b, comp_e);
                CmdAbs += " and flag='-'";
                CmdAbs += type_data;
                DataTable rq_absb = SqlConn.GetDataTable(CmdAbs);
                DataTable rq_abs1 = new DataTable();
                rq_abs1.Columns.Add("dept", typeof(string));
                rq_abs1.Columns.Add("tol_hours", typeof(string));
                rq_abs1.PrimaryKey = new DataColumn[] { rq_abs1.Columns["dept"] };
                foreach (DataRow Row in rq_absb.Rows)
                {
                    if (Row["unit"].ToString().Trim() == "天")
                    {
                        //DataRow row1 = rq_rote.Rows.Find(Row["rotet"].ToString());
                        Object[] _value = new object[2];
                        _value[0] = Row["nobr"].ToString();
                        _value[1] = Row["bdate"].ToString();
                        DataRow row1 = rq_rote.Rows.Find(_value);
                        if (row1 != null)
                        {
                            Row["tol_hours"] = decimal.Round(decimal.Parse(Row["tol_hours"].ToString()) * decimal.Parse(row1["wk_hrs"].ToString()), 2);
                        }
                    }
                    DataRow row = rq_abs1.Rows.Find(Row["dept"].ToString());
                    if (row != null)
                    {
                        row["tol_hours"] = decimal.Parse(row["tol_hours"].ToString()) + decimal.Parse(Row["tol_hours"].ToString());
                    }
                    else
                    {
                        DataRow aRow = rq_abs1.NewRow();
                        aRow["dept"] = Row["dept"].ToString();
                        aRow["tol_hours"] = decimal.Parse(Row["tol_hours"].ToString());
                        rq_abs1.Rows.Add(aRow);
                    }
                    tolhrs = tolhrs + decimal.Parse(Row["tol_hours"].ToString());
                }
                rq_absb = null;

                //比較加班時數
                CmdOt = "select dept,sum(ot_hrs) as ot_hrs,sum(rest_hrs) as rest_hrs from otbasetts";
                CmdOt += string.Format(@" where bdate between '{0}' and '{1}'", otdate_b, otdate_e);
                CmdOt += string.Format(@" and comp between '{0}' and '{1}'", comp_b, comp_e);
                CmdOt += " group by dept";
                DataTable rq_ot1 = SqlConn.GetDataTable(CmdOt);
                rq_ot1.PrimaryKey = new DataColumn[] { rq_ot1.Columns["dept"] };

                foreach (DataRow Row in ds.Tables["zz28"].Rows)
                {
                    DataRow row = rq_attend.Rows.Find(Row["dept"].ToString());
                    if (row != null)
                    {
                        Row["wk_hrs"] = decimal.Parse(row["wk_hrs"].ToString());
                        Row["wk_pr"] = (row["wk_hrs"].ToString() == "" || wkhrs == 0) ? 0 : decimal.Round((decimal.Parse(row["wk_hrs"].ToString()) / wkhrs) * 100, 2);
                    }
                    DataRow row1 = rq_attend1.Rows.Find(Row["dept"].ToString());
                    if (row1 != null) Row["wk_hrs1"] = decimal.Round(decimal.Parse(row1["wk_hrs"].ToString()), 2);

                    DataRow row2 = rq_abs.Rows.Find(Row["dept"].ToString());
                    if (row2 != null)
                    {
                        Row["tol_hours"] = decimal.Round(decimal.Parse(row2["tol_hours"].ToString()), 2);
                        Row["tol_pr"] = (row2["tol_hours"].ToString() == "" || tolhrs == 0) ? 0 : decimal.Round((decimal.Parse(row2["tol_hours"].ToString()) / tolhrs) * 100, 2);
                    }
                    DataRow row3 = rq_abs1.Rows.Find(Row["dept"].ToString());
                    if (row3 != null) Row["tol_hours1"] = decimal.Parse(row3["tol_hours"].ToString());

                    DataRow row4 = rq_ot.Rows.Find(Row["dept"].ToString());
                    if (row4 != null)
                    {
                        Row["ot_hrs"] = (row4["ot_hrs"].ToString() == "") ? 0 : decimal.Round(decimal.Parse(row4["ot_hrs"].ToString()), 2);
                        Row["res_hrs"] = (row4["rest_hrs"].ToString() == "") ? 0 : decimal.Round(decimal.Parse(row4["rest_hrs"].ToString()), 2);
                        Row["ot_pr"] = (row4["ot_hrs"].ToString() == "" || othrs == 0) ? 0 : decimal.Round((decimal.Parse(row4["ot_hrs"].ToString()) / othrs) * 100, 2);
                        Row["res_pr"] = (row4["rest_hrs"].ToString() == "" || resthrs==0) ? 0 : decimal.Round((decimal.Parse(row4["rest_hrs"].ToString()) / resthrs) * 100, 2);

                    }
                    DataRow row5 = rq_ot1.Rows.Find(Row["dept"].ToString());
                    if (row5 != null)
                    {
                        Row["ot_hrs1"] = decimal.Round(decimal.Parse(row5["ot_hrs"].ToString()), 2);
                        Row["res_hrs1"] = decimal.Round(decimal.Parse(row5["rest_hrs"].ToString()), 2);
                    }
                    Row["tot_pr"] = decimal.Round(((decimal.Parse(Row["wk_hrs"].ToString()) - decimal.Parse(Row["tol_hours"].ToString()) + decimal.Parse(Row["ot_hrs"].ToString()) + decimal.Parse(Row["res_hrs"].ToString())) / (wkhrs - tolhrs + othrs + resthrs)) * 100, 2);
                    Row["dept"] = Row["d_no_disp"].ToString();
                }
                rq_abs = null;
                rq_abs1 = null;
                rq_attend = null;
                rq_attend1 = null;
                rq_ot = null;
                rq_ot1 = null;
                if (ds.Tables["zz28"].Rows.Count < 1)
                {
                    MessageBox.Show(Resources.Reports.NotData, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Close();
                    return;
                }
                if (exportexcel)
                {
                    Export(ds.Tables["zz28"]);
                    this.Close();
                }
                else
                {                    
                    RptViewer.Reset();
                    //string _floor1 = JBModule.Pluging.CReport.GetDirectory(Application.StartupPath, "Reports");
                    //string _rptpath = JBModule.Pluging.CReport.GetDirectory(_floor1, "AttReport");
                    string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "AttReport", "*.rdlc");
                    
                    RptViewer.LocalReport.ReportPath = _rptpath + "Rpt_zz28.rdlc";
                    RptViewer.LocalReport.DataSources.Clear();
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", comp_name) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateB", date_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DateE", date_e) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYMMB", otdate_b) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YYMME", otdate_e) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("attenddata_zz28", ds.Tables["zz28"]));
                    RptViewer.SetDisplayMode(DisplayMode.PrintLayout);
                    RptViewer.ZoomMode = ZoomMode.FullPage;
                    //RptViewer.ZoomPercent = JBHR.Reports.ReportClass.GetReportPercent();

                }
                //if (exportexcel)
                //    PPT_ReportForm.DataClass.Export_Excel(ds.Tables["zz28"]);
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
            ExporDt.Columns.Add("部門英文名稱", typeof(string));
            ExporDt.Columns.Add("出勤基準", typeof(decimal));
            ExporDt.Columns.Add("出勤百分比", typeof(decimal));
            ExporDt.Columns.Add("出勤比較", typeof(decimal));
            ExporDt.Columns.Add("加班基準", typeof(decimal));
            ExporDt.Columns.Add("加班百分比", typeof(decimal));
            ExporDt.Columns.Add("加班比較", typeof(decimal));
            ExporDt.Columns.Add("補休基準", typeof(decimal));
            ExporDt.Columns.Add("補休百分比", typeof(decimal));
            ExporDt.Columns.Add("補休比較", typeof(decimal));
            ExporDt.Columns.Add("請假基準", typeof(decimal));
            ExporDt.Columns.Add("請假百分比", typeof(decimal));
            ExporDt.Columns.Add("請假比較", typeof(decimal));
            ExporDt.Columns.Add("總計基準", typeof(decimal));
            ExporDt.Columns.Add("總計百分比", typeof(decimal));
            ExporDt.Columns.Add("總計比較", typeof(decimal));
            foreach (DataRow Row in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row["dept"].ToString();
                aRow["部門名稱"] = Row["d_name"].ToString();
                aRow["部門英文名稱"] = Row["d_ename"].ToString();
                aRow["出勤基準"] = decimal.Parse(Row["wk_hrs"].ToString());
                aRow["出勤百分比"] = decimal.Parse(Row["wk_pr"].ToString());
                aRow["出勤比較"] = decimal.Parse(Row["wk_hrs"].ToString()) - decimal.Parse(Row["wk_hrs1"].ToString());
                aRow["加班基準"] = decimal.Parse(Row["ot_hrs"].ToString());
                aRow["加班百分比"] = decimal.Parse(Row["ot_pr"].ToString());
                aRow["加班比較"] = decimal.Parse(Row["ot_hrs"].ToString()) - decimal.Parse(Row["ot_hrs1"].ToString());
                aRow["補休基準"] = decimal.Parse(Row["res_hrs"].ToString());
                aRow["補休百分比"] = decimal.Parse(Row["res_pr"].ToString());
                aRow["補休比較"] = decimal.Parse(Row["res_hrs"].ToString()) - decimal.Parse(Row["res_hrs"].ToString());
                aRow["請假基準"] = decimal.Parse(Row["tol_hours"].ToString());
                aRow["請假百分比"] = decimal.Parse(Row["tol_pr"].ToString());
                aRow["請假比較"] = decimal.Parse(Row["tol_hours"].ToString()) - decimal.Parse(Row["tol_hours1"].ToString());
                aRow["總計基準"] = decimal.Parse(Row["wk_hrs"].ToString()) - decimal.Parse(Row["tol_hours"].ToString()) + decimal.Parse(Row["ot_hrs"].ToString()) + decimal.Parse(Row["res_hrs"].ToString());
                aRow["總計百分比"] = decimal.Parse(Row["tot_pr"].ToString());
                aRow["總計比較"] = decimal.Parse(aRow["總計基準"].ToString()) - decimal.Parse(Row["wk_hrs1"].ToString()) - decimal.Parse(Row["tol_hours1"].ToString()) + decimal.Parse(Row["ot_hrs1"].ToString()) + decimal.Parse(Row["res_hrs1"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, this.Name);
        }
    }
}
